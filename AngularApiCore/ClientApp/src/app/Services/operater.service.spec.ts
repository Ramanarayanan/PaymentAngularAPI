import { TestBed, inject } from '@angular/core/testing';

import { OperaterService } from './operater.service';

describe('OperaterService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OperaterService]
    });
  });

  it('should be created', inject([OperaterService], (service: OperaterService) => {
    expect(service).toBeTruthy();
  }));
});
