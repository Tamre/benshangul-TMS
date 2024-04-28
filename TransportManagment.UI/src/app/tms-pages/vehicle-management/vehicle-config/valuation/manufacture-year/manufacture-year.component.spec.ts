import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManufactureYearComponent } from './manufacture-year.component';

describe('ManufactureYearComponent', () => {
  let component: ManufactureYearComponent;
  let fixture: ComponentFixture<ManufactureYearComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManufactureYearComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ManufactureYearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
