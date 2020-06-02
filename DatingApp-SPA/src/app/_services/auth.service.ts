import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = "http://localhost:5000/api/auth/";

  constructor(private http: HttpClient) { }

  login(model: any) {
    this.http.post(this.baseUrl + 'login', model).pipe(

      map((reponse: any) => {
        const user = reponse;
        if (user) {
          localStorage.setItem('token', user.token);
        }
      })
    );
  }

}
