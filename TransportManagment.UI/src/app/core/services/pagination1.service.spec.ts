import { TestBed } from '@angular/core/testing';

import { Pagination1Service } from './pagination1.service';

describe('Pagination1Service', () => {
  let service: Pagination1Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Pagination1Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
