import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LogInComponent } from './log-in/log-in.component';
import { ProductComponent } from './product/product.component';
import { RegisterComponent } from './register/register.component';


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
      { path: 'products', component: ProductComponent },
      { path: 'register', component: RegisterComponent }
      
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

