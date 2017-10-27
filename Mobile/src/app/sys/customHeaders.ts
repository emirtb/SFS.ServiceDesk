import { Headers } from '@angular/http';
import { SystemVariables } from '../sys/SystemVariables';
import { GeneralFunctions } from '../sys/generalFunctions';
export class CustomHeader {

    public static GetJsonHeaderSystem(): Headers {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let token = GeneralFunctions.getTokenSystem();
        if (token != null) {
            headers.append(SystemVariables.TokenRequestName, token);
            if (SystemVariables.IsDebug)
                console.log(SystemVariables.TokenRequestName + " : " + token);

        }
        return headers;
    }

    public static GetJsonHeader(): Headers {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return headers;
    }

    public static GetJsonHeaderUser(): Headers {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');

        let token = SystemVariables.SystemUserToken; //GeneralFunctions.getTokenCurrentUser();
        if (SystemVariables.IsBrowser){
            token = SystemVariables.SystemUserTokenLocal;
        }
        if (token != null) {
            headers.append(SystemVariables.TokenRequestName, token);
           
        }
        return headers;
    }

}