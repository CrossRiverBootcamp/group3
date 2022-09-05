import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcountInfoComponent } from './acount-info.component';

describe('AcountInfoComponent', () => {
  let component: AcountInfoComponent;
  let fixture: ComponentFixture<AcountInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AcountInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AcountInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
