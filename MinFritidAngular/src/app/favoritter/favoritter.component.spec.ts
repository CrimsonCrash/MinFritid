import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { FavoritterComponent } from './favoritter.component';

describe('FavoritterComponent', () => {
  let component: FavoritterComponent;
  let fixture: ComponentFixture<FavoritterComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ FavoritterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FavoritterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
