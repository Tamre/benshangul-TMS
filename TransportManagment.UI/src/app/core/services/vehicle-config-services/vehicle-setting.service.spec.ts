import { TestBed } from '@angular/core/testing';

import { VehicleSettingService } from './vehicle-setting.service';

describe('VehicleSettingService', () => {
  let service: VehicleSettingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VehicleSettingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
