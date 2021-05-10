import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { BrugerAktivitetComponent } from './bruger-aktivitet.component';

describe('BrugerAktivitetComponent', () => {
  let component: BrugerAktivitetComponent;
  let fixture: ComponentFixture<BrugerAktivitetComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ BrugerAktivitetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BrugerAktivitetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
