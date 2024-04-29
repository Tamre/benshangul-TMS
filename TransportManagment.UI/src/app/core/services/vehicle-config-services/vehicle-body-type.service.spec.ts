import { TestBed } from '@angular/core/testing';

import { VehicleBodyTypeService } from './vehicle-body-type.service';

describe('VehicleBodyTypeService', () => {
  let service: VehicleBodyTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VehicleBodyTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
