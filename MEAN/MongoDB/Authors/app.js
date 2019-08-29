const express = require('express');
const mongoose = require('mongoose');
const path = require('path');
const app = express();
mongoose.connect('mongodb://localhost/Authors', {useNewUrlParser: true});

app.use(express.static ( __dirname + '/public/dist/public'));
app.use(express.json())






//keep this next section here, put things above it, but not below!
app.all("*", (req,res,next) => {
    res.sendFile(path.resolve("./public/dist/public/index.html"))
});

app.listen(8000, ()=> {console.log("listening on port 8000")});