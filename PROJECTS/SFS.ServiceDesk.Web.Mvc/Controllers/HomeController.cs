using SFS.ServiceDesk.BusinessObjects;
using SFSdotNet.Framework.Web.Mvc;
using SFSdotNet.Framework.Web.Mvc.Models;
using SFSdotNet.Framework.Web.Mvc.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SFS.ServiceDesk.Web.Mvc.Controllers
{

    public class HomeController : SFS.ServiceDesk.Web.Mvc.ControllerBase<ModelBase>
    {
        public HomeController()
        {
            //UIText = new SFSdotNet.Framework.Globalization.TextUI("SFSServiceDesk", cmeMeeting.EntityName, GetContextRequest());
        }
        SFSdotNet.Framework.Globalization.TextUI UIText;

        //[MyAuthorize()]
        //public ActionResult Public(string meeting)
        //{
        //    if (!string.IsNullOrEmpty(meeting))
        //    {
        //        return RedirectToAction("OpenedMeeting", "cmeMeetings", new { guidMeeting = meeting });
        //    }
        //    MyEventArgs<UIModel<ModelBase>> eBase = new MyEventArgs<UIModel<ModelBase>>();
        //    eBase.Object = new UIModel<ModelBase>();
        //    this.LayoutSettings(this, eBase);
        //    var uiModel = eBase.UIModel;
        //    uiModel.RemoveTitleSpace = true;

        //    uiModel.BodyPartialView = "HomeStart";
        //    //loadCSS("@(SFSdotNet.Framework.Web.Urls.Tag("~/Static/v2/Elastislide/css/elastislide.css"))");
        //    //loadJS("@(SFSdotNet.Framework.Web.Urls.Tag("~/Static/v2/Elastislide/js/jquery.elastislide.js"))");
        //    uiModel.CssFiles.Add("~/Static/v2/Elastislide/css/elastislide.css");
        //    uiModel.JsFiles.Add("~/Static/v2/Elastislide/js/jquery.elastislide.js");

        //    ViewBag.HtmlTabs = SFSdotNet.Framework.Resources.Content.GetContent("SFSServiceDesk", "Views/Shared/LeftHomeTabs.cshtml", GetContextRequest());
        //    ViewBag.HtmlTabs = SFSdotNet.Framework.Utilities.Text.RemoveLineEndings(ViewBag.HtmlTabs);
        //    ViewBag.UserDisplayName = SFSdotNet.Framework.My.Context.CurrentContext.User.FirstName;
        //    ViewBag.Time = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
        //    string welcomeText = this.UIText.GetText("welcome");
        //    string createNewMeetingText = this.UIText.GetText("create-new-meeting");
        //    #region Texts
        //    if (welcomeText == null)
        //    {
        //        UIText.SetInitialText("welcome", "en", "Welcome");
        //        UIText.SetInitialText("welcome", "es", "Bienvenid@");
        //        welcomeText = UIText.GetText("welcome");
        //    }
        //    if (createNewMeetingText == null)
        //    {
        //        UIText.SetInitialText("create-new-meeting", "en", "Create new meeting");
        //        UIText.SetInitialText("create-new-meeting", "es", "Crear nueva reunión");
        //        createNewMeetingText = UIText.GetText("create-new-meeting");
        //    }


        //    #endregion
        //    ViewBag.WelcomeText = welcomeText;
        //    ViewBag.CreateNewMeetingText = createNewMeetingText;



        //    return ResolveView(uiModel, null);

           


        //}
        //
        // GET: /Home/
        [MyAuthorize("r")]
        public ActionResult Index()
        {
            //Session["test"] = "prueba";

            //if (
            //    SFSdotNet.Framework.My.Context.CurrentContext.IsModuleAdmin("SFSServiceDesk", SFSdotNet.Framework.My.Context.CurrentContext.Company)
            //    || SFSdotNet.Framework.My.Context.CurrentContext.IsSuperAdmin()
            //    )
            //{
                return RedirectToAction("Statics", "Dashboard", new { area = "SFSdotNetFrameworkSecurity", overrideModule = "SFSServiceDesk" });

        //}
        //    else
        //    {

        //        return RedirectToAction("Public");
        //    }

        }

        public ContentResult ShortDescription()
        {
            return Content(SFS.ServiceDesk.Web.Mvc.Resources.ModuleResources.SHORT_DESCRIPTION);
        }
        public ContentResult  LogoUrl()
        {
            return Content(VirtualPathUtility.ToAbsolute("~/SFSServiceDesk/Content/img/logo.png"));
        }
        public ContentResult AboutHtml()
        {
            return Content("About text");
        }
    }
}
