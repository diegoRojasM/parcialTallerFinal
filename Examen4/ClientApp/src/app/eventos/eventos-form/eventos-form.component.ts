import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IEvento } from '../Evento';
import { EventosService } from '../eventos.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-eventos-form',
  templateUrl: './eventos-form.component.html',
  styleUrls: ['./eventos-form.component.css'],
  providers: [DatePipe]
})
export class EventosFormComponent implements OnInit {
  formGroup!: FormGroup;
  modoVerDetalle: boolean = false; // Set this based on your logic
  eventoId! : number;

  constructor(private fb: FormBuilder,
              private eventoService: EventosService,
              private router: Router,
              private activatedRoute: ActivatedRoute,
              private datePipe: DatePipe,) {}

  ngOnInit() {
    this.formGroup = this.fb.group({
      nombre: ['', Validators.required],
      descripcion: ['', Validators.required],
      ubicacion: ['', Validators.required],
      informacionContacto: ['', Validators.required],
      fechaInicio: ['', Validators.required],
      fechaFin: ['', Validators.required],
      estado: { value: 'Activo', disabled: this.modoVerDetalle }
    });

    
    this.activatedRoute.params.subscribe(params => {
      if (params['id'] === undefined) {
        return;
      }
      this.modoVerDetalle = true;

      this.eventoId = params['id'];
      this.eventoService.getEvento(this.eventoId.toString())
        .subscribe(evento => this.cargarFormulario(evento),
                   error => console.error(error));
    });

    if (this.modoVerDetalle) {
      this.formGroup.disable();
    }
    
  }

  cargarFormulario(evento : IEvento){
    const format = 'yyyy-MM-dd';

    this.formGroup.patchValue({
      nombre: evento.nombre,
      descripcion: evento.descripcion,
      ubicacion: evento.ubicacion,
      informacionContacto: evento.informacionContacto,
      fechaInicio: this.datePipe.transform(evento.fechaInicio, format),
      fechaFin: this.datePipe.transform(evento.fechaFin, format),
      estado: evento.estado
    })
  }

  save() {
    if (this.modoVerDetalle) return;

    let evento: IEvento = Object.assign({}, this.formGroup.value);
    console.table(evento);

    this.eventoService.createEvento(evento)
      .subscribe(evento => this.onSaveSuccess(),
                 error => console.error(error));
  }

  onSaveSuccess() {
    this.router.navigate(['/eventos']);
  }
}
