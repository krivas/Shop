
import { environment } from './../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/internal/Observable';
import * as moment from 'moment';

import { LoginUser } from '../Models/LoginUser';
import { LoginResponse } from '../Models/LoginResponse';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
    
    constructor(private http: HttpClient) { }
    baseUrl:string="http://localhost:44494/api/security/login";
     controller:string='authenticate';

    login(formData:LoginUser) :Observable<LoginResponse> {
        return this.http.post<LoginResponse>(this.baseUrl,formData);
      }

      logout() {
        localStorage.removeItem("token");
        localStorage.removeItem("expires_at");
        localStorage.removeItem("username");
      }

      public SetTokenInfo(response:LoginResponse)  {
        localStorage.setItem("token",response.token);
        localStorage.setItem("expires_at",response.expiration);
      }

      isLoggedIn() {
        return moment().isBefore(this.getExpiration());
      }

     public getToken() {
        return localStorage.getItem("token") ;
      }

     getExpiration(){
       const expiration=localStorage.getItem("expires_at");
       return  moment(expiration);
    }
    
}


