using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFS.ServiceDesk.BusinessObjects;
using SFSdotNet.Framework.BR;

namespace SFS.ServiceDesk.BR
{
    public partial class SDPersonsBR

        
    {
        //public void MyMethod()
        //{
        //    SFSdotNet.Framework.My.Context.CurrentContext.ContextRequest.ReplaceApiResponse()
        //}
        //partial void OnTaken(object sender, BusinessRulesEventArgs<SDPerson> e)
        //{
        //    throw new NotImplementedException();
        //}
        partial void OnGetting(object sender, BusinessRulesEventArgs<SDPerson> e)
        {
            // Sample of replace API response and cancel the current request
            e.ContextRequest.ReplaceApiResponse("success", "test", "simple test of replace", e.Items);
            e.Cancel = true; // Canceling the execution of the query
        }
    }
}
