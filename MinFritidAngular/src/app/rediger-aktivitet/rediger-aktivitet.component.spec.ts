import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RedigerAktivitetComponent } from './rediger-aktivitet.component';

describe('RedigerAktivitetComponent', () => {
  let component: RedigerAktivitetComponent;
  let fixture: ComponentFixture<RedigerAktivitetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RedigerAktivitetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RedigerAktivitetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
