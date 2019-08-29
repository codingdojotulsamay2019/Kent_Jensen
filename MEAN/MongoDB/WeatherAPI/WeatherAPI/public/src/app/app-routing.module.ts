import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SeattleComponent } from './seattle/seattle.component';
import { SanjoseComponent } from './sanjose/sanjose.component';
import { BurbankComponent } from './burbank/burbank.component';
import { DallasComponent } from './dallas/dallas.component';
import { WashingtonComponent } from './washington/washington.component';
import { ChicagoComponent } from './chicago/chicago.component';
import { TulsaComponent } from './tulsa/tulsa.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';


const routes: Routes = [
  {path: '', component: TulsaComponent},
  {path: 'Seattle', component: SeattleComponent},
  {path: 'Seattle', component: SeattleComponent},
  {path: 'Sanjose', component: SanjoseComponent},
  {path: 'Burbank', component: BurbankComponent},
  {path: 'Dallas', component: DallasComponent},
  {path: 'Washington', component: WashingtonComponent},
  {path: 'Chicago', component: ChicagoComponent},
  {path: '', pathMatch: 'full', redirectTo: '/'},
  {path: '**', component: PagenotfoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
