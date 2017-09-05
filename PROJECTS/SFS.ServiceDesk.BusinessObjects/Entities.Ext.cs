 
 
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
//using Repository.Pattern.Ef6;
#endregion
namespace SFS.ServiceDesk.BusinessObjects
{

	  [Serializable()]
	  [EntityInfo(PropertyKeyName="GuidArea",PropertyDefaultText="Name",RequiredProperties="Name", CompanyPropertyName = "GuidCompany",CreatedByPropertyName="CreatedBy",UpdatedByPropertyName="UpdatedBy",CreatedDatePropertyName="CreatedDate",UpdatedDatePropertyName="UpdatedDate",DeletedPropertyName="IsDeleted")]
	  [DynamicLinqType]
	  public partial class SDArea:  IMyEntity{
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
	  public partial class SDAreaPerson:  IMyEntity{
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
	  public partial class SDCase:  IMyEntity{
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
	  [EntityInfo(PropertyKeyName="GuidCasefile",PropertyDefaultText="Bytes",RequiredProperties="UrlFile,UrlThumbFile,ExistFile", CompanyPropertyName = "GuidCompany",CreatedByPropertyName="CreatedBy",UpdatedByPropertyName="UpdatedBy",CreatedDatePropertyName="CreatedDate",UpdatedDatePropertyName="UpdatedDate",DeletedPropertyName="IsDeleted")]
	  [DynamicLinqType]
	  public partial class SDCaseFile:  IMyEntity{
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
        
			
	public String UrlFile { get; set; }
			
	public String UrlThumbFile { get; set; }
			[DataMember]
          	 public Boolean ExistFile { get; set; } //test

			[DataMember]
          	 public String FileName { get; set; } //test

			[DataMember]
          	 public String FileStorage { get; set; } //test

	
       
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
		}
		#endregion
	}
		  [Serializable()]
	  [EntityInfo(PropertyKeyName="GuidCaseHistory",PropertyDefaultText="BodyContent",RequiredProperties="GuidCase,BodyContent,SDCase", CompanyPropertyName = "GuidCompany",CreatedByPropertyName="CreatedBy",UpdatedByPropertyName="UpdatedBy",CreatedDatePropertyName="CreatedDate",UpdatedDatePropertyName="UpdatedDate",DeletedPropertyName="IsDeleted")]
	  [DynamicLinqType]
	  public partial class SDCaseHistory:  IMyEntity{
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
	  public partial class SDCaseHistoryFile:  IMyEntity{
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
	  public partial class SDCasePriority:  IMyEntity{
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
	  public partial class SDCaseState:  IMyEntity{
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
	  public partial class SDFile:  IMyEntity{
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
            public static readonly string SDCaseFiles = "SDCaseFiles";
            public static readonly string SDCaseHistoryFiles = "SDCaseHistoryFiles";
		}
		#endregion
	}
		  [Serializable()]
	  [EntityInfo(PropertyKeyName="GuidOrganization",PropertyDefaultText="FullName",RequiredProperties="FullName", CompanyPropertyName = "GuidCompany",CreatedByPropertyName="CreatedBy",UpdatedByPropertyName="UpdatedBy",CreatedDatePropertyName="CreatedDate",UpdatedDatePropertyName="UpdatedDate",DeletedPropertyName="IsDeleted")]
	  [DynamicLinqType]
	  public partial class SDOrganization:  IMyEntity{
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
	  public partial class SDPerson:  IMyEntity{
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
	  public partial class SDProxyUser:  IMyEntity{
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
