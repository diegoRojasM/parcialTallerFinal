import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IProducto } from '../productos';

@Component({
  selector: 'app-agregar-producto',
  templateUrl: './agregar-producto.component.html',
  styleUrls: ['./agregar-producto.component.css']
})
export class AgregarProductoComponent {
  productoForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router,
    @Inject('BASE_URL') private baseUrl: string
  ) {
    this.productoForm = this.fb.group({
      nombre: ['', Validators.required],
      descripcion: ['', Validators.required],
      precio: [0, [Validators.required, Validators.min(0.01)]],
      categoria: ['', Validators.required],
      stock: [0, [Validators.required, Validators.min(0)]]
    });
  }

  onSubmit() {
    if (this.productoForm.valid) {
      this.http.post<IProducto>(this.baseUrl + 'productos', this.productoForm.value).subscribe(() => {
        this.router.navigate(['/productos']);
      }, error => console.error(error));
    }
  }
}
