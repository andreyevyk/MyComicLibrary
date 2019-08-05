import { TestBed, inject } from '@angular/core/testing';

import { TipoLeituraService } from './tipo-leitura.service';

describe('TipoLeituraService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TipoLeituraService]
    });
  });

  it('should be created', inject([TipoLeituraService], (service: TipoLeituraService) => {
    expect(service).toBeTruthy();
  }));
});
