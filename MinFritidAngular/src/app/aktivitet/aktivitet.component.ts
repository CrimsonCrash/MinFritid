import { Router } from '@angular/router';
import { DataService } from './../data.service';
import { Component, OnInit } from '@angular/core';
import { Iaktivitet } from '../data/Iaktivitet';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-aktivitet',
  templateUrl: './aktivitet.component.html',
  styleUrls: ['./aktivitet.component.css']
})
export class AktivitetComponent implements OnInit {

  id: number;
  iaktivitet: Iaktivitet;
  constructor( public dataService: DataService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id']

    this.dataService.getAktivitet(this.id).subscribe((data: Iaktivitet) =>{
      this.iaktivitet = data;
    })
  }

}
