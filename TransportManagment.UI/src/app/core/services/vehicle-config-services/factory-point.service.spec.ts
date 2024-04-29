import { TestBed } from '@angular/core/testing';

import { FactoryPointService } from './factory-point.service';

describe('FactoryPointService', () => {
  let service: FactoryPointService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FactoryPointService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
