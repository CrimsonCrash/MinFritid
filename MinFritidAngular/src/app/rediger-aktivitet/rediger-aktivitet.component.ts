import { Iaktivitet } from './../data/Iaktivitet';
import { FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { DataService } from '../data.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-rediger-aktivitet',
  templateUrl: './rediger-aktivitet.component.html',
  styleUrls: ['./rediger-aktivitet.component.css']
})
export class RedigerAktivitetComponent implements OnInit {
  url = "";
  
    id: number;
    UserForm: FormGroup;
    iaktivitet: Iaktivitet;
  
    constructor(private formbuilder: FormBuilder, private dataService: DataService,
       private route: ActivatedRoute,private router: Router) { }
  
    
    ngOnInit(): void {

      this.id = this.route.snapshot.paramMap['id'];
      this.dataService.putAktivitet(this.id, this.UserForm).subscribe((data: Iaktivitet) => {
        this.iaktivitet = data;
      })


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
      
      this.dataService.putAktivitet(this.id, this.UserForm.value).subscribe(res => {
        this.router.navigateByUrl[''];
      })
      
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
