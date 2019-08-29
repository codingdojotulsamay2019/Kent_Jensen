import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { IndexComponent } from './index/index.component';
import { EditComponent } from './edit/edit.component';
import { NewComponent } from './new/new.component';
import { PagenotfoundComponent } from './pagenotfound/Pagenotfound.component';

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    EditComponent,
    NewComponent,
    PagenotfoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
