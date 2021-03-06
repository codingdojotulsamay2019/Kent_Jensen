const express = require("express");
const mongoose = require('mongoose');
const app = express();
const session = require('express-session');
const flash = require('express-flash');
mongoose.connect('mongodb://localhost/MessageBoard', {useNewUrlParser: true});

const CommentSchema = new mongoose.Schema({
    name: {type: String, required: [true, "Name required"]},
    content: {type: String, required: [true, "Content required"], minlength: [5,"comment must be at least 5 characters"]},
}, {timestamps:true}
)
const MessageSchema = new mongoose.Schema({
    name: {type: String, required: [true, "Name required"]},
    content: {type: String, required: [true, "Message required"], minlength: [5, "Message must be at least 5 characters."]},
    comments: [CommentSchema]}, {timestamps: true}
    )
const Comment = mongoose.model('Comment', CommentSchema);
const Message = mongoose.model('Message', MessageSchema);
app.use(express.urlencoded({extended: true}));
app.use(express.static(__dirname + "/static"));
app.use(flash());
app.use(session({
    secret: 'keyboardkitteh',
    resave: false,
    saveUninitialized: true,
    cookie: { maxAge: 60000 }
    }))
app.set('view engine', 'ejs');
app.set('views', __dirname + '/views');
app.get('/', (req, res) => {
    Message.find()
    .then(data => {
        console.log(data)
        res.render("index", {message: data})})
    .catch(err => res.render('message', {err: err}))
})
app.post('/', (req, res) => {
    console.log("POSTING MESSAGE")
    const message = new Message();
    message.name = req.body.name;
    message.content = req.body.content;
    message.save()
        .then(newMessageData => {
            console.log('message created: ', newMessageData)
            res.redirect('/')
        })
        .catch(err => {
            console.log("We have an error!", err)
            // adjust the code below as needed to create a flash message with the tag and content you would like
            for (var key in err.errors) {
                req.flash('errors', err.errors[key].message)
            }
            res.redirect('/')
        })


// THIS DOES THE SAME THING AS THE ONE ABOVE!
// app.post('/', (req, res) => {
//     console.log("POSTING MESSAGE")
//     Message.create(req.body)
//         .then(newMessageData => console.log('message created: ', newMessageData))
//         .catch(err => console.log(err));
//     res.redirect('/');
// })

app.post('/comment/:id', (req,res) => {
    console.log("POSTING COMMENT");
    console.log(req.params.id);
    Comment.create(req.body)
        .then(newCommentData => {
            console.log('comment created: ', newCommentData);
            return Message.updateOne({_id: req.params.id}, {
                $push: {comments: newCommentData}
            })
        .catch(err => {
            console.log("We have an error!", err);
            for (var key in err.errors) {
                req.flash('errors', err.errors[key].message);
            }
        })
        .finally(()=> res.redirect('/'))
        })
})
})
app.listen(8000, () => console.log("listening on port 8000"));