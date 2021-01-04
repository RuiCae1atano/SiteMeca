import { TestBed } from '@angular/core/testing';

import { ProdutService } from './produt.service';

describe('ProdutService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProdutService = TestBed.get(ProdutService);
    expect(service).toBeTruthy();
  });
});
