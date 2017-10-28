import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { SdCaseListPage } from './sd-case-list';
import { BaseListComponent } from '../../../components/base-list/base-list'

@NgModule({
  declarations: [
    SdCaseListPage,
    BaseListComponent
  ],
  imports: [
    IonicPageModule.forChild(SdCaseListPage),
  ],
})
export class SdCaseListPageModule {}
