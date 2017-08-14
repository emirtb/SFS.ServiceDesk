 
 

#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
//using SFSdotNet.Framework.Common.Entities.Metadata;
//using SFSdotNet.Framework.Common.Entities;

//using Repository.Pattern.Ef6;
#endregion
namespace SFS.ServiceDesk.Client.Models
{


	  [Serializable()]
	  public partial class SDArea{
public Guid? GuidArea { get; set; }		

			


public String Name { get; set; }		
		
			


public Guid? GuidAreaParent { get; set; }		
		
			


public Guid? GuidOrganization { get; set; }		
		
			


public Guid? GuidCompany { get; set; }		
		
			


public DateTime? CreatedDate { get; set; }		
		
			


public DateTime? UpdatedDate { get; set; }		
		
			


public Guid? CreatedBy { get; set; }		
		
			


public Guid? UpdatedBy { get; set; }		
		
			


public Int32? Bytes { get; set; }		
		
			


public Boolean? IsDeleted { get; set; }		
		
			
public List<SDArea>  SDArea1 { get; set; }		
		
 			


public SDArea SDArea2 { get; set; }		
		
			


public SDOrganization SDOrganization { get; set; }		
		
			
public List<SDAreaPerson>  SDAreaPersons { get; set; }		
		
 	  }

	  [Serializable()]
	  public partial class SDAreaPerson{
public Guid? GuidAreaPerson { get; set; }		

			


public Guid? GuidArea { get; set; }		
		
			


public Guid? GuidPerson { get; set; }		
		
			


public Guid? GuidCompany { get; set; }		
		
			


public DateTime? CreatedDate { get; set; }		
		
			


public DateTime? UpdatedDate { get; set; }		
		
			


public Guid? CreatedBy { get; set; }		
		
			


public Guid? UpdatedBy { get; set; }		
		
			


public Int32? Bytes { get; set; }		
		
			


public Boolean? IsDeleted { get; set; }		
		
			


public SDArea SDArea { get; set; }		
		
			


public SDPerson SDPerson { get; set; }		
		
	  }

	  [Serializable()]
	  public partial class SDCase{
public Guid? GuidCase { get; set; }		

			


public Guid GuidCaseState { get; set; }		
		
			


public Guid? GuidPersonClient { get; set; }		
		
			


public DateTime? ClosedDateTime { get; set; }		
		
			


public String BodyContent { get; set; }		
		
			


public String PreviewContent { get; set; }		
		
			


public Guid GuidCasePriority { get; set; }		
		
			


public String Title { get; set; }		
		
			


public Guid? GuidCompany { get; set; }		
		
			


public DateTime? CreatedDate { get; set; }		
		
			


public DateTime? UpdatedDate { get; set; }		
		
			


public Guid? CreatedBy { get; set; }		
		
			


public Guid? UpdatedBy { get; set; }		
		
			


public Int32? Bytes { get; set; }		
		
			


public Boolean? IsDeleted { get; set; }		
		
			


public SDPerson SDPerson { get; set; }		
		
			


public SDCasePriority SDCasePriority { get; set; }		
		
			


public SDCaseState SDCaseState { get; set; }		
		
			
public List<SDCaseFile>  SDCaseFiles { get; set; }		
		
 			
public List<SDCaseHistory>  SDCaseHistories { get; set; }		
		
 	  }

	  [Serializable()]
	  public partial class SDCaseFile{
public Guid? GuidCasefile { get; set; }		

			


public Guid? GuidCase { get; set; }		
		
			


public Guid? GuidFile { get; set; }		
		
			


public Guid? GuidCompany { get; set; }		
		
			


public DateTime? CreatedDate { get; set; }		
		
			


public DateTime? UpdatedDate { get; set; }		
		
			


public Guid? CreatedBy { get; set; }		
		
			


public Guid? UpdatedBy { get; set; }		
		
			


public Int32? Bytes { get; set; }		
		
			


public Boolean? IsDeleted { get; set; }		
		
			


public SDCase SDCase { get; set; }		
		
			


public SDFile SDFile { get; set; }		
		
	  }

	  [Serializable()]
	  public partial class SDCaseHistory{
public Guid? GuidCaseHistory { get; set; }		

			


public Guid GuidCase { get; set; }		
		
			


public Guid? GuidCaseStatus { get; set; }		
		
			


public String BodyContent { get; set; }		
		
			


public String PreviewContent { get; set; }		
		
			


public Guid? GuidCompany { get; set; }		
		
			


public DateTime? CreatedDate { get; set; }		
		
			


public DateTime? UpdatedDate { get; set; }		
		
			


public Guid? CreatedBy { get; set; }		
		
			


public Guid? UpdatedBy { get; set; }		
		
			


public Int32? Bytes { get; set; }		
		
			


public Boolean? IsDeleted { get; set; }		
		
			


public SDCase SDCase { get; set; }		
		
			


public SDCaseState SDCaseState { get; set; }		
		
			
public List<SDCaseHistoryFile>  SDCaseHistoryFiles { get; set; }		
		
 	  }

