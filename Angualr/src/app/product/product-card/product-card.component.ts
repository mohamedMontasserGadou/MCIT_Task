import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { ProductDto } from 'src/app/_models/productDto';

@Component({
  selector: 'product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent implements OnInit {
  
  @Input() product: ProductDto;
  @Output() productDeleted: EventEmitter<number> = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

}
