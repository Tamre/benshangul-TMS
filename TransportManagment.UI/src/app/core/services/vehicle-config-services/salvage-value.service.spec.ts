import { TestBed } from '@angular/core/testing';

import { SalvageValueService } from './salvage-value.service';

describe('SalvageValueService', () => {
  let service: SalvageValueService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalvageValueService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
