import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LibrosContainer } from './containers/libros/libros.container';

const routes: Routes = [
  {
    path: '',
    component: LibrosContainer
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LibroRoutingModule { }
