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
            string appKey = "SFSServiceDesk"; // ID de aplicación
            //string entitySetName = "bonCustomers";
            UserDataRegister data = new SFS.ServiceDesk.Client.Models.UserDataRegister();
            #region Register user with App
            data = new SFS.ServiceDesk.Client.Models.UserDataRegister();
            data.Email = Utils.GetString(10) + "@mail.com";
            data.Password = Utils.GetString(10);
            data.FirstName = "Name" + Utils.GetString(6);
            data.FirstName = "Last" + Utils.GetString(6);
            data.AppKey = appKey; // tiene autoservicio, relacionado con una empresa + dominio
            var registerResultWithApp = Services.CallApi(urlApp + "/Api/Register", "POST", data);

            Result<UserDataResponse> resultRegisterWithApp = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<UserDataResponse>>(registerResultWithApp);
            Assert.AreEqual(resultRegisterWithApp.status, "success");
            Assert.IsNotNull(resultRegisterWithApp.data.IdCompany);

            #endregion

            #region Login
            UserDataLogin dataLogin = new SFS.ServiceDesk.Client.Models.UserDataLogin();
            dataLogin = new SFS.ServiceDesk.Client.Models.UserDataLogin();
            dataLogin.Username = data.Email;
            dataLogin.Password = data.Password;
            var loginResult = Services.CallApi(urlApp + "/Api/Login", "POST", dataLogin);

            Result<UserDataWithToken>  resultLogin = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<UserDataWithToken>>(loginResult);
            Assert.AreEqual(resultLogin.status, "success");
            Assert.IsNotNull(resultLogin.data.Token);
            #endregion

            #region Get Items of ProfileEvents

            // Se espera que ocurra un error de token inválido porque la contraseña ha sido cambiada

            ApiWrapper dataRequest = new ApiWrapper();

            //var dataRequestTyped = new ApiWrapper<PageType>();
            //dataRequestTyped.Item = new Client.Models.PageType() { ProfileType = 0, Name = Utils.GetString(10) };
            
            dataRequestTyped.Token = resultLogin.data.Token;
            dataRequestTyped.CompanyId = resultRegisterWithApp.data.IdCompany;
            var result = Services.CallApi(urlApp + "/" + appKey + "/SdCase/Create?rok=1", "POST", (object)dataRequestTyped);
            Assert.AreEqual("ok", result);

            dataRequestTyped = new ApiWrapper<PageType>();
            dataRequestTyped.Item = new Client.Models.PageType() { ProfileType = 0, Name = Utils.GetString(10) };
            //dataRequestTyped.Items = new List<ProfileEvent>();

            //dataRequestTyped.Items.Add(new ProfileEvent() { EventDate = DateTime.Now, Description = Utils.GetString(10),  GuidProject = Guid.Empty,  GuidProfile = Guid.Parse(resultRegisterWithApp.data.IdUser) });
            //dataRequestTyped.Items.Add(new ProfileEvent() { EventDate = DateTime.Now, Description = Utils.GetString(10), GuidProject = Guid.Empty, GuidProfile = Guid.Parse(resultRegisterWithApp.data.IdUser) });
            //// dataRequest.QueryFilter = "it.UserProfile.GuidUser ";
            dataRequestTyped.Token = resultLogin.data.Token;
            dataRequestTyped.CompanyId = resultRegisterWithApp.data.IdCompany;
            result = Services.CallApi(urlApp + "/" + appKey + "/SdCase/Create?v=2", "POST", (object)dataRequestTyped);
            Result<PageType> pageTypeWrapper =  Newtonsoft.Json.JsonConvert.DeserializeObject<Result<PageType>>(result);

            Assert.AreEqual(pageTypeWrapper.status, "success");


            // var resultGetItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProfileEvent>>(getItems);

            // Assert.AreEqual(resultGetItems.status, "success");

            dataRequest = new ApiWrapper();
            dataRequest.QueryFilter = "";
            dataRequest.Token = resultLogin.data.Token;
            dataRequest.CompanyId = resultRegisterWithApp.data.IdCompany;
            var getItems = Services.CallApi(urlApp + "/" + appKey + "/SdCase/Get", "POST", dataRequest);

            var resultGetItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PageType>>(getItems);

            int resultNum = resultGetItems.Count;
            Assert.IsTrue(resultNum > 0);

            dataRequest = new ApiWrapper();
            dataRequest.QueryFilter = "";
            dataRequest.Token = resultLogin.data.Token;
            dataRequest.CompanyId = resultRegisterWithApp.data.IdCompany;
            getItems = Services.CallApi(urlApp + "/" + appKey + "/SdCase/Get?v=2", "POST", dataRequest);

            Result<List<PageType>> resultsTyped = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<List<PageType>>>(getItems);

            Assert.AreEqual(resultsTyped.status, "success");
            Assert.IsTrue(resultsTyped.data.Count > 0);





            var dataRequest2 = new ApiWrapper();
            
            dataRequestTyped.MethodName = "MyCustomMethodA";
               // dataRequest.QueryFilter = "it.UserProfile.GuidUser ";
            dataRequestTyped.Token = resultLogin.data.Token;
            dataRequestTyped.CompanyId = resultRegisterWithApp.data.IdCompany;
            result = Services.CallApi(urlApp + "/" + appKey + "/SdCase/CustomMethod", "POST", (object)dataRequestTyped);

            // Assert.AreEqual(resultGetItems.status, "success");


            #endregion



        }
    }
}
