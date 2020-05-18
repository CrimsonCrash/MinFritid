import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AktivitetComponent } from './aktivitet.component';

describe('AktivitetComponent', () => {
  let component: AktivitetComponent;
  let fixture: ComponentFixture<AktivitetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AktivitetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AktivitetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
