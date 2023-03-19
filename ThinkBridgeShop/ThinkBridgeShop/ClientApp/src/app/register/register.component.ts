import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserRegister } from '../../Models/UserRegister';
import { AuthService } from '../../Services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private authService:AuthService ) { }
  user:UserRegister={userName:"",email:"", password:""};
  errorsMessage:string="";
  successMessage:string="";
  ngOnInit(): void {
  }

  onSubmit(registerForm:NgForm)
  {
    if (registerForm.valid)
    {
      this.authService.register(this.user).subscribe(response=>{
        this.successMessage="User Created succesfully"; 
       },
        (error) => {
          console.log(error);
          if (error.status === 400) {
            this.errorsMessage=error;
          } 
        });
    }
  
  }
  clear(register:NgForm)
  {
    this.user={userName:"",email:"", password:""};
    register.resetForm();
    this.successMessage="";
    this.errorsMessage="";
  }
}
