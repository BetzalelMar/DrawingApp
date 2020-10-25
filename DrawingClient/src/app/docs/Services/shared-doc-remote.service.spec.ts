import { TestBed } from '@angular/core/testing';

import { SharedDocRemoteService } from './shared-doc-remote.service';

describe('SharedDocRemoteService', () => {
  let service: SharedDocRemoteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SharedDocRemoteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
