import {Injectable} from '@angular/core';
import { Platform } from 'ionic-angular';

@Injectable()
export class Utils {
  
  _isBrowser: boolean;
  constructor(public platform: Platform) {
    if (this.platform.is('mobileweb') || this.platform.is('core')) {
      // This will only print when running on desktop
      this._isBrowser = true ;
    }
  }

    

  isBrowser() {
    return this._isBrowser;
  }

}