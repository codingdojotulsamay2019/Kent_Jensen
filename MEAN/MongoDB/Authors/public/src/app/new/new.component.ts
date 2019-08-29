import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent implements OnInit {

  constructor(     
    private _route: ActivatedRoute,
    private _router: Router
  ) {}

  ngOnInit() {    
    this._route.params.subscribe((params: Params) => {
    console.log(params['id'])
});
}
goHome() {
  this._router.navigate(['/new']);
  }

}
