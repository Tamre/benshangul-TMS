import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleBodyTypeComponent } from './vehicle-body-type.component';

describe('VehicleBodyTypeComponent', () => {
  let component: VehicleBodyTypeComponent;
  let fixture: ComponentFixture<VehicleBodyTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VehicleBodyTypeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VehicleBodyTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
