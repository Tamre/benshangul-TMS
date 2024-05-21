import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleOwnersComponent } from './vehicle-owners.component';

describe('VehicleOwnersComponent', () => {
  let component: VehicleOwnersComponent;
  let fixture: ComponentFixture<VehicleOwnersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VehicleOwnersComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VehicleOwnersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
