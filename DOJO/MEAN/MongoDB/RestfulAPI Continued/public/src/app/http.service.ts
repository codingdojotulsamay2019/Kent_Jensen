import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class HttpService {
  constructor(private _http: HttpClient){
   }
   getTasks(){
      return this._http.get('/tasks');
   }
   getTaskByID(){
      return this._http.get('/task/:id');
   }
   createTask(data){
      return this._http.post('/task/new', data);
   }
   updateTask(data){
      return this._http.put('/task/:id', data);
   }
   deleteTask(){
      return this._http.delete('/task/:id');
   }
}