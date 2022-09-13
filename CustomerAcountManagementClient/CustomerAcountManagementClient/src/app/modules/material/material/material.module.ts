import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatCardModule} from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select'
import {MatMenuModule} from '@angular/material/menu';
import {  MatToolbarModule } from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';




const materialComponents = [
  MatFormFieldModule,
  MatCardModule,
  MatIconModule,
  MatInputModule,
  MatSelectModule,
  MatMenuModule,
  MatToolbarModule,
  MatButtonModule
]
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    materialComponents
  ],
  exports:[
    materialComponents
  ]
})
export class MaterialModule { }
