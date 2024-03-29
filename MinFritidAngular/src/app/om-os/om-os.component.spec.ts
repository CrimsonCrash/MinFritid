import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { OmosComponent } from './om-os.component';

describe('Om-osComponent', () => {
  let component: OmosComponent;
  let fixture: ComponentFixture<OmosComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ OmosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OmosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
