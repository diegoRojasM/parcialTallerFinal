import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPersona } from './IPersona';

@Injectable({
  providedIn: 'root'
})
export class PersonasService {
  private apiURL = this.baseUrl + "personas"

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string ) { }

  // Método para obtener personas
  getPersonas(): Observable<IPersona[]> {
    return this.http.get<IPersona[]>(this.apiURL);
  }

  createPersona(persona:IPersona): Observable<IPersona>{
    return this.http.post<IPersona>(this.apiURL,persona);
  }
}
