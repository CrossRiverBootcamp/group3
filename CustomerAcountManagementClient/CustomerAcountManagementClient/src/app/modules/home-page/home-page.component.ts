import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(private _router: Router) {

  }
  navigateToLogin() {
    this._router.navigate(['acount/login']);
  }
   navigateToRegister() {
    this._router.navigate(['acount/register']);

  }
  ngOnInit(): void {
  }

}
