using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFS.ServiceDesk.Client.Models;
using System.Collections.Generic;

namespace SFS.ServiceDesk.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RegisterUserOnlyFullName()
        { 


            string urlApp = System.Configuration.ConfigurationManager.AppSettings["urlApp"];
            string IdCompany = System.Configuration.ConfigurationManager.AppSettings["companyId"];
            string appKey = "SFSServiceDesk"; // ID de aplicación
            //string entitySetName = "bonCustomers";
            //UserDataRegister data = new SFS.ServiceDesk.Client.Models.UserDataRegister();
            #region Register user with App
            //data = new SFS.ServiceDesk.Client.Models.UserDataRegister();
            //data.Email = Utils.GetString(10) + "@mail.com";
            //data.Password = Utils.GetString(10);
            //data.FirstName = "Name" + Utils.GetString(6);
            //data.FirstName = "Last" + Utils.GetString(6);
            //data.AppKey = appKey; // tiene autoservicio, relacionado con una empresa + dominio
            //var registerResultWithApp = Services.CallApi(urlApp + "/Api/Register", "POST", data);

            //Result<UserDataResponse> resultRegisterWithApp = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<UserDataResponse>>(registerResultWithApp);
            //Assert.AreEqual(resultRegisterWithApp.status, "success");
            //Assert.IsNotNull(resultRegisterWithApp.data.IdCompany);

            #endregion

            #region Login
            UserDataLogin dataLogin = new SFS.ServiceDesk.Client.Models.UserDataLogin();
            dataLogin = new SFS.ServiceDesk.Client.Models.UserDataLogin();
            dataLogin.Username = System.Configuration.ConfigurationManager.AppSettings["username"];
            dataLogin.Password = System.Configuration.ConfigurationManager.AppSettings["password"];
            var loginResult = Services.CallApi(urlApp + "/Api/Login", "POST", dataLogin);

            Result<UserDataWithToken>  resultLogin = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<UserDataWithToken>>(loginResult);
            Assert.AreEqual(resultLogin.status, "success");
            Assert.IsNotNull(resultLogin.data.Token);
            #endregion

            #region Get Items of ProfileEvents

            // Se espera que ocurra un error de token inválido porque la contraseña ha sido cambiada

            ApiWrapper dataRequest = new ApiWrapper();

            var dataRequestTyped = new ApiWrapper<SDArea>();
            //dataRequestTyped.Item = new Client.Models.PageType() { ProfileType = 0, Name = Utils.GetString(10) };
            
            dataRequestTyped.Token = resultLogin.data.Token;
            dataRequestTyped.CompanyId = IdCompany;
            var result = Services.CallApi(urlApp + "/" + appKey + "/SDCases/Get?v=2&Fields=SDCaseHistories", "POST", (object)dataRequestTyped);
            string test = result;

            // var resultGetItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProfileEvent>>(getItems);

            // Assert.AreEqual(resultGetItems.status, "success");



            #endregion



        }
    }
}
