import { TestBed } from '@angular/core/testing';

import { OrcStockService } from './orc-stock.service';

describe('OrcStockService', () => {
  let service: OrcStockService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrcStockService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
