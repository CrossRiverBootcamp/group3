import { Component, OnInit, ViewChild, AfterViewInit, Inject, Input } from '@angular/core';
import { Operation } from 'src/app/models/operation.model';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FloatLabelType } from '@angular/material/form-field';
import { CustomerService } from 'src/app/services/customer.service';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { ThirdPartyDetails } from 'src/app/models/thirdPartyDetails.model';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { ThirdPartyDetailsDialog } from './ThirdPartyDetailsDialog';

@Component({
  selector: 'app-operations-history',
  templateUrl: './operations-history.component.html',
  styleUrls: ['./operations-history.component.css']
})
export class OperationsHistoryComponent implements AfterViewInit, OnInit {
  operations: Operation[] = []
  isLoading = false;
  totalRows = 0;
  pageSize = 5;
  currentPage = 0;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  displayedColumns: string[] = ['debit', 'thirdParty', 'amount', 'balance', 'date'];
  thirdPartyDetails:ThirdPartyDetails;

  @ViewChild(MatTable) table: MatTable<any>;
  dataSource = new MatTableDataSource<Operation>(this.operations);
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  

  constructor(private _customerService: CustomerService, private _dialog:MatDialog) { }
  ngOnInit() {
  
     this.loadData();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
  loadData() {      
    this.isLoading = true;
    this._customerService.getOperationsHistory(this.currentPage,this.pageSize).subscribe((data: Operation[]) => {
      this.operations = data;
      this.dataSource = new MatTableDataSource(this.operations);
      this.paginator.pageIndex = this.currentPage;
      this.isLoading = false;
      this._customerService.getOperationsNumber()
      .subscribe((data:number)=>{
        this.totalRows=data
       
      })
    }, (error: any) => {
      console.log(error);
      this.isLoading = false;
    });
  }

pageChanged(event: PageEvent) {
  console.log({ event });
  this.pageSize = event.pageSize;
  this.currentPage = event.pageIndex;
  this.loadData();
}
showCustomerDetails(acountId:number){
this._customerService.getCustomerByAcountId(acountId)
.subscribe((data:ThirdPartyDetails)=>{
this.thirdPartyDetails=data;
  this.openDialog()
}
,
(error:any)=>
console.log(error)
)
}
openDialog(): void {
 const dialogRef=this._dialog.open(ThirdPartyDetailsDialog);
 dialogRef.componentInstance.data=this.thirdPartyDetails;
 }
}


