import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { AdminGuard } from './_guards/admin.guard';
import { CategoriesListComponent } from './category/categories-list/categories-list.component';
import { ProductsListComponent } from './product/products-list/products-list.component';
import { CreateOrEditCategoryComponent } from './category/create-or-edit-category/create-or-edit-category.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'categories', component: CategoriesListComponent},
      {path: 'categories/add', component: CreateOrEditCategoryComponent},
      {path: 'categories/edit/:id', component: CreateOrEditCategoryComponent},
      {path: 'products/:categoryId', component: ProductsListComponent},
      {path: 'admin', component: AdminPanelComponent, canActivate: [AdminGuard]},
    ]
  },
  // {path: 'errors', component: TestErrorsComponent},
  // {path: 'not-found', component: NotFoundComponent},
  // {path: 'server-error', component: ServerErrorComponent},
  // {path: '**', component: NotFoundComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
