import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Transaction } from 'src/app/models/transaction.model';
import { TransactionService } from 'src/app/services/transaction.service';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class TransactionComponent implements OnInit {
  addTransactionForm!: FormGroup;
  transaction!: Transaction;
  constructor(private _transactionService: TransactionService, private _customerService: CustomerService) { }

  ngOnInit(): void {
    this.addTransactionForm = new FormGroup({
      "toAcount": new FormControl("", Validators.required),
      "amount": new FormControl("", [Validators.required])
    });
  }
  addTransaction() {
    this.transaction = {
      fromAcountId: this._customerService.customer.acountId,
      toAcountId: this.addTransactionForm?.value.toAcount,
      amount: this.addTransactionForm?.value.amount
    }
    this._transactionService.createTransaction(this.transaction).subscribe((success: boolean) => {
     
    })
  }

}
