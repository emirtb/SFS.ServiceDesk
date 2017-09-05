 
 

#region using
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFS.ServiceDesk.Client.Models;

using System.Configuration;
using System.Collections.Generic;

#endregion
namespace SFS.ServiceDesk.Tests
{

	 [TestClass]
	  public class AllBasicTests
	  {
	    private string url = null;
        public AllBasicTests()
        {
            url = ConfigurationManager.AppSettings["urlApp"];
        }
		private ApiWrapper<TModel> GetWrapper<TModel>() where TModel:class 
        {
            
            ApiWrapper<TModel> apiWrapper = new ApiWrapper<TModel>();
            apiWrapper.Username = ConfigurationManager.AppSettings["username"];
            apiWrapper.Password = ConfigurationManager.AppSettings["password"];
            apiWrapper.CompanyId = ConfigurationManager.AppSettings["companyId"];
            return apiWrapper;
        }
	public SDCasePriority SDCasePrioritySample(){
		 SDCasePriority item = new SDCasePriority();
            item.GuidCasePriority = Guid.NewGuid();

            item.Title = Utils.GetString(10);








		return item;
	}
 [TestMethod]
  public void  SDCasePriorityCreate()
  {
            this. SDCasePriorityCreate(null, null);
   }

	[TestMethod]
	 public void SDCasePriorityCreate( List<SDCasePriority> items, SDCasePriority item )
        {
            var apiWrapper = GetWrapper<SDCasePriority>();
            apiWrapper.EntityKeyName = "SDCasePriority";
            apiWrapper.EntitySetName  = "SDCasePriorities";
			if (item == null && items == null)
            {
				apiWrapper.Item = SDCasePrioritySample();
			}else{
				apiWrapper.Item = item;
                apiWrapper.Items = items;
			}
            var resultCreate  = Services.ApiCreate(url, apiWrapper);
			Assert.IsTrue(resultCreate == "ok");
			if (apiWrapper.Item != null)
            {
				apiWrapper.ItemKey = apiWrapper.Item.GuidCasePriority;
				var existent = Services.ApiGetByKey<SDCasePriority>(url, apiWrapper);
				Assert.IsNotNull(existent);
			}
            
        }
	public SDCaseState SDCaseStateSample(){
		 SDCaseState item = new SDCaseState();
            item.GuidCaseState = Guid.NewGuid();

            item.Title = Utils.GetString(10);








		return item;
	}
 [TestMethod]
  public void  SDCaseStateCreate()
  {
            this. SDCaseStateCreate(null, null);
   }

	[TestMethod]
	 public void SDCaseStateCreate( List<SDCaseState> items, SDCaseState item )
        {
            var apiWrapper = GetWrapper<SDCaseState>();
            apiWrapper.EntityKeyName = "SDCaseState";
            apiWrapper.EntitySetName  = "SDCaseStates";
			if (item == null && items == null)
            {
				apiWrapper.Item = SDCaseStateSample();
			}else{
				apiWrapper.Item = item;
                apiWrapper.Items = items;
			}
            var resultCreate  = Services.ApiCreate(url, apiWrapper);
			Assert.IsTrue(resultCreate == "ok");
			if (apiWrapper.Item != null)
            {
				apiWrapper.ItemKey = apiWrapper.Item.GuidCaseState;
				var existent = Services.ApiGetByKey<SDCaseState>(url, apiWrapper);
				Assert.IsNotNull(existent);
			}
            
        }
	public SDFile SDFileSample(){
		 SDFile item = new SDFile();
            item.GuidFile = Guid.NewGuid();

            item.FileName = Utils.GetString(10);

            item.FileType = Utils.GetString(10);

            item.FileSize = Utils.GetInt();









            item.FileStorage = Utils.GetString(10);

		return item;
	}
 [TestMethod]
  public void  SDFileCreate()
  {
            this. SDFileCreate(null, null);
   }

	[TestMethod]
	 public void SDFileCreate( List<SDFile> items, SDFile item )
        {
            var apiWrapper = GetWrapper<SDFile>();
            apiWrapper.EntityKeyName = "SDFile";
            apiWrapper.EntitySetName  = "SDFiles";
			if (item == null && items == null)
            {
				apiWrapper.Item = SDFileSample();
			}else{
				apiWrapper.Item = item;
                apiWrapper.Items = items;
			}
            var resultCreate  = Services.ApiCreate(url, apiWrapper);
			Assert.IsTrue(resultCreate == "ok");
			if (apiWrapper.Item != null)
            {
				apiWrapper.ItemKey = apiWrapper.Item.GuidFile;
				var existent = Services.ApiGetByKey<SDFile>(url, apiWrapper);
				Assert.IsNotNull(existent);
			}
            
        }
	public SDOrganization SDOrganizationSample(){
		 SDOrganization item = new SDOrganization();
            item.GuidOrganization = Guid.NewGuid();

            item.FullName = Utils.GetString(10);








		return item;
	}
 [TestMethod]
  public void  SDOrganizationCreate()
  {
            this. SDOrganizationCreate(null, null);
   }

	[TestMethod]
	 public void SDOrganizationCreate( List<SDOrganization> items, SDOrganization item )
        {
            var apiWrapper = GetWrapper<SDOrganization>();
            apiWrapper.EntityKeyName = "SDOrganization";
            apiWrapper.EntitySetName  = "SDOrganizations";
			if (item == null && items == null)
            {
				apiWrapper.Item = SDOrganizationSample();
			}else{
				apiWrapper.Item = item;
                apiWrapper.Items = items;
			}
            var resultCreate  = Services.ApiCreate(url, apiWrapper);
			Assert.IsTrue(resultCreate == "ok");
			if (apiWrapper.Item != null)
            {
				apiWrapper.ItemKey = apiWrapper.Item.GuidOrganization;
				var existent = Services.ApiGetByKey<SDOrganization>(url, apiWrapper);
				Assert.IsNotNull(existent);
			}
            
        }
	public SDProxyUser SDProxyUserSample(){
		 SDProxyUser item = new SDProxyUser();
            item.GuidUser = Guid.NewGuid();

            item.Email = Utils.GetString(10);

            item.DisplayName = Utils.GetString(10);

		return item;
	}
 [TestMethod]
  public void  SDProxyUserCreate()
  {
            this. SDProxyUserCreate(null, null);
   }

	[TestMethod]
	 public void SDProxyUserCreate( List<SDProxyUser> items, SDProxyUser item )
        {
            var apiWrapper = GetWrapper<SDProxyUser>();
            apiWrapper.EntityKeyName = "SDProxyUser";
            apiWrapper.EntitySetName  = "SDProxyUsers";
			if (item == null && items == null)
            {
				apiWrapper.Item = SDProxyUserSample();
			}else{
				apiWrapper.Item = item;
                apiWrapper.Items = items;
			}
            var resultCreate  = Services.ApiCreate(url, apiWrapper);
			Assert.IsTrue(resultCreate == "ok");
			if (apiWrapper.Item != null)
            {
				apiWrapper.ItemKey = apiWrapper.Item.GuidUser;
				var existent = Services.ApiGetByKey<SDProxyUser>(url, apiWrapper);
				Assert.IsNotNull(existent);
			}
            
        }
	public SDArea SDAreaSample(){
		 SDArea item = new SDArea();
            item.GuidArea = Guid.NewGuid();

            item.Name = Utils.GetString(10);










		return item;
	}
 [TestMethod]
  public void  SDAreaCreate()
  {
            this. SDAreaCreate(null, null);
   }

	[TestMethod]
	 public void SDAreaCreate( List<SDArea> items, SDArea item )
        {
            var apiWrapper = GetWrapper<SDArea>();
            apiWrapper.EntityKeyName = "SDArea";
            apiWrapper.EntitySetName  = "SDAreas";
			if (item == null && items == null)
            {
				apiWrapper.Item = SDAreaSample();
			}else{
				apiWrapper.Item = item;
                apiWrapper.Items = items;
			}
            var resultCreate  = Services.ApiCreate(url, apiWrapper);
			Assert.IsTrue(resultCreate == "ok");
			if (apiWrapper.Item != null)
            {
				apiWrapper.ItemKey = apiWrapper.Item.GuidArea;
				var existent = Services.ApiGetByKey<SDArea>(url, apiWrapper);
				Assert.IsNotNull(existent);
			}
            
        }
	public SDPerson SDPersonSample(){
		 SDPerson item = new SDPerson();
            item.GuidPerson = Guid.NewGuid();

            item.DisplayName = Utils.GetString(10);










		return item;
	}
 [TestMethod]
  public void  SDPersonCreate()
  {
            this. SDPersonCreate(null, null);
   }

