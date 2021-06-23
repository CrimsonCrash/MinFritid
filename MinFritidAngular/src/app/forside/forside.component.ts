import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { DataService } from '../data.service';
import { Iaktivitet } from '../data/Iaktivitet';

@Component({
  selector: 'app-forside',
  templateUrl: './forside.component.html',
  styleUrls: ['./forside.component.css']
})
export class ForsideComponent implements OnInit {

  constructor(private dataService : DataService) { }
  public Aktiviteter = [];

  //iaktivitet: Iaktivitet[];
  
  // den kalder på getAktiviteter fra service filen med brug af subscribe
  ngOnInit() {
    this.dataService.getAktiviteter()
    .subscribe(data => this.Aktiviteter = data)
  }

  
  

}
