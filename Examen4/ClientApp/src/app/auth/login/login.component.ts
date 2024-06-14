import { Component, Inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IUsuario } from './IUsuario';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { User } from 'oidc-client';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  public usuarios:IUsuario[]=[];
  loginError:string="";

  currentUserLoginOn: BehaviorSubject<boolean>= new BehaviorSubject<boolean>(false);
  currentUserData: BehaviorSubject<IUsuario> = new BehaviorSubject<IUsuario>({id:0,nombre:'',correo:'',clave:''});

  loginForm=this.formBuilder.group({
      email:['diego@gmail.com',[Validators.required,Validators.email]],
      password:['',[Validators.required]]
    })
    constructor(
      private http: HttpClient, 
      @Inject('BASE_URL') private baseUrl: string,
      private formBuilder: FormBuilder, 
      private router: Router
    ) {

    }
    

  get email(){
    return this.loginForm.controls.email;
  }
  get password(){
    return this.loginForm.controls.password;
  }

  login(){
    if(this.loginForm.valid){
      console.log("Llamar al servicio de login")
      this.http.get<IUsuario[]>(this.baseUrl + "eventos").subscribe({
        next: (result) => {
          this.usuarios = result;
          console.log(result);
          console.log(this.usuarios);
        },
        error: (error) => {console.log(error)
        this.loginError="Algo fallo, intente nuevamente";
      },
        complete: () => {
          console.info("login completo");
          //this.login();
          this.router.navigateByUrl("/inicio");
          this.loginForm.reset();
        }
      });

    }
    else{
      this.loginForm.markAllAsTouched();
    }
  }


}

