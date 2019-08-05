import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatSidenavModule } from '@angular/material/sidenav';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule, MatButtonModule, MatIconModule, MatListModule } from '@angular/material';
import { SidebarPageComponent } from './sidebar-page/sidebar-page.component';
import { AppRoutingModule } from '../app.routing.module';



@NgModule({
  declarations: [SidebarPageComponent],
  imports: [
    CommonModule,
    MatSidenavModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    AppRoutingModule
  ],
  exports: [SidebarPageComponent]
})
export class SidebarModule { }
