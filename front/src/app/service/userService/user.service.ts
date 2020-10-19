import { User } from './../../shared/model/user';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = `${environment.baseURL}account/`;
  jwtHelper = new JwtHelperService();
  constructor(private http: HttpClient) { }
  decodedToken: any;

  atualizar(model: any){
    return this.http.put(`${this.baseUrl}atualizar`, model);
  }

  registrar(model: any){
    return this.http.post(`${this.baseUrl}registrar`, model);
  }

  login(model: User){
    return this.http.post(`${this.baseUrl}login`, model).pipe(
      map((response: User) => {
        const user = response;
        if (user){
          console.log(user);
          localStorage.setItem('token', user.token);
          localStorage.setItem('username', user.user.username);
          localStorage.setItem('role', user.user.role);
          localStorage.setItem('email', user.user.email);
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
        }
      })
    );
  }

  loggedIn(){
    const token  = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
