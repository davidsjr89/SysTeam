import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'SysTeam';
  username = '';
  ngOnInit() {
    this.username =  this.carregaLocalStorageUsername();
    console.log(this.username);
  }
  carregaLocalStorageUsername(): string{
    return localStorage.getItem('username');
  }
}
