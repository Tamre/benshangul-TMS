import { TestBed } from '@angular/core/testing';

import { InitialPriceService } from './initial-price.service';

describe('InitialPriceService', () => {
  let service: InitialPriceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InitialPriceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
