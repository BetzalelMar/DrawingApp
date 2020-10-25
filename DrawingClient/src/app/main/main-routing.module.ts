import { GardService } from './Services/gard.service';
import { LogOutComponent } from './Components/log-out/log-out.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Components/login/login.component';
import { MainPageComponent } from './Components/main-page/main-page.component';
import { RegisterComponent } from './Components/register/register.component';

const routes: Routes = [
  {
    path: '', component: MainPageComponent
    , children: [{ path: 'docs', loadChildren: () => import('../docs/docs.module').then(m => m.DocsModule), canActivate:[GardService] }
    ]
  },
  { path: 'login', component: LoginComponent },
  { path: 'logout', component: LogOutComponent },
  { path: 'register', component: RegisterComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MainRoutingModule { }
