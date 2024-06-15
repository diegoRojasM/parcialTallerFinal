import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventoooComponent } from './eventooo.component';

describe('EventoooComponent', () => {
  let component: EventoooComponent;
  let fixture: ComponentFixture<EventoooComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventoooComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EventoooComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
