import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ForsideComponent } from "./forside/forside.component";
import { AktivitetComponent } from './aktivitet/aktivitet.component';
import { LoginComponent } from './login/login.component';
import { OpretBrugerComponent } from './opret-bruger/opret-bruger.component'
import { OmosComponent } from './om-os/om-os.component';
import { BrugerProfilComponent } from './bruger-profil/bruger-profil.component';
import { FavoritterComponent } from './favoritter/favoritter.component';
import { KontaktComponent } from './kontakt/kontakt.component';
import { MineAktiviteterComponent } from './mine-aktiviteter/mine-aktiviteter.component';
import { NyAktivitetComponent } from './ny-aktivitet/ny-aktivitet.component';
import { RedigerAktivitetComponent } from './rediger-aktivitet/rediger-aktivitet.component';
import { SoegComponent } from './soeg/soeg.component';
import { VennerComponent } from './venner/venner.component';
import { RedigerProfilComponent } from './rediger-profil/rediger-profil.component';

// her sættes der url med hjælp fra routeren

const routes: Routes = [
  {path: '', component: ForsideComponent},
  {path: 'aktivitet/:AktivitetId', component: AktivitetComponent},
  {path: 'login', component: LoginComponent},
  {path: 'opretBruger', component: OpretBrugerComponent},
  {path: 'omOs', component: OmosComponent},
  {path: 'redigerProfil', component: RedigerProfilComponent},
  {path: 'brugerProfil', component: BrugerProfilComponent},
  {path: 'favorit', component: FavoritterComponent},
  {path: 'kontakt', component: KontaktComponent},
  {path: 'mineAktiviteter', component: MineAktiviteterComponent},
  {path: 'nyAktivitet', component: NyAktivitetComponent},
  {path: 'redigerAktivitet/:id', component: RedigerAktivitetComponent},
  {path: 'søg', component: SoegComponent},
  {path: 'venner', component: VennerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponent = [ForsideComponent, AktivitetComponent, OmosComponent, BrugerProfilComponent,
  FavoritterComponent, KontaktComponent, MineAktiviteterComponent, NyAktivitetComponent,
  RedigerAktivitetComponent, SoegComponent, VennerComponent, RedigerProfilComponent]