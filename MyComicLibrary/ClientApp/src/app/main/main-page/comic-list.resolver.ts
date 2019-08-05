import { TipoLeituraService } from './../../services/tipo-leitura.service';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class ComicListResolver implements Resolve<Observable<any[]>> {

    constructor (private service: TipoLeituraService) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const page = route.params.page;
        return  this.service.GETBYENUM(page);
    }
}
