import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';

export class PageBase {
    
    constructor(public navCtrl: NavController, public navParams: NavParams) {
      
    }
    
      ionViewDidLoad() {
        console.log('ionViewDidLoad HomePage');
      }
    
}