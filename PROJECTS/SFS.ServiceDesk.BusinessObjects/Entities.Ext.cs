 
 

// <Template>
//   <SolutionTemplate>EF POCO 1</SolutionTemplate>
//   <Version>20140822.0944</Version>
//   <Update>Metadata de identificador</Update>
// </Template>
#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using SFSdotNet.Framework.Common.Entities.Metadata;
using SFSdotNet.Framework.Common.Entities;
using System.Linq.Dynamic;

    using Newtonsoft.Json;

//using Repository.Pattern.Ef6;
#endregion
namespace SFS.ServiceDesk.BusinessObjects
{

	  [Serializable()]
	  [EntityInfo(PropertyKeyName="GuidArea",PropertyDefaultText="Name",RequiredProperties="Name", CompanyPropertyName = "GuidCompany",CreatedByPropertyName="CreatedBy",UpdatedByPropertyName="UpdatedBy",CreatedDatePropertyName="CreatedDate",UpdatedDatePropertyName="UpdatedDate",DeletedPropertyName="IsDeleted")]
	  [DynamicLinqType]
	  [JsonObject(IsReference = true)]
      [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]

	  public partial class SDArea:  ITrackable, IMyEntity{
			
            public double? _UpdatedDateTS
            {
                get
                {
                    if (this.UpdatedDate != null)
                    {
                        return (this.UpdatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			
            public double? _CreatedDateTS
            {
                get
                {
                    if (this.CreatedDate != null)
                    {
                        return (this.CreatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			public SFSdotNet.Framework.Common.GlobalObjects.UserInfo CreatedByUser { get; set; }

			public override string ToString()
            {
	
				if (this.Name != null )		
            		return this.Name.ToString();
				else
					return String.Empty;
			}

		//public SDArea()
        //  {

        //  }

	  #region Composite Key
	   public string Key { 
                  get {
                      StringBuilder sb = new StringBuilder();
					sb.Append(this.GuidArea.ToString());
                      return sb.ToString();
                } 
		}
        [Serializable()]
        [DataContract]
        public class CompositeKey {

			
            public CompositeKey(Guid guidArea)
            {
				_GuidArea = guidArea;

            }
			private Guid _GuidArea;
			[DataMember]
			public Guid GuidArea
			{
				get{
					return _GuidArea;
				}
				set{
                     
					_GuidArea = value;
				}
	        }

            
        }
        #endregion

		public SDArea(){
		#region 
			this.ModifiedProperties = new List<string>();
	this.SDArea1 = new List<SDArea>();


	this.SDAreaPersons = new List<SDAreaPerson>();


		#endregion
		}
		#region
	
	[DataMember]
	public ICollection<SDArea> SDArea1 { get; set; }
	

	
	[DataMember]
	public ICollection<SDAreaPerson> SDAreaPersons { get; set; }
	


	private SDArea __SDArea2;
	[DataMember]
	public SDArea SDArea2 {
		get{
			return __SDArea2;
		}
		set{
			__SDArea2 = value;
				if (value != null)
                {
                   this.__GuidAreaParent = value.GuidArea;
                }else
                {
					                    this.__GuidAreaParent = null;
					                }
		}
	}
	

	private SDOrganization __SDOrganization;
	[DataMember]
	public SDOrganization SDOrganization {
		get{
			return __SDOrganization;
		}
		set{
			__SDOrganization = value;
				if (value != null)
                {
                   this.__GuidOrganization = value.GuidOrganization;
                }else
                {
					                    this.__GuidOrganization = null;
					                }
		}
	}
	


	#endregion

	#region
	private Guid __GuidArea;
	[DataMember]
	public Guid GuidArea  { 
		get{
			return __GuidArea;
		}
		set{

			__GuidArea = value;
			
		}
	 }
	private String __Name;
	[DataMember]
	public String Name  { 
		get{
			return __Name;
		}
		set{

			__Name = value;
			
		}
	 }
	private Guid? __GuidAreaParent;
	[DataMember]
	public Guid? GuidAreaParent  { 
		get{
			return __GuidAreaParent;
		}
		set{

			__GuidAreaParent = value;
				if (value == null)
                {
                    this.__SDArea2 = null;
                }else
                {
											if (this.__SDArea2 != null && this.__SDArea2.GuidArea != value.Value)
						{
							this.__SDArea2 = new SDArea() { GuidArea = value.Value };

						}
                    //this.__SDArea2 = new SDArea() { GuidArea = value.Value };
					  // if (this.__SDArea2 == null )
                      //      this.__SDArea2 = new SDArea() {  GuidArea = value.Value };
                      //  else {
                       //     if (this.__SDArea2.GuidArea != value)
                       //     {
                       //     this.__SDArea2 = new SDArea() {  GuidArea = value.Value };
					//		}
                     //   }
					                }
			
		}
	 }
	private Guid? __GuidOrganization;
	[DataMember]
	public Guid? GuidOrganization  { 
		get{
			return __GuidOrganization;
		}
		set{

			__GuidOrganization = value;
				if (value == null)
                {
                    this.__SDOrganization = null;
                }else
                {
											if (this.__SDOrganization != null && this.__SDOrganization.GuidOrganization != value.Value)
						{
							this.__SDOrganization = new SDOrganization() { GuidOrganization = value.Value };

						}
                    //this.__SDOrganization = new SDOrganization() { GuidOrganization = value.Value };
					  // if (this.__SDOrganization == null )
                      //      this.__SDOrganization = new SDOrganization() {  GuidOrganization = value.Value };
                      //  else {
                       //     if (this.__SDOrganization.GuidOrganization != value)
                       //     {
                       //     this.__SDOrganization = new SDOrganization() {  GuidOrganization = value.Value };
					//		}
                     //   }
					                }
			
		}
	 }
	private Guid? __GuidCompany;
	[DataMember]
	public Guid? GuidCompany  { 
		get{
			return __GuidCompany;
		}
		set{

			__GuidCompany = value;
			
		}
	 }
	private DateTime? __CreatedDate;
	[DataMember]
	public DateTime? CreatedDate  { 
		get{
			return __CreatedDate;
		}
		set{

			__CreatedDate = value;
			
		}
	 }
	private DateTime? __UpdatedDate;
	[DataMember]
	public DateTime? UpdatedDate  { 
		get{
			return __UpdatedDate;
		}
		set{

			__UpdatedDate = value;
			
		}
	 }
	private Guid? __CreatedBy;
	[DataMember]
	public Guid? CreatedBy  { 
		get{
			return __CreatedBy;
		}
		set{

			__CreatedBy = value;
			
		}
	 }
	private Guid? __UpdatedBy;
	[DataMember]
	public Guid? UpdatedBy  { 
		get{
			return __UpdatedBy;
		}
		set{

			__UpdatedBy = value;
			
		}
	 }
	private Int32? __Bytes;
	[DataMember]
	public Int32? Bytes  { 
		get{
			return __Bytes;
		}
		set{

			__Bytes = value;
			
		}
	 }
	private Boolean? __IsDeleted;
	[DataMember]
	public Boolean? IsDeleted  { 
		get{
			return __IsDeleted;
		}
		set{

			__IsDeleted = value;
			
		}
	 }
    #endregion    
	
	[DataMember]
    public TrackingState TrackingState { get; set; }
    [DataMember]
    public ICollection<string> ModifiedProperties { get; set; }
    [JsonProperty, DataMember]
    private Guid EntityIdentifier { get; set; }

      


	      #region propertyNames
		public static readonly string EntityName = "SDArea";
		public static readonly string EntitySetName = "SDAreas";
        public struct PropertyNames {
            public static readonly string GuidArea = "GuidArea";
            public static readonly string Name = "Name";
            public static readonly string GuidAreaParent = "GuidAreaParent";
            public static readonly string GuidOrganization = "GuidOrganization";
            public static readonly string GuidCompany = "GuidCompany";
            public static readonly string CreatedDate = "CreatedDate";
            public static readonly string UpdatedDate = "UpdatedDate";
            public static readonly string CreatedBy = "CreatedBy";
            public static readonly string UpdatedBy = "UpdatedBy";
            public static readonly string Bytes = "Bytes";
            public static readonly string IsDeleted = "IsDeleted";
            public static readonly string SDArea1 = "SDArea1";
            public static readonly string SDArea2 = "SDArea2";
            public static readonly string SDOrganization = "SDOrganization";
            public static readonly string SDAreaPersons = "SDAreaPersons";
		}
		#endregion
	}
		  [Serializable()]
	  [EntityInfo(PropertyKeyName="GuidAreaPerson",PropertyDefaultText="Bytes", CompanyPropertyName = "GuidCompany",CreatedByPropertyName="CreatedBy",UpdatedByPropertyName="UpdatedBy",CreatedDatePropertyName="CreatedDate",UpdatedDatePropertyName="UpdatedDate",DeletedPropertyName="IsDeleted")]
	  [DynamicLinqType]
	  [JsonObject(IsReference = true)]
      [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]

	  public partial class SDAreaPerson:  ITrackable, IMyEntity{
			
            public double? _UpdatedDateTS
            {
                get
                {
                    if (this.UpdatedDate != null)
                    {
                        return (this.UpdatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			
            public double? _CreatedDateTS
            {
                get
                {
                    if (this.CreatedDate != null)
                    {
                        return (this.CreatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			public SFSdotNet.Framework.Common.GlobalObjects.UserInfo CreatedByUser { get; set; }

			public override string ToString()
            {
	
				if (this.Bytes != null )		
            		return this.Bytes.ToString();
				else
					return String.Empty;
			}

		//public SDAreaPerson()
        //  {

        //  }

	  #region Composite Key
	   public string Key { 
                  get {
                      StringBuilder sb = new StringBuilder();
					sb.Append(this.GuidAreaPerson.ToString());
                      return sb.ToString();
                } 
		}
        [Serializable()]
        [DataContract]
        public class CompositeKey {

			
            public CompositeKey(Guid guidAreaPerson)
            {
				_GuidAreaPerson = guidAreaPerson;

            }
			private Guid _GuidAreaPerson;
			[DataMember]
			public Guid GuidAreaPerson
			{
				get{
					return _GuidAreaPerson;
				}
				set{
                     
					_GuidAreaPerson = value;
				}
	        }

            
        }
        #endregion

		public SDAreaPerson(){
		#region 
			this.ModifiedProperties = new List<string>();
		#endregion
		}
		#region

	private SDArea __SDArea;
	[DataMember]
	public SDArea SDArea {
		get{
			return __SDArea;
		}
		set{
			__SDArea = value;
				if (value != null)
                {
                   this.__GuidArea = value.GuidArea;
                }else
                {
					                    this.__GuidArea = null;
					                }
		}
	}
	

	private SDPerson __SDPerson;
	[DataMember]
	public SDPerson SDPerson {
		get{
			return __SDPerson;
		}
		set{
			__SDPerson = value;
				if (value != null)
                {
                   this.__GuidPerson = value.GuidPerson;
                }else
                {
					                    this.__GuidPerson = null;
					                }
		}
	}
	


	#endregion

	#region
	private Guid __GuidAreaPerson;
	[DataMember]
	public Guid GuidAreaPerson  { 
		get{
			return __GuidAreaPerson;
		}
		set{

			__GuidAreaPerson = value;
			
		}
	 }
	private Guid? __GuidArea;
	[DataMember]
	public Guid? GuidArea  { 
		get{
			return __GuidArea;
		}
		set{

			__GuidArea = value;
				if (value == null)
                {
                    this.__SDArea = null;
                }else
                {
											if (this.__SDArea != null && this.__SDArea.GuidArea != value.Value)
						{
							this.__SDArea = new SDArea() { GuidArea = value.Value };

						}
                    //this.__SDArea = new SDArea() { GuidArea = value.Value };
					  // if (this.__SDArea == null )
                      //      this.__SDArea = new SDArea() {  GuidArea = value.Value };
                      //  else {
                       //     if (this.__SDArea.GuidArea != value)
                       //     {
                       //     this.__SDArea = new SDArea() {  GuidArea = value.Value };
					//		}
                     //   }
					                }
			
		}
	 }
	private Guid? __GuidPerson;
	[DataMember]
	public Guid? GuidPerson  { 
		get{
			return __GuidPerson;
		}
		set{

			__GuidPerson = value;
				if (value == null)
                {
                    this.__SDPerson = null;
                }else
                {
											if (this.__SDPerson != null && this.__SDPerson.GuidPerson != value.Value)
						{
							this.__SDPerson = new SDPerson() { GuidPerson = value.Value };

						}
                    //this.__SDPerson = new SDPerson() { GuidPerson = value.Value };
					  // if (this.__SDPerson == null )
                      //      this.__SDPerson = new SDPerson() {  GuidPerson = value.Value };
                      //  else {
                       //     if (this.__SDPerson.GuidPerson != value)
                       //     {
                       //     this.__SDPerson = new SDPerson() {  GuidPerson = value.Value };
					//		}
                     //   }
					                }
			
		}
	 }
	private Guid? __GuidCompany;
	[DataMember]
	public Guid? GuidCompany  { 
		get{
			return __GuidCompany;
		}
		set{

			__GuidCompany = value;
			
		}
	 }
	private DateTime? __CreatedDate;
	[DataMember]
	public DateTime? CreatedDate  { 
		get{
			return __CreatedDate;
		}
		set{

			__CreatedDate = value;
			
		}
	 }
	private DateTime? __UpdatedDate;
	[DataMember]
	public DateTime? UpdatedDate  { 
		get{
			return __UpdatedDate;
		}
		set{

			__UpdatedDate = value;
			
		}
	 }
	private Guid? __CreatedBy;
	[DataMember]
	public Guid? CreatedBy  { 
		get{
			return __CreatedBy;
		}
		set{

			__CreatedBy = value;
			
		}
	 }
	private Guid? __UpdatedBy;
	[DataMember]
	public Guid? UpdatedBy  { 
		get{
			return __UpdatedBy;
		}
		set{

			__UpdatedBy = value;
			
		}
	 }
	private Int32? __Bytes;
	[DataMember]
	public Int32? Bytes  { 
		get{
			return __Bytes;
		}
		set{

			__Bytes = value;
			
		}
	 }
	private Boolean? __IsDeleted;
	[DataMember]
	public Boolean? IsDeleted  { 
		get{
			return __IsDeleted;
		}
		set{

			__IsDeleted = value;
			
		}
	 }
    #endregion    
	
	[DataMember]
    public TrackingState TrackingState { get; set; }
    [DataMember]
    public ICollection<string> ModifiedProperties { get; set; }
    [JsonProperty, DataMember]
    private Guid EntityIdentifier { get; set; }

      


	      #region propertyNames
		public static readonly string EntityName = "SDAreaPerson";
		public static readonly string EntitySetName = "SDAreaPersons";
        public struct PropertyNames {
            public static readonly string GuidAreaPerson = "GuidAreaPerson";
            public static readonly string GuidArea = "GuidArea";
            public static readonly string GuidPerson = "GuidPerson";
            public static readonly string GuidCompany = "GuidCompany";
            public static readonly string CreatedDate = "CreatedDate";
            public static readonly string UpdatedDate = "UpdatedDate";
            public static readonly string CreatedBy = "CreatedBy";
            public static readonly string UpdatedBy = "UpdatedBy";
            public static readonly string Bytes = "Bytes";
            public static readonly string IsDeleted = "IsDeleted";
            public static readonly string SDArea = "SDArea";
            public static readonly string SDPerson = "SDPerson";
		}
		#endregion
	}
		  [Serializable()]
	  [EntityInfo(PropertyKeyName="GuidCase",PropertyDefaultText="BodyContent",RequiredProperties="GuidCaseState,GuidCasePriority,SDCasePriority,SDCaseState", CompanyPropertyName = "GuidCompany",CreatedByPropertyName="CreatedBy",UpdatedByPropertyName="UpdatedBy",CreatedDatePropertyName="CreatedDate",UpdatedDatePropertyName="UpdatedDate",DeletedPropertyName="IsDeleted")]
	  [DynamicLinqType]
	  [JsonObject(IsReference = true)]
      [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]

	  public partial class SDCase:  ITrackable, IMyEntity{
			
            public double? _UpdatedDateTS
            {
                get
                {
                    if (this.UpdatedDate != null)
                    {
                        return (this.UpdatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			
            public double? _CreatedDateTS
            {
                get
                {
                    if (this.CreatedDate != null)
                    {
                        return (this.CreatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			public SFSdotNet.Framework.Common.GlobalObjects.UserInfo CreatedByUser { get; set; }

			public override string ToString()
            {
	
				if (this.BodyContent != null )		
            		return this.BodyContent.ToString();
				else
					return String.Empty;
			}

		//public SDCase()
        //  {

        //  }

	  #region Composite Key
	   public string Key { 
                  get {
                      StringBuilder sb = new StringBuilder();
					sb.Append(this.GuidCase.ToString());
                      return sb.ToString();
                } 
		}
        [Serializable()]
        [DataContract]
        public class CompositeKey {

			
            public CompositeKey(Guid guidCase)
            {
				_GuidCase = guidCase;

            }
			private Guid _GuidCase;
			[DataMember]
			public Guid GuidCase
			{
				get{
					return _GuidCase;
				}
				set{
                     
					_GuidCase = value;
				}
	        }

            
        }
        #endregion

		public SDCase(){
		#region 
			this.ModifiedProperties = new List<string>();
	this.SDCaseFiles = new List<SDCaseFile>();


	this.SDCaseHistories = new List<SDCaseHistory>();


		#endregion
		}
		#region
	
	[DataMember]
	public ICollection<SDCaseFile> SDCaseFiles { get; set; }
	

	
	[DataMember]
	public ICollection<SDCaseHistory> SDCaseHistories { get; set; }
	


	private SDPerson __SDPerson;
	[DataMember]
	public SDPerson SDPerson {
		get{
			return __SDPerson;
		}
		set{
			__SDPerson = value;
				if (value != null)
                {
                   this.__GuidPersonClient = value.GuidPerson;
                }else
                {
					                    this.__GuidPersonClient = null;
					                }
		}
	}
	

	private SDCasePriority __SDCasePriority;
	[DataMember]
	public SDCasePriority SDCasePriority {
		get{
			return __SDCasePriority;
		}
		set{
			__SDCasePriority = value;
				if (value != null)
                {
                   this.__GuidCasePriority = value.GuidCasePriority;
                }else
                {
											 this.__GuidCasePriority = Guid.Empty;
					                }
		}
	}
	

	private SDCaseState __SDCaseState;
	[DataMember]
	public SDCaseState SDCaseState {
		get{
			return __SDCaseState;
		}
		set{
			__SDCaseState = value;
				if (value != null)
                {
                   this.__GuidCaseState = value.GuidCaseState;
                }else
                {
											 this.__GuidCaseState = Guid.Empty;
					                }
		}
	}
	


	#endregion

	#region
	private Guid __GuidCase;
	[DataMember]
	public Guid GuidCase  { 
		get{
			return __GuidCase;
		}
		set{

			__GuidCase = value;
			
		}
	 }
	private Guid __GuidCaseState;
	[DataMember]
	public Guid GuidCaseState  { 
		get{
			return __GuidCaseState;
		}
		set{

			__GuidCaseState = value;
				if (value == null)
                {
                    this.__SDCaseState = null;
                }else
                {
					                      //this.__SDCaseState = new SDCaseState() { GuidCaseState = value };
					     if (this.__SDCaseState != null && this.__SDCaseState.GuidCaseState != value)
						{
							this.__SDCaseState = new SDCaseState() { GuidCaseState = value };

						}
						// if (this.__SDCaseState == null )
                        //    this.__SDCaseState = new SDCaseState() {  GuidCaseState = value };
                        //else {
                        //    if (this.__SDCaseState.GuidCaseState != value)
                        //    {
                        //    this.__SDCaseState = new SDCaseState() {  GuidCaseState = value };
						//	}
                        //}
					                }
			
		}
	 }
	private Guid? __GuidPersonClient;
	[DataMember]
	public Guid? GuidPersonClient  { 
		get{
			return __GuidPersonClient;
		}
		set{

			__GuidPersonClient = value;
				if (value == null)
                {
                    this.__SDPerson = null;
                }else
                {
											if (this.__SDPerson != null && this.__SDPerson.GuidPerson != value.Value)
						{
							this.__SDPerson = new SDPerson() { GuidPerson = value.Value };

						}
                    //this.__SDPerson = new SDPerson() { GuidPerson = value.Value };
					  // if (this.__SDPerson == null )
                      //      this.__SDPerson = new SDPerson() {  GuidPerson = value.Value };
                      //  else {
                       //     if (this.__SDPerson.GuidPerson != value)
                       //     {
                       //     this.__SDPerson = new SDPerson() {  GuidPerson = value.Value };
					//		}
                     //   }
					                }
			
		}
	 }
	private DateTime? __ClosedDateTime;
	[DataMember]
	public DateTime? ClosedDateTime  { 
		get{
			return __ClosedDateTime;
		}
		set{

			__ClosedDateTime = value;
			
		}
	 }
	private String __BodyContent;
	[DataMember]
	public String BodyContent  { 
		get{
			return __BodyContent;
		}
		set{

			__BodyContent = value;
			
		}
	 }
	private String __PreviewContent;
	[DataMember]
	public String PreviewContent  { 
		get{
			return __PreviewContent;
		}
		set{

			__PreviewContent = value;
			
		}
	 }
	private Guid __GuidCasePriority;
	[DataMember]
	public Guid GuidCasePriority  { 
		get{
			return __GuidCasePriority;
		}
		set{

			__GuidCasePriority = value;
				if (value == null)
                {
                    this.__SDCasePriority = null;
                }else
                {
					                      //this.__SDCasePriority = new SDCasePriority() { GuidCasePriority = value };
					     if (this.__SDCasePriority != null && this.__SDCasePriority.GuidCasePriority != value)
						{
							this.__SDCasePriority = new SDCasePriority() { GuidCasePriority = value };

						}
						// if (this.__SDCasePriority == null )
                        //    this.__SDCasePriority = new SDCasePriority() {  GuidCasePriority = value };
                        //else {
                        //    if (this.__SDCasePriority.GuidCasePriority != value)
                        //    {
                        //    this.__SDCasePriority = new SDCasePriority() {  GuidCasePriority = value };
						//	}
                        //}
					                }
			
		}
	 }
	private String __Title;
	[DataMember]
	public String Title  { 
		get{
			return __Title;
		}
		set{

			__Title = value;
			
		}
	 }
	private Guid? __GuidCompany;
	[DataMember]
	public Guid? GuidCompany  { 
		get{
			return __GuidCompany;
		}
		set{

			__GuidCompany = value;
			
		}
	 }
	private DateTime? __CreatedDate;
	[DataMember]
	public DateTime? CreatedDate  { 
		get{
			return __CreatedDate;
		}
		set{

			__CreatedDate = value;
			
		}
	 }
	private DateTime? __UpdatedDate;
	[DataMember]
	public DateTime? UpdatedDate  { 
		get{
			return __UpdatedDate;
		}
		set{

			__UpdatedDate = value;
			
		}
	 }
	private Guid? __CreatedBy;
	[DataMember]
	public Guid? CreatedBy  { 
		get{
			return __CreatedBy;
		}
		set{

			__CreatedBy = value;
			
		}
	 }
	private Guid? __UpdatedBy;
	[DataMember]
	public Guid? UpdatedBy  { 
		get{
			return __UpdatedBy;
		}
		set{

			__UpdatedBy = value;
			
		}
	 }
	private Int32? __Bytes;
	[DataMember]
	public Int32? Bytes  { 
		get{
			return __Bytes;
		}
		set{

			__Bytes = value;
			
		}
	 }
	private Boolean? __IsDeleted;
	[DataMember]
	public Boolean? IsDeleted  { 
		get{
			return __IsDeleted;
		}
		set{

			__IsDeleted = value;
			
		}
	 }
    #endregion    
	
	[DataMember]
    public TrackingState TrackingState { get; set; }
    [DataMember]
    public ICollection<string> ModifiedProperties { get; set; }
    [JsonProperty, DataMember]
    private Guid EntityIdentifier { get; set; }

      


	      #region propertyNames
		public static readonly string EntityName = "SDCase";
		public static readonly string EntitySetName = "SDCases";
        public struct PropertyNames {
            public static readonly string GuidCase = "GuidCase";
            public static readonly string GuidCaseState = "GuidCaseState";
            public static readonly string GuidPersonClient = "GuidPersonClient";
            public static readonly string ClosedDateTime = "ClosedDateTime";
            public static readonly string BodyContent = "BodyContent";
            public static readonly string PreviewContent = "PreviewContent";
            public static readonly string GuidCasePriority = "GuidCasePriority";
            public static readonly string Title = "Title";
            public static readonly string GuidCompany = "GuidCompany";
            public static readonly string CreatedDate = "CreatedDate";
            public static readonly string UpdatedDate = "UpdatedDate";
            public static readonly string CreatedBy = "CreatedBy";
            public static readonly string UpdatedBy = "UpdatedBy";
            public static readonly string Bytes = "Bytes";
            public static readonly string IsDeleted = "IsDeleted";
            public static readonly string SDPerson = "SDPerson";
            public static readonly string SDCasePriority = "SDCasePriority";
            public static readonly string SDCaseState = "SDCaseState";
            public static readonly string SDCaseFiles = "SDCaseFiles";
            public static readonly string SDCaseHistories = "SDCaseHistories";
		}
		#endregion
	}
		  [Serializable()]
	  [EntityInfo(PropertyKeyName="GuidCasefile",PropertyDefaultText="Bytes", CompanyPropertyName = "GuidCompany",CreatedByPropertyName="CreatedBy",UpdatedByPropertyName="UpdatedBy",CreatedDatePropertyName="CreatedDate",UpdatedDatePropertyName="UpdatedDate",DeletedPropertyName="IsDeleted")]
	  [DynamicLinqType]
	  [JsonObject(IsReference = true)]
      [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]

	  public partial class SDCaseFile:  ITrackable, IMyEntity{
			
            public double? _UpdatedDateTS
            {
                get
                {
                    if (this.UpdatedDate != null)
                    {
                        return (this.UpdatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			
            public double? _CreatedDateTS
            {
                get
                {
                    if (this.CreatedDate != null)
                    {
                        return (this.CreatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			public SFSdotNet.Framework.Common.GlobalObjects.UserInfo CreatedByUser { get; set; }

			public override string ToString()
            {
	
				if (this.Bytes != null )		
            		return this.Bytes.ToString();
				else
					return String.Empty;
			}

		//public SDCaseFile()
        //  {

        //  }

	  #region Composite Key
	   public string Key { 
                  get {
                      StringBuilder sb = new StringBuilder();
					sb.Append(this.GuidCasefile.ToString());
                      return sb.ToString();
                } 
		}
        [Serializable()]
        [DataContract]
        public class CompositeKey {

			
            public CompositeKey(Guid guidCasefile)
            {
				_GuidCasefile = guidCasefile;

            }
			private Guid _GuidCasefile;
			[DataMember]
			public Guid GuidCasefile
			{
				get{
					return _GuidCasefile;
				}
				set{
                     
					_GuidCasefile = value;
				}
	        }

            
        }
        #endregion

		public SDCaseFile(){
		#region 
			this.ModifiedProperties = new List<string>();
		#endregion
		}
		#region

	private SDCase __SDCase;
	[DataMember]
	public SDCase SDCase {
		get{
			return __SDCase;
		}
		set{
			__SDCase = value;
				if (value != null)
                {
                   this.__GuidCase = value.GuidCase;
                }else
                {
					                    this.__GuidCase = null;
					                }
		}
	}
	

	private SDFile __SDFile;
	[DataMember]
	public SDFile SDFile {
		get{
			return __SDFile;
		}
		set{
			__SDFile = value;
				if (value != null)
                {
                   this.__GuidFile = value.GuidFile;
                }else
                {
					                    this.__GuidFile = null;
					                }
		}
	}
	


	#endregion

	#region
	private Guid __GuidCasefile;
	[DataMember]
	public Guid GuidCasefile  { 
		get{
			return __GuidCasefile;
		}
		set{

			__GuidCasefile = value;
			
		}
	 }
	private Guid? __GuidCase;
	[DataMember]
	public Guid? GuidCase  { 
		get{
			return __GuidCase;
		}
		set{

			__GuidCase = value;
				if (value == null)
                {
                    this.__SDCase = null;
                }else
                {
											if (this.__SDCase != null && this.__SDCase.GuidCase != value.Value)
						{
							this.__SDCase = new SDCase() { GuidCase = value.Value };

						}
                    //this.__SDCase = new SDCase() { GuidCase = value.Value };
					  // if (this.__SDCase == null )
                      //      this.__SDCase = new SDCase() {  GuidCase = value.Value };
                      //  else {
                       //     if (this.__SDCase.GuidCase != value)
                       //     {
                       //     this.__SDCase = new SDCase() {  GuidCase = value.Value };
					//		}
                     //   }
					                }
			
		}
	 }
	private Guid? __GuidFile;
	[DataMember]
	public Guid? GuidFile  { 
		get{
			return __GuidFile;
		}
		set{

			__GuidFile = value;
				if (value == null)
                {
                    this.__SDFile = null;
                }else
                {
											if (this.__SDFile != null && this.__SDFile.GuidFile != value.Value)
						{
							this.__SDFile = new SDFile() { GuidFile = value.Value };

						}
                    //this.__SDFile = new SDFile() { GuidFile = value.Value };
					  // if (this.__SDFile == null )
                      //      this.__SDFile = new SDFile() {  GuidFile = value.Value };
                      //  else {
                       //     if (this.__SDFile.GuidFile != value)
                       //     {
                       //     this.__SDFile = new SDFile() {  GuidFile = value.Value };
					//		}
                     //   }
					                }
			
		}
	 }
	private Guid? __GuidCompany;
	[DataMember]
	public Guid? GuidCompany  { 
		get{
			return __GuidCompany;
		}
		set{

			__GuidCompany = value;
			
		}
	 }
	private DateTime? __CreatedDate;
	[DataMember]
	public DateTime? CreatedDate  { 
		get{
			return __CreatedDate;
		}
		set{

			__CreatedDate = value;
			
		}
	 }
	private DateTime? __UpdatedDate;
	[DataMember]
	public DateTime? UpdatedDate  { 
		get{
			return __UpdatedDate;
		}
		set{

			__UpdatedDate = value;
			
		}
	 }
	private Guid? __CreatedBy;
	[DataMember]
	public Guid? CreatedBy  { 
		get{
			return __CreatedBy;
		}
		set{

			__CreatedBy = value;
			
		}
	 }
	private Guid? __UpdatedBy;
	[DataMember]
	public Guid? UpdatedBy  { 
		get{
			return __UpdatedBy;
		}
		set{

			__UpdatedBy = value;
			
		}
	 }
	private Int32? __Bytes;
	[DataMember]
	public Int32? Bytes  { 
		get{
			return __Bytes;
		}
		set{

			__Bytes = value;
			
		}
	 }
	private Boolean? __IsDeleted;
	[DataMember]
	public Boolean? IsDeleted  { 
		get{
			return __IsDeleted;
		}
		set{

			__IsDeleted = value;
			
		}
	 }
    #endregion    
			
	public String UrlFile { get; set; }
			
	public String UrlThumbFile { get; set; }
			[DataMember]
          	 public Boolean? ExistFile { get; set; } //test

			[DataMember]
          	 public String FileName { get; set; } //test

			[DataMember]
          	 public String FileStorage { get; set; } //test

			[DataMember]
          	 public String FileThumbSizes { get; set; } //test

	
	[DataMember]
    public TrackingState TrackingState { get; set; }
    [DataMember]
    public ICollection<string> ModifiedProperties { get; set; }
    [JsonProperty, DataMember]
    private Guid EntityIdentifier { get; set; }

		 public string files_SDFile { get; set; }

      


	      #region propertyNames
		public static readonly string EntityName = "SDCaseFile";
		public static readonly string EntitySetName = "SDCaseFiles";
        public struct PropertyNames {
            public static readonly string GuidCasefile = "GuidCasefile";
            public static readonly string GuidCase = "GuidCase";
            public static readonly string GuidFile = "GuidFile";
            public static readonly string GuidCompany = "GuidCompany";
            public static readonly string CreatedDate = "CreatedDate";
            public static readonly string UpdatedDate = "UpdatedDate";
            public static readonly string CreatedBy = "CreatedBy";
            public static readonly string UpdatedBy = "UpdatedBy";
            public static readonly string Bytes = "Bytes";
            public static readonly string IsDeleted = "IsDeleted";
            public static readonly string SDCase = "SDCase";
            public static readonly string SDFile = "SDFile";
            public static readonly string UrlFile = "UrlFile";
            public static readonly string UrlThumbFile = "UrlThumbFile";
            public static readonly string ExistFile = "ExistFile";
            public static readonly string FileName = "FileName";
            public static readonly string FileStorage = "FileStorage";
            public static readonly string FileThumbSizes = "FileThumbSizes";
		}
		#endregion
	}
		  [Serializable()]
	  [EntityInfo(PropertyKeyName="GuidCaseHistory",PropertyDefaultText="BodyContent",RequiredProperties="GuidCase,BodyContent,SDCase", CompanyPropertyName = "GuidCompany",CreatedByPropertyName="CreatedBy",UpdatedByPropertyName="UpdatedBy",CreatedDatePropertyName="CreatedDate",UpdatedDatePropertyName="UpdatedDate",DeletedPropertyName="IsDeleted")]
	  [DynamicLinqType]
	  [JsonObject(IsReference = true)]
      [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]

	  public partial class SDCaseHistory:  ITrackable, IMyEntity{
			
            public double? _UpdatedDateTS
            {
                get
                {
                    if (this.UpdatedDate != null)
                    {
                        return (this.UpdatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			
            public double? _CreatedDateTS
            {
                get
                {
                    if (this.CreatedDate != null)
                    {
                        return (this.CreatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			public SFSdotNet.Framework.Common.GlobalObjects.UserInfo CreatedByUser { get; set; }

			public override string ToString()
            {
	
				if (this.BodyContent != null )		
            		return this.BodyContent.ToString();
				else
					return String.Empty;
			}

		//public SDCaseHistory()
        //  {

        //  }

	  #region Composite Key
	   public string Key { 
                  get {
                      StringBuilder sb = new StringBuilder();
					sb.Append(this.GuidCaseHistory.ToString());
                      return sb.ToString();
                } 
		}
        [Serializable()]
        [DataContract]
        public class CompositeKey {

			
            public CompositeKey(Guid guidCaseHistory)
            {
				_GuidCaseHistory = guidCaseHistory;

            }
			private Guid _GuidCaseHistory;
			[DataMember]
			public Guid GuidCaseHistory
			{
				get{
					return _GuidCaseHistory;
				}
				set{
                     
					_GuidCaseHistory = value;
				}
	        }

            
        }
        #endregion

		public SDCaseHistory(){
		#region 
			this.ModifiedProperties = new List<string>();
	this.SDCaseHistoryFiles = new List<SDCaseHistoryFile>();


		#endregion
		}
		#region
	
	[DataMember]
	public ICollection<SDCaseHistoryFile> SDCaseHistoryFiles { get; set; }
	


	private SDCase __SDCase;
	[DataMember]
	public SDCase SDCase {
		get{
			return __SDCase;
		}
		set{
			__SDCase = value;
				if (value != null)
                {
                   this.__GuidCase = value.GuidCase;
                }else
                {
											 this.__GuidCase = Guid.Empty;
					                }
		}
	}
	

	private SDCaseState __SDCaseState;
	[DataMember]
	public SDCaseState SDCaseState {
		get{
			return __SDCaseState;
		}
		set{
			__SDCaseState = value;
				if (value != null)
                {
                   this.__GuidCaseStatus = value.GuidCaseState;
                }else
                {
					                    this.__GuidCaseStatus = null;
					                }
		}
	}
	


	#endregion

	#region
	private Guid __GuidCaseHistory;
	[DataMember]
	public Guid GuidCaseHistory  { 
		get{
			return __GuidCaseHistory;
		}
		set{

			__GuidCaseHistory = value;
			
		}
	 }
	private Guid __GuidCase;
	[DataMember]
	public Guid GuidCase  { 
		get{
			return __GuidCase;
		}
		set{

			__GuidCase = value;
				if (value == null)
                {
                    this.__SDCase = null;
                }else
                {
					                      //this.__SDCase = new SDCase() { GuidCase = value };
					     if (this.__SDCase != null && this.__SDCase.GuidCase != value)
						{
							this.__SDCase = new SDCase() { GuidCase = value };

						}
						// if (this.__SDCase == null )
                        //    this.__SDCase = new SDCase() {  GuidCase = value };
                        //else {
                        //    if (this.__SDCase.GuidCase != value)
                        //    {
                        //    this.__SDCase = new SDCase() {  GuidCase = value };
						//	}
                        //}
					                }
			
		}
	 }
	private Guid? __GuidCaseStatus;
	[DataMember]
	public Guid? GuidCaseStatus  { 
		get{
			return __GuidCaseStatus;
		}
		set{

			__GuidCaseStatus = value;
				if (value == null)
                {
                    this.__SDCaseState = null;
                }else
                {
											if (this.__SDCaseState != null && this.__SDCaseState.GuidCaseState != value.Value)
						{
							this.__SDCaseState = new SDCaseState() { GuidCaseState = value.Value };

						}
                    //this.__SDCaseState = new SDCaseState() { GuidCaseState = value.Value };
					  // if (this.__SDCaseState == null )
                      //      this.__SDCaseState = new SDCaseState() {  GuidCaseState = value.Value };
                      //  else {
                       //     if (this.__SDCaseState.GuidCaseState != value)
                       //     {
                       //     this.__SDCaseState = new SDCaseState() {  GuidCaseState = value.Value };
					//		}
                     //   }
					                }
			
		}
	 }
	private String __BodyContent;
	[DataMember]
	public String BodyContent  { 
		get{
			return __BodyContent;
		}
		set{

			__BodyContent = value;
			
		}
	 }
	private String __PreviewContent;
	[DataMember]
	public String PreviewContent  { 
		get{
			return __PreviewContent;
		}
		set{

			__PreviewContent = value;
			
		}
	 }
	private Guid? __GuidCompany;
	[DataMember]
	public Guid? GuidCompany  { 
		get{
			return __GuidCompany;
		}
		set{

			__GuidCompany = value;
			
		}
	 }
	private DateTime? __CreatedDate;
	[DataMember]
	public DateTime? CreatedDate  { 
		get{
			return __CreatedDate;
		}
		set{

			__CreatedDate = value;
			
		}
	 }
	private DateTime? __UpdatedDate;
	[DataMember]
	public DateTime? UpdatedDate  { 
		get{
			return __UpdatedDate;
		}
		set{

			__UpdatedDate = value;
			
		}
	 }
	private Guid? __CreatedBy;
	[DataMember]
	public Guid? CreatedBy  { 
		get{
			return __CreatedBy;
		}
		set{

			__CreatedBy = value;
			
		}
	 }
	private Guid? __UpdatedBy;
	[DataMember]
	public Guid? UpdatedBy  { 
		get{
			return __UpdatedBy;
		}
		set{

			__UpdatedBy = value;
			
		}
	 }
	private Int32? __Bytes;
	[DataMember]
	public Int32? Bytes  { 
		get{
			return __Bytes;
		}
		set{

			__Bytes = value;
			
		}
	 }
	private Boolean? __IsDeleted;
	[DataMember]
	public Boolean? IsDeleted  { 
		get{
			return __IsDeleted;
		}
		set{

			__IsDeleted = value;
			
		}
	 }
    #endregion    
	
	[DataMember]
    public TrackingState TrackingState { get; set; }
    [DataMember]
    public ICollection<string> ModifiedProperties { get; set; }
    [JsonProperty, DataMember]
    private Guid EntityIdentifier { get; set; }

      


	      #region propertyNames
		public static readonly string EntityName = "SDCaseHistory";
		public static readonly string EntitySetName = "SDCaseHistories";
        public struct PropertyNames {
            public static readonly string GuidCaseHistory = "GuidCaseHistory";
            public static readonly string GuidCase = "GuidCase";
            public static readonly string GuidCaseStatus = "GuidCaseStatus";
            public static readonly string BodyContent = "BodyContent";
            public static readonly string PreviewContent = "PreviewContent";
            public static readonly string GuidCompany = "GuidCompany";
            public static readonly string CreatedDate = "CreatedDate";
            public static readonly string UpdatedDate = "UpdatedDate";
            public static readonly string CreatedBy = "CreatedBy";
            public static readonly string UpdatedBy = "UpdatedBy";
            public static readonly string Bytes = "Bytes";
            public static readonly string IsDeleted = "IsDeleted";
            public static readonly string SDCase = "SDCase";
            public static readonly string SDCaseState = "SDCaseState";
            public static readonly string SDCaseHistoryFiles = "SDCaseHistoryFiles";
		}
		#endregion
	}
		  [Serializable()]
	  [EntityInfo(PropertyKeyName="GuidCasehistoryFile",PropertyDefaultText="Bytes", CompanyPropertyName = "GuidCompany",CreatedByPropertyName="CreatedBy",UpdatedByPropertyName="UpdatedBy",CreatedDatePropertyName="CreatedDate",UpdatedDatePropertyName="UpdatedDate",DeletedPropertyName="IsDeleted")]
	  [DynamicLinqType]
	  [JsonObject(IsReference = true)]
      [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]

	  public partial class SDCaseHistoryFile:  ITrackable, IMyEntity{
			
            public double? _UpdatedDateTS
            {
                get
                {
                    if (this.UpdatedDate != null)
                    {
                        return (this.UpdatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			
            public double? _CreatedDateTS
            {
                get
                {
                    if (this.CreatedDate != null)
                    {
                        return (this.CreatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			public SFSdotNet.Framework.Common.GlobalObjects.UserInfo CreatedByUser { get; set; }

			public override string ToString()
            {
	
				if (this.Bytes != null )		
            		return this.Bytes.ToString();
				else
					return String.Empty;
			}

		//public SDCaseHistoryFile()
        //  {

        //  }

	  #region Composite Key
	   public string Key { 
                  get {
                      StringBuilder sb = new StringBuilder();
					sb.Append(this.GuidCasehistoryFile.ToString());
                      return sb.ToString();
                } 
		}
        [Serializable()]
        [DataContract]
        public class CompositeKey {

			
            public CompositeKey(Guid guidCasehistoryFile)
            {
				_GuidCasehistoryFile = guidCasehistoryFile;

            }
			private Guid _GuidCasehistoryFile;
			[DataMember]
			public Guid GuidCasehistoryFile
			{
				get{
					return _GuidCasehistoryFile;
				}
				set{
                     
					_GuidCasehistoryFile = value;
				}
	        }

            
        }
        #endregion

		public SDCaseHistoryFile(){
		#region 
			this.ModifiedProperties = new List<string>();
		#endregion
		}
		#region

	private SDCaseHistory __SDCaseHistory;
	[DataMember]
	public SDCaseHistory SDCaseHistory {
		get{
			return __SDCaseHistory;
		}
		set{
			__SDCaseHistory = value;
				if (value != null)
                {
                   this.__GuidCaseHistory = value.GuidCaseHistory;
                }else
                {
					                    this.__GuidCaseHistory = null;
					                }
		}
	}
	

	private SDFile __SDFile;
	[DataMember]
	public SDFile SDFile {
		get{
			return __SDFile;
		}
		set{
			__SDFile = value;
				if (value != null)
                {
                   this.__GuidFile = value.GuidFile;
                }else
                {
					                    this.__GuidFile = null;
					                }
		}
	}
	


	#endregion

	#region
	private Guid __GuidCasehistoryFile;
	[DataMember]
	public Guid GuidCasehistoryFile  { 
		get{
			return __GuidCasehistoryFile;
		}
		set{

			__GuidCasehistoryFile = value;
			
		}
	 }
	private Guid? __GuidFile;
	[DataMember]
	public Guid? GuidFile  { 
		get{
			return __GuidFile;
		}
		set{

			__GuidFile = value;
				if (value == null)
                {
                    this.__SDFile = null;
                }else
                {
											if (this.__SDFile != null && this.__SDFile.GuidFile != value.Value)
						{
							this.__SDFile = new SDFile() { GuidFile = value.Value };

						}
                    //this.__SDFile = new SDFile() { GuidFile = value.Value };
					  // if (this.__SDFile == null )
                      //      this.__SDFile = new SDFile() {  GuidFile = value.Value };
                      //  else {
                       //     if (this.__SDFile.GuidFile != value)
                       //     {
                       //     this.__SDFile = new SDFile() {  GuidFile = value.Value };
					//		}
                     //   }
					                }
			
		}
	 }
	private Guid? __GuidCaseHistory;
	[DataMember]
	public Guid? GuidCaseHistory  { 
		get{
			return __GuidCaseHistory;
		}
		set{

			__GuidCaseHistory = value;
				if (value == null)
                {
                    this.__SDCaseHistory = null;
                }else
                {
											if (this.__SDCaseHistory != null && this.__SDCaseHistory.GuidCaseHistory != value.Value)
						{
							this.__SDCaseHistory = new SDCaseHistory() { GuidCaseHistory = value.Value };

						}
                    //this.__SDCaseHistory = new SDCaseHistory() { GuidCaseHistory = value.Value };
					  // if (this.__SDCaseHistory == null )
                      //      this.__SDCaseHistory = new SDCaseHistory() {  GuidCaseHistory = value.Value };
                      //  else {
                       //     if (this.__SDCaseHistory.GuidCaseHistory != value)
                       //     {
                       //     this.__SDCaseHistory = new SDCaseHistory() {  GuidCaseHistory = value.Value };
					//		}
                     //   }
					                }
			
		}
	 }
	private Guid? __GuidCompany;
	[DataMember]
	public Guid? GuidCompany  { 
		get{
			return __GuidCompany;
		}
		set{

			__GuidCompany = value;
			
		}
	 }
	private DateTime? __CreatedDate;
	[DataMember]
	public DateTime? CreatedDate  { 
		get{
			return __CreatedDate;
		}
		set{

			__CreatedDate = value;
			
		}
	 }
	private DateTime? __UpdatedDate;
	[DataMember]
	public DateTime? UpdatedDate  { 
		get{
			return __UpdatedDate;
		}
		set{

			__UpdatedDate = value;
			
		}
	 }
	private Guid? __CreatedBy;
	[DataMember]
	public Guid? CreatedBy  { 
		get{
			return __CreatedBy;
		}
		set{

			__CreatedBy = value;
			
		}
	 }
	private Guid? __UpdatedBy;
	[DataMember]
	public Guid? UpdatedBy  { 
		get{
			return __UpdatedBy;
		}
		set{

			__UpdatedBy = value;
			
		}
	 }
	private Int32? __Bytes;
	[DataMember]
	public Int32? Bytes  { 
		get{
			return __Bytes;
		}
		set{

			__Bytes = value;
			
		}
	 }
	private Boolean? __IsDeleted;
	[DataMember]
	public Boolean? IsDeleted  { 
		get{
			return __IsDeleted;
		}
		set{

			__IsDeleted = value;
			
		}
	 }
    #endregion    
	
	[DataMember]
    public TrackingState TrackingState { get; set; }
    [DataMember]
    public ICollection<string> ModifiedProperties { get; set; }
    [JsonProperty, DataMember]
    private Guid EntityIdentifier { get; set; }

      


	      #region propertyNames
		public static readonly string EntityName = "SDCaseHistoryFile";
		public static readonly string EntitySetName = "SDCaseHistoryFiles";
        public struct PropertyNames {
            public static readonly string GuidCasehistoryFile = "GuidCasehistoryFile";
            public static readonly string GuidFile = "GuidFile";
            public static readonly string GuidCaseHistory = "GuidCaseHistory";
            public static readonly string GuidCompany = "GuidCompany";
            public static readonly string CreatedDate = "CreatedDate";
            public static readonly string UpdatedDate = "UpdatedDate";
            public static readonly string CreatedBy = "CreatedBy";
            public static readonly string UpdatedBy = "UpdatedBy";
            public static readonly string Bytes = "Bytes";
            public static readonly string IsDeleted = "IsDeleted";
            public static readonly string SDCaseHistory = "SDCaseHistory";
            public static readonly string SDFile = "SDFile";
		}
		#endregion
	}
		  [Serializable()]
	  [EntityInfo(PropertyKeyName="GuidCasePriority",PropertyDefaultText="Title",RequiredProperties="Title", CompanyPropertyName = "GuidCompany",CreatedByPropertyName="CreatedBy",UpdatedByPropertyName="UpdatedBy",CreatedDatePropertyName="CreatedDate",UpdatedDatePropertyName="UpdatedDate",DeletedPropertyName="IsDeleted")]
	  [DynamicLinqType]
	  [JsonObject(IsReference = true)]
      [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]

	  public partial class SDCasePriority:  ITrackable, IMyEntity{
			
            public double? _UpdatedDateTS
            {
                get
                {
                    if (this.UpdatedDate != null)
                    {
                        return (this.UpdatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			
            public double? _CreatedDateTS
            {
                get
                {
                    if (this.CreatedDate != null)
                    {
                        return (this.CreatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			public SFSdotNet.Framework.Common.GlobalObjects.UserInfo CreatedByUser { get; set; }

			public override string ToString()
            {
	
				if (this.Title != null )		
            		return this.Title.ToString();
				else
					return String.Empty;
			}

		//public SDCasePriority()
        //  {

        //  }

	  #region Composite Key
	   public string Key { 
                  get {
                      StringBuilder sb = new StringBuilder();
					sb.Append(this.GuidCasePriority.ToString());
                      return sb.ToString();
                } 
		}
        [Serializable()]
        [DataContract]
        public class CompositeKey {

			
            public CompositeKey(Guid guidCasePriority)
            {
				_GuidCasePriority = guidCasePriority;

            }
			private Guid _GuidCasePriority;
			[DataMember]
			public Guid GuidCasePriority
			{
				get{
					return _GuidCasePriority;
				}
				set{
                     
					_GuidCasePriority = value;
				}
	        }

            
        }
        #endregion

		public SDCasePriority(){
		#region 
			this.ModifiedProperties = new List<string>();
	this.SDCases = new List<SDCase>();


		#endregion
		}
		#region
	
	[DataMember]
	public ICollection<SDCase> SDCases { get; set; }
	



	#endregion

	#region
	private Guid __GuidCasePriority;
	[DataMember]
	public Guid GuidCasePriority  { 
		get{
			return __GuidCasePriority;
		}
		set{

			__GuidCasePriority = value;
			
		}
	 }
	private String __Title;
	[DataMember]
	public String Title  { 
		get{
			return __Title;
		}
		set{

			__Title = value;
			
		}
	 }
	private Guid? __GuidCompany;
	[DataMember]
	public Guid? GuidCompany  { 
		get{
			return __GuidCompany;
		}
		set{

			__GuidCompany = value;
			
		}
	 }
	private DateTime? __CreatedDate;
	[DataMember]
	public DateTime? CreatedDate  { 
		get{
			return __CreatedDate;
		}
		set{

			__CreatedDate = value;
			
		}
	 }
	private DateTime? __UpdatedDate;
	[DataMember]
	public DateTime? UpdatedDate  { 
		get{
			return __UpdatedDate;
		}
		set{

			__UpdatedDate = value;
			
		}
	 }
	private Guid? __CreatedBy;
	[DataMember]
	public Guid? CreatedBy  { 
		get{
			return __CreatedBy;
		}
		set{

			__CreatedBy = value;
			
		}
	 }
	private Guid? __UpdatedBy;
	[DataMember]
	public Guid? UpdatedBy  { 
		get{
			return __UpdatedBy;
		}
		set{

			__UpdatedBy = value;
			
		}
	 }
	private Int32? __Bytes;
	[DataMember]
	public Int32? Bytes  { 
		get{
			return __Bytes;
		}
		set{

			__Bytes = value;
			
		}
	 }
	private Boolean? __IsDeleted;
	[DataMember]
	public Boolean? IsDeleted  { 
		get{
			return __IsDeleted;
		}
		set{

			__IsDeleted = value;
			
		}
	 }
    #endregion    
	
	[DataMember]
    public TrackingState TrackingState { get; set; }
    [DataMember]
    public ICollection<string> ModifiedProperties { get; set; }
    [JsonProperty, DataMember]
    private Guid EntityIdentifier { get; set; }

      


	      #region propertyNames
		public static readonly string EntityName = "SDCasePriority";
		public static readonly string EntitySetName = "SDCasePriorities";
        public struct PropertyNames {
            public static readonly string GuidCasePriority = "GuidCasePriority";
            public static readonly string Title = "Title";
            public static readonly string GuidCompany = "GuidCompany";
            public static readonly string CreatedDate = "CreatedDate";
            public static readonly string UpdatedDate = "UpdatedDate";
            public static readonly string CreatedBy = "CreatedBy";
            public static readonly string UpdatedBy = "UpdatedBy";
            public static readonly string Bytes = "Bytes";
            public static readonly string IsDeleted = "IsDeleted";
            public static readonly string SDCases = "SDCases";
		}
		#endregion
	}
		  [Serializable()]
	  [EntityInfo(PropertyKeyName="GuidCaseState",PropertyDefaultText="Title",RequiredProperties="Title", CompanyPropertyName = "GuidCompany",CreatedByPropertyName="CreatedBy",UpdatedByPropertyName="UpdatedBy",CreatedDatePropertyName="CreatedDate",UpdatedDatePropertyName="UpdatedDate",DeletedPropertyName="IsDeleted")]
	  [DynamicLinqType]
	  [JsonObject(IsReference = true)]
      [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]

	  public partial class SDCaseState:  ITrackable, IMyEntity{
			
            public double? _UpdatedDateTS
            {
                get
                {
                    if (this.UpdatedDate != null)
                    {
                        return (this.UpdatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			
            public double? _CreatedDateTS
            {
                get
                {
                    if (this.CreatedDate != null)
                    {
                        return (this.CreatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			public SFSdotNet.Framework.Common.GlobalObjects.UserInfo CreatedByUser { get; set; }

			public override string ToString()
            {
	
				if (this.Title != null )		
            		return this.Title.ToString();
				else
					return String.Empty;
			}

		//public SDCaseState()
        //  {

        //  }

	  #region Composite Key
	   public string Key { 
                  get {
                      StringBuilder sb = new StringBuilder();
					sb.Append(this.GuidCaseState.ToString());
                      return sb.ToString();
                } 
		}
        [Serializable()]
        [DataContract]
        public class CompositeKey {

			
            public CompositeKey(Guid guidCaseState)
            {
				_GuidCaseState = guidCaseState;

            }
			private Guid _GuidCaseState;
			[DataMember]
			public Guid GuidCaseState
			{
				get{
					return _GuidCaseState;
				}
				set{
                     
					_GuidCaseState = value;
				}
	        }

            
        }
        #endregion

		public SDCaseState(){
		#region 
			this.ModifiedProperties = new List<string>();
	this.SDCases = new List<SDCase>();


	this.SDCaseHistories = new List<SDCaseHistory>();


		#endregion
		}
		#region
	
	[DataMember]
	public ICollection<SDCase> SDCases { get; set; }
	

	
	[DataMember]
	public ICollection<SDCaseHistory> SDCaseHistories { get; set; }
	



	#endregion

	#region
	private Guid __GuidCaseState;
	[DataMember]
	public Guid GuidCaseState  { 
		get{
			return __GuidCaseState;
		}
		set{

			__GuidCaseState = value;
			
		}
	 }
	private String __Title;
	[DataMember]
	public String Title  { 
		get{
			return __Title;
		}
		set{

			__Title = value;
			
		}
	 }
	private Guid? __GuidCompany;
	[DataMember]
	public Guid? GuidCompany  { 
		get{
			return __GuidCompany;
		}
		set{

			__GuidCompany = value;
			
		}
	 }
	private DateTime? __CreatedDate;
	[DataMember]
	public DateTime? CreatedDate  { 
		get{
			return __CreatedDate;
		}
		set{

			__CreatedDate = value;
			
		}
	 }
	private DateTime? __UpdatedDate;
	[DataMember]
	public DateTime? UpdatedDate  { 
		get{
			return __UpdatedDate;
		}
		set{

			__UpdatedDate = value;
			
		}
	 }
	private Guid? __CreatedBy;
	[DataMember]
	public Guid? CreatedBy  { 
		get{
			return __CreatedBy;
		}
		set{

			__CreatedBy = value;
			
		}
	 }
	private Guid? __UpdatedBy;
	[DataMember]
	public Guid? UpdatedBy  { 
		get{
			return __UpdatedBy;
		}
		set{

			__UpdatedBy = value;
			
		}
	 }
	private Int32? __Bytes;
	[DataMember]
	public Int32? Bytes  { 
		get{
			return __Bytes;
		}
		set{

			__Bytes = value;
			
		}
	 }
	private Boolean? __IsDeleted;
	[DataMember]
	public Boolean? IsDeleted  { 
		get{
			return __IsDeleted;
		}
		set{

			__IsDeleted = value;
			
		}
	 }
    #endregion    
	
	[DataMember]
    public TrackingState TrackingState { get; set; }
    [DataMember]
    public ICollection<string> ModifiedProperties { get; set; }
    [JsonProperty, DataMember]
    private Guid EntityIdentifier { get; set; }

      


	      #region propertyNames
		public static readonly string EntityName = "SDCaseState";
		public static readonly string EntitySetName = "SDCaseStates";
        public struct PropertyNames {
            public static readonly string GuidCaseState = "GuidCaseState";
            public static readonly string Title = "Title";
            public static readonly string GuidCompany = "GuidCompany";
            public static readonly string CreatedDate = "CreatedDate";
            public static readonly string UpdatedDate = "UpdatedDate";
            public static readonly string CreatedBy = "CreatedBy";
            public static readonly string UpdatedBy = "UpdatedBy";
            public static readonly string Bytes = "Bytes";
            public static readonly string IsDeleted = "IsDeleted";
            public static readonly string SDCases = "SDCases";
            public static readonly string SDCaseHistories = "SDCaseHistories";
		}
		#endregion
	}
		  [Serializable()]
	  [EntityInfo(PropertyKeyName="GuidFile",PropertyDefaultText="FileName",RequiredProperties="FileName", CompanyPropertyName = "GuidCompany",CreatedByPropertyName="CreatedBy",UpdatedByPropertyName="UpdatedBy",CreatedDatePropertyName="CreatedDate",UpdatedDatePropertyName="UpdatedDate",DeletedPropertyName="IsDeleted", IsFile=true, ExtraSizeField= "FileSize")]
	  [DynamicLinqType]
	  [JsonObject(IsReference = true)]
      [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]

	  public partial class SDFile:  ITrackable, IMyEntity{
			
            public double? _UpdatedDateTS
            {
                get
                {
                    if (this.UpdatedDate != null)
                    {
                        return (this.UpdatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			
            public double? _CreatedDateTS
            {
                get
                {
                    if (this.CreatedDate != null)
                    {
                        return (this.CreatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			public SFSdotNet.Framework.Common.GlobalObjects.UserInfo CreatedByUser { get; set; }

			public override string ToString()
            {
	
				if (this.FileName != null )		
            		return this.FileName.ToString();
				else
					return String.Empty;
			}

		//public SDFile()
        //  {

        //  }

	  #region Composite Key
	   public string Key { 
                  get {
                      StringBuilder sb = new StringBuilder();
					sb.Append(this.GuidFile.ToString());
                      return sb.ToString();
                } 
		}
        [Serializable()]
        [DataContract]
        public class CompositeKey {

			
            public CompositeKey(Guid guidFile)
            {
				_GuidFile = guidFile;

            }
			private Guid _GuidFile;
			[DataMember]
			public Guid GuidFile
			{
				get{
					return _GuidFile;
				}
				set{
                     
					_GuidFile = value;
				}
	        }

            
        }
        #endregion

		public SDFile(){
		#region 
			this.ModifiedProperties = new List<string>();
	this.SDCaseFiles = new List<SDCaseFile>();


	this.SDCaseHistoryFiles = new List<SDCaseHistoryFile>();


		#endregion
		}
		#region
	
	[DataMember]
	public ICollection<SDCaseFile> SDCaseFiles { get; set; }
	

	
	[DataMember]
	public ICollection<SDCaseHistoryFile> SDCaseHistoryFiles { get; set; }
	



	#endregion

	#region
	private Guid __GuidFile;
	[DataMember]
	public Guid GuidFile  { 
		get{
			return __GuidFile;
		}
		set{

			__GuidFile = value;
			
		}
	 }
	private String __FileName;
	[DataMember]
	public String FileName  { 
		get{
			return __FileName;
		}
		set{

			__FileName = value;
			
		}
	 }
	private String __FileType;
	[DataMember]
	public String FileType  { 
		get{
			return __FileType;
		}
		set{

			__FileType = value;
			
		}
	 }
	private Int64? __FileSize;
	[DataMember]
	public Int64? FileSize  { 
		get{
			return __FileSize;
		}
		set{

			__FileSize = value;
			
		}
	 }
	private Byte[] __FileData;
	[DataMember]
	public Byte[] FileData  { 
		get{
			return __FileData;
		}
		set{

			__FileData = value;
			
		}
	 }
	private Guid? __GuidCompany;
	[DataMember]
	public Guid? GuidCompany  { 
		get{
			return __GuidCompany;
		}
		set{

			__GuidCompany = value;
			
		}
	 }
	private DateTime? __CreatedDate;
	[DataMember]
	public DateTime? CreatedDate  { 
		get{
			return __CreatedDate;
		}
		set{

			__CreatedDate = value;
			
		}
	 }
	private DateTime? __UpdatedDate;
	[DataMember]
	public DateTime? UpdatedDate  { 
		get{
			return __UpdatedDate;
		}
		set{

			__UpdatedDate = value;
			
		}
	 }
	private Guid? __CreatedBy;
	[DataMember]
	public Guid? CreatedBy  { 
		get{
			return __CreatedBy;
		}
		set{

			__CreatedBy = value;
			
		}
	 }
	private Guid? __UpdatedBy;
	[DataMember]
	public Guid? UpdatedBy  { 
		get{
			return __UpdatedBy;
		}
		set{

			__UpdatedBy = value;
			
		}
	 }
	private Int32? __Bytes;
	[DataMember]
	public Int32? Bytes  { 
		get{
			return __Bytes;
		}
		set{

			__Bytes = value;
			
		}
	 }
	private Boolean? __IsDeleted;
	[DataMember]
	public Boolean? IsDeleted  { 
		get{
			return __IsDeleted;
		}
		set{

			__IsDeleted = value;
			
		}
	 }
	private String __FileStorage;
	[DataMember]
	public String FileStorage  { 
		get{
			return __FileStorage;
		}
		set{

			__FileStorage = value;
			
		}
	 }
	private String __FileThumbSizes;
	[DataMember]
	public String FileThumbSizes  { 
		get{
			return __FileThumbSizes;
		}
		set{

			__FileThumbSizes = value;
			
		}
	 }
    #endregion    
	
	[DataMember]
    public TrackingState TrackingState { get; set; }
    [DataMember]
    public ICollection<string> ModifiedProperties { get; set; }
    [JsonProperty, DataMember]
    private Guid EntityIdentifier { get; set; }

      


	      #region propertyNames
		public static readonly string EntityName = "SDFile";
		public static readonly string EntitySetName = "SDFiles";
        public struct PropertyNames {
            public static readonly string GuidFile = "GuidFile";
            public static readonly string FileName = "FileName";
            public static readonly string FileType = "FileType";
            public static readonly string FileSize = "FileSize";
            public static readonly string FileData = "FileData";
            public static readonly string GuidCompany = "GuidCompany";
            public static readonly string CreatedDate = "CreatedDate";
            public static readonly string UpdatedDate = "UpdatedDate";
            public static readonly string CreatedBy = "CreatedBy";
            public static readonly string UpdatedBy = "UpdatedBy";
            public static readonly string Bytes = "Bytes";
            public static readonly string IsDeleted = "IsDeleted";
            public static readonly string FileStorage = "FileStorage";
            public static readonly string FileThumbSizes = "FileThumbSizes";
            public static readonly string SDCaseFiles = "SDCaseFiles";
            public static readonly string SDCaseHistoryFiles = "SDCaseHistoryFiles";
		}
		#endregion
	}
		  [Serializable()]
	  [EntityInfo(PropertyKeyName="GuidOrganization",PropertyDefaultText="FullName",RequiredProperties="FullName", CompanyPropertyName = "GuidCompany",CreatedByPropertyName="CreatedBy",UpdatedByPropertyName="UpdatedBy",CreatedDatePropertyName="CreatedDate",UpdatedDatePropertyName="UpdatedDate",DeletedPropertyName="IsDeleted")]
	  [DynamicLinqType]
	  [JsonObject(IsReference = true)]
      [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]

	  public partial class SDOrganization:  ITrackable, IMyEntity{
			
            public double? _UpdatedDateTS
            {
                get
                {
                    if (this.UpdatedDate != null)
                    {
                        return (this.UpdatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			
            public double? _CreatedDateTS
            {
                get
                {
                    if (this.CreatedDate != null)
                    {
                        return (this.CreatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			public SFSdotNet.Framework.Common.GlobalObjects.UserInfo CreatedByUser { get; set; }

			public override string ToString()
            {
	
				if (this.FullName != null )		
            		return this.FullName.ToString();
				else
					return String.Empty;
			}

		//public SDOrganization()
        //  {

        //  }

	  #region Composite Key
	   public string Key { 
                  get {
                      StringBuilder sb = new StringBuilder();
					sb.Append(this.GuidOrganization.ToString());
                      return sb.ToString();
                } 
		}
        [Serializable()]
        [DataContract]
        public class CompositeKey {

			
            public CompositeKey(Guid guidOrganization)
            {
				_GuidOrganization = guidOrganization;

            }
			private Guid _GuidOrganization;
			[DataMember]
			public Guid GuidOrganization
			{
				get{
					return _GuidOrganization;
				}
				set{
                     
					_GuidOrganization = value;
				}
	        }

            
        }
        #endregion

		public SDOrganization(){
		#region 
			this.ModifiedProperties = new List<string>();
	this.SDAreas = new List<SDArea>();


	this.SDPersons = new List<SDPerson>();


		#endregion
		}
		#region
	
	[DataMember]
	public ICollection<SDArea> SDAreas { get; set; }
	

	
	[DataMember]
	public ICollection<SDPerson> SDPersons { get; set; }
	



	#endregion

	#region
	private Guid __GuidOrganization;
	[DataMember]
	public Guid GuidOrganization  { 
		get{
			return __GuidOrganization;
		}
		set{

			__GuidOrganization = value;
			
		}
	 }
	private String __FullName;
	[DataMember]
	public String FullName  { 
		get{
			return __FullName;
		}
		set{

			__FullName = value;
			
		}
	 }
	private Guid? __GuidCompany;
	[DataMember]
	public Guid? GuidCompany  { 
		get{
			return __GuidCompany;
		}
		set{

			__GuidCompany = value;
			
		}
	 }
	private DateTime? __CreatedDate;
	[DataMember]
	public DateTime? CreatedDate  { 
		get{
			return __CreatedDate;
		}
		set{

			__CreatedDate = value;
			
		}
	 }
	private DateTime? __UpdatedDate;
	[DataMember]
	public DateTime? UpdatedDate  { 
		get{
			return __UpdatedDate;
		}
		set{

			__UpdatedDate = value;
			
		}
	 }
	private Guid? __CreatedBy;
	[DataMember]
	public Guid? CreatedBy  { 
		get{
			return __CreatedBy;
		}
		set{

			__CreatedBy = value;
			
		}
	 }
	private Guid? __UpdatedBy;
	[DataMember]
	public Guid? UpdatedBy  { 
		get{
			return __UpdatedBy;
		}
		set{

			__UpdatedBy = value;
			
		}
	 }
	private Int32? __Bytes;
	[DataMember]
	public Int32? Bytes  { 
		get{
			return __Bytes;
		}
		set{

			__Bytes = value;
			
		}
	 }
	private Boolean? __IsDeleted;
	[DataMember]
	public Boolean? IsDeleted  { 
		get{
			return __IsDeleted;
		}
		set{

			__IsDeleted = value;
			
		}
	 }
    #endregion    
	
	[DataMember]
    public TrackingState TrackingState { get; set; }
    [DataMember]
    public ICollection<string> ModifiedProperties { get; set; }
    [JsonProperty, DataMember]
    private Guid EntityIdentifier { get; set; }

      


	      #region propertyNames
		public static readonly string EntityName = "SDOrganization";
		public static readonly string EntitySetName = "SDOrganizations";
        public struct PropertyNames {
            public static readonly string GuidOrganization = "GuidOrganization";
            public static readonly string FullName = "FullName";
            public static readonly string GuidCompany = "GuidCompany";
            public static readonly string CreatedDate = "CreatedDate";
            public static readonly string UpdatedDate = "UpdatedDate";
            public static readonly string CreatedBy = "CreatedBy";
            public static readonly string UpdatedBy = "UpdatedBy";
            public static readonly string Bytes = "Bytes";
            public static readonly string IsDeleted = "IsDeleted";
            public static readonly string SDAreas = "SDAreas";
            public static readonly string SDPersons = "SDPersons";
		}
		#endregion
	}
		  [Serializable()]
	  [EntityInfo(PropertyKeyName="GuidPerson",PropertyDefaultText="DisplayName",RequiredProperties="DisplayName", CompanyPropertyName = "GuidCompany",CreatedByPropertyName="CreatedBy",UpdatedByPropertyName="UpdatedBy",CreatedDatePropertyName="CreatedDate",UpdatedDatePropertyName="UpdatedDate",DeletedPropertyName="IsDeleted")]
	  [DynamicLinqType]
	  [JsonObject(IsReference = true)]
      [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]

	  public partial class SDPerson:  ITrackable, IMyEntity{
			
            public double? _UpdatedDateTS
            {
                get
                {
                    if (this.UpdatedDate != null)
                    {
                        return (this.UpdatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			
            public double? _CreatedDateTS
            {
                get
                {
                    if (this.CreatedDate != null)
                    {
                        return (this.CreatedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    }else
                    {
                        return null;
                    }
                }
            }
			public SFSdotNet.Framework.Common.GlobalObjects.UserInfo CreatedByUser { get; set; }

			public override string ToString()
            {
	
				if (this.DisplayName != null )		
            		return this.DisplayName.ToString();
				else
					return String.Empty;
			}

		//public SDPerson()
        //  {

        //  }

	  #region Composite Key
	   public string Key { 
                  get {
                      StringBuilder sb = new StringBuilder();
					sb.Append(this.GuidPerson.ToString());
                      return sb.ToString();
                } 
		}
        [Serializable()]
        [DataContract]
        public class CompositeKey {

			
            public CompositeKey(Guid guidPerson)
            {
				_GuidPerson = guidPerson;

            }
			private Guid _GuidPerson;
			[DataMember]
			public Guid GuidPerson
			{
				get{
					return _GuidPerson;
				}
				set{
                     
					_GuidPerson = value;
				}
	        }

            
        }
        #endregion

		public SDPerson(){
		#region 
			this.ModifiedProperties = new List<string>();
	this.SDAreaPersons = new List<SDAreaPerson>();


	this.SDCases = new List<SDCase>();


		#endregion
		}
		#region
	
	[DataMember]
	public ICollection<SDAreaPerson> SDAreaPersons { get; set; }
	

	
	[DataMember]
	public ICollection<SDCase> SDCases { get; set; }
	


	private SDOrganization __SDOrganization;
	[DataMember]
	public SDOrganization SDOrganization {
		get{
			return __SDOrganization;
		}
		set{
			__SDOrganization = value;
				if (value != null)
                {
                   this.__GuidOrganization = value.GuidOrganization;
                }else
                {
					                    this.__GuidOrganization = null;
					                }
		}
	}
	

	private SDProxyUser __SDProxyUser;
	[DataMember]
	public SDProxyUser SDProxyUser {
		get{
			return __SDProxyUser;
		}
		set{
			__SDProxyUser = value;
				if (value != null)
                {
                   this.__GuidUser = value.GuidUser;
                }else
                {
					                    this.__GuidUser = null;
					                }
		}
	}
	


	#endregion

	#region
	private Guid __GuidPerson;
	[DataMember]
	public Guid GuidPerson  { 
		get{
			return __GuidPerson;
		}
		set{

			__GuidPerson = value;
			
		}
	 }
	private String __DisplayName;
	[DataMember]
	public String DisplayName  { 
		get{
			return __DisplayName;
		}
		set{

			__DisplayName = value;
			
		}
	 }
	private Guid? __GuidUser;
	[DataMember]
	public Guid? GuidUser  { 
		get{
			return __GuidUser;
		}
		set{

			__GuidUser = value;
				if (value == null)
                {
                    this.__SDProxyUser = null;
                }else
                {
											if (this.__SDProxyUser != null && this.__SDProxyUser.GuidUser != value.Value)
						{
							this.__SDProxyUser = new SDProxyUser() { GuidUser = value.Value };

						}
                    //this.__SDProxyUser = new SDProxyUser() { GuidUser = value.Value };
					  // if (this.__SDProxyUser == null )
                      //      this.__SDProxyUser = new SDProxyUser() {  GuidUser = value.Value };
                      //  else {
                       //     if (this.__SDProxyUser.GuidUser != value)
                       //     {
                       //     this.__SDProxyUser = new SDProxyUser() {  GuidUser = value.Value };
					//		}
                     //   }
					                }
			
		}
	 }
	private Guid? __GuidOrganization;
	[DataMember]
	public Guid? GuidOrganization  { 
		get{
			return __GuidOrganization;
		}
		set{

			__GuidOrganization = value;
				if (value == null)
                {
                    this.__SDOrganization = null;
                }else
                {
											if (this.__SDOrganization != null && this.__SDOrganization.GuidOrganization != value.Value)
						{
							this.__SDOrganization = new SDOrganization() { GuidOrganization = value.Value };

						}
                    //this.__SDOrganization = new SDOrganization() { GuidOrganization = value.Value };
					  // if (this.__SDOrganization == null )
                      //      this.__SDOrganization = new SDOrganization() {  GuidOrganization = value.Value };
                      //  else {
                       //     if (this.__SDOrganization.GuidOrganization != value)
                       //     {
                       //     this.__SDOrganization = new SDOrganization() {  GuidOrganization = value.Value };
					//		}
                     //   }
					                }
			
		}
	 }
	private Guid? __GuidCompany;
	[DataMember]
	public Guid? GuidCompany  { 
		get{
			return __GuidCompany;
		}
		set{

			__GuidCompany = value;
			
		}
	 }
	private DateTime? __CreatedDate;
	[DataMember]
	public DateTime? CreatedDate  { 
		get{
			return __CreatedDate;
		}
		set{

			__CreatedDate = value;
			
		}
	 }
	private DateTime? __UpdatedDate;
	[DataMember]
	public DateTime? UpdatedDate  { 
		get{
			return __UpdatedDate;
		}
		set{

			__UpdatedDate = value;
			
		}
	 }
	private Guid? __CreatedBy;
	[DataMember]
	public Guid? CreatedBy  { 
		get{
			return __CreatedBy;
		}
		set{

			__CreatedBy = value;
			
		}
	 }
	private Guid? __UpdatedBy;
	[DataMember]
	public Guid? UpdatedBy  { 
		get{
			return __UpdatedBy;
		}
		set{

			__UpdatedBy = value;
			
		}
	 }
	private Int32? __Bytes;
	[DataMember]
	public Int32? Bytes  { 
		get{
			return __Bytes;
		}
		set{

			__Bytes = value;
			
		}
	 }
	private Boolean? __IsDeleted;
	[DataMember]
	public Boolean? IsDeleted  { 
		get{
			return __IsDeleted;
		}
		set{

			__IsDeleted = value;
			
		}
	 }
    #endregion    
	
	[DataMember]
    public TrackingState TrackingState { get; set; }
    [DataMember]
    public ICollection<string> ModifiedProperties { get; set; }
    [JsonProperty, DataMember]
    private Guid EntityIdentifier { get; set; }

      


	      #region propertyNames
		public static readonly string EntityName = "SDPerson";
		public static readonly string EntitySetName = "SDPersons";
        public struct PropertyNames {
            public static readonly string GuidPerson = "GuidPerson";
            public static readonly string DisplayName = "DisplayName";
            public static readonly string GuidUser = "GuidUser";
            public static readonly string GuidOrganization = "GuidOrganization";
            public static readonly string GuidCompany = "GuidCompany";
            public static readonly string CreatedDate = "CreatedDate";
            public static readonly string UpdatedDate = "UpdatedDate";
            public static readonly string CreatedBy = "CreatedBy";
            public static readonly string UpdatedBy = "UpdatedBy";
            public static readonly string Bytes = "Bytes";
            public static readonly string IsDeleted = "IsDeleted";
            public static readonly string SDAreaPersons = "SDAreaPersons";
            public static readonly string SDCases = "SDCases";
            public static readonly string SDOrganization = "SDOrganization";
            public static readonly string SDProxyUser = "SDProxyUser";
		}
		#endregion
	}
		  [Serializable()]
	  [EntityInfo(PropertyKeyName="GuidUser",PropertyDefaultText="Email",RequiredProperties="Email")]
	  [DynamicLinqType]
	  [JsonObject(IsReference = true)]
      [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]

	  public partial class SDProxyUser:  ITrackable, IMyEntity{
			public SFSdotNet.Framework.Common.GlobalObjects.UserInfo CreatedByUser { get; set; }

			public override string ToString()
            {
	
				if (this.Email != null )		
            		return this.Email.ToString();
				else
					return String.Empty;
			}

		//public SDProxyUser()
        //  {

        //  }

	  #region Composite Key
	   public string Key { 
                  get {
                      StringBuilder sb = new StringBuilder();
					sb.Append(this.GuidUser.ToString());
                      return sb.ToString();
                } 
		}
        [Serializable()]
        [DataContract]
        public class CompositeKey {

			
            public CompositeKey(Guid guidUser)
            {
				_GuidUser = guidUser;

            }
			private Guid _GuidUser;
			[DataMember]
			public Guid GuidUser
			{
				get{
					return _GuidUser;
				}
				set{
                     
					_GuidUser = value;
				}
	        }

            
        }
        #endregion

		public SDProxyUser(){
		#region 
			this.ModifiedProperties = new List<string>();
	this.SDPersons = new List<SDPerson>();


		#endregion
		}
		#region
	
	[DataMember]
	public ICollection<SDPerson> SDPersons { get; set; }
	



	#endregion

	#region
	private Guid __GuidUser;
	[DataMember]
	public Guid GuidUser  { 
		get{
			return __GuidUser;
		}
		set{

			__GuidUser = value;
			
		}
	 }
	private String __Email;
	[DataMember]
	public String Email  { 
		get{
			return __Email;
		}
		set{

			__Email = value;
			
		}
	 }
	private String __DisplayName;
	[DataMember]
	public String DisplayName  { 
		get{
			return __DisplayName;
		}
		set{

			__DisplayName = value;
			
		}
	 }
    #endregion    
	
	[DataMember]
    public TrackingState TrackingState { get; set; }
    [DataMember]
    public ICollection<string> ModifiedProperties { get; set; }
    [JsonProperty, DataMember]
    private Guid EntityIdentifier { get; set; }

      


	      #region propertyNames
		public static readonly string EntityName = "SDProxyUser";
		public static readonly string EntitySetName = "SDProxyUsers";
        public struct PropertyNames {
            public static readonly string GuidUser = "GuidUser";
            public static readonly string Email = "Email";
            public static readonly string DisplayName = "DisplayName";
            public static readonly string SDPersons = "SDPersons";
		}
		#endregion
	}
	 
	
}
