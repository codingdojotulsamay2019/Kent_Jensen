import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewComponent} from './new/new.component';
import { EditComponent} from './edit/edit.component';
import { IndexComponent} from './index/index.component';
import { PagenotfoundComponent} from './pagenotfound/Pagenotfound.component';

const routes: Routes = [
  { path: 'index', component: IndexComponent },
  { path: 'edit/:id', component: EditComponent },
  { path: 'new', component: NewComponent },
  { path: '', pathMatch: 'full', redirectTo: '/index' },
  { path: '**', component: PagenotfoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
