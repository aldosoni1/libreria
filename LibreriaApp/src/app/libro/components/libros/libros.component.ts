import { Component, OnInit, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';
import { LibroService } from '../../../core/services/libro.service';

@Component({
  selector: 'app-libros',
  templateUrl: './libros.component.html',
  styleUrls: ['./libros.component.css']
})

export class LibrosComponent implements OnInit {
  @ViewChild('dataGridVar', { static: false })
  dataGrid!: DxDataGridComponent;
  store!: DataSource;
  idLibro!:string;
  constructor(private librosService: LibroService) { }
  ngOnInit(): void {
    this.store = new DataSource({
      store: new CustomStore({
        load: (data) => {
          return this.librosService.getAll(data.searchValue, data.skip, data.take).toPromise()
        },
        byKey: (key) => {
          return this.librosService.getById(key).toPromise()
        },
        update: (key, values) => {
          return this.librosService.update(key, values).toPromise()
        },
        remove: (key) => {
          return this.librosService.eliminar(key.id).toPromise()
        },
      }),
      paginate: true,
      pageSize: 5
    });
  }
}
