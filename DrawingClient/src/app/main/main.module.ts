import { MyMatiralModule } from './../my-matiral/my-matiral.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainRoutingModule } from './main-routing.module';
import { RegisterComponent } from './Components/register/register.component';
import { LoginComponent } from './Components/login/login.component';
import { LogOutComponent } from './Components/log-out/log-out.component';
import { MainPageComponent } from './Components/main-page/main-page.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [RegisterComponent, LoginComponent, LogOutComponent, MainPageComponent],
  imports: [
    CommonModule,
    MainRoutingModule,
    ReactiveFormsModule,
    MyMatiralModule,
    
  ]
})
export class MainModule { }
