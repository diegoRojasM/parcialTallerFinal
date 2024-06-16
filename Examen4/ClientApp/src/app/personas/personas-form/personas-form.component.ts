import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IPersona } from '../IPersona';
import { PersonasService } from '../personas.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-personas-form',
  templateUrl: './personas-form.component.html',
  styleUrls: ['./personas-form.component.css']
})
export class PersonasFormComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private personaService: PersonasService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private datePipe: DatePipe
  ) {}

  modoEdicion: boolean = false;
  formGroup!: FormGroup;
  personaId!: number;

  ngOnInit() {
    this.formGroup = this.fb.group({
      nombre: '',
      fechaNacimiento: ''
    });

    this.activatedRoute.params.subscribe(params => {
      if (params['id'] === undefined) {
        return;
      }
      this.modoEdicion = true;

      this.personaId = params['id'];
      // Necesito traer los valores de la persona por el id
      this.personaService.getPersona(this.personaId.toString())
        .subscribe(persona => this.cargarFormulario(persona),
                   error => console.error(error));
    });
  }

  cargarFormulario(persona: IPersona) {
    const format = 'yyyy-MM-dd'; 

    this.formGroup.patchValue({
      nombre: persona.nombre,
      fechaNacimiento: this.datePipe.transform(persona.fechaNacimiento, format) // Formato correcto para fecha
    });
  }

  save() {
    let persona: IPersona = Object.assign({}, this.formGroup.value);
    console.table(persona);

    if(this.modoEdicion){
      //editar el registro
      persona.id = this.personaId; // pasamos el valor de la persona

      this.personaService.updatePersona(persona)
        .subscribe(persona => this.onSaveSuccess(),
          error => console.error(error))
    }else{
      //crear el registro
      this.personaService.createPersona(persona)
      .subscribe(
        persona => this.onSaveSuccess(),
        error => console.error(error)
      );
    }


  }

  onSaveSuccess() {
    this.router.navigate(['/personas']);
  }
}
