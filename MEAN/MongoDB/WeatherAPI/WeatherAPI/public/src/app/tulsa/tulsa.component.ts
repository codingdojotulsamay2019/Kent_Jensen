import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-tulsa',
  templateUrl: './tulsa.component.html',
  styleUrls: ['./tulsa.component.css']
})
export class TulsaComponent implements OnInit {
  tulsa: Object;

  constructor(private _httpservice: HttpService) { }

  ngOnInit() {
    this.getTulsaFromService();
  }
  getTulsaFromService() {
  this._httpservice.getTulsa().subscribe( data => {
    console.log(data);
    this.tulsa = data;
  })
  }
  convertToF(x: number){
    return ((x-273.15) * (9/5) + 32).toFixed(2)
  }
}
