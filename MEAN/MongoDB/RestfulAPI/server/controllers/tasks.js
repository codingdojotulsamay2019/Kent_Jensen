//modify to make work

const mongoose = require('mongoose'),
Task = mongoose.model('Task')
module.exports = {
    // GET /quotes
    Show : (req, res) => {
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
                console.log("******* error:")
                console.log(err);
                res.json({task:err});
                }
            )
    },
    GetID : (req,res) => {
        const {id} = req.params;
        console.log("Getting task ID: "+ id);
        Task.find({_id:id})
            .then(success => {
                console.log("retrieved data by ID")
                res.json({task:success})
            })
            .catch(err => {
                console.log("******* error:")
                console.log(err);
                res.json({task:err});
            })
    },
    Update: (req,res) => {
        console.log(req.body)
        const {id} = req.params;
        Task.updateOne({_id:id}, req.body)
            .then(success => {
                console.log("data updated successfully")
                res.json({task:success})
            })
            .catch(err => {
                console.log("******* error:")
                console.log(err);
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
            console.log("******* error:");
            console.log(err);
            res.json(err);
        })
    }
}