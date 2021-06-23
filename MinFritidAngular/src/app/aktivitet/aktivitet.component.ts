import { ParamMap, Params, Router } from '@angular/router';
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
     this.id = +this.route.snapshot.paramMap['AktivitetID']

    

     //this.getAktivitetet(this.route.snapshot.params.id);
    // this.route.paramMap.subscribe(params => {
    //   this.id = params['AktivitetId'];
    //   this.dataService.getAktivitet(this.id).subscribe((data: Iaktivitet) =>{
    //     this.iaktivitet = data;
    //     console.log(this.id);
    //   });
    // })

    this.dataService.getAktivitet(this.id).subscribe((data: Iaktivitet) =>{
      this.iaktivitet = data;
    });

    
    
  }

  // getAktivitetet(id: number) {
  //   this.dataService.getAktivitet(id).subscribe(data =>{
  //     this.iaktivitet = data;
  //   });
  // }

}
