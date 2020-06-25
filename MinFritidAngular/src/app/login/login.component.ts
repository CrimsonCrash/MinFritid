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

    get formData() {
        return this.loginForm.controls;
    }
    onLogin() {
        this.submitted = true;

        if (this.loginForm.invalid) {
            return;
        }

        this.submitClick = true;
        this.dataService
            .login(this.formData.Email.value, this.formData.Password.value)
            .pipe(first())
            .subscribe(
                (data) => {
                    this.router.navigate([this.returnUrl]);
                },
                (error) => {
                    this.error = error;
                    this.submitClick = false;
                }
            );
    }
}
