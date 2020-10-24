import { DocGalleryComponent } from './Components/doc-gallery/doc-gallery.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainPageComponent } from '../main/Components/main-page/main-page.component';

const routes: Routes = [
  {path:'',component:DocGalleryComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DocsRoutingModule { }
