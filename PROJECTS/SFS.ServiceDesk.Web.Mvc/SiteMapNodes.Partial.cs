using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcSiteMapProvider;
using SFS.ServiceDesk.Web.Mvc.Resources;
using System.Web.Mvc;
using SFS.ServiceDesk.BusinessObjects;

namespace SFS.ServiceDesk.Web.Mvc
{
    public partial class DynamicNodeProvider
    {

        SFSdotNet.Framework.Globalization.TextUI textUI = new SFSdotNet.Framework.Globalization.TextUI("SFSServiceDesk", null);
 
        partial void OnCreatingNodes(object sender, ref List<DynamicNode> nodes)
        {




        }

        partial void OnCreatedNodes(object sender, ref List<DynamicNode> nodes)
        {
            




        }
    }
}
