import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FieldInspectionComponent } from './field-inspection.component';

describe('FieldInspectionComponent', () => {
  let component: FieldInspectionComponent;
  let fixture: ComponentFixture<FieldInspectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FieldInspectionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FieldInspectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
