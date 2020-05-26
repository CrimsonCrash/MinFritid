import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RedigerProfilComponent } from './rediger-profil.component';

describe('RedigerProfilComponent', () => {
  let component: RedigerProfilComponent;
  let fixture: ComponentFixture<RedigerProfilComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RedigerProfilComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RedigerProfilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
