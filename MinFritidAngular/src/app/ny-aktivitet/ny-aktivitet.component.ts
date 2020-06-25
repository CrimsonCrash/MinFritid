import { Component, OnInit } from "@angular/core";

@Component({
    selector: "app-ny-aktivitet",
    templateUrl: "./ny-aktivitet.component.html",
    styleUrls: ["./ny-aktivitet.component.css"],
})
export class NyAktivitetComponent implements OnInit {
    url = "";
    constructor() {}

    ngOnInit(): void {}
    onSelectImg(event) {
        if (event.target.files && event.target.files[0]) {
            var reader = new FileReader();

            reader.readAsDataURL(event.target.files[0]);

            reader.onload = (event) => {
                this.url = event.target.result as string;
            };
        }
    }
}
