import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Category } from 'src/app/interfaces/category.interface';
import { CategoryService } from 'src/app/services/category.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.scss'],
})
export class EditCategoryComponent implements OnInit {
  form = new FormGroup({
    CategoryID: new FormControl(0, [Validators.required]),
    CategoryName: new FormControl('', [
      Validators.maxLength(15),
      Validators.required,
    ]),
    Description: new FormControl('', [
      Validators.maxLength(150),
      Validators.required,
    ]),
  });

  id!: number;
  category$!: Observable<Category>;

  constructor(
    private categoryService: CategoryService,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id')) || 0;
    this.category$ = this.categoryService.getCategoryById(this.id);
    this.category$.subscribe((category) => {
      if (category) {
        this.form.patchValue({
          CategoryID: category.CategoryID,
          CategoryName: category.CategoryName,
          Description: category.Description,
        });
      }
    });
  }

  hasError(controlName: string, errorName: string) {
    return this.form.get(controlName)?.hasError(errorName);
  }

  isSubmitDisabled() {
    return this.form.invalid;
  }

  onSubmit() {
    if (this.form.valid) {
      const formData = this.form.value;
      const updatedCategory: Category = {
        CategoryID:
          formData.CategoryID !== null && formData.CategoryID !== undefined
            ? Number(formData.CategoryID)
            : 0,
        CategoryName: formData.CategoryName || '',
        Description: formData.Description || '',
      };
  
      this.categoryService.updateCategory(updatedCategory).subscribe(
        (data) => {
          console.log(data);
          this.notificationService.success('Categoria actualizada exitosamente');
          this.goBack();
        },
        (error) => {
          this.notificationService.error('Error al actualizar la categoria: ' + error.message);
        }
      );
    }
  }
  

  goBack() {
    this.router.navigate(['/']);
  }
}
