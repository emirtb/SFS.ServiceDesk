using SFS.ServiceDesk.BR;
using SFS.ServiceDesk.BusinessObjects;
using SFS.ServiceDesk.Web.Mvc.Models;
using Newtonsoft.Json;
using SFSdotNet.Framework.Common.Entities;
using SFSdotNet.Framework.Entities;
using SFSdotNet.Framework.My;
using SFSdotNet.Framework.Security.BR;
using SFSdotNet.Framework.Security.BusinessObjects;
using SFSdotNet.Framework.Security.Web.Mvc.Models.secCompanies;
using SFSdotNet.Framework.Web.Mvc;
using SFSdotNet.Framework.Web.Mvc.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SFS.ServiceDesk.Web.Mvc.Controllers
{
    public class EntityChangeSet
    {
        public string EntityName { get; set; }
        public string EntitySetName { get; set; }
        public string FilterQuery { get; set; }
    }
    public class IntegrationAppsController : SFSdotNet.Framework.Web.Mvc.ControllerBase
    {
        private DateTime GetDate(string stringFrom)
        {
            string year = stringFrom.Substring(0, 4);
            string month = stringFrom.Substring(4, 2);
            string day = stringFrom.Substring(6, 2);

            string hour = stringFrom.Substring(9, 2);
            string minute = stringFrom.Substring(11, 2);
            string second = stringFrom.Substring(13, 2);

            DateTime fromUtc = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minute), int.Parse(second));
            return fromUtc;
        }
      
           


        public ViewDataDictionary GetViewData(RequestContext requestContext)
        {
            string controller = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(requestContext.HttpContext.Request.RequestContext, "controller");
            string action = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(requestContext.HttpContext.Request.RequestContext, "action");

            if (controller == "Public" && (action == "Login" || action == "Register" || action == "ResetPassword"))
            {
                if (!string.IsNullOrEmpty(requestContext.HttpContext.Request.QueryString["ReturnUrl"]))
                {
                    StringBuilder sbLangChange = new StringBuilder();
                    if (!string.IsNullOrEmpty(requestContext.HttpContext.Request.QueryString["lang"]))
                    {

                    }
               

                    UIModel uiModel = new UIModel();

                    uiModel.UILayoutFile = "~/Views/Templates/AdminLTE.cshtml";
                    uiModel.NewUILayoutTool = true;
                    uiModel.UIVersion = 2;


                    ViewData["uiModel"] = uiModel;

                    string loginScripts = SFSdotNet.Framework.Resources.Content.GetContent("SFSServiceDesk", "Views/LoginScripts.cshtml", GetContextRequest(requestContext.HttpContext.ApplicationInstance.Context));
                    //loginScripts = loginScripts.Replace("{APP_PATH}", VirtualPathUtility.ToAbsolute("~/"));

                    //ViewData["HeaderScript"] = "";
                    ViewData["FooterScript"] = loginScripts;
                }
            }

            return ViewData;
        }
        public void OnLayoutSettings(object sender, object e)
        {
            SFS.ServiceDesk.Web.Mvc.ControllerBase<ModelBase> controller = new ControllerBase<ModelBase>();
            MyEventArgs<SFSdotNet.Framework.Web.Mvc.Models.UIModel<ModelBase>> eModel = (MyEventArgs<SFSdotNet.Framework.Web.Mvc.Models.UIModel<ModelBase>>)e;
            controller.LayoutSettings(this, eModel);
            e = eModel;

        }

        public void OnEdited(object sender, object e)
        {
            if (sender.GetType().FullName.Contains("secCompaniesController"))
            {
              
            }
        }
        public void OnShowing(object sender, object e)
        {
            if (sender.GetType().FullName.Contains("secCompaniesController"))
            {
                MyEventArgs<SFSdotNet.Framework.Web.Mvc.Models.UIModel<SFSdotNet.Framework.Security.Web.Mvc.Models.secCompanies.secCompanyModel>> eModel = (MyEventArgs<SFSdotNet.Framework.Web.Mvc.Models.UIModel<SFSdotNet.Framework.Security.Web.Mvc.Models.secCompanies.secCompanyModel>>)e;
                if (IsItemsOrListForm(eModel.UIModel))
                {
                 
                }
                if (IsEditOrDetailsForm(eModel.UIModel))
                { 
                  
                }
            }
        }
    }
}