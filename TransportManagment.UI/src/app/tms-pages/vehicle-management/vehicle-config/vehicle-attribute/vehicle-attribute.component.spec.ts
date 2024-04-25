import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleAttributeComponent } from './vehicle-attribute.component';

describe('VehicleAttributeComponent', () => {
  let component: VehicleAttributeComponent;
  let fixture: ComponentFixture<VehicleAttributeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VehicleAttributeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VehicleAttributeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
