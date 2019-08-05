import { WelcomeComponent } from './home/welcome/welcome.component';
import { ComicViewComponent } from './comic/comic-view/comic-view.component';
import { ComicListResolver } from './main/main-page/comic-list.resolver';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MainPageComponent } from './main/main-page/main-page.component';
import { CountResolver } from './main/main-page/count.resolver';
import { ComicViewResolver } from './comic/comic-view/comic-view.resolver';
import { ComicAddComponent } from './comic/comic-add/comic-add.component';
import { ComicConfirmResolver } from './comic/comic-add/comic-confirm/comic-confirm.resolver';
import { ComicConfirmComponent } from './comic/comic-add/comic-confirm/comic-confirm.component';

const routes: Routes = [
  {
    path: '',
    component: WelcomeComponent,
  },
  {
    path: 'main/:page',
    component: MainPageComponent,
    resolve: {
      comics: ComicListResolver,
      count: CountResolver
    }
  },
  {
    path: 'comic/add',
    component: ComicAddComponent
  },
  {
    path: 'comic/add/:id',
    component: ComicConfirmComponent,
    resolve: {
      comic: ComicConfirmResolver
    }
  },
  {
    path: 'comic/:id',
    component: ComicViewComponent,
    resolve: {
      comic: ComicViewResolver
    }
  },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {

}
