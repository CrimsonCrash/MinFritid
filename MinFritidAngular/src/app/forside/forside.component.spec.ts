import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ForsideComponent } from './forside.component';

describe('ForsideComponent', () => {
  let component: ForsideComponent;
  let fixture: ComponentFixture<ForsideComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ForsideComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ForsideComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
