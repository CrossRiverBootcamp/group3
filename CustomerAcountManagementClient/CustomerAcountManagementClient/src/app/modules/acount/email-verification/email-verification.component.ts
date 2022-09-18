import { AcountModule } from './../acount.module';
import { Component, OnInit } from '@angular/core';
import {FormControl} from '@angular/forms';
import {MatDialog, MatDialogConfig} from "@angular/material/dialog";
import {CourseDialogComponent} from "../course-dialog/course-dialog.component"


@Component({
  selector: 'app-email-verification',
  templateUrl: './email-verification.component.html',
  styleUrls: ['./email-verification.component.css']
})

export class EmailVerificationComponent  {
  

  constructor(private dialog: MatDialog) {}

  openDialog() {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    dialogConfig.data = {
        id: 1,
        title: 'Angular For Beginners'
    };

    
    const dialogRef = this.dialog.open(CourseDialogComponent, dialogConfig);
    dialogRef.componentInstance.description="aaa";

    dialogRef.afterClosed().subscribe(
      (data: any) => console.log("Dialog output:", data)
    );    
}

}
