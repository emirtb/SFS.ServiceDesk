import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { HttpModule } from '@angular/http';
import { IonicStorageModule } from '@ionic/storage';

import { Facebook } from '@ionic-native/facebook';

import { MyApp } from './app.component';

import { LoginPage } from '../pages/sys/login/login';
import { HomePage } from '../pages/home/home';
import { RegisterPage } from '../pages/sys/register/register';



import { Geolocation ,GeolocationOptions ,Geoposition ,PositionError } from '@ionic-native/geolocation'; 
import { GoogleMaps } from '@ionic-native/google-maps';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { AdMobFree } from '@ionic-native/admob-free';
// providers

import { ChartsModule } from 'ng2-charts';

import { AuthServiceProvider } from '../providers/sys/auth-service/auth-service';


declare var window;

export class MyErrorHandler implements ErrorHandler {
  handleError(err: any): void {

    //window.Ionic.handleNewError(err);
  }
}


@NgModule({
  declarations: [
    MyApp,
    HomePage,
    LoginPage,
    RegisterPage
   
  ],
  imports: [
    BrowserModule, HttpModule,ChartsModule,
    IonicModule.forRoot(MyApp, {
     // tabsHideOnSubPages: false

    }),
    IonicStorageModule.forRoot()
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    
    RegisterPage,
    LoginPage

  ],
  providers: [
    StatusBar,
    AdMobFree,
    SplashScreen,
    Geolocation,
    GoogleMaps,
    {provide: ErrorHandler, useClass: IonicErrorHandler},
    {provide: ErrorHandler, useClass: MyErrorHandler},
    Facebook,

    AuthServiceProvider,
    
  ]
})
export class AppModule {}
