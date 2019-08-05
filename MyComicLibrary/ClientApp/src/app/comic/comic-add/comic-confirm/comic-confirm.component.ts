import { Location } from '@angular/common';
import { ListEnum } from './../../../interfaces/list-enum';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ComicService } from 'src/app/services/comic.service';
import { error } from 'util';

@Component({
  selector: 'app-comic-confirm',
  templateUrl: './comic-confirm.component.html',
  styleUrls: ['./comic-confirm.component.css']
})
export class ComicConfirmComponent implements OnInit {
  comic;
  type = ListEnum;
  keys;
  title;
  constructor(private route: ActivatedRoute,private router: Router, private service: ComicService, private location: Location) {
    this.keys = Object.keys(this.type).filter(Number);
  }

  ngOnInit() {
    this.comic = this.route.snapshot.data.comic;
    console.log(this.comic);
  }
  backClicked() {
    this.location.back();
  }

  createComic(form){
    console.log(form.value.list);
    let comicCreate = {
      title: this.comic.title,
      list: form.value.list - 1,
      pageCount: this.comic.pageCount,
      description: this.comic.description,
      imageCover: this.comic.imageCover,
      characters: this.comic.characters,
      creators: this.comic.creators,
    };
    this.service.CREATE(comicCreate).subscribe(
      succes => this.router.navigateByUrl(`main/${comicCreate.list}`),
      error => console.log(error),
      () => console.log('request completo')
    );
  }
}
