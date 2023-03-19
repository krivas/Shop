import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../../Models/LoginUser';
import { DataService } from '../../Services/data.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-fetch-data',
  templateUrl: './log-in.component.html'
})
export class LogInComponent implements OnInit {
  user:User={name:"",password:""};
  constructor(private dataService:DataService,private router:Router){}

  ngOnInit(): void {
   this.dataService.getData().subscribe(response=>{

    if (response)
      this.router.navigate(['/products'])
   });
     
  }
  onSubmit() {

    this.dataService.setData(true);
    this.router.navigate(['/products'])
  }

  check() {
   
   }
}



