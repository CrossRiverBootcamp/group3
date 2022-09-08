import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent {

  constructor(private _router: Router,public _customerService:CustomerService) {

  }
  navigateToLogin() {
    this._router.navigate(['acount/login']);
  }
   navigateToRegister() {
    this._router.navigate(['acount/register']);

  }
  navigateToAddTransaction(){
    this._router.navigate(['transaction']);
  }

}
