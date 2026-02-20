import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { simpleAuthGuardGuard } from './simple-auth.guard-guard';

describe('simpleAuthGuardGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => simpleAuthGuardGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
