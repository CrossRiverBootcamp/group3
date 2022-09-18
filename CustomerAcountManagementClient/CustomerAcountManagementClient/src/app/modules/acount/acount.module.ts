import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AcountInfoComponent } from './acount-info/acount-info.component';
import { HttpClientModule } from '@angular/common/http';
import { MaterialModule } from '../material/material/material.module';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { OperationsHistoryComponent } from './operations-history/operations-history.component';
import { EmailVerificationDialogComponent } from './email-verification-dialog/email-verification-dialog.component';


const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "register", component:RegisterComponent },
  { path: "acountInfo", component: AcountInfoComponent },
  { path: "operations-history", component: OperationsHistoryComponent }
 


]
@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    AcountInfoComponent,
    OperationsHistoryComponent,
    EmailVerificationDialogComponent

  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialModule,
    RouterModule.forChild(routes),
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    AcountInfoComponent,
    LoginComponent,
    RegisterComponent,
    OperationsHistoryComponent,
    EmailVerificationDialogComponent

  ]
})

export class AcountModule { }
