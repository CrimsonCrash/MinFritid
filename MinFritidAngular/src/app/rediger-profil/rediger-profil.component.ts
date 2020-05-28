import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-rediger-profil',
  templateUrl: './rediger-profil.component.html',
  styleUrls: ['./rediger-profil.component.css']
})
export class RedigerProfilComponent implements OnInit {
  url = "";
  constructor() { }

  ngOnInit(): void {
  }
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
