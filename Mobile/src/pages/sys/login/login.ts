import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams,ToastController, Events } from 'ionic-angular';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterPage } from '../register/register';
import { AuthServiceProvider } from '../../../providers/sys/auth-service/auth-service';
import { CustomAlert } from '../../../app/sys/customAlert';

import { Facebook } from '@ionic-native/facebook';


/**
 * Generated class for the LoginPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-login',
  templateUrl: 'login.html',
})
export class LoginPage {
  myForm: FormGroup;
  userData = { "Email": "", "Password":"" };
  responseData:any;
  constructor(public navCtrl: NavController,
    public authService:AuthServiceProvider, 
    public toast:ToastController,
    public formBuilder: FormBuilder,
    public events: Events,
    public fb:Facebook, 
    public navParams: NavParams) {
      
      this.myForm = this.createMyForm();
 
   }

   private createMyForm(){
    return this.formBuilder.group({
      Username: ['', Validators.required],
      Password: ['', Validators.required]
    });
  }


  login(){
    console.log("Form value: ");

    console.log(this.myForm.value);
    this.userData = this.myForm.value;
    this.authService.postData(this.userData, "Api/Login").then(
      (result)=> {
        this.responseData = result["data"];
        let status = result["status"];
        if (status == "error"){

          CustomAlert.showToast("error: " + result["reason"], this.toast);
       
        
        
      }else{
          this.authService.setUserData(this.responseData).then(result => {
            this.events.publish('user:loged', this.responseData, Date.now());
            this.navCtrl.setRoot(HomePage);            
          }).catch(error=> {

            CustomAlert.showToast(error, this.toast);   
          });
        }
      }, (err)=> {
        CustomAlert.showToast(err, this.toast);   
      
      }
    );
  }
  doFbLogin(){
    let permissions = new Array<string>();
    let nav = this.navCtrl;
    let env = this;
    //the permissions your facebook app needs from the user
    permissions = ["public_profile","email"];

    
  // running on device/emulator

    this.fb.login(permissions)
    .then(function(response){
      let userId = response.authResponse.userID;
      let params = new Array<string>();

      //Getting name and gender properties
      env.fb.api("/me?fields=name,gender,email", params)
      .then(function(user) {
        user.picture = "https://graph.facebook.com/" + userId + "/picture?type=large";
        localStorage.setItem("user", JSON.stringify(user));

        //now we have the users info, let's save it in the NativeStorage
        // env.nativeStorage.setItem('user',
        // {
        //   name: user.name,
        //   gender: user.gender,
        //   picture: user.picture
        // })
        // .then(function(){
        //   nav.push(UserPage);
        // }, function (error) {
        //   console.log(error);
        // })
      })
    }, function(error){
      console.log(error);
    });
  //   } else {
  // // running in dev mode
  //   }
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad LoginPage');
  }


  signup(){
    console.log("signup");
    this.navCtrl.push(RegisterPage);
  }

}
