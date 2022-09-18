import { NgModule } from '@angular/core';
import {CommonModule } from '@angular/common';
import {MatFormFieldModule } from '@angular/material/form-field';
import {MatCardModule} from '@angular/material/card';
import {MatIconModule } from '@angular/material/icon';
import {MatInputModule } from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select'
import {MatMenuModule} from '@angular/material/menu';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule } from '@angular/material/paginator';
import { MatDialogModule } from '@angular/material/dialog';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatToolbarModule } from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import {MatTooltipModule} from '@angular/material/tooltip';


const materialComponents = [
  MatFormFieldModule,
  MatCardModule,
  MatIconModule,
  MatInputModule,
  MatSelectModule,
  MatMenuModule,
  MatTableModule,
  MatPaginatorModule,
  MatDialogModule,
  MatProgressBarModule,
  MatToolbarModule,
  MatButtonModule,
  MatTooltipModule,
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
