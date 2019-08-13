const express = require("express");
const mongoose = require('mongoose');
const app = express();
const session = require('express-session');

app.use(session({
    secret: 'keyboardkitteh',
    resave: false,
    saveUninitialized: true,
    cookie: { maxAge: 60000 }
    }))
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
const Message = mongoose.model('Message', MessageSchema);
app.use(express.urlencoded({extended: true}));
app.use(express.static(__dirname + "/static"));
app.set('view engine', 'ejs');
app.set('views', __dirname + '/views');
app.get('/', (req, res) => {  
    Message.find()
        .then(data => {
            res.render("index", {message: data})})
        .catch(err => res.json(err));
});
app.post('/', (req, res) => {
    console.log("POSTING MESSAGE")
    const message = new Message();
    message.name = req.body.name;
    message.content = req.body.content;
    message.save()
        .then(newMessageData => console.log('message created: ', newMessageData))
        .catch(err => console.log(err));
    res.redirect('/');
})
// THIS DOES THE SAME THING AS THE ONE ABOVE!
// app.post('/', (req, res) => {
//     console.log("POSTING MESSAGE")
//     Message.create(req.body)
//         .then(newMessageData => console.log('message created: ', newMessageData))
//         .catch(err => console.log(err));
//     res.redirect('/');
// })
app.get('/comment', (req,res) => {
    console.log('loading comments')
    res.redirect('/')
})

app.post('/comment', (req,res) => {
    console.log("POSTING COMMENT")
    Comment.create(req.body)
        .then(newCommentData => console.log('comment created: ', newCommentData))
        .catch(err => console.log(err));
    res.redirect('/')
})

app.listen(8000, () => console.log("listening on port 8000"));