import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManufactureCountryComponent } from './manufacture-country.component';

describe('ManufactureCountryComponent', () => {
  let component: ManufactureCountryComponent;
  let fixture: ComponentFixture<ManufactureCountryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManufactureCountryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ManufactureCountryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
