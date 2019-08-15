//GET: Retrieve all tasks
//GET: Retrieve a task by ID
//POST: Create a task
// PUT: Update a task by ID
// DELETE: Delete a task by ID

//JSON should have: 
// _id: (string)
// title: (string)
// description: (string, default to empty)
// completed: (boolean, default to false)
// created_at: (date, default to current)
// updated_at: (date, default to current)


const express = require("express");
const app= express();
//static files
app.use(express.static(__dirname+"/static"));
//views ejs
app.set("view engine", "ejs");
app.set("views",__dirname+"/views");
//form data
app.use(express.urlencoded({extended: true}));
//Mongoose
const mongoose = require('mongoose');

mongoose.connect('mongodb://localhost/RestfulAPI', {useNewUrlParser: true});

require('./server/config/routes.js')(app)

require('./server/models/task.js')(app)

require('./server/controllers/tasks.js')(app)

app.listen(8000, () => console.log ("listening on port 8000"));