import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ForsideComponent } from "./forside/forside.component";
import { AktivitetComponent } from './aktivitet/aktivitet.component';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
  {path: '', component: ForsideComponent},
  {path: 'aktivitet', component: AktivitetComponent},
  {path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponent = [ForsideComponent, AktivitetComponent]