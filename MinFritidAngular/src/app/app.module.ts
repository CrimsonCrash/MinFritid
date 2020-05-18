import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule, routingComponent } from './app-routing.module';
import { AppComponent } from './app.component';
import { ForsideComponent } from './forside/forside.component';
import { NavComponent } from './nav/nav.component';
import { AktivitetComponent } from './aktivitet/aktivitet.component';

@NgModule({
  declarations: [
    AppComponent,
    ForsideComponent,
    routingComponent,
    NavComponent,
    AktivitetComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
