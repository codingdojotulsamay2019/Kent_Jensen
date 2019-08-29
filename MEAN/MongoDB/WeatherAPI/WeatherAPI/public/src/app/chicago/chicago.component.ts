import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-chicago',
  templateUrl: './chicago.component.html',
  styleUrls: ['./chicago.component.css']
})
export class ChicagoComponent implements OnInit {
  chicago: Object;

  constructor(private _httpservice: HttpService) { }

  ngOnInit() {
    this.getChicagoFromService();
  }
  getChicagoFromService() {
  this._httpservice.getChicago().subscribe( data => {
    console.log(data);
    this.chicago = data;
  })
  }
  convertToF(x: number){
    return ((x-273.15) * (9/5) + 32).toFixed(2)
  }
}