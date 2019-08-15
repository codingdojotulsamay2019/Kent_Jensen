const express = require("express");
const app= express();
app.use(express.json());

//Mongoose
const mongoose = require('mongoose');

mongoose.connect('mongodb://localhost/RestfulAPI', {useNewUrlParser: true});

require('./server/models/task.js')

require('./server/config/routes.js')(app)

require('./server/controllers/tasks.js')

app.listen(8000, () => console.log ("listening on port 8000"));