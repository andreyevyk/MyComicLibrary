import { ListEnum } from '../interfaces/list-enum';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class TipoLeituraService {

  private readonly listUrl = 'https://localhost:5001/api/listcomic';

  constructor(private htpp: HttpClient) { }

  GETBYENUM(listEnum: number, pagina = '1' ) {
    const params = new  HttpParams()
    .set('pagina', pagina)
      return this.htpp.get<any[]>(`${this.listUrl}/${listEnum}`, {params})
      .pipe(
        tap(console.log)
      );
  }

  GETALL() {
      return this.htpp.get<any[]>(this.listUrl);
  }

  COUNT(listEnum: number){
    return this.htpp.get<any[]>(`${this.listUrl}/count/${listEnum}`);
  }

}
