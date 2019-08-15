//modify to make work
const mongoose = require('mongoose'),
Task = mongoose.model('Task')
module.exports = function(app){
const TaskSchema = new mongoose.Schema({
title: { type: String, required: true, minlength:3},
description: { type: String, required: true, minlength: 5},
completed: {type:Boolean, required: true},
created_at: {type:Date, required: true},
updated_at: {type: Date, required: true}
}, {timestamps: true})
const Task=mongoose.model('Task', TaskSchema);
}
// _id: (string)
// title: (string)
// description: (string, default to empty)
// completed: (boolean, default to false)
// created_at: (date, default to current)
// updated_at: (date, default to current)