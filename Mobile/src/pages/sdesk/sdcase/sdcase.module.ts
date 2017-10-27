import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { SdcasePage } from './sdcase';

@NgModule({
  declarations: [
    SdcasePage,
  ],
  imports: [
    IonicPageModule.forChild(SdcasePage),
  ],
})
export class SdcasePageModule {}
