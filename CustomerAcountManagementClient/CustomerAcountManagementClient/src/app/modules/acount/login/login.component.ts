import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { customerService } from 'src/app/services/customer.service';
import { LoginDTO } from 'src/app/models/loginDTO.model';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  hide: boolean = false;
  customer!: LoginDTO;
  constructor(private _customerService: customerService, private router: Router) { }
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

    this.customer={email:this.loginForm?.value.email,
      password:this.loginForm?.value.password
    }
    this._customerService.logIn(this.customer).subscribe(acountId => {

      //this.router.navigate(['acountInfo']);
    });;


  }
}