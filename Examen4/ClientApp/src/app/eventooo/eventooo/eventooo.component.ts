import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventooo',
  templateUrl: './eventooo.component.html',
  styleUrls: ['./eventooo.component.css']
})
export class EventoooComponent {
  public eventos: IEvento[] = [];
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

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
    this.loadEventos();
  }

  loadEventos() {
    this.http.get<IEvento[]>(this.baseUrl + 'evento').subscribe(result => {
      this.eventos = result;
      console.log(result);
    }, error => console.error(error));
  }

  agregarEvento() {
    this.router.navigate(['/agregar-evento']);
  }

  editarEvento(evento: IEvento) {
    this.router.navigate(['/editar-evento', evento.id]);
  }

  verDetalleEvento(eventoId: number) {
    this.router.navigate(['/evento-detalle', eventoId]);
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
