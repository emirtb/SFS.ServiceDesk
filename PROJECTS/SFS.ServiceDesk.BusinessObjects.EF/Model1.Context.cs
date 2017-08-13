﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SFS.ServiceDesk.BusinessObjects.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
     using InteractivePreGeneratedViews;
    
    public partial class SFSServiceDeskContext : DbContext
    {
     public SFSServiceDeskContext(string conn, string pathCacheViews )
            : base(conn)
        {
            Database.SetInitializer(new NullDatabaseInitializer<SFSServiceDeskContext>());
    		Configuration.ProxyCreationEnabled = false;
    
    		 if (!string.IsNullOrEmpty(pathCacheViews))
                {
                    if (!InteractiveViewsHelper.Attached(this))
                    {
    					try{
    						InteractiveViews.SetViewCacheFactory(this, new FileViewCacheFactory(pathCacheViews + @"MyViews.xml"));
    					}catch{
    
    					}
                    }
                }
        }
    
        public SFSServiceDeskContext()
            : base("name=SFSServiceDeskContext")
        {
    		Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SDArea> SDAreas { get; set; }
        public virtual DbSet<SDAreaPerson> SDAreaPersons { get; set; }
        public virtual DbSet<SDCase> SDCases { get; set; }
        public virtual DbSet<SDCaseFile> SDCaseFiles { get; set; }
        public virtual DbSet<SDCaseHistory> SDCaseHistories { get; set; }
        public virtual DbSet<SDCaseHistoryFile> SDCaseHistoryFiles { get; set; }
        public virtual DbSet<SDCasePriority> SDCasePriorities { get; set; }
        public virtual DbSet<SDCaseStatu> SDCaseStatus { get; set; }
        public virtual DbSet<SDFile> SDFiles { get; set; }
        public virtual DbSet<SDOrganization> SDOrganizations { get; set; }
        public virtual DbSet<SDPerson> SDPersons { get; set; }
        public virtual DbSet<SDProxyUser> SDProxyUsers { get; set; }
    }
}
