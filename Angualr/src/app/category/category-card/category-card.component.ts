import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { CategoryDto } from 'src/app/_models/categoryDto';
import { CategoryService } from 'src/app/_services/category.service';

@Component({
  selector: 'category-card',
  templateUrl: './category-card.component.html',
  styleUrls: ['./category-card.component.css']
})
export class CategoryCardComponent implements OnInit {
  @Input() category: CategoryDto;
  @Output() categoryDeleted: EventEmitter<number> = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {

  }

  deleteCategory(id: number) {
    this.categoryDeleted.emit(id);
  }
}
