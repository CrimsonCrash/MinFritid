import { TestBed } from "@angular/core/testing";

import { DataService } from "./data.service";

describe("DataService", () => {
    //let service: DataService

    beforeEach(
        () => TestBed.configureTestingModule({})
        //service = TestBed.inject(DataService);
    );

    it("should be created", () => {
        const service: DataService = TestBed.get(DataService);
        expect(service).toBeTruthy();
    });
});
