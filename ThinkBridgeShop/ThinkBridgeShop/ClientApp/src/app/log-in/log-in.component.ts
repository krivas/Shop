import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginUser } from '../../Models/LoginUser';
import { DataService } from '../../Services/data.service';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth.service';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-fetch-data',
  templateUrl: './log-in.component.html'
})
export class LogInComponent implements OnInit {
  user:LoginUser={userName:"",password:""};
  errorsMessage:string="";
  constructor(private authService:AuthService,private router:Router,private dataService:DataService){}

  ngOnInit(): void {

    this.authService.isUserLoggedInObservable().subscribe(isLoggedIn=>{
      if (isLoggedIn)
      this.router.navigate(['/products']);
    })
    
     
  }
  onSubmit(userForm:NgForm) {

    if (userForm.valid)
    {
      this.authService.login(this.user).subscribe(response=>{
        this.authService.SetTokenInfo(response);
        this.router.navigate(['/products']);
      },
      (error) => {
        console.log("response con error");
        if (error.status === 401) {
          this.errorsMessage="User or password incorrect!";
        } 
      });
   
    }

  }

}



