
import { environment } from './../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/internal/Observable';
import * as moment from 'moment';

import { LoginUser } from '../Models/LoginUser';
import { LoginResponse } from '../Models/LoginResponse';
import { UserRegister } from '../Models/UserRegister';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
    
    constructor(private http: HttpClient) { }
    baseUrl:string="http://localhost:44494/api/security";

     controller:string='authenticate';
     private isLoggedInBehaviorSubject = new BehaviorSubject<boolean>(false);

  
    login(formData:LoginUser) :Observable<LoginResponse> {
        return this.http.post<LoginResponse>(`${this.baseUrl}/login`,formData);
      }

      register(formData:UserRegister) :Observable<string> {
        return this.http.post<string>(`${this.baseUrl}/register`,formData);
      }


      logout() {
        localStorage.removeItem("token");
        localStorage.removeItem("expires_at");
        localStorage.removeItem("username");
        this.isLoggedInBehaviorSubject.next(false);
      }

      public SetTokenInfo(response:LoginResponse)  {
        localStorage.setItem("token",response.token);
        localStorage.setItem("expires_at",response.expiration);
        this.isLoggedInBehaviorSubject.next(true)
      }
      
      isUserLoggedInObservable()
      {
        this.isLoggedInBehaviorSubject.next(this.isLoggedIn());
        return this.isLoggedInBehaviorSubject.asObservable();
      }

      isLoggedIn():boolean {
        const isLoggedIn=moment().isBefore(this.getExpiration());
       
        return isLoggedIn;
     
      }

     public getToken() {
        return localStorage.getItem("token") ;
      }

     getExpiration(){
       const expiration=localStorage.getItem("expires_at");
       return  moment(expiration);
    }
    
}


