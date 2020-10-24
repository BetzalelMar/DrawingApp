import { MyMatiralModule } from './../my-matiral/my-matiral.module';
import { DrawingComponent } from './../docs/Components/drawing/drawing.component';
import { AddDocComponent } from './../docs/Components/add-doc/add-doc.component';
import { EditDocComponent } from './../docs/Components/edit-doc/edit-doc.component';
import { DocGalleryComponent } from './../docs/Components/doc-gallery/doc-gallery.component';
import { DocComponent } from './../docs/Components/doc/doc.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DocsRoutingModule } from './docs-routing.module';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [DocComponent, DocGalleryComponent, EditDocComponent, AddDocComponent, DrawingComponent],
  imports: [
    CommonModule,
    DocsRoutingModule,
    ReactiveFormsModule,
    MyMatiralModule],
    entryComponents: [
      AddDocComponent,
      EditDocComponent
    ],
})
export class DocsModule { }
