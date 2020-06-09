import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-rediger-aktivitet',
  templateUrl: './rediger-aktivitet.component.html',
  styleUrls: ['./rediger-aktivitet.component.css']
})
export class RedigerAktivitetComponent implements OnInit {
  url = "";
  constructor() { }

  ngOnInit(): void {
  }
  // vælg en billed fra drevet
  onSelectImg(event) {
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();


      reader.readAsDataURL(event.target.files[0]);

      reader.onload = (event) => {
        this.url = event.target.result as string;
      }
    }
  }
}
