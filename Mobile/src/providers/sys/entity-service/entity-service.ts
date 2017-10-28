import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';


import { SystemVariables } from '../../../app/sys/SystemVariables';
import { CustomHeader } from '../../../app/sys/customHeaders';
import { GeneralFunctions } from '../../../app/sys/generalFunctions';

/*
  Generated class for the EntityServiceProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class EntityServiceProvider {

  constructor(public http: Http) {
    console.log('Hello EntityServiceProvider Provider');
  }


  
  get(listData:ListData) {
    let headers = CustomHeader.GetJsonHeaderUser();
    let url = SystemVariables.GeneralUrl ;
    let companyId = SystemVariables.GuidCompanyId;
    if (SystemVariables.IsBrowser == true ){
      url = "/OtherShell/";
      companyId = SystemVariables.GuidCompanyIdLocal;
    }
    return this.http.post(url + SystemVariables.AppNameKey + "/Get?v=2&allFieds=1", {
        "CompanyId": companyId //SystemVariables.GuidCompanyId""
        ,"Page": listData.Page
        ,"PageSize": listData.PageSize
        ,"SortBy": listData.SortBy, "SortDirection": listData.SortDirection
      
    }, { headers: headers })
      .map(response => JSON.parse(response.text())
      );
  
  }


  update(listData:ListData) {
    let headers = CustomHeader.GetJsonHeaderUser();
    let url = SystemVariables.GeneralUrl ;
    let companyId = SystemVariables.GuidCompanyId;
    if (SystemVariables.IsBrowser == true ){
      url = "/OtherShell/";
      companyId = SystemVariables.GuidCompanyIdLocal;
    }
    return this.http.post(url + SystemVariables.AppNameKey + "/Update", {
       
    }, { headers: headers })
      .map(response => JSON.parse(response.text())
      );
  
  }


  create(listData:ListData) {
    let headers = CustomHeader.GetJsonHeaderUser();
    let url = SystemVariables.GeneralUrl ;
    let companyId = SystemVariables.GuidCompanyId;
    if (SystemVariables.IsBrowser == true ){
      url = "/OtherShell/";
      companyId = SystemVariables.GuidCompanyIdLocal;
    }
    return this.http.post(url + SystemVariables.AppNameKey + "/Get?v=2&allFieds=1", {
        "CompanyId": companyId //SystemVariables.GuidCompanyId""
        ,"Page": listData.Page
        ,"PageSize": listData.PageSize
        ,"SortBy": listData.SortBy, "SortDirection": listData.SortDirection
      
    }, { headers: headers })
      .map(response => JSON.parse(response.text())
      );
  
  }


  delete(listData:ListData) {
    let headers = CustomHeader.GetJsonHeaderUser();
    let url = SystemVariables.GeneralUrl ;
    let companyId = SystemVariables.GuidCompanyId;
    if (SystemVariables.IsBrowser == true ){
      url = "/OtherShell/";
      companyId = SystemVariables.GuidCompanyIdLocal;
    }
    return this.http.post(url + SystemVariables.AppNameKey + "/Get?v=2&allFieds=1", {
        "CompanyId": companyId //SystemVariables.GuidCompanyId""
        ,"Page": listData.Page
        ,"PageSize": listData.PageSize
        ,"SortBy": listData.SortBy, "SortDirection": listData.SortDirection
      
    }, { headers: headers })
      .map(response => JSON.parse(response.text())
      );
  
  }



}

export class ListData {
    Query: string;
    Page:number;
    PageSize:number;
    SortBy:string;
    SortDirection:string;
    EntitySet:string;
}
