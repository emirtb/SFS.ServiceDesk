using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFS.ServiceDesk.BusinessObjects;
using SFSdotNet.Framework.BR;

namespace SFS.ServiceDesk.BR
{
    public partial class SDCasesBR
    {
        #region Samples for guide
        ////Sample for guide
        //partial void OnQuerySettings(object sender, BusinessRulesEventArgs<SDCase> e)
        //{
        //    //e.SetQueryComputedField(SDCase.PropertyNames.SDCaseHistories, true);
        //    e.SetQueryComputedField(SDCase.PropertyNames.SDCaseHistories, "it.SDCaseHistories.Where(IsDeleted = null OR IsDeleted = false)");
        //}
        //partial void OnTaken(object sender, BusinessRulesEventArgs<SDCase> e)
        //{
        //    e.ContextRequest.ReplaceApiResponse("succes", null, null, e.Items);
        //}
       

        #endregion


    }
}
