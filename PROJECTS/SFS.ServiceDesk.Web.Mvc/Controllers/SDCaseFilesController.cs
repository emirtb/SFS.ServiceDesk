using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SFS.ServiceDesk.Web.Mvc.Models.SDCaseFiles;
using SFSdotNet.Framework.Web.Mvc;
using SFSdotNet.Framework.Web.Mvc.Models;
using SFS.ServiceDesk.BusinessObjects;

namespace SFS.ServiceDesk.Web.Mvc.Controllers
{
    public partial class SDCaseFilesController
    {
        partial void OnShowing(object sender, MyEventArgs<UIModel<SDCaseFileModel>> e)
        {
            
            if (this.IsItemsOrListForm(e.UIModel))
            {
                e.UIModel.SetOrder(SDCaseFile.PropertyNames.SDFile);
                e.UIModel.SetHide(SDCaseFile.PropertyNames.GuidFile, true);
                e.UIModel.SetHide(SDCaseFile.PropertyNames.ExistFile, true);


                e.UIModel.SetOrder(SDCaseFile.PropertyNames.FileName, true);



                //e.UIModel.Properties.Add(GetPropertyDefinition("StaticFile", new accFileModel()));
                e.UIModel.SetHide(SDCaseFile.PropertyNames.UrlFile, true);
                e.UIModel.SetHide(SDCaseFile.PropertyNames.UrlThumbFile, true);

                var module = SFSdotNet.Framework.Cache.Caching.SystemObjects.GetModuleByKey("SFSServiceDesk");
                SFSdotNet.Framework.Data.StaticStorage storage = new SFSdotNet.Framework.Data.StaticStorage("Thumbs");
                foreach (var item in e.UIModel.Items)
                {

                    var staticFile = storage.GetFile(item.GuidFile, item.FileName, item.FileStorage, null, 100, 100, "SDFile", "SDFiles", module, GetContextRequest());
                    item.UrlFile = staticFile.Url;
                    item.UrlThumbFile = staticFile.UrlThumb;
                }

            }
        }
    }
}