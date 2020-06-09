import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BrugerAktivitetComponent } from './bruger-aktivitet.component';

describe('BrugerAktivitetComponent', () => {
  let component: BrugerAktivitetComponent;
  let fixture: ComponentFixture<BrugerAktivitetComponent>;

  beforeEach(async(() => {
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
