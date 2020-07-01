import { Component, OnInit } from "@angular/core";
import { DataService } from '../data.service';

@Component({
    selector: "app-mine-aktiviteter",
    templateUrl: "./mine-aktiviteter.component.html",
    styleUrls: ["./mine-aktiviteter.component.css"],
})
export class MineAktiviteterComponent implements OnInit {
    constructor(private dataService: DataService) {}

    public Aktiviteten;

    ngOnInit() {
        this.dataService
            .getBrugersAktiviteter("5e34359b-dd51-4515-b47e-7c9bea9fdfbf")
            .subscribe((data) => (this.Aktiviteten = data));
    }
}
