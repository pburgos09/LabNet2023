import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NewCategory } from 'src/app/interfaces/category.interface';
import { CategoryService } from 'src/app/services/category.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-new-category',
  templateUrl: './new-category.component.html',
  styleUrls: ['./new-category.component.scss'],
})
export class NewCategoryComponent implements OnInit {
  form = new FormGroup({
    CategoryName: new FormControl('', [
      Validators.maxLength(15),
      Validators.required,
    ]),
    Description: new FormControl('', [
      Validators.maxLength(150),
      Validators.required,
    ]),
  });
  constructor(
    private categoryService: CategoryService,
    private router: Router,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {}

  hasError(controlName: string, errorName: string) {
    return this.form.get(controlName)?.hasError(errorName);
  }

  isSubmitDisabled() {
    return this.form.invalid;
  }

  onSubmit() {
    if (this.form.valid) {
      const formData = this.form.value;
      const newCategory: NewCategory = {
        CategoryName: formData.CategoryName || '',
        Description: formData.Description || '',
      };
  
      this.categoryService.addCategory(newCategory).subscribe(
        () => {
          this.notificationService.success('Categoria agregada exitosamente');
          this.goBack();
        },
        (error) => {
          this.notificationService.error('Error al agregar la categoria: ' + error.message);
        }
      );
    }
  }
  

  goBack() {
    this.router.navigate(['/']);
  }
}
