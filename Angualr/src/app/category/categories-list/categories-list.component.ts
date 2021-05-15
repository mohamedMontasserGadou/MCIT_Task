import { Component, OnInit } from '@angular/core';
import { CategoryDto } from 'src/app/_models/categoryDto';
import { CategoryService } from 'src/app/_services/category.service';

@Component({
  selector: 'categories-list',
  templateUrl: './categories-list.component.html',
  styleUrls: ['./categories-list.component.css']
})
export class CategoriesListComponent implements OnInit {
  
  categories: CategoryDto[];
  
  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.loadAllCategories();
  }

  deleteCategory(id: number) {
    this.categoryService.delete(id)
    .subscribe(() => this.loadAllCategories());
  }


  loadAllCategories() {
    this.categoryService.getAll()
    .subscribe((categories: CategoryDto[]) => this.categories = categories);
  }
}
