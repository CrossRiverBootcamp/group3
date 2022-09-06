import { LoginDTO } from '../models/loginDTO.model';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
  })
  export class customerService {
  
    constructor(private _http: HttpClient) { }
  
    baseUrl:string = "/api/Customer/";
    logIn(LogIn:LoginDTO):Observable<number>{
       return this._http.post<number>(this.baseUrl+"LogIn",LogIn)
    }
    
  }
