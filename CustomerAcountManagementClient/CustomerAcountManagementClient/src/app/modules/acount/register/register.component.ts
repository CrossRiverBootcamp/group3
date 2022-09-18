import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CustomerService } from 'src/app/services/customer.service';
import { Router } from '@angular/router';
import { Customer } from 'src/app/models/customer.model';
import { MatDialog } from '@angular/material/dialog';
import { EmailVerificationDialogComponent } from '../email-verification-dialog/email-verification-dialog.component';
import { RegisterDTO } from 'src/app/models/registerDTO.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  hide: boolean = false;
  newCustomer!:RegisterDTO;
  constructor(private _customerService: CustomerService, private router: Router,private dialog: MatDialog) { }
  ngOnInit(): void {
    this.registerForm = new FormGroup({
      "firstName": new FormControl("", Validators.required),
      "lastName": new FormControl("", Validators.required),
      "email": new FormControl("", Validators.required),
      "password": new FormControl("", [Validators.required, Validators.minLength(8)])
    });

  }
  public togglePasswordVisibility(): void {
    this.hide = !this.hide;
  }
  async register() {
this.newCustomer={
  firstName:this.registerForm?.value.firstName,
  lastName:this.registerForm?.value.lastName,
  email:this.registerForm?.value.email,
  password:this.registerForm?.value.password,
  verificationCode:""
}
this._customerService.validateEmail(this.registerForm.value?.email)
  .subscribe(()=>this.openDialog())
}
  openDialog() {
   
    const dialogRef = this.dialog.open(EmailVerificationDialogComponent);
    dialogRef.componentInstance.registerCustomer=this.newCustomer;

    dialogRef.afterClosed().subscribe(
      (data: any) => console.log("Dialog output:", data)
    );    
}

  }


