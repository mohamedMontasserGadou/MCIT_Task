import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductDto } from 'src/app/_models/productDto';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-create-or-edit-product',
  templateUrl: './create-or-edit-product.component.html',
  styleUrls: ['./create-or-edit-product.component.css']
})
export class CreateOrEditProductComponent implements OnInit {

  
  constructor(private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router) { }

  id?: number;
  categoryId: number;
  product: ProductDto;

  ngOnInit() {
    this.id = +this.route.snapshot.paramMap.get('id');
    this.categoryId = +this.route.snapshot.paramMap.get('categoryId');

    this.product = new ProductDto();
    if(this.id)
    {
      this.productService.get(this.id)
      .subscribe((product: ProductDto) => this.product = product);
    }
  }

  createOrEditProduct() {
    if(this.id)
      this.editProduct(this.id);
    else
      this.createProduct();
  }

  private createProduct() {
    this.productService.add({name: this.product.name, price: this.product.price, categoryId: this.categoryId})
    .subscribe(() => this.goToProductList(this.categoryId));
  }

  private editProduct(id: number) {
    this.productService.edit(id, {name: this.product.name, price: this.product.price})
    .subscribe(() => this.goToProductList(this.categoryId));
  }

  private goToProductList(categoryId: number) {
    this.router.navigateByUrl(`products/${this.categoryId}`);
  }
}
