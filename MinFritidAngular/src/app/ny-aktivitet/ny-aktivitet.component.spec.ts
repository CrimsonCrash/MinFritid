import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { NyAktivitetComponent } from './ny-aktivitet.component';

describe('NyAktivitetComponent', () => {
  let component: NyAktivitetComponent;
  let fixture: ComponentFixture<NyAktivitetComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ NyAktivitetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NyAktivitetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
