// import { BrowserModule } from '@angular/platform-browser';
// import { NgModule } from '@angular/core';
// import { FormsModule, ReactiveFormsModule } from '@angular/forms';
// import { HttpClientModule } from '@angular/common/http';
// import { RouterModule } from '@angular/router';

// import { AppComponent } from './app.component';
// import { NavMenuComponent } from './nav-menu/nav-menu.component';
// import { HomeComponent } from './home/home.component';
// import { CounterComponent } from './counter/counter.component';
// import { FetchDataComponent } from './fetch-data/fetch-data.component';
// import { ProductosComponent } from './productos/productos.component';
// //import { ProductosFormComponent } from './productos/productos-form/productos-form.component';



// @NgModule({
//   declarations: [
//     AppComponent,
//     NavMenuComponent,
//     HomeComponent,
//     CounterComponent,
//     FetchDataComponent,
//     ProductosComponent,

//   ],
//   imports: [
//     BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
//     HttpClientModule,
//     FormsModule,
//     ReactiveFormsModule,

//     RouterModule.forRoot([
//       { path: '', component: HomeComponent, pathMatch: 'full' },
//       { path: 'counter', component: CounterComponent },
//       { path: 'fetch-data', component: FetchDataComponent },
//       { path: 'productos', component: ProductosComponent },


//     ])
//   ],
//   providers: [],
//   bootstrap: [AppComponent]
// })
// export class AppModule { }



import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ProductosComponent } from './productos/productos.component';
import { AgregarProductoComponent } from './productos/agregar-producto/agregar-producto.component';
import { EditarProductoComponent } from './productos/editar-producto/editar-producto.component';
import { ConfirmarBorrarProductoComponent } from './productos/confirmar-borrar-producto/confirmar-borrar-producto.component';

import { LoginComponent } from './auth/login/login.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { NavComponent } from './shared/nav/nav.component';
import { EventComponent } from './eventos/event/event.component';

import { EventoooComponent } from './eventooo/eventooo/eventooo.component';
import { EventDetailComponent } from './eventooo/eventooo/evento-detalle/evento-detalle.component'; 

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProductosComponent,
    AgregarProductoComponent,
    EditarProductoComponent,
    ConfirmarBorrarProductoComponent,
    LoginComponent,
    DashboardComponent,
    NavComponent,
    EventComponent,
    EventoooComponent,
    EventDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', /*redirectTo:'/inicio'*/component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'productos', component: ProductosComponent },
      { path: 'agregar', component: AgregarProductoComponent },
      { path: 'editar/:id', component: EditarProductoComponent },
      { path: 'borrar/:id', component: ConfirmarBorrarProductoComponent },


      { path: 'inicio', component: DashboardComponent },
      { path: 'iniciar-sesion', component: LoginComponent },
      { path: 'events', component: EventComponent },
      { path: 'eventooo', component: EventoooComponent },
      { path: 'evento-detalle/:id', component: EventDetailComponent },


    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
