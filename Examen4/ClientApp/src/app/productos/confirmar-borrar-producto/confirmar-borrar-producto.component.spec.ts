import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmarBorrarProductoComponent } from './confirmar-borrar-producto.component';

describe('ConfirmarBorrarProductoComponent', () => {
  let component: ConfirmarBorrarProductoComponent;
  let fixture: ComponentFixture<ConfirmarBorrarProductoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConfirmarBorrarProductoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConfirmarBorrarProductoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