	[TestMethod]
	 public void SDPersonCreate( List<SDPerson> items, SDPerson item )
        {
            var apiWrapper = GetWrapper<SDPerson>();
            apiWrapper.EntityKeyName = "SDPerson";
            apiWrapper.EntitySetName  = "SDPersons";
			if (item == null && items == null)
            {
				apiWrapper.Item = SDPersonSample();
			}else{
				apiWrapper.Item = item;
                apiWrapper.Items = items;
			}
            var resultCreate  = Services.ApiCreate(url, apiWrapper);
			Assert.IsTrue(resultCreate == "ok");
			if (apiWrapper.Item != null)
            {
				apiWrapper.ItemKey = apiWrapper.Item.GuidPerson;
				var existent = Services.ApiGetByKey<SDPerson>(url, apiWrapper);
				Assert.IsNotNull(existent);
			}
            
        }
	public SDAreaPerson SDAreaPersonSample(){
		 SDAreaPerson item = new SDAreaPerson();
            item.GuidAreaPerson = Guid.NewGuid();










		return item;
	}
 [TestMethod]
  public void  SDAreaPersonCreate()
  {
            this. SDAreaPersonCreate(null, null);
   }

	[TestMethod]
	 public void SDAreaPersonCreate( List<SDAreaPerson> items, SDAreaPerson item )
        {
            var apiWrapper = GetWrapper<SDAreaPerson>();
            apiWrapper.EntityKeyName = "SDAreaPerson";
            apiWrapper.EntitySetName  = "SDAreaPersons";
			if (item == null && items == null)
            {
				apiWrapper.Item = SDAreaPersonSample();
			}else{
				apiWrapper.Item = item;
                apiWrapper.Items = items;
			}
            var resultCreate  = Services.ApiCreate(url, apiWrapper);
			Assert.IsTrue(resultCreate == "ok");
			if (apiWrapper.Item != null)
            {
				apiWrapper.ItemKey = apiWrapper.Item.GuidAreaPerson;
				var existent = Services.ApiGetByKey<SDAreaPerson>(url, apiWrapper);
				Assert.IsNotNull(existent);
			}
            
        }
	public SDCase SDCaseSample(){
		 SDCase item = new SDCase();
            item.GuidCase = Guid.NewGuid();



            item.ClosedDateTime = Utils.GetDateTime();
			

            item.BodyContent = Utils.GetString(10);

            item.PreviewContent = Utils.GetString(10);


            item.Title = Utils.GetString(10);








		return item;
	}
 [TestMethod]
  public void  SDCaseCreate()
  {
            this. SDCaseCreate(null, null);
   }

	[TestMethod]
	 public void SDCaseCreate( List<SDCase> items, SDCase item )
        {
            var apiWrapper = GetWrapper<SDCase>();
            apiWrapper.EntityKeyName = "SDCase";
            apiWrapper.EntitySetName  = "SDCases";
			if (item == null && items == null)
            {
				apiWrapper.Item = SDCaseSample();
			}else{
				apiWrapper.Item = item;
                apiWrapper.Items = items;
			}
            var resultCreate  = Services.ApiCreate(url, apiWrapper);
			Assert.IsTrue(resultCreate == "ok");
			if (apiWrapper.Item != null)
            {
				apiWrapper.ItemKey = apiWrapper.Item.GuidCase;
				var existent = Services.ApiGetByKey<SDCase>(url, apiWrapper);
				Assert.IsNotNull(existent);
			}
            
        }
	public SDCaseFile SDCaseFileSample(){
		 SDCaseFile item = new SDCaseFile();
            item.GuidCasefile = Guid.NewGuid();










            item.UrlFile = Utils.GetString(10);

            item.UrlThumbFile = Utils.GetString(10);


            item.ExistFile = Utils.GetBool();

            item.FileName = Utils.GetString(10);

            item.FileStorage = Utils.GetString(10);

		return item;
	}
 [TestMethod]
  public void  SDCaseFileCreate()
  {
            this. SDCaseFileCreate(null, null);
   }

	[TestMethod]
	 public void SDCaseFileCreate( List<SDCaseFile> items, SDCaseFile item )
        {
            var apiWrapper = GetWrapper<SDCaseFile>();
            apiWrapper.EntityKeyName = "SDCaseFile";
            apiWrapper.EntitySetName  = "SDCaseFiles";
			if (item == null && items == null)
            {
				apiWrapper.Item = SDCaseFileSample();
			}else{
				apiWrapper.Item = item;
                apiWrapper.Items = items;
			}
            var resultCreate  = Services.ApiCreate(url, apiWrapper);
			Assert.IsTrue(resultCreate == "ok");
			if (apiWrapper.Item != null)
            {
				apiWrapper.ItemKey = apiWrapper.Item.GuidCasefile;
				var existent = Services.ApiGetByKey<SDCaseFile>(url, apiWrapper);
				Assert.IsNotNull(existent);
			}
            
        }
	public SDCaseHistory SDCaseHistorySample(){
		 SDCaseHistory item = new SDCaseHistory();
            item.GuidCaseHistory = Guid.NewGuid();



            item.BodyContent = Utils.GetString(10);

            item.PreviewContent = Utils.GetString(10);








		return item;
	}
 [TestMethod]
  public void  SDCaseHistoryCreate()
  {
            this. SDCaseHistoryCreate(null, null);
   }

	[TestMethod]
	 public void SDCaseHistoryCreate( List<SDCaseHistory> items, SDCaseHistory item )
        {
            var apiWrapper = GetWrapper<SDCaseHistory>();
            apiWrapper.EntityKeyName = "SDCaseHistory";
            apiWrapper.EntitySetName  = "SDCaseHistories";
			if (item == null && items == null)
            {
				apiWrapper.Item = SDCaseHistorySample();
			}else{
				apiWrapper.Item = item;
                apiWrapper.Items = items;
			}
            var resultCreate  = Services.ApiCreate(url, apiWrapper);
			Assert.IsTrue(resultCreate == "ok");
			if (apiWrapper.Item != null)
            {
				apiWrapper.ItemKey = apiWrapper.Item.GuidCaseHistory;
				var existent = Services.ApiGetByKey<SDCaseHistory>(url, apiWrapper);
				Assert.IsNotNull(existent);
			}
            
        }
	public SDCaseHistoryFile SDCaseHistoryFileSample(){
		 SDCaseHistoryFile item = new SDCaseHistoryFile();
            item.GuidCasehistoryFile = Guid.NewGuid();










		return item;
	}
 [TestMethod]
  public void  SDCaseHistoryFileCreate()
  {
            this. SDCaseHistoryFileCreate(null, null);
   }

	[TestMethod]
	 public void SDCaseHistoryFileCreate( List<SDCaseHistoryFile> items, SDCaseHistoryFile item )
        {
            var apiWrapper = GetWrapper<SDCaseHistoryFile>();
            apiWrapper.EntityKeyName = "SDCaseHistoryFile";
            apiWrapper.EntitySetName  = "SDCaseHistoryFiles";
			if (item == null && items == null)
            {
				apiWrapper.Item = SDCaseHistoryFileSample();
			}else{
				apiWrapper.Item = item;
                apiWrapper.Items = items;
			}
            var resultCreate  = Services.ApiCreate(url, apiWrapper);
			Assert.IsTrue(resultCreate == "ok");
			if (apiWrapper.Item != null)
            {
				apiWrapper.ItemKey = apiWrapper.Item.GuidCasehistoryFile;
				var existent = Services.ApiGetByKey<SDCaseHistoryFile>(url, apiWrapper);
				Assert.IsNotNull(existent);
			}
            
        }
	  }
}
