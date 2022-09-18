import { LoginDTO } from '../models/loginDTO.model';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";
import { Router } from '@angular/router';
import { Operation } from '../models/operation.model';
import { ThirdPartyDetails } from '../models/thirdPartyDetails.model';
import { RegisterDTO } from '../models/registerDTO.model';
import { CustomerTokenDTO } from '../models/customerTokenDTO.moderl';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  
 
  constructor(private _http: HttpClient, private router: Router) { }

  baseCustomerUrl: string = "https://localhost:7251/api/Customer/";
  baseAcountUrl:string='https://localhost:7251/api/Acount/';
  baseOperationUrl:string='https://localhost:7251/api/Operation/';
customer:CustomerTokenDTO
  async logIn(LogIn: LoginDTO){
      this._http.post<CustomerTokenDTO>(this.baseCustomerUrl + "LogIn", LogIn)
      .subscribe((customerToken: CustomerTokenDTO) =>{
        this.customer= customerToken
        this.router.navigate(['acount/acountInfo']);
      } ,
      ()=>{
      alert("The email or password you inserted is not correct, maybe you have to sign up?")
      })
     
  }
  register(customer: RegisterDTO): Observable<boolean> {
    return this._http.post<boolean>(`${this.baseCustomerUrl}Register`, customer);
  }
  validateEmail(email:string){
   return this._http.get(`${this.baseCustomerUrl}${email}`)
  }
  getAcountInfo():Observable<any> {
     return this._http.get(`${this.baseAcountUrl}AcountInfo/ ${this.customer.acountId}`, {
      headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${this.customer.token}`
      }})
  }
  getOperationsHistory(pageNumber:number,numberOfRecords:number):Observable<Operation[]>{
    return this._http.get<Operation[]>(`${this.baseOperationUrl}${this.customer?.acountId}/${pageNumber}/${numberOfRecords}`, {
      headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${this.customer.token}`
      }})
  }
  getCustomerByAcountId(acountId:number):Observable<ThirdPartyDetails>{
   return this._http.get<ThirdPartyDetails>(`${this.baseAcountUrl}Customer/${acountId}`, {
    headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.customer.token}`
    }})
  }
  getOperationsNumber():Observable<number>{
    return this._http.get<number>(`${this.baseOperationUrl}${1}`, {
      headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${this.customer.token}`
      }})
  }

}
