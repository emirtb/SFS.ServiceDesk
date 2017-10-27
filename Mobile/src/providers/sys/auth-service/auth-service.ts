import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Storage } from '@ionic/storage';

import { SystemVariables } from '../../../app/sys/SystemVariables';
import { CustomHeader } from '../../../app/sys/customHeaders';
import { GeneralFunctions } from '../../../app/sys/generalFunctions';

import { UserDataModel } from '../../../app/sys/userData'



/*
  Generated class for the AuthServiceProvider provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular DI.
*/
/* 
export class User {
  public fullName: string;
  firstName:string;
  lastName:string;
  email: string;
  idUser:string;
  idCompany:string;
  idApp: string;
  token:string;
  constructor(
    fullName: string, 
    firstName:string, lastName:string,
     email: string, 
    idUser:string,
     idCompany:string, 
    idApp:string, 
    token:string
    
  ) {
    this.fullName = fullName;
    this.firstName = firstName;
    this.lastName = lastName;
    this.email = email;
    this.idApp = idApp;
    this.idUser = idUser;
    this.idCompany = idCompany;
    this.token = token;
    
  }
} */

@Injectable()
export class AuthServiceProvider {

  constructor(public http: Http,public storage: Storage) {
    this.http = http;
    console.log('Hello AuthServiceProvider Provider');
  }

  postData(userData, type){
      return new Promise((resolve, reject) =>{
        let headers = CustomHeader.GetJsonHeaderUser();
        let url = SystemVariables.GeneralUrl ;
        let companyId = SystemVariables.GuidCompanyId;
        if (SystemVariables.IsBrowser == true ){
          url = "/OtherShell/";
          companyId = SystemVariables.GuidCompanyIdLocal;
        }
      this.http.post(url+"/"+type, JSON.stringify(userData), { headers: headers }).
      subscribe(res =>{
        resolve(res.json());
      }, (err) =>{
        reject(err);
      });

    });

  }

  public login(userData) {
    this.postData(userData, "Login");

    
  }
  public setUserData(userData){
    return this.storage.set("userData", userData);
    //localStorage.setItem("userData", JSON.stringify(userData));
  }

  public getUserdata() : Promise<UserDataModel>   {
    return new Promise((resolve, reject)=> {
    //let dataObj =  localStorage.getItem("userData");
      this.storage.get("userData").then((result)=> {
          resolve(result);
      }).catch(error=> {
          reject(error);

      });
    });
   /*  if (dataObj != null ){
      var data = JSON.parse(dataObj);
      console.log(data);
      if (data.FullName == null ){
        data.FullName = data.FirstName;
      }
     // return new User(data.FullName, data.FirstName,data.LastName, data.Email, data.IdUser, data.IdCompany, data.IdApp, data.Token);
    }else{
      return null;
    } */
  }
}
