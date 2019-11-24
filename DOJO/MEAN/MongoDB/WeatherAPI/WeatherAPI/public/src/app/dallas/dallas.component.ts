import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-dallas',
  templateUrl: './dallas.component.html',
  styleUrls: ['./dallas.component.css']
})
export class DallasComponent implements OnInit {
  dallas: Object;

  constructor(private _httpservice: HttpService) { }

  ngOnInit() {
    this.getDallasFromService();
  }
  getDallasFromService() {
  this._httpservice.getDallas().subscribe( data => {
    console.log(data);
    this.dallas = data;
  })
  }
  convertToF(x: number){
    return ((x-273.15) * (9/5) + 32).toFixed(2)
  }
}