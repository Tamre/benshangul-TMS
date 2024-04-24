import { TestBed } from '@angular/core/testing';

import { DepCostService } from './dep-cost.service';

describe('DepCostService', () => {
  let service: DepCostService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DepCostService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
