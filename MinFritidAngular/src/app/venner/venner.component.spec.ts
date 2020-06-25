import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { VennerComponent } from "./venner.component";

describe("VennerComponent", () => {
    let component: VennerComponent;
    let fixture: ComponentFixture<VennerComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [VennerComponent],
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(VennerComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it("should create", () => {
        expect(component).toBeTruthy();
    });
});
