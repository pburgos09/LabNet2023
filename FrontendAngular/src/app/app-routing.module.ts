import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './components/list/list.component';
import { NewCategoryComponent } from './components/new-category/new-category.component';
import { EditCategoryComponent } from './components/edit-category/edit-category.component';

const routes: Routes = [
  {
    path: '',
    component: ListComponent,
  },
  {
    path: 'newCategory',
    component: NewCategoryComponent,
  },
  {
    path: 'editCategory/:id',
    component: EditCategoryComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
