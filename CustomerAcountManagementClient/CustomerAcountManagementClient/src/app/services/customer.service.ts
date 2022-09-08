import { LoginDTO } from '../models/loginDTO.model';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";
import { Customer } from '../models/customer.moder';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  acountId!: number;
  constructor(private _http: HttpClient, private router: Router) { }

  baseCustomerUrl: string = "https://localhost:7251/api/Customer/";
  baseAcountUrl:string='https://localhost:7251/api/Acount/';

  async logIn(LogIn: LoginDTO){
    this._http.post<number>(this.baseCustomerUrl + "LogIn", LogIn)
      .subscribe((acountId: number) =>{
        this.acountId = acountId
        this.router.navigate(['acount/acountInfo']);
      } )
     
  }
  register(customer: Customer): Observable<boolean> {
    return this._http.post<boolean>(`${this.baseCustomerUrl}Register`, customer);
  }
  getAcountInfo():Observable<any> {
     return this._http.get(`${this.baseAcountUrl}AcountInfo/ ${this.acountId}`)
  }

}
