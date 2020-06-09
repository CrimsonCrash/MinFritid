import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule, routingComponent } from './app-routing.module';
import { AppComponent } from './app.component';
import { ForsideComponent } from './forside/forside.component';
import { NavComponent } from './nav/nav.component';
import { AktivitetComponent } from './aktivitet/aktivitet.component';
import { LoginComponent } from './login/login.component';
import { OpretBrugerComponent } from './opret-bruger/opret-bruger.component';
import { OmosComponent } from './om-os/om-os.component';
import { KontaktComponent } from './kontakt/kontakt.component';
import { MinProfilComponent } from './min-profil/min-profil.component';
import { BrugerProfilComponent } from './bruger-profil/bruger-profil.component';
import { NyAktivitetComponent } from './ny-aktivitet/ny-aktivitet.component';
import { RedigerAktivitetComponent } from './rediger-aktivitet/rediger-aktivitet.component';
import { VennerComponent } from './venner/venner.component';
import { FavoritterComponent } from './favoritter/favoritter.component';
import { SoegComponent } from './soeg/soeg.component';
import { MineAktiviteterComponent } from './mine-aktiviteter/mine-aktiviteter.component';
import { RedigerProfilComponent } from './rediger-profil/rediger-profil.component';
import { BrugerAktivitetComponent } from './bruger-aktivitet/bruger-aktivitet.component';
import { DataService } from './data.service';

@NgModule({
  declarations: [
    AppComponent,
    ForsideComponent,
    routingComponent,
    NavComponent,
    AktivitetComponent,
    LoginComponent,
    OpretBrugerComponent,
    OmosComponent,
    KontaktComponent,
    MinProfilComponent,
    BrugerProfilComponent,
    NyAktivitetComponent,
    RedigerAktivitetComponent,
    VennerComponent,
    FavoritterComponent,
    SoegComponent,
    MineAktiviteterComponent,
    RedigerProfilComponent,
    BrugerAktivitetComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
