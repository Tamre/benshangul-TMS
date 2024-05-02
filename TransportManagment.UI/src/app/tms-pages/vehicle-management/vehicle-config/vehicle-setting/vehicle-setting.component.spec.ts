import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleSettingComponent } from './vehicle-setting.component';

describe('VehicleSettingComponent', () => {
  let component: VehicleSettingComponent;
  let fixture: ComponentFixture<VehicleSettingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VehicleSettingComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VehicleSettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
