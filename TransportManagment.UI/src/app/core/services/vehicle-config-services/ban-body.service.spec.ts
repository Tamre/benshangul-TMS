import { TestBed } from '@angular/core/testing';

import { BanBodyService } from './ban-body.service';

describe('BanBodyService', () => {
  let service: BanBodyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BanBodyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
