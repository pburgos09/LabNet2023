import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/interfaces/category.interface';
import { CategoryService } from 'src/app/services/category.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
})
export class ListComponent implements OnInit {
  categories: Category[] = [];

  constructor(
    private categoryService: CategoryService,
    private notificationService: NotificationService
  ) {}
  ngOnInit(): void {
    this.categoryService.getCategories().subscribe((data) => {
      this.categories = data;
    });
  }

  deleteCategory(id: number) {
    this.notificationService
      .confirmation('¿Estás seguro?')
      .then((result: any) => {
        if (result.isConfirmed) {
          this.categoryService.deleteCategory(id).subscribe(
            () => {
              this.categories = this.categories.filter(
                (category) => category.CategoryID !== id
              );
              this.notificationService.success('Categoria eliminada');
            },
            (error) => {
              this.notificationService.error('Error al eliminar la categoria: ' + error.message);
            }
          );
        } else {
          this.notificationService.error('Categoria no eliminada');
        }
      });
  }
  
}
