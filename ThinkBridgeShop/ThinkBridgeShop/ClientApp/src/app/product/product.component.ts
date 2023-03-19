import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { from } from 'rxjs';
import { Product } from '../../Models/Product';
import { ProductService } from '../../Services/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './product.component.html',
})
export class ProductComponent implements OnInit {
  products:Product[]=[];
  displayError:string="";
  product: Product ={name:"",price:undefined,description:"",id:0};

  constructor(private productService: ProductService){}
  
  isLoggedIn:boolean=false;
  ngOnInit()
  {
    this.getProducts();
  }
  getProducts()
  {
    this.productService.getProducts()
    .subscribe(response=> this.products=response);
  }
  clearForm()
  {
    this.product={name:"",price:undefined,description:"",id:0};
  }
  submit(form:NgForm)
  {
    if (form.valid)
    {
      this.productService.addProduct(this.product).subscribe(
        response=> {
          console.log(response);
           this.product.id=response;
           this.products.push(this.product);
           this.clearForm();
           form.reset();
        }, error => {
          this.displayError = error.error;
        });
      
    }

  }

  delete(product:Product,index:number)
  {
     this.productService.deleteProduct(product.id)
     .subscribe(response=>{
      this.products.splice(index,1);
    });
  }
  edit(form:NgForm)
  {
    if (form.valid)
    {
      this.productService.updateProduct(this.product).subscribe(
        response=> {
          console.log(response);
           this.clearForm();
           form.reset();
           this.getProducts();
        }, error => {
          this.displayError = error.error;
        });
      
    }

  }
  copyProduct(product:Product)
  {
     const cloneProduct:Product={name:product.name,id:product.id,description:product.description,price:product.price};
     this.product=cloneProduct;
   
  }
}

