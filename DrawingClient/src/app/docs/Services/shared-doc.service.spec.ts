import { TestBed } from '@angular/core/testing';

import { SharedDocService } from './shared-doc.service';

describe('SharedDocService', () => {
  let service: SharedDocService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SharedDocService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
