import { Geolocation ,GeolocationOptions ,Geoposition ,PositionError } from '@ionic-native/geolocation'; 
import {
    
    LatLng
   } from '@ionic-native/google-maps';
import { UserDataModel } from '../sys/userData'; 

export class SystemVariables {

    public static GuidCompanyId: string = "55f07343-fab1-4ba1-8461-3b31dd5680b5";
    public static GuidCompanyIdLocal: string = "16ac3d70-1e20-4131-8330-22916a880d2f";
    public static AppNameKey:string = "TCIBestEx";

    public static SystemUser: string = "superadmin";
    public static SystemUserPassword: string = "pass.word1313";
    public static SystemUserTokenLocal: string = "f384648b1fc649128594cf4b90fc85eb9d04edb199c748b183a4d8758111160b";
    public static SystemUserToken: string = "b7c02db54e2d4bdeb6aa8b4879c791e7d3f098961b9a42728dc80984185a9f87";
    

    //public static GeneralUrl: string = "/OtherShell/";
    public static GeneralUrl: string = "http://bestex-test.azurewebsites.net/";     
   
    public static IsBrowser: boolean = false;

    public static IsAndroid: boolean = false;
    public static IsIOS: boolean = false;
    public static IsNative: boolean = false;
    
    public static TokenUserSystem: string = "TokenUserSystem";
    public static TokenRequestName: string = "Token";
    public static TokenCurrentUser: string = "TokenCurrentUser";
    public static KeyCurrentUser: string = "KeyCurrentUser";
    public static EmailCurrentUser: string = "EmailCurrentUser";
    public static CurrentPosition: LatLng = null ;

    public static IsDebug: boolean = true;
    public static OkResult: string = "success";
    public static ErrorResult: string = "error";
    public static failResult: string = "fail";
    public static NoImageUser: string = "./assets/images/no-user.png";
    public static imgPlayYoutube: string = "./assets/images/btnPlayYoutube.png";
    public static imgNoContent: string = "./assets/images/NoContent.png";
    //public static IsBrowser: boolean = true;
    public static StringEmpty: string = "";
    public static JsonStringEmpty: string = '""';
    public static Visible: string = "visible";
    public static Hidden: string = "hidden";
    public static ItemsForBriefcase: number = 5;

    public static GoogleApiKey: string = "AIzaSyBOVil9N5XHMyCyvkbE4vkY1Z9bSC2Ki7E";
    public static GoogleApiUrl: string = "https://www.googleapis.com/youtube/v3/videos?part=id&id=_ID_&key=_KEY_"
    public static GoogleApiReplaceId: string = "_ID_"
    public static GoogleApiReplaceKey: string = "_KEY_"

    public static CurrentUser : UserDataModel;

    public static regex = {
        email: /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
        emptyText: /^\s*$/,
        someText: /(?!^ +$)^.+$/,
        allowedText: /[a-zA-ZÀ-ú0-9 \.\'\-]*/,
        decimalNumber: /^(\d*)(\.\d{1,2})?$/
    }

} 