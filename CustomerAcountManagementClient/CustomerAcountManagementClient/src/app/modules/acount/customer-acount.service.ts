import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class CustomerAcountService {
    constructor(private _http: HttpClient) { }
    // baseUrl:string='https://localhost:7251/api/Acount/';
    // getAcountInfo(/*acountId: number*/):Observable<any> {
    //    return this._http.get(`${this.baseUrl}AcountInfo/ ${this.acountId}`)
    // }
}