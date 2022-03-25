import { TestBed } from '@angular/core/testing';

import { SalesTaxService } from './sales-tax.service';

describe('SalesTaxService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SalesTaxService = TestBed.get(SalesTaxService);
    expect(service).toBeTruthy();
  });
});
