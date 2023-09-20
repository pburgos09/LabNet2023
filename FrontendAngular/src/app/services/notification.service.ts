import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor() { }

  success(message: string) {
    Swal.fire({
      title: 'Exito!',
      text: message,
      icon: 'success',
      confirmButtonText: 'Ok'
    });
  }

  error(message: string) {
    Swal.fire({
      title: 'Error!',
      text: message,
      icon: 'error',
      confirmButtonText: 'Ok'
    });
  }

  confirmation(message: string) {
    return Swal.fire({
      title: '¿Estas seguro?',
      text: message,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes',
      cancelButtonText: 'No'
    });
  }
}
