// I'm not sure what to do to get this to show the Angular page on the root route.
// I've tried everything I could think of, but couldn't figure it out. 
const express = require("express");
const app= express();
app.use(express.json());
app.use(express.static( __dirname + 'public/dist/public' ));

//Mongoose
const mongoose = require('mongoose');

mongoose.connect('mongodb://localhost/RestfulAPI', {useNewUrlParser: true});

require('./server/models/task.js')

require('./server/config/routes.js')(app)

require('./server/controllers/tasks.js')

app.listen(8000, () => console.log ("listening on port 8000"));