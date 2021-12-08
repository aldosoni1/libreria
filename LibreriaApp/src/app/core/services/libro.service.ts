import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GridLibrosViewModel, LibroViewModel } from '../../libro/models/libroViewModel.model';
import { environment } from '../../../environments/environment';
import { LibroEditViewModel } from 'src/app/libro/models/libroEditViewModel';

@Injectable({
  providedIn: 'root'
})
export class LibroService {

  constructor(private httpClient: HttpClient) { }
  getAll(searchValue?: string, skip?: number, take?: number): Observable<GridLibrosViewModel> {
    let params = new HttpParams();
    if (searchValue) params = params.set('searchValue', searchValue);
    if (skip) params = params.set('skip', skip.toString());
    if (take) params = params.set('take', take.toString());
    return this.httpClient.get<GridLibrosViewModel>(`${environment.urlApi}Libro`, { params: params });
  }
  eliminar(id: string): Observable<void> {
    return this.httpClient.delete<void>(`${environment.urlApi}Libro/${id}`);
  }
  getById(id: string): Observable<LibroViewModel> {
    return this.httpClient.get<LibroViewModel>(`${environment.urlApi}Libro/${id}`);
  }
  update(actual: LibroViewModel, actualizado: LibroViewModel): Observable<LibroViewModel> {
    let data: LibroEditViewModel = {
      autor: actualizado.autor ? actualizado.autor: actual.autor,
      id:actual.id,
      nombre:actualizado.nombre ? actualizado.nombre: actual.nombre,
      numeroHojas:actualizado.noPaginas ? actualizado.noPaginas: actual.noPaginas
    };
    return this.httpClient.patch<LibroViewModel>(`${environment.urlApi}Libro`, data);
  }
}
