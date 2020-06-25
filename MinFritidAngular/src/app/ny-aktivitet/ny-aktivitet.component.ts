import { Component, OnInit } from "@angular/core";
import { DataService } from "../data.service";
import { Ibruger } from "../data/Ibruger";
import { Observable } from "rxjs";
import {
    FormBuilder,
    Validators,
    FormGroup,
    FormControl,
} from "@angular/forms";
import { Iaktivitet } from "../data/Iaktivitet";

@Component({
    selector: "app-ny-aktivitet",
    templateUrl: "./ny-aktivitet.component.html",
    styleUrls: ["./ny-aktivitet.component.css"],
})
export class NyAktivitetComponent implements OnInit {
    data = false;
    UserForm: any;
    message: string;

    constructor(
        private formbuilder: FormBuilder,
        private dataService: DataService
    ) {}

    ngOnInit(): void {
        this.UserForm = this.formbuilder.group({
            Titel: ["", [Validators.required]],
            Beskrivelse: ["", [Validators.required]],
            AktivitetPostnummer: ["", [Validators.required]],
            Starttidspunkt: ["", [Validators.required]],
            Sluttidspunkt: ["", [Validators.required]],
            MaxDeltagere: ["", [Validators.required]],
            Pris: ["", [Validators.required]],
            Huskeliste: ["", []],
        });
    }

    /*     onSelectImg(event) {
        if (event.target.files && event.target.files[0]) {
            var reader = new FileReader();

            reader.readAsDataURL(event.target.files[0]);

            reader.onload = (event) => {
                this.url = event.target.result as string;
            };
        }
    } */

    OnSubmit() {
        const aktivitet = this.UserForm.value;
        if (aktivitet != null) {
            this.CreateAktivitet(aktivitet);
        }
        return this.UserForm;
    }

    CreateAktivitet(aktivitet: Iaktivitet) {
        this.dataService.postAktivitet(aktivitet).subscribe(() => {
            this.data = true;
            this.message = "Aktivitet oprettet.";
            this.UserForm.reset();
        });
    }
}
