import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class HttpService {
  constructor(private _http: HttpClient){
     this.getTasks();
   }
   getTasks(){
   // our http response is an Observable, store it in a variable
      let tempObservable = this._http.get('/tasks');
   // subscribe to the Observable and provide the code we would like to do with our data from the response
      tempObservable.subscribe(data => console.log("Got our tasks!", data));
   }
   getTaskByID(){
      let tempObservable = this._http.get('/task/:id');
      tempObservable.subscribe(data => console.log("Got the task!", data));
   }
   createTask(data){
      let tempObservable = this._http.post('/task/new', data);
      tempObservable.subscribe(data => console.log("Adding a new task!", data));
   }
   updateTask(data){
      let tempObservable = this._http.put('/task/:id', data);
      tempObservable.subscribe(data => console.log("Updated the task!", data));
   }
   deleteTask(){
      let tempObservable = this._http.delete('/task/:id');
      tempObservable.subscribe(data => console.log("Deleted the task!", data));
   }
}