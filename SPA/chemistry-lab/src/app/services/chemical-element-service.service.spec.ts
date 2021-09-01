import { TestBed } from '@angular/core/testing';

import { ChemicalElementServiceService } from './chemical-element-service.service';

describe('ChemicalElementServiceService', () => {
  let service: ChemicalElementServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChemicalElementServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
