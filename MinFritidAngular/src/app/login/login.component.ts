import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { first } from "rxjs/operators";
import { DataService } from "../data.service";

@Component({
    selector: "app-login",
    templateUrl: "./login.component.html",
    styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
    submitClick = false;
    submitted = false;
    loginForm: FormGroup;
    returnUrl: string;
    error = "";

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private dataService: DataService
    ) {}

    ngOnInit(): void {
        this.loginForm = this.formBuilder.group({
            Email: ["", [Validators.required]],
            Password: ["", [Validators.required]],
        });

        this.dataService.logout();

        this.returnUrl = this.route.snapshot.queryParams["returnUrl"] || "/";
    }

    onLogin() {}
}
