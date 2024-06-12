import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IProducto } from '../productos';

@Component({
  selector: 'app-editar-producto',
  templateUrl: './editar-producto.component.html',
  styleUrls: ['./editar-producto.component.css']
})
export class EditarProductoComponent implements OnInit {
  productoForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router,
    @Inject('BASE_URL') private baseUrl: string
  ) {
    this.productoForm = this.fb.group({
      id: [''],
      nombre: ['', Validators.required],
      descripcion: ['', Validators.required],
      precio: [0, [Validators.required, Validators.min(0.01)]],
      categoria: ['', Validators.required],
      stock: [0, [Validators.required, Validators.min(0)]]
    });
  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.http.get<IProducto>(this.baseUrl + 'productos/' + id).subscribe(result => {
      this.productoForm.patchValue(result);
    }, error => console.error(error));
  }

  onSubmit() {
    if (this.productoForm.valid) {
      this.http.put(this.baseUrl + 'productos/' + this.productoForm.value.id, this.productoForm.value).subscribe(() => {
        this.router.navigate(['/productos']);
      }, error => console.error(error));
    }
  }
}
