import { TestBed } from '@angular/core/testing';

import { ManufactureCountryService } from './manufacture-country.service';

describe('ManufactureCountryService', () => {
  let service: ManufactureCountryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ManufactureCountryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
