import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComicViewComponent } from './comic-view/comic-view.component';
import { ComicAddComponent } from './comic-add/comic-add.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { ComicConfirmComponent } from './comic-add/comic-confirm/comic-confirm.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbPaginationModule.forRoot()

  ],
  declarations: [ComicViewComponent, ComicAddComponent, ComicConfirmComponent]
})
export class ComicModule { }
