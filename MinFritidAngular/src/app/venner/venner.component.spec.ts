import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { VennerComponent } from './venner.component';

describe('VennerComponent', () => {
  let component: VennerComponent;
  let fixture: ComponentFixture<VennerComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ VennerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VennerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
