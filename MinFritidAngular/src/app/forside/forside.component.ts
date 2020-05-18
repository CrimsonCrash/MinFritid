import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'app-forside',
  templateUrl: './forside.component.html',
  styleUrls: ['./forside.component.css']
})
export class ForsideComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  btnClickAktivitet= function() {
    this.router.navigateByUrl("/aktivitet")
  };

}
