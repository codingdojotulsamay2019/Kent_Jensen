const mongoose = require('mongoose'),
Task = mongoose.model('Task')
const tasks = require('../controllers/tasks.js')
module.exports = function(app){
    //Redirects to /tasks
    app.get("/", tasks.Home)
    // GET all tasks
    app.get("/tasks", tasks.Index)
    //GET by ID
    app.get('/task/:id',tasks.GetID)
    // POST new task
    app.post("/task/new", tasks.New)
    // PUT updates task
    app.put('/task/:id', tasks.Update)
    app.delete('/task/:id', tasks.Delete)
}
