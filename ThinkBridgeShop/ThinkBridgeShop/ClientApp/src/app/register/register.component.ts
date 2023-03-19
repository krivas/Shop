import { Component, OnInit } from '@angular/core';
import { UserRegister } from '../../Models/UserRegister';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor() { }
  user:UserRegister={name:"",email:"", password:""};
  
  ngOnInit(): void {
  }

  onSubmit()
  {

  }
}
