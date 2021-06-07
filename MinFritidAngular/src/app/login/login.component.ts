import { DataService } from './../data.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { Ibruger } from '../data/Ibruger';
import { IloginRequest } from '../data/IloginRequest';
import { IloggedIn } from '../data/IloggedIn';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  data = false;
  loginRequest: any;
  massage: string;
  loginform: any;
  LoggedIn: IloggedIn;

  constructor(private formbuilder: FormBuilder, private dataService: DataService) { }

  
  ngOnInit(): void {
    this.loginform = this.formbuilder.group({
      Email: ['', [Validators.required]],
      Password: ['', [Validators.required]]
    });
  }
  submit() {
    const user = this.loginform.value;
    this.login(user);
    this.getLogin();
  }
  login(loginRequest: IloginRequest) {
    this.dataService.login(loginRequest).subscribe(
      () =>
      {
        this.data = true;
        this.massage = 'Login Successfully';
        this.loginform.reset();
        
      });
  }

  getLogin(){
    this.dataService.getLogin().subscribe((data: IloggedIn) =>{
      this.LoggedIn = data;
    });
  }



}
