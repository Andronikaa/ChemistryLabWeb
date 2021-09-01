import { TestBed } from '@angular/core/testing';

import { CompoundsServiceService } from './compounds-service.service';

describe('CompoundsServiceService', () => {
  let service: CompoundsServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CompoundsServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
