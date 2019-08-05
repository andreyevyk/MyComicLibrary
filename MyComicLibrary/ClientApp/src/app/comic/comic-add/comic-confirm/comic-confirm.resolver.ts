import { ActivatedRouteSnapshot, RouterStateSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { ComicService } from 'src/app/services/comic.service';

@Injectable({ providedIn: 'root' })
export class ComicConfirmResolver implements Resolve<Observable<any>> {

    constructor (private service: ComicService) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const id = route.params.id;
        return  this.service.SEARCHBYID(id);
    }
}
