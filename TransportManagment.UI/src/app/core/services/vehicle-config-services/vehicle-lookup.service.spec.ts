import { TestBed } from '@angular/core/testing';

import { VehicleLookupService } from './vehicle-lookup.service';

describe('VehicleLookupService', () => {
  let service: VehicleLookupService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VehicleLookupService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
