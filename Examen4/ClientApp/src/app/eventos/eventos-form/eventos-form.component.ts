import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-eventos-form',
  templateUrl: './eventos-form.component.html',
  styleUrls: ['./eventos-form.component.css'],
  providers: [DatePipe]
})
export class EventosFormComponent {

  constructor(private fb: FormBuilder){}
  formGroup!: FormGroup;

  ngOnInit() {
    this.formGroup = this.fb.group({
      nombre: '',
      descripcion: '',
      ubicacion: '',
      informacionContacto: '',
      fechaInicio:'',
      fechaFin: '',
      estado: ''
      //participantes: this.fb.array([])
    });
  }
  save() {
    throw new Error('Method not implemented.');
    }


}
