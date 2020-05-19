import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule, routingComponent } from './app-routing.module';
import { AppComponent } from './app.component';
import { ForsideComponent } from './forside/forside.component';
import { NavComponent } from './nav/nav.component';
import { AktivitetComponent } from './aktivitet/aktivitet.component';
import { LoginComponent } from './login/login.component';
import { OpretBrugerComponent } from './opret-bruger/opret-bruger.component';

@NgModule({
  declarations: [
    AppComponent,
    ForsideComponent,
    routingComponent,
    NavComponent,
    AktivitetComponent,
    LoginComponent,
    OpretBrugerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
