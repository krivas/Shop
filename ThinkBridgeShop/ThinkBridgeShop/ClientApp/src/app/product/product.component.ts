import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Product } from '../../Models/Product';
import { DataService } from '../../Services/data.service';
import { ProductService } from '../../Services/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './product.component.html',
})
export class ProductComponent implements OnInit {
  products:Product[]=[];
  displayError:string="";
  product={name:"",price:"",description:""};

  constructor(private productService: ProductService,private dataService:DataService){}
  
  isLoggedIn:boolean=false;
  ngOnInit()
  {
    this.getProducts();
    this.dataService.getData().subscribe(response=>this.isLoggedIn=response);
  }
  getProducts()
  {

    this.productService.getProducts()
    .subscribe(response=> this.products=response);
  }

  submit(form:NgForm)
  {

  }

  delete(product:Product,index:number)
  {

  }
  edit(product:Product)
  {

  }
  editProduct(form:NgForm)
  {

  }
}

