import { MatDialogRef } from '@angular/material/dialog';
import { ThirdPartyDetails } from 'src/app/models/thirdPartyDetails.model';
import { Input, Component } from '@angular/core';

@Component({
  selector: 'dialog-animations-example-dialog',
  templateUrl: './dialog-animations-example-dialog.html',
})
export class ThirdPartyDetailsDialog {
  @Input()
  data: ThirdPartyDetails;
  constructor(public dialogRef: MatDialogRef<ThirdPartyDetailsDialog>) {}
}