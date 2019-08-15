// FULL DISCLOSURE: I did not write the base code for this assignment,
// but I did complete the modularization on my own.
// I am a little behind, and in order to try to keep up and complete more advanced assignments like I was asked, 
// I didn't complete Quoting Dojo. Mason gifted me this code of his own volition and without my asking
// to be able to modularize this assignment to make progress forward. Again, I take no credit for the base code.

const mongoose = require('mongoose'),
Quote = mongoose.model('Quote')
module.exports = function(app){
    // root route
    app.get("/", (req, res) => {
        console.log("Root Route")
        res.render('index')
    })
    app.get('/', function(req, res){
        quotes.index(req, res);
    })
    // POST /quotes
    app.post("/quotes", (req,res) => {
        console.log("post /quotes")
        console.log(req.body)
        Quote.create(req.body)
            .then(success => console.log("success!"))
            .catch(err => {
                for(let e in err.errors) {
                console.log(err.errors[e].message);
                req.flash('name', err.errors[e].message);
                }
            })
            .finally(()=> {
                res.redirect('/');
            })
    })
}