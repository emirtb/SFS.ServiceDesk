
 
 
// <Template>
//   <SolutionTemplate></SolutionTemplate>
//   <Version>20140213.2136</Version>
//   <Update>Agregado el objeto ContextRequest en todas las peticiones de reglas de negocio</Update>
// </Template>using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using SFSdotNet.Framework.Security.BusinessObjects;
using SFSdotNet.Framework.My;


namespace SFS.ServiceDesk.Web.Mvc
{
    public partial class SecuritySettings
    {
		static partial void OnCreatingRolesAndUsers(object sender, secModule module);
		static partial void OnIntegrationSetting(object sender, SFSdotNet.Framework.Security.BusinessObjects.secModule module, ContextRequest contextRequest);
        
        public static void PermissionsInitialization() {
			ContextRequest contextRequest = new ContextRequest();
            string moduleKey = "SFSServiceDesk";

			var module = SFSdotNet.Framework.Security.SiteMapBuilder.AddModuleIfNotExist(moduleKey, moduleKey, "SFS.ServiceDesk", null);

            #region permissions
            secPermission createPermission = SFSdotNet.Framework.Security.Permissions.AddPermissionIfNotExist("c", "Create", module, contextRequest);
            secPermission readPermission = SFSdotNet.Framework.Security.Permissions.AddPermissionIfNotExist("r", "Read", module, contextRequest);
            secPermission updatePermission = SFSdotNet.Framework.Security.Permissions.AddPermissionIfNotExist("u", "Update", module, contextRequest);
            secPermission deletePermission = SFSdotNet.Framework.Security.Permissions.AddPermissionIfNotExist("d", "Delete", module, contextRequest);
			
			OnCreatingRolesAndUsers(null, module);
			 OnIntegrationSetting(null, module, contextRequest);
		
			//if (SFSdotNet.Framework.Security.BR.secRolesBR.Instance.GetBy(p => p.LoweredRoleName == "superadmin").Count == 0)
            //    SFSdotNet.Framework.Security.BR.secRolesBR.Instance.Create(new secRole() { LoweredRoleName="superadmin", RoleName="superadmin" });


			 if (SFSdotNet.Framework.Security.BR.secRolesBR.Instance.GetBy(p => p.LoweredRoleName == "sfsservicedesk admin", contextRequest).Count == 0)
                SFSdotNet.Framework.Security.BR.secRolesBR.Instance.Create(new secRole() { LoweredRoleName="sfsservicedesk admin", RoleName="SFSServiceDesk Admin" }, contextRequest);
            
            
			AddPermissionIfNotExist(module, null, readPermission);
            #endregion
			
			secBusinessObject bo = null;
			secModuleObjectPermission mop =  null;
            secRoleModuleObjectPermission rmop = null;
			#region BusinessObjects
			
            #region SDArea
            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.GetBy(p=>p.BusinessObjectKey == "SDArea" && p.secModule.ModuleKey == module.ModuleKey , contextRequest).FirstOrDefault();
            if (bo == null) {
                            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Create(new secBusinessObject() { BusinessObjectKey="SDArea",EntitySetName="SDAreas", Name="SDArea", secModule = module, GuidBusinessObject= Guid.NewGuid()  }, contextRequest);
            }else{
				bo.EntitySetName = "SDAreas";
				bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Update(bo, contextRequest);
			}
            AddPermissionIfNotExist(module, bo, createPermission);
            AddPermissionIfNotExist(module, bo, readPermission);
            AddPermissionIfNotExist(module, bo, updatePermission);
            AddPermissionIfNotExist(module, bo, deletePermission);
            #endregion

            #region SDAreaPerson
            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.GetBy(p=>p.BusinessObjectKey == "SDAreaPerson" && p.secModule.ModuleKey == module.ModuleKey , contextRequest).FirstOrDefault();
            if (bo == null) {
                            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Create(new secBusinessObject() { BusinessObjectKey="SDAreaPerson",EntitySetName="SDAreaPersons", Name="SDAreaPerson", secModule = module, GuidBusinessObject= Guid.NewGuid()  }, contextRequest);
            }else{
				bo.EntitySetName = "SDAreaPersons";
				bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Update(bo, contextRequest);
			}
            AddPermissionIfNotExist(module, bo, createPermission);
            AddPermissionIfNotExist(module, bo, readPermission);
            AddPermissionIfNotExist(module, bo, updatePermission);
            AddPermissionIfNotExist(module, bo, deletePermission);
            #endregion

            #region SDCase
            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.GetBy(p=>p.BusinessObjectKey == "SDCase" && p.secModule.ModuleKey == module.ModuleKey , contextRequest).FirstOrDefault();
            if (bo == null) {
                            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Create(new secBusinessObject() { BusinessObjectKey="SDCase",EntitySetName="SDCases", Name="SDCase", secModule = module, GuidBusinessObject= Guid.NewGuid()  }, contextRequest);
            }else{
				bo.EntitySetName = "SDCases";
				bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Update(bo, contextRequest);
			}
            AddPermissionIfNotExist(module, bo, createPermission);
            AddPermissionIfNotExist(module, bo, readPermission);
            AddPermissionIfNotExist(module, bo, updatePermission);
            AddPermissionIfNotExist(module, bo, deletePermission);
            #endregion

            #region SDCaseFile
            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.GetBy(p=>p.BusinessObjectKey == "SDCaseFile" && p.secModule.ModuleKey == module.ModuleKey , contextRequest).FirstOrDefault();
            if (bo == null) {
                            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Create(new secBusinessObject() { BusinessObjectKey="SDCaseFile",EntitySetName="SDCaseFiles", Name="SDCaseFile", secModule = module, GuidBusinessObject= Guid.NewGuid()  }, contextRequest);
            }else{
				bo.EntitySetName = "SDCaseFiles";
				bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Update(bo, contextRequest);
			}
            AddPermissionIfNotExist(module, bo, createPermission);
            AddPermissionIfNotExist(module, bo, readPermission);
            AddPermissionIfNotExist(module, bo, updatePermission);
            AddPermissionIfNotExist(module, bo, deletePermission);
            #endregion

            #region SDCaseHistory
            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.GetBy(p=>p.BusinessObjectKey == "SDCaseHistory" && p.secModule.ModuleKey == module.ModuleKey , contextRequest).FirstOrDefault();
            if (bo == null) {
                            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Create(new secBusinessObject() { BusinessObjectKey="SDCaseHistory",EntitySetName="SDCaseHistories", Name="SDCaseHistory", secModule = module, GuidBusinessObject= Guid.NewGuid()  }, contextRequest);
            }else{
				bo.EntitySetName = "SDCaseHistories";
				bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Update(bo, contextRequest);
			}
            AddPermissionIfNotExist(module, bo, createPermission);
            AddPermissionIfNotExist(module, bo, readPermission);
            AddPermissionIfNotExist(module, bo, updatePermission);
            AddPermissionIfNotExist(module, bo, deletePermission);
            #endregion

            #region SDCaseHistoryFile
            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.GetBy(p=>p.BusinessObjectKey == "SDCaseHistoryFile" && p.secModule.ModuleKey == module.ModuleKey , contextRequest).FirstOrDefault();
            if (bo == null) {
                            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Create(new secBusinessObject() { BusinessObjectKey="SDCaseHistoryFile",EntitySetName="SDCaseHistoryFiles", Name="SDCaseHistoryFile", secModule = module, GuidBusinessObject= Guid.NewGuid()  }, contextRequest);
            }else{
				bo.EntitySetName = "SDCaseHistoryFiles";
				bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Update(bo, contextRequest);
			}
            AddPermissionIfNotExist(module, bo, createPermission);
            AddPermissionIfNotExist(module, bo, readPermission);
            AddPermissionIfNotExist(module, bo, updatePermission);
            AddPermissionIfNotExist(module, bo, deletePermission);
            #endregion

            #region SDCasePriority
            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.GetBy(p=>p.BusinessObjectKey == "SDCasePriority" && p.secModule.ModuleKey == module.ModuleKey , contextRequest).FirstOrDefault();
            if (bo == null) {
                            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Create(new secBusinessObject() { BusinessObjectKey="SDCasePriority",EntitySetName="SDCasePriorities", Name="SDCasePriority", secModule = module, GuidBusinessObject= Guid.NewGuid()  }, contextRequest);
            }else{
				bo.EntitySetName = "SDCasePriorities";
				bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Update(bo, contextRequest);
			}
            AddPermissionIfNotExist(module, bo, createPermission);
            AddPermissionIfNotExist(module, bo, readPermission);
            AddPermissionIfNotExist(module, bo, updatePermission);
            AddPermissionIfNotExist(module, bo, deletePermission);
            #endregion

            #region SDCaseState
            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.GetBy(p=>p.BusinessObjectKey == "SDCaseState" && p.secModule.ModuleKey == module.ModuleKey , contextRequest).FirstOrDefault();
            if (bo == null) {
                            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Create(new secBusinessObject() { BusinessObjectKey="SDCaseState",EntitySetName="SDCaseStates", Name="SDCaseState", secModule = module, GuidBusinessObject= Guid.NewGuid()  }, contextRequest);
            }else{
				bo.EntitySetName = "SDCaseStates";
				bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Update(bo, contextRequest);
			}
            AddPermissionIfNotExist(module, bo, createPermission);
            AddPermissionIfNotExist(module, bo, readPermission);
            AddPermissionIfNotExist(module, bo, updatePermission);
            AddPermissionIfNotExist(module, bo, deletePermission);
            #endregion

            #region SDFile
            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.GetBy(p=>p.BusinessObjectKey == "SDFile" && p.secModule.ModuleKey == module.ModuleKey , contextRequest).FirstOrDefault();
            if (bo == null) {
                            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Create(new secBusinessObject() { BusinessObjectKey="SDFile",EntitySetName="SDFiles", Name="SDFile", secModule = module, GuidBusinessObject= Guid.NewGuid()  }, contextRequest);
            }else{
				bo.EntitySetName = "SDFiles";
				bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Update(bo, contextRequest);
			}
            AddPermissionIfNotExist(module, bo, createPermission);
            AddPermissionIfNotExist(module, bo, readPermission);
            AddPermissionIfNotExist(module, bo, updatePermission);
            AddPermissionIfNotExist(module, bo, deletePermission);
            #endregion

            #region SDOrganization
            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.GetBy(p=>p.BusinessObjectKey == "SDOrganization" && p.secModule.ModuleKey == module.ModuleKey , contextRequest).FirstOrDefault();
            if (bo == null) {
                            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Create(new secBusinessObject() { BusinessObjectKey="SDOrganization",EntitySetName="SDOrganizations", Name="SDOrganization", secModule = module, GuidBusinessObject= Guid.NewGuid()  }, contextRequest);
            }else{
				bo.EntitySetName = "SDOrganizations";
				bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Update(bo, contextRequest);
			}
            AddPermissionIfNotExist(module, bo, createPermission);
            AddPermissionIfNotExist(module, bo, readPermission);
            AddPermissionIfNotExist(module, bo, updatePermission);
            AddPermissionIfNotExist(module, bo, deletePermission);
            #endregion

            #region SDPerson
            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.GetBy(p=>p.BusinessObjectKey == "SDPerson" && p.secModule.ModuleKey == module.ModuleKey , contextRequest).FirstOrDefault();
            if (bo == null) {
                            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Create(new secBusinessObject() { BusinessObjectKey="SDPerson",EntitySetName="SDPersons", Name="SDPerson", secModule = module, GuidBusinessObject= Guid.NewGuid()  }, contextRequest);
            }else{
				bo.EntitySetName = "SDPersons";
				bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Update(bo, contextRequest);
			}
            AddPermissionIfNotExist(module, bo, createPermission);
            AddPermissionIfNotExist(module, bo, readPermission);
            AddPermissionIfNotExist(module, bo, updatePermission);
            AddPermissionIfNotExist(module, bo, deletePermission);
            #endregion

            #region SDProxyUser
            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.GetBy(p=>p.BusinessObjectKey == "SDProxyUser" && p.secModule.ModuleKey == module.ModuleKey , contextRequest).FirstOrDefault();
            if (bo == null) {
                            bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Create(new secBusinessObject() { BusinessObjectKey="SDProxyUser",EntitySetName="SDProxyUsers", Name="SDProxyUser", secModule = module, GuidBusinessObject= Guid.NewGuid()  }, contextRequest);
            }else{
				bo.EntitySetName = "SDProxyUsers";
				bo = SFSdotNet.Framework.Security.BR.secBusinessObjectsBR.Instance.Update(bo, contextRequest);
			}
            AddPermissionIfNotExist(module, bo, createPermission);
            AddPermissionIfNotExist(module, bo, readPermission);
            AddPermissionIfNotExist(module, bo, updatePermission);
            AddPermissionIfNotExist(module, bo, deletePermission);
            #endregion

            #endregion
        }
		
		public static void AddPermissionIfNotExist(secModule module, secBusinessObject businessObject, secPermission permission) {
              // se asume que el permiso ya existe
            // se asume que el m?dulo ya existe
             ContextRequest contextRequest = new ContextRequest();
            if (businessObject == null)
            {
                // m?dulo y permiso ya existen
                secPermission mp = SFSdotNet.Framework.Security.BR.secPermissionsBR.Instance.GetBy(
                p => p.PermissionKey == permission.PermissionKey
                && p.secModules.Any(x=>x.ModuleKey == module.ModuleKey)
                , contextRequest).FirstOrDefault();
                if (mp == null) {

                    SFSdotNet.Framework.Security.BR.secPermissionsBR.Instance.AddRelation(permission, module);
                }

                secRoleModulePermission rmp = SFSdotNet.Framework.Security.BR.secRoleModulePermissionsBR.Instance.GetBy(
                    p => p.secRole.LoweredRoleName == "superadmin"
                    && p.secModule.ModuleKey == module.ModuleKey
                
                    && p.secPermission.PermissionKey == permission.PermissionKey, contextRequest).FirstOrDefault();
                if (rmp == null) {
                    rmp = new secRoleModulePermission();
					rmp.secRole = SFSdotNet.Framework.Security.BR.secRolesBR.Instance.GetBy(p => p.LoweredRoleName == "superadmin", contextRequest).FirstOrDefault();
                    rmp.secModule = module;
                    rmp.secPermission = permission;
					rmp.IsAllowed = true;
                    SFSdotNet.Framework.Security.BR.secRoleModulePermissionsBR.Instance.Create(rmp, contextRequest);
                }
				rmp = SFSdotNet.Framework.Security.BR.secRoleModulePermissionsBR.Instance.GetBy(
                    p => p.secRole.LoweredRoleName == "sfsservicedesk admin"
                    && p.secModule.ModuleKey == module.ModuleKey
                
                    && p.secPermission.PermissionKey == permission.PermissionKey, contextRequest).FirstOrDefault();
                if (rmp == null) {
                    rmp = new secRoleModulePermission();
					rmp.secRole = SFSdotNet.Framework.Security.BR.secRolesBR.Instance.GetBy(p => p.LoweredRoleName == "sfsservicedesk admin", contextRequest).FirstOrDefault();
                    rmp.secModule = module;
                    rmp.secPermission = permission;
					rmp.IsAllowed = true;
                    SFSdotNet.Framework.Security.BR.secRoleModulePermissionsBR.Instance.Create(rmp, contextRequest);
                }
            }
            else { 
				secModuleObjectPermission mop = SFSdotNet.Framework.Security.BR.secModuleObjectPermissionsBR.Instance.GetBy(
					p => p.secPermission.PermissionKey == permission.PermissionKey
					&& p.secBusinessObject.BusinessObjectKey == businessObject.BusinessObjectKey
					&& p.secModule.ModuleKey == module.ModuleKey
					, contextRequest).FirstOrDefault();
				if (mop == null)
				{
					mop = new secModuleObjectPermission();
					mop.secModule = module;
					mop.secBusinessObject = businessObject;
					mop.secPermission = permission;

					mop = SFSdotNet.Framework.Security.BR.secModuleObjectPermissionsBR.Instance.Create(mop, contextRequest);
				}

				secRoleModuleObjectPermission rmop = SFSdotNet.Framework.Security.BR.secRoleModuleObjectPermissionsBR.Instance.GetBy(
					p => p.secRole.LoweredRoleName == "superadmin"
					&& p.secModule.ModuleKey == module.ModuleKey 
					&& p.secBusinessObject.BusinessObjectKey == businessObject.BusinessObjectKey 
					&& p.secPermission.PermissionKey == permission.PermissionKey, contextRequest).FirstOrDefault();
				if (rmop == null)
				{
					rmop = new secRoleModuleObjectPermission();
					rmop.secBusinessObject = businessObject ;
					rmop.secModule = module;
					rmop.secRole = SFSdotNet.Framework.Security.BR.secRolesBR.Instance.GetBy(p => p.LoweredRoleName == "superadmin", contextRequest).FirstOrDefault();
					rmop.secPermission = permission ;
					rmop.IsAllowed = true;

					SFSdotNet.Framework.Security.BR.secRoleModuleObjectPermissionsBR.Instance.Create(rmop, contextRequest);

				}
				
				rmop = SFSdotNet.Framework.Security.BR.secRoleModuleObjectPermissionsBR.Instance.GetBy(
					p => p.secRole.LoweredRoleName == "sfsservicedesk admin"
					&& p.secModule.ModuleKey == module.ModuleKey 
					&& p.secBusinessObject.BusinessObjectKey == businessObject.BusinessObjectKey 
					&& p.secPermission.PermissionKey == permission.PermissionKey, contextRequest).FirstOrDefault();
				if (rmop == null)
				{
					rmop = new secRoleModuleObjectPermission();
					rmop.secBusinessObject = businessObject ;
					rmop.secModule = module;
					rmop.secRole = SFSdotNet.Framework.Security.BR.secRolesBR.Instance.GetBy(p => p.LoweredRoleName == "sfsservicedesk admin", contextRequest).FirstOrDefault();
					rmop.secPermission = permission ;
					rmop.IsAllowed = true;

					SFSdotNet.Framework.Security.BR.secRoleModuleObjectPermissionsBR.Instance.Create(rmop, contextRequest);

				}
			}

        }

    }
}
