import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-sanjose',
  templateUrl: './sanjose.component.html',
  styleUrls: ['./sanjose.component.css']
})
export class SanjoseComponent implements OnInit {
  sanjose: Object;

  constructor(private _httpservice: HttpService) { }

  ngOnInit() {
    this.getSanjoseFromService();
  }
  getSanjoseFromService() {
  this._httpservice.getSanjose().subscribe( data => {
    console.log(data);
    this.sanjose = data;
  })
  }
  convertToF(x: number){
    return ((x-273.15) * (9/5) + 32).toFixed(2)
  }
}