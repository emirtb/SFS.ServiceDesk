using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFS.ServiceDesk.BusinessObjects;
using SFSdotNet.Framework.BR;
using SFSdotNet.Framework.My;

namespace SFS.ServiceDesk.BR
{
    public partial class SDFilesBR
    {

        partial void OnGetting(object sender, BusinessRulesEventArgs<SDFile> e)
        {
            e.ContextRequest.SetParam("queryOr", e.ContextRequest.CustomQuery);
        }
        partial void OnCreating(object sender, BusinessRulesEventArgs<SDFile> e)
        {
            
            if (!string.IsNullOrEmpty(e.Item.FileName))
            {
                e.Item.FileName = SFSdotNet.Framework.Utilities.Text.RemoveDiacritics(e.Item.FileName);
            }
            bool saveInBlob = false;
            if (e.ContextRequest != null && e.ContextRequest.Company != null)
            {
                saveInBlob = (bool)SFSdotNet.Framework.Configuration.ModuleAppSettings.GetValue("save-files-blob", "SFSServiceDesk", "Boolean", true, false);
            }
            if (saveInBlob == true)
            {

                SFSdotNet.Framework.Data.StaticStorage storage = new SFSdotNet.Framework.Data.StaticStorage("SFSServiceDesk".ToLower());
                      storage.GuidCompany = e.ContextRequest.Company.GuidCompany;
                try
                {

                    string fileNameStorage = e.Item.GuidFile.ToString() + "_" + e.Item.FileName;
                    var storageFileName = storage.UploadByteArray(e.Item.FileData, fileNameStorage);
                    e.Item.FileStorage = storageFileName;
                
                }
                catch (Exception ex)
                {
                    SFSdotNet.Framework.My.EventLog.Exception(ex, e.ContextRequest);

                }


            }

            bool saveInDB = (bool)SFSdotNet.Framework.Configuration.ModuleAppSettings.GetValue("save-files-db", "SFSServiceDesk", "Boolean", true, false);
            if (saveInDB == false)
                e.Item.FileData = null;
            

        }

        partial void OnTaken(object sender, BusinessRulesEventArgs<SDFile> e)
        {
          
            var queryOr = e.ContextRequest.CustomParams.FirstOrDefault(p => p.Name == "queryOr");
            if (queryOr != null && (e.Item != null || e.Items.Count > 0))
            {
                if (e.Item == null)
                    e.Item = e.Items[0];

                CustomQuery customQuery = (CustomQuery)queryOr.Value;
                if (customQuery.SelectedFields.FirstOrDefault(p => p.Name == "FileData") != null)
                {

                    bool saveInBlob = false;
                    if (e.ContextRequest != null && e.ContextRequest.Company != null)
                    {
                        saveInBlob = (bool)SFSdotNet.Framework.Configuration.ModuleAppSettings.GetValue("save-files-blob", "SFSServiceDesk", "Boolean", false, false);
                    }
                    if (saveInBlob == true && !string.IsNullOrEmpty(e.Item.FileStorage))
                    {
                        
                        SFSdotNet.Framework.Data.StaticStorage storage = new SFSdotNet.Framework.Data.StaticStorage("SFSServiceDesk".ToLower());
                        
                        storage.GuidCompany = e.ContextRequest.Company.GuidCompany;

                        e.Item.FileData = storage.GetDataByteArray(e.Item.FileStorage);
                    



                    }
                }
            }
        }
    }
}
