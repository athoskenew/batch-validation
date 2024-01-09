import { TestBed } from '@angular/core/testing';

import { QualityCharacteristicService } from './quality-characteristic.service';

describe('QualityCharacteristicService', () => {
  let service: QualityCharacteristicService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(QualityCharacteristicService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
