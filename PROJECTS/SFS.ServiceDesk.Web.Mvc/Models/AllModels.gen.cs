using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SFS.ServiceDesk.Web.Mvc.Resources;
using System.Runtime.Serialization;
using SFSdotNet.Framework.Web.Mvc.Models;
using SFSdotNet.Framework.Web.Mvc.Extensions;
using BO = SFS.ServiceDesk.BusinessObjects;
using System.Web.Mvc;
//using SFSdotNet.Framework.Web.Mvc.Validation;
//using SFSdotNet.Framework.Web.Mvc.Models;
using SFSdotNet.Framework.Web.Mvc.Resources;
using SFSdotNet.Framework.Common.Entities.Metadata;
using System.Text;
using SFS.ServiceDesk.BusinessObjects;
	namespace SFS.ServiceDesk.Web.Mvc.Models.SDAreas 
	{
	public partial class SDAreaModel: ModelBase{

	  public SDAreaModel(BO.SDArea resultObj)
        {

            Bind(resultObj);
        }
#region Tags		
#endregion
		public SDAreaModel()
        {
		}
		public override string Id
        {
            get
            {
                return this.GuidArea.ToString();
            }
        }
			
			
        public override string ToString()
        {
			if (this.Name != null)
		
            return this.Name.ToString();
			else
				return "";
		
        }    
			

       
	
		[SystemProperty()]		
		public Guid? GuidArea{ get; set; }
		
	
[Exportable()]
	
	    [Required()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("NAME"/*, NameResourceType=typeof(SDAreaResources)*/)]
	public String   Name { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("GUIDAREAPARENT"/*, NameResourceType=typeof(SDAreaResources)*/)]
	public Guid  ? GuidAreaParent { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("GUIDORGANIZATION"/*, NameResourceType=typeof(SDAreaResources)*/)]
	public Guid  ? GuidOrganization { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("GUIDCOMPANY"/*, NameResourceType=typeof(SDAreaResources)*/)]
	public Guid  ? GuidCompany { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("CREATEDDATE"/*, NameResourceType=typeof(SDAreaResources)*/)]
	public DateTime  ? CreatedDate { get; set; }
	public string CreatedDateText {
        get {
            if (CreatedDate != null)
				return ((DateTime)CreatedDate).ToShortDateString() ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.CreatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("UPDATEDDATE"/*, NameResourceType=typeof(SDAreaResources)*/)]
	public DateTime  ? UpdatedDate { get; set; }
	public string UpdatedDateText {
        get {
            if (UpdatedDate != null)
			
                return ((DateTime)UpdatedDate).ToString("s") ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.UpdatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "CreatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("CREATEDBY"/*, NameResourceType=typeof(SDAreaResources)*/)]
	public Guid  ? CreatedBy { get; set; }
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "UpdatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("UPDATEDBY"/*, NameResourceType=typeof(SDAreaResources)*/)]
	public Guid  ? UpdatedBy { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DataType("Integer")]
	[LocalizedDisplayName("BYTES"/*, NameResourceType=typeof(SDAreaResources)*/)]
	public Int32  ? Bytes { get; set; }
	public string _BytesText = null;
    public string BytesText {
        get {
			if (string.IsNullOrEmpty( _BytesText ))
				{
	
            if (Bytes != null)
				return Bytes.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _BytesText ;
			}			
        }
		set{
			_BytesText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("ISDELETED"/*, NameResourceType=typeof(SDAreaResources)*/)]
	public Boolean  ? IsDeleted { get; set; }
	public string _IsDeletedText = null;
    public string IsDeletedText {
        get {
			if (string.IsNullOrEmpty( _IsDeletedText ))
				{
	
            if (IsDeleted != null)

				return IsDeleted.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _IsDeletedText ;
			}			
        }
		set{
			_IsDeletedText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable(DataClassProvider = typeof(Controllers.SDAreasController), GetByKeyMethod="GetByKey", GetAllMethod = "GetAll", DataPropertyText = "Name", DataPropertyValue = "GuidArea", FiltrablePropertyPathName="SDArea2.GuidArea")]	

	[LocalizedDisplayName("SDAREA2"/*, NameResourceType=typeof(SDAreaResources)*/)]
	public Guid  ? FkSDArea2 { get; set; }
		[LocalizedDisplayName("SDAREA2"/*, NameResourceType=typeof(SDAreaResources)*/)]
	[Exportable()]
	public string  FkSDArea2Text { get; set; }
    public string FkSDArea2SafeKey { get; set; }

	
		
	
[Exportable()]
		
	[RelationFilterable(DataClassProvider = typeof(Controllers.SDOrganizationsController), GetByKeyMethod="GetByKey", GetAllMethod = "GetAll", DataPropertyText = "FullName", DataPropertyValue = "GuidOrganization", FiltrablePropertyPathName="SDOrganization.GuidOrganization")]	

	[LocalizedDisplayName("SDORGANIZATION"/*, NameResourceType=typeof(SDAreaResources)*/)]
	public Guid  ? FkSDOrganization { get; set; }
		[LocalizedDisplayName("SDORGANIZATION"/*, NameResourceType=typeof(SDAreaResources)*/)]
	[Exportable()]
	public string  FkSDOrganizationText { get; set; }
    public string FkSDOrganizationSafeKey { get; set; }

	
		
		
		[LocalizedDisplayName("SDAREA1"/*, NameResourceType=typeof(SDAreaResources)*/)]
		[RelationFilterable(IsNavigationPropertyMany=true, FiltrablePropertyPathName="SDArea1.Count()", ModelPartialType="SDAreas.SDArea", BusinessObjectSetName = "SDAreas")]
        public List<SDAreas.SDAreaModel> SDArea1 { get; set; }			
	
		[LocalizedDisplayName("SDAREAPERSONS"/*, NameResourceType=typeof(SDAreaResources)*/)]
		[RelationFilterable(IsNavigationPropertyMany=true, FiltrablePropertyPathName="SDAreaPersons.Count()", ModelPartialType="SDAreaPersons.SDAreaPerson", BusinessObjectSetName = "SDAreaPersons")]
        public List<SDAreaPersons.SDAreaPersonModel> SDAreaPersons { get; set; }			
	
	public override string SafeKey
   	{
		get
        {
			if(this.GuidArea != null)
				return SFSdotNet.Framework.Entities.Utils.GetKey(this ,"GuidArea").Replace("/","-");
			else
				return String.Empty;
		}
    }		
		public void Bind(SDAreaModel model){
            
		this.GuidArea = model.GuidArea;
		this.Name = model.Name;
		this.GuidAreaParent = model.GuidAreaParent;
		this.GuidOrganization = model.GuidOrganization;
		this.GuidCompany = model.GuidCompany;
		this.CreatedDate = model.CreatedDate;
		this.UpdatedDate = model.UpdatedDate;
		this.CreatedBy = model.CreatedBy;
		this.UpdatedBy = model.UpdatedBy;
		this.Bytes = model.Bytes;
		this.IsDeleted = model.IsDeleted;
        }

        public BusinessObjects.SDArea GetBusinessObject()
        {
            BusinessObjects.SDArea result = new BusinessObjects.SDArea();


			       
	if (this.GuidArea != null )
				result.GuidArea = (Guid)this.GuidArea;
				
	if (this.Name != null )
				result.Name = (String)this.Name.Trim().Replace("\t", String.Empty);
				
	if (this.GuidAreaParent != null )
				result.GuidAreaParent = (Guid)this.GuidAreaParent;
				
	if (this.GuidOrganization != null )
				result.GuidOrganization = (Guid)this.GuidOrganization;
				
	if (this.GuidCompany != null )
				result.GuidCompany = (Guid)this.GuidCompany;
				
				if(this.CreatedDate != null)
					if (this.CreatedDate != null)
				result.CreatedDate = (DateTime)this.CreatedDate;		
				
				if(this.UpdatedDate != null)
					if (this.UpdatedDate != null)
				result.UpdatedDate = (DateTime)this.UpdatedDate;		
				
	if (this.CreatedBy != null )
				result.CreatedBy = (Guid)this.CreatedBy;
				
	if (this.UpdatedBy != null )
				result.UpdatedBy = (Guid)this.UpdatedBy;
				
	if (this.Bytes != null )
				result.Bytes = (Int32)this.Bytes;
				
	if (this.IsDeleted != null )
				result.IsDeleted = (Boolean)this.IsDeleted;
				
			
			if(this.FkSDArea2 != null || this.GuidAreaParent != null){
			if (GuidAreaParent != null && this.FkSDArea2 == null) this.FkSDArea2 = GuidAreaParent; 
			result.SDArea2 = new BusinessObjects.SDArea() { GuidArea= (Guid)this.FkSDArea2 };

			
			}
				
			
			if(this.FkSDOrganization != null || this.GuidOrganization != null){
			if (GuidOrganization != null && this.FkSDOrganization == null) this.FkSDOrganization = GuidOrganization; 
			result.SDOrganization = new BusinessObjects.SDOrganization() { GuidOrganization= (Guid)this.FkSDOrganization };

			
			}
				

            return result;
        }
        public void Bind(BusinessObjects.SDArea businessObject)
        {
				this.BusinessObjectObject = businessObject;

			this.GuidArea = businessObject.GuidArea;
				
			this.Name = businessObject.Name != null ? businessObject.Name.Trim().Replace("\t", String.Empty) : "";
				
				
	if (businessObject.GuidAreaParent != null )
				this.GuidAreaParent = (Guid)businessObject.GuidAreaParent;
				
	if (businessObject.GuidOrganization != null )
				this.GuidOrganization = (Guid)businessObject.GuidOrganization;
				
	if (businessObject.GuidCompany != null )
				this.GuidCompany = (Guid)businessObject.GuidCompany;
				if (businessObject.CreatedDate != null )
				this.CreatedDate = (DateTime)businessObject.CreatedDate;
				if (businessObject.UpdatedDate != null )
				this.UpdatedDate = (DateTime)businessObject.UpdatedDate;
				
	if (businessObject.CreatedBy != null )
				this.CreatedBy = (Guid)businessObject.CreatedBy;
				
	if (businessObject.UpdatedBy != null )
				this.UpdatedBy = (Guid)businessObject.UpdatedBy;
				
	if (businessObject.Bytes != null )
				this.Bytes = (Int32)businessObject.Bytes;
				
	if (businessObject.IsDeleted != null )
				this.IsDeleted = (Boolean)businessObject.IsDeleted;
	        if (businessObject.SDArea2 != null){
	                	this.FkSDArea2Text = businessObject.SDArea2.Name != null ? businessObject.SDArea2.Name.ToString() : "";; 
										
										
				this.FkSDArea2 = businessObject.SDArea2.GuidArea;
                this.FkSDArea2SafeKey  = SFSdotNet.Framework.Entities.Utils.GetKey(businessObject.SDArea2,"GuidArea").Replace("/","-");

			}
	        if (businessObject.SDOrganization != null){
	                	this.FkSDOrganizationText = businessObject.SDOrganization.FullName != null ? businessObject.SDOrganization.FullName.ToString() : "";; 
										
										
				this.FkSDOrganization = businessObject.SDOrganization.GuidOrganization;
                this.FkSDOrganizationSafeKey  = SFSdotNet.Framework.Entities.Utils.GetKey(businessObject.SDOrganization,"GuidOrganization").Replace("/","-");

			}
           
        }
	}
}
	namespace SFS.ServiceDesk.Web.Mvc.Models.SDAreaPersons 
	{
	public partial class SDAreaPersonModel: ModelBase{

	  public SDAreaPersonModel(BO.SDAreaPerson resultObj)
        {

            Bind(resultObj);
        }
#region Tags		
#endregion
		public SDAreaPersonModel()
        {
		}
		public override string Id
        {
            get
            {
                return this.GuidAreaPerson.ToString();
            }
        }
			
			
        public override string ToString()
        {
			if (this.Bytes != null)
		
            return this.Bytes.ToString();
			else
				return "";
		
        }    
			

       
	
		[SystemProperty()]		
		public Guid? GuidAreaPerson{ get; set; }
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("GUIDAREA"/*, NameResourceType=typeof(SDAreaPersonResources)*/)]
	public Guid  ? GuidArea { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("GUIDPERSON"/*, NameResourceType=typeof(SDAreaPersonResources)*/)]
	public Guid  ? GuidPerson { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("GUIDCOMPANY"/*, NameResourceType=typeof(SDAreaPersonResources)*/)]
	public Guid  ? GuidCompany { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("CREATEDDATE"/*, NameResourceType=typeof(SDAreaPersonResources)*/)]
	public DateTime  ? CreatedDate { get; set; }
	public string CreatedDateText {
        get {
            if (CreatedDate != null)
				return ((DateTime)CreatedDate).ToShortDateString() ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.CreatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("UPDATEDDATE"/*, NameResourceType=typeof(SDAreaPersonResources)*/)]
	public DateTime  ? UpdatedDate { get; set; }
	public string UpdatedDateText {
        get {
            if (UpdatedDate != null)
			
                return ((DateTime)UpdatedDate).ToString("s") ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.UpdatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "CreatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("CREATEDBY"/*, NameResourceType=typeof(SDAreaPersonResources)*/)]
	public Guid  ? CreatedBy { get; set; }
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "UpdatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("UPDATEDBY"/*, NameResourceType=typeof(SDAreaPersonResources)*/)]
	public Guid  ? UpdatedBy { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DataType("Integer")]
	[LocalizedDisplayName("BYTES"/*, NameResourceType=typeof(SDAreaPersonResources)*/)]
	public Int32  ? Bytes { get; set; }
	public string _BytesText = null;
    public string BytesText {
        get {
			if (string.IsNullOrEmpty( _BytesText ))
				{
	
            if (Bytes != null)
				return Bytes.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _BytesText ;
			}			
        }
		set{
			_BytesText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("ISDELETED"/*, NameResourceType=typeof(SDAreaPersonResources)*/)]
	public Boolean  ? IsDeleted { get; set; }
	public string _IsDeletedText = null;
    public string IsDeletedText {
        get {
			if (string.IsNullOrEmpty( _IsDeletedText ))
				{
	
            if (IsDeleted != null)

				return IsDeleted.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _IsDeletedText ;
			}			
        }
		set{
			_IsDeletedText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable(DataClassProvider = typeof(Controllers.SDAreasController), GetByKeyMethod="GetByKey", GetAllMethod = "GetAll", DataPropertyText = "Name", DataPropertyValue = "GuidArea", FiltrablePropertyPathName="SDArea.GuidArea")]	

	[LocalizedDisplayName("SDAREA"/*, NameResourceType=typeof(SDAreaPersonResources)*/)]
	public Guid  ? FkSDArea { get; set; }
		[LocalizedDisplayName("SDAREA"/*, NameResourceType=typeof(SDAreaPersonResources)*/)]
	[Exportable()]
	public string  FkSDAreaText { get; set; }
    public string FkSDAreaSafeKey { get; set; }

	
		
	
[Exportable()]
		
	[RelationFilterable(DataClassProvider = typeof(Controllers.SDPersonsController), GetByKeyMethod="GetByKey", GetAllMethod = "GetAll", DataPropertyText = "DisplayName", DataPropertyValue = "GuidPerson", FiltrablePropertyPathName="SDPerson.GuidPerson")]	

	[LocalizedDisplayName("SDPERSON"/*, NameResourceType=typeof(SDAreaPersonResources)*/)]
	public Guid  ? FkSDPerson { get; set; }
		[LocalizedDisplayName("SDPERSON"/*, NameResourceType=typeof(SDAreaPersonResources)*/)]
	[Exportable()]
	public string  FkSDPersonText { get; set; }
    public string FkSDPersonSafeKey { get; set; }

	
		
		
	public override string SafeKey
   	{
		get
        {
			if(this.GuidAreaPerson != null)
				return SFSdotNet.Framework.Entities.Utils.GetKey(this ,"GuidAreaPerson").Replace("/","-");
			else
				return String.Empty;
		}
    }		
		public void Bind(SDAreaPersonModel model){
            
		this.GuidAreaPerson = model.GuidAreaPerson;
		this.GuidArea = model.GuidArea;
		this.GuidPerson = model.GuidPerson;
		this.GuidCompany = model.GuidCompany;
		this.CreatedDate = model.CreatedDate;
		this.UpdatedDate = model.UpdatedDate;
		this.CreatedBy = model.CreatedBy;
		this.UpdatedBy = model.UpdatedBy;
		this.Bytes = model.Bytes;
		this.IsDeleted = model.IsDeleted;
        }

        public BusinessObjects.SDAreaPerson GetBusinessObject()
        {
            BusinessObjects.SDAreaPerson result = new BusinessObjects.SDAreaPerson();


			       
	if (this.GuidAreaPerson != null )
				result.GuidAreaPerson = (Guid)this.GuidAreaPerson;
				
	if (this.GuidArea != null )
				result.GuidArea = (Guid)this.GuidArea;
				
	if (this.GuidPerson != null )
				result.GuidPerson = (Guid)this.GuidPerson;
				
	if (this.GuidCompany != null )
				result.GuidCompany = (Guid)this.GuidCompany;
				
				if(this.CreatedDate != null)
					if (this.CreatedDate != null)
				result.CreatedDate = (DateTime)this.CreatedDate;		
				
				if(this.UpdatedDate != null)
					if (this.UpdatedDate != null)
				result.UpdatedDate = (DateTime)this.UpdatedDate;		
				
	if (this.CreatedBy != null )
				result.CreatedBy = (Guid)this.CreatedBy;
				
	if (this.UpdatedBy != null )
				result.UpdatedBy = (Guid)this.UpdatedBy;
				
	if (this.Bytes != null )
				result.Bytes = (Int32)this.Bytes;
				
	if (this.IsDeleted != null )
				result.IsDeleted = (Boolean)this.IsDeleted;
				
			
			if(this.FkSDArea != null || this.GuidArea != null){
			if (GuidArea != null && this.FkSDArea == null) this.FkSDArea = GuidArea; 
			result.SDArea = new BusinessObjects.SDArea() { GuidArea= (Guid)this.FkSDArea };

			
			}
				
			
			if(this.FkSDPerson != null || this.GuidPerson != null){
			if (GuidPerson != null && this.FkSDPerson == null) this.FkSDPerson = GuidPerson; 
			result.SDPerson = new BusinessObjects.SDPerson() { GuidPerson= (Guid)this.FkSDPerson };

			
			}
				

            return result;
        }
        public void Bind(BusinessObjects.SDAreaPerson businessObject)
        {
				this.BusinessObjectObject = businessObject;

			this.GuidAreaPerson = businessObject.GuidAreaPerson;
				
				
	if (businessObject.GuidArea != null )
				this.GuidArea = (Guid)businessObject.GuidArea;
				
	if (businessObject.GuidPerson != null )
				this.GuidPerson = (Guid)businessObject.GuidPerson;
				
	if (businessObject.GuidCompany != null )
				this.GuidCompany = (Guid)businessObject.GuidCompany;
				if (businessObject.CreatedDate != null )
				this.CreatedDate = (DateTime)businessObject.CreatedDate;
				if (businessObject.UpdatedDate != null )
				this.UpdatedDate = (DateTime)businessObject.UpdatedDate;
				
	if (businessObject.CreatedBy != null )
				this.CreatedBy = (Guid)businessObject.CreatedBy;
				
	if (businessObject.UpdatedBy != null )
				this.UpdatedBy = (Guid)businessObject.UpdatedBy;
				
	if (businessObject.Bytes != null )
				this.Bytes = (Int32)businessObject.Bytes;
				
	if (businessObject.IsDeleted != null )
				this.IsDeleted = (Boolean)businessObject.IsDeleted;
	        if (businessObject.SDArea != null){
	                	this.FkSDAreaText = businessObject.SDArea.Name != null ? businessObject.SDArea.Name.ToString() : "";; 
										
										
				this.FkSDArea = businessObject.SDArea.GuidArea;
                this.FkSDAreaSafeKey  = SFSdotNet.Framework.Entities.Utils.GetKey(businessObject.SDArea,"GuidArea").Replace("/","-");

			}
	        if (businessObject.SDPerson != null){
	                	this.FkSDPersonText = businessObject.SDPerson.DisplayName != null ? businessObject.SDPerson.DisplayName.ToString() : "";; 
										
										
				this.FkSDPerson = businessObject.SDPerson.GuidPerson;
                this.FkSDPersonSafeKey  = SFSdotNet.Framework.Entities.Utils.GetKey(businessObject.SDPerson,"GuidPerson").Replace("/","-");

			}
           
        }
	}
}
	namespace SFS.ServiceDesk.Web.Mvc.Models.SDCases 
	{
	public partial class SDCaseModel: ModelBase{

	  public SDCaseModel(BO.SDCase resultObj)
        {

            Bind(resultObj);
        }
#region Tags		
#endregion
		public SDCaseModel()
        {
		}
		public override string Id
        {
            get
            {
                return this.GuidCase.ToString();
            }
        }
			
			
        public override string ToString()
        {
			if (this.BodyContent != null)
		
            return this.BodyContent.ToString();
			else
				return "";
		
        }    
			

       
	
		[SystemProperty()]		
		public Guid? GuidCase{ get; set; }
		
	
[Exportable()]
	
	    [Required()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("GUIDCASESTATE"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public Guid   GuidCaseState { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("GUIDPERSONCLIENT"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public Guid  ? GuidPersonClient { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("CLOSEDDATETIME"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public DateTime  ? ClosedDateTime { get; set; }
	public string ClosedDateTimeText {
        get {
            if (ClosedDateTime != null)
				return ((DateTime)ClosedDateTime).ToShortDateString() ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.ClosedDateTime = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[DataType("RichEditorAdvanced")]
	[LocalizedDisplayName("BODYCONTENT"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public String   BodyContent { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("PREVIEWCONTENT"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public String   PreviewContent { get; set; }
		
		
	
[Exportable()]
	
	    [Required()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("GUIDCASEPRIORITY"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public Guid   GuidCasePriority { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("TITLE"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public String   Title { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("GUIDCOMPANY"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public Guid  ? GuidCompany { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("CREATEDDATE"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public DateTime  ? CreatedDate { get; set; }
	public string CreatedDateText {
        get {
            if (CreatedDate != null)
				return ((DateTime)CreatedDate).ToShortDateString() ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.CreatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("UPDATEDDATE"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public DateTime  ? UpdatedDate { get; set; }
	public string UpdatedDateText {
        get {
            if (UpdatedDate != null)
			
                return ((DateTime)UpdatedDate).ToString("s") ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.UpdatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "CreatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("CREATEDBY"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public Guid  ? CreatedBy { get; set; }
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "UpdatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("UPDATEDBY"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public Guid  ? UpdatedBy { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DataType("Integer")]
	[LocalizedDisplayName("BYTES"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public Int32  ? Bytes { get; set; }
	public string _BytesText = null;
    public string BytesText {
        get {
			if (string.IsNullOrEmpty( _BytesText ))
				{
	
            if (Bytes != null)
				return Bytes.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _BytesText ;
			}			
        }
		set{
			_BytesText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("ISDELETED"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public Boolean  ? IsDeleted { get; set; }
	public string _IsDeletedText = null;
    public string IsDeletedText {
        get {
			if (string.IsNullOrEmpty( _IsDeletedText ))
				{
	
            if (IsDeleted != null)

				return IsDeleted.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _IsDeletedText ;
			}			
        }
		set{
			_IsDeletedText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable(DataClassProvider = typeof(Controllers.SDPersonsController), GetByKeyMethod="GetByKey", GetAllMethod = "GetAll", DataPropertyText = "DisplayName", DataPropertyValue = "GuidPerson", FiltrablePropertyPathName="SDPerson.GuidPerson")]	

	[LocalizedDisplayName("SDPERSON"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public Guid  ? FkSDPerson { get; set; }
		[LocalizedDisplayName("SDPERSON"/*, NameResourceType=typeof(SDCaseResources)*/)]
	[Exportable()]
	public string  FkSDPersonText { get; set; }
    public string FkSDPersonSafeKey { get; set; }

	
		
	
[Exportable()]
		
	[RelationFilterable(DataClassProvider = typeof(Controllers.SDCasePrioritiesController), GetByKeyMethod="GetByKey", GetAllMethod = "GetAll", DataPropertyText = "Title", DataPropertyValue = "GuidCasePriority", FiltrablePropertyPathName="SDCasePriority.GuidCasePriority")]	

	[LocalizedDisplayName("SDCASEPRIORITY"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public Guid  ? FkSDCasePriority { get; set; }
		[LocalizedDisplayName("SDCASEPRIORITY"/*, NameResourceType=typeof(SDCaseResources)*/)]
	[Exportable()]
	public string  FkSDCasePriorityText { get; set; }
    public string FkSDCasePrioritySafeKey { get; set; }

	
		
	
[Exportable()]
		
	[RelationFilterable(DataClassProvider = typeof(Controllers.SDCaseStatesController), GetByKeyMethod="GetByKey", GetAllMethod = "GetAll", DataPropertyText = "Title", DataPropertyValue = "GuidCaseState", FiltrablePropertyPathName="SDCaseState.GuidCaseState")]	

	[LocalizedDisplayName("SDCASESTATE"/*, NameResourceType=typeof(SDCaseResources)*/)]
	public Guid  ? FkSDCaseState { get; set; }
		[LocalizedDisplayName("SDCASESTATE"/*, NameResourceType=typeof(SDCaseResources)*/)]
	[Exportable()]
	public string  FkSDCaseStateText { get; set; }
    public string FkSDCaseStateSafeKey { get; set; }

	
		
		
		[LocalizedDisplayName("SDCASEFILES"/*, NameResourceType=typeof(SDCaseResources)*/)]
		[RelationFilterable(IsNavigationPropertyMany=true, FiltrablePropertyPathName="SDCaseFiles.Count()", ModelPartialType="SDCaseFiles.SDCaseFile", BusinessObjectSetName = "SDCaseFiles")]
        public List<SDCaseFiles.SDCaseFileModel> SDCaseFiles { get; set; }			
	
		[LocalizedDisplayName("SDCASEHISTORIES"/*, NameResourceType=typeof(SDCaseResources)*/)]
		[RelationFilterable(IsNavigationPropertyMany=true, FiltrablePropertyPathName="SDCaseHistories.Count()", ModelPartialType="SDCaseHistories.SDCaseHistory", BusinessObjectSetName = "SDCaseHistories")]
        public List<SDCaseHistories.SDCaseHistoryModel> SDCaseHistories { get; set; }			
	
	public override string SafeKey
   	{
		get
        {
			if(this.GuidCase != null)
				return SFSdotNet.Framework.Entities.Utils.GetKey(this ,"GuidCase").Replace("/","-");
			else
				return String.Empty;
		}
    }		
		public void Bind(SDCaseModel model){
            
		this.GuidCase = model.GuidCase;
		this.GuidCaseState = model.GuidCaseState;
		this.GuidPersonClient = model.GuidPersonClient;
		this.ClosedDateTime = model.ClosedDateTime;
		this.BodyContent = model.BodyContent;
		this.PreviewContent = model.PreviewContent;
		this.GuidCasePriority = model.GuidCasePriority;
		this.Title = model.Title;
		this.GuidCompany = model.GuidCompany;
		this.CreatedDate = model.CreatedDate;
		this.UpdatedDate = model.UpdatedDate;
		this.CreatedBy = model.CreatedBy;
		this.UpdatedBy = model.UpdatedBy;
		this.Bytes = model.Bytes;
		this.IsDeleted = model.IsDeleted;
        }

        public BusinessObjects.SDCase GetBusinessObject()
        {
            BusinessObjects.SDCase result = new BusinessObjects.SDCase();


			       
	if (this.GuidCase != null )
				result.GuidCase = (Guid)this.GuidCase;
				
	if (this.GuidCaseState != null )
				result.GuidCaseState = (Guid)this.GuidCaseState;
				
	if (this.GuidPersonClient != null )
				result.GuidPersonClient = (Guid)this.GuidPersonClient;
				
				if(this.ClosedDateTime != null)
					if (this.ClosedDateTime != null)
				result.ClosedDateTime = (DateTime)this.ClosedDateTime;		
				
	if (this.BodyContent != null )
				result.BodyContent = (String)this.BodyContent.Trim().Replace("\t", String.Empty);
				
	if (this.PreviewContent != null )
				result.PreviewContent = (String)this.PreviewContent.Trim().Replace("\t", String.Empty);
				
	if (this.GuidCasePriority != null )
				result.GuidCasePriority = (Guid)this.GuidCasePriority;
				
	if (this.Title != null )
				result.Title = (String)this.Title.Trim().Replace("\t", String.Empty);
				
	if (this.GuidCompany != null )
				result.GuidCompany = (Guid)this.GuidCompany;
				
				if(this.CreatedDate != null)
					if (this.CreatedDate != null)
				result.CreatedDate = (DateTime)this.CreatedDate;		
				
				if(this.UpdatedDate != null)
					if (this.UpdatedDate != null)
				result.UpdatedDate = (DateTime)this.UpdatedDate;		
				
	if (this.CreatedBy != null )
				result.CreatedBy = (Guid)this.CreatedBy;
				
	if (this.UpdatedBy != null )
				result.UpdatedBy = (Guid)this.UpdatedBy;
				
	if (this.Bytes != null )
				result.Bytes = (Int32)this.Bytes;
				
	if (this.IsDeleted != null )
				result.IsDeleted = (Boolean)this.IsDeleted;
				
			
			if(this.FkSDPerson != null || this.GuidPersonClient != null){
			if (GuidPersonClient != null && this.FkSDPerson == null) this.FkSDPerson = GuidPersonClient; 
			result.SDPerson = new BusinessObjects.SDPerson() { GuidPerson= (Guid)this.FkSDPerson };

			
			}
				
			if (GuidCasePriority != null && this.FkSDCasePriority == null) this.FkSDCasePriority = GuidCasePriority; 
			result.SDCasePriority = new BusinessObjects.SDCasePriority() { GuidCasePriority= (Guid)this.FkSDCasePriority };

				
			if (GuidCaseState != null && this.FkSDCaseState == null) this.FkSDCaseState = GuidCaseState; 
			result.SDCaseState = new BusinessObjects.SDCaseState() { GuidCaseState= (Guid)this.FkSDCaseState };

				

            return result;
        }
        public void Bind(BusinessObjects.SDCase businessObject)
        {
				this.BusinessObjectObject = businessObject;

			this.GuidCase = businessObject.GuidCase;
				
			this.GuidCaseState = businessObject.GuidCaseState;
				
				
	if (businessObject.GuidPersonClient != null )
				this.GuidPersonClient = (Guid)businessObject.GuidPersonClient;
				if (businessObject.ClosedDateTime != null )
				this.ClosedDateTime = (DateTime)businessObject.ClosedDateTime;
				
	if (businessObject.BodyContent != null )
				this.BodyContent = (String)businessObject.BodyContent;
				
	if (businessObject.PreviewContent != null )
				this.PreviewContent = (String)businessObject.PreviewContent;
			this.GuidCasePriority = businessObject.GuidCasePriority;
				
				
	if (businessObject.Title != null )
				this.Title = (String)businessObject.Title;
				
	if (businessObject.GuidCompany != null )
				this.GuidCompany = (Guid)businessObject.GuidCompany;
				if (businessObject.CreatedDate != null )
				this.CreatedDate = (DateTime)businessObject.CreatedDate;
				if (businessObject.UpdatedDate != null )
				this.UpdatedDate = (DateTime)businessObject.UpdatedDate;
				
	if (businessObject.CreatedBy != null )
				this.CreatedBy = (Guid)businessObject.CreatedBy;
				
	if (businessObject.UpdatedBy != null )
				this.UpdatedBy = (Guid)businessObject.UpdatedBy;
				
	if (businessObject.Bytes != null )
				this.Bytes = (Int32)businessObject.Bytes;
				
	if (businessObject.IsDeleted != null )
				this.IsDeleted = (Boolean)businessObject.IsDeleted;
	        if (businessObject.SDPerson != null){
	                	this.FkSDPersonText = businessObject.SDPerson.DisplayName != null ? businessObject.SDPerson.DisplayName.ToString() : "";; 
										
										
				this.FkSDPerson = businessObject.SDPerson.GuidPerson;
                this.FkSDPersonSafeKey  = SFSdotNet.Framework.Entities.Utils.GetKey(businessObject.SDPerson,"GuidPerson").Replace("/","-");

			}
	        if (businessObject.SDCasePriority != null){
	                	this.FkSDCasePriorityText = businessObject.SDCasePriority.Title != null ? businessObject.SDCasePriority.Title.ToString() : "";; 
										
										
				this.FkSDCasePriority = businessObject.SDCasePriority.GuidCasePriority;
                this.FkSDCasePrioritySafeKey  = SFSdotNet.Framework.Entities.Utils.GetKey(businessObject.SDCasePriority,"GuidCasePriority").Replace("/","-");

			}
	        if (businessObject.SDCaseState != null){
	                	this.FkSDCaseStateText = businessObject.SDCaseState.Title != null ? businessObject.SDCaseState.Title.ToString() : "";; 
										
										
				this.FkSDCaseState = businessObject.SDCaseState.GuidCaseState;
                this.FkSDCaseStateSafeKey  = SFSdotNet.Framework.Entities.Utils.GetKey(businessObject.SDCaseState,"GuidCaseState").Replace("/","-");

			}
           
        }
	}
}
	namespace SFS.ServiceDesk.Web.Mvc.Models.SDCaseFiles 
	{
	public partial class SDCaseFileModel: ModelBase{

	  public SDCaseFileModel(BO.SDCaseFile resultObj)
        {

            Bind(resultObj);
        }
#region Tags		
#endregion
		public SDCaseFileModel()
        {
		}
		public override string Id
        {
            get
            {
                return this.GuidCasefile.ToString();
            }
        }
			
			
        public override string ToString()
        {
			if (this.Bytes != null)
		
            return this.Bytes.ToString();
			else
				return "";
		
        }    
			

       
		 public string files_SDFile { get; set; }

	
		[SystemProperty()]		
		public Guid? GuidCasefile{ get; set; }
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("GUIDCASE"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public Guid  ? GuidCase { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("GUIDFILE"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public Guid  ? GuidFile { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("GUIDCOMPANY"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public Guid  ? GuidCompany { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("CREATEDDATE"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public DateTime  ? CreatedDate { get; set; }
	public string CreatedDateText {
        get {
            if (CreatedDate != null)
				return ((DateTime)CreatedDate).ToShortDateString() ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.CreatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("UPDATEDDATE"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public DateTime  ? UpdatedDate { get; set; }
	public string UpdatedDateText {
        get {
            if (UpdatedDate != null)
			
                return ((DateTime)UpdatedDate).ToString("s") ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.UpdatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "CreatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("CREATEDBY"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public Guid  ? CreatedBy { get; set; }
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "UpdatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("UPDATEDBY"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public Guid  ? UpdatedBy { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DataType("Integer")]
	[LocalizedDisplayName("BYTES"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public Int32  ? Bytes { get; set; }
	public string _BytesText = null;
    public string BytesText {
        get {
			if (string.IsNullOrEmpty( _BytesText ))
				{
	
            if (Bytes != null)
				return Bytes.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _BytesText ;
			}			
        }
		set{
			_BytesText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("ISDELETED"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public Boolean  ? IsDeleted { get; set; }
	public string _IsDeletedText = null;
    public string IsDeletedText {
        get {
			if (string.IsNullOrEmpty( _IsDeletedText ))
				{
	
            if (IsDeleted != null)

				return IsDeleted.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _IsDeletedText ;
			}			
        }
		set{
			_IsDeletedText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable(DataClassProvider = typeof(Controllers.SDCasesController), GetByKeyMethod="GetByKey", GetAllMethod = "GetAll", DataPropertyText = "BodyContent", DataPropertyValue = "GuidCase", FiltrablePropertyPathName="SDCase.GuidCase")]	

	[LocalizedDisplayName("SDCASE"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public Guid  ? FkSDCase { get; set; }
		[LocalizedDisplayName("SDCASE"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	[Exportable()]
	public string  FkSDCaseText { get; set; }
    public string FkSDCaseSafeKey { get; set; }

	
		
	
[Exportable()]
		
	
 
			//[RelationFilterable( FiltrablePropertyPathName="SDFile.GuidFile")]
			[RelationFilterable(DataClassProvider = typeof(Controllers.SDFilesController), GetByKeyMethod="GetByKey", GetAllMethod = "GetByJson", DataPropertyText = "FileName", DataPropertyValue = "GuidFile", FiltrablePropertyPathName="SDFile.GuidFile")]	

			//1234
	[LookUp("SFS.ServiceDesk", "SFSServiceDesk","SDFiles", "ListViewGen", "FileName", "GuidFile")]	

	//TODO: Hacer dinamicos los campos. Ya existe la funcionalidad
	[FileData("FileData", "FileName", "FileType", "FileSize", "GuidFile", "SDFiles.SDFileModel", true)]
				[LocalizedDisplayName("SDFILE"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public Guid  ? FkSDFile { get; set; }
		[LocalizedDisplayName("SDFILE"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	[Exportable()]
	public string  FkSDFileText { get; set; }
    public string FkSDFileSafeKey { get; set; }

	
		
	
[Exportable()]
	
	    [Required()]
		
	[RelationFilterable()] 
	[DataType("RichEditorAdvanced")]
	[LocalizedDisplayName("URLFILE"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public String   UrlFile { get; set; }
		
		
	
[Exportable()]
	
	    [Required()]
		
	[RelationFilterable()] 
	[DataType("RichEditorAdvanced")]
	[LocalizedDisplayName("URLTHUMBFILE"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public String   UrlThumbFile { get; set; }
		
		
	
[Exportable()]
	
	    [Required()]
		
	[RelationFilterable(DisableFilterableInSubfilter=true)]

	[LocalizedDisplayName("EXISTFILE"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public Boolean   ExistFile { get; set; }
	public string _ExistFileText = null;
    public string ExistFileText {
        get {
			if (string.IsNullOrEmpty( _ExistFileText ))
				{
			//Aplicar formato si esta especificado
				return ExistFile.ToString();
	
			}else{
				return _ExistFileText ;
			}			
        }
		set{
			_ExistFileText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable(DisableFilterableInSubfilter=true)]

	[DataType("RichEditorAdvanced")]
	[LocalizedDisplayName("FILENAME"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public String   FileName { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable(DisableFilterableInSubfilter=true)]

	[DataType("RichEditorAdvanced")]
	[LocalizedDisplayName("FILESTORAGE"/*, NameResourceType=typeof(SDCaseFileResources)*/)]
	public String   FileStorage { get; set; }
		
		
		
	public override string SafeKey
   	{
		get
        {
			if(this.GuidCasefile != null)
				return SFSdotNet.Framework.Entities.Utils.GetKey(this ,"GuidCasefile").Replace("/","-");
			else
				return String.Empty;
		}
    }		
		public void Bind(SDCaseFileModel model){
            
		this.GuidCasefile = model.GuidCasefile;
		this.GuidCase = model.GuidCase;
		this.GuidFile = model.GuidFile;
		this.GuidCompany = model.GuidCompany;
		this.CreatedDate = model.CreatedDate;
		this.UpdatedDate = model.UpdatedDate;
		this.CreatedBy = model.CreatedBy;
		this.UpdatedBy = model.UpdatedBy;
		this.Bytes = model.Bytes;
		this.IsDeleted = model.IsDeleted;
		this.UrlFile = model.UrlFile;
		this.UrlThumbFile = model.UrlThumbFile;
		this.ExistFile = model.ExistFile;
		this.FileName = model.FileName;
		this.FileStorage = model.FileStorage;
        }

        public BusinessObjects.SDCaseFile GetBusinessObject()
        {
            BusinessObjects.SDCaseFile result = new BusinessObjects.SDCaseFile();


			       
	   result.files_SDFile = this.files_SDFile;
	if (this.GuidCasefile != null )
				result.GuidCasefile = (Guid)this.GuidCasefile;
				
	if (this.GuidCase != null )
				result.GuidCase = (Guid)this.GuidCase;
				
	if (this.GuidFile != null )
				result.GuidFile = (Guid)this.GuidFile;
				
	if (this.GuidCompany != null )
				result.GuidCompany = (Guid)this.GuidCompany;
				
				if(this.CreatedDate != null)
					if (this.CreatedDate != null)
				result.CreatedDate = (DateTime)this.CreatedDate;		
				
				if(this.UpdatedDate != null)
					if (this.UpdatedDate != null)
				result.UpdatedDate = (DateTime)this.UpdatedDate;		
				
	if (this.CreatedBy != null )
				result.CreatedBy = (Guid)this.CreatedBy;
				
	if (this.UpdatedBy != null )
				result.UpdatedBy = (Guid)this.UpdatedBy;
				
	if (this.Bytes != null )
				result.Bytes = (Int32)this.Bytes;
				
	if (this.IsDeleted != null )
				result.IsDeleted = (Boolean)this.IsDeleted;
				
			
			if(this.FkSDCase != null || this.GuidCase != null){
			if (GuidCase != null && this.FkSDCase == null) this.FkSDCase = GuidCase; 
			result.SDCase = new BusinessObjects.SDCase() { GuidCase= (Guid)this.FkSDCase };

			
			}
				
			
			if(this.FkSDFile != null || this.GuidFile != null){
			if (GuidFile != null && this.FkSDFile == null) this.FkSDFile = GuidFile; 
			result.SDFile = new BusinessObjects.SDFile() { GuidFile= (Guid)this.FkSDFile };

			
			}
				
	if (this.UrlFile != null )
				result.UrlFile = (String)this.UrlFile.Trim().Replace("\t", String.Empty);
				
	if (this.UrlThumbFile != null )
				result.UrlThumbFile = (String)this.UrlThumbFile.Trim().Replace("\t", String.Empty);
				
	if (this.ExistFile != null )
				result.ExistFile = (Boolean)this.ExistFile;
				
	if (this.FileName != null )
				result.FileName = (String)this.FileName.Trim().Replace("\t", String.Empty);
				
	if (this.FileStorage != null )
				result.FileStorage = (String)this.FileStorage.Trim().Replace("\t", String.Empty);
				

            return result;
        }
        public void Bind(BusinessObjects.SDCaseFile businessObject)
        {
				this.BusinessObjectObject = businessObject;

			this.GuidCasefile = businessObject.GuidCasefile;
				
				
	if (businessObject.GuidCase != null )
				this.GuidCase = (Guid)businessObject.GuidCase;
				
	if (businessObject.GuidFile != null )
				this.GuidFile = (Guid)businessObject.GuidFile;
				
	if (businessObject.GuidCompany != null )
				this.GuidCompany = (Guid)businessObject.GuidCompany;
				if (businessObject.CreatedDate != null )
				this.CreatedDate = (DateTime)businessObject.CreatedDate;
				if (businessObject.UpdatedDate != null )
				this.UpdatedDate = (DateTime)businessObject.UpdatedDate;
				
	if (businessObject.CreatedBy != null )
				this.CreatedBy = (Guid)businessObject.CreatedBy;
				
	if (businessObject.UpdatedBy != null )
				this.UpdatedBy = (Guid)businessObject.UpdatedBy;
				
	if (businessObject.Bytes != null )
				this.Bytes = (Int32)businessObject.Bytes;
				
	if (businessObject.IsDeleted != null )
				this.IsDeleted = (Boolean)businessObject.IsDeleted;
			this.UrlFile = businessObject.UrlFile != null ? businessObject.UrlFile.Trim().Replace("\t", String.Empty) : "";
				
			this.UrlThumbFile = businessObject.UrlThumbFile != null ? businessObject.UrlThumbFile.Trim().Replace("\t", String.Empty) : "";
				
			this.ExistFile = businessObject.ExistFile;
				
				
	if (businessObject.FileName != null )
				this.FileName = (String)businessObject.FileName;
				
	if (businessObject.FileStorage != null )
				this.FileStorage = (String)businessObject.FileStorage;
	        if (businessObject.SDCase != null){
	                	this.FkSDCaseText = businessObject.SDCase.BodyContent != null ? businessObject.SDCase.BodyContent.ToString() : "";; 
										
				this.FkSDCase = businessObject.SDCase.GuidCase;
                this.FkSDCaseSafeKey  = SFSdotNet.Framework.Entities.Utils.GetKey(businessObject.SDCase,"GuidCase").Replace("/","-");

			}
	        if (businessObject.SDFile != null){
	                	this.FkSDFileText = businessObject.SDFile.FileName != null ? businessObject.SDFile.FileName.ToString() : "";; 
										
										
				this.FkSDFile = businessObject.SDFile.GuidFile;
                this.FkSDFileSafeKey  = SFSdotNet.Framework.Entities.Utils.GetKey(businessObject.SDFile,"GuidFile").Replace("/","-");

			}
           
        }
	}
}
	namespace SFS.ServiceDesk.Web.Mvc.Models.SDCaseHistories 
	{
	public partial class SDCaseHistoryModel: ModelBase{

	  public SDCaseHistoryModel(BO.SDCaseHistory resultObj)
        {

            Bind(resultObj);
        }
#region Tags		
#endregion
		public SDCaseHistoryModel()
        {
		}
		public override string Id
        {
            get
            {
                return this.GuidCaseHistory.ToString();
            }
        }
			
			
        public override string ToString()
        {
			if (this.BodyContent != null)
		
            return this.BodyContent.ToString();
			else
				return "";
		
        }    
			

       
	
		[SystemProperty()]		
		public Guid? GuidCaseHistory{ get; set; }
		
	
[Exportable()]
	
	    [Required()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("GUIDCASE"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
	public Guid   GuidCase { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("GUIDCASESTATUS"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
	public Guid  ? GuidCaseStatus { get; set; }
		
		
	
[Exportable()]
	
	    [Required()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("BODYCONTENT"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
	public String   BodyContent { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("PREVIEWCONTENT"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
	public String   PreviewContent { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("GUIDCOMPANY"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
	public Guid  ? GuidCompany { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("CREATEDDATE"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
	public DateTime  ? CreatedDate { get; set; }
	public string CreatedDateText {
        get {
            if (CreatedDate != null)
				return ((DateTime)CreatedDate).ToShortDateString() ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.CreatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("UPDATEDDATE"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
	public DateTime  ? UpdatedDate { get; set; }
	public string UpdatedDateText {
        get {
            if (UpdatedDate != null)
			
                return ((DateTime)UpdatedDate).ToString("s") ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.UpdatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "CreatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("CREATEDBY"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
	public Guid  ? CreatedBy { get; set; }
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "UpdatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("UPDATEDBY"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
	public Guid  ? UpdatedBy { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DataType("Integer")]
	[LocalizedDisplayName("BYTES"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
	public Int32  ? Bytes { get; set; }
	public string _BytesText = null;
    public string BytesText {
        get {
			if (string.IsNullOrEmpty( _BytesText ))
				{
	
            if (Bytes != null)
				return Bytes.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _BytesText ;
			}			
        }
		set{
			_BytesText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("ISDELETED"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
	public Boolean  ? IsDeleted { get; set; }
	public string _IsDeletedText = null;
    public string IsDeletedText {
        get {
			if (string.IsNullOrEmpty( _IsDeletedText ))
				{
	
            if (IsDeleted != null)

				return IsDeleted.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _IsDeletedText ;
			}			
        }
		set{
			_IsDeletedText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable(DataClassProvider = typeof(Controllers.SDCasesController), GetByKeyMethod="GetByKey", GetAllMethod = "GetAll", DataPropertyText = "BodyContent", DataPropertyValue = "GuidCase", FiltrablePropertyPathName="SDCase.GuidCase")]	

	[LocalizedDisplayName("SDCASE"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
	public Guid  ? FkSDCase { get; set; }
		[LocalizedDisplayName("SDCASE"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
	[Exportable()]
	public string  FkSDCaseText { get; set; }
    public string FkSDCaseSafeKey { get; set; }

	
		
	
[Exportable()]
		
	[RelationFilterable(DataClassProvider = typeof(Controllers.SDCaseStatesController), GetByKeyMethod="GetByKey", GetAllMethod = "GetAll", DataPropertyText = "Title", DataPropertyValue = "GuidCaseState", FiltrablePropertyPathName="SDCaseState.GuidCaseState")]	

	[LocalizedDisplayName("SDCASESTATE"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
	public Guid  ? FkSDCaseState { get; set; }
		[LocalizedDisplayName("SDCASESTATE"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
	[Exportable()]
	public string  FkSDCaseStateText { get; set; }
    public string FkSDCaseStateSafeKey { get; set; }

	
		
		
		[LocalizedDisplayName("SDCASEHISTORYFILES"/*, NameResourceType=typeof(SDCaseHistoryResources)*/)]
		[RelationFilterable(IsNavigationPropertyMany=true, FiltrablePropertyPathName="SDCaseHistoryFiles.Count()", ModelPartialType="SDCaseHistoryFiles.SDCaseHistoryFile", BusinessObjectSetName = "SDCaseHistoryFiles")]
        public List<SDCaseHistoryFiles.SDCaseHistoryFileModel> SDCaseHistoryFiles { get; set; }			
	
	public override string SafeKey
   	{
		get
        {
			if(this.GuidCaseHistory != null)
				return SFSdotNet.Framework.Entities.Utils.GetKey(this ,"GuidCaseHistory").Replace("/","-");
			else
				return String.Empty;
		}
    }		
		public void Bind(SDCaseHistoryModel model){
            
		this.GuidCaseHistory = model.GuidCaseHistory;
		this.GuidCase = model.GuidCase;
		this.GuidCaseStatus = model.GuidCaseStatus;
		this.BodyContent = model.BodyContent;
		this.PreviewContent = model.PreviewContent;
		this.GuidCompany = model.GuidCompany;
		this.CreatedDate = model.CreatedDate;
		this.UpdatedDate = model.UpdatedDate;
		this.CreatedBy = model.CreatedBy;
		this.UpdatedBy = model.UpdatedBy;
		this.Bytes = model.Bytes;
		this.IsDeleted = model.IsDeleted;
        }

        public BusinessObjects.SDCaseHistory GetBusinessObject()
        {
            BusinessObjects.SDCaseHistory result = new BusinessObjects.SDCaseHistory();


			       
	if (this.GuidCaseHistory != null )
				result.GuidCaseHistory = (Guid)this.GuidCaseHistory;
				
	if (this.GuidCase != null )
				result.GuidCase = (Guid)this.GuidCase;
				
	if (this.GuidCaseStatus != null )
				result.GuidCaseStatus = (Guid)this.GuidCaseStatus;
				
	if (this.BodyContent != null )
				result.BodyContent = (String)this.BodyContent.Trim().Replace("\t", String.Empty);
				
	if (this.PreviewContent != null )
				result.PreviewContent = (String)this.PreviewContent.Trim().Replace("\t", String.Empty);
				
	if (this.GuidCompany != null )
				result.GuidCompany = (Guid)this.GuidCompany;
				
				if(this.CreatedDate != null)
					if (this.CreatedDate != null)
				result.CreatedDate = (DateTime)this.CreatedDate;		
				
				if(this.UpdatedDate != null)
					if (this.UpdatedDate != null)
				result.UpdatedDate = (DateTime)this.UpdatedDate;		
				
	if (this.CreatedBy != null )
				result.CreatedBy = (Guid)this.CreatedBy;
				
	if (this.UpdatedBy != null )
				result.UpdatedBy = (Guid)this.UpdatedBy;
				
	if (this.Bytes != null )
				result.Bytes = (Int32)this.Bytes;
				
	if (this.IsDeleted != null )
				result.IsDeleted = (Boolean)this.IsDeleted;
				
			if (GuidCase != null && this.FkSDCase == null) this.FkSDCase = GuidCase; 
			result.SDCase = new BusinessObjects.SDCase() { GuidCase= (Guid)this.FkSDCase };

				
			
			if(this.FkSDCaseState != null || this.GuidCaseStatus != null){
			if (GuidCaseStatus != null && this.FkSDCaseState == null) this.FkSDCaseState = GuidCaseStatus; 
			result.SDCaseState = new BusinessObjects.SDCaseState() { GuidCaseState= (Guid)this.FkSDCaseState };

			
			}
				

            return result;
        }
        public void Bind(BusinessObjects.SDCaseHistory businessObject)
        {
				this.BusinessObjectObject = businessObject;

			this.GuidCaseHistory = businessObject.GuidCaseHistory;
				
			this.GuidCase = businessObject.GuidCase;
				
				
	if (businessObject.GuidCaseStatus != null )
				this.GuidCaseStatus = (Guid)businessObject.GuidCaseStatus;
			this.BodyContent = businessObject.BodyContent != null ? businessObject.BodyContent.Trim().Replace("\t", String.Empty) : "";
				
				
	if (businessObject.PreviewContent != null )
				this.PreviewContent = (String)businessObject.PreviewContent;
				
	if (businessObject.GuidCompany != null )
				this.GuidCompany = (Guid)businessObject.GuidCompany;
				if (businessObject.CreatedDate != null )
				this.CreatedDate = (DateTime)businessObject.CreatedDate;
				if (businessObject.UpdatedDate != null )
				this.UpdatedDate = (DateTime)businessObject.UpdatedDate;
				
	if (businessObject.CreatedBy != null )
				this.CreatedBy = (Guid)businessObject.CreatedBy;
				
	if (businessObject.UpdatedBy != null )
				this.UpdatedBy = (Guid)businessObject.UpdatedBy;
				
	if (businessObject.Bytes != null )
				this.Bytes = (Int32)businessObject.Bytes;
				
	if (businessObject.IsDeleted != null )
				this.IsDeleted = (Boolean)businessObject.IsDeleted;
	        if (businessObject.SDCase != null){
	                	this.FkSDCaseText = businessObject.SDCase.BodyContent != null ? businessObject.SDCase.BodyContent.ToString() : "";; 
										
				this.FkSDCase = businessObject.SDCase.GuidCase;
                this.FkSDCaseSafeKey  = SFSdotNet.Framework.Entities.Utils.GetKey(businessObject.SDCase,"GuidCase").Replace("/","-");

			}
	        if (businessObject.SDCaseState != null){
	                	this.FkSDCaseStateText = businessObject.SDCaseState.Title != null ? businessObject.SDCaseState.Title.ToString() : "";; 
										
										
				this.FkSDCaseState = businessObject.SDCaseState.GuidCaseState;
                this.FkSDCaseStateSafeKey  = SFSdotNet.Framework.Entities.Utils.GetKey(businessObject.SDCaseState,"GuidCaseState").Replace("/","-");

			}
           
        }
	}
}
	namespace SFS.ServiceDesk.Web.Mvc.Models.SDCaseHistoryFiles 
	{
	public partial class SDCaseHistoryFileModel: ModelBase{

	  public SDCaseHistoryFileModel(BO.SDCaseHistoryFile resultObj)
        {

            Bind(resultObj);
        }
#region Tags		
#endregion
		public SDCaseHistoryFileModel()
        {
		}
		public override string Id
        {
            get
            {
                return this.GuidCasehistoryFile.ToString();
            }
        }
			
			
        public override string ToString()
        {
			if (this.Bytes != null)
		
            return this.Bytes.ToString();
			else
				return "";
		
        }    
			

       
	
		[SystemProperty()]		
		public Guid? GuidCasehistoryFile{ get; set; }
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("GUIDFILE"/*, NameResourceType=typeof(SDCaseHistoryFileResources)*/)]
	public Guid  ? GuidFile { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("GUIDCASEHISTORY"/*, NameResourceType=typeof(SDCaseHistoryFileResources)*/)]
	public Guid  ? GuidCaseHistory { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("GUIDCOMPANY"/*, NameResourceType=typeof(SDCaseHistoryFileResources)*/)]
	public Guid  ? GuidCompany { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("CREATEDDATE"/*, NameResourceType=typeof(SDCaseHistoryFileResources)*/)]
	public DateTime  ? CreatedDate { get; set; }
	public string CreatedDateText {
        get {
            if (CreatedDate != null)
				return ((DateTime)CreatedDate).ToShortDateString() ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.CreatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("UPDATEDDATE"/*, NameResourceType=typeof(SDCaseHistoryFileResources)*/)]
	public DateTime  ? UpdatedDate { get; set; }
	public string UpdatedDateText {
        get {
            if (UpdatedDate != null)
			
                return ((DateTime)UpdatedDate).ToString("s") ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.UpdatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "CreatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("CREATEDBY"/*, NameResourceType=typeof(SDCaseHistoryFileResources)*/)]
	public Guid  ? CreatedBy { get; set; }
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "UpdatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("UPDATEDBY"/*, NameResourceType=typeof(SDCaseHistoryFileResources)*/)]
	public Guid  ? UpdatedBy { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DataType("Integer")]
	[LocalizedDisplayName("BYTES"/*, NameResourceType=typeof(SDCaseHistoryFileResources)*/)]
	public Int32  ? Bytes { get; set; }
	public string _BytesText = null;
    public string BytesText {
        get {
			if (string.IsNullOrEmpty( _BytesText ))
				{
	
            if (Bytes != null)
				return Bytes.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _BytesText ;
			}			
        }
		set{
			_BytesText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("ISDELETED"/*, NameResourceType=typeof(SDCaseHistoryFileResources)*/)]
	public Boolean  ? IsDeleted { get; set; }
	public string _IsDeletedText = null;
    public string IsDeletedText {
        get {
			if (string.IsNullOrEmpty( _IsDeletedText ))
				{
	
            if (IsDeleted != null)

				return IsDeleted.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _IsDeletedText ;
			}			
        }
		set{
			_IsDeletedText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable(DataClassProvider = typeof(Controllers.SDCaseHistoriesController), GetByKeyMethod="GetByKey", GetAllMethod = "GetAll", DataPropertyText = "BodyContent", DataPropertyValue = "GuidCaseHistory", FiltrablePropertyPathName="SDCaseHistory.GuidCaseHistory")]	

	[LocalizedDisplayName("SDCASEHISTORY"/*, NameResourceType=typeof(SDCaseHistoryFileResources)*/)]
	public Guid  ? FkSDCaseHistory { get; set; }
		[LocalizedDisplayName("SDCASEHISTORY"/*, NameResourceType=typeof(SDCaseHistoryFileResources)*/)]
	[Exportable()]
	public string  FkSDCaseHistoryText { get; set; }
    public string FkSDCaseHistorySafeKey { get; set; }

	
		
	
[Exportable()]
		
	[RelationFilterable(DataClassProvider = typeof(Controllers.SDFilesController), GetByKeyMethod="GetByKey", GetAllMethod = "GetAll", DataPropertyText = "FileName", DataPropertyValue = "GuidFile", FiltrablePropertyPathName="SDFile.GuidFile")]	

	[LocalizedDisplayName("SDFILE"/*, NameResourceType=typeof(SDCaseHistoryFileResources)*/)]
	public Guid  ? FkSDFile { get; set; }
		[LocalizedDisplayName("SDFILE"/*, NameResourceType=typeof(SDCaseHistoryFileResources)*/)]
	[Exportable()]
	public string  FkSDFileText { get; set; }
    public string FkSDFileSafeKey { get; set; }

	
		
		
	public override string SafeKey
   	{
		get
        {
			if(this.GuidCasehistoryFile != null)
				return SFSdotNet.Framework.Entities.Utils.GetKey(this ,"GuidCasehistoryFile").Replace("/","-");
			else
				return String.Empty;
		}
    }		
		public void Bind(SDCaseHistoryFileModel model){
            
		this.GuidCasehistoryFile = model.GuidCasehistoryFile;
		this.GuidFile = model.GuidFile;
		this.GuidCaseHistory = model.GuidCaseHistory;
		this.GuidCompany = model.GuidCompany;
		this.CreatedDate = model.CreatedDate;
		this.UpdatedDate = model.UpdatedDate;
		this.CreatedBy = model.CreatedBy;
		this.UpdatedBy = model.UpdatedBy;
		this.Bytes = model.Bytes;
		this.IsDeleted = model.IsDeleted;
        }

        public BusinessObjects.SDCaseHistoryFile GetBusinessObject()
        {
            BusinessObjects.SDCaseHistoryFile result = new BusinessObjects.SDCaseHistoryFile();


			       
	if (this.GuidCasehistoryFile != null )
				result.GuidCasehistoryFile = (Guid)this.GuidCasehistoryFile;
				
	if (this.GuidFile != null )
				result.GuidFile = (Guid)this.GuidFile;
				
	if (this.GuidCaseHistory != null )
				result.GuidCaseHistory = (Guid)this.GuidCaseHistory;
				
	if (this.GuidCompany != null )
				result.GuidCompany = (Guid)this.GuidCompany;
				
				if(this.CreatedDate != null)
					if (this.CreatedDate != null)
				result.CreatedDate = (DateTime)this.CreatedDate;		
				
				if(this.UpdatedDate != null)
					if (this.UpdatedDate != null)
				result.UpdatedDate = (DateTime)this.UpdatedDate;		
				
	if (this.CreatedBy != null )
				result.CreatedBy = (Guid)this.CreatedBy;
				
	if (this.UpdatedBy != null )
				result.UpdatedBy = (Guid)this.UpdatedBy;
				
	if (this.Bytes != null )
				result.Bytes = (Int32)this.Bytes;
				
	if (this.IsDeleted != null )
				result.IsDeleted = (Boolean)this.IsDeleted;
				
			
			if(this.FkSDCaseHistory != null || this.GuidCaseHistory != null){
			if (GuidCaseHistory != null && this.FkSDCaseHistory == null) this.FkSDCaseHistory = GuidCaseHistory; 
			result.SDCaseHistory = new BusinessObjects.SDCaseHistory() { GuidCaseHistory= (Guid)this.FkSDCaseHistory };

			
			}
				
			
			if(this.FkSDFile != null || this.GuidFile != null){
			if (GuidFile != null && this.FkSDFile == null) this.FkSDFile = GuidFile; 
			result.SDFile = new BusinessObjects.SDFile() { GuidFile= (Guid)this.FkSDFile };

			
			}
				

            return result;
        }
        public void Bind(BusinessObjects.SDCaseHistoryFile businessObject)
        {
				this.BusinessObjectObject = businessObject;

			this.GuidCasehistoryFile = businessObject.GuidCasehistoryFile;
				
				
	if (businessObject.GuidFile != null )
				this.GuidFile = (Guid)businessObject.GuidFile;
				
	if (businessObject.GuidCaseHistory != null )
				this.GuidCaseHistory = (Guid)businessObject.GuidCaseHistory;
				
	if (businessObject.GuidCompany != null )
				this.GuidCompany = (Guid)businessObject.GuidCompany;
				if (businessObject.CreatedDate != null )
				this.CreatedDate = (DateTime)businessObject.CreatedDate;
				if (businessObject.UpdatedDate != null )
				this.UpdatedDate = (DateTime)businessObject.UpdatedDate;
				
	if (businessObject.CreatedBy != null )
				this.CreatedBy = (Guid)businessObject.CreatedBy;
				
	if (businessObject.UpdatedBy != null )
				this.UpdatedBy = (Guid)businessObject.UpdatedBy;
				
	if (businessObject.Bytes != null )
				this.Bytes = (Int32)businessObject.Bytes;
				
	if (businessObject.IsDeleted != null )
				this.IsDeleted = (Boolean)businessObject.IsDeleted;
	        if (businessObject.SDCaseHistory != null){
	                	this.FkSDCaseHistoryText = businessObject.SDCaseHistory.BodyContent != null ? businessObject.SDCaseHistory.BodyContent.ToString() : "";; 
										
										
				this.FkSDCaseHistory = businessObject.SDCaseHistory.GuidCaseHistory;
                this.FkSDCaseHistorySafeKey  = SFSdotNet.Framework.Entities.Utils.GetKey(businessObject.SDCaseHistory,"GuidCaseHistory").Replace("/","-");

			}
	        if (businessObject.SDFile != null){
	                	this.FkSDFileText = businessObject.SDFile.FileName != null ? businessObject.SDFile.FileName.ToString() : "";; 
										
										
				this.FkSDFile = businessObject.SDFile.GuidFile;
                this.FkSDFileSafeKey  = SFSdotNet.Framework.Entities.Utils.GetKey(businessObject.SDFile,"GuidFile").Replace("/","-");

			}
           
        }
	}
}
	namespace SFS.ServiceDesk.Web.Mvc.Models.SDCasePriorities 
	{
	public partial class SDCasePriorityModel: ModelBase{

	  public SDCasePriorityModel(BO.SDCasePriority resultObj)
        {

            Bind(resultObj);
        }
#region Tags		
#endregion
		public SDCasePriorityModel()
        {
		}
		public override string Id
        {
            get
            {
                return this.GuidCasePriority.ToString();
            }
        }
			
			
        public override string ToString()
        {
			if (this.Title != null)
		
            return this.Title.ToString();
			else
				return "";
		
        }    
			

       
	
		[SystemProperty()]		
		public Guid? GuidCasePriority{ get; set; }
		
	
[Exportable()]
	
	    [Required()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("TITLE"/*, NameResourceType=typeof(SDCasePriorityResources)*/)]
	public String   Title { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("GUIDCOMPANY"/*, NameResourceType=typeof(SDCasePriorityResources)*/)]
	public Guid  ? GuidCompany { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("CREATEDDATE"/*, NameResourceType=typeof(SDCasePriorityResources)*/)]
	public DateTime  ? CreatedDate { get; set; }
	public string CreatedDateText {
        get {
            if (CreatedDate != null)
				return ((DateTime)CreatedDate).ToShortDateString() ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.CreatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("UPDATEDDATE"/*, NameResourceType=typeof(SDCasePriorityResources)*/)]
	public DateTime  ? UpdatedDate { get; set; }
	public string UpdatedDateText {
        get {
            if (UpdatedDate != null)
			
                return ((DateTime)UpdatedDate).ToString("s") ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.UpdatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "CreatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("CREATEDBY"/*, NameResourceType=typeof(SDCasePriorityResources)*/)]
	public Guid  ? CreatedBy { get; set; }
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "UpdatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("UPDATEDBY"/*, NameResourceType=typeof(SDCasePriorityResources)*/)]
	public Guid  ? UpdatedBy { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DataType("Integer")]
	[LocalizedDisplayName("BYTES"/*, NameResourceType=typeof(SDCasePriorityResources)*/)]
	public Int32  ? Bytes { get; set; }
	public string _BytesText = null;
    public string BytesText {
        get {
			if (string.IsNullOrEmpty( _BytesText ))
				{
	
            if (Bytes != null)
				return Bytes.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _BytesText ;
			}			
        }
		set{
			_BytesText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("ISDELETED"/*, NameResourceType=typeof(SDCasePriorityResources)*/)]
	public Boolean  ? IsDeleted { get; set; }
	public string _IsDeletedText = null;
    public string IsDeletedText {
        get {
			if (string.IsNullOrEmpty( _IsDeletedText ))
				{
	
            if (IsDeleted != null)

				return IsDeleted.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _IsDeletedText ;
			}			
        }
		set{
			_IsDeletedText = value;
		}
        
    }

		
		
		
		[LocalizedDisplayName("SDCASES"/*, NameResourceType=typeof(SDCasePriorityResources)*/)]
		[RelationFilterable(IsNavigationPropertyMany=true, FiltrablePropertyPathName="SDCases.Count()", ModelPartialType="SDCases.SDCase", BusinessObjectSetName = "SDCases")]
        public List<SDCases.SDCaseModel> SDCases { get; set; }			
	
	public override string SafeKey
   	{
		get
        {
			if(this.GuidCasePriority != null)
				return SFSdotNet.Framework.Entities.Utils.GetKey(this ,"GuidCasePriority").Replace("/","-");
			else
				return String.Empty;
		}
    }		
		public void Bind(SDCasePriorityModel model){
            
		this.GuidCasePriority = model.GuidCasePriority;
		this.Title = model.Title;
		this.GuidCompany = model.GuidCompany;
		this.CreatedDate = model.CreatedDate;
		this.UpdatedDate = model.UpdatedDate;
		this.CreatedBy = model.CreatedBy;
		this.UpdatedBy = model.UpdatedBy;
		this.Bytes = model.Bytes;
		this.IsDeleted = model.IsDeleted;
        }

        public BusinessObjects.SDCasePriority GetBusinessObject()
        {
            BusinessObjects.SDCasePriority result = new BusinessObjects.SDCasePriority();


			       
	if (this.GuidCasePriority != null )
				result.GuidCasePriority = (Guid)this.GuidCasePriority;
				
	if (this.Title != null )
				result.Title = (String)this.Title.Trim().Replace("\t", String.Empty);
				
	if (this.GuidCompany != null )
				result.GuidCompany = (Guid)this.GuidCompany;
				
				if(this.CreatedDate != null)
					if (this.CreatedDate != null)
				result.CreatedDate = (DateTime)this.CreatedDate;		
				
				if(this.UpdatedDate != null)
					if (this.UpdatedDate != null)
				result.UpdatedDate = (DateTime)this.UpdatedDate;		
				
	if (this.CreatedBy != null )
				result.CreatedBy = (Guid)this.CreatedBy;
				
	if (this.UpdatedBy != null )
				result.UpdatedBy = (Guid)this.UpdatedBy;
				
	if (this.Bytes != null )
				result.Bytes = (Int32)this.Bytes;
				
	if (this.IsDeleted != null )
				result.IsDeleted = (Boolean)this.IsDeleted;
				

            return result;
        }
        public void Bind(BusinessObjects.SDCasePriority businessObject)
        {
				this.BusinessObjectObject = businessObject;

			this.GuidCasePriority = businessObject.GuidCasePriority;
				
			this.Title = businessObject.Title != null ? businessObject.Title.Trim().Replace("\t", String.Empty) : "";
				
				
	if (businessObject.GuidCompany != null )
				this.GuidCompany = (Guid)businessObject.GuidCompany;
				if (businessObject.CreatedDate != null )
				this.CreatedDate = (DateTime)businessObject.CreatedDate;
				if (businessObject.UpdatedDate != null )
				this.UpdatedDate = (DateTime)businessObject.UpdatedDate;
				
	if (businessObject.CreatedBy != null )
				this.CreatedBy = (Guid)businessObject.CreatedBy;
				
	if (businessObject.UpdatedBy != null )
				this.UpdatedBy = (Guid)businessObject.UpdatedBy;
				
	if (businessObject.Bytes != null )
				this.Bytes = (Int32)businessObject.Bytes;
				
	if (businessObject.IsDeleted != null )
				this.IsDeleted = (Boolean)businessObject.IsDeleted;
           
        }
	}
}
	namespace SFS.ServiceDesk.Web.Mvc.Models.SDCaseStates 
	{
	public partial class SDCaseStateModel: ModelBase{

	  public SDCaseStateModel(BO.SDCaseState resultObj)
        {

            Bind(resultObj);
        }
#region Tags		
#endregion
		public SDCaseStateModel()
        {
		}
		public override string Id
        {
            get
            {
                return this.GuidCaseState.ToString();
            }
        }
			
			
        public override string ToString()
        {
			if (this.Title != null)
		
            return this.Title.ToString();
			else
				return "";
		
        }    
			

       
	
		[SystemProperty()]		
		public Guid? GuidCaseState{ get; set; }
		
	
[Exportable()]
	
	    [Required()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("TITLE"/*, NameResourceType=typeof(SDCaseStateResources)*/)]
	public String   Title { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("GUIDCOMPANY"/*, NameResourceType=typeof(SDCaseStateResources)*/)]
	public Guid  ? GuidCompany { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("CREATEDDATE"/*, NameResourceType=typeof(SDCaseStateResources)*/)]
	public DateTime  ? CreatedDate { get; set; }
	public string CreatedDateText {
        get {
            if (CreatedDate != null)
				return ((DateTime)CreatedDate).ToShortDateString() ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.CreatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("UPDATEDDATE"/*, NameResourceType=typeof(SDCaseStateResources)*/)]
	public DateTime  ? UpdatedDate { get; set; }
	public string UpdatedDateText {
        get {
            if (UpdatedDate != null)
			
                return ((DateTime)UpdatedDate).ToString("s") ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.UpdatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "CreatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("CREATEDBY"/*, NameResourceType=typeof(SDCaseStateResources)*/)]
	public Guid  ? CreatedBy { get; set; }
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "UpdatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("UPDATEDBY"/*, NameResourceType=typeof(SDCaseStateResources)*/)]
	public Guid  ? UpdatedBy { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DataType("Integer")]
	[LocalizedDisplayName("BYTES"/*, NameResourceType=typeof(SDCaseStateResources)*/)]
	public Int32  ? Bytes { get; set; }
	public string _BytesText = null;
    public string BytesText {
        get {
			if (string.IsNullOrEmpty( _BytesText ))
				{
	
            if (Bytes != null)
				return Bytes.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _BytesText ;
			}			
        }
		set{
			_BytesText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("ISDELETED"/*, NameResourceType=typeof(SDCaseStateResources)*/)]
	public Boolean  ? IsDeleted { get; set; }
	public string _IsDeletedText = null;
    public string IsDeletedText {
        get {
			if (string.IsNullOrEmpty( _IsDeletedText ))
				{
	
            if (IsDeleted != null)

				return IsDeleted.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _IsDeletedText ;
			}			
        }
		set{
			_IsDeletedText = value;
		}
        
    }

		
		
		
		[LocalizedDisplayName("SDCASES"/*, NameResourceType=typeof(SDCaseStateResources)*/)]
		[RelationFilterable(IsNavigationPropertyMany=true, FiltrablePropertyPathName="SDCases.Count()", ModelPartialType="SDCases.SDCase", BusinessObjectSetName = "SDCases")]
        public List<SDCases.SDCaseModel> SDCases { get; set; }			
	
		[LocalizedDisplayName("SDCASEHISTORIES"/*, NameResourceType=typeof(SDCaseStateResources)*/)]
		[RelationFilterable(IsNavigationPropertyMany=true, FiltrablePropertyPathName="SDCaseHistories.Count()", ModelPartialType="SDCaseHistories.SDCaseHistory", BusinessObjectSetName = "SDCaseHistories")]
        public List<SDCaseHistories.SDCaseHistoryModel> SDCaseHistories { get; set; }			
	
	public override string SafeKey
   	{
		get
        {
			if(this.GuidCaseState != null)
				return SFSdotNet.Framework.Entities.Utils.GetKey(this ,"GuidCaseState").Replace("/","-");
			else
				return String.Empty;
		}
    }		
		public void Bind(SDCaseStateModel model){
            
		this.GuidCaseState = model.GuidCaseState;
		this.Title = model.Title;
		this.GuidCompany = model.GuidCompany;
		this.CreatedDate = model.CreatedDate;
		this.UpdatedDate = model.UpdatedDate;
		this.CreatedBy = model.CreatedBy;
		this.UpdatedBy = model.UpdatedBy;
		this.Bytes = model.Bytes;
		this.IsDeleted = model.IsDeleted;
        }

        public BusinessObjects.SDCaseState GetBusinessObject()
        {
            BusinessObjects.SDCaseState result = new BusinessObjects.SDCaseState();


			       
	if (this.GuidCaseState != null )
				result.GuidCaseState = (Guid)this.GuidCaseState;
				
	if (this.Title != null )
				result.Title = (String)this.Title.Trim().Replace("\t", String.Empty);
				
	if (this.GuidCompany != null )
				result.GuidCompany = (Guid)this.GuidCompany;
				
				if(this.CreatedDate != null)
					if (this.CreatedDate != null)
				result.CreatedDate = (DateTime)this.CreatedDate;		
				
				if(this.UpdatedDate != null)
					if (this.UpdatedDate != null)
				result.UpdatedDate = (DateTime)this.UpdatedDate;		
				
	if (this.CreatedBy != null )
				result.CreatedBy = (Guid)this.CreatedBy;
				
	if (this.UpdatedBy != null )
				result.UpdatedBy = (Guid)this.UpdatedBy;
				
	if (this.Bytes != null )
				result.Bytes = (Int32)this.Bytes;
				
	if (this.IsDeleted != null )
				result.IsDeleted = (Boolean)this.IsDeleted;
				

            return result;
        }
        public void Bind(BusinessObjects.SDCaseState businessObject)
        {
				this.BusinessObjectObject = businessObject;

			this.GuidCaseState = businessObject.GuidCaseState;
				
			this.Title = businessObject.Title != null ? businessObject.Title.Trim().Replace("\t", String.Empty) : "";
				
				
	if (businessObject.GuidCompany != null )
				this.GuidCompany = (Guid)businessObject.GuidCompany;
				if (businessObject.CreatedDate != null )
				this.CreatedDate = (DateTime)businessObject.CreatedDate;
				if (businessObject.UpdatedDate != null )
				this.UpdatedDate = (DateTime)businessObject.UpdatedDate;
				
	if (businessObject.CreatedBy != null )
				this.CreatedBy = (Guid)businessObject.CreatedBy;
				
	if (businessObject.UpdatedBy != null )
				this.UpdatedBy = (Guid)businessObject.UpdatedBy;
				
	if (businessObject.Bytes != null )
				this.Bytes = (Int32)businessObject.Bytes;
				
	if (businessObject.IsDeleted != null )
				this.IsDeleted = (Boolean)businessObject.IsDeleted;
           
        }
	}
}
	namespace SFS.ServiceDesk.Web.Mvc.Models.SDFiles 
	{
	public partial class SDFileModel: ModelBase{

	  public SDFileModel(BO.SDFile resultObj)
        {

            Bind(resultObj);
        }
#region Tags		
#endregion
		public SDFileModel()
        {
		}
		public override string Id
        {
            get
            {
                return this.GuidFile.ToString();
            }
        }
			
			
        public override string ToString()
        {
			if (this.FileName != null)
		
            return this.FileName.ToString();
			else
				return "";
		
        }    
			

       
	
		[SystemProperty()]		
		public Guid? GuidFile{ get; set; }
		
	
[Exportable()]
	
	    [Required()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("FILENAME"/*, NameResourceType=typeof(SDFileResources)*/)]
	public String   FileName { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("FILETYPE"/*, NameResourceType=typeof(SDFileResources)*/)]
	public String   FileType { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[DataType("Integer")]
	[LocalizedDisplayName("FILESIZE"/*, NameResourceType=typeof(SDFileResources)*/)]
	public Int64  ? FileSize { get; set; }
	public string _FileSizeText = null;
    public string FileSizeText {
        get {
			if (string.IsNullOrEmpty( _FileSizeText ))
				{
	
            if (FileSize != null)
				return FileSize.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _FileSizeText ;
			}			
        }
		set{
			_FileSizeText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable()] 
 
	[DataType("File")]
	[LocalizedDisplayName("FILEDATA"/*, NameResourceType=typeof(SDFileResources)*/)]
	public Byte[]   FileData { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("GUIDCOMPANY"/*, NameResourceType=typeof(SDFileResources)*/)]
	public Guid  ? GuidCompany { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("CREATEDDATE"/*, NameResourceType=typeof(SDFileResources)*/)]
	public DateTime  ? CreatedDate { get; set; }
	public string CreatedDateText {
        get {
            if (CreatedDate != null)
				return ((DateTime)CreatedDate).ToShortDateString() ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.CreatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("UPDATEDDATE"/*, NameResourceType=typeof(SDFileResources)*/)]
	public DateTime  ? UpdatedDate { get; set; }
	public string UpdatedDateText {
        get {
            if (UpdatedDate != null)
			
                return ((DateTime)UpdatedDate).ToString("s") ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.UpdatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "CreatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("CREATEDBY"/*, NameResourceType=typeof(SDFileResources)*/)]
	public Guid  ? CreatedBy { get; set; }
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "UpdatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("UPDATEDBY"/*, NameResourceType=typeof(SDFileResources)*/)]
	public Guid  ? UpdatedBy { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DataType("Integer")]
	[LocalizedDisplayName("BYTES"/*, NameResourceType=typeof(SDFileResources)*/)]
	public Int32  ? Bytes { get; set; }
	public string _BytesText = null;
    public string BytesText {
        get {
			if (string.IsNullOrEmpty( _BytesText ))
				{
	
            if (Bytes != null)
				return Bytes.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _BytesText ;
			}			
        }
		set{
			_BytesText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("ISDELETED"/*, NameResourceType=typeof(SDFileResources)*/)]
	public Boolean  ? IsDeleted { get; set; }
	public string _IsDeletedText = null;
    public string IsDeletedText {
        get {
			if (string.IsNullOrEmpty( _IsDeletedText ))
				{
	
            if (IsDeleted != null)

				return IsDeleted.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _IsDeletedText ;
			}			
        }
		set{
			_IsDeletedText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("FILESTORAGE"/*, NameResourceType=typeof(SDFileResources)*/)]
	public String   FileStorage { get; set; }
		
		
		
		[LocalizedDisplayName("SDCASEFILES"/*, NameResourceType=typeof(SDFileResources)*/)]
		[RelationFilterable(IsNavigationPropertyMany=true, FiltrablePropertyPathName="SDCaseFiles.Count()", ModelPartialType="SDCaseFiles.SDCaseFile", BusinessObjectSetName = "SDCaseFiles")]
        public List<SDCaseFiles.SDCaseFileModel> SDCaseFiles { get; set; }			
	
		[LocalizedDisplayName("SDCASEHISTORYFILES"/*, NameResourceType=typeof(SDFileResources)*/)]
		[RelationFilterable(IsNavigationPropertyMany=true, FiltrablePropertyPathName="SDCaseHistoryFiles.Count()", ModelPartialType="SDCaseHistoryFiles.SDCaseHistoryFile", BusinessObjectSetName = "SDCaseHistoryFiles")]
        public List<SDCaseHistoryFiles.SDCaseHistoryFileModel> SDCaseHistoryFiles { get; set; }			
	
	public override string SafeKey
   	{
		get
        {
			if(this.GuidFile != null)
				return SFSdotNet.Framework.Entities.Utils.GetKey(this ,"GuidFile").Replace("/","-");
			else
				return String.Empty;
		}
    }		
		public void Bind(SDFileModel model){
            
		this.GuidFile = model.GuidFile;
		this.FileName = model.FileName;
		this.FileType = model.FileType;
		this.FileSize = model.FileSize;
		this.FileData = model.FileData;
		this.GuidCompany = model.GuidCompany;
		this.CreatedDate = model.CreatedDate;
		this.UpdatedDate = model.UpdatedDate;
		this.CreatedBy = model.CreatedBy;
		this.UpdatedBy = model.UpdatedBy;
		this.Bytes = model.Bytes;
		this.IsDeleted = model.IsDeleted;
		this.FileStorage = model.FileStorage;
        }

        public BusinessObjects.SDFile GetBusinessObject()
        {
            BusinessObjects.SDFile result = new BusinessObjects.SDFile();


			       
	if (this.GuidFile != null )
				result.GuidFile = (Guid)this.GuidFile;
				
	if (this.FileName != null )
				result.FileName = (String)this.FileName.Trim().Replace("\t", String.Empty);
				
	if (this.FileType != null )
				result.FileType = (String)this.FileType.Trim().Replace("\t", String.Empty);
				
	if (this.FileSize != null )
				result.FileSize = (Int64)this.FileSize;
				
				if(this.FileData != null)
					result.FileData = (Byte[])this.FileData;
			
				
	if (this.GuidCompany != null )
				result.GuidCompany = (Guid)this.GuidCompany;
				
				if(this.CreatedDate != null)
					if (this.CreatedDate != null)
				result.CreatedDate = (DateTime)this.CreatedDate;		
				
				if(this.UpdatedDate != null)
					if (this.UpdatedDate != null)
				result.UpdatedDate = (DateTime)this.UpdatedDate;		
				
	if (this.CreatedBy != null )
				result.CreatedBy = (Guid)this.CreatedBy;
				
	if (this.UpdatedBy != null )
				result.UpdatedBy = (Guid)this.UpdatedBy;
				
	if (this.Bytes != null )
				result.Bytes = (Int32)this.Bytes;
				
	if (this.IsDeleted != null )
				result.IsDeleted = (Boolean)this.IsDeleted;
				
	if (this.FileStorage != null )
				result.FileStorage = (String)this.FileStorage.Trim().Replace("\t", String.Empty);
				

            return result;
        }
        public void Bind(BusinessObjects.SDFile businessObject)
        {
				this.BusinessObjectObject = businessObject;

			this.GuidFile = businessObject.GuidFile;
				
			this.FileName = businessObject.FileName != null ? businessObject.FileName.Trim().Replace("\t", String.Empty) : "";
				
				
	if (businessObject.FileType != null )
				this.FileType = (String)businessObject.FileType;
				
	if (businessObject.FileSize != null )
				this.FileSize = (Int64)businessObject.FileSize;
			if (businessObject.FileData != null )
				this.FileData = businessObject.FileData;			
				
	if (businessObject.GuidCompany != null )
				this.GuidCompany = (Guid)businessObject.GuidCompany;
				if (businessObject.CreatedDate != null )
				this.CreatedDate = (DateTime)businessObject.CreatedDate;
				if (businessObject.UpdatedDate != null )
				this.UpdatedDate = (DateTime)businessObject.UpdatedDate;
				
	if (businessObject.CreatedBy != null )
				this.CreatedBy = (Guid)businessObject.CreatedBy;
				
	if (businessObject.UpdatedBy != null )
				this.UpdatedBy = (Guid)businessObject.UpdatedBy;
				
	if (businessObject.Bytes != null )
				this.Bytes = (Int32)businessObject.Bytes;
				
	if (businessObject.IsDeleted != null )
				this.IsDeleted = (Boolean)businessObject.IsDeleted;
				
	if (businessObject.FileStorage != null )
				this.FileStorage = (String)businessObject.FileStorage;
           
        }
	}
}
	namespace SFS.ServiceDesk.Web.Mvc.Models.SDOrganizations 
	{
	public partial class SDOrganizationModel: ModelBase{

	  public SDOrganizationModel(BO.SDOrganization resultObj)
        {

            Bind(resultObj);
        }
#region Tags		
#endregion
		public SDOrganizationModel()
        {
		}
		public override string Id
        {
            get
            {
                return this.GuidOrganization.ToString();
            }
        }
			
			
        public override string ToString()
        {
			if (this.FullName != null)
		
            return this.FullName.ToString();
			else
				return "";
		
        }    
			

       
	
		[SystemProperty()]		
		public Guid? GuidOrganization{ get; set; }
		
	
[Exportable()]
	
	    [Required()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("FULLNAME"/*, NameResourceType=typeof(SDOrganizationResources)*/)]
	public String   FullName { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("GUIDCOMPANY"/*, NameResourceType=typeof(SDOrganizationResources)*/)]
	public Guid  ? GuidCompany { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("CREATEDDATE"/*, NameResourceType=typeof(SDOrganizationResources)*/)]
	public DateTime  ? CreatedDate { get; set; }
	public string CreatedDateText {
        get {
            if (CreatedDate != null)
				return ((DateTime)CreatedDate).ToShortDateString() ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.CreatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("UPDATEDDATE"/*, NameResourceType=typeof(SDOrganizationResources)*/)]
	public DateTime  ? UpdatedDate { get; set; }
	public string UpdatedDateText {
        get {
            if (UpdatedDate != null)
			
                return ((DateTime)UpdatedDate).ToString("s") ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.UpdatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "CreatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("CREATEDBY"/*, NameResourceType=typeof(SDOrganizationResources)*/)]
	public Guid  ? CreatedBy { get; set; }
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "UpdatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("UPDATEDBY"/*, NameResourceType=typeof(SDOrganizationResources)*/)]
	public Guid  ? UpdatedBy { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DataType("Integer")]
	[LocalizedDisplayName("BYTES"/*, NameResourceType=typeof(SDOrganizationResources)*/)]
	public Int32  ? Bytes { get; set; }
	public string _BytesText = null;
    public string BytesText {
        get {
			if (string.IsNullOrEmpty( _BytesText ))
				{
	
            if (Bytes != null)
				return Bytes.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _BytesText ;
			}			
        }
		set{
			_BytesText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("ISDELETED"/*, NameResourceType=typeof(SDOrganizationResources)*/)]
	public Boolean  ? IsDeleted { get; set; }
	public string _IsDeletedText = null;
    public string IsDeletedText {
        get {
			if (string.IsNullOrEmpty( _IsDeletedText ))
				{
	
            if (IsDeleted != null)

				return IsDeleted.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _IsDeletedText ;
			}			
        }
		set{
			_IsDeletedText = value;
		}
        
    }

		
		
		
		[LocalizedDisplayName("SDAREAS"/*, NameResourceType=typeof(SDOrganizationResources)*/)]
		[RelationFilterable(IsNavigationPropertyMany=true, FiltrablePropertyPathName="SDAreas.Count()", ModelPartialType="SDAreas.SDArea", BusinessObjectSetName = "SDAreas")]
        public List<SDAreas.SDAreaModel> SDAreas { get; set; }			
	
		[LocalizedDisplayName("SDPERSONS"/*, NameResourceType=typeof(SDOrganizationResources)*/)]
		[RelationFilterable(IsNavigationPropertyMany=true, FiltrablePropertyPathName="SDPersons.Count()", ModelPartialType="SDPersons.SDPerson", BusinessObjectSetName = "SDPersons")]
        public List<SDPersons.SDPersonModel> SDPersons { get; set; }			
	
	public override string SafeKey
   	{
		get
        {
			if(this.GuidOrganization != null)
				return SFSdotNet.Framework.Entities.Utils.GetKey(this ,"GuidOrganization").Replace("/","-");
			else
				return String.Empty;
		}
    }		
		public void Bind(SDOrganizationModel model){
            
		this.GuidOrganization = model.GuidOrganization;
		this.FullName = model.FullName;
		this.GuidCompany = model.GuidCompany;
		this.CreatedDate = model.CreatedDate;
		this.UpdatedDate = model.UpdatedDate;
		this.CreatedBy = model.CreatedBy;
		this.UpdatedBy = model.UpdatedBy;
		this.Bytes = model.Bytes;
		this.IsDeleted = model.IsDeleted;
        }

        public BusinessObjects.SDOrganization GetBusinessObject()
        {
            BusinessObjects.SDOrganization result = new BusinessObjects.SDOrganization();


			       
	if (this.GuidOrganization != null )
				result.GuidOrganization = (Guid)this.GuidOrganization;
				
	if (this.FullName != null )
				result.FullName = (String)this.FullName.Trim().Replace("\t", String.Empty);
				
	if (this.GuidCompany != null )
				result.GuidCompany = (Guid)this.GuidCompany;
				
				if(this.CreatedDate != null)
					if (this.CreatedDate != null)
				result.CreatedDate = (DateTime)this.CreatedDate;		
				
				if(this.UpdatedDate != null)
					if (this.UpdatedDate != null)
				result.UpdatedDate = (DateTime)this.UpdatedDate;		
				
	if (this.CreatedBy != null )
				result.CreatedBy = (Guid)this.CreatedBy;
				
	if (this.UpdatedBy != null )
				result.UpdatedBy = (Guid)this.UpdatedBy;
				
	if (this.Bytes != null )
				result.Bytes = (Int32)this.Bytes;
				
	if (this.IsDeleted != null )
				result.IsDeleted = (Boolean)this.IsDeleted;
				

            return result;
        }
        public void Bind(BusinessObjects.SDOrganization businessObject)
        {
				this.BusinessObjectObject = businessObject;

			this.GuidOrganization = businessObject.GuidOrganization;
				
			this.FullName = businessObject.FullName != null ? businessObject.FullName.Trim().Replace("\t", String.Empty) : "";
				
				
	if (businessObject.GuidCompany != null )
				this.GuidCompany = (Guid)businessObject.GuidCompany;
				if (businessObject.CreatedDate != null )
				this.CreatedDate = (DateTime)businessObject.CreatedDate;
				if (businessObject.UpdatedDate != null )
				this.UpdatedDate = (DateTime)businessObject.UpdatedDate;
				
	if (businessObject.CreatedBy != null )
				this.CreatedBy = (Guid)businessObject.CreatedBy;
				
	if (businessObject.UpdatedBy != null )
				this.UpdatedBy = (Guid)businessObject.UpdatedBy;
				
	if (businessObject.Bytes != null )
				this.Bytes = (Int32)businessObject.Bytes;
				
	if (businessObject.IsDeleted != null )
				this.IsDeleted = (Boolean)businessObject.IsDeleted;
           
        }
	}
}
	namespace SFS.ServiceDesk.Web.Mvc.Models.SDPersons 
	{
	public partial class SDPersonModel: ModelBase{

	  public SDPersonModel(BO.SDPerson resultObj)
        {

            Bind(resultObj);
        }
#region Tags		
#endregion
		public SDPersonModel()
        {
		}
		public override string Id
        {
            get
            {
                return this.GuidPerson.ToString();
            }
        }
			
			
        public override string ToString()
        {
			if (this.DisplayName != null)
		
            return this.DisplayName.ToString();
			else
				return "";
		
        }    
			

       
	
		[SystemProperty()]		
		public Guid? GuidPerson{ get; set; }
		
	
[Exportable()]
	
	    [Required()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("DISPLAYNAME"/*, NameResourceType=typeof(SDPersonResources)*/)]
	public String   DisplayName { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("GUIDUSER"/*, NameResourceType=typeof(SDPersonResources)*/)]
	public Guid  ? GuidUser { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("GUIDORGANIZATION"/*, NameResourceType=typeof(SDPersonResources)*/)]
	public Guid  ? GuidOrganization { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("GUIDCOMPANY"/*, NameResourceType=typeof(SDPersonResources)*/)]
	public Guid  ? GuidCompany { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("CREATEDDATE"/*, NameResourceType=typeof(SDPersonResources)*/)]
	public DateTime  ? CreatedDate { get; set; }
	public string CreatedDateText {
        get {
            if (CreatedDate != null)
				return ((DateTime)CreatedDate).ToShortDateString() ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.CreatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DateTime(true, false, null)]	
	[LocalizedDisplayName("UPDATEDDATE"/*, NameResourceType=typeof(SDPersonResources)*/)]
	public DateTime  ? UpdatedDate { get; set; }
	public string UpdatedDateText {
        get {
            if (UpdatedDate != null)
			
                return ((DateTime)UpdatedDate).ToString("s") ;
            else
                return String.Empty;
        }
				set{
					if (!string.IsNullOrEmpty(value))
						this.UpdatedDate = Convert.ToDateTime(value);
    }
		}
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "CreatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("CREATEDBY"/*, NameResourceType=typeof(SDPersonResources)*/)]
	public Guid  ? CreatedBy { get; set; }
		
		
	
[Exportable()]
		
[RelationFilterable(FiltrablePropertyPathName = "UpdatedBy", IsExternal =true )]
[AutoComplete("SFSdotNetFrameworkSecurity", "secUsers", "FindUsers", "filter", "DisplayName", "GuidUser", true)]	

	[SystemProperty()]
	[LocalizedDisplayName("UPDATEDBY"/*, NameResourceType=typeof(SDPersonResources)*/)]
	public Guid  ? UpdatedBy { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[DataType("Integer")]
	[LocalizedDisplayName("BYTES"/*, NameResourceType=typeof(SDPersonResources)*/)]
	public Int32  ? Bytes { get; set; }
	public string _BytesText = null;
    public string BytesText {
        get {
			if (string.IsNullOrEmpty( _BytesText ))
				{
	
            if (Bytes != null)
				return Bytes.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _BytesText ;
			}			
        }
		set{
			_BytesText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[SystemProperty()]
	[LocalizedDisplayName("ISDELETED"/*, NameResourceType=typeof(SDPersonResources)*/)]
	public Boolean  ? IsDeleted { get; set; }
	public string _IsDeletedText = null;
    public string IsDeletedText {
        get {
			if (string.IsNullOrEmpty( _IsDeletedText ))
				{
	
            if (IsDeleted != null)

				return IsDeleted.ToString();
				
            else
                return String.Empty;
	
			}else{
				return _IsDeletedText ;
			}			
        }
		set{
			_IsDeletedText = value;
		}
        
    }

		
		
	
[Exportable()]
		
	[RelationFilterable(DataClassProvider = typeof(Controllers.SDOrganizationsController), GetByKeyMethod="GetByKey", GetAllMethod = "GetAll", DataPropertyText = "FullName", DataPropertyValue = "GuidOrganization", FiltrablePropertyPathName="SDOrganization.GuidOrganization")]	

	[LocalizedDisplayName("SDORGANIZATION"/*, NameResourceType=typeof(SDPersonResources)*/)]
	public Guid  ? FkSDOrganization { get; set; }
		[LocalizedDisplayName("SDORGANIZATION"/*, NameResourceType=typeof(SDPersonResources)*/)]
	[Exportable()]
	public string  FkSDOrganizationText { get; set; }
    public string FkSDOrganizationSafeKey { get; set; }

	
		
	
[Exportable()]
		
	[RelationFilterable(DataClassProvider = typeof(Controllers.SDProxyUsersController), GetByKeyMethod="GetByKey", GetAllMethod = "GetAll", DataPropertyText = "Email", DataPropertyValue = "GuidUser", FiltrablePropertyPathName="SDProxyUser.GuidUser")]	

	[LocalizedDisplayName("SDPROXYUSER"/*, NameResourceType=typeof(SDPersonResources)*/)]
	public Guid  ? FkSDProxyUser { get; set; }
		[LocalizedDisplayName("SDPROXYUSER"/*, NameResourceType=typeof(SDPersonResources)*/)]
	[Exportable()]
	public string  FkSDProxyUserText { get; set; }
    public string FkSDProxyUserSafeKey { get; set; }

	
		
		
		[LocalizedDisplayName("SDAREAPERSONS"/*, NameResourceType=typeof(SDPersonResources)*/)]
		[RelationFilterable(IsNavigationPropertyMany=true, FiltrablePropertyPathName="SDAreaPersons.Count()", ModelPartialType="SDAreaPersons.SDAreaPerson", BusinessObjectSetName = "SDAreaPersons")]
        public List<SDAreaPersons.SDAreaPersonModel> SDAreaPersons { get; set; }			
	
		[LocalizedDisplayName("SDCASES"/*, NameResourceType=typeof(SDPersonResources)*/)]
		[RelationFilterable(IsNavigationPropertyMany=true, FiltrablePropertyPathName="SDCases.Count()", ModelPartialType="SDCases.SDCase", BusinessObjectSetName = "SDCases")]
        public List<SDCases.SDCaseModel> SDCases { get; set; }			
	
	public override string SafeKey
   	{
		get
        {
			if(this.GuidPerson != null)
				return SFSdotNet.Framework.Entities.Utils.GetKey(this ,"GuidPerson").Replace("/","-");
			else
				return String.Empty;
		}
    }		
		public void Bind(SDPersonModel model){
            
		this.GuidPerson = model.GuidPerson;
		this.DisplayName = model.DisplayName;
		this.GuidUser = model.GuidUser;
		this.GuidOrganization = model.GuidOrganization;
		this.GuidCompany = model.GuidCompany;
		this.CreatedDate = model.CreatedDate;
		this.UpdatedDate = model.UpdatedDate;
		this.CreatedBy = model.CreatedBy;
		this.UpdatedBy = model.UpdatedBy;
		this.Bytes = model.Bytes;
		this.IsDeleted = model.IsDeleted;
        }

        public BusinessObjects.SDPerson GetBusinessObject()
        {
            BusinessObjects.SDPerson result = new BusinessObjects.SDPerson();


			       
	if (this.GuidPerson != null )
				result.GuidPerson = (Guid)this.GuidPerson;
				
	if (this.DisplayName != null )
				result.DisplayName = (String)this.DisplayName.Trim().Replace("\t", String.Empty);
				
	if (this.GuidUser != null )
				result.GuidUser = (Guid)this.GuidUser;
				
	if (this.GuidOrganization != null )
				result.GuidOrganization = (Guid)this.GuidOrganization;
				
	if (this.GuidCompany != null )
				result.GuidCompany = (Guid)this.GuidCompany;
				
				if(this.CreatedDate != null)
					if (this.CreatedDate != null)
				result.CreatedDate = (DateTime)this.CreatedDate;		
				
				if(this.UpdatedDate != null)
					if (this.UpdatedDate != null)
				result.UpdatedDate = (DateTime)this.UpdatedDate;		
				
	if (this.CreatedBy != null )
				result.CreatedBy = (Guid)this.CreatedBy;
				
	if (this.UpdatedBy != null )
				result.UpdatedBy = (Guid)this.UpdatedBy;
				
	if (this.Bytes != null )
				result.Bytes = (Int32)this.Bytes;
				
	if (this.IsDeleted != null )
				result.IsDeleted = (Boolean)this.IsDeleted;
				
			
			if(this.FkSDOrganization != null || this.GuidOrganization != null){
			if (GuidOrganization != null && this.FkSDOrganization == null) this.FkSDOrganization = GuidOrganization; 
			result.SDOrganization = new BusinessObjects.SDOrganization() { GuidOrganization= (Guid)this.FkSDOrganization };

			
			}
				
			
			if(this.FkSDProxyUser != null || this.GuidUser != null){
			if (GuidUser != null && this.FkSDProxyUser == null) this.FkSDProxyUser = GuidUser; 
			result.SDProxyUser = new BusinessObjects.SDProxyUser() { GuidUser= (Guid)this.FkSDProxyUser };

			
			}
				

            return result;
        }
        public void Bind(BusinessObjects.SDPerson businessObject)
        {
				this.BusinessObjectObject = businessObject;

			this.GuidPerson = businessObject.GuidPerson;
				
			this.DisplayName = businessObject.DisplayName != null ? businessObject.DisplayName.Trim().Replace("\t", String.Empty) : "";
				
				
	if (businessObject.GuidUser != null )
				this.GuidUser = (Guid)businessObject.GuidUser;
				
	if (businessObject.GuidOrganization != null )
				this.GuidOrganization = (Guid)businessObject.GuidOrganization;
				
	if (businessObject.GuidCompany != null )
				this.GuidCompany = (Guid)businessObject.GuidCompany;
				if (businessObject.CreatedDate != null )
				this.CreatedDate = (DateTime)businessObject.CreatedDate;
				if (businessObject.UpdatedDate != null )
				this.UpdatedDate = (DateTime)businessObject.UpdatedDate;
				
	if (businessObject.CreatedBy != null )
				this.CreatedBy = (Guid)businessObject.CreatedBy;
				
	if (businessObject.UpdatedBy != null )
				this.UpdatedBy = (Guid)businessObject.UpdatedBy;
				
	if (businessObject.Bytes != null )
				this.Bytes = (Int32)businessObject.Bytes;
				
	if (businessObject.IsDeleted != null )
				this.IsDeleted = (Boolean)businessObject.IsDeleted;
	        if (businessObject.SDOrganization != null){
	                	this.FkSDOrganizationText = businessObject.SDOrganization.FullName != null ? businessObject.SDOrganization.FullName.ToString() : "";; 
										
										
				this.FkSDOrganization = businessObject.SDOrganization.GuidOrganization;
                this.FkSDOrganizationSafeKey  = SFSdotNet.Framework.Entities.Utils.GetKey(businessObject.SDOrganization,"GuidOrganization").Replace("/","-");

			}
	        if (businessObject.SDProxyUser != null){
	                	this.FkSDProxyUserText = businessObject.SDProxyUser.Email != null ? businessObject.SDProxyUser.Email.ToString() : "";; 
										
										
				this.FkSDProxyUser = businessObject.SDProxyUser.GuidUser;
                this.FkSDProxyUserSafeKey  = SFSdotNet.Framework.Entities.Utils.GetKey(businessObject.SDProxyUser,"GuidUser").Replace("/","-");

			}
           
        }
	}
}
	namespace SFS.ServiceDesk.Web.Mvc.Models.SDProxyUsers 
	{
	public partial class SDProxyUserModel: ModelBase{

	  public SDProxyUserModel(BO.SDProxyUser resultObj)
        {

            Bind(resultObj);
        }
#region Tags		
#endregion
		public SDProxyUserModel()
        {
		}
		public override string Id
        {
            get
            {
                return this.GuidUser.ToString();
            }
        }
			
			
        public override string ToString()
        {
			if (this.Email != null)
		
            return this.Email.ToString();
			else
				return "";
		
        }    
			

       
	
		[SystemProperty()]		
		public Guid? GuidUser{ get; set; }
		
	
[Exportable()]
	
	    [Required()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("EMAIL"/*, NameResourceType=typeof(SDProxyUserResources)*/)]
	public String   Email { get; set; }
		
		
	
[Exportable()]
		
	[RelationFilterable()] 
	[LocalizedDisplayName("DISPLAYNAME"/*, NameResourceType=typeof(SDProxyUserResources)*/)]
	public String   DisplayName { get; set; }
		
		
		
		[LocalizedDisplayName("SDPERSONS"/*, NameResourceType=typeof(SDProxyUserResources)*/)]
		[RelationFilterable(IsNavigationPropertyMany=true, FiltrablePropertyPathName="SDPersons.Count()", ModelPartialType="SDPersons.SDPerson", BusinessObjectSetName = "SDPersons")]
        public List<SDPersons.SDPersonModel> SDPersons { get; set; }			
	
	public override string SafeKey
   	{
		get
        {
			if(this.GuidUser != null)
				return SFSdotNet.Framework.Entities.Utils.GetKey(this ,"GuidUser").Replace("/","-");
			else
				return String.Empty;
		}
    }		
		public void Bind(SDProxyUserModel model){
            
		this.GuidUser = model.GuidUser;
		this.Email = model.Email;
		this.DisplayName = model.DisplayName;
        }

        public BusinessObjects.SDProxyUser GetBusinessObject()
        {
            BusinessObjects.SDProxyUser result = new BusinessObjects.SDProxyUser();


			       
	if (this.GuidUser != null )
				result.GuidUser = (Guid)this.GuidUser;
				
	if (this.Email != null )
				result.Email = (String)this.Email.Trim().Replace("\t", String.Empty);
				
	if (this.DisplayName != null )
				result.DisplayName = (String)this.DisplayName.Trim().Replace("\t", String.Empty);
				

            return result;
        }
        public void Bind(BusinessObjects.SDProxyUser businessObject)
        {
				this.BusinessObjectObject = businessObject;

			this.GuidUser = businessObject.GuidUser;
				
			this.Email = businessObject.Email != null ? businessObject.Email.Trim().Replace("\t", String.Empty) : "";
				
				
	if (businessObject.DisplayName != null )
				this.DisplayName = (String)businessObject.DisplayName;
           
        }
	}
}
