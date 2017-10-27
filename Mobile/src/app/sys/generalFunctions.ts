import { SystemVariables } from '../sys/SystemVariables';
import { NativeStorage } from '@ionic-native/native-storage';

export class GeneralFunctions {

    private static nativeStorage: NativeStorage;

    constructor() {
    }

    
    public static getDistance(lat1, lon1, lat2, lon2, unit) {
        var radlat1 = Math.PI * lat1/180
        var radlat2 = Math.PI * lat2/180
        var theta = lon1-lon2
        var radtheta = Math.PI * theta/180
        var dist = Math.sin(radlat1) * Math.sin(radlat2) + Math.cos(radlat1) * Math.cos(radlat2) * Math.cos(radtheta);
        dist = Math.acos(dist)
        dist = dist * 180/Math.PI
        dist = dist * 60 * 1.1515
        if (unit=="K") { dist = dist * 1.609344 }
        if (unit=="N") { dist = dist * 0.8684 }
        return dist
    }

    public static getTokenSystem(): any {
        if (SystemVariables.IsBrowser) {
            let token = window.localStorage.getItem(SystemVariables.TokenUserSystem);
            return token;
        }
        else {
            this.nativeStorage.getItem(SystemVariables.TokenUserSystem).then(function (token) {
                return token;
            }, function (error) {
            });
        }
    }

    public static getTokenCurrentUser(): any {
        if (SystemVariables.IsBrowser) {
            let token = window.localStorage.getItem(SystemVariables.TokenCurrentUser);
            return token;
        }
        else {
            this.nativeStorage.getItem(SystemVariables.TokenCurrentUser).then(function (token) {
                return token;
            }, function (error) {
            });
        }
    }

    public static setTokenCurrentUser(tokenValue: string): any {
        if (SystemVariables.IsBrowser) {
            let token = window.localStorage.setItem(SystemVariables.TokenCurrentUser, tokenValue);
            return token;
        }
        else {
            this.nativeStorage.setItem(SystemVariables.TokenCurrentUser, tokenValue).then(function (token) {

            }, function (error) {

            });
        }
    }

    public static setKeyCurrentUser(keyCurrentUser: string): any {
        if (SystemVariables.IsBrowser) {
            let token = window.localStorage.setItem(SystemVariables.KeyCurrentUser, keyCurrentUser);
            return token;
        }
        else {
            this.nativeStorage.setItem(SystemVariables.KeyCurrentUser, keyCurrentUser).then(function (token) {
            }, function (error) {

            });
        }
    }

    public static getKeyCurrentUser(): any {
        if (SystemVariables.IsBrowser) {
            let token = window.localStorage.getItem(SystemVariables.KeyCurrentUser);
            return token;
        }
        else {
            this.nativeStorage.getItem(SystemVariables.KeyCurrentUser).then(function (key) {
                return key;
            }, function (error) {
            });
        }
    }

    public static setEmailCurrentUser(EmailUser: string): any {
        if (SystemVariables.IsBrowser) {
            window.localStorage.setItem(SystemVariables.EmailCurrentUser, EmailUser);
        }
        else {

            this.nativeStorage.setItem(SystemVariables.EmailCurrentUser, EmailUser).then(function (token) {
            }, function (error) {

            });

        }
    }

    public static getEmailCurrentUser(): any {
        if (SystemVariables.IsBrowser) {
            let email = window.localStorage.getItem(SystemVariables.EmailCurrentUser);
            return email;
        }
        else {

            this.nativeStorage.getItem(SystemVariables.EmailCurrentUser).then(function (email) {
                return email;
            }, function (error) {
            });

        }
    }
}