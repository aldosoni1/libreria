import { Component, OnInit } from '@angular/core';

export interface LibroViewModel {
  nombre: string;
  autor: string;
}
@Component({
  selector: 'app-libros',
  templateUrl: './libros.component.html',
  styleUrls: ['./libros.component.css']
})

export class LibrosComponent implements OnInit {

  constructor() { }
  libros: LibroViewModel[] = [
    {
      autor: 'Aldo',
      nombre: 'Libro 1'
    },
    {
      autor: 'Ignacio',
      nombre: 'Libro 2'
    }
  ]
  ngOnInit(): void {
    fetch('https://localhost:44394/api/libro').then(x=>x.json()).then(data => this.libros = data)
  }

}
