//modify to make work
const mongoose = require('mongoose')
const TaskSchema = new mongoose.Schema({
title: { type: String, required: true, minlength:3},
description: { type: String, required: true, minlength: 5},
completed: {type:Boolean, required: false},
}, {timestamps: true})

const Task=mongoose.model('Task', TaskSchema);
// _id: (string)
// title: (string)
// description: (string, default to empty)
// completed: (boolean, default to false)
// created_at: (date, default to current)
// updated_at: (date, default to current)