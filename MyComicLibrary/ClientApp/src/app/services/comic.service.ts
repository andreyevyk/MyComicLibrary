import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ComicService {

  private readonly comicUrl = 'https://localhost:5001/api/comic';

  constructor(private htpp: HttpClient) { }

  GETBYID(id: number ) {
    return this.htpp.get<any>(`${this.comicUrl}/${id}`);
  }

  GETALL() {
    return this.htpp.get<any>(`${this.comicUrl}`);
  }

  SEARCH(name: string, pagina: string = '1') {
    const params = new  HttpParams()
    .set('name', name)
    .set('pagina', pagina);
    return this.htpp.get( `${this.comicUrl}/search`, {params});
  }

  SEARCHBYID(id: number){
    const params = new  HttpParams()
    .set('id', id.toString());
    return this.htpp.get( `${this.comicUrl}/search/comic`, {params});
  }

  COUNTSEARCH(name:string){
    const params = new  HttpParams()
    .set('name', name)
    return this.htpp.get( `${this.comicUrl}/search/count`, {params});
  }

  DELETE(id: number){
    return this.htpp.delete(`${this.comicUrl}/${id}`);
  }

  CREATE(comic) {
    return this.htpp.post(this.comicUrl, comic);
  }

  EDIT(id,comic) {
    return this.htpp.put(`${this.comicUrl}/${id}`, comic);
  }
}
