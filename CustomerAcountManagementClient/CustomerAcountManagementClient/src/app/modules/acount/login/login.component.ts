import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CustomerService } from 'src/app/services/customer.service';
import { LoginDTO } from 'src/app/models/loginDTO.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  hide: boolean = false;
  customer!: LoginDTO;
  constructor(private _customerService: CustomerService) { }
  ngOnInit(): void {
    this.loginForm = new FormGroup({
      "email": new FormControl("", Validators.required),
      "password": new FormControl("", [Validators.required, Validators.minLength(8)])
    });

  }
  public togglePasswordVisibility(): void {
    this.hide = !this.hide;
  }
  async logIn() {
    try {
      this.customer = {
        email: this.loginForm?.value.email,
        customerPassword: this.loginForm?.value.password
      }
      await this._customerService.logIn(this.customer).catch()
    }
    catch{
      alert("The email or password you inserted is not correct, maybe you have to sign up?")
    }
  }
}  