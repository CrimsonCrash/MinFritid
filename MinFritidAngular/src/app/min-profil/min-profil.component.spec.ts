import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MinProfilComponent } from './min-profil.component';

describe('MinProfilComponent', () => {
  let component: MinProfilComponent;
  let fixture: ComponentFixture<MinProfilComponent>;

  beforeEach(async(() => {
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
