import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";
import { Transaction } from '../models/transaction.model';
import { CustomerService } from './customer.service';
@Injectable({
    providedIn: 'root'
  })
  export class TransactionService {
constructor(private _httpClient:HttpClient,private _customerService:CustomerService){

}
baseUrl:string='https://localhost:7136/api/Transaction'

createTransaction(transaction:Transaction):Observable<boolean>{
return this._httpClient.post<boolean>(this.baseUrl,transaction ,{
  headers: {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this._customerService.customer.token}`
  }
})}
  }