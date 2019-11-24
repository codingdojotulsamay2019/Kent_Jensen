import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

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
  this._router.navigate(['/index']);
  }

}
