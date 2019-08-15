// FULL DISCLOSURE: I did not write the base code for this assignment,
// but I did complete the modularization on my own.
// I am a little behind, and in order to try to keep up and complete more advanced assignments like I was asked, 
// I didn't complete Quoting Dojo. Mason gifted me this code of his own volition and without my asking
// to be able to modularize this assignment to make progress forward. Again, I take no credit for the base code.

const mongoose = require('mongoose'),
Quote = mongoose.model('Quote')
module.exports = function(app){
const QuoteSchema = new mongoose.Schema({
name: { type: String, required: true, minlength:1},
quote: { type: String, required: true, minlength: 5}
}, {timestamps: true})
const QuoteSchema=mongoose.model('Quote', UserQuote);
}