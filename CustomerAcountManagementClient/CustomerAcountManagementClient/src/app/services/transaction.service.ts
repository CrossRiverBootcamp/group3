import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";
import { Transaction } from '../models/transaction.model';
@Injectable({
    providedIn: 'root'
  })
  export class TransactionService {
constructor(private _httpClient:HttpClient){

}
baseUrl:string='https://localhost:7136/api/Transaction'

createTransaction(transaction:Transaction):Observable<boolean>{
return this._httpClient.post<boolean>(this.baseUrl,transaction)
}
  }