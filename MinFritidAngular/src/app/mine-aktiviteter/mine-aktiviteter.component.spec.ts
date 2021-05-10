import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { MineAktiviteterComponent } from './mine-aktiviteter.component';

describe('MineAktiviteterComponent', () => {
  let component: MineAktiviteterComponent;
  let fixture: ComponentFixture<MineAktiviteterComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ MineAktiviteterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MineAktiviteterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
