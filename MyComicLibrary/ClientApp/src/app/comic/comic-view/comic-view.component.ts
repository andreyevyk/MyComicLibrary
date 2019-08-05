import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {Location} from '@angular/common';
import { ListEnum } from 'src/app/interfaces/list-enum';
import { ComicService } from 'src/app/services/comic.service';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-comic-view',
  templateUrl: './comic-view.component.html',
  styleUrls: ['./comic-view.component.css']
})
export class ComicViewComponent implements OnInit {

  comic;
  type = ListEnum;
  keys;

  constructor(private route: ActivatedRoute, private service: ComicService, private location: Location, private router: Router) {
    this.keys = Object.keys(this.type).filter(Number);
  }

  ngOnInit() {
    this.comic = this.route.snapshot.data.comic;
    console.log(this.comic);
  }

  backClicked() {
    this.location.back();
  }

  deleteComic() {
    this.service.DELETE(this.comic.id)
    .subscribe(
      success => this.router.navigateByUrl(`main/${this.comic.list}`),
      error => console.log('error')
    );
  }

  editComic(form){
    let comicEdit = {
      id: this.comic.id,
      title: this.comic.title,
      list: form.value.list - 1,
      pageCount: this.comic.pageCount,
      description: this.comic.description,
      imageCover: this.comic.imageCover,
      characters: this.comic.characters,
      creators: this.comic.creators,
    };
    this.service.EDIT(comicEdit.id, comicEdit).subscribe(
      success => this.router.navigateByUrl(`main/${comicEdit.list}`),
      error => console.log('error')
    );
  }
}
