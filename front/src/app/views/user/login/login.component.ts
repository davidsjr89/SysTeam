import { UserService } from '../../../service/userService/user.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  constructor(private fb: FormBuilder, private userService: UserService, public router: Router, private toast: ToastrService) {
    this.criarForm();
   }

  ngOnInit(): void {
    if(localStorage.getItem('token') !== null){
      this.router.navigate(['/principal']);
    }
  }
  criarForm(){
    this.loginForm = this.fb.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
  login(){
    this.userService.login(this.loginForm.value).subscribe(
      () => {
        this.router.navigate(['/principal']);
        this.toast.success('Logado com Sucesso');
      },
        error => {
          this.toast.error('Falha ao tentar Logar');
        }
        
    );
  }
}
