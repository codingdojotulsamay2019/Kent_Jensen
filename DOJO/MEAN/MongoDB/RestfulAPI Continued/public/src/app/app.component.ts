import { Component, OnInit } from '@angular/core';
import { HttpService } from './http.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Restful Tasks API';
  loggedIn: boolean;
  tasks = [];
  constructor(private _httpService: HttpService){}
  ngOnInit(){
    this.getTasksFromService()
  };
  getTasksFromService(){
    let tempObservable = this._httpService.getTasks();
    tempObservable.subscribe(data => {
      console.log("Got our tasks!", data)
      this.tasks = data["tasks"];
      console.log(this.tasks);
      this.loggedIn = true;
    } )
  }
  getTaskByIDFromService(){
    let tempObservable = this._httpService.getTaskByID();
    tempObservable.subscribe(data => {
      console.log("Got the task!", data);
      this.tasks = data["task"];
    })
  }
  createTaskFromService(data){
    let tempObservable = this._httpService.createTask(data);
    tempObservable.subscribe(data => {
      console.log("Creating task", data);
    })
  }
  updateTaskFromService(data) {
    let tempObservable = this._httpService.updateTask(data);
    tempObservable.subscribe(data =>{
    console.log("Updating task",data);
  })
  }
  deleteTaskFromService(){
    let tempObservable = this._httpService.deleteTask();
    tempObservable.subscribe(data => {
      console.log("Deleting task");
    })
  }
}


