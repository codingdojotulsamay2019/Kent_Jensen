const express = require("express");
const mongoose = require('mongoose');
const app = express();
const flash = require('express-flash');
const bcrypt= require('bcrypt');
const session = require('express-session');
mongoose.connect('mongodb://localhost/logreg', {useNewUrlParser: true});

const UserSchema = new mongoose.Schema({
    email: {type: String, required: [true, "email required"],
        match: [/^\w+([.-]?\w+)@\w+([.-]?\w+)(.\w{2,3})+$/, 'Please fill in a valid email address']},
    first_name: {type: String, required: [true, "first name required"]},
    last_name: {type: String, required: [true, "last name required"]},
    password: {type: String, required: [true, "password required"]},
    birthday: {type: Date, required: [true, "birthday required"]}
}, {timestamps:true}
)
const User = mongoose.model('User', UserSchema);

app.set('view engine', 'ejs');
app.set('views', __dirname + '/views');
app.set('trust proxy', 1) // trust first proxy
app.use(express.urlencoded({extended: true}));
app.use(flash());
app.use(session({
  secret: 'keyboard cat',
  resave: false,
  saveUninitialized: true,
  cookie: { maxAge: 60000 }
}))

app.get('/', (req,res) => {
    res.render('index');
})

app.post('/register', (req,res) => {
    console.log(req.body);
    bcrypt.hash(req.body.password, 10)
    .then(hashedpw => {
        req.body.password = hashedpw;
        User.create(req.body)
        .then(success => {
            console.log("***REGISTRATION SUCCESS***", success);
            res.redirect('/success');
        })
        .catch(err => {
            console.log("We have an error!", err);
            for (var key in err.errors) {
                req.flash('errors', err.errors[key].message);
            }
            res.redirect('/')
        })
    })
})

app.get('/success', (req,res) => {
    res.render('success');
});

app.post('/login', (req, res) => {
    console.log(" req.body: ", req.body);
    User.findOne({email:req.body.email_login}, (err, user) => {
        if (err) {
            // error reporting path
            console.log("***Error occurred***");
            console.log(err);
            res.redirect('/');
        }
        else {
            // successful path
            bcrypt.compare(req.body.password_login, user.password)
                .then(result => {
                    console.log("LOGIN SUCCESS!")
                    req.session.user_id = user._id;
                    req.session.email = user.email;
                    req.session.trusted = true;
                    res.redirect('/success')
                })
                .catch(err => {
                    console.log("***LOGIN FAILURE***");
                    console.log(err);
                    req.session.trusted = false;
                    for (var key in err.errors) {
                        req.flash('errors', err.errors[key].message)
                    }
                    res.redirect('/')
                })
        }
    })
})

app.listen(8000, () => console.log("listening on port 8000"));