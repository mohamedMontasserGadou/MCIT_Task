import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryDto } from 'src/app/_models/categoryDto';
import { CategoryService } from 'src/app/_services/category.service';

@Component({
  selector: 'app-create-or-edit-category',
  templateUrl: './create-or-edit-category.component.html',
  styleUrls: ['./create-or-edit-category.component.css']
})
export class CreateOrEditCategoryComponent implements OnInit {
  category: CategoryDto;
  id? : number;
  constructor(private categoryService: CategoryService, private route: ActivatedRoute,
    private router: Router) { }


  ngOnInit(): void {
    this.id = +this.route.snapshot.paramMap.get('id');
    this.category = new CategoryDto();
    if(this.id)
    {
      this.categoryService.get(this.id)
      .subscribe((c: CategoryDto) => this.category = c);
    }
  }

  createOrEditCategory() {
    if(this.id)
      this.editCategory(this.id);
    else
      this.createCategory();
  }

  private editCategory(id: number) {
    this.categoryService.edit(id, {name: this.category.name})
    .subscribe(() => this.router.navigateByUrl('categories') );
  }

  private createCategory() {
    this.categoryService.add({name: this.category.name})
    .subscribe(() => this.router.navigateByUrl('categories') );
  }
}
