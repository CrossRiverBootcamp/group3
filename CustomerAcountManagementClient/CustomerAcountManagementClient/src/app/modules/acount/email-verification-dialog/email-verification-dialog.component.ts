import { Component, OnInit, Input } from '@angular/core';
import { MatDialogRef} from "@angular/material/dialog";
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CustomerService } from 'src/app/services/customer.service';
import { RegisterDTO } from 'src/app/models/registerDTO.model';


@Component({
  selector: 'app-email-verification-dialog',
  templateUrl: './email-verification-dialog.component.html'
})
export class EmailVerificationDialogComponent implements OnInit {

  emailVerificationForm: FormGroup;
 @Input()
 registerCustomer:RegisterDTO;
  constructor(
      private dialogRef: MatDialogRef<EmailVerificationDialogComponent>, private _customerService:CustomerService){
  }

  ngOnInit() {
      this.emailVerificationForm = new FormGroup({
        "emailVerificationCode": new FormControl("",[Validators.required,Validators.minLength(4),Validators.maxLength(4)])
      });
        
    
  }

  submit(){
    this.registerCustomer.verificationCode= this.emailVerificationForm.value.emailVerificationCode
this._customerService.register(this.registerCustomer)
.subscribe(
      (success:boolean)=>{
        alert(`You have been registered successfully \n You can log in now`),

        this.dialogRef.close(this.emailVerificationForm.value)
      },
      (error: any)=>alert(error))


}

}
    
