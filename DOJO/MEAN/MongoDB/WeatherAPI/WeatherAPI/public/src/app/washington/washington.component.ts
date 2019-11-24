import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-washington',
  templateUrl: './washington.component.html',
  styleUrls: ['./washington.component.css']
})
export class WashingtonComponent implements OnInit {
  washington: Object;

  constructor(private _httpservice: HttpService) { }

  ngOnInit() {
    this.getWashingtonFromService();
  }
  getWashingtonFromService() {
  this._httpservice.getWashington().subscribe( data => {
    console.log(data);
    this.washington = data;
  })
  }
  convertToF(x: number){
    return ((x-273.15) * (9/5) + 32).toFixed(2)
  }
}