import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AcountInfoComponent } from './acount-info/acount-info.component';
import { MaterialModule } from '../material/material/material.module';
import { FormsModule, ReactiveFormsModule  } from "@angular/forms";
import{HttpClientModule}from '@angular/common/http';




@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    AcountInfoComponent
   
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ]
  ,exports:[
    LoginComponent
  ]
})

export class AcountModule { }
