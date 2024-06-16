import { Component } from '@angular/core';
import { IPersona } from './IPersona';
import { PersonasService } from './personas.service';

@Component({
  selector: 'app-personas',
  templateUrl: './personas.component.html',
  styleUrls: ['./personas.component.css']
})
export class PersonasComponent {
  public personas:IPersona[] =[];
  

  constructor(private personasService: PersonasService){}

  ngOnInit(){
    this.personasService.getPersonas()
    .subscribe(personasD => this.personas = personasD,
        error => console.error(error)
    ); //el listado de persona que viene desde el webService asignelo a la var
  }
}
