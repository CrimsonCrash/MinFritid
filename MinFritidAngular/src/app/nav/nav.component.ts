import { DataService } from './../data.service';
import { Component, OnInit } from '@angular/core';
import { Iaktivitet } from '../data/Iaktivitet';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  titel: "";
  iaktivitet: any;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
  }

  searchTitel(): void {
    this.dataService.findAktivitet(this.titel).subscribe(data => {
      this.iaktivitet = data;
    });

  }
}
