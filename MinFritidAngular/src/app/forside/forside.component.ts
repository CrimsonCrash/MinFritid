import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { DataService } from '../data.service';

@Component({
  selector: 'app-forside',
  templateUrl: './forside.component.html',
  styleUrls: ['./forside.component.css']
})
export class ForsideComponent implements OnInit {

  constructor(private dataService : DataService) { }
  public Forsider = [];

  
  ngOnInit() {
    this.dataService.getAktivitet()
    .subscribe(data => this.Forsider = data)
  }
  

}
