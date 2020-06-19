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
      Fornavn: ['', [Validators.required]],
      Efternavn: ['', [Validators.required]],
      Foedselsdato: ['', [Validators.required]],
      PostNummer: ['', [Validators.required]],
      Email: ['', [Validators.required]],
      Password: ['', [Validators.required]],
    });
  }
  OnSubmit() {
    const user = this.UserForm.value;
    if (user != null) {
      this.CreateUser(user);
    }
    return this.UserForm;
    //this.CreateUser(user);
    
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
