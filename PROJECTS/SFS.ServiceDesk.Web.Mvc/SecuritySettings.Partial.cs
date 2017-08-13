using SFS.ServiceDesk.BusinessObjects;
using SFSdotNet.Framework.My;
using SFSdotNet.Framework.Security.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFS.ServiceDesk.Web.Mvc
{
    public partial class SecuritySettings
    {
        static partial void OnCreatingRolesAndUsers(object sender, SFSdotNet.Framework.Security.BusinessObjects.secModule module)
        {
            ContextRequest contextRequest = new ContextRequest();
            secPermission createPermission = SFSdotNet.Framework.Security.Permissions.AddPermissionIfNotExist("c", "Create", module, contextRequest);
            secPermission readPermission = SFSdotNet.Framework.Security.Permissions.AddPermissionIfNotExist("r", "Read", module, contextRequest);
            secPermission updatePermission = SFSdotNet.Framework.Security.Permissions.AddPermissionIfNotExist("u", "Update", module, contextRequest);
            secPermission deletePermission = SFSdotNet.Framework.Security.Permissions.AddPermissionIfNotExist("d", "Delete", module, contextRequest);

           //secPermission activate = SFSdotNet.Framework.Security.Permissions.AddPermissionIfNotExist("activate", "Activar", module, );

           // AddPermissionIfNotExist(module, bo, activate);
            //secPermission payment = SFSdotNet.Framework.Security.Permissions.AddPermissionIfNotExist("payment", "Pagar", module, contextRequest);
            //secPermission cancel = SFSdotNet.Framework.Security.Permissions.AddPermissionIfNotExist("cancel", "Cancelar", module, contextRequest);

            //secPermission preventAll = SFSdotNet.Framework.Security.Permissions.AddPermissionIfNotExist("prevent-all", "Evitar ver todo (Solo lo suyo)", module, contextRequest);
            //secPermission allWaitingForMe = SFSdotNet.Framework.Security.Permissions.AddPermissionIfNotExist("all-waiting-for-me", "Todas en espera de acción", module, contextRequest);



        }
    }
}