import { Component, OnInit } from '@angular/core';
import { DataService } from "../data.service";
import { Ibruger } from "../data/Ibruger";
import { Observable } from "rxjs";
import { FormBuilder, Validators, FormGroup, FormControl} from "@angular/forms";

@Component({
  selector: 'app-opret-bruger',
  templateUrl: './opret-bruger.component.html',
  styleUrls: ['./opret-bruger.component.css']
})
export class OpretBrugerComponent implements OnInit {
  data = false;
  UserForm: any;
  massage: string;

  constructor(private formbuilder: FormBuilder, private dataService: DataService) { }

  
  ngOnInit(): void {
    this.UserForm = this.formbuilder.group({
      _BrugerID: '',
      _Fornavn: ['', [Validators.required]],
      _Efternavn: ['', [Validators.required]],
      _Foedselsdato: ['', [Validators.required]],
      _PostNummer: ['', [Validators.required]],
      _Email: ['', [Validators.required]],
      _Password: ['', [Validators.required]],
    });
  }
  OnSubmit() {
    const user = this.UserForm.value;
    this.CreateUser(user);
    
  }
  CreateUser(bruger: Ibruger) {
    this.dataService.postBrugers(bruger).subscribe(
      () =>
      {
        this.data = true;
        this.massage = 'Data saved Successfully';
        this.UserForm.reset();
      });
  }

}
