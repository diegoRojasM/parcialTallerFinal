import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarParticipanteEventoComponent } from './agregar-participante-evento.component';

describe('AgregarParticipanteEventoComponent', () => {
  let component: AgregarParticipanteEventoComponent;
  let fixture: ComponentFixture<AgregarParticipanteEventoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgregarParticipanteEventoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AgregarParticipanteEventoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
