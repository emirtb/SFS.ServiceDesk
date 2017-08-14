
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace SFS.ServiceDesk.BusinessObjects
{

using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using SFSdotNet.Framework.Common.Entities;
    
[JsonObject(IsReference = true)]
[DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]
public partial class SDArea : ITrackable
{

    public SDArea()
    {
	
		this.ModifiedProperties = new List<string>();

        this.SDArea1 = new List<SDArea>();

        this.SDAreaPersons = new List<SDAreaPerson>();

    }


    [DataMember]
        public System.Guid GuidArea { get; set; }

    [DataMember]
        public string Name { get; set; }

    [DataMember]
        public Nullable<System.Guid> GuidAreaParent { get; set; }

    [DataMember]
        public Nullable<System.Guid> GuidOrganization { get; set; }

    [DataMember]
        public Nullable<System.Guid> GuidCompany { get; set; }

    [DataMember]
        public Nullable<System.DateTime> CreatedDate { get; set; }

    [DataMember]
        public Nullable<System.DateTime> UpdatedDate { get; set; }

    [DataMember]
        public Nullable<System.Guid> CreatedBy { get; set; }

    [DataMember]
        public Nullable<System.Guid> UpdatedBy { get; set; }

    [DataMember]
        public Nullable<int> Bytes { get; set; }

    [DataMember]
        public Nullable<bool> IsDeleted { get; set; }



    [DataMember]
        public ICollection<SDArea> SDArea1 { get; set; }

    [DataMember]
        public SDArea SDArea2 { get; set; }

    [DataMember]
        public SDOrganization SDOrganization { get; set; }

    [DataMember]
        public ICollection<SDAreaPerson> SDAreaPersons { get; set; }


    [DataMember]
    public TrackingState TrackingState { get; set; }
    [DataMember]
    public ICollection<string> ModifiedProperties { get; set; }
    [JsonProperty, DataMember]
    private Guid EntityIdentifier { get; set; }
}

}