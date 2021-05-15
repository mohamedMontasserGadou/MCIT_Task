import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductDto } from 'src/app/_models/productDto';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
  products: ProductDto[];
  categoryId: number;
  constructor(private productService: ProductService ,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.categoryId = +this.route.snapshot.paramMap.get('categoryId');
    if(this.categoryId)
    {
      this.loadCategoryProducts(this.categoryId);
    }
  }

  loadCategoryProducts(categoryId: number) {
    this.productService.getAll(categoryId)
    .subscribe((products: ProductDto[]) => this.products = products);
  }

  deleteProduct(id: number) {
    this.productService.delete(id)
    .subscribe(() => this.loadCategoryProducts(this.categoryId));
  }

}
