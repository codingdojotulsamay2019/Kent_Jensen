// FULL DISCLOSURE: I did not write the base code for this assignment,
// but I did complete the modularization on my own.
// I am a little behind, and in order to try to keep up and complete more advanced assignments like I was asked, 
// I didn't complete Quoting Dojo. Mason gifted me this code of his own volition and without my asking
// to be able to modularize this assignment to make progress forward. Again, I take no credit for the base code.

const express = require("express");
const app= express();
//static files
app.use(express.static(__dirname+"/static"));
//views ejs
app.set("view engine", "ejs");
app.set("views",__dirname+"/views");
//form data
app.use(express.urlencoded({extended: true}));
//Flash
const flash = require('express-flash');
app.use(flash());
//Session
const session = require('express-session');
app.use(session({
  secret: 'keyboardkitteh',
  resave: false,
  saveUninitialized: true,
  cookie: { maxAge: 60000 }
}))
//Mongoose
const mongoose = require('mongoose');

mongoose.connect('mongodb://localhost/QuotingDojo', {useNewUrlParser: true});

require('./server/config/routes.js')(app)

require('./server/models/quote.js')(app)

require('./server/controllers/quotes.js')(app)

app.listen(8000, () => console.log ("listening on port 8000"));