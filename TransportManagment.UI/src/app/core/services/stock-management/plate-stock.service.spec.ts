import { TestBed } from '@angular/core/testing';

import { PlateStockService } from './plate-stock.service';

describe('PlateStockService', () => {
  let service: PlateStockService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlateStockService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
