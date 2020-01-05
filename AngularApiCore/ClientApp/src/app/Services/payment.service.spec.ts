import { TestBed, inject } from '@angular/core/testing';

import { PaymentWeb } from './payment.service';

describe('PaymentWeb', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PaymentWeb]
    });
  });

  it('should be created', inject([PaymentWeb], (service: PaymentWeb) => {
    expect(service).toBeTruthy();
  }));
});
