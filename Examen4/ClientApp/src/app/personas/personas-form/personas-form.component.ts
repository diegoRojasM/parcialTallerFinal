import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IPersona } from '../IPersona';
import { PersonasService } from '../personas.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-personas-form',
  templateUrl: './personas-form.component.html',
  styleUrls: ['./personas-form.component.css']
})
export class PersonasFormComponent {

  constructor(private fb: FormBuilder,
    private personaService:PersonasService,
    private router:Router){} //para poder consumir el servicio persona desde el componente
  formGroup!: FormGroup;

  ngOnInit(){
    this.formGroup = this.fb.group({
      nombre:'',
      fechaNacimiento:''
    })
  }
  //enviar 
  save() {
    let persona : IPersona = Object.assign({},this.formGroup.value);
    console.table(persona);

    this.personaService.createPersona(persona)
      .subscribe(persona => this.onSaveSuccess(),
          error => console.error(error)
    )
  }
  onSaveSuccess(){ //que quiero que ocurra cuando se cree la persona, navegar hasta el listado de persona
    this.router.navigate(["/personas"]); //se redirigira hacia el listado de persona
  }
}
