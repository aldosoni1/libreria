import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DxDataGridModule, DxSelectBoxModule, } from 'devextreme-angular';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    DxDataGridModule,
    DxSelectBoxModule
  ],
  exports: [
    DxDataGridModule,
    DxSelectBoxModule
  ]
})
export class DevExtremeModule { }
