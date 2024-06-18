import { Component } from '@angular/core';
import { IEvento } from './Evento';
import { EventosService } from './eventos.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent {

  eventos: IEvento[]=[];

  constructor(private eventosService: EventosService) {
    // Aquí podrías inicializar eventos con datos obtenidos de algún servicio o fuente de datos
    this.eventos = [
      {
        id: 1,
        nombre: 'Evento 1',
        ubicacion: 'Ubicación 1',
        descripcion: 'Descipcion1',
        informacionContacto: 'Contacto 1',
        fechaInicio: new Date('2024-07-01'),
        fechaFin: new Date('2024-07-03'),
        estado: 'activo'
      },
      {
        id: 2,
        nombre: 'Evento 2',
        ubicacion: 'Ubicación 2',
        descripcion: 'Descipcion2',
        informacionContacto: 'Contacto 2',
        fechaInicio: new Date('2024-07-05'),
        fechaFin: new Date('2024-07-07'),
        estado: 'activo'
      },
      // Más objetos eventos...
    ];
  }

  ngOnInit(){
    this.eventosService.getEventos()
    .subscribe(event => this.eventos = event,
      error => console.error(error));
  }




  delete(_t21: IEvento) {
    console.log('Method not implemented.');
    }

}
