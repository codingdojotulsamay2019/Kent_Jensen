import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

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
  this._router.navigate(['/edit']);
  }

}
