import { Component } from '@angular/core';

/**
 * Generated class for the BaseListComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'base-list',
  templateUrl: 'base-list.html'
})
export class BaseListComponent {

  text: string;

  constructor() {
    console.log('Hello BaseListComponent Component');
    this.text = 'Hello World';
  }

}

export class BaseListModel {
  
    constructor() {
     
      
    }
  
  }

  