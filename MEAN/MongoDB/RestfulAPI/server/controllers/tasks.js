//modify to make work

const mongoose = require('mongoose'),
Task = mongoose.model('Task')
module.exports = {
    // GET /quotes
    Home : (req, res) => {
        res.redirect('/tasks')
    },
    Index : (req, res) => {
    console.log("getting tasks")
    Task.find()
        .then(allTasks => {
            console.log("success!");
            console.log(allTasks)
            res.json({tasks: allTasks})
        })
        .catch(err => {
            console.log("******* error:")
            console.log(err);
            res.json({err: err})
        })
    },
    New : (req,res) => {
        console.log(req.body)
        Task.create(req.body)
            .then(success => {
                console.log("success path to add new data")
                res.json({task:success})
            })
            .catch(err => {
                res.json({task:err});
                }
            )
    },
    GetID : (req,res) => {
        console.log("Getting task ID: "+ _id);
        Task.findByID(id)
        res.json({task:data})
    },
    Update: (req,res) => {
        console.log(req.body)
        const {id} = req.params;
        Task.updateOne({_id:id}, req.body)
            .then(success => {
                console.log("success path to update data")
                res.json({task:success})
            })
            .catch(err => {
                res.json({task:err});
            })
    },
    Delete: (req,res) =>{
        const {id} = req.params
        Task.remove({_id:id})
        .then(data => {
            res.json(data)
        })
        .catch(err => {
            res.json(task.err)
        })
        
    }
}