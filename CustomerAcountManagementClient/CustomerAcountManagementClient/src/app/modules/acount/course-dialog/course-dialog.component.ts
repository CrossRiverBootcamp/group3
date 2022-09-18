import { MaterialModule } from './../../material/material/material.module';
import { Component, Inject, OnInit, Input } from '@angular/core';
import {/*MAT_DIALOG_DATA,*/ MatDialogRef} from "@angular/material/dialog";
import { FormGroup, FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-course-dialog',
  templateUrl: './course-dialog.component.html',
  styleUrls: ['./course-dialog.component.css']
})
export class CourseDialogComponent implements OnInit {

  form: FormGroup;
  @Input()
  description:string;

  constructor(
      private fb: FormBuilder,
      private dialogRef: MatDialogRef<CourseDialogComponent>){
     // @Inject(MAT_DIALOG_DATA) data:any) {

      // this.description = data.description;
  }

  ngOnInit() {
      this.form = this.fb.group({
          description: [this.description, []],
        
      });
  }

  save() {
      this.dialogRef.close(this.form.value);
  }

  close() {
      this.dialogRef.close();
  }
}


    
