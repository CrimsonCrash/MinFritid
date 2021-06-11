import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../data.service';
import { Iaktivitet } from '../data/Iaktivitet';

@Component({
  selector: 'app-mine-aktiviteter',
  templateUrl: './mine-aktiviteter.component.html',
  styleUrls: ['./mine-aktiviteter.component.css']
})
export class MineAktiviteterComponent implements OnInit {
  constructor(private dataService : DataService, private router: Router) { }
  public Aktiviteter = [];
  iaktivitet: Iaktivitet;

  
  ngOnInit() {
    this.dataService.getAktiviteter()
    .subscribe(data => this.Aktiviteter = data)
  }
  
  // redigerAktivitet(iaktivitet: Iaktivitet): void {
  //   window.localStorage.removeItem("id");
  //   window.localStorage.setItem("id", iaktivitet.AktivitetID.toString());
  //   this.router.navigate['redigerAktivitet']
  // }

}
