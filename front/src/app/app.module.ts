import { UserModule } from './views/user/login/user.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RodapeModule } from './shared/component/rodape/rodape.module';
import { PrincipalComponent } from './views/principal/principal.component';
import { UnidadeComponent } from './views/unidade/unidade.component';

@NgModule({
  declarations: [
    AppComponent,
    PrincipalComponent,
    UnidadeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RodapeModule,
    UserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
