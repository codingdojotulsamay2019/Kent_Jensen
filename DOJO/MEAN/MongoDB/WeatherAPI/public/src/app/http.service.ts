import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

//API KEY : {appid=a52263ca0f86311796b5972320aa23ef}

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private _http: HttpClient) {
    
   }
  getBurbank(){
    return this._http.get('http://api.openweathermap.org/data/2.5/weather?q=burbank&appid=a52263ca0f86311796b5972320aa23ef')
  }
  getChicago(){
    return this._http.get('http://api.openweathermap.org/data/2.5/weather?q=chicago&appid=a52263ca0f86311796b5972320aa23ef')
  }
  getDallas(){
    return this._http.get('http://api.openweathermap.org/data/2.5/weather?q=dallas&appid=a52263ca0f86311796b5972320aa23ef')
  }
  getSanjose(){
    return this._http.get('http://api.openweathermap.org/data/2.5/weather?q=san%20jose&appid=a52263ca0f86311796b5972320aa23ef')
  }
  getSeattle(){
    return this._http.get('http://api.openweathermap.org/data/2.5/weather?q=seattle&appid=a52263ca0f86311796b5972320aa23ef')
  }
  getWashington(){
    return this._http.get('http://api.openweathermap.org/data/2.5/weather?q=washington&appid=a52263ca0f86311796b5972320aa23ef')
  }
}
