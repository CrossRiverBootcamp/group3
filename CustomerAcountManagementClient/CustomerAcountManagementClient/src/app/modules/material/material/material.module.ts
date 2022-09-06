import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatCardModule} from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';



const materialComponents = [
  MatFormFieldModule,
  MatCardModule,
  MatIconModule,
  MatInputModule
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
