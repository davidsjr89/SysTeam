import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { CardModule } from 'src/app/shared/component/card/card.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule, CardModule, FormsModule, ReactiveFormsModule
  ],
  declarations: [LoginComponent]
})
export class LoginModule { }
