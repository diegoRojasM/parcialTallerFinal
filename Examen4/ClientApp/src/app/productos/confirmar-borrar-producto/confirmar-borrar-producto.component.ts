import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { IProducto } from '../productos';

@Component({
  selector: 'app-confirmar-borrar-producto',
  templateUrl: './confirmar-borrar-producto.component.html',
  styleUrls: ['./confirmar-borrar-producto.component.css']
})
export class ConfirmarBorrarProductoComponent implements OnInit {
  producto: IProducto = {} as IProducto;

  constructor(private route: ActivatedRoute, private http: HttpClient, private router: Router, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.http.get<IProducto>(this.baseUrl + 'productos/' + id).subscribe(result => {
      this.producto = result;
    }, error => console.error(error));
  }

  borrarProducto() {
    this.http.delete(this.baseUrl + 'productos/' + this.producto.id).subscribe(() => {
      this.router.navigate(['/productos']);
    }, error => console.error(error));
  }

  cancelar() {
    this.router.navigate(['/productos']);
  }
}
