import { Observable, of } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit, SimpleChanges, OnChanges } from '@angular/core';
import { TipoLeituraService } from '../../services/tipo-leitura.service';
import { tap, map, delay } from 'rxjs/operators';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {
  comics: any[] = [];
  rows = [];
  title: string = '';
  pageSize = 4;
  count : number;
  p: number = 1;
  previousPage: any;
  page;

  constructor(private route: ActivatedRoute,private service: TipoLeituraService) { }

  ngOnInit() {
    this.count = this.route.snapshot.data.count;
    this.page = this.route.snapshot.params['page'];
    this.title = this.getTitle(this.page);
    this.comics = this.route.snapshot.data.comics.comics;
    this.rows = this.groupColumns(this.comics);
  }

  groupColumns( comics ) {
    const newRows = [];
    for (let index = 0 ; index < comics.length; index += 4) {
      newRows.push(comics.slice(index, index + 4 ));
    }
    return newRows;
  }
  getTitle(page: number): string {
    if ( page == 0) {
      return 'To Read';
    }
    if ( page == 1) {
      return 'Reading';
    }
    if ( page == 2) {
      return 'Read';
    }
    if ( page == 3) {
      return 'Lend';
    }

  }
  pageChanger(pageNumber: number) {
    let hqs = this.service.GETBYENUM(this.page, pageNumber.toString()).subscribe(data => {
      this.comics = data.comics;
      this.rows = this.groupColumns(this.comics);
    });
    console.log(this.rows);
  }

}

