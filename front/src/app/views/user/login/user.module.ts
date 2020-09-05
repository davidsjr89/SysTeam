import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { CardModule } from '../../../shared/component/card/card.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule, CardModule, FormsModule, ReactiveFormsModule
  ]
})
export class UserModule { }
