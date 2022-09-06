import { Component, OnInit, Input } from '@angular/core';
import { CustomerAcountService } from '../customer-acount.service';
import { AcountInfo } from 'src/app/models/acountInfo.model';

@Component({
  selector: 'app-acount-info',
  templateUrl: './acount-info.component.html',
  styleUrls: ['./acount-info.component.css']
})
export class AcountInfoComponent implements OnInit {
  @Input()
  acountId!: number
  acountInfo!: AcountInfo;
  constructor(private _customerAcountService: CustomerAcountService) { }

  ngOnInit(): void {
    this._customerAcountService.getAcountInfo(this.acountId).subscribe((acount: any) => {
      this.acountInfo = acount;
      console.log(acount)
    }
    )
  }

}
