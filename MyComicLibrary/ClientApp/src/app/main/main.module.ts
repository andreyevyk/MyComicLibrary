import {NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from '../app.routing.module';
import { MainPageComponent } from './main-page/main-page.component';
import { MatToolbarModule, MatButtonModule, MatIconModule, MatListModule, MatPaginator, MatPaginatorModule } from '@angular/material';


@NgModule({
  imports: [
    CommonModule,
    AppRoutingModule,

    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatPaginatorModule,
    NgbPaginationModule.forRoot()
  ],
  declarations: [MainPageComponent],
  exports: [ MainPageComponent]
})
export class MainModule { }
