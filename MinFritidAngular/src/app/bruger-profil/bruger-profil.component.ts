import { ParamMap, Params, Router } from '@angular/router';
import { DataService } from './../data.service';
import { Component, OnInit } from '@angular/core';
import { Ibruger } from '../data/Ibruger';
import { ActivatedRoute } from '@angular/router';
import { IloggedIn } from '../data/IloggedIn';

@Component({
  selector: 'app-bruger-profil',
  templateUrl: './bruger-profil.component.html',
  styleUrls: ['./bruger-profil.component.css']
})
export class BrugerProfilComponent implements OnInit {

  id: number;
  ibruger: Ibruger;
  iloggedIn: IloggedIn;
  constructor( public dataService: DataService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    //Continuing this tomorrow
    this.getLogin(this.route.snapshot.params.id);

    if(this.iloggedIn.LoggedIn != false){
      this.getBruger(this.route.snapshot.params.id);
    }
    
  }

  getLogin(LoginId: number){
    this.dataService.getLogin().subscribe((data: IloggedIn) =>{
      this.iloggedIn= data;
    });
  }

  getBruger(BrugerId: number) {
    this.dataService.getBruger(BrugerId).subscribe((data: Ibruger) =>{
      this.ibruger = data;
    });
  }

}
