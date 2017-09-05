using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFS.ServiceDesk.BusinessObjects;
using SFSdotNet.Framework.BR;

namespace SFS.ServiceDesk.BR
{
    public partial class SDCaseFilesBR
    {
        partial void OnQuerySettings(object sender, BusinessRulesEventArgs<SDCaseFile> e)
        {
            e.SetQueryComputedField(SDCaseFile.PropertyNames.ExistFile, "iif(it.SDFile == null, false, true)");
            e.SetQueryComputedField(SDCaseFile.PropertyNames.FileStorage, "iif(it.SDFile != null, it.SDFile.FileStorage, null)");
        }
    }
}
