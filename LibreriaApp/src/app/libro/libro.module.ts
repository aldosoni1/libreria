import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LibroRoutingModule } from './libro-routing.module';
import { LibrosContainer } from './containers/libros/libros.container';
import { LibrosComponent } from './components/libros/libros.component';
import { LibroContainer } from './containers/libro/libro.container';
import { LibroComponent } from './components/libro/libro.component';
import { DevExtremeModule } from '../dev-extreme/dev-extreme.module';


@NgModule({
  declarations: [
    LibrosContainer,
    LibrosComponent,
    LibroContainer,
    LibroComponent
  ],
  imports: [
    CommonModule,
    LibroRoutingModule,
    DevExtremeModule
  ]
})
export class LibroModule { }
