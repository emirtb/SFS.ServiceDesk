import { AlertController, ToastController } from 'ionic-angular';

export class CustomAlert {
    /**
     *
     */
     constructor(public toastCtrl:ToastController) {
        

    }

    public static sendOkNotification( message: string, ctrl:AlertController, title:string = 'Talenti'): void {
        let alert = ctrl.create({
            title: title,
            subTitle: message,
            buttons: ['OK']

        });
        alert.present();
    }

    public static showToast( message: string, toastCtrl:ToastController): void {
       //let ctrl: ToastController =  new ToastController();
        let toast = toastCtrl.create({
            message: message,
            duration: 3000
          });
          toast.present();
    }

}