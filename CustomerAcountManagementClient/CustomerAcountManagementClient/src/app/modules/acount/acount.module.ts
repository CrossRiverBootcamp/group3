import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AcountInfoComponent } from './acount-info/acount-info.component';



@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    AcountInfoComponent
  ],
  imports: [
    CommonModule
  ]
})
export class AcountModule { }
