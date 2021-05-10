import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { OpretBrugerComponent } from './opret-bruger.component';

describe('OpretBrugerComponent', () => {
  let component: OpretBrugerComponent;
  let fixture: ComponentFixture<OpretBrugerComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ OpretBrugerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpretBrugerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
