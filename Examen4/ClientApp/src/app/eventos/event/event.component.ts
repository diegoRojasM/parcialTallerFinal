import { Component, Inject } from '@angular/core';
import { IUsuario } from './IUsuario';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent {
  public usuarios: IUsuario[] = [];
  loginError: string = "";

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string,
    // private formBuilder: FormBuilder,  // Comentado si no se utiliza
    private router: Router
  ) {
    this.http.get<IUsuario[]>(this.baseUrl + "eventos").subscribe({
      next: (result) => {
        this.usuarios = result;
        console.log(result);
      },
      error: (error) => {
        console.log(error);
        this.loginError = "Algo falló, intente nuevamente";
      },
      complete: () => {
        console.info("login completo");
        this.router.navigateByUrl("/inicio");
      }
    });
  }
}
