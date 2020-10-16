import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PrincipalComponent } from './views/principal/principal.component';
import { UnidadeComponent } from './views/unidade/unidade.component';
import { LoginComponent } from './views/user/login/login.component';


const routes: Routes = [
  { path: '', component: PrincipalComponent,
    children: [
      { path: 'principal', component: PrincipalComponent},
      { path: 'unidade', component: UnidadeComponent}
    ]},
    {
      path: '', component: LoginComponent,
      children: [
        {
          path: '', redirectTo: 'login', pathMatch: 'full'
        }
      ]
    }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
