import { TestBed } from '@angular/core/testing';

import { QualityVisionService } from './quality-vision.service';

describe('QualityVisionService', () => {
  let service: QualityVisionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(QualityVisionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
