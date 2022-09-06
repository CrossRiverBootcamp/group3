import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class CustomerAcountService {
    constructor(private _http: HttpClient) { }
    getAcountInfo(acountId: number):Observable<any> {
       return this._http.get(`https://localhost:7251/api/Acount/AcountInfo/ ${acountId}`)
    }
}