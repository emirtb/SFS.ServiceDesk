import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { Storage } from '@ionic/storage';

import { AuthServiceProvider } from '../../../providers/sys/auth-service/auth-service';
import { ToastController } from 'ionic-angular';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { SystemVariables } from '../../../app/sys/SystemVariables';
import { GeneralFunctions } from '../../../app/sys/generalFunctions';
import { HomePage } from '../../../pages/home/home'
import { UserDataModel } from '../../../app/sys/userData';

/**
 * Generated class for the RegisterPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-register',
  templateUrl: 'register.html',
})
export class RegisterPage {
  myForm: FormGroup;
  responseData : any;
  userData: UserDataModel ;
  constructor(public navCtrl: NavController,
   public autService: AuthServiceProvider,
    public toastCrl:ToastController,
    public formBuilder:FormBuilder,

    public storage: Storage
    ) {
      this.myForm = this.createMyForm();
  }
  private createMyForm(){
  return this.formBuilder.group({
    Email: ['', Validators.required],
    Password: ['', Validators.required],
    FullName: ['', Validators.required],
    
    
  });
}

signup(){
  console.log(this.myForm.value);
  this.userData = this.myForm.value;
  this.userData.AppKey = SystemVariables.AppNameKey;
  //this.navCtrl.push(HomePage);
  this.autService.postData(this.userData, "Api/Register").then(
    (result)=> {
      this.responseData = result["data"];
      let status = result["status"];
      if (status == "error" && result["reason"] == "email-not-available"){
        
         let toast = this.toastCrl.create({
        message: "Este correo ya ha sido utilizado previamente",
        duration: 3000
      });
      toast.present();
    }else{
      this.userData = this.responseData;
      console.log(this.userData);
        

        this.storage.set("userData", this.userData).then(result=>{
          console.log("se guardaron los datos");
          console.log(result);
          SystemVariables.CurrentUser = this.userData;
        }).catch(error=> {
          console.log(error);
          

        });
       
        
        this.navCtrl.setRoot(HomePage);

      }
    }, (err)=> {
       
      let toast = this.toastCrl.create({
        message: "error: " + err,
        duration: 3000
        });
      toast.present();
    }
  );
}

  ionViewDidLoad() {
    console.log('ionViewDidLoad RegisterPage');
  }

  public setUserData(userData){
     
    localStorage.setItem("userData", JSON.stringify(userData));
  }

}
