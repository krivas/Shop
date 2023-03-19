import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LogInComponent } from './log-in/log-in.component';
import { ProductComponent } from './product/product.component';
import { RegisterComponent } from './register/register.component';
import { AddTokenInterceptor } from '../Interceptors/AddTokenInterceptor';
import { GuardService } from '../Services/guard.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ProductComponent,
    LogInComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LogInComponent, pathMatch: 'full' },
      { path: 'products', component: ProductComponent,canActivate:[GuardService]  },
      { path: 'register', component: RegisterComponent }
      
    ])
  ],
  providers: [ { provide: HTTP_INTERCEPTORS, useClass: AddTokenInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }

