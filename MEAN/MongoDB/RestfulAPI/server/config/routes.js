//modify to make work

const mongoose = require('mongoose'),
Quote = mongoose.model('Quote')
module.exports = function(app){
    //GET: Retrieve all tasks /tasks
    //GET: Retrieve a task by ID /task/:id
    //POST: Create a task /task/new
    // PUT: Update a task by ID /task/update
    // DELETE: Delete a task by ID /task/destroy
    //RENDER index
    app.get("/", (req, res) => {
        console.log("This shows index");
        res.render('index')
    })
    // GET all tasks
    app.get('/tasks', function(req, res){
        Task.find()
        .then(data => res.render('index', {tasks:data}))
        .catch(err => res.json(err));
    })
    //GET by ID
    app.get('/task/:id', (req,res) =>{
        console.log("Getting task ID: "+ _id);
        Task.findByID(id)
        res.render('show', {task:data})
    })
    // POST new task
    app.post("/task/new", (req,res) => {
        console.log(req.body)
        Task.create(req.body)
            .then(success => console.log("success!"))
            .catch(err => {
                for(let e in err.errors) {
                console.log(err.errors[e].message);
                }
            })
            .finally(()=> {
                res.redirect('/');
            })
    })
    // PUT updates task
    app.put('/task/:id', (req,res) => {
        res.redirect('show')
    })
    app.delete('/task/:id', (req,res) =>{
        res.redirect('index')
    })
}