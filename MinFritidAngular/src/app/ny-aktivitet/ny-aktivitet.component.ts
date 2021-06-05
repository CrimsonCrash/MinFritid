import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from '../data.service';

@Component({
  selector: 'app-ny-aktivitet',
  templateUrl: './ny-aktivitet.component.html',
  styleUrls: ['./ny-aktivitet.component.css']
})
export class NyAktivitetComponent implements OnInit {
    url = "";
    UserForm: FormGroup;
    constructor(private formbuilder: FormBuilder, private dataService: DataService,
      private router: Router) { }

    ngOnInit(): void {
      this.UserForm = this.formbuilder.group({
        AktivitetID: '',
        BrugerID: '',
        Titel: ['', [Validators.required]],
        Beskrivelse: ['', [Validators.required]],
        Huskeliste: ['', [Validators.required]],
        Pris: ['', [Validators.required]],
        MaxDeltagere: ['', [Validators.required]],
        StartTidspunkt: ['', [Validators.required]],
        SlutTidspunkt: ['', [Validators.required]],
        PostNummer: ['', [Validators.required]],
        Aktiv: ''
    });
  }
    OnSubmit() {
      this.dataService.postAktivitet(this.UserForm.value).subscribe(res => {
        this.router.navigateByUrl('post/index')
      })
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
