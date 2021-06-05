import { ParamMap, Params, Router } from '@angular/router';
import { DataService } from './../data.service';
import { Component, OnInit } from '@angular/core';
import { Ibruger } from '../data/Ibruger';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-bruger-profil',
  templateUrl: './bruger-profil.component.html',
  styleUrls: ['./bruger-profil.component.css']
})
export class BrugerProfilComponent implements OnInit {

  id: number;
  ibruger: Ibruger;
  constructor( public dataService: DataService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    //Continuing this tomorrow
    //this.getLogin();

    this.getBruger(this.route.snapshot.params.id);
  }

  getLogin(loginId: number)[

  ]

  getBruger(BrugerId: number) {
    this.dataService.getBruger(BrugerId).subscribe((data: Ibruger) =>{
      this.ibruger = data;
    });
  }

}
