import { TestBed } from '@angular/core/testing';

import { AisStockService } from './ais-stock.service';

describe('AisStockService', () => {
  let service: AisStockService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AisStockService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
