import { MyMatiralModule } from './my-matiral/my-matiral.module';

import { LocalCommService } from './services/commService/local-comm.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { CommService } from './services/commService/comm.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DocsModule } from './docs/docs.module';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    DocsModule,
    MyMatiralModule
  ],
  providers: [{provide:CommService,useClass:LocalCommService}],
  bootstrap: [AppComponent]
})
export class AppModule { }
