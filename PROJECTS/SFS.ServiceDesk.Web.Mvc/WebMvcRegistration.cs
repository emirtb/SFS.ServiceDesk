using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcContrib.PortableAreas;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Routing;
using SFSdotNet.Framework.My;
using SFSdotNet.Framework.Web.Mvc;

namespace SFS.ServiceDesk.Web.Mvc
{
    public partial class SFSServiceDeskWebMvcRegistration : PortableAreaRegistration, IRegistrationModuleWithInfo
    {

        public override void RegisterArea(System.Web.Mvc.AreaRegistrationContext context, IApplicationBus bus)
        {
            #region SFSServiceDesk/Views/Shared/
            context.MapRoute("SFSServiceDesk_Views_Shared", "SFSServiceDesk/Views/Shared/{resourceName}",
                new { controller = "EmbeddedResource", action = "Index", resourcePath = "Views/Shared" },
                new string[] { "MvcContrib.PortableAreas" });
            #endregion

            #region SFSServiceDesk/Content/Themes/Default/
            context.MapRoute("SFSServiceDesk_ResourceRoute_theme", "SFSServiceDesk/Content/Themes/Default/{resourceName}",
                new { controller = "EmbeddedResource", action = "Index", resourcePath = "Content/Themes/Default" },
                new string[] { "MvcContrib.PortableAreas" });
            #endregion
            #region SFSServiceDesk/Content/Themes/Default/css/
            context.MapRoute("SFSServiceDesk_ResourceRoute_theme_css", "SFSServiceDesk/Content/Themes/Default/css/{resourceName}",
    new { controller = "EmbeddedResource", action = "Index", resourcePath = "Content/Themes/Default/css" },
    new string[] { "MvcContrib.PortableAreas" });
            #endregion



           
            context.MapRoute("SFSServiceDesk_ResourceRoute_js", "SFSServiceDesk/Content/js/{resourceName}",
    new { controller = "EmbeddedResource", action = "Index", resourcePath = "Content/js" },
    new string[] { "MvcContrib.PortableAreas" });
     


            #region SFSServiceDesk/Content/Themes/Default/img/
            context.MapRoute("SFSServiceDesk_ResourceRoute_theme_img", "SFSServiceDesk/Content/Themes/Default/img/{resourceName}",
    new { controller = "EmbeddedResource", action = "Index", resourcePath = "Content/Themes/Default/img" },
    new string[] { "MvcContrib.PortableAreas" });
            #endregion
            #region SFSServiceDesk/Content/img/
            context.MapRoute("SFSServiceDesk_ResourceRoute_img", "SFSServiceDesk/Content/img/{resourceName}",
new { controller = "EmbeddedResource", action = "Index", resourcePath = "Content/img" },
new string[] { "MvcContrib.PortableAreas" });
            #endregion

            context.MapRoute("SFSServiceDesk_ResourceImageRoute", "SFSServiceDesk/images/{resourceName}",
                new { controller = "EmbeddedResource", action = "Index", resourcePath = "images" },
                new string[] { "MvcContrib.PortableAreas" });

            context.MapRoute("SFSServiceDesk_Default", 
                "SFSServiceDesk/{controller}/{action}",
                new { controller = "Home", 
                    action = "index" },
                new string[] { "SFS.ServiceDesk.Web.Mvc.Controllers" 
                });

            context.MapRoute(
              "SFSServiceDesk_Id", // Route name
              "SFSServiceDesk/{controller}/{action}/{id}", // URL with parameters
              new { controller = "Home", 
                  action = "Index", 
                  id = UrlParameter.Optional }, 
                  new[] { "SFS.ServiceDesk.Web.Mvc.Controllers" 
                  });

            //context.MapRoute(
            // "SFSServiceDesk_usemode_Id", // Route name
            // "SFSServiceDesk/{controller}/usemode/{usemode}/{action}/{id}", // URL with parameters
            // new
            // {
            //     controller = "Home",
            //     action = "Index",
            //     id = UrlParameter.Optional
            // },
            //     new[] { "SFS.ServiceDesk.Web.Mvc.Controllers" 
            //      });
          

            
        
            //ControllerBuilder.Current.DefaultNamespaces.Add("SFS.ServiceDesk.Web.Mvc.Controllers");

            this.RegisterAreaEmbeddedResources();
            if (Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["AutoInjectPermissionsOnStartup"]))
                SecuritySettings.PermissionsInitialization();

            OnAreaRegistration(this, new EventArgs());
        }
        public  SFSdotNet.Framework.My.BusinessModuleApp GetModuleInfo()
        {
            SFSdotNet.Framework.My.BusinessModuleApp result = new SFSdotNet.Framework.My.BusinessModuleApp();
            result.BusinessModulePath = "SFSServiceDesk";
            //result.DefaultOwnLayout = VirtualPathUtility.ToAbsolute("~/") + "Areas/" + result.BusinessModulePath + "/Views/Shared/_Layout.cshtml";
            result.UseOwnLayout = false;
            OnBusinessAppInfoRequest(this, result );
            return result;
        }
        partial void OnBusinessAppInfoRequest(object sender, BusinessModuleApp e);
        partial void OnAreaRegistration(object sender, EventArgs e);

        public override string AreaName
        {
            get
            {
                return "SFSServiceDesk";
            }
        }
    }
}
