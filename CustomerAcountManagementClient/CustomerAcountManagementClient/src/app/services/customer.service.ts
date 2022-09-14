import { LoginDTO } from '../models/loginDTO.model';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";
import { Customer } from '../models/customer.moder';
import { Router } from '@angular/router';
import { Operation } from '../models/operation.model';
import { ThirdPartyDetails } from '../models/thirdPartyDetails.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  acountId!: number;
  constructor(private _http: HttpClient, private router: Router) { }

  baseCustomerUrl: string = "https://localhost:7251/api/Customer/";
  baseAcountUrl:string='https://localhost:7251/api/Acount/';
  baseOperationUrl:string='https://localhost:7251/api/Operation/';

  async logIn(LogIn: LoginDTO){
    this._http.post<number>(this.baseCustomerUrl + "LogIn", LogIn)
      .subscribe((acountId: number) =>{
        this.acountId = acountId
        this.router.navigate(['acount/acountInfo']);
      } ,
      ()=>{
      alert("The email or password you inserted is not correct, maybe you have to sign up?")
      })
     
  }
  register(customer: Customer): Observable<boolean> {
    return this._http.post<boolean>(`${this.baseCustomerUrl}Register`, customer);
  }
  getAcountInfo():Observable<any> {
     return this._http.get(`${this.baseAcountUrl}AcountInfo/ ${this.acountId}`)
  }
  getOperationsHistory(pageNumber:number,numberOfRecords:number):Observable<Operation[]>{
    return this._http.get<Operation[]>(`${this.baseOperationUrl}${this.acountId}/${pageNumber}/${numberOfRecords}`)
  }
  getCustomerByAcountId(acountId:number):Observable<ThirdPartyDetails>{
   return this._http.get<ThirdPartyDetails>(`${this.baseAcountUrl}Customer/${acountId}`)
  }
  getOperationsNumber():Observable<number>{
    return this._http.get<number>(`${this.baseOperationUrl}${1}`)
  }

}
