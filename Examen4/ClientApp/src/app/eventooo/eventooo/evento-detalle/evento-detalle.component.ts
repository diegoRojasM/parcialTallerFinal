// import { Component } from '@angular/core';

// @Component({
//   selector: 'app-evento-detalle',
//   templateUrl: './evento-detalle.component.html',
//   styleUrls: ['./evento-detalle.component.css']
// })
// export class EventoDetalleComponent {

// }

import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-evento-detalle',
  templateUrl: './evento-detalle.component.html',
  styleUrls: ['./evento-detalle.component.css']
})
export class EventDetailComponent implements OnInit {
  public evento: IEvento | undefined;
  public nuevoParticipante: IParticipante = {
    id: 0,
    nombre: '',
    direccion: '',
    fechaNacimiento: new Date(),
    correo: '',
    numeroTelefono: '',
    organizacion: '',
    profesion: '',
    cargo: '',
    eventos: [],
    certificados: []
  };
  public nuevoEquipo: IEquipo = {
    id: 0,
    nombre: '',
    institucion: '',
    representante: '',
    miembros: [],
    eventos: [],
    certificados: []
  };

  constructor(private route: ActivatedRoute, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  ngOnInit() {
    const eventoId = +this.route.snapshot.paramMap.get('id')!;
    this.http.get<IEvento>(`${this.baseUrl}evento/${eventoId}`).subscribe(result => {
      this.evento = result;
      console.log(result);
    }, error => console.error(error));
  }
  agregarParticipante(eventoId: number) {
    this.http.post(`${this.baseUrl}evento/${eventoId}/participantes`, this.nuevoParticipante).subscribe(() => {
      console.log('Participante agregado');

    }, error => console.error(error));
  }


  agregarEquipo(eventoId: number) {
    this.http.post(`${this.baseUrl}evento/${eventoId}/equipos`, this.nuevoEquipo).subscribe(() => {
      console.log('Equipo agregado');

    }, error => console.error(error));
  }
}

export interface IEvento {
  id: number;
  nombre: string;
  descripcion: string;
  ubicacion: string;
  informacionContacto: string;
  fechaInicio: Date;
  fechaFin: Date;
  estado: string; // Estado del evento: Activo o Inactivo
  tipo: string; // Tipo del evento: Participantes o Equipos
  participantes: IParticipante[];
  equipos: IEquipo[];
}


export interface IParticipante {
  id: number;
  nombre: string;
  direccion: string;
  fechaNacimiento: Date;
  correo: string;
  numeroTelefono: string;
  organizacion: string;
  profesion: string;
  cargo: string;
  eventos: IEvento[];
  certificados: any[]; // Assuming certificados is an array of some kind
}

export interface IEquipo {
  id: number;
  nombre: string;
  institucion: string;
  representante: string;
  miembros: IParticipante[];
  eventos: IEvento[];
  certificados: any[]; // Assuming certificados is an array of some kind
}
