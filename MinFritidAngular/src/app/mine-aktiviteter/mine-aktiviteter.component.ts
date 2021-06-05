import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-mine-aktiviteter',
  templateUrl: './mine-aktiviteter.component.html',
  styleUrls: ['./mine-aktiviteter.component.css']
})
export class MineAktiviteterComponent implements OnInit {
  constructor(private dataService : DataService) { }
  public Forsider = [];

  
  ngOnInit() {
    this.dataService.getAktiviteter()
    .subscribe(data => this.Forsider = data)
  }
  

}