	  [Serializable()]
	  public partial class SDCaseHistoryFile{
public Guid? GuidCasehistoryFile { get; set; }		

			


public Guid? GuidFile { get; set; }		
		
			


public Guid? GuidCaseHistory { get; set; }		
		
			


public Guid? GuidCompany { get; set; }		
		
			


public DateTime? CreatedDate { get; set; }		
		
			


public DateTime? UpdatedDate { get; set; }		
		
			


public Guid? CreatedBy { get; set; }		
		
			


public Guid? UpdatedBy { get; set; }		
		
			


public Int32? Bytes { get; set; }		
		
			


public Boolean? IsDeleted { get; set; }		
		
			


public SDCaseHistory SDCaseHistory { get; set; }		
		
			


public SDFile SDFile { get; set; }		
		
	  }

	  [Serializable()]
	  public partial class SDCasePriority{
public Guid? GuidCasePriority { get; set; }		

			


public String Title { get; set; }		
		
			


public Guid? GuidCompany { get; set; }		
		
			


public DateTime? CreatedDate { get; set; }		
		
			


public DateTime? UpdatedDate { get; set; }		
		
			


public Guid? CreatedBy { get; set; }		
		
			


public Guid? UpdatedBy { get; set; }		
		
			


public Int32? Bytes { get; set; }		
		
			


public Boolean? IsDeleted { get; set; }		
		
			
public List<SDCase>  SDCases { get; set; }		
		
 	  }

	  [Serializable()]
	  public partial class SDCaseState{
public Guid? GuidCaseState { get; set; }		

			


public String Title { get; set; }		
		
			


public Guid? GuidCompany { get; set; }		
		
			


public DateTime? CreatedDate { get; set; }		
		
			


public DateTime? UpdatedDate { get; set; }		
		
			


public Guid? CreatedBy { get; set; }		
		
			


public Guid? UpdatedBy { get; set; }		
		
			


public Int32? Bytes { get; set; }		
		
			


public Boolean? IsDeleted { get; set; }		
		
			
public List<SDCase>  SDCases { get; set; }		
		
 			
public List<SDCaseHistory>  SDCaseHistories { get; set; }		
		
 	  }

	  [Serializable()]
	  public partial class SDFile{
public Guid? GuidFile { get; set; }		

			


public String FileName { get; set; }		
		
			


public String FileType { get; set; }		
		
			


public Int64? FileSize { get; set; }		
		
			


public Byte[] FileData { get; set; }		
		
			


public String StorageLocation { get; set; }		
		
			


public Guid? GuidCompany { get; set; }		
		
			


public DateTime? CreatedDate { get; set; }		
		
			


public DateTime? UpdatedDate { get; set; }		
		
			


public Guid? CreatedBy { get; set; }		
		
			


public Guid? UpdatedBy { get; set; }		
		
			


public Int32? Bytes { get; set; }		
		
			


public Boolean? IsDeleted { get; set; }		
		
			
public List<SDCaseFile>  SDCaseFiles { get; set; }		
		
 			
public List<SDCaseHistoryFile>  SDCaseHistoryFiles { get; set; }		
		
 	  }

	  [Serializable()]
	  public partial class SDOrganization{
public Guid? GuidOrganization { get; set; }		

			


public String FullName { get; set; }		
		
			


public Guid? GuidCompany { get; set; }		
		
			


public DateTime? CreatedDate { get; set; }		
		
			


public DateTime? UpdatedDate { get; set; }		
		
			


public Guid? CreatedBy { get; set; }		
		
			


public Guid? UpdatedBy { get; set; }		
		
			


public Int32? Bytes { get; set; }		
		
			


public Boolean? IsDeleted { get; set; }		
		
			
public List<SDArea>  SDAreas { get; set; }		
		
 			
public List<SDPerson>  SDPersons { get; set; }		
		
 	  }

	  [Serializable()]
	  public partial class SDPerson{
public Guid? GuidPerson { get; set; }		

			


public String DisplayName { get; set; }		
		
			


public Guid? GuidUser { get; set; }		
		
			


public Guid? GuidOrganization { get; set; }		
		
			


public Guid? GuidCompany { get; set; }		
		
			


public DateTime? CreatedDate { get; set; }		
		
			


public DateTime? UpdatedDate { get; set; }		
		
			


public Guid? CreatedBy { get; set; }		
		
			


public Guid? UpdatedBy { get; set; }		
		
			


public Int32? Bytes { get; set; }		
		
			


public Boolean? IsDeleted { get; set; }		
		
			
public List<SDAreaPerson>  SDAreaPersons { get; set; }		
		
 			
public List<SDCase>  SDCases { get; set; }		
		
 			


public SDOrganization SDOrganization { get; set; }		
		
			


public SDProxyUser SDProxyUser { get; set; }		
		
	  }

	  [Serializable()]
	  public partial class SDProxyUser{
public Guid? GuidUser { get; set; }		

			


public String Email { get; set; }		
		
			


public String DisplayName { get; set; }		
		
			
public List<SDPerson>  SDPersons { get; set; }		
		
 	  }
	
}
