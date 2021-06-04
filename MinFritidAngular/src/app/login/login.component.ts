import { DataService } from './../data.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { Ibruger } from '../data/Ibruger';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  

  data = false;
  UserForm: any;
  massage: string;

  constructor(private formbuilder: FormBuilder, private dataService: DataService) { }

  
  ngOnInit(): void {
    this.UserForm = this.formbuilder.group({
      BrugerID: '',
      Email: ['', [Validators.required]],
      Password: ['', [Validators.required]],
    });
  }
  submit() {
    const user = this.UserForm.value;
    this.login(user);
    
  }
  login(bruger: Ibruger) {
    this.dataService.postBrugers(bruger).subscribe(
      () =>
      {
        this.data = true;
        this.massage = 'Data saved Successfully';
        this.UserForm.reset();
      });
  }



}
