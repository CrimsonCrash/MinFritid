import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { MinProfilComponent } from './min-profil.component';

describe('MinProfilComponent', () => {
  let component: MinProfilComponent;
  let fixture: ComponentFixture<MinProfilComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ MinProfilComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MinProfilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
