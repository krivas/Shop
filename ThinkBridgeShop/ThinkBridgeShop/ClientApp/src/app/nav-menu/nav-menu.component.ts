import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth.service';
import { DataService } from '../../Services/data.service';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  isLoggedin: boolean=false;

  constructor(private dataService:DataService,private route:Router,private authService:AuthService){}
  ngOnInit(): void {
   this.authService.isUserLoggedInObservable().subscribe(response=>this.isLoggedin=response);
  }
  logout() {
    this.dataService.setData(false);
    this.authService.logout();
    this.route.navigate([""]);
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}

