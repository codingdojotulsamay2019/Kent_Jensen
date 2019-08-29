import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-burbank',
  templateUrl: './burbank.component.html',
  styleUrls: ['./burbank.component.css']
})
export class BurbankComponent implements OnInit {
  burbank: Object;

  constructor(private _httpservice: HttpService) { }

  ngOnInit() {
    this.getBurbankFromService();
  }
  getBurbankFromService() {
  this._httpservice.getBurbank().subscribe( data => {
    console.log(data);
    this.burbank = data;
  })
  }
  convertToF(x: number){
    return ((x-273.15) * (9/5) + 32).toFixed(2)
  }
}