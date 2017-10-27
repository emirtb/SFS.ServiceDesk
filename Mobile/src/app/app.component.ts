import { Component, ViewChild } from '@angular/core';
import { Nav, Platform, Events } from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { SystemVariables } from '../app/sys/SystemVariables';
import { Storage } from '@ionic/storage';


import { LoginPage } from '../pages/sys/login/login';
import { HomePage } from '../pages/home/home';






@Component({
  templateUrl: 'app.html'
})
export class MyApp {
  @ViewChild(Nav) nav: Nav;
  public IsBrowser:boolean;
  rootPage: any = null ;
  currentUser:any;
  pages: Array<{title: string, component: any}>;

  constructor(public events: Events, public platform: Platform, public storage: Storage, public statusBar: StatusBar, public splashScreen: SplashScreen) {
    this.rootPage = HomePage;
    this.initializeApp();
    if (this.platform.is('mobileweb') || this.platform.is('core')) {
      // This will only print when running on desktop
      SystemVariables.IsBrowser = true ;

    }else{
      SystemVariables.IsNative = true ;
    }
    events.subscribe('user:loged', (user) => {
      this.currentUser = user;
      // user and time are the same arguments passed in `events.publish(user, time)`
      console.log('Loged ', user);
    });

    events.subscribe('user:logoff', (user) => {
      this.currentUser = null ;
      // user and time are the same arguments passed in `events.publish(user, time)`
      console.log('Logoff  ');
    });


    this.IsBrowser = SystemVariables.IsBrowser;

    // used for an example of ngFor and navigation
    this.pages = [
      { title: 'Home', component: HomePage }
    ];

  }

  initializeApp() {
    this.platform.ready().then(() => {
      if (this.platform.is('mobileweb') || this.platform.is('core')) {
        // This will only print when running on desktop
        SystemVariables.IsBrowser = true ;
  
      }else{
        SystemVariables.IsNative = true ;
      }
      //setTimeout(function() {
        this.statusBar.styleDefault();
        this.splashScreen.hide();

       this.storage.get("userData").then(result=> {
         console.log("si existe");
        SystemVariables.CurrentUser =  result;
        this.currentUser = result;
       }).catch(error=> {
          if (SystemVariables.IsDebug)
            console.error(error)
       });

        /* if (userDataFinded == null ){
          this.rootPage = WelcomePage;
        }else{
          this.rootPage = HomePage;
        } */
     // }, 5000);
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
     
    });
  }
  goLogin(){
    this.nav.push(LoginPage);
  }
  goLogOff(){
    this.storage.remove("userData").then(result=> {
      console.log("eliminado");
     SystemVariables.CurrentUser =  null;
     this.currentUser = null;
    }).catch(error=> {
       if (SystemVariables.IsDebug)
         console.error(error)
    });

  }
  openPage(page) {
    // Reset the content nav to have just this page
    // we wouldn't want the back button to show in this scenario
    this.nav.setRoot(page.component);
  }
}
