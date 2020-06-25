import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { BrugerProfilComponent } from "./bruger-profil.component";

describe("BrugerProfilComponent", () => {
    let component: BrugerProfilComponent;
    let fixture: ComponentFixture<BrugerProfilComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [BrugerProfilComponent],
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(BrugerProfilComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it("should create", () => {
        expect(component).toBeTruthy();
    });
});
