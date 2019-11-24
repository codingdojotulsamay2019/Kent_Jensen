import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-seattle',
  templateUrl: './seattle.component.html',
  styleUrls: ['./seattle.component.css']
})
export class SeattleComponent implements OnInit {
  seattle: Object;

  constructor(private _httpservice: HttpService) { }

  ngOnInit() {
    this.getSeattleFromService();
  }
  getSeattleFromService() {
  this._httpservice.getSeattle().subscribe( data => {
    console.log(data);
    this.seattle = data;
  })
  }
  convertToF(x: number){
    return ((x-273.15) * (9/5) + 32).toFixed(2)
  }
}