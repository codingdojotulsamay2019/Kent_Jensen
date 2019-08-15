//modify to make work

const mongoose = require('mongoose'),
Quote = mongoose.model('Quote')
module.exports = function(app){
    // GET /quotes
app.get("/quotes", (req, res) => {
    console.log("get /quotes")
    Quote.find()
        .then(allQuotes => {
            console.log("success!");
            console.log(allQuotes)
            res.render('show', {quotes: allQuotes})
        })
        .catch(err => {
            console.log("******* error:")
            console.log(err);
            res.render('show', {err: err})
        })
})
}