//NEED TO FIX UPDATE ROUTE AND ADD COMPLETED OPTION

import { Component, OnInit } from '@angular/core';
import { HttpService } from './http.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Restful Tasks API';
  dataIn: boolean = false;
  showData: boolean = false;
  showForm: boolean = false;
  tasks = [];
  task1:any = [];
  newTask: any;
  task:any;
  constructor(private _httpService: HttpService){}
  ngOnInit(){
    this.newTask = { title: "", description: "" }
  };
  getTasksFromService(){
    let tempObservable = this._httpService.getTasks();
    tempObservable.subscribe(data => {
      console.log("Got our tasks!", data)
      this.tasks = data["tasks"];
      console.log(this.tasks);
      this.dataIn = true;
    } )
  }
  getTaskByIDFromService(){
    let tempObservable = this._httpService.getTaskByID();
    tempObservable.subscribe(data => {
      console.log("Got the task!", data);
      this.tasks = data["task"];
    })
  }
  //SPLIT INTO TWO FUNCTIONS:
  updateTaskFromService(data): void {
    let tempObservable = this._httpService.updateTask(data);
    tempObservable.subscribe(data =>{
    console.log("Updating task ", data);
    this.showForm = true;
    this.tasks = data["task"];
  })
  }
  deleteTaskFromService(id:string){
    let tempObservable = this._httpService.deleteTask(id);
    tempObservable.subscribe(data => {
      console.log("Deleting task", data);
    })
    this.getTasksFromService();
    this.task1={ title: "", description: "" };
  }
  displayData(id:string){
    let tempObservable = this._httpService.displayData(id);
    tempObservable.subscribe(data=>{
      console.log("Displaying task data for id ", id);
      this.showData=true;
      console.log(data);
      this.task1 = data["task"];
      console.log(this.task1);
    })
  }
  onSubmit() {
    //code to send off form data (this.newTask) to the Service
    let tempObservable = this._httpService.addTask(this.newTask);
    tempObservable.subscribe(data => {
      console.log("Sending data to service.", data);
      this.newTask = { title: "", description: ""}
      // this.getTasksFromService();
      this.tasks.push(data["task"]);
    })
  }
}