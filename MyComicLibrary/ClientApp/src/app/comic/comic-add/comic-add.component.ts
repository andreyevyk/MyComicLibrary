import { Component, OnInit } from '@angular/core';
import { ComicService } from 'src/app/services/comic.service';

@Component({
  selector: 'app-comic-add',
  templateUrl: './comic-add.component.html',
  styleUrls: ['./comic-add.component.css']
})
export class ComicAddComponent implements OnInit {
  constructor(private service: ComicService) { }

  comics;
  rows = [];
  count ;
  titleSearch;
  p: number = 1;
  ativo: boolean = false;
  error: boolean = false;
  ngOnInit() {
  }

  searchComic(form){
    this.titleSearch = form.value.title;
    this.count = this.service.COUNTSEARCH(this.titleSearch).subscribe(res => {
      this.count = res;
    });
    this.service.SEARCH(this.titleSearch).subscribe( res => {
      this.comics = res;
      this.rows = this.groupColumns(this.comics);
      if(this.rows.length != 0){
        this.ativo = true;
        this.error = false;
      }
      else{
        this.error = true;
      }
    });
  }

  groupColumns( comics ) {
    const newRows = [];
    for (let index = 0 ; index < comics.length; index += 4) {
      newRows.push(comics.slice(index, index + 4 ));
    }
    return newRows;
  }

  pageChanger(pageNumber: number) {
    let hqs = this.service.SEARCH(this.titleSearch, pageNumber.toString()).subscribe(res => {
      this.comics = res;
      this.rows = this.groupColumns(this.comics);
      this.ativo = true;
    });
    console.log(this.rows);
  }
}
