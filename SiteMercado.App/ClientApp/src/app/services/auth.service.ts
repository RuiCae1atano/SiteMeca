import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  _baseURL: string = "http://localhost:53574/api/login";
  logged: boolean = false;

  constructor(private http: HttpClient, private router: Router) { }

  loginCustomer(user: User)
  {
    return this.http.post<any>(this._baseURL, user).subscribe(res => {
      this.authenticate(res);
    })
  }

  authenticate(res) {
    localStorage.setItem('token', res);
    this.router.navigate(['/']);
    window.location.reload();
  }

  checkLogged() {
    console.log('verificar entrada');
    console.log('verificar entrada', !!localStorage.getItem('token'));
    //return false;
    return !!localStorage.getItem('token');
  }

  logout() {
    localStorage.removeItem('token');
    window.location.reload();
  }


}
