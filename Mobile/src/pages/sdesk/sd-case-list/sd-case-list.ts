import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

/**
 * Generated class for the SdCaseListPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */ 

@IonicPage({
  name: "sd-case-list"
})
@Component({
  selector: 'page-sd-case-list',
  templateUrl: 'sd-case-list.html',
})
export class SdCaseListPage {

  constructor(public navCtrl: NavController, public navParams: NavParams) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad SdCaseListPage');
  }

}
