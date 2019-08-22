const mongoose = require('mongoose'),
Task = mongoose.model('Task')
const tasks = require('../controllers/tasks.js')
module.exports = function(app){
    // GET all tasks
    app.get("/tasks", tasks.Show)
    // GET by ID
    app.get('/task/:id',tasks.GetID)
    // POST new task
    app.post("/task/new", tasks.New)
    // PUT updates task
    app.put('/task/:id', tasks.Update)
    // DELETE task by ID
    app.delete('/task/:id', tasks.Delete)
}