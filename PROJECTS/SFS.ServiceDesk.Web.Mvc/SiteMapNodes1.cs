
 
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcSiteMapProvider;
using SFS.ServiceDesk.Web.Mvc.Resources;
using SFSdotNet.Framework.Web.Mvc.Resources;


namespace SFS.ServiceDesk.Web.Mvc
{
    public partial class DynamicNodeProvider : DynamicNodeProviderBase
    {
        partial void OnCreatingNodes(object sender, ref List<DynamicNode> nodes);
        partial void OnCreatedNodes(object sender, ref List<DynamicNode> nodes);
   
       public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode startNode)
        {
            List<DynamicNode> nodes = new List<DynamicNode>();
            DynamicNode node = null;
             SFSdotNet.Framework.Globalization.TextUI textUI = new SFSdotNet.Framework.Globalization.TextUI("SFSServiceDesk", null);

			node = new DynamicNode();
            node.Title = ModuleResources.MODULE_NAME;
			
            node.Controller = "Navigation";
            node.Area = "";
            node.Action = "Index";
            node.Key = "SFSServiceDesk";
			node.RouteValues.Add("id", node.Key);
			node.RouteValues.Add("overrideModule", "SFSServiceDesk");

 			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("permissionKey", "r");    
 
 
			textUI.SetTextTo(node, "Title", typeof(ModuleResources), "MODULE_NAME");
                   
            nodes.Add(node);

			
            node = new DynamicNode();
            node.Title = ModuleResources.CATALOGS;
			  
            node.Controller = "Navigation";
            node.Area = "";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_Catalogs";
			node.RouteValues.Add("id", node.Key);
			node.RouteValues.Add("overrideModule", "SFSServiceDesk");

			node.Attributes.Add("moduleKey", "SFSServiceDesk");
			node.ParentKey = "SFSServiceDesk";
			 textUI.SetTextTo(node, "Title", typeof(ModuleResources), "CATALOGS");
         
            nodes.Add(node);
			
			
          /*  node = new DynamicNode();
            node.Title = ModuleResources.all_catalogs;
			 
            node.Controller = "Navigation";
            node.Area = "";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_all_catalogs";
			node.RouteValues.Add("id", node.Key);
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
			node.RouteValues.Add("overrideModule", "SFSServiceDesk");

			node.ParentKey = "SFSServiceDesk_Catalogs";
			 textUI.SetTextTo(node, "Title", typeof(ModuleResources), "all_catalogs");
          
            nodes.Add(node);*/


            node = new DynamicNode();
            //node.Title = SFSdotNet.Framework.Web.Mvc.Resources.GlobalMessages.USERS_AND_ROLES ;
            node.Controller = "secBusinessObjects";
            node.Area = "SFSdotNetFrameworkSecurity";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_all_catalogs";
            node.ParentKey = "SFSServiceDesk_Catalogs";
            node.Attributes.Add("moduleKey", "SFSdotNetFrameworkSecurity");
            node.RouteValues.Add("overrideModule", "SFSServiceDesk");
            node.RouteValues.Add("usemode", "all-catalogs");

            //node.Attributes.Add("permissionKey", "admin");
            textUI.SetTextTo(node, "Title", typeof(SFSdotNet.Framework.Web.Mvc.Resources.GlobalMessages), "ALL_CATALOGS");

            nodes.Add(node);

            
			//node for contents
			node = new DynamicNode();
            node.Title = ModuleResources.MODULE_NAME;
		  
            node.Controller = "Home";
            node.Area = "";
            node.Action = "App";
            node.Key = "SFSServiceDesk_home_app_c";
            node.RouteValues.Add("id", "SFSServiceDesk");
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
			node.RouteValues.Add("overrideModule", "SFSServiceDesk");

            node.ParentKey = "allapps";
				 textUI.SetTextTo(node, "Title", typeof(ModuleResources), "MODULE_NAME");
         
            nodes.Add(node);

			
		    OnCreatingNodes(this, ref nodes);

           List<SFSdotNet.Framework.Globalization.UITexts> entityTexts =   textUI.GetItems("en");
           string single = "";
           string plural = "";
           SFSdotNet.Framework.Globalization.UITexts entityText = null ;
	

			#region SDArea
			  plural = "";
            single = "";
            entityText = entityTexts.FirstOrDefault(p => p.EntityKey == "SDArea");
            if (entityText != null)
            {
                plural = entityText.PluralName;
                single = entityText.Name;
            }

            node = new DynamicNode();
            node.Title = !string.IsNullOrEmpty(plural) ? plural : "SDAreas";
		
		       node.Controller = "SDAreas";
            node.Area = "SFSServiceDesk";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_SDArea_List";
			//node.CacheResolvedUrl = true;
			node.ParentKey = "SFSServiceDesk_all_catalogs";
 			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDArea");
            node.Attributes.Add("permissionKey", "r");            
			nodes.Add(node);

			
			// Create
			node = new DynamicNode();
            node.Title =GlobalMessages.ADD_NEW;
            node.Controller = "SDAreas";
            node.Area = "SFSServiceDesk";
            node.Action = "CreateGen";
            node.Key = "SFSServiceDesk_SDArea_Create";
			node.ParentKey = "SFSServiceDesk_SDArea_List";
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDArea");
			node.Attributes.Add("visiblemenu", "false");
			
			
            nodes.Add(node);

			// Edit
			//node = new DynamicNode();
            //node.Title = SDAreaResources.SDAREAS_EDIT;
            //node.Controller = "SDAreas";
            //node.Area = "SFSServiceDesk";
            //node.Action = "EditGen";
            //node.Key = "SFSServiceDesk_SDArea_Edit";
			//node.ParentKey = "SFSServiceDesk_SDArea_List";
			//node.Attributes.Add("visible", "false");
			//node.Attributes.Add("dynamicParameters", "id");
			//node.Attributes.Add("isDynamic", "true");
            //nodes.Add(node);

			// Details
			node = new DynamicNode();
           //node.Title = !string.IsNullOrEmpty(single) ? single : "SDArea";
            node.Controller = "SDAreas";
            node.Area = "SFSServiceDesk";
            node.Action = "DetailsGen";
            node.Key = "SFSServiceDesk_SDArea_Details";
			node.ParentKey = "SFSServiceDesk_SDArea_List";
			node.Attributes.Add("visible", "false");
			node.Attributes.Add("dynamicParameters", "id");
			node.Attributes.Add("isDynamic", "true");
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDArea");
			node.PreservedRouteParameters.Add("id");
            nodes.Add(node); 

			#endregion
			#region SDAreaPerson
			  plural = "";
            single = "";
            entityText = entityTexts.FirstOrDefault(p => p.EntityKey == "SDAreaPerson");
            if (entityText != null)
            {
                plural = entityText.PluralName;
                single = entityText.Name;
            }

            node = new DynamicNode();
            node.Title = !string.IsNullOrEmpty(plural) ? plural : "SDAreaPersons";
		
		       node.Controller = "SDAreaPersons";
            node.Area = "SFSServiceDesk";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_SDAreaPerson_List";
			//node.CacheResolvedUrl = true;
			node.ParentKey = "SFSServiceDesk_all_catalogs";
 			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDAreaPerson");
            node.Attributes.Add("permissionKey", "r");            
			nodes.Add(node);

			
			// Create
			node = new DynamicNode();
            node.Title =GlobalMessages.ADD_NEW;
            node.Controller = "SDAreaPersons";
            node.Area = "SFSServiceDesk";
            node.Action = "CreateGen";
            node.Key = "SFSServiceDesk_SDAreaPerson_Create";
			node.ParentKey = "SFSServiceDesk_SDAreaPerson_List";
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDAreaPerson");
			node.Attributes.Add("visiblemenu", "false");
			
			
            nodes.Add(node);

			// Edit
			//node = new DynamicNode();
            //node.Title = SDAreaPersonResources.SDAREAPERSONS_EDIT;
            //node.Controller = "SDAreaPersons";
            //node.Area = "SFSServiceDesk";
            //node.Action = "EditGen";
            //node.Key = "SFSServiceDesk_SDAreaPerson_Edit";
			//node.ParentKey = "SFSServiceDesk_SDAreaPerson_List";
			//node.Attributes.Add("visible", "false");
			//node.Attributes.Add("dynamicParameters", "id");
			//node.Attributes.Add("isDynamic", "true");
            //nodes.Add(node);

			// Details
			node = new DynamicNode();
           //node.Title = !string.IsNullOrEmpty(single) ? single : "SDAreaPerson";
            node.Controller = "SDAreaPersons";
            node.Area = "SFSServiceDesk";
            node.Action = "DetailsGen";
            node.Key = "SFSServiceDesk_SDAreaPerson_Details";
			node.ParentKey = "SFSServiceDesk_SDAreaPerson_List";
			node.Attributes.Add("visible", "false");
			node.Attributes.Add("dynamicParameters", "id");
			node.Attributes.Add("isDynamic", "true");
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDAreaPerson");
			node.PreservedRouteParameters.Add("id");
            nodes.Add(node); 

			#endregion
			#region SDCase
			  plural = "";
            single = "";
            entityText = entityTexts.FirstOrDefault(p => p.EntityKey == "SDCase");
            if (entityText != null)
            {
                plural = entityText.PluralName;
                single = entityText.Name;
            }

            node = new DynamicNode();
            node.Title = !string.IsNullOrEmpty(plural) ? plural : "SDCases";
		
		       node.Controller = "SDCases";
            node.Area = "SFSServiceDesk";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_SDCase_List";
			//node.CacheResolvedUrl = true;
			node.ParentKey = "SFSServiceDesk_all_catalogs";
 			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCase");
            node.Attributes.Add("permissionKey", "r");            
			nodes.Add(node);

			
			// Create
			node = new DynamicNode();
            node.Title =GlobalMessages.ADD_NEW;
            node.Controller = "SDCases";
            node.Area = "SFSServiceDesk";
            node.Action = "CreateGen";
            node.Key = "SFSServiceDesk_SDCase_Create";
			node.ParentKey = "SFSServiceDesk_SDCase_List";
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCase");
			node.Attributes.Add("visiblemenu", "false");
			
			
            nodes.Add(node);

			// Edit
			//node = new DynamicNode();
            //node.Title = SDCaseResources.SDCASES_EDIT;
            //node.Controller = "SDCases";
            //node.Area = "SFSServiceDesk";
            //node.Action = "EditGen";
            //node.Key = "SFSServiceDesk_SDCase_Edit";
			//node.ParentKey = "SFSServiceDesk_SDCase_List";
			//node.Attributes.Add("visible", "false");
			//node.Attributes.Add("dynamicParameters", "id");
			//node.Attributes.Add("isDynamic", "true");
            //nodes.Add(node);

			// Details
			node = new DynamicNode();
           //node.Title = !string.IsNullOrEmpty(single) ? single : "SDCase";
            node.Controller = "SDCases";
            node.Area = "SFSServiceDesk";
            node.Action = "DetailsGen";
            node.Key = "SFSServiceDesk_SDCase_Details";
			node.ParentKey = "SFSServiceDesk_SDCase_List";
			node.Attributes.Add("visible", "false");
			node.Attributes.Add("dynamicParameters", "id");
			node.Attributes.Add("isDynamic", "true");
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCase");
			node.PreservedRouteParameters.Add("id");
            nodes.Add(node); 

			#endregion
			#region SDCaseFile
			  plural = "";
            single = "";
            entityText = entityTexts.FirstOrDefault(p => p.EntityKey == "SDCaseFile");
            if (entityText != null)
            {
                plural = entityText.PluralName;
                single = entityText.Name;
            }

            node = new DynamicNode();
            node.Title = !string.IsNullOrEmpty(plural) ? plural : "SDCaseFiles";
		
		       node.Controller = "SDCaseFiles";
            node.Area = "SFSServiceDesk";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_SDCaseFile_List";
			//node.CacheResolvedUrl = true;
			node.ParentKey = "SFSServiceDesk_all_catalogs";
 			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCaseFile");
            node.Attributes.Add("permissionKey", "r");            
			nodes.Add(node);

			
			// Create
			node = new DynamicNode();
            node.Title =GlobalMessages.ADD_NEW;
            node.Controller = "SDCaseFiles";
            node.Area = "SFSServiceDesk";
            node.Action = "CreateGen";
            node.Key = "SFSServiceDesk_SDCaseFile_Create";
			node.ParentKey = "SFSServiceDesk_SDCaseFile_List";
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCaseFile");
			node.Attributes.Add("visiblemenu", "false");
			
			
            nodes.Add(node);

			// Edit
			//node = new DynamicNode();
            //node.Title = SDCaseFileResources.SDCASEFILES_EDIT;
            //node.Controller = "SDCaseFiles";
            //node.Area = "SFSServiceDesk";
            //node.Action = "EditGen";
            //node.Key = "SFSServiceDesk_SDCaseFile_Edit";
			//node.ParentKey = "SFSServiceDesk_SDCaseFile_List";
			//node.Attributes.Add("visible", "false");
			//node.Attributes.Add("dynamicParameters", "id");
			//node.Attributes.Add("isDynamic", "true");
            //nodes.Add(node);

			// Details
			node = new DynamicNode();
           //node.Title = !string.IsNullOrEmpty(single) ? single : "SDCaseFile";
            node.Controller = "SDCaseFiles";
            node.Area = "SFSServiceDesk";
            node.Action = "DetailsGen";
            node.Key = "SFSServiceDesk_SDCaseFile_Details";
			node.ParentKey = "SFSServiceDesk_SDCaseFile_List";
			node.Attributes.Add("visible", "false");
			node.Attributes.Add("dynamicParameters", "id");
			node.Attributes.Add("isDynamic", "true");
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCaseFile");
			node.PreservedRouteParameters.Add("id");
            nodes.Add(node); 

			#endregion
			#region SDCaseHistory
			  plural = "";
            single = "";
            entityText = entityTexts.FirstOrDefault(p => p.EntityKey == "SDCaseHistory");
            if (entityText != null)
            {
                plural = entityText.PluralName;
                single = entityText.Name;
            }

            node = new DynamicNode();
            node.Title = !string.IsNullOrEmpty(plural) ? plural : "SDCaseHistories";
		
		       node.Controller = "SDCaseHistories";
            node.Area = "SFSServiceDesk";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_SDCaseHistory_List";
			//node.CacheResolvedUrl = true;
			node.ParentKey = "SFSServiceDesk_all_catalogs";
 			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCaseHistory");
            node.Attributes.Add("permissionKey", "r");            
			nodes.Add(node);

			
			// Create
			node = new DynamicNode();
            node.Title =GlobalMessages.ADD_NEW;
            node.Controller = "SDCaseHistories";
            node.Area = "SFSServiceDesk";
            node.Action = "CreateGen";
            node.Key = "SFSServiceDesk_SDCaseHistory_Create";
			node.ParentKey = "SFSServiceDesk_SDCaseHistory_List";
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCaseHistory");
			node.Attributes.Add("visiblemenu", "false");
			
			
            nodes.Add(node);

			// Edit
			//node = new DynamicNode();
            //node.Title = SDCaseHistoryResources.SDCASEHISTORIES_EDIT;
            //node.Controller = "SDCaseHistories";
            //node.Area = "SFSServiceDesk";
            //node.Action = "EditGen";
            //node.Key = "SFSServiceDesk_SDCaseHistory_Edit";
			//node.ParentKey = "SFSServiceDesk_SDCaseHistory_List";
			//node.Attributes.Add("visible", "false");
			//node.Attributes.Add("dynamicParameters", "id");
			//node.Attributes.Add("isDynamic", "true");
            //nodes.Add(node);

			// Details
			node = new DynamicNode();
           //node.Title = !string.IsNullOrEmpty(single) ? single : "SDCaseHistory";
            node.Controller = "SDCaseHistories";
            node.Area = "SFSServiceDesk";
            node.Action = "DetailsGen";
            node.Key = "SFSServiceDesk_SDCaseHistory_Details";
			node.ParentKey = "SFSServiceDesk_SDCaseHistory_List";
			node.Attributes.Add("visible", "false");
			node.Attributes.Add("dynamicParameters", "id");
			node.Attributes.Add("isDynamic", "true");
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCaseHistory");
			node.PreservedRouteParameters.Add("id");
            nodes.Add(node); 

			#endregion
			#region SDCaseHistoryFile
			  plural = "";
            single = "";
            entityText = entityTexts.FirstOrDefault(p => p.EntityKey == "SDCaseHistoryFile");
            if (entityText != null)
            {
                plural = entityText.PluralName;
                single = entityText.Name;
            }

            node = new DynamicNode();
            node.Title = !string.IsNullOrEmpty(plural) ? plural : "SDCaseHistoryFiles";
		
		       node.Controller = "SDCaseHistoryFiles";
            node.Area = "SFSServiceDesk";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_SDCaseHistoryFile_List";
			//node.CacheResolvedUrl = true;
			node.ParentKey = "SFSServiceDesk_all_catalogs";
 			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCaseHistoryFile");
            node.Attributes.Add("permissionKey", "r");            
			nodes.Add(node);

			
			// Create
			node = new DynamicNode();
            node.Title =GlobalMessages.ADD_NEW;
            node.Controller = "SDCaseHistoryFiles";
            node.Area = "SFSServiceDesk";
            node.Action = "CreateGen";
            node.Key = "SFSServiceDesk_SDCaseHistoryFile_Create";
			node.ParentKey = "SFSServiceDesk_SDCaseHistoryFile_List";
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCaseHistoryFile");
			node.Attributes.Add("visiblemenu", "false");
			
			
            nodes.Add(node);

			// Edit
			//node = new DynamicNode();
            //node.Title = SDCaseHistoryFileResources.SDCASEHISTORYFILES_EDIT;
            //node.Controller = "SDCaseHistoryFiles";
            //node.Area = "SFSServiceDesk";
            //node.Action = "EditGen";
            //node.Key = "SFSServiceDesk_SDCaseHistoryFile_Edit";
			//node.ParentKey = "SFSServiceDesk_SDCaseHistoryFile_List";
			//node.Attributes.Add("visible", "false");
			//node.Attributes.Add("dynamicParameters", "id");
			//node.Attributes.Add("isDynamic", "true");
            //nodes.Add(node);

			// Details
			node = new DynamicNode();
           //node.Title = !string.IsNullOrEmpty(single) ? single : "SDCaseHistoryFile";
            node.Controller = "SDCaseHistoryFiles";
            node.Area = "SFSServiceDesk";
            node.Action = "DetailsGen";
            node.Key = "SFSServiceDesk_SDCaseHistoryFile_Details";
			node.ParentKey = "SFSServiceDesk_SDCaseHistoryFile_List";
			node.Attributes.Add("visible", "false");
			node.Attributes.Add("dynamicParameters", "id");
			node.Attributes.Add("isDynamic", "true");
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCaseHistoryFile");
			node.PreservedRouteParameters.Add("id");
            nodes.Add(node); 

			#endregion
			#region SDCasePriority
			  plural = "";
            single = "";
            entityText = entityTexts.FirstOrDefault(p => p.EntityKey == "SDCasePriority");
            if (entityText != null)
            {
                plural = entityText.PluralName;
                single = entityText.Name;
            }

            node = new DynamicNode();
            node.Title = !string.IsNullOrEmpty(plural) ? plural : "SDCasePriorities";
		
		       node.Controller = "SDCasePriorities";
            node.Area = "SFSServiceDesk";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_SDCasePriority_List";
			//node.CacheResolvedUrl = true;
			node.ParentKey = "SFSServiceDesk_all_catalogs";
 			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCasePriority");
            node.Attributes.Add("permissionKey", "r");            
			nodes.Add(node);

			
			// Create
			node = new DynamicNode();
            node.Title =GlobalMessages.ADD_NEW;
            node.Controller = "SDCasePriorities";
            node.Area = "SFSServiceDesk";
            node.Action = "CreateGen";
            node.Key = "SFSServiceDesk_SDCasePriority_Create";
			node.ParentKey = "SFSServiceDesk_SDCasePriority_List";
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCasePriority");
			node.Attributes.Add("visiblemenu", "false");
			
			
            nodes.Add(node);

			// Edit
			//node = new DynamicNode();
            //node.Title = SDCasePriorityResources.SDCASEPRIORITIES_EDIT;
            //node.Controller = "SDCasePriorities";
            //node.Area = "SFSServiceDesk";
            //node.Action = "EditGen";
            //node.Key = "SFSServiceDesk_SDCasePriority_Edit";
			//node.ParentKey = "SFSServiceDesk_SDCasePriority_List";
			//node.Attributes.Add("visible", "false");
			//node.Attributes.Add("dynamicParameters", "id");
			//node.Attributes.Add("isDynamic", "true");
            //nodes.Add(node);

			// Details
			node = new DynamicNode();
           //node.Title = !string.IsNullOrEmpty(single) ? single : "SDCasePriority";
            node.Controller = "SDCasePriorities";
            node.Area = "SFSServiceDesk";
            node.Action = "DetailsGen";
            node.Key = "SFSServiceDesk_SDCasePriority_Details";
			node.ParentKey = "SFSServiceDesk_SDCasePriority_List";
			node.Attributes.Add("visible", "false");
			node.Attributes.Add("dynamicParameters", "id");
			node.Attributes.Add("isDynamic", "true");
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCasePriority");
			node.PreservedRouteParameters.Add("id");
            nodes.Add(node); 

			#endregion
			#region SDCaseStatu
			  plural = "";
            single = "";
            entityText = entityTexts.FirstOrDefault(p => p.EntityKey == "SDCaseStatu");
            if (entityText != null)
            {
                plural = entityText.PluralName;
                single = entityText.Name;
            }

            node = new DynamicNode();
            node.Title = !string.IsNullOrEmpty(plural) ? plural : "SDCaseStatus";
		
		       node.Controller = "SDCaseStatus";
            node.Area = "SFSServiceDesk";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_SDCaseStatu_List";
			//node.CacheResolvedUrl = true;
			node.ParentKey = "SFSServiceDesk_all_catalogs";
 			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCaseStatu");
            node.Attributes.Add("permissionKey", "r");            
			nodes.Add(node);

			
			// Create
			node = new DynamicNode();
            node.Title =GlobalMessages.ADD_NEW;
            node.Controller = "SDCaseStatus";
            node.Area = "SFSServiceDesk";
            node.Action = "CreateGen";
            node.Key = "SFSServiceDesk_SDCaseStatu_Create";
			node.ParentKey = "SFSServiceDesk_SDCaseStatu_List";
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCaseStatu");
			node.Attributes.Add("visiblemenu", "false");
			
			
            nodes.Add(node);

			// Edit
			//node = new DynamicNode();
            //node.Title = SDCaseStatuResources.SDCASESTATUS_EDIT;
            //node.Controller = "SDCaseStatus";
            //node.Area = "SFSServiceDesk";
            //node.Action = "EditGen";
            //node.Key = "SFSServiceDesk_SDCaseStatu_Edit";
			//node.ParentKey = "SFSServiceDesk_SDCaseStatu_List";
			//node.Attributes.Add("visible", "false");
			//node.Attributes.Add("dynamicParameters", "id");
			//node.Attributes.Add("isDynamic", "true");
            //nodes.Add(node);

			// Details
			node = new DynamicNode();
           //node.Title = !string.IsNullOrEmpty(single) ? single : "SDCaseStatu";
            node.Controller = "SDCaseStatus";
            node.Area = "SFSServiceDesk";
            node.Action = "DetailsGen";
            node.Key = "SFSServiceDesk_SDCaseStatu_Details";
			node.ParentKey = "SFSServiceDesk_SDCaseStatu_List";
			node.Attributes.Add("visible", "false");
			node.Attributes.Add("dynamicParameters", "id");
			node.Attributes.Add("isDynamic", "true");
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDCaseStatu");
			node.PreservedRouteParameters.Add("id");
            nodes.Add(node); 

			#endregion
			#region SDFile
			  plural = "";
            single = "";
            entityText = entityTexts.FirstOrDefault(p => p.EntityKey == "SDFile");
            if (entityText != null)
            {
                plural = entityText.PluralName;
                single = entityText.Name;
            }

            node = new DynamicNode();
            node.Title = !string.IsNullOrEmpty(plural) ? plural : "SDFiles";
		
		       node.Controller = "SDFiles";
            node.Area = "SFSServiceDesk";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_SDFile_List";
			//node.CacheResolvedUrl = true;
			node.ParentKey = "SFSServiceDesk_all_catalogs";
 			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDFile");
            node.Attributes.Add("permissionKey", "r");            
			nodes.Add(node);

			
			// Create
			node = new DynamicNode();
            node.Title =GlobalMessages.ADD_NEW;
            node.Controller = "SDFiles";
            node.Area = "SFSServiceDesk";
            node.Action = "CreateGen";
            node.Key = "SFSServiceDesk_SDFile_Create";
			node.ParentKey = "SFSServiceDesk_SDFile_List";
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDFile");
			node.Attributes.Add("visiblemenu", "false");
			
			
            nodes.Add(node);

			// Edit
			//node = new DynamicNode();
            //node.Title = SDFileResources.SDFILES_EDIT;
            //node.Controller = "SDFiles";
            //node.Area = "SFSServiceDesk";
            //node.Action = "EditGen";
            //node.Key = "SFSServiceDesk_SDFile_Edit";
			//node.ParentKey = "SFSServiceDesk_SDFile_List";
			//node.Attributes.Add("visible", "false");
			//node.Attributes.Add("dynamicParameters", "id");
			//node.Attributes.Add("isDynamic", "true");
            //nodes.Add(node);

			// Details
			node = new DynamicNode();
           //node.Title = !string.IsNullOrEmpty(single) ? single : "SDFile";
            node.Controller = "SDFiles";
            node.Area = "SFSServiceDesk";
            node.Action = "DetailsGen";
            node.Key = "SFSServiceDesk_SDFile_Details";
			node.ParentKey = "SFSServiceDesk_SDFile_List";
			node.Attributes.Add("visible", "false");
			node.Attributes.Add("dynamicParameters", "id");
			node.Attributes.Add("isDynamic", "true");
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDFile");
			node.PreservedRouteParameters.Add("id");
            nodes.Add(node); 

			#endregion
			#region SDOrganization
			  plural = "";
            single = "";
            entityText = entityTexts.FirstOrDefault(p => p.EntityKey == "SDOrganization");
            if (entityText != null)
            {
                plural = entityText.PluralName;
                single = entityText.Name;
            }

            node = new DynamicNode();
            node.Title = !string.IsNullOrEmpty(plural) ? plural : "SDOrganizations";
		
		       node.Controller = "SDOrganizations";
            node.Area = "SFSServiceDesk";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_SDOrganization_List";
			//node.CacheResolvedUrl = true;
			node.ParentKey = "SFSServiceDesk_all_catalogs";
 			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDOrganization");
            node.Attributes.Add("permissionKey", "r");            
			nodes.Add(node);

			
			// Create
			node = new DynamicNode();
            node.Title =GlobalMessages.ADD_NEW;
            node.Controller = "SDOrganizations";
            node.Area = "SFSServiceDesk";
            node.Action = "CreateGen";
            node.Key = "SFSServiceDesk_SDOrganization_Create";
			node.ParentKey = "SFSServiceDesk_SDOrganization_List";
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDOrganization");
			node.Attributes.Add("visiblemenu", "false");
			
			
            nodes.Add(node);

			// Edit
			//node = new DynamicNode();
            //node.Title = SDOrganizationResources.SDORGANIZATIONS_EDIT;
            //node.Controller = "SDOrganizations";
            //node.Area = "SFSServiceDesk";
            //node.Action = "EditGen";
            //node.Key = "SFSServiceDesk_SDOrganization_Edit";
			//node.ParentKey = "SFSServiceDesk_SDOrganization_List";
			//node.Attributes.Add("visible", "false");
			//node.Attributes.Add("dynamicParameters", "id");
			//node.Attributes.Add("isDynamic", "true");
            //nodes.Add(node);

			// Details
			node = new DynamicNode();
           //node.Title = !string.IsNullOrEmpty(single) ? single : "SDOrganization";
            node.Controller = "SDOrganizations";
            node.Area = "SFSServiceDesk";
            node.Action = "DetailsGen";
            node.Key = "SFSServiceDesk_SDOrganization_Details";
			node.ParentKey = "SFSServiceDesk_SDOrganization_List";
			node.Attributes.Add("visible", "false");
			node.Attributes.Add("dynamicParameters", "id");
			node.Attributes.Add("isDynamic", "true");
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDOrganization");
			node.PreservedRouteParameters.Add("id");
            nodes.Add(node); 

			#endregion
			#region SDPerson
			  plural = "";
            single = "";
            entityText = entityTexts.FirstOrDefault(p => p.EntityKey == "SDPerson");
            if (entityText != null)
            {
                plural = entityText.PluralName;
                single = entityText.Name;
            }

            node = new DynamicNode();
            node.Title = !string.IsNullOrEmpty(plural) ? plural : "SDPersons";
		
		       node.Controller = "SDPersons";
            node.Area = "SFSServiceDesk";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_SDPerson_List";
			//node.CacheResolvedUrl = true;
			node.ParentKey = "SFSServiceDesk_all_catalogs";
 			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDPerson");
            node.Attributes.Add("permissionKey", "r");            
			nodes.Add(node);

			
			// Create
			node = new DynamicNode();
            node.Title =GlobalMessages.ADD_NEW;
            node.Controller = "SDPersons";
            node.Area = "SFSServiceDesk";
            node.Action = "CreateGen";
            node.Key = "SFSServiceDesk_SDPerson_Create";
			node.ParentKey = "SFSServiceDesk_SDPerson_List";
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDPerson");
			node.Attributes.Add("visiblemenu", "false");
			
			
            nodes.Add(node);

			// Edit
			//node = new DynamicNode();
            //node.Title = SDPersonResources.SDPERSONS_EDIT;
            //node.Controller = "SDPersons";
            //node.Area = "SFSServiceDesk";
            //node.Action = "EditGen";
            //node.Key = "SFSServiceDesk_SDPerson_Edit";
			//node.ParentKey = "SFSServiceDesk_SDPerson_List";
			//node.Attributes.Add("visible", "false");
			//node.Attributes.Add("dynamicParameters", "id");
			//node.Attributes.Add("isDynamic", "true");
            //nodes.Add(node);

			// Details
			node = new DynamicNode();
           //node.Title = !string.IsNullOrEmpty(single) ? single : "SDPerson";
            node.Controller = "SDPersons";
            node.Area = "SFSServiceDesk";
            node.Action = "DetailsGen";
            node.Key = "SFSServiceDesk_SDPerson_Details";
			node.ParentKey = "SFSServiceDesk_SDPerson_List";
			node.Attributes.Add("visible", "false");
			node.Attributes.Add("dynamicParameters", "id");
			node.Attributes.Add("isDynamic", "true");
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDPerson");
			node.PreservedRouteParameters.Add("id");
            nodes.Add(node); 

			#endregion
			#region SDProxyUser
			  plural = "";
            single = "";
            entityText = entityTexts.FirstOrDefault(p => p.EntityKey == "SDProxyUser");
            if (entityText != null)
            {
                plural = entityText.PluralName;
                single = entityText.Name;
            }

            node = new DynamicNode();
            node.Title = !string.IsNullOrEmpty(plural) ? plural : "SDProxyUsers";
		
		       node.Controller = "SDProxyUsers";
            node.Area = "SFSServiceDesk";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_SDProxyUser_List";
			//node.CacheResolvedUrl = true;
			node.ParentKey = "SFSServiceDesk_all_catalogs";
 			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDProxyUser");
            node.Attributes.Add("permissionKey", "r");            
			nodes.Add(node);

			
			// Create
			node = new DynamicNode();
            node.Title =GlobalMessages.ADD_NEW;
            node.Controller = "SDProxyUsers";
            node.Area = "SFSServiceDesk";
            node.Action = "CreateGen";
            node.Key = "SFSServiceDesk_SDProxyUser_Create";
			node.ParentKey = "SFSServiceDesk_SDProxyUser_List";
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDProxyUser");
			node.Attributes.Add("visiblemenu", "false");
			
			
            nodes.Add(node);

			// Edit
			//node = new DynamicNode();
            //node.Title = SDProxyUserResources.SDPROXYUSERS_EDIT;
            //node.Controller = "SDProxyUsers";
            //node.Area = "SFSServiceDesk";
            //node.Action = "EditGen";
            //node.Key = "SFSServiceDesk_SDProxyUser_Edit";
			//node.ParentKey = "SFSServiceDesk_SDProxyUser_List";
			//node.Attributes.Add("visible", "false");
			//node.Attributes.Add("dynamicParameters", "id");
			//node.Attributes.Add("isDynamic", "true");
            //nodes.Add(node);

			// Details
			node = new DynamicNode();
           //node.Title = !string.IsNullOrEmpty(single) ? single : "SDProxyUser";
            node.Controller = "SDProxyUsers";
            node.Area = "SFSServiceDesk";
            node.Action = "DetailsGen";
            node.Key = "SFSServiceDesk_SDProxyUser_Details";
			node.ParentKey = "SFSServiceDesk_SDProxyUser_List";
			node.Attributes.Add("visible", "false");
			node.Attributes.Add("dynamicParameters", "id");
			node.Attributes.Add("isDynamic", "true");
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.Attributes.Add("businessObjectKey", "SDProxyUser");
			node.PreservedRouteParameters.Add("id");
            nodes.Add(node); 

			#endregion

 			OnCreatedNodes(this, ref nodes);
			
			node = new DynamicNode();
            //node.Title = SFSdotNet.Framework.Web.Mvc.Resources.GlobalMessages.SYSTEM;
            node.Controller = "Navigation";
            node.Area = "";
            node.Action = "Index";
            node.Key = "SFSServiceDesk_System_override";
            node.RouteValues.Add("id", node.Key);
            node.RouteValues.Add("overrideModule", "SFSServiceDesk");
            
			node.ParentKey = "SFSServiceDesk";
			node.Attributes.Add("moduleKey", "SFSServiceDesk");
			 node.Attributes.Add("permissionKey", "admin");
			 textUI.SetTextTo(node, "Title", typeof(SFSdotNet.Framework.Web.Mvc.Resources.GlobalMessages), "SYSTEM");

            nodes.Add(node);



			  node = new DynamicNode();
            //node.Title = SFSdotNet.Framework.Web.Mvc.Resources.GlobalMessages.USERS_AND_ROLES ;
            node.Controller = "secRoles";
            node.Area = "SFSdotNetFrameworkSecurity";
            node.Action = "Index";
            node.Key = "SFSdotNetFrameworkSecurity_SFSServiceDesk_roles";
            node.ParentKey = "SFSServiceDesk_System_override";
            node.Attributes.Add("moduleKey", "SFSServiceDesk");
                      node.RouteValues.Add("overrideModule", "SFSServiceDesk");
            node.Attributes.Add("permissionKey", "admin");
            textUI.SetTextTo(node, "Title", typeof(SFSdotNet.Framework.Web.Mvc.Resources.GlobalMessages), "ROLES");

            nodes.Add(node);




			 node = new DynamicNode();
            //node.Title = SFSdotNet.Framework.Web.Mvc.Resources.GlobalMessages.USERS_AND_ROLES ;
            node.Controller = "secUserCompanies";
            node.Area = "SFSdotNetFrameworkSecurity";
            node.Action = "Index";
            node.Key = "SFSdotNetFrameworkSecurity_SFSServiceDesk_user_companies";
            node.ParentKey = "SFSServiceDesk_System_override";
            node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.RouteValues.Add("overrideModule", "SFSServiceDesk");
            node.Attributes.Add("permissionKey", "admin");
			textUI.SetTextTo(node, "Title", typeof(SFSdotNet.Framework.Web.Mvc.Resources.GlobalMessages), "USERS_AND_ROLES");

            nodes.Add(node);

			
			 node = new DynamicNode();
            node.Controller = "secCompanies";
            node.Area = "SFSdotNetFrameworkSecurity";
            node.Action = "Index";
            node.Key = "SFSdotNetFrameworkSecurity_SFSServiceDesk_child_companies";
            node.ParentKey = "SFSServiceDesk_System_override";
            node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.RouteValues.Add("overrideModule", "SFSServiceDesk");
			node.RouteValues.Add("usemode", "children");
            node.Attributes.Add("permissionKey", "admin");
			textUI.SetTextTo(node, "Title", typeof(SFSdotNet.Framework.Web.Mvc.Resources.GlobalMessages), "COMPANIES_CHILDS");

            nodes.Add(node);
			 node = new DynamicNode();
            //node.Title = SFSdotNet.Framework.Web.Mvc.Resources.GlobalMessages.EVENT_LOG;
            node.Controller = "secEventLogs";
            node.Area = "SFSdotNetFrameworkSecurity";
            node.Action = "Index";
            node.Key = "SFSdotNetFrameworkSecurity_SFSServiceDesk_EventLogs";
            node.ParentKey = "SFSServiceDesk_System_override";
            node.Attributes.Add("moduleKey", "SFSServiceDesk");

            node.RouteValues.Add("overrideModule", "SFSServiceDesk");

			
            node.Attributes.Add("permissionKey", "admin");
			textUI.SetTextTo(node, "Title", typeof(SFSdotNet.Framework.Web.Mvc.Resources.GlobalMessages), "EVENT_LOG");

            nodes.Add(node);
			 node = new DynamicNode();
            //node.Title = SFSdotNet.Framework.Web.Mvc.Resources.GlobalMessages.EVENT_LOG;
            node.Controller = "Dashboard";
            node.Area = "SFSdotNetFrameworkSecurity";
            node.Action = "Statics";
            node.Key = "SFSdotNetFrameworkSecurity_SFSServiceDesk_Statics";
            node.ParentKey = "SFSServiceDesk_System_override";
            node.Attributes.Add("moduleKey", "SFSServiceDesk");

            node.RouteValues.Add("overrideModule", "SFSServiceDesk");
            node.Attributes.Add("permissionKey", "admin");
            textUI.SetTextTo(node, "Title", typeof(SFSdotNet.Framework.Web.Mvc.Resources.GlobalMessages), "SERVICE_USE_STATICS");

            nodes.Add(node);


			 node = new DynamicNode();
           // node.Title = SFSdotNet.Framework.Web.Mvc.Resources.GlobalMessages.CHANGE_AUDITING;
            node.Controller = "secAudits";
            node.Area = "SFSdotNetFrameworkSecurity";
            node.Action = "Index";
            node.Key = "SFSdotNetFrameworkSecurity_SFSServiceDesk_ChangeAutiting";
            node.ParentKey = "SFSServiceDesk_System_override";
            node.Attributes.Add("moduleKey", "SFSServiceDesk");
            node.RouteValues.Add("overrideModule", "SFSServiceDesk");
            node.Attributes.Add("permissionKey", "admin");
			 textUI.SetTextTo(node, "Title", typeof(SFSdotNet.Framework.Web.Mvc.Resources.GlobalMessages), "CHANGE_AUDITING");

            nodes.Add(node);




            return nodes;
        }
    }
}
