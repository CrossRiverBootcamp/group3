import { Component, OnInit, Input } from '@angular/core';
import { AcountInfo } from 'src/app/models/acountInfo.model';
import { Router, ActivatedRoute } from '@angular/router';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-acount-info',
  templateUrl: './acount-info.component.html',
  styleUrls: ['./acount-info.component.css']
})
export class AcountInfoComponent implements OnInit {
  acountInfo!: AcountInfo;
  constructor(private _customerService: CustomerService,private router:Router,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this._customerService.getAcountInfo().subscribe((acount: any) => {
      this.acountInfo = acount;
      console.log(acount)
    } )
  }

}
