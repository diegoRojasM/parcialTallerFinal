import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { IEvento } from './Evento';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventosService {
  private apiURL = this.baseUrl + "eventos"

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string ) { }

  // Método para obtener personas
  getEventos(): Observable<IEvento[]> {
    return this.http.get<IEvento[]>(this.apiURL);
  }

  getEvento(eventoId: string): Observable<IEvento>{
    return this.http.get<IEvento>(this.apiURL + '/' + eventoId)
  }

  createEvento(evento: IEvento):Observable<IEvento>{
    return this.http.post<IEvento>(this.apiURL, evento)
  }

}
