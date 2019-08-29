import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
@Component({
  selector: 'app-pagenotfound',
  templateUrl: './pagenotfound.component.html',
  styleUrls: ['./pagenotfound.component.css']
})
export class PagenotfoundComponent implements OnInit {

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
  this._router.navigate(['/pagenotfound']);
  }

}
