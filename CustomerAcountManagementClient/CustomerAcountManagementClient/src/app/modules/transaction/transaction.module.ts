import { NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TransactionComponent } from './transaction.component';
import { TransactionService } from 'src/app/services/transaction.service';
import{HttpClientModule}from '@angular/common/http';
import { MaterialModule } from '../material/material/material.module';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule  } from "@angular/forms";


const routes: Routes = [
  { path: '', component: TransactionComponent }
]

@NgModule({
  declarations: [
    TransactionComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialModule,
    RouterModule.forChild(routes),
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class TransactionModule {}