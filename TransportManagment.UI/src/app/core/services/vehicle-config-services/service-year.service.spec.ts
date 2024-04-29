import { TestBed } from '@angular/core/testing';

import { ServiceYearService } from './service-year.service';

describe('ServiceYearService', () => {
  let service: ServiceYearService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServiceYearService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
