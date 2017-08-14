 
 
 
// <Template>
//   <SolutionTemplate>EF POCO 1</SolutionTemplate>
//   <Version>20140213.2136</Version>
//   <Update>mas de contextRequest</Update>
// </Template>
#region using
using System;
using System.Collections.Generic;
using System.Text;
using SFSdotNet.Framework.BR;
using System.Linq.Dynamic;
using System.Collections;
using System.Linq;
using LinqKit;
using SFSdotNet.Framework.Entities;
using SFSdotNet.Framework.Linq;
using System.Linq.Expressions;
using System.Data;
using SFSdotNet.Framework;
using SFSdotNet.Framework.My;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Core.Objects;
using SFS.ServiceDesk.BusinessObjects;
//using SFS.ServiceDesk.BusinessObjects.EFPocoAdapter;
using EntityFramework.BulkExtensions;
//using EFPocoAdapter;
using SFSdotNet.Framework.Entities.Trackable;

using System.Data.Entity;


#endregion
namespace SFS.ServiceDesk.BR
{
public class SinglentonContext
    {
        private static EFContext context = null;
        public static EFContext Instance {
            get {
               if (context == null)
                    context = new EFContext();
                return context;
            }
        }
        /// <summary>
    /// Re-new the singlenton instance
    /// </summary>
    /// <returns></returns>
        public static EFContext RenewInstance() {
            context = new EFContext();
            return context;
        }
    /// <summary>
    /// Get a new instance
    /// </summary>
        public static EFContext NewInstance {
            get {
                return new EFContext();
            }
        }
    }
	
	
		public partial class SDAreasBR:BRBase<SDArea>{
	 	
           
		 #region Partial methods

           partial void OnUpdating(object sender, BusinessRulesEventArgs<SDArea> e);

            partial void OnUpdated(object sender, BusinessRulesEventArgs<SDArea> e);
			partial void OnUpdatedAgile(object sender, BusinessRulesEventArgs<SDArea> e);

            partial void OnCreating(object sender, BusinessRulesEventArgs<SDArea> e);
            partial void OnCreated(object sender, BusinessRulesEventArgs<SDArea> e);

            partial void OnDeleting(object sender, BusinessRulesEventArgs<SDArea> e);
            partial void OnDeleted(object sender, BusinessRulesEventArgs<SDArea> e);

            partial void OnGetting(object sender, BusinessRulesEventArgs<SDArea> e);
            protected override void OnVirtualGetting(object sender, BusinessRulesEventArgs<SDArea> e)
            {
                OnGetting(sender, e);
            }
			protected override void OnVirtualCounting(object sender, BusinessRulesEventArgs<SDArea> e)
            {
                OnCounting(sender, e);
            }
			partial void OnTaken(object sender, BusinessRulesEventArgs<SDArea> e);
			protected override void OnVirtualTaken(object sender, BusinessRulesEventArgs<SDArea> e)
            {
                OnTaken(sender, e);
            }

            partial void OnCounting(object sender, BusinessRulesEventArgs<SDArea> e);
 
			partial void OnQuerySettings(object sender, BusinessRulesEventArgs<SDArea> e);
          
            #endregion
			
		private static SDAreasBR singlenton =null;
				public static SDAreasBR NewInstance(){
					return  new SDAreasBR();
					
				}
		public static SDAreasBR Instance{
			get{
				if (singlenton == null)
					singlenton = new SDAreasBR();
				return singlenton;
			}
		}
		//private bool preventSecurityRestrictions = false;
		 public bool PreventAuditTrail { get; set;  }
		#region Fields
        EFContext context = null;
        #endregion
        #region Constructor
        public SDAreasBR()
        {
            context = new EFContext();
        }
		 public SDAreasBR(bool preventSecurity)
            {
                this.preventSecurityRestrictions = preventSecurity;
				context = new EFContext();
            }
        #endregion
		
		#region Get

 		public IQueryable<SDArea> Get()
        {
            using (EFContext con = new EFContext())
            {
				
				var query = con.SDAreas.AsQueryable();
                con.Configuration.ProxyCreationEnabled = false;

                //query = ContextQueryBuilder<Nutrient>.ApplyContextQuery(query, contextRequest);

                return query;




            }

        }
		


 	
		public List<SDArea> GetAll()
        {
            return this.GetBy(p => true);
        }
        public List<SDArea> GetAll(string includes)
        {
            return this.GetBy(p => true, includes);
        }
        public SDArea GetByKey(Guid guidArea)
        {
            return GetByKey(guidArea, true);
        }
        public SDArea GetByKey(Guid guidArea, bool loadIncludes)
        {
            SDArea item = null;
			var query = PredicateBuilder.True<SDArea>();
                    
			string strWhere = @"GuidArea = Guid(""" + guidArea.ToString()+@""")";
            Expression<Func<SDArea, bool>> predicate = null;
            //if (!string.IsNullOrEmpty(strWhere))
            //    predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDArea, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
			 ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
            contextRequest.CustomQuery.FilterExpressionString = strWhere;

			//item = GetBy(predicate, loadIncludes, contextRequest).FirstOrDefault();
			item = GetBy(strWhere,loadIncludes,contextRequest).FirstOrDefault();
            return item;
        }
         public List<SDArea> GetBy(string strWhere, bool loadRelations, ContextRequest contextRequest)
        {
            if (!loadRelations)
                return GetBy(strWhere, contextRequest);
            else
                return GetBy(strWhere, contextRequest, "");

        }
		  public List<SDArea> GetBy(string strWhere, bool loadRelations)
        {
              if (!loadRelations)
                return GetBy(strWhere, new ContextRequest());
            else
                return GetBy(strWhere, new ContextRequest(), "");

        }
		         public SDArea GetByKey(Guid guidArea, params Expression<Func<SDArea, object>>[] includes)
        {
            SDArea item = null;
			string strWhere = @"GuidArea = Guid(""" + guidArea.ToString()+@""")";
          Expression<Func<SDArea, bool>> predicate = p=> p.GuidArea == guidArea;
           // if (!string.IsNullOrEmpty(strWhere))
           //     predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDArea, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
        item = GetBy(predicate, includes).FirstOrDefault();
         ////   item = GetBy(strWhere,includes).FirstOrDefault();
			return item;

        }
        public SDArea GetByKey(Guid guidArea, string includes)
        {
            SDArea item = null;
			string strWhere = @"GuidArea = Guid(""" + guidArea.ToString()+@""")";
            
			
            item = GetBy(strWhere, includes).FirstOrDefault();
            return item;

        }
		 public SDArea GetByKey(Guid guidArea, string usemode, string includes)
		{
			return GetByKey(guidArea, usemode, null, includes);

		 }
		 public SDArea GetByKey(Guid guidArea, string usemode, ContextRequest context,  string includes)
        {
            SDArea item = null;
			string strWhere = @"GuidArea = Guid(""" + guidArea.ToString()+@""")";
			if (context == null){
				context = new ContextRequest();
				context.CustomQuery = new CustomQuery();
				context.CustomQuery.IsByKey = true;
				context.CustomQuery.FilterExpressionString = strWhere;
				context.UseMode = usemode;
			}
            item = GetBy(strWhere,context , includes).FirstOrDefault();
            return item;

        }

        #region Dynamic Predicate
        public List<SDArea> GetBy(Expression<Func<SDArea, bool>> predicate, int? pageSize, int? page)
        {
            return this.GetBy(predicate, pageSize, page, null, null);
        }
        public List<SDArea> GetBy(Expression<Func<SDArea, bool>> predicate, ContextRequest contextRequest)
        {

            return GetBy(predicate, contextRequest,"");
        }
        
        public List<SDArea> GetBy(Expression<Func<SDArea, bool>> predicate, ContextRequest contextRequest, params Expression<Func<SDArea, object>>[] includes)
        {
            StringBuilder sb = new StringBuilder();
           if (includes != null)
            {
                foreach (var path in includes)
                {

						if (sb.Length > 0) sb.Append(",");
						sb.Append(SFSdotNet.Framework.Linq.Utils.IncludeToString<SDArea>(path));

               }
            }
            return GetBy(predicate, contextRequest, sb.ToString());
        }
        
        
        public List<SDArea> GetBy(Expression<Func<SDArea, bool>> predicate, string includes)
        {
			ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";

            return GetBy(predicate, context, includes);
        }

        public List<SDArea> GetBy(Expression<Func<SDArea, bool>> predicate, params Expression<Func<SDArea, object>>[] includes)
        {
			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest context = new ContextRequest();
			            context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";
            return GetBy(predicate, context, includes);
        }

      
		public bool DisableCache { get; set; }
		public List<SDArea> GetBy(Expression<Func<SDArea, bool>> predicate, ContextRequest contextRequest, string includes)
		{
            using (EFContext con = new EFContext()) {
				
				string fkIncludes = "SDArea2,SDOrganization";
                List<string> multilangProperties = new List<string>();
				if (predicate == null) predicate = PredicateBuilder.True<SDArea>();
				string isDeletedField = null;
				Expression<Func<SDArea,bool>> notDeletedExpression = null;
	
					bool sharedAndMultiTenant = false;
					Expression<Func<SDArea,bool>> multitenantExpression  = null;
					if (contextRequest != null && contextRequest.Company != null)	                        	
						multitenantExpression = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicate, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression);

#region Old code
/*
				List<SDArea> result = null;
               BusinessRulesEventArgs<SDArea>  e = null;
	
				OnGetting(con, e = new BusinessRulesEventArgs<SDArea>() {  FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null) });

               // OnGetting(con,e = new BusinessRulesEventArgs<SDArea>() { FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = contextRequest.CustomQuery.FilterExpressionString});
				   if (e != null) {
				    predicate = e.FilterExpression;
						if (e.Cancel)
						{
							context = null;
							 if (e.Items == null) e.Items = new List<SDArea>();
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                if (predicate == null) predicate = PredicateBuilder.True<SDArea>();
 				string fkIncludes = "SDArea2,SDOrganization";
                if(contextRequest!=null){
					if (contextRequest.CustomQuery != null)
					{
						if (contextRequest.CustomQuery.IncludeForeignKeyPaths != null) {
							if (contextRequest.CustomQuery.IncludeForeignKeyPaths.Value == false)
								fkIncludes = "";
						}
					}
				}
				if (!string.IsNullOrEmpty(includes))
					includes = includes + "," + fkIncludes;
				else
					includes = fkIncludes;
                
                //var es = _repository.Queryable;

                IQueryable<SDArea> query =  con.SDAreas.AsQueryable();

                                if (!string.IsNullOrEmpty(includes))
                {
                    foreach (string include in includes.Split(char.Parse(",")))
                    {
						if (!string.IsNullOrEmpty(include))
                            query = query.Include(include);
                    }
                }
					 	if (!preventSecurityRestrictions)
						{
							if (contextRequest != null )
		                    	if (contextRequest.User !=null )
		                        	if (contextRequest.Company != null){
		                        	
										predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
 									
									}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				query =query.AsExpandable().Where(predicate);
                query = ContextQueryBuilder<SDArea>.ApplyContextQuery(query, contextRequest);

                result = query.AsNoTracking().ToList<SDArea>();
				  
                if (e != null)
                {
                    e.Items = result;
                }
				//if (contextRequest != null ){
				//	 contextRequest = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
					contextRequest.CustomQuery = new CustomQuery();

				//}
				OnTaken(this, e == null ? e =  new BusinessRulesEventArgs<SDArea>() { Items= result, IncludingComputedLinq = false, ContextRequest = contextRequest,  FilterExpression = predicate } :  e);
  
			

                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
				*/
#endregion
            }
        }


		/*public int Update(List<SDArea> items, ContextRequest contextRequest)
            {
                int result = 0;
                using (EFContext con = new EFContext())
                {
                   
                

                    foreach (var item in items)
                    {
                        //secMessageToUser messageToUser = new secMessageToUser();
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            item.GetType().GetProperty(prop).SetValue(item, item.GetType().GetProperty(prop).GetValue(item));
                        }
                        //messageToUser.GuidMessageToUser = (Guid)item.GetType().GetProperty("GuidMessageToUser").GetValue(item);

                        var setObject = con.CreateObjectSet<SDArea>("SDAreas");
                        //messageToUser.Readed = DateTime.UtcNow;
                        setObject.Attach(item);
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            con.ObjectStateManager.GetObjectStateEntry(item).SetModifiedProperty(prop);
                        }
                       
                    }
                    result = con.SaveChanges();

                    


                }
                return result;
            }
           */
		

        public List<SDArea> GetBy(string predicateString, ContextRequest contextRequest, string includes)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
				


				string computedFields = "";
				string fkIncludes = "SDArea2,SDOrganization";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDArea>();
				string isDeletedField = null;
				string notDeletedExpression = null;
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					//if (contextRequest != null && contextRequest.Company != null)                      	
					//	 multitenantExpression = @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))";
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicateString, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression,computedFields);


	#region Old Code
	/*
				BusinessRulesEventArgs<SDArea> e = null;

				Filter filter = new Filter();
                if (predicateString.Contains("|"))
                {
                    string ft = GetSpecificFilter(predicateString, contextRequest);
                    if (!string.IsNullOrEmpty(ft))
                        filter.SetFilterPart("ft", ft);
                   
                    contextRequest.FreeText = predicateString.Split(char.Parse("|"))[1];
                    var q1 = predicateString.Split(char.Parse("|"))[0];
                    if (!string.IsNullOrEmpty(q1))
                    {
                        filter.ProcessText(q1);
                    }
                }
                else {
                    filter.ProcessText(predicateString);
                }
				 var includesList = (new List<string>());
                 if (!string.IsNullOrEmpty(includes))
                 {
                     includesList = includes.Split(char.Parse(",")).ToList();
                 }

				List<SDArea> result = new List<SDArea>();
         
			QueryBuild(predicateString, filter, con, contextRequest, "getby", includesList);
			 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }
				
				
					OnGetting(con, e == null ? e = new BusinessRulesEventArgs<SDArea>() { Filter = filter, ContextRequest = contextRequest  } : e );

                  //OnGetting(con,e = new BusinessRulesEventArgs<SDArea>() {  ContextRequest = contextRequest, FilterExpressionString = predicateString });
			   	if (e != null) {
				    //predicateString = e.GetQueryString();
						if (e.Cancel)
						{
							context = null;
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				//	 else {
                //      predicateString = predicateString.Replace("*extraFreeText*", "").Replace("()","");
                //  }
				//con.EnableChangeTrackingUsingProxies = false;
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                //if (predicate == null) predicate = PredicateBuilder.True<SDArea>();
 				string fkIncludes = "SDArea2,SDOrganization";
                if(contextRequest!=null){
					if (contextRequest.CustomQuery != null)
					{
						if (contextRequest.CustomQuery.IncludeForeignKeyPaths != null) {
							if (contextRequest.CustomQuery.IncludeForeignKeyPaths.Value == false)
								fkIncludes = "";
						}
					}
				}else{
                    contextRequest = new ContextRequest();
                    contextRequest.CustomQuery = new CustomQuery();

                }
				if (!string.IsNullOrEmpty(includes))
					includes = includes + "," + fkIncludes;
				else
					includes = fkIncludes;
                
                //var es = _repository.Queryable;
				IQueryable<SDArea> query = con.SDAreas.AsQueryable();
		
				// include relations FK
				if(string.IsNullOrEmpty(includes) ){
					includes ="";
				}
				StringBuilder sbQuerySystem = new StringBuilder();
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
	                    	if (contextRequest.User !=null )
	                        	if (contextRequest.Company != null ){
	                        		//if (sbQuerySystem.Length > 0)
	                        		//	    			sbQuerySystem.Append( " And ");	
									//sbQuerySystem.Append(@" (GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa

									filter.SetFilterPart("co",@"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))");

								}
						}	
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				//string predicateString = predicate.ToDynamicLinq<SDArea>();
				//predicateString += sbQuerySystem.ToString();
				filter.CleanAndProcess("");

				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed(); //SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicateString );               
                string predicateWithManyRelations = filter.GetFilterChildren(); //SFSdotNet.Framework.Linq.Utils.CleanPartExpression(predicateString);

                //QueryUtils.BreakeQuery1(predicateString, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
                var _queryable = query.AsQueryable();
				bool includeAll = true; 
                if (!string.IsNullOrEmpty(predicateWithManyRelations))
                    _queryable = _queryable.Where(predicateWithManyRelations, contextRequest.CustomQuery.ExtraParams);
				if (contextRequest.CustomQuery.SpecificProperties.Count > 0)
                {

				includeAll = false; 
                }

				StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append("new (");
                bool existPrev = false;
                foreach (var selected in contextRequest.CustomQuery.SelectedFields.Where(p=> !string.IsNullOrEmpty(p.Linq)))
                {
                    if (existPrev) sbSelect.Append(", ");
                    if (!selected.Linq.Contains(".") && !selected.Linq.StartsWith("it."))
                        sbSelect.Append("it." + selected.Linq);
                    else
                        sbSelect.Append(selected.Linq);
                    existPrev = true;
                }
                sbSelect.Append(")");
                var queryable = _queryable.Select(sbSelect.ToString());                    


     				
                 if (!string.IsNullOrEmpty(predicateWithFKAndComputed))
                    queryable = queryable.Where(predicateWithFKAndComputed, contextRequest.CustomQuery.ExtraParams);

				QueryComplementOptions queryOps = ContextQueryBuilder.ApplyContextQuery(contextRequest);
            	if (!string.IsNullOrEmpty(queryOps.OrderByAndSort)){
					if (queryOps.OrderBy.Contains(".") && !queryOps.OrderBy.StartsWith("it.")) queryOps.OrderBy = "it." + queryOps.OrderBy;
					queryable = queryable.OrderBy(queryOps.OrderByAndSort);
					}
               	if (queryOps.Skip != null)
                {
                    queryable = queryable.Skip(queryOps.Skip.Value);
                }
                if (queryOps.PageSize != null)
                {
                    queryable = queryable.Take (queryOps.PageSize.Value);
                }


                var resultTemp = queryable.AsQueryable().ToListAsync().Result;
                foreach (var item in resultTemp)
                {

				   result.Add(SFSdotNet.Framework.BR.Utils.GetConverted<SDArea,dynamic>(item, contextRequest.CustomQuery.SelectedFields.Select(p=>p.Name).ToArray()));
                }

			 if (e != null)
                {
                    e.Items = result;
                }
				 contextRequest.CustomQuery = new CustomQuery();
				OnTaken(this, e == null ? e = new BusinessRulesEventArgs<SDArea>() { Items= result, IncludingComputedLinq = true, ContextRequest = contextRequest, FilterExpressionString  = predicateString } :  e);
  
			
  
                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
	
	*/
	#endregion

            }
        }
		public SDArea GetFromOperation(string function, string filterString, string usemode, string fields, ContextRequest contextRequest)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
                string computedFields = "";
               // string fkIncludes = "accContpaqiClassification,accProjectConcept,accProjectType,accProxyUser";
                List<string> multilangProperties = new List<string>();
				string isDeletedField = null;
				string notDeletedExpression = null;
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					if (contextRequest != null && contextRequest.Company != null)
					{
						multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
						contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
					}
					 									
					string multiTenantField = "GuidCompany";


                return GetSummaryOperation(con, new SDArea(), function, filterString, usemode, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields, contextRequest, fields.Split(char.Parse(",")).ToArray());
            }
        }

   protected override void QueryBuild(string predicate, Filter filter, DbContext efContext, ContextRequest contextRequest, string method, List<string> includesList)
      	{
				if (contextRequest.CustomQuery.SpecificProperties.Count == 0)
                {
					contextRequest.CustomQuery.SpecificProperties.Add(SDArea.PropertyNames.Name);
					contextRequest.CustomQuery.SpecificProperties.Add(SDArea.PropertyNames.GuidAreaParent);
					contextRequest.CustomQuery.SpecificProperties.Add(SDArea.PropertyNames.GuidOrganization);
					contextRequest.CustomQuery.SpecificProperties.Add(SDArea.PropertyNames.GuidCompany);
					contextRequest.CustomQuery.SpecificProperties.Add(SDArea.PropertyNames.CreatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDArea.PropertyNames.UpdatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDArea.PropertyNames.CreatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDArea.PropertyNames.UpdatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDArea.PropertyNames.Bytes);
					contextRequest.CustomQuery.SpecificProperties.Add(SDArea.PropertyNames.IsDeleted);
					contextRequest.CustomQuery.SpecificProperties.Add(SDArea.PropertyNames.SDArea2);
					contextRequest.CustomQuery.SpecificProperties.Add(SDArea.PropertyNames.SDOrganization);
                    
				}

				if (method == "getby" || method == "sum")
				{
					if (!contextRequest.CustomQuery.SpecificProperties.Contains("GuidArea")){
						contextRequest.CustomQuery.SpecificProperties.Add("GuidArea");
					}

					 if (!string.IsNullOrEmpty(contextRequest.CustomQuery.OrderBy))
					{
						string existPropertyOrderBy = contextRequest.CustomQuery.OrderBy;
						if (contextRequest.CustomQuery.OrderBy.Contains("."))
						{
							existPropertyOrderBy = contextRequest.CustomQuery.OrderBy.Split(char.Parse("."))[0];
						}
						if (!contextRequest.CustomQuery.SpecificProperties.Exists(p => p == existPropertyOrderBy))
						{
							contextRequest.CustomQuery.SpecificProperties.Add(existPropertyOrderBy);
						}
					}

				}
				
	bool isFullDetails = contextRequest.IsFromUI("SDAreas", UIActions.GetForDetails);
	string filterForTest = predicate  + filter.GetFilterComplete();

				if (isFullDetails || !string.IsNullOrEmpty(predicate))
            {
            } 

			if (method == "sum")
            {
            } 
			if (contextRequest.CustomQuery.SelectedFields.Count == 0)
            {
				foreach (var selected in contextRequest.CustomQuery.SpecificProperties)
                {
					string linq = selected;
					switch (selected)
                    {

					case "SDArea2":
					if (includesList.Contains(selected)){
                        linq = "it.SDArea2 as SDArea2";
					}
                    else
						linq = "iif(it.SDArea2 != null, new (it.SDArea2.GuidArea, it.SDArea2.Name), null) as SDArea2";
 					break;
					case "SDOrganization":
					if (includesList.Contains(selected)){
                        linq = "it.SDOrganization as SDOrganization";
					}
                    else
						linq = "iif(it.SDOrganization != null, new (it.SDOrganization.GuidOrganization, it.SDOrganization.FullName), null) as SDOrganization";
 					break;
					 
						
					 default:
                            break;
                    }
					contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name=selected, Linq=linq});
					if (method == "getby" || method == "sum")
					{
						if (includesList.Contains(selected))
							includesList.Remove(selected);

					}

				}
			}
				if (method == "getby" || method == "sum")
				{
					foreach (var otherInclude in includesList.Where(p=> !string.IsNullOrEmpty(p)))
					{
						contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name = otherInclude, Linq = "it." + otherInclude +" as " + otherInclude });
					}
				}
				BusinessRulesEventArgs<SDArea> e = null;
				if (contextRequest.PreventInterceptors == false)
					OnQuerySettings(efContext, e = new BusinessRulesEventArgs<SDArea>() { Filter = filter, ContextRequest = contextRequest /*, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null)*/ });

				//List<SDArea> result = new List<SDArea>();
                 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }

}
		public List<SDArea> GetBy(Expression<Func<SDArea, bool>> predicate, bool loadRelations, ContextRequest contextRequest)
        {
			if(!loadRelations)
				return GetBy(predicate, contextRequest);
			else
				return GetBy(predicate, contextRequest, "SDArea1,SDAreaPersons");

        }

        public List<SDArea> GetBy(Expression<Func<SDArea, bool>> predicate, int? pageSize, int? page, string orderBy, SFSdotNet.Framework.Data.SortDirection? sortDirection)
        {
            return GetBy(predicate, new ContextRequest() { CustomQuery = new CustomQuery() { Page = page, PageSize = pageSize, OrderBy = orderBy, SortDirection = sortDirection } });
        }
        public List<SDArea> GetBy(Expression<Func<SDArea, bool>> predicate)
        {

			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
			contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
			            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            contextRequest.CustomQuery.FilterExpressionString = null;
            return this.GetBy(predicate, contextRequest, "");
        }
        #endregion
        #region Dynamic String
		protected override string GetSpecificFilter(string filter, ContextRequest contextRequest) {
            string result = "";
		    //string linqFilter = String.Empty;
            string freeTextFilter = String.Empty;
            if (filter.Contains("|"))
            {
               // linqFilter = filter.Split(char.Parse("|"))[0];
                freeTextFilter = filter.Split(char.Parse("|"))[1];
            }
            //else {
            //    freeTextFilter = filter;
            //}
            //else {
            //    linqFilter = filter;
            //}
			// linqFilter = SFSdotNet.Framework.Linq.Utils.ReplaceCustomDateFilters(linqFilter);
            //string specificFilter = linqFilter;
            if (!string.IsNullOrEmpty(freeTextFilter))
            {
                System.Text.StringBuilder sbCont = new System.Text.StringBuilder();
                /*if (specificFilter.Length > 0)
                {
                    sbCont.Append(" AND ");
                    sbCont.Append(" ({0})");
                }
                else
                {
                    sbCont.Append("{0}");
                }*/
                //var words = freeTextFilter.Split(char.Parse(" "));
				var word = freeTextFilter;
                System.Text.StringBuilder sbSpec = new System.Text.StringBuilder();
                 int nWords = 1;
				/*foreach (var word in words)
                {
					if (word.Length > 0){
                    if (sbSpec.Length > 0) sbSpec.Append(" AND ");
					if (words.Length > 1) sbSpec.Append("("); */
					
	
					
					
					
									
					sbSpec.Append(string.Format(@"Name.Contains(""{0}"")", word));
					

					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
								sbSpec.Append(" OR ");
					
					//if (sbSpec.Length > 2)
					//	sbSpec.Append(" OR "); // test
					sbSpec.Append(string.Format(@"it.SDArea2.Name.Contains(""{0}"")", word)+" OR "+string.Format(@"it.SDOrganization.FullName.Contains(""{0}"")", word));
								 //sbSpec.Append("*extraFreeText*");

                    /*if (words.Length > 1) sbSpec.Append(")");
					
					nWords++;

					}

                }*/
                //specificFilter = string.Format("{0}{1}", specificFilter, string.Format(sbCont.ToString(), sbSpec.ToString()));
                                 result = sbSpec.ToString();  
            }
			//result = specificFilter;
			
			return result;

		}
	
			public List<SDArea> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params object[] extraParams)
        {
			return GetBy(filter, pageSize, page, orderBy, orderDir,  null, extraParams);
		}
           public List<SDArea> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, string usemode, params object[] extraParams)
            { 
                return GetBy(filter, pageSize, page, orderBy, orderDir, usemode, null, extraParams);
            }


		public List<SDArea> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  string usemode, ContextRequest context, params object[] extraParams)

        {

            // string freetext = null;
            //if (filter.Contains("|"))
            //{
            //    int parts = filter.Split(char.Parse("|")).Count();
            //    if (parts > 1)
            //    {

            //        freetext = filter.Split(char.Parse("|"))[1];
            //    }
            //}
		
            //string specificFilter = "";
            //if (!string.IsNullOrEmpty(filter))
            //  specificFilter=  GetSpecificFilter(filter);
            if (string.IsNullOrEmpty(orderBy))
            {
			                orderBy = "UpdatedDate";
            }
			//orderDir = "desc";
			SFSdotNet.Framework.Data.SortDirection direction = SFSdotNet.Framework.Data.SortDirection.Ascending;
            if (!string.IsNullOrEmpty(orderDir))
            {
                if (orderDir == "desc")
                    direction = SFSdotNet.Framework.Data.SortDirection.Descending;
            }
            if (context == null)
                context = new ContextRequest();
			

             context.UseMode = usemode;
             if (context.CustomQuery == null )
                context.CustomQuery =new SFSdotNet.Framework.My.CustomQuery();

 
                context.CustomQuery.ExtraParams = extraParams;

                    context.CustomQuery.OrderBy = orderBy;
                   context.CustomQuery.SortDirection = direction;
                   context.CustomQuery.Page = page;
                  context.CustomQuery.PageSize = pageSize;
               

            

            if (!preventSecurityRestrictions) {
			 if (context.CurrentContext == null)
                {
					if (SFSdotNet.Framework.My.Context.CurrentContext != null &&  SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
					{
						context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
						context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

					}
					else {
						throw new Exception("The security rule require a specific user and company");
					}
				}
            }
            return GetBy(filter, context);
  
        }


        public List<SDArea> GetBy(string strWhere, ContextRequest contextRequest)
        {
        	#region old code
				
				 //Expression<Func<tvsReservationTransport, bool>> predicate = null;
				string strWhereClean = strWhere.Replace("*extraFreeText*", "").Replace("()", "");
                //if (!string.IsNullOrEmpty(strWhereClean)){

                //    object[] extraParams = null;
                //    //if (contextRequest != null )
                //    //    if (contextRequest.CustomQuery != null )
                //    //        extraParams = contextRequest.CustomQuery.ExtraParams;
                //    //predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<tvsReservationTransport, bool>(strWhereClean, extraParams != null? extraParams.Cast<Guid>(): null);				
                //}
				 if (contextRequest == null)
                {
                    contextRequest = new ContextRequest();
                    if (contextRequest.CustomQuery == null)
                        contextRequest.CustomQuery = new CustomQuery();
                }
                  if (!preventSecurityRestrictions) {
					if (contextRequest.User == null || contextRequest.Company == null)
                      {
                     if (SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
                     {
                         contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                         contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

                     }
                     else {
                         throw new Exception("The security rule require a specific User and Company ");
                     }
					 }
                 }
            contextRequest.CustomQuery.FilterExpressionString = strWhere;
				//return GetBy(predicate, contextRequest);  

			#endregion				
				
                    return GetBy(strWhere, contextRequest, "");  


        }
       public List<SDArea> GetBy(string strWhere)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
			
            return GetBy(strWhere, context, null);
        }

        public List<SDArea> GetBy(string strWhere, string includes)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
            return GetBy(strWhere, context, includes);
        }

        #endregion
        #endregion
		
		  #region SaveOrUpdate
        
 		 public SDArea Create(SDArea entity)
        {
				//ObjectContext context = null;
				    if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: Create");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

				return this.Create(entity, contextRequest);


        }
        
       
        public SDArea Create(SDArea entity, ContextRequest contextRequest)
        {
		
		bool graph = false;
	
				bool preventPartial = false;
                if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
               
			using (EFContext con = new EFContext()) {

				SDArea itemForSave = new SDArea();
#region Autos
		if(!preventSecurityRestrictions){

				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion
               BusinessRulesEventArgs<SDArea> e = null;
			    if (preventPartial == false )
                OnCreating(this,e = new BusinessRulesEventArgs<SDArea>() { ContextRequest = contextRequest, Item=entity });
				   if (e != null) {
						if (e.Cancel)
						{
							context = null;
							return e.Item;

						}
					}

                    if (entity.GuidArea == Guid.Empty)
                   {
                       entity.GuidArea = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   itemForSave.GuidArea = entity.GuidArea;
				  
		
			itemForSave.GuidArea = entity.GuidArea;

			itemForSave.Name = entity.Name;

			itemForSave.GuidCompany = entity.GuidCompany;

			itemForSave.CreatedDate = entity.CreatedDate;

			itemForSave.UpdatedDate = entity.UpdatedDate;

			itemForSave.CreatedBy = entity.CreatedBy;

			itemForSave.UpdatedBy = entity.UpdatedBy;

			itemForSave.Bytes = entity.Bytes;

			itemForSave.IsDeleted = entity.IsDeleted;

				
				con.SDAreas.Add(itemForSave);





					if (entity.SDArea2 != null)
					{
						var sDArea = new SDArea();
						sDArea.GuidArea = entity.SDArea2.GuidArea;
						itemForSave.SDArea2 = sDArea;
						SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDArea>(con, itemForSave.SDArea2);
			
					}




					if (entity.SDOrganization != null)
					{
						var sDOrganization = new SDOrganization();
						sDOrganization.GuidOrganization = entity.SDOrganization.GuidOrganization;
						itemForSave.SDOrganization = sDOrganization;
						SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDOrganization>(con, itemForSave.SDOrganization);
			
					}





                
				con.ChangeTracker.Entries().Where(p => p.Entity != itemForSave && p.State != EntityState.Unchanged).ForEach(p => p.State = EntityState.Detached);

				con.Entry<SDArea>(itemForSave).State = EntityState.Added;

				con.SaveChanges();

					 
				

				//itemResult = entity;
                //if (e != null)
                //{
                 //   e.Item = itemResult;
                //}
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false )
                OnCreated(this, e == null ? e = new BusinessRulesEventArgs<SDArea>() { ContextRequest = contextRequest, Item = entity } : e);



                if (e != null && e.Item != null )
                {
                    return e.Item;
                }
                              return entity;
			}
            
        }
        //BusinessRulesEventArgs<SDArea> e = null;
        public void Create(List<SDArea> entities)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            Create(entities, contextRequest);
        }
        public void Create(List<SDArea> entities, ContextRequest contextRequest)
        
        {
			ObjectContext context = null;
            	foreach (SDArea entity in entities)
				{
					this.Create(entity, contextRequest);
				}
        }
		  public void CreateOrUpdateBulk(List<SDArea> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "cu", contextRequest);
        }

        private void CreateOrUpdateBulk(List<SDArea> entities, string actionKey, ContextRequest contextRequest)
        {
			if (entities.Count() > 0){
            bool graph = false;

            bool preventPartial = false;
            if (contextRequest != null && contextRequest.PreventInterceptors == true)
            {
                preventPartial = true;
            }
            foreach (var entity in entities)
            {
                    if (entity.GuidArea == Guid.Empty)
                   {
                       entity.GuidArea = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   
				  


#region Autos
		if(!preventSecurityRestrictions){


 if (actionKey != "u")
                        {
				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;


}
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion


		
			//entity.GuidArea = entity.GuidArea;

			//entity.Name = entity.Name;

			//entity.GuidCompany = entity.GuidCompany;

			//entity.CreatedDate = entity.CreatedDate;

			//entity.UpdatedDate = entity.UpdatedDate;

			//entity.CreatedBy = entity.CreatedBy;

			//entity.UpdatedBy = entity.UpdatedBy;

			//entity.Bytes = entity.Bytes;

			//entity.IsDeleted = entity.IsDeleted;

				
				





				    if (entity.SDArea2 != null)
					{
						//var sDArea = new SDArea();
						entity.GuidAreaParent = entity.SDArea2.GuidArea;
						//entity.SDArea2 = sDArea;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDArea>(con, itemForSave.SDArea2);
			
					}




				    if (entity.SDOrganization != null)
					{
						//var sDOrganization = new SDOrganization();
						entity.GuidOrganization = entity.SDOrganization.GuidOrganization;
						//entity.SDOrganization = sDOrganization;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDOrganization>(con, itemForSave.SDOrganization);
			
					}





                
				

					 
				

				//itemResult = entity;
            }
            using (EFContext con = new EFContext())
            {
                 if (actionKey == "c")
                    {
                        context.BulkInsert(entities);
                    }else if ( actionKey == "u")
                    {
                        context.BulkUpdate(entities);
                    }else
                    {
                        context.BulkInsertOrUpdate(entities);
                    }
            }

			}
        }
	
		public void CreateBulk(List<SDArea> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "c", contextRequest);
        }


		public void UpdateAgile(SDArea item, params string[] fields)
         {
			UpdateAgile(item, null, fields);
        }
		public void UpdateAgile(SDArea item, ContextRequest contextRequest, params string[] fields)
         {
            
             ContextRequest contextNew = null;
             if (contextRequest != null)
             {
                 contextNew = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
                 if (fields != null && fields.Length > 0)
                 {
                     contextNew.CustomQuery.SpecificProperties  = fields.ToList();
                 }
                 else if(contextRequest.CustomQuery.SpecificProperties.Count > 0)
                 {
                     fields = contextRequest.CustomQuery.SpecificProperties.ToArray();
                 }
             }
			

		   using (EFContext con = new EFContext())
            {



               
					List<string> propForCopy = new List<string>();
                    propForCopy.AddRange(fields);
                    
					  
					if (!propForCopy.Contains("GuidArea"))
						propForCopy.Add("GuidArea");
					if (!propForCopy.Contains("Name"))
						propForCopy.Add("Name");

					var itemForUpdate = SFSdotNet.Framework.BR.Utils.GetConverted<SDArea,SDArea>(item, propForCopy.ToArray());
					 itemForUpdate.GuidArea = item.GuidArea;
                  var setT = con.Set<SDArea>().Attach(itemForUpdate);

					if (fields.Count() > 0)
					  {
						  item.ModifiedProperties = fields;
					  }
                    foreach (var property in item.ModifiedProperties)
					{						
                        if (property != "GuidArea")
                             con.Entry(setT).Property(property).IsModified = true;

                    }

                
               int result = con.SaveChanges();
               if (result != 1)
               {
                   SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: 1");
               }


            }

			OnUpdatedAgile(this, new BusinessRulesEventArgs<SDArea>() { Item = item, ContextRequest = contextNew  });

         }
		public void UpdateBulk(List<SDArea>  items, params string[] fields)
         {
             SFSdotNet.Framework.My.ContextRequest req = new SFSdotNet.Framework.My.ContextRequest();
             req.CustomQuery = new SFSdotNet.Framework.My.CustomQuery();
             foreach (var field in fields)
             {
                 req.CustomQuery.SpecificProperties.Add(field);
             }
             UpdateBulk(items, req);

         }

		 public void DeleteBulk(List<SDArea> entities, ContextRequest contextRequest = null)
        {

            using (EFContext con = new EFContext())
            {
                foreach (var entity in entities)
                {
					var entityProxy = new SDArea() { GuidArea = entity.GuidArea };

                    con.Entry<SDArea>(entityProxy).State = EntityState.Deleted;

                }

                int result = con.SaveChanges();
                if (result != entities.Count)
                {
                    SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: " + entities.Count.ToString());
                }
            }

        }

        public void UpdateBulk(List<SDArea> items, ContextRequest contextRequest)
        {
            if (items.Count() > 0){

			 foreach (var entity in items)
            {


#region Autos
		if(!preventSecurityRestrictions){

				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	



			}
#endregion






				    if (entity.SDArea2 != null)
					{
						//var sDArea = new SDArea();
						entity.GuidAreaParent = entity.SDArea2.GuidArea;
						//entity.SDArea2 = sDArea;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDArea>(con, itemForSave.SDArea2);
			
					}




				    if (entity.SDOrganization != null)
					{
						//var sDOrganization = new SDOrganization();
						entity.GuidOrganization = entity.SDOrganization.GuidOrganization;
						//entity.SDOrganization = sDOrganization;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDOrganization>(con, itemForSave.SDOrganization);
			
					}





				}
				using (EFContext con = new EFContext())
				{

                    
                
                   con.BulkUpdate(items);

				}
             
			}	  
        }

         public SDArea Update(SDArea entity)
        {
            if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return Update(entity, contextRequest);
        }
       
         public SDArea Update(SDArea entity, ContextRequest contextRequest)
        {
		 if ((System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null) && contextRequest == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Update");
            }
            if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            }

			
				SDArea  itemResult = null;

	
			//entity.UpdatedDate = DateTime.Now.ToUniversalTime();
			//if(contextRequest.User != null)
				//entity.UpdatedBy = contextRequest.User.GuidUser;

//	    var oldentity = GetBy(p => p.GuidArea == entity.GuidArea, contextRequest).FirstOrDefault();
	//	if (oldentity != null) {
		
          //  entity.CreatedDate = oldentity.CreatedDate;
    //        entity.CreatedBy = oldentity.CreatedBy;
	
      //      entity.GuidCompany = oldentity.GuidCompany;
	
			

	
		//}

			 using( EFContext con = new EFContext()){
				BusinessRulesEventArgs<SDArea> e = null;
				bool preventPartial = false; 
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false)
                OnUpdating(this,e = new BusinessRulesEventArgs<SDArea>() { ContextRequest = contextRequest, Item=entity});
				   if (e != null) {
						if (e.Cancel)
						{
							//outcontext = null;
							return e.Item;

						}
					}

	string includes = "SDArea2,SDOrganization";
	IQueryable < SDArea > query = con.SDAreas.AsQueryable();
	foreach (string include in includes.Split(char.Parse(",")))
                       {
                           if (!string.IsNullOrEmpty(include))
                               query = query.Include(include);
                       }
	var oldentity = query.FirstOrDefault(p => p.GuidArea == entity.GuidArea);
	if (oldentity.Name != entity.Name)
		oldentity.Name = entity.Name;

				//if (entity.UpdatedDate == null || (contextRequest != null && contextRequest.IsFromUI("SDAreas", UIActions.Updating)))
			oldentity.UpdatedDate = DateTime.Now.ToUniversalTime();
			if(contextRequest.User != null)
				oldentity.UpdatedBy = contextRequest.User.GuidUser;

           


				if (entity.SDArea1 != null)
                {
                    foreach (var item in entity.SDArea1)
                    {


                        
                    }
					
                    

                }


						if (SFSdotNet.Framework.BR.Utils.HasRelationPropertyChanged(oldentity.SDArea2, entity.SDArea2, "GuidArea"))
							oldentity.SDArea2 = entity.SDArea2 != null? new SDArea(){ GuidArea = entity.SDArea2.GuidArea } :null;

                


						if (SFSdotNet.Framework.BR.Utils.HasRelationPropertyChanged(oldentity.SDOrganization, entity.SDOrganization, "GuidOrganization"))
							oldentity.SDOrganization = entity.SDOrganization != null? new SDOrganization(){ GuidOrganization = entity.SDOrganization.GuidOrganization } :null;

                


				if (entity.SDAreaPersons != null)
                {
                    foreach (var item in entity.SDAreaPersons)
                    {


                        
                    }
					
                    

                }


				con.ChangeTracker.Entries().Where(p => p.Entity != oldentity).ForEach(p => p.State = EntityState.Unchanged);  
				  
				con.SaveChanges();
        
					 
					
               
				itemResult = entity;
				if(preventPartial == false)
					OnUpdated(this, e = new BusinessRulesEventArgs<SDArea>() { ContextRequest = contextRequest, Item=itemResult });

              	return itemResult;
			}
			  
        }
        public SDArea Save(SDArea entity)
        {
			return Create(entity);
        }
        public int Save(List<SDArea> entities)
        {
			 Create(entities);
            return entities.Count;

        }
        #endregion
        #region Delete
        public void Delete(SDArea entity)
        {
				this.Delete(entity, null);
			
        }
		 public void Delete(SDArea entity, ContextRequest contextRequest)
        {
				
				  List<SDArea> entities = new List<SDArea>();
				   entities.Add(entity);
				this.Delete(entities, contextRequest);
			
        }

         public void Delete(string query, Guid[] guids, ContextRequest contextRequest)
        {
			var br = new SDAreasBR(true);
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);
            
            Delete(items, contextRequest);

        }
        public void Delete(SDArea entity,  ContextRequest contextRequest, BusinessRulesEventArgs<SDArea> e = null)
        {
			
				using(EFContext con = new EFContext())
                 {
				
               	BusinessRulesEventArgs<SDArea> _e = null;
               List<SDArea> _items = new List<SDArea>();
                _items.Add(entity);
                if (e == null || e.PreventPartialPropagate == false)
                {
                    OnDeleting(this, _e = (e == null ? new BusinessRulesEventArgs<SDArea>() { ContextRequest = contextRequest, Item = entity, Items = null  } : e));
                }
                if (_e != null)
                {
                    if (_e.Cancel)
						{
							context = null;
							return;

						}
					}


				
									//IsDeleted
					bool logicDelete = true;
					if (entity.IsDeleted != null)
					{
						if (entity.IsDeleted.Value)
							logicDelete = false;
					}
					if (logicDelete)
					{
											//entity = GetBy(p =>, contextRequest).FirstOrDefault();
						entity.IsDeleted = true;
						if (contextRequest != null && contextRequest.User != null)
							entity.UpdatedBy = contextRequest.User.GuidUser;
                        entity.UpdatedDate = DateTime.UtcNow;
						UpdateAgile(entity, "IsDeleted","UpdatedBy","UpdatedDate");

						
					}
					else {
					con.Entry<SDArea>(entity).State = EntityState.Deleted;
					con.SaveChanges();
				
				 
					}
								
				
				 
					
					
			if (e == null || e.PreventPartialPropagate == false)
                {

                    if (_e == null)
                        _e = new BusinessRulesEventArgs<SDArea>() { ContextRequest = contextRequest, Item = entity, Items = null };

                    OnDeleted(this, _e);
                }

				//return null;
			}
        }
 public void UnDelete(string query, Guid[] guids, ContextRequest contextRequest)
        {
            var br = new SDAreasBR(true);
            contextRequest.CustomQuery.IncludeDeleted = true;
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);

            foreach (var item in items)
            {
                item.IsDeleted = false;
						if (contextRequest != null && contextRequest.User != null)
							item.UpdatedBy = contextRequest.User.GuidUser;
                        item.UpdatedDate = DateTime.UtcNow;
            }

            UpdateBulk(items, "IsDeleted","UpdatedBy","UpdatedDate");
        }

         public void Delete(List<SDArea> entities,  ContextRequest contextRequest = null )
        {
				
			 BusinessRulesEventArgs<SDArea> _e = null;

                OnDeleting(this, _e = new BusinessRulesEventArgs<SDArea>() { ContextRequest = contextRequest, Item = null, Items = entities });
                if (_e != null)
                {
                    if (_e.Cancel)
                    {
                        context = null;
                        return;

                    }
                }
                bool allSucced = true;
                BusinessRulesEventArgs<SDArea> eToChilds = new BusinessRulesEventArgs<SDArea>();
                if (_e != null)
                {
                    eToChilds = _e;
                }
                else
                {
                    eToChilds = new BusinessRulesEventArgs<SDArea>() { ContextRequest = contextRequest, Item = (entities.Count == 1 ? entities[0] : null), Items = entities };
                }
				foreach (SDArea item in entities)
				{
					try
                    {
                        this.Delete(item, contextRequest, e: eToChilds);
                    }
                    catch (Exception ex)
                    {
                        SFSdotNet.Framework.My.EventLog.Error(ex);
                        allSucced = false;
                    }
				}
				if (_e == null)
                    _e = new BusinessRulesEventArgs<SDArea>() { ContextRequest = contextRequest, CountResult = entities.Count, Item = null, Items = entities };
                OnDeleted(this, _e);

			
        }
        #endregion
 
        #region GetCount
		 public int GetCount(Expression<Func<SDArea, bool>> predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

			return GetCount(predicate, contextRequest);
		}
        public int GetCount(Expression<Func<SDArea, bool>> predicate, ContextRequest contextRequest)
        {


		
		 using (EFContext con = new EFContext())
            {


				if (predicate == null) predicate = PredicateBuilder.True<SDArea>();
           		predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted == null);
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    		if (contextRequest.User !=null )
                        		if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
									predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa

								}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				
				IQueryable<SDArea> query = con.SDAreas.AsQueryable();
                return query.AsExpandable().Count(predicate);

			
				}
			

        }
		  public int GetCount(string predicate,  ContextRequest contextRequest)
         {
             return GetCount(predicate, null, contextRequest);
         }

         public int GetCount(string predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return GetCount(predicate, contextRequest);
        }
		 public int GetCount(string predicate, string usemode){
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
				return GetCount( predicate,  usemode,  contextRequest);
		 }
        public int GetCount(string predicate, string usemode, ContextRequest contextRequest){

		using (EFContext con = new EFContext()) {
				string computedFields = "";
				string fkIncludes = "SDArea2,SDOrganization";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDArea>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetCount(con, predicate, usemode, contextRequest, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields);

			}
			#region old code
			 /* string freetext = null;
            Filter filter = new Filter();

              if (predicate.Contains("|"))
              {
                 
                  filter.SetFilterPart("ft", GetSpecificFilter(predicate, contextRequest));
                 
                  filter.ProcessText(predicate.Split(char.Parse("|"))[0]);
                  freetext = predicate.Split(char.Parse("|"))[1];

				  if (!string.IsNullOrEmpty(freetext) && string.IsNullOrEmpty(contextRequest.FreeText))
                  {
                      contextRequest.FreeText = freetext;
                  }
              }
              else {
                  filter.ProcessText(predicate);
              }
			   predicate = filter.GetFilterComplete();
			// BusinessRulesEventArgs<SDArea>  e = null;
           	using (EFContext con = new EFContext())
			{
			
			

			 QueryBuild(predicate, filter, con, contextRequest, "count", new List<string>());


			
			BusinessRulesEventArgs<SDArea> e = null;

			contextRequest.FreeText = freetext;
			contextRequest.UseMode = usemode;
            OnCounting(this, e = new BusinessRulesEventArgs<SDArea>() {  Filter =filter, ContextRequest = contextRequest });
            if (e != null)
            {
                if (e.Cancel)
                {
                    context = null;
                    return e.CountResult;

                }

            

            }
			
			StringBuilder sbQuerySystem = new StringBuilder();
		
					
                    filter.SetFilterPart("de","(IsDeleted != true OR IsDeleted == null)");
			
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    	if (contextRequest.User !=null )
                        	if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
                        		
								filter.SetFilterPart("co", @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa
						
						
							}
							
							}
							if (preventSecurityRestrictions) preventSecurityRestrictions= false;
		
				   
                 filter.CleanAndProcess("");
				//string predicateWithFKAndComputed = SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicate );               
				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed();
               string predicateWithManyRelations = filter.GetFilterChildren();
			   ///QueryUtils.BreakeQuery1(predicate, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
			   predicate = filter.GetFilterComplete();
               if (!string.IsNullOrEmpty(predicate))
               {
				
					
                    return con.SDAreas.Where(predicate).Count();
					
                }else
                    return con.SDAreas.Count();
					
			}*/
			#endregion

		}
         public int GetCount()
        {
            return GetCount(p => true);
        }
        #endregion
        
         


        public void Delete(List<SDArea.CompositeKey> entityKeys)
        {

            List<SDArea> items = new List<SDArea>();
            foreach (var itemKey in entityKeys)
            {
                items.Add(GetByKey(itemKey.GuidArea));
            }

            Delete(items);

        }
		 public void UpdateAssociation(string relation, string relationValue, string query, Guid[] ids, ContextRequest contextRequest)
        {
            var items = GetBy(query, null, null, null, null, null, contextRequest, ids);
			 var module = SFSdotNet.Framework.Cache.Caching.SystemObjects.GetModuleByKey(SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(System.Web.HttpContext.Current.Request.RequestContext, "area"));
           
            foreach (var item in items)
            {
			  Guid ? guidRelationValue = null ;
                if (!string.IsNullOrEmpty(relationValue)){
                    guidRelationValue = Guid.Parse(relationValue );
                }

				 if (relation.Contains("."))
                {
                    var partsWithOtherProp = relation.Split(char.Parse("|"));
                    var parts = partsWithOtherProp[0].Split(char.Parse("."));

                    string proxyRelName = parts[0];
                    string proxyProperty = parts[1];
                    string proxyPropertyKeyNameFromOther = partsWithOtherProp[1];
                    //string proxyPropertyThis = parts[2];

                    var prop = item.GetType().GetProperty(proxyRelName);
                    //var entityInfo = //SFSdotNet.Framework.
                    // descubrir el tipo de entidad dentro de la colección
                    Type typeEntityInList = SFSdotNet.Framework.Entities.Utils.GetTypeFromList(prop);
                    var newProxyItem = Activator.CreateInstance(typeEntityInList);
                    var propThisForSet = newProxyItem.GetType().GetProperty(proxyProperty);
                    var entityInfoOfProxy = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(typeEntityInList);
                    var propOther = newProxyItem.GetType().GetProperty(proxyPropertyKeyNameFromOther);

                    if (propThisForSet != null && entityInfoOfProxy != null && propOther != null )
                    {
                        var entityInfoThis = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(item.GetType());
                        var valueThisId = item.GetType().GetProperty(entityInfoThis.PropertyKeyName).GetValue(item);
                        if (valueThisId != null)
                            propThisForSet.SetValue(newProxyItem, valueThisId);
                        propOther.SetValue(newProxyItem, Guid.Parse(relationValue));
                        
                        var entityNameProp = newProxyItem.GetType().GetField("EntityName").GetValue(null);
                        var entitySetNameProp = newProxyItem.GetType().GetField("EntitySetName").GetValue(null);

                        SFSdotNet.Framework.Apps.Integration.CreateItemFromApp(entityNameProp.ToString(), entitySetNameProp.ToString(), module.ModuleNamespace, newProxyItem, contextRequest);

                    }

                    // crear una instancia del tipo de entidad
                    // llenar los datos y registrar nuevo


                }
                else
                {
                var prop = item.GetType().GetProperty(relation);
                var entityInfo = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(prop.PropertyType);
                if (entityInfo != null)
                {
                    var ins = Activator.CreateInstance(prop.PropertyType);
                   if (guidRelationValue != null)
                    {
                        prop.PropertyType.GetProperty(entityInfo.PropertyKeyName).SetValue(ins, guidRelationValue);
                        item.GetType().GetProperty(relation).SetValue(item, ins);
                    }
                    else
                    {
                        item.GetType().GetProperty(relation).SetValue(item, null);
                    }

                    Update(item, contextRequest);
                }

				}
            }
        }
		
	}
		public partial class SDAreaPersonsBR:BRBase<SDAreaPerson>{
	 	
           
		 #region Partial methods

           partial void OnUpdating(object sender, BusinessRulesEventArgs<SDAreaPerson> e);

            partial void OnUpdated(object sender, BusinessRulesEventArgs<SDAreaPerson> e);
			partial void OnUpdatedAgile(object sender, BusinessRulesEventArgs<SDAreaPerson> e);

            partial void OnCreating(object sender, BusinessRulesEventArgs<SDAreaPerson> e);
            partial void OnCreated(object sender, BusinessRulesEventArgs<SDAreaPerson> e);

            partial void OnDeleting(object sender, BusinessRulesEventArgs<SDAreaPerson> e);
            partial void OnDeleted(object sender, BusinessRulesEventArgs<SDAreaPerson> e);

            partial void OnGetting(object sender, BusinessRulesEventArgs<SDAreaPerson> e);
            protected override void OnVirtualGetting(object sender, BusinessRulesEventArgs<SDAreaPerson> e)
            {
                OnGetting(sender, e);
            }
			protected override void OnVirtualCounting(object sender, BusinessRulesEventArgs<SDAreaPerson> e)
            {
                OnCounting(sender, e);
            }
			partial void OnTaken(object sender, BusinessRulesEventArgs<SDAreaPerson> e);
			protected override void OnVirtualTaken(object sender, BusinessRulesEventArgs<SDAreaPerson> e)
            {
                OnTaken(sender, e);
            }

            partial void OnCounting(object sender, BusinessRulesEventArgs<SDAreaPerson> e);
 
			partial void OnQuerySettings(object sender, BusinessRulesEventArgs<SDAreaPerson> e);
          
            #endregion
			
		private static SDAreaPersonsBR singlenton =null;
				public static SDAreaPersonsBR NewInstance(){
					return  new SDAreaPersonsBR();
					
				}
		public static SDAreaPersonsBR Instance{
			get{
				if (singlenton == null)
					singlenton = new SDAreaPersonsBR();
				return singlenton;
			}
		}
		//private bool preventSecurityRestrictions = false;
		 public bool PreventAuditTrail { get; set;  }
		#region Fields
        EFContext context = null;
        #endregion
        #region Constructor
        public SDAreaPersonsBR()
        {
            context = new EFContext();
        }
		 public SDAreaPersonsBR(bool preventSecurity)
            {
                this.preventSecurityRestrictions = preventSecurity;
				context = new EFContext();
            }
        #endregion
		
		#region Get

 		public IQueryable<SDAreaPerson> Get()
        {
            using (EFContext con = new EFContext())
            {
				
				var query = con.SDAreaPersons.AsQueryable();
                con.Configuration.ProxyCreationEnabled = false;

                //query = ContextQueryBuilder<Nutrient>.ApplyContextQuery(query, contextRequest);

                return query;




            }

        }
		


 	
		public List<SDAreaPerson> GetAll()
        {
            return this.GetBy(p => true);
        }
        public List<SDAreaPerson> GetAll(string includes)
        {
            return this.GetBy(p => true, includes);
        }
        public SDAreaPerson GetByKey(Guid guidAreaPerson)
        {
            return GetByKey(guidAreaPerson, true);
        }
        public SDAreaPerson GetByKey(Guid guidAreaPerson, bool loadIncludes)
        {
            SDAreaPerson item = null;
			var query = PredicateBuilder.True<SDAreaPerson>();
                    
			string strWhere = @"GuidAreaPerson = Guid(""" + guidAreaPerson.ToString()+@""")";
            Expression<Func<SDAreaPerson, bool>> predicate = null;
            //if (!string.IsNullOrEmpty(strWhere))
            //    predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDAreaPerson, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
			 ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
            contextRequest.CustomQuery.FilterExpressionString = strWhere;

			//item = GetBy(predicate, loadIncludes, contextRequest).FirstOrDefault();
			item = GetBy(strWhere,loadIncludes,contextRequest).FirstOrDefault();
            return item;
        }
         public List<SDAreaPerson> GetBy(string strWhere, bool loadRelations, ContextRequest contextRequest)
        {
            if (!loadRelations)
                return GetBy(strWhere, contextRequest);
            else
                return GetBy(strWhere, contextRequest, "");

        }
		  public List<SDAreaPerson> GetBy(string strWhere, bool loadRelations)
        {
              if (!loadRelations)
                return GetBy(strWhere, new ContextRequest());
            else
                return GetBy(strWhere, new ContextRequest(), "");

        }
		         public SDAreaPerson GetByKey(Guid guidAreaPerson, params Expression<Func<SDAreaPerson, object>>[] includes)
        {
            SDAreaPerson item = null;
			string strWhere = @"GuidAreaPerson = Guid(""" + guidAreaPerson.ToString()+@""")";
          Expression<Func<SDAreaPerson, bool>> predicate = p=> p.GuidAreaPerson == guidAreaPerson;
           // if (!string.IsNullOrEmpty(strWhere))
           //     predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDAreaPerson, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
        item = GetBy(predicate, includes).FirstOrDefault();
         ////   item = GetBy(strWhere,includes).FirstOrDefault();
			return item;

        }
        public SDAreaPerson GetByKey(Guid guidAreaPerson, string includes)
        {
            SDAreaPerson item = null;
			string strWhere = @"GuidAreaPerson = Guid(""" + guidAreaPerson.ToString()+@""")";
            
			
            item = GetBy(strWhere, includes).FirstOrDefault();
            return item;

        }
		 public SDAreaPerson GetByKey(Guid guidAreaPerson, string usemode, string includes)
		{
			return GetByKey(guidAreaPerson, usemode, null, includes);

		 }
		 public SDAreaPerson GetByKey(Guid guidAreaPerson, string usemode, ContextRequest context,  string includes)
        {
            SDAreaPerson item = null;
			string strWhere = @"GuidAreaPerson = Guid(""" + guidAreaPerson.ToString()+@""")";
			if (context == null){
				context = new ContextRequest();
				context.CustomQuery = new CustomQuery();
				context.CustomQuery.IsByKey = true;
				context.CustomQuery.FilterExpressionString = strWhere;
				context.UseMode = usemode;
			}
            item = GetBy(strWhere,context , includes).FirstOrDefault();
            return item;

        }

        #region Dynamic Predicate
        public List<SDAreaPerson> GetBy(Expression<Func<SDAreaPerson, bool>> predicate, int? pageSize, int? page)
        {
            return this.GetBy(predicate, pageSize, page, null, null);
        }
        public List<SDAreaPerson> GetBy(Expression<Func<SDAreaPerson, bool>> predicate, ContextRequest contextRequest)
        {

            return GetBy(predicate, contextRequest,"");
        }
        
        public List<SDAreaPerson> GetBy(Expression<Func<SDAreaPerson, bool>> predicate, ContextRequest contextRequest, params Expression<Func<SDAreaPerson, object>>[] includes)
        {
            StringBuilder sb = new StringBuilder();
           if (includes != null)
            {
                foreach (var path in includes)
                {

						if (sb.Length > 0) sb.Append(",");
						sb.Append(SFSdotNet.Framework.Linq.Utils.IncludeToString<SDAreaPerson>(path));

               }
            }
            return GetBy(predicate, contextRequest, sb.ToString());
        }
        
        
        public List<SDAreaPerson> GetBy(Expression<Func<SDAreaPerson, bool>> predicate, string includes)
        {
			ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";

            return GetBy(predicate, context, includes);
        }

        public List<SDAreaPerson> GetBy(Expression<Func<SDAreaPerson, bool>> predicate, params Expression<Func<SDAreaPerson, object>>[] includes)
        {
			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest context = new ContextRequest();
			            context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";
            return GetBy(predicate, context, includes);
        }

      
		public bool DisableCache { get; set; }
		public List<SDAreaPerson> GetBy(Expression<Func<SDAreaPerson, bool>> predicate, ContextRequest contextRequest, string includes)
		{
            using (EFContext con = new EFContext()) {
				
				string fkIncludes = "SDArea,SDPerson";
                List<string> multilangProperties = new List<string>();
				if (predicate == null) predicate = PredicateBuilder.True<SDAreaPerson>();
                var notDeletedExpression = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;
					Expression<Func<SDAreaPerson,bool>> multitenantExpression  = null;
					if (contextRequest != null && contextRequest.Company != null)	                        	
						multitenantExpression = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicate, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression);

#region Old code
/*
				List<SDAreaPerson> result = null;
               BusinessRulesEventArgs<SDAreaPerson>  e = null;
	
				OnGetting(con, e = new BusinessRulesEventArgs<SDAreaPerson>() {  FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null) });

               // OnGetting(con,e = new BusinessRulesEventArgs<SDAreaPerson>() { FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = contextRequest.CustomQuery.FilterExpressionString});
				   if (e != null) {
				    predicate = e.FilterExpression;
						if (e.Cancel)
						{
							context = null;
							 if (e.Items == null) e.Items = new List<SDAreaPerson>();
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                if (predicate == null) predicate = PredicateBuilder.True<SDAreaPerson>();
 				string fkIncludes = "SDArea,SDPerson";
                if(contextRequest!=null){
					if (contextRequest.CustomQuery != null)
					{
						if (contextRequest.CustomQuery.IncludeForeignKeyPaths != null) {
							if (contextRequest.CustomQuery.IncludeForeignKeyPaths.Value == false)
								fkIncludes = "";
						}
					}
				}
				if (!string.IsNullOrEmpty(includes))
					includes = includes + "," + fkIncludes;
				else
					includes = fkIncludes;
                
                //var es = _repository.Queryable;

                IQueryable<SDAreaPerson> query =  con.SDAreaPersons.AsQueryable();

                                if (!string.IsNullOrEmpty(includes))
                {
                    foreach (string include in includes.Split(char.Parse(",")))
                    {
						if (!string.IsNullOrEmpty(include))
                            query = query.Include(include);
                    }
                }
                    predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
					 	if (!preventSecurityRestrictions)
						{
							if (contextRequest != null )
		                    	if (contextRequest.User !=null )
		                        	if (contextRequest.Company != null){
		                        	
										predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
 									
									}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				query =query.AsExpandable().Where(predicate);
                query = ContextQueryBuilder<SDAreaPerson>.ApplyContextQuery(query, contextRequest);

                result = query.AsNoTracking().ToList<SDAreaPerson>();
				  
                if (e != null)
                {
                    e.Items = result;
                }
				//if (contextRequest != null ){
				//	 contextRequest = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
					contextRequest.CustomQuery = new CustomQuery();

				//}
				OnTaken(this, e == null ? e =  new BusinessRulesEventArgs<SDAreaPerson>() { Items= result, IncludingComputedLinq = false, ContextRequest = contextRequest,  FilterExpression = predicate } :  e);
  
			

                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
				*/
#endregion
            }
        }


		/*public int Update(List<SDAreaPerson> items, ContextRequest contextRequest)
            {
                int result = 0;
                using (EFContext con = new EFContext())
                {
                   
                

                    foreach (var item in items)
                    {
                        //secMessageToUser messageToUser = new secMessageToUser();
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            item.GetType().GetProperty(prop).SetValue(item, item.GetType().GetProperty(prop).GetValue(item));
                        }
                        //messageToUser.GuidMessageToUser = (Guid)item.GetType().GetProperty("GuidMessageToUser").GetValue(item);

                        var setObject = con.CreateObjectSet<SDAreaPerson>("SDAreaPersons");
                        //messageToUser.Readed = DateTime.UtcNow;
                        setObject.Attach(item);
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            con.ObjectStateManager.GetObjectStateEntry(item).SetModifiedProperty(prop);
                        }
                       
                    }
                    result = con.SaveChanges();

                    


                }
                return result;
            }
           */
		

        public List<SDAreaPerson> GetBy(string predicateString, ContextRequest contextRequest, string includes)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
				


				string computedFields = "";
				string fkIncludes = "SDArea,SDPerson";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDAreaPerson>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					//if (contextRequest != null && contextRequest.Company != null)                      	
					//	 multitenantExpression = @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))";
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicateString, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression,computedFields);


	#region Old Code
	/*
				BusinessRulesEventArgs<SDAreaPerson> e = null;

				Filter filter = new Filter();
                if (predicateString.Contains("|"))
                {
                    string ft = GetSpecificFilter(predicateString, contextRequest);
                    if (!string.IsNullOrEmpty(ft))
                        filter.SetFilterPart("ft", ft);
                   
                    contextRequest.FreeText = predicateString.Split(char.Parse("|"))[1];
                    var q1 = predicateString.Split(char.Parse("|"))[0];
                    if (!string.IsNullOrEmpty(q1))
                    {
                        filter.ProcessText(q1);
                    }
                }
                else {
                    filter.ProcessText(predicateString);
                }
				 var includesList = (new List<string>());
                 if (!string.IsNullOrEmpty(includes))
                 {
                     includesList = includes.Split(char.Parse(",")).ToList();
                 }

				List<SDAreaPerson> result = new List<SDAreaPerson>();
         
			QueryBuild(predicateString, filter, con, contextRequest, "getby", includesList);
			 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }
				
				
					OnGetting(con, e == null ? e = new BusinessRulesEventArgs<SDAreaPerson>() { Filter = filter, ContextRequest = contextRequest  } : e );

                  //OnGetting(con,e = new BusinessRulesEventArgs<SDAreaPerson>() {  ContextRequest = contextRequest, FilterExpressionString = predicateString });
			   	if (e != null) {
				    //predicateString = e.GetQueryString();
						if (e.Cancel)
						{
							context = null;
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				//	 else {
                //      predicateString = predicateString.Replace("*extraFreeText*", "").Replace("()","");
                //  }
				//con.EnableChangeTrackingUsingProxies = false;
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                //if (predicate == null) predicate = PredicateBuilder.True<SDAreaPerson>();
 				string fkIncludes = "SDArea,SDPerson";
                if(contextRequest!=null){
					if (contextRequest.CustomQuery != null)
					{
						if (contextRequest.CustomQuery.IncludeForeignKeyPaths != null) {
							if (contextRequest.CustomQuery.IncludeForeignKeyPaths.Value == false)
								fkIncludes = "";
						}
					}
				}else{
                    contextRequest = new ContextRequest();
                    contextRequest.CustomQuery = new CustomQuery();

                }
				if (!string.IsNullOrEmpty(includes))
					includes = includes + "," + fkIncludes;
				else
					includes = fkIncludes;
                
                //var es = _repository.Queryable;
				IQueryable<SDAreaPerson> query = con.SDAreaPersons.AsQueryable();
		
				// include relations FK
				if(string.IsNullOrEmpty(includes) ){
					includes ="";
				}
				StringBuilder sbQuerySystem = new StringBuilder();
                    //predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				

				//if (!string.IsNullOrEmpty(predicateString))
                //      sbQuerySystem.Append(" And ");
                //sbQuerySystem.Append(" (IsDeleted != true Or IsDeleted = null) ");
				 filter.SetFilterPart("de", "(IsDeleted != true OR IsDeleted = null)");


					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
	                    	if (contextRequest.User !=null )
	                        	if (contextRequest.Company != null ){
	                        		//if (sbQuerySystem.Length > 0)
	                        		//	    			sbQuerySystem.Append( " And ");	
									//sbQuerySystem.Append(@" (GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa

									filter.SetFilterPart("co",@"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))");

								}
						}	
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				//string predicateString = predicate.ToDynamicLinq<SDAreaPerson>();
				//predicateString += sbQuerySystem.ToString();
				filter.CleanAndProcess("");

				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed(); //SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicateString );               
                string predicateWithManyRelations = filter.GetFilterChildren(); //SFSdotNet.Framework.Linq.Utils.CleanPartExpression(predicateString);

                //QueryUtils.BreakeQuery1(predicateString, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
                var _queryable = query.AsQueryable();
				bool includeAll = true; 
                if (!string.IsNullOrEmpty(predicateWithManyRelations))
                    _queryable = _queryable.Where(predicateWithManyRelations, contextRequest.CustomQuery.ExtraParams);
				if (contextRequest.CustomQuery.SpecificProperties.Count > 0)
                {

				includeAll = false; 
                }

				StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append("new (");
                bool existPrev = false;
                foreach (var selected in contextRequest.CustomQuery.SelectedFields.Where(p=> !string.IsNullOrEmpty(p.Linq)))
                {
                    if (existPrev) sbSelect.Append(", ");
                    if (!selected.Linq.Contains(".") && !selected.Linq.StartsWith("it."))
                        sbSelect.Append("it." + selected.Linq);
                    else
                        sbSelect.Append(selected.Linq);
                    existPrev = true;
                }
                sbSelect.Append(")");
                var queryable = _queryable.Select(sbSelect.ToString());                    


     				
                 if (!string.IsNullOrEmpty(predicateWithFKAndComputed))
                    queryable = queryable.Where(predicateWithFKAndComputed, contextRequest.CustomQuery.ExtraParams);

				QueryComplementOptions queryOps = ContextQueryBuilder.ApplyContextQuery(contextRequest);
            	if (!string.IsNullOrEmpty(queryOps.OrderByAndSort)){
					if (queryOps.OrderBy.Contains(".") && !queryOps.OrderBy.StartsWith("it.")) queryOps.OrderBy = "it." + queryOps.OrderBy;
					queryable = queryable.OrderBy(queryOps.OrderByAndSort);
					}
               	if (queryOps.Skip != null)
                {
                    queryable = queryable.Skip(queryOps.Skip.Value);
                }
                if (queryOps.PageSize != null)
                {
                    queryable = queryable.Take (queryOps.PageSize.Value);
                }


                var resultTemp = queryable.AsQueryable().ToListAsync().Result;
                foreach (var item in resultTemp)
                {

				   result.Add(SFSdotNet.Framework.BR.Utils.GetConverted<SDAreaPerson,dynamic>(item, contextRequest.CustomQuery.SelectedFields.Select(p=>p.Name).ToArray()));
                }

			 if (e != null)
                {
                    e.Items = result;
                }
				 contextRequest.CustomQuery = new CustomQuery();
				OnTaken(this, e == null ? e = new BusinessRulesEventArgs<SDAreaPerson>() { Items= result, IncludingComputedLinq = true, ContextRequest = contextRequest, FilterExpressionString  = predicateString } :  e);
  
			
  
                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
	
	*/
	#endregion

            }
        }
		public SDAreaPerson GetFromOperation(string function, string filterString, string usemode, string fields, ContextRequest contextRequest)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
                string computedFields = "";
               // string fkIncludes = "accContpaqiClassification,accProjectConcept,accProjectType,accProxyUser";
                List<string> multilangProperties = new List<string>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					if (contextRequest != null && contextRequest.Company != null)
					{
						multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
						contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
					}
					 									
					string multiTenantField = "GuidCompany";


                return GetSummaryOperation(con, new SDAreaPerson(), function, filterString, usemode, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields, contextRequest, fields.Split(char.Parse(",")).ToArray());
            }
        }

   protected override void QueryBuild(string predicate, Filter filter, DbContext efContext, ContextRequest contextRequest, string method, List<string> includesList)
      	{
				if (contextRequest.CustomQuery.SpecificProperties.Count == 0)
                {
					contextRequest.CustomQuery.SpecificProperties.Add(SDAreaPerson.PropertyNames.GuidArea);
					contextRequest.CustomQuery.SpecificProperties.Add(SDAreaPerson.PropertyNames.GuidPerson);
					contextRequest.CustomQuery.SpecificProperties.Add(SDAreaPerson.PropertyNames.GuidCompany);
					contextRequest.CustomQuery.SpecificProperties.Add(SDAreaPerson.PropertyNames.CreatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDAreaPerson.PropertyNames.UpdatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDAreaPerson.PropertyNames.CreatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDAreaPerson.PropertyNames.UpdatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDAreaPerson.PropertyNames.Bytes);
					contextRequest.CustomQuery.SpecificProperties.Add(SDAreaPerson.PropertyNames.IsDeleted);
					contextRequest.CustomQuery.SpecificProperties.Add(SDAreaPerson.PropertyNames.SDArea);
					contextRequest.CustomQuery.SpecificProperties.Add(SDAreaPerson.PropertyNames.SDPerson);
                    
				}

				if (method == "getby" || method == "sum")
				{
					if (!contextRequest.CustomQuery.SpecificProperties.Contains("GuidAreaPerson")){
						contextRequest.CustomQuery.SpecificProperties.Add("GuidAreaPerson");
					}

					 if (!string.IsNullOrEmpty(contextRequest.CustomQuery.OrderBy))
					{
						string existPropertyOrderBy = contextRequest.CustomQuery.OrderBy;
						if (contextRequest.CustomQuery.OrderBy.Contains("."))
						{
							existPropertyOrderBy = contextRequest.CustomQuery.OrderBy.Split(char.Parse("."))[0];
						}
						if (!contextRequest.CustomQuery.SpecificProperties.Exists(p => p == existPropertyOrderBy))
						{
							contextRequest.CustomQuery.SpecificProperties.Add(existPropertyOrderBy);
						}
					}

				}
				
	bool isFullDetails = contextRequest.IsFromUI("SDAreaPersons", UIActions.GetForDetails);
	string filterForTest = predicate  + filter.GetFilterComplete();

				if (isFullDetails || !string.IsNullOrEmpty(predicate))
            {
            } 

			if (method == "sum")
            {
            } 
			if (contextRequest.CustomQuery.SelectedFields.Count == 0)
            {
				foreach (var selected in contextRequest.CustomQuery.SpecificProperties)
                {
					string linq = selected;
					switch (selected)
                    {

					case "SDArea":
					if (includesList.Contains(selected)){
                        linq = "it.SDArea as SDArea";
					}
                    else
						linq = "iif(it.SDArea != null, new (it.SDArea.GuidArea, it.SDArea.Name), null) as SDArea";
 					break;
					case "SDPerson":
					if (includesList.Contains(selected)){
                        linq = "it.SDPerson as SDPerson";
					}
                    else
						linq = "iif(it.SDPerson != null, new (it.SDPerson.GuidPerson, it.SDPerson.DisplayName), null) as SDPerson";
 					break;
					 
						
					 default:
                            break;
                    }
					contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name=selected, Linq=linq});
					if (method == "getby" || method == "sum")
					{
						if (includesList.Contains(selected))
							includesList.Remove(selected);

					}

				}
			}
				if (method == "getby" || method == "sum")
				{
					foreach (var otherInclude in includesList.Where(p=> !string.IsNullOrEmpty(p)))
					{
						contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name = otherInclude, Linq = "it." + otherInclude +" as " + otherInclude });
					}
				}
				BusinessRulesEventArgs<SDAreaPerson> e = null;
				if (contextRequest.PreventInterceptors == false)
					OnQuerySettings(efContext, e = new BusinessRulesEventArgs<SDAreaPerson>() { Filter = filter, ContextRequest = contextRequest /*, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null)*/ });

				//List<SDAreaPerson> result = new List<SDAreaPerson>();
                 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }

}
		public List<SDAreaPerson> GetBy(Expression<Func<SDAreaPerson, bool>> predicate, bool loadRelations, ContextRequest contextRequest)
        {
			if(!loadRelations)
				return GetBy(predicate, contextRequest);
			else
				return GetBy(predicate, contextRequest, "");

        }

        public List<SDAreaPerson> GetBy(Expression<Func<SDAreaPerson, bool>> predicate, int? pageSize, int? page, string orderBy, SFSdotNet.Framework.Data.SortDirection? sortDirection)
        {
            return GetBy(predicate, new ContextRequest() { CustomQuery = new CustomQuery() { Page = page, PageSize = pageSize, OrderBy = orderBy, SortDirection = sortDirection } });
        }
        public List<SDAreaPerson> GetBy(Expression<Func<SDAreaPerson, bool>> predicate)
        {

			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
			contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
			            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            contextRequest.CustomQuery.FilterExpressionString = null;
            return this.GetBy(predicate, contextRequest, "");
        }
        #endregion
        #region Dynamic String
		protected override string GetSpecificFilter(string filter, ContextRequest contextRequest) {
            string result = "";
		    //string linqFilter = String.Empty;
            string freeTextFilter = String.Empty;
            if (filter.Contains("|"))
            {
               // linqFilter = filter.Split(char.Parse("|"))[0];
                freeTextFilter = filter.Split(char.Parse("|"))[1];
            }
            //else {
            //    freeTextFilter = filter;
            //}
            //else {
            //    linqFilter = filter;
            //}
			// linqFilter = SFSdotNet.Framework.Linq.Utils.ReplaceCustomDateFilters(linqFilter);
            //string specificFilter = linqFilter;
            if (!string.IsNullOrEmpty(freeTextFilter))
            {
                System.Text.StringBuilder sbCont = new System.Text.StringBuilder();
                /*if (specificFilter.Length > 0)
                {
                    sbCont.Append(" AND ");
                    sbCont.Append(" ({0})");
                }
                else
                {
                    sbCont.Append("{0}");
                }*/
                //var words = freeTextFilter.Split(char.Parse(" "));
				var word = freeTextFilter;
                System.Text.StringBuilder sbSpec = new System.Text.StringBuilder();
                 int nWords = 1;
				/*foreach (var word in words)
                {
					if (word.Length > 0){
                    if (sbSpec.Length > 0) sbSpec.Append(" AND ");
					if (words.Length > 1) sbSpec.Append("("); */
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
								
					//if (sbSpec.Length > 2)
					//	sbSpec.Append(" OR "); // test
					sbSpec.Append(string.Format(@"it.SDArea.Name.Contains(""{0}"")", word)+" OR "+string.Format(@"it.SDPerson.DisplayName.Contains(""{0}"")", word));
								 //sbSpec.Append("*extraFreeText*");

                    /*if (words.Length > 1) sbSpec.Append(")");
					
					nWords++;

					}

                }*/
                //specificFilter = string.Format("{0}{1}", specificFilter, string.Format(sbCont.ToString(), sbSpec.ToString()));
                                 result = sbSpec.ToString();  
            }
			//result = specificFilter;
			
			return result;

		}
	
			public List<SDAreaPerson> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params object[] extraParams)
        {
			return GetBy(filter, pageSize, page, orderBy, orderDir,  null, extraParams);
		}
           public List<SDAreaPerson> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, string usemode, params object[] extraParams)
            { 
                return GetBy(filter, pageSize, page, orderBy, orderDir, usemode, null, extraParams);
            }


		public List<SDAreaPerson> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  string usemode, ContextRequest context, params object[] extraParams)

        {

            // string freetext = null;
            //if (filter.Contains("|"))
            //{
            //    int parts = filter.Split(char.Parse("|")).Count();
            //    if (parts > 1)
            //    {

            //        freetext = filter.Split(char.Parse("|"))[1];
            //    }
            //}
		
            //string specificFilter = "";
            //if (!string.IsNullOrEmpty(filter))
            //  specificFilter=  GetSpecificFilter(filter);
            if (string.IsNullOrEmpty(orderBy))
            {
			                orderBy = "UpdatedDate";
            }
			//orderDir = "desc";
			SFSdotNet.Framework.Data.SortDirection direction = SFSdotNet.Framework.Data.SortDirection.Ascending;
            if (!string.IsNullOrEmpty(orderDir))
            {
                if (orderDir == "desc")
                    direction = SFSdotNet.Framework.Data.SortDirection.Descending;
            }
            if (context == null)
                context = new ContextRequest();
			

             context.UseMode = usemode;
             if (context.CustomQuery == null )
                context.CustomQuery =new SFSdotNet.Framework.My.CustomQuery();

 
                context.CustomQuery.ExtraParams = extraParams;

                    context.CustomQuery.OrderBy = orderBy;
                   context.CustomQuery.SortDirection = direction;
                   context.CustomQuery.Page = page;
                  context.CustomQuery.PageSize = pageSize;
               

            

            if (!preventSecurityRestrictions) {
			 if (context.CurrentContext == null)
                {
					if (SFSdotNet.Framework.My.Context.CurrentContext != null &&  SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
					{
						context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
						context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

					}
					else {
						throw new Exception("The security rule require a specific user and company");
					}
				}
            }
            return GetBy(filter, context);
  
        }


        public List<SDAreaPerson> GetBy(string strWhere, ContextRequest contextRequest)
        {
        	#region old code
				
				 //Expression<Func<tvsReservationTransport, bool>> predicate = null;
				string strWhereClean = strWhere.Replace("*extraFreeText*", "").Replace("()", "");
                //if (!string.IsNullOrEmpty(strWhereClean)){

                //    object[] extraParams = null;
                //    //if (contextRequest != null )
                //    //    if (contextRequest.CustomQuery != null )
                //    //        extraParams = contextRequest.CustomQuery.ExtraParams;
                //    //predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<tvsReservationTransport, bool>(strWhereClean, extraParams != null? extraParams.Cast<Guid>(): null);				
                //}
				 if (contextRequest == null)
                {
                    contextRequest = new ContextRequest();
                    if (contextRequest.CustomQuery == null)
                        contextRequest.CustomQuery = new CustomQuery();
                }
                  if (!preventSecurityRestrictions) {
					if (contextRequest.User == null || contextRequest.Company == null)
                      {
                     if (SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
                     {
                         contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                         contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

                     }
                     else {
                         throw new Exception("The security rule require a specific User and Company ");
                     }
					 }
                 }
            contextRequest.CustomQuery.FilterExpressionString = strWhere;
				//return GetBy(predicate, contextRequest);  

			#endregion				
				
                    return GetBy(strWhere, contextRequest, "");  


        }
       public List<SDAreaPerson> GetBy(string strWhere)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
			
            return GetBy(strWhere, context, null);
        }

        public List<SDAreaPerson> GetBy(string strWhere, string includes)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
            return GetBy(strWhere, context, includes);
        }

        #endregion
        #endregion
		
		  #region SaveOrUpdate
        
 		 public SDAreaPerson Create(SDAreaPerson entity)
        {
				//ObjectContext context = null;
				    if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: Create");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

				return this.Create(entity, contextRequest);


        }
        
       
        public SDAreaPerson Create(SDAreaPerson entity, ContextRequest contextRequest)
        {
		
		bool graph = false;
	
				bool preventPartial = false;
                if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
               
			using (EFContext con = new EFContext()) {

				SDAreaPerson itemForSave = new SDAreaPerson();
#region Autos
		if(!preventSecurityRestrictions){

				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion
               BusinessRulesEventArgs<SDAreaPerson> e = null;
			    if (preventPartial == false )
                OnCreating(this,e = new BusinessRulesEventArgs<SDAreaPerson>() { ContextRequest = contextRequest, Item=entity });
				   if (e != null) {
						if (e.Cancel)
						{
							context = null;
							return e.Item;

						}
					}

                    if (entity.GuidAreaPerson == Guid.Empty)
                   {
                       entity.GuidAreaPerson = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   itemForSave.GuidAreaPerson = entity.GuidAreaPerson;
				  
		
			itemForSave.GuidAreaPerson = entity.GuidAreaPerson;

			itemForSave.GuidCompany = entity.GuidCompany;

			itemForSave.CreatedDate = entity.CreatedDate;

			itemForSave.UpdatedDate = entity.UpdatedDate;

			itemForSave.CreatedBy = entity.CreatedBy;

			itemForSave.UpdatedBy = entity.UpdatedBy;

			itemForSave.Bytes = entity.Bytes;

			itemForSave.IsDeleted = entity.IsDeleted;

				
				con.SDAreaPersons.Add(itemForSave);



					if (entity.SDArea != null)
					{
						var sDArea = new SDArea();
						sDArea.GuidArea = entity.SDArea.GuidArea;
						itemForSave.SDArea = sDArea;
						SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDArea>(con, itemForSave.SDArea);
			
					}




					if (entity.SDPerson != null)
					{
						var sDPerson = new SDPerson();
						sDPerson.GuidPerson = entity.SDPerson.GuidPerson;
						itemForSave.SDPerson = sDPerson;
						SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDPerson>(con, itemForSave.SDPerson);
			
					}



                
				con.ChangeTracker.Entries().Where(p => p.Entity != itemForSave && p.State != EntityState.Unchanged).ForEach(p => p.State = EntityState.Detached);

				con.Entry<SDAreaPerson>(itemForSave).State = EntityState.Added;

				con.SaveChanges();

					 
				

				//itemResult = entity;
                //if (e != null)
                //{
                 //   e.Item = itemResult;
                //}
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false )
                OnCreated(this, e == null ? e = new BusinessRulesEventArgs<SDAreaPerson>() { ContextRequest = contextRequest, Item = entity } : e);



                if (e != null && e.Item != null )
                {
                    return e.Item;
                }
                              return entity;
			}
            
        }
        //BusinessRulesEventArgs<SDAreaPerson> e = null;
        public void Create(List<SDAreaPerson> entities)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            Create(entities, contextRequest);
        }
        public void Create(List<SDAreaPerson> entities, ContextRequest contextRequest)
        
        {
			ObjectContext context = null;
            	foreach (SDAreaPerson entity in entities)
				{
					this.Create(entity, contextRequest);
				}
        }
		  public void CreateOrUpdateBulk(List<SDAreaPerson> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "cu", contextRequest);
        }

        private void CreateOrUpdateBulk(List<SDAreaPerson> entities, string actionKey, ContextRequest contextRequest)
        {
			if (entities.Count() > 0){
            bool graph = false;

            bool preventPartial = false;
            if (contextRequest != null && contextRequest.PreventInterceptors == true)
            {
                preventPartial = true;
            }
            foreach (var entity in entities)
            {
                    if (entity.GuidAreaPerson == Guid.Empty)
                   {
                       entity.GuidAreaPerson = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   
				  


#region Autos
		if(!preventSecurityRestrictions){


 if (actionKey != "u")
                        {
				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;


}
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion


		
			//entity.GuidAreaPerson = entity.GuidAreaPerson;

			//entity.GuidCompany = entity.GuidCompany;

			//entity.CreatedDate = entity.CreatedDate;

			//entity.UpdatedDate = entity.UpdatedDate;

			//entity.CreatedBy = entity.CreatedBy;

			//entity.UpdatedBy = entity.UpdatedBy;

			//entity.Bytes = entity.Bytes;

			//entity.IsDeleted = entity.IsDeleted;

				
				



				    if (entity.SDArea != null)
					{
						//var sDArea = new SDArea();
						entity.GuidArea = entity.SDArea.GuidArea;
						//entity.SDArea = sDArea;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDArea>(con, itemForSave.SDArea);
			
					}




				    if (entity.SDPerson != null)
					{
						//var sDPerson = new SDPerson();
						entity.GuidPerson = entity.SDPerson.GuidPerson;
						//entity.SDPerson = sDPerson;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDPerson>(con, itemForSave.SDPerson);
			
					}



                
				

					 
				

				//itemResult = entity;
            }
            using (EFContext con = new EFContext())
            {
                 if (actionKey == "c")
                    {
                        context.BulkInsert(entities);
                    }else if ( actionKey == "u")
                    {
                        context.BulkUpdate(entities);
                    }else
                    {
                        context.BulkInsertOrUpdate(entities);
                    }
            }

			}
        }
	
		public void CreateBulk(List<SDAreaPerson> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "c", contextRequest);
        }


		public void UpdateAgile(SDAreaPerson item, params string[] fields)
         {
			UpdateAgile(item, null, fields);
        }
		public void UpdateAgile(SDAreaPerson item, ContextRequest contextRequest, params string[] fields)
         {
            
             ContextRequest contextNew = null;
             if (contextRequest != null)
             {
                 contextNew = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
                 if (fields != null && fields.Length > 0)
                 {
                     contextNew.CustomQuery.SpecificProperties  = fields.ToList();
                 }
                 else if(contextRequest.CustomQuery.SpecificProperties.Count > 0)
                 {
                     fields = contextRequest.CustomQuery.SpecificProperties.ToArray();
                 }
             }
			

		   using (EFContext con = new EFContext())
            {



               
					List<string> propForCopy = new List<string>();
                    propForCopy.AddRange(fields);
                    
					  
					if (!propForCopy.Contains("GuidAreaPerson"))
						propForCopy.Add("GuidAreaPerson");

					var itemForUpdate = SFSdotNet.Framework.BR.Utils.GetConverted<SDAreaPerson,SDAreaPerson>(item, propForCopy.ToArray());
					 itemForUpdate.GuidAreaPerson = item.GuidAreaPerson;
                  var setT = con.Set<SDAreaPerson>().Attach(itemForUpdate);

					if (fields.Count() > 0)
					  {
						  item.ModifiedProperties = fields;
					  }
                    foreach (var property in item.ModifiedProperties)
					{						
                        if (property != "GuidAreaPerson")
                             con.Entry(setT).Property(property).IsModified = true;

                    }

                
               int result = con.SaveChanges();
               if (result != 1)
               {
                   SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: 1");
               }


            }

			OnUpdatedAgile(this, new BusinessRulesEventArgs<SDAreaPerson>() { Item = item, ContextRequest = contextNew  });

         }
		public void UpdateBulk(List<SDAreaPerson>  items, params string[] fields)
         {
             SFSdotNet.Framework.My.ContextRequest req = new SFSdotNet.Framework.My.ContextRequest();
             req.CustomQuery = new SFSdotNet.Framework.My.CustomQuery();
             foreach (var field in fields)
             {
                 req.CustomQuery.SpecificProperties.Add(field);
             }
             UpdateBulk(items, req);

         }

		 public void DeleteBulk(List<SDAreaPerson> entities, ContextRequest contextRequest = null)
        {

            using (EFContext con = new EFContext())
            {
                foreach (var entity in entities)
                {
					var entityProxy = new SDAreaPerson() { GuidAreaPerson = entity.GuidAreaPerson };

                    con.Entry<SDAreaPerson>(entityProxy).State = EntityState.Deleted;

                }

                int result = con.SaveChanges();
                if (result != entities.Count)
                {
                    SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: " + entities.Count.ToString());
                }
            }

        }

        public void UpdateBulk(List<SDAreaPerson> items, ContextRequest contextRequest)
        {
            if (items.Count() > 0){

			 foreach (var entity in items)
            {


#region Autos
		if(!preventSecurityRestrictions){

				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	



			}
#endregion




				    if (entity.SDArea != null)
					{
						//var sDArea = new SDArea();
						entity.GuidArea = entity.SDArea.GuidArea;
						//entity.SDArea = sDArea;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDArea>(con, itemForSave.SDArea);
			
					}




				    if (entity.SDPerson != null)
					{
						//var sDPerson = new SDPerson();
						entity.GuidPerson = entity.SDPerson.GuidPerson;
						//entity.SDPerson = sDPerson;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDPerson>(con, itemForSave.SDPerson);
			
					}



				}
				using (EFContext con = new EFContext())
				{

                    
                
                   con.BulkUpdate(items);

				}
             
			}	  
        }

         public SDAreaPerson Update(SDAreaPerson entity)
        {
            if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return Update(entity, contextRequest);
        }
       
         public SDAreaPerson Update(SDAreaPerson entity, ContextRequest contextRequest)
        {
		 if ((System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null) && contextRequest == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Update");
            }
            if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            }

			
				SDAreaPerson  itemResult = null;

	
			//entity.UpdatedDate = DateTime.Now.ToUniversalTime();
			//if(contextRequest.User != null)
				//entity.UpdatedBy = contextRequest.User.GuidUser;

//	    var oldentity = GetBy(p => p.GuidAreaPerson == entity.GuidAreaPerson, contextRequest).FirstOrDefault();
	//	if (oldentity != null) {
		
          //  entity.CreatedDate = oldentity.CreatedDate;
    //        entity.CreatedBy = oldentity.CreatedBy;
	
      //      entity.GuidCompany = oldentity.GuidCompany;
	
			

	
		//}

			 using( EFContext con = new EFContext()){
				BusinessRulesEventArgs<SDAreaPerson> e = null;
				bool preventPartial = false; 
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false)
                OnUpdating(this,e = new BusinessRulesEventArgs<SDAreaPerson>() { ContextRequest = contextRequest, Item=entity});
				   if (e != null) {
						if (e.Cancel)
						{
							//outcontext = null;
							return e.Item;

						}
					}

	string includes = "SDArea,SDPerson";
	IQueryable < SDAreaPerson > query = con.SDAreaPersons.AsQueryable();
	foreach (string include in includes.Split(char.Parse(",")))
                       {
                           if (!string.IsNullOrEmpty(include))
                               query = query.Include(include);
                       }
	var oldentity = query.FirstOrDefault(p => p.GuidAreaPerson == entity.GuidAreaPerson);

				//if (entity.UpdatedDate == null || (contextRequest != null && contextRequest.IsFromUI("SDAreaPersons", UIActions.Updating)))
			oldentity.UpdatedDate = DateTime.Now.ToUniversalTime();
			if(contextRequest.User != null)
				oldentity.UpdatedBy = contextRequest.User.GuidUser;

           


						if (SFSdotNet.Framework.BR.Utils.HasRelationPropertyChanged(oldentity.SDArea, entity.SDArea, "GuidArea"))
							oldentity.SDArea = entity.SDArea != null? new SDArea(){ GuidArea = entity.SDArea.GuidArea } :null;

                


						if (SFSdotNet.Framework.BR.Utils.HasRelationPropertyChanged(oldentity.SDPerson, entity.SDPerson, "GuidPerson"))
							oldentity.SDPerson = entity.SDPerson != null? new SDPerson(){ GuidPerson = entity.SDPerson.GuidPerson } :null;

                


				con.ChangeTracker.Entries().Where(p => p.Entity != oldentity).ForEach(p => p.State = EntityState.Unchanged);  
				  
				con.SaveChanges();
        
					 
					
               
				itemResult = entity;
				if(preventPartial == false)
					OnUpdated(this, e = new BusinessRulesEventArgs<SDAreaPerson>() { ContextRequest = contextRequest, Item=itemResult });

              	return itemResult;
			}
			  
        }
        public SDAreaPerson Save(SDAreaPerson entity)
        {
			return Create(entity);
        }
        public int Save(List<SDAreaPerson> entities)
        {
			 Create(entities);
            return entities.Count;

        }
        #endregion
        #region Delete
        public void Delete(SDAreaPerson entity)
        {
				this.Delete(entity, null);
			
        }
		 public void Delete(SDAreaPerson entity, ContextRequest contextRequest)
        {
				
				  List<SDAreaPerson> entities = new List<SDAreaPerson>();
				   entities.Add(entity);
				this.Delete(entities, contextRequest);
			
        }

         public void Delete(string query, Guid[] guids, ContextRequest contextRequest)
        {
			var br = new SDAreaPersonsBR(true);
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);
            
            Delete(items, contextRequest);

        }
        public void Delete(SDAreaPerson entity,  ContextRequest contextRequest, BusinessRulesEventArgs<SDAreaPerson> e = null)
        {
			
				using(EFContext con = new EFContext())
                 {
				
               	BusinessRulesEventArgs<SDAreaPerson> _e = null;
               List<SDAreaPerson> _items = new List<SDAreaPerson>();
                _items.Add(entity);
                if (e == null || e.PreventPartialPropagate == false)
                {
                    OnDeleting(this, _e = (e == null ? new BusinessRulesEventArgs<SDAreaPerson>() { ContextRequest = contextRequest, Item = entity, Items = null  } : e));
                }
                if (_e != null)
                {
                    if (_e.Cancel)
						{
							context = null;
							return;

						}
					}


				
									//IsDeleted
					bool logicDelete = true;
					if (entity.IsDeleted != null)
					{
						if (entity.IsDeleted.Value)
							logicDelete = false;
					}
					if (logicDelete)
					{
											//entity = GetBy(p =>, contextRequest).FirstOrDefault();
						entity.IsDeleted = true;
						if (contextRequest != null && contextRequest.User != null)
							entity.UpdatedBy = contextRequest.User.GuidUser;
                        entity.UpdatedDate = DateTime.UtcNow;
						UpdateAgile(entity, "IsDeleted","UpdatedBy","UpdatedDate");

						
					}
					else {
					con.Entry<SDAreaPerson>(entity).State = EntityState.Deleted;
					con.SaveChanges();
				
				 
					}
								
				
				 
					
					
			if (e == null || e.PreventPartialPropagate == false)
                {

                    if (_e == null)
                        _e = new BusinessRulesEventArgs<SDAreaPerson>() { ContextRequest = contextRequest, Item = entity, Items = null };

                    OnDeleted(this, _e);
                }

				//return null;
			}
        }
 public void UnDelete(string query, Guid[] guids, ContextRequest contextRequest)
        {
            var br = new SDAreaPersonsBR(true);
            contextRequest.CustomQuery.IncludeDeleted = true;
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);

            foreach (var item in items)
            {
                item.IsDeleted = false;
						if (contextRequest != null && contextRequest.User != null)
							item.UpdatedBy = contextRequest.User.GuidUser;
                        item.UpdatedDate = DateTime.UtcNow;
            }

            UpdateBulk(items, "IsDeleted","UpdatedBy","UpdatedDate");
        }

         public void Delete(List<SDAreaPerson> entities,  ContextRequest contextRequest = null )
        {
				
			 BusinessRulesEventArgs<SDAreaPerson> _e = null;

                OnDeleting(this, _e = new BusinessRulesEventArgs<SDAreaPerson>() { ContextRequest = contextRequest, Item = null, Items = entities });
                if (_e != null)
                {
                    if (_e.Cancel)
                    {
                        context = null;
                        return;

                    }
                }
                bool allSucced = true;
                BusinessRulesEventArgs<SDAreaPerson> eToChilds = new BusinessRulesEventArgs<SDAreaPerson>();
                if (_e != null)
                {
                    eToChilds = _e;
                }
                else
                {
                    eToChilds = new BusinessRulesEventArgs<SDAreaPerson>() { ContextRequest = contextRequest, Item = (entities.Count == 1 ? entities[0] : null), Items = entities };
                }
				foreach (SDAreaPerson item in entities)
				{
					try
                    {
                        this.Delete(item, contextRequest, e: eToChilds);
                    }
                    catch (Exception ex)
                    {
                        SFSdotNet.Framework.My.EventLog.Error(ex);
                        allSucced = false;
                    }
				}
				if (_e == null)
                    _e = new BusinessRulesEventArgs<SDAreaPerson>() { ContextRequest = contextRequest, CountResult = entities.Count, Item = null, Items = entities };
                OnDeleted(this, _e);

			
        }
        #endregion
 
        #region GetCount
		 public int GetCount(Expression<Func<SDAreaPerson, bool>> predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

			return GetCount(predicate, contextRequest);
		}
        public int GetCount(Expression<Func<SDAreaPerson, bool>> predicate, ContextRequest contextRequest)
        {


		
		 using (EFContext con = new EFContext())
            {


				if (predicate == null) predicate = PredicateBuilder.True<SDAreaPerson>();
           		predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted == null);
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    		if (contextRequest.User !=null )
                        		if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
									predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa

								}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				
				IQueryable<SDAreaPerson> query = con.SDAreaPersons.AsQueryable();
                return query.AsExpandable().Count(predicate);

			
				}
			

        }
		  public int GetCount(string predicate,  ContextRequest contextRequest)
         {
             return GetCount(predicate, null, contextRequest);
         }

         public int GetCount(string predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return GetCount(predicate, contextRequest);
        }
		 public int GetCount(string predicate, string usemode){
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
				return GetCount( predicate,  usemode,  contextRequest);
		 }
        public int GetCount(string predicate, string usemode, ContextRequest contextRequest){

		using (EFContext con = new EFContext()) {
				string computedFields = "";
				string fkIncludes = "SDArea,SDPerson";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDAreaPerson>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetCount(con, predicate, usemode, contextRequest, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields);

			}
			#region old code
			 /* string freetext = null;
            Filter filter = new Filter();

              if (predicate.Contains("|"))
              {
                 
                  filter.SetFilterPart("ft", GetSpecificFilter(predicate, contextRequest));
                 
                  filter.ProcessText(predicate.Split(char.Parse("|"))[0]);
                  freetext = predicate.Split(char.Parse("|"))[1];

				  if (!string.IsNullOrEmpty(freetext) && string.IsNullOrEmpty(contextRequest.FreeText))
                  {
                      contextRequest.FreeText = freetext;
                  }
              }
              else {
                  filter.ProcessText(predicate);
              }
			   predicate = filter.GetFilterComplete();
			// BusinessRulesEventArgs<SDAreaPerson>  e = null;
           	using (EFContext con = new EFContext())
			{
			
			

			 QueryBuild(predicate, filter, con, contextRequest, "count", new List<string>());


			
			BusinessRulesEventArgs<SDAreaPerson> e = null;

			contextRequest.FreeText = freetext;
			contextRequest.UseMode = usemode;
            OnCounting(this, e = new BusinessRulesEventArgs<SDAreaPerson>() {  Filter =filter, ContextRequest = contextRequest });
            if (e != null)
            {
                if (e.Cancel)
                {
                    context = null;
                    return e.CountResult;

                }

            

            }
			
			StringBuilder sbQuerySystem = new StringBuilder();
		
					
                    filter.SetFilterPart("de","(IsDeleted != true OR IsDeleted == null)");
			
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    	if (contextRequest.User !=null )
                        	if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
                        		
								filter.SetFilterPart("co", @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa
						
						
							}
							
							}
							if (preventSecurityRestrictions) preventSecurityRestrictions= false;
		
				   
                 filter.CleanAndProcess("");
				//string predicateWithFKAndComputed = SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicate );               
				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed();
               string predicateWithManyRelations = filter.GetFilterChildren();
			   ///QueryUtils.BreakeQuery1(predicate, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
			   predicate = filter.GetFilterComplete();
               if (!string.IsNullOrEmpty(predicate))
               {
				
					
                    return con.SDAreaPersons.Where(predicate).Count();
					
                }else
                    return con.SDAreaPersons.Count();
					
			}*/
			#endregion

		}
         public int GetCount()
        {
            return GetCount(p => true);
        }
        #endregion
        
         


        public void Delete(List<SDAreaPerson.CompositeKey> entityKeys)
        {

            List<SDAreaPerson> items = new List<SDAreaPerson>();
            foreach (var itemKey in entityKeys)
            {
                items.Add(GetByKey(itemKey.GuidAreaPerson));
            }

            Delete(items);

        }
		 public void UpdateAssociation(string relation, string relationValue, string query, Guid[] ids, ContextRequest contextRequest)
        {
            var items = GetBy(query, null, null, null, null, null, contextRequest, ids);
			 var module = SFSdotNet.Framework.Cache.Caching.SystemObjects.GetModuleByKey(SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(System.Web.HttpContext.Current.Request.RequestContext, "area"));
           
            foreach (var item in items)
            {
			  Guid ? guidRelationValue = null ;
                if (!string.IsNullOrEmpty(relationValue)){
                    guidRelationValue = Guid.Parse(relationValue );
                }

				 if (relation.Contains("."))
                {
                    var partsWithOtherProp = relation.Split(char.Parse("|"));
                    var parts = partsWithOtherProp[0].Split(char.Parse("."));

                    string proxyRelName = parts[0];
                    string proxyProperty = parts[1];
                    string proxyPropertyKeyNameFromOther = partsWithOtherProp[1];
                    //string proxyPropertyThis = parts[2];

                    var prop = item.GetType().GetProperty(proxyRelName);
                    //var entityInfo = //SFSdotNet.Framework.
                    // descubrir el tipo de entidad dentro de la colección
                    Type typeEntityInList = SFSdotNet.Framework.Entities.Utils.GetTypeFromList(prop);
                    var newProxyItem = Activator.CreateInstance(typeEntityInList);
                    var propThisForSet = newProxyItem.GetType().GetProperty(proxyProperty);
                    var entityInfoOfProxy = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(typeEntityInList);
                    var propOther = newProxyItem.GetType().GetProperty(proxyPropertyKeyNameFromOther);

                    if (propThisForSet != null && entityInfoOfProxy != null && propOther != null )
                    {
                        var entityInfoThis = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(item.GetType());
                        var valueThisId = item.GetType().GetProperty(entityInfoThis.PropertyKeyName).GetValue(item);
                        if (valueThisId != null)
                            propThisForSet.SetValue(newProxyItem, valueThisId);
                        propOther.SetValue(newProxyItem, Guid.Parse(relationValue));
                        
                        var entityNameProp = newProxyItem.GetType().GetField("EntityName").GetValue(null);
                        var entitySetNameProp = newProxyItem.GetType().GetField("EntitySetName").GetValue(null);

                        SFSdotNet.Framework.Apps.Integration.CreateItemFromApp(entityNameProp.ToString(), entitySetNameProp.ToString(), module.ModuleNamespace, newProxyItem, contextRequest);

                    }

                    // crear una instancia del tipo de entidad
                    // llenar los datos y registrar nuevo


                }
                else
                {
                var prop = item.GetType().GetProperty(relation);
                var entityInfo = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(prop.PropertyType);
                if (entityInfo != null)
                {
                    var ins = Activator.CreateInstance(prop.PropertyType);
                   if (guidRelationValue != null)
                    {
                        prop.PropertyType.GetProperty(entityInfo.PropertyKeyName).SetValue(ins, guidRelationValue);
                        item.GetType().GetProperty(relation).SetValue(item, ins);
                    }
                    else
                    {
                        item.GetType().GetProperty(relation).SetValue(item, null);
                    }

                    Update(item, contextRequest);
                }

				}
            }
        }
		
	}
		public partial class SDCasesBR:BRBase<SDCase>{
	 	
           
		 #region Partial methods

           partial void OnUpdating(object sender, BusinessRulesEventArgs<SDCase> e);

            partial void OnUpdated(object sender, BusinessRulesEventArgs<SDCase> e);
			partial void OnUpdatedAgile(object sender, BusinessRulesEventArgs<SDCase> e);

            partial void OnCreating(object sender, BusinessRulesEventArgs<SDCase> e);
            partial void OnCreated(object sender, BusinessRulesEventArgs<SDCase> e);

            partial void OnDeleting(object sender, BusinessRulesEventArgs<SDCase> e);
            partial void OnDeleted(object sender, BusinessRulesEventArgs<SDCase> e);

            partial void OnGetting(object sender, BusinessRulesEventArgs<SDCase> e);
            protected override void OnVirtualGetting(object sender, BusinessRulesEventArgs<SDCase> e)
            {
                OnGetting(sender, e);
            }
			protected override void OnVirtualCounting(object sender, BusinessRulesEventArgs<SDCase> e)
            {
                OnCounting(sender, e);
            }
			partial void OnTaken(object sender, BusinessRulesEventArgs<SDCase> e);
			protected override void OnVirtualTaken(object sender, BusinessRulesEventArgs<SDCase> e)
            {
                OnTaken(sender, e);
            }

            partial void OnCounting(object sender, BusinessRulesEventArgs<SDCase> e);
 
			partial void OnQuerySettings(object sender, BusinessRulesEventArgs<SDCase> e);
          
            #endregion
			
		private static SDCasesBR singlenton =null;
				public static SDCasesBR NewInstance(){
					return  new SDCasesBR();
					
				}
		public static SDCasesBR Instance{
			get{
				if (singlenton == null)
					singlenton = new SDCasesBR();
				return singlenton;
			}
		}
		//private bool preventSecurityRestrictions = false;
		 public bool PreventAuditTrail { get; set;  }
		#region Fields
        EFContext context = null;
        #endregion
        #region Constructor
        public SDCasesBR()
        {
            context = new EFContext();
        }
		 public SDCasesBR(bool preventSecurity)
            {
                this.preventSecurityRestrictions = preventSecurity;
				context = new EFContext();
            }
        #endregion
		
		#region Get

 		public IQueryable<SDCase> Get()
        {
            using (EFContext con = new EFContext())
            {
				
				var query = con.SDCases.AsQueryable();
                con.Configuration.ProxyCreationEnabled = false;

                //query = ContextQueryBuilder<Nutrient>.ApplyContextQuery(query, contextRequest);

                return query;




            }

        }
		


 	
		public List<SDCase> GetAll()
        {
            return this.GetBy(p => true);
        }
        public List<SDCase> GetAll(string includes)
        {
            return this.GetBy(p => true, includes);
        }
        public SDCase GetByKey(Guid guidCase)
        {
            return GetByKey(guidCase, true);
        }
        public SDCase GetByKey(Guid guidCase, bool loadIncludes)
        {
            SDCase item = null;
			var query = PredicateBuilder.True<SDCase>();
                    
			string strWhere = @"GuidCase = Guid(""" + guidCase.ToString()+@""")";
            Expression<Func<SDCase, bool>> predicate = null;
            //if (!string.IsNullOrEmpty(strWhere))
            //    predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDCase, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
			 ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
            contextRequest.CustomQuery.FilterExpressionString = strWhere;

			//item = GetBy(predicate, loadIncludes, contextRequest).FirstOrDefault();
			item = GetBy(strWhere,loadIncludes,contextRequest).FirstOrDefault();
            return item;
        }
         public List<SDCase> GetBy(string strWhere, bool loadRelations, ContextRequest contextRequest)
        {
            if (!loadRelations)
                return GetBy(strWhere, contextRequest);
            else
                return GetBy(strWhere, contextRequest, "");

        }
		  public List<SDCase> GetBy(string strWhere, bool loadRelations)
        {
              if (!loadRelations)
                return GetBy(strWhere, new ContextRequest());
            else
                return GetBy(strWhere, new ContextRequest(), "");

        }
		         public SDCase GetByKey(Guid guidCase, params Expression<Func<SDCase, object>>[] includes)
        {
            SDCase item = null;
			string strWhere = @"GuidCase = Guid(""" + guidCase.ToString()+@""")";
          Expression<Func<SDCase, bool>> predicate = p=> p.GuidCase == guidCase;
           // if (!string.IsNullOrEmpty(strWhere))
           //     predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDCase, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
        item = GetBy(predicate, includes).FirstOrDefault();
         ////   item = GetBy(strWhere,includes).FirstOrDefault();
			return item;

        }
        public SDCase GetByKey(Guid guidCase, string includes)
        {
            SDCase item = null;
			string strWhere = @"GuidCase = Guid(""" + guidCase.ToString()+@""")";
            
			
            item = GetBy(strWhere, includes).FirstOrDefault();
            return item;

        }
		 public SDCase GetByKey(Guid guidCase, string usemode, string includes)
		{
			return GetByKey(guidCase, usemode, null, includes);

		 }
		 public SDCase GetByKey(Guid guidCase, string usemode, ContextRequest context,  string includes)
        {
            SDCase item = null;
			string strWhere = @"GuidCase = Guid(""" + guidCase.ToString()+@""")";
			if (context == null){
				context = new ContextRequest();
				context.CustomQuery = new CustomQuery();
				context.CustomQuery.IsByKey = true;
				context.CustomQuery.FilterExpressionString = strWhere;
				context.UseMode = usemode;
			}
            item = GetBy(strWhere,context , includes).FirstOrDefault();
            return item;

        }

        #region Dynamic Predicate
        public List<SDCase> GetBy(Expression<Func<SDCase, bool>> predicate, int? pageSize, int? page)
        {
            return this.GetBy(predicate, pageSize, page, null, null);
        }
        public List<SDCase> GetBy(Expression<Func<SDCase, bool>> predicate, ContextRequest contextRequest)
        {

            return GetBy(predicate, contextRequest,"");
        }
        
        public List<SDCase> GetBy(Expression<Func<SDCase, bool>> predicate, ContextRequest contextRequest, params Expression<Func<SDCase, object>>[] includes)
        {
            StringBuilder sb = new StringBuilder();
           if (includes != null)
            {
                foreach (var path in includes)
                {

						if (sb.Length > 0) sb.Append(",");
						sb.Append(SFSdotNet.Framework.Linq.Utils.IncludeToString<SDCase>(path));

               }
            }
            return GetBy(predicate, contextRequest, sb.ToString());
        }
        
        
        public List<SDCase> GetBy(Expression<Func<SDCase, bool>> predicate, string includes)
        {
			ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";

            return GetBy(predicate, context, includes);
        }

        public List<SDCase> GetBy(Expression<Func<SDCase, bool>> predicate, params Expression<Func<SDCase, object>>[] includes)
        {
			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest context = new ContextRequest();
			            context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";
            return GetBy(predicate, context, includes);
        }

      
		public bool DisableCache { get; set; }
		public List<SDCase> GetBy(Expression<Func<SDCase, bool>> predicate, ContextRequest contextRequest, string includes)
		{
            using (EFContext con = new EFContext()) {
				
				string fkIncludes = "SDPerson,SDCasePriority,SDCaseState";
                List<string> multilangProperties = new List<string>();
				if (predicate == null) predicate = PredicateBuilder.True<SDCase>();
                var notDeletedExpression = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;
					Expression<Func<SDCase,bool>> multitenantExpression  = null;
					if (contextRequest != null && contextRequest.Company != null)	                        	
						multitenantExpression = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicate, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression);

#region Old code
/*
				List<SDCase> result = null;
               BusinessRulesEventArgs<SDCase>  e = null;
	
				OnGetting(con, e = new BusinessRulesEventArgs<SDCase>() {  FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null) });

               // OnGetting(con,e = new BusinessRulesEventArgs<SDCase>() { FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = contextRequest.CustomQuery.FilterExpressionString});
				   if (e != null) {
				    predicate = e.FilterExpression;
						if (e.Cancel)
						{
							context = null;
							 if (e.Items == null) e.Items = new List<SDCase>();
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                if (predicate == null) predicate = PredicateBuilder.True<SDCase>();
 				string fkIncludes = "SDPerson,SDCasePriority,SDCaseState";
                if(contextRequest!=null){
					if (contextRequest.CustomQuery != null)
					{
						if (contextRequest.CustomQuery.IncludeForeignKeyPaths != null) {
							if (contextRequest.CustomQuery.IncludeForeignKeyPaths.Value == false)
								fkIncludes = "";
						}
					}
				}
				if (!string.IsNullOrEmpty(includes))
					includes = includes + "," + fkIncludes;
				else
					includes = fkIncludes;
                
                //var es = _repository.Queryable;

                IQueryable<SDCase> query =  con.SDCases.AsQueryable();

                                if (!string.IsNullOrEmpty(includes))
                {
                    foreach (string include in includes.Split(char.Parse(",")))
                    {
						if (!string.IsNullOrEmpty(include))
                            query = query.Include(include);
                    }
                }
                    predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
					 	if (!preventSecurityRestrictions)
						{
							if (contextRequest != null )
		                    	if (contextRequest.User !=null )
		                        	if (contextRequest.Company != null){
		                        	
										predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
 									
									}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				query =query.AsExpandable().Where(predicate);
                query = ContextQueryBuilder<SDCase>.ApplyContextQuery(query, contextRequest);

                result = query.AsNoTracking().ToList<SDCase>();
				  
                if (e != null)
                {
                    e.Items = result;
                }
				//if (contextRequest != null ){
				//	 contextRequest = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
					contextRequest.CustomQuery = new CustomQuery();

				//}
				OnTaken(this, e == null ? e =  new BusinessRulesEventArgs<SDCase>() { Items= result, IncludingComputedLinq = false, ContextRequest = contextRequest,  FilterExpression = predicate } :  e);
  
			

                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
				*/
#endregion
            }
        }


		/*public int Update(List<SDCase> items, ContextRequest contextRequest)
            {
                int result = 0;
                using (EFContext con = new EFContext())
                {
                   
                

                    foreach (var item in items)
                    {
                        //secMessageToUser messageToUser = new secMessageToUser();
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            item.GetType().GetProperty(prop).SetValue(item, item.GetType().GetProperty(prop).GetValue(item));
                        }
                        //messageToUser.GuidMessageToUser = (Guid)item.GetType().GetProperty("GuidMessageToUser").GetValue(item);

                        var setObject = con.CreateObjectSet<SDCase>("SDCases");
                        //messageToUser.Readed = DateTime.UtcNow;
                        setObject.Attach(item);
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            con.ObjectStateManager.GetObjectStateEntry(item).SetModifiedProperty(prop);
                        }
                       
                    }
                    result = con.SaveChanges();

                    


                }
                return result;
            }
           */
		

        public List<SDCase> GetBy(string predicateString, ContextRequest contextRequest, string includes)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
				


				string computedFields = "";
				string fkIncludes = "SDPerson,SDCasePriority,SDCaseState";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDCase>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					//if (contextRequest != null && contextRequest.Company != null)                      	
					//	 multitenantExpression = @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))";
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicateString, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression,computedFields);


	#region Old Code
	/*
				BusinessRulesEventArgs<SDCase> e = null;

				Filter filter = new Filter();
                if (predicateString.Contains("|"))
                {
                    string ft = GetSpecificFilter(predicateString, contextRequest);
                    if (!string.IsNullOrEmpty(ft))
                        filter.SetFilterPart("ft", ft);
                   
                    contextRequest.FreeText = predicateString.Split(char.Parse("|"))[1];
                    var q1 = predicateString.Split(char.Parse("|"))[0];
                    if (!string.IsNullOrEmpty(q1))
                    {
                        filter.ProcessText(q1);
                    }
                }
                else {
                    filter.ProcessText(predicateString);
                }
				 var includesList = (new List<string>());
                 if (!string.IsNullOrEmpty(includes))
                 {
                     includesList = includes.Split(char.Parse(",")).ToList();
                 }

				List<SDCase> result = new List<SDCase>();
         
			QueryBuild(predicateString, filter, con, contextRequest, "getby", includesList);
			 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }
				
				
					OnGetting(con, e == null ? e = new BusinessRulesEventArgs<SDCase>() { Filter = filter, ContextRequest = contextRequest  } : e );

                  //OnGetting(con,e = new BusinessRulesEventArgs<SDCase>() {  ContextRequest = contextRequest, FilterExpressionString = predicateString });
			   	if (e != null) {
				    //predicateString = e.GetQueryString();
						if (e.Cancel)
						{
							context = null;
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				//	 else {
                //      predicateString = predicateString.Replace("*extraFreeText*", "").Replace("()","");
                //  }
				//con.EnableChangeTrackingUsingProxies = false;
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                //if (predicate == null) predicate = PredicateBuilder.True<SDCase>();
 				string fkIncludes = "SDPerson,SDCasePriority,SDCaseState";
                if(contextRequest!=null){
					if (contextRequest.CustomQuery != null)
					{
						if (contextRequest.CustomQuery.IncludeForeignKeyPaths != null) {
							if (contextRequest.CustomQuery.IncludeForeignKeyPaths.Value == false)
								fkIncludes = "";
						}
					}
				}else{
                    contextRequest = new ContextRequest();
                    contextRequest.CustomQuery = new CustomQuery();

                }
				if (!string.IsNullOrEmpty(includes))
					includes = includes + "," + fkIncludes;
				else
					includes = fkIncludes;
                
                //var es = _repository.Queryable;
				IQueryable<SDCase> query = con.SDCases.AsQueryable();
		
				// include relations FK
				if(string.IsNullOrEmpty(includes) ){
					includes ="";
				}
				StringBuilder sbQuerySystem = new StringBuilder();
                    //predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				

				//if (!string.IsNullOrEmpty(predicateString))
                //      sbQuerySystem.Append(" And ");
                //sbQuerySystem.Append(" (IsDeleted != true Or IsDeleted = null) ");
				 filter.SetFilterPart("de", "(IsDeleted != true OR IsDeleted = null)");


					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
	                    	if (contextRequest.User !=null )
	                        	if (contextRequest.Company != null ){
	                        		//if (sbQuerySystem.Length > 0)
	                        		//	    			sbQuerySystem.Append( " And ");	
									//sbQuerySystem.Append(@" (GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa

									filter.SetFilterPart("co",@"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))");

								}
						}	
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				//string predicateString = predicate.ToDynamicLinq<SDCase>();
				//predicateString += sbQuerySystem.ToString();
				filter.CleanAndProcess("");

				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed(); //SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicateString );               
                string predicateWithManyRelations = filter.GetFilterChildren(); //SFSdotNet.Framework.Linq.Utils.CleanPartExpression(predicateString);

                //QueryUtils.BreakeQuery1(predicateString, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
                var _queryable = query.AsQueryable();
				bool includeAll = true; 
                if (!string.IsNullOrEmpty(predicateWithManyRelations))
                    _queryable = _queryable.Where(predicateWithManyRelations, contextRequest.CustomQuery.ExtraParams);
				if (contextRequest.CustomQuery.SpecificProperties.Count > 0)
                {

				includeAll = false; 
                }

				StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append("new (");
                bool existPrev = false;
                foreach (var selected in contextRequest.CustomQuery.SelectedFields.Where(p=> !string.IsNullOrEmpty(p.Linq)))
                {
                    if (existPrev) sbSelect.Append(", ");
                    if (!selected.Linq.Contains(".") && !selected.Linq.StartsWith("it."))
                        sbSelect.Append("it." + selected.Linq);
                    else
                        sbSelect.Append(selected.Linq);
                    existPrev = true;
                }
                sbSelect.Append(")");
                var queryable = _queryable.Select(sbSelect.ToString());                    


     				
                 if (!string.IsNullOrEmpty(predicateWithFKAndComputed))
                    queryable = queryable.Where(predicateWithFKAndComputed, contextRequest.CustomQuery.ExtraParams);

				QueryComplementOptions queryOps = ContextQueryBuilder.ApplyContextQuery(contextRequest);
            	if (!string.IsNullOrEmpty(queryOps.OrderByAndSort)){
					if (queryOps.OrderBy.Contains(".") && !queryOps.OrderBy.StartsWith("it.")) queryOps.OrderBy = "it." + queryOps.OrderBy;
					queryable = queryable.OrderBy(queryOps.OrderByAndSort);
					}
               	if (queryOps.Skip != null)
                {
                    queryable = queryable.Skip(queryOps.Skip.Value);
                }
                if (queryOps.PageSize != null)
                {
                    queryable = queryable.Take (queryOps.PageSize.Value);
                }


                var resultTemp = queryable.AsQueryable().ToListAsync().Result;
                foreach (var item in resultTemp)
                {

				   result.Add(SFSdotNet.Framework.BR.Utils.GetConverted<SDCase,dynamic>(item, contextRequest.CustomQuery.SelectedFields.Select(p=>p.Name).ToArray()));
                }

			 if (e != null)
                {
                    e.Items = result;
                }
				 contextRequest.CustomQuery = new CustomQuery();
				OnTaken(this, e == null ? e = new BusinessRulesEventArgs<SDCase>() { Items= result, IncludingComputedLinq = true, ContextRequest = contextRequest, FilterExpressionString  = predicateString } :  e);
  
			
  
                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
	
	*/
	#endregion

            }
        }
		public SDCase GetFromOperation(string function, string filterString, string usemode, string fields, ContextRequest contextRequest)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
                string computedFields = "";
               // string fkIncludes = "accContpaqiClassification,accProjectConcept,accProjectType,accProxyUser";
                List<string> multilangProperties = new List<string>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					if (contextRequest != null && contextRequest.Company != null)
					{
						multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
						contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
					}
					 									
					string multiTenantField = "GuidCompany";


                return GetSummaryOperation(con, new SDCase(), function, filterString, usemode, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields, contextRequest, fields.Split(char.Parse(",")).ToArray());
            }
        }

   protected override void QueryBuild(string predicate, Filter filter, DbContext efContext, ContextRequest contextRequest, string method, List<string> includesList)
      	{
				if (contextRequest.CustomQuery.SpecificProperties.Count == 0)
                {
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.GuidCaseState);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.GuidPersonClient);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.ClosedDateTime);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.BodyContent);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.PreviewContent);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.GuidCasePriority);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.Title);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.GuidCompany);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.CreatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.UpdatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.CreatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.UpdatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.Bytes);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.IsDeleted);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.SDPerson);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.SDCasePriority);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCase.PropertyNames.SDCaseState);
                    
				}

				if (method == "getby" || method == "sum")
				{
					if (!contextRequest.CustomQuery.SpecificProperties.Contains("GuidCase")){
						contextRequest.CustomQuery.SpecificProperties.Add("GuidCase");
					}

					 if (!string.IsNullOrEmpty(contextRequest.CustomQuery.OrderBy))
					{
						string existPropertyOrderBy = contextRequest.CustomQuery.OrderBy;
						if (contextRequest.CustomQuery.OrderBy.Contains("."))
						{
							existPropertyOrderBy = contextRequest.CustomQuery.OrderBy.Split(char.Parse("."))[0];
						}
						if (!contextRequest.CustomQuery.SpecificProperties.Exists(p => p == existPropertyOrderBy))
						{
							contextRequest.CustomQuery.SpecificProperties.Add(existPropertyOrderBy);
						}
					}

				}
				
	bool isFullDetails = contextRequest.IsFromUI("SDCases", UIActions.GetForDetails);
	string filterForTest = predicate  + filter.GetFilterComplete();

				if (isFullDetails || !string.IsNullOrEmpty(predicate))
            {
            } 

			if (method == "sum")
            {
            } 
			if (contextRequest.CustomQuery.SelectedFields.Count == 0)
            {
				foreach (var selected in contextRequest.CustomQuery.SpecificProperties)
                {
					string linq = selected;
					switch (selected)
                    {

					case "SDPerson":
					if (includesList.Contains(selected)){
                        linq = "it.SDPerson as SDPerson";
					}
                    else
						linq = "iif(it.SDPerson != null, new (it.SDPerson.GuidPerson, it.SDPerson.DisplayName), null) as SDPerson";
 					break;
					case "SDCasePriority":
					if (includesList.Contains(selected)){
                        linq = "it.SDCasePriority as SDCasePriority";
					}
                    else
						linq = "new (it.SDCasePriority.GuidCasePriority, it.SDCasePriority.Title) as SDCasePriority";
 					break;
					case "SDCaseState":
					if (includesList.Contains(selected)){
                        linq = "it.SDCaseState as SDCaseState";
					}
                    else
						linq = "new (it.SDCaseState.GuidCaseState, it.SDCaseState.Title) as SDCaseState";
 					break;
					 
						
					 default:
                            break;
                    }
					contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name=selected, Linq=linq});
					if (method == "getby" || method == "sum")
					{
						if (includesList.Contains(selected))
							includesList.Remove(selected);

					}

				}
			}
				if (method == "getby" || method == "sum")
				{
					foreach (var otherInclude in includesList.Where(p=> !string.IsNullOrEmpty(p)))
					{
						contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name = otherInclude, Linq = "it." + otherInclude +" as " + otherInclude });
					}
				}
				BusinessRulesEventArgs<SDCase> e = null;
				if (contextRequest.PreventInterceptors == false)
					OnQuerySettings(efContext, e = new BusinessRulesEventArgs<SDCase>() { Filter = filter, ContextRequest = contextRequest /*, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null)*/ });

				//List<SDCase> result = new List<SDCase>();
                 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }

}
		public List<SDCase> GetBy(Expression<Func<SDCase, bool>> predicate, bool loadRelations, ContextRequest contextRequest)
        {
			if(!loadRelations)
				return GetBy(predicate, contextRequest);
			else
				return GetBy(predicate, contextRequest, "SDCaseFiles,SDCaseHistories");

        }

        public List<SDCase> GetBy(Expression<Func<SDCase, bool>> predicate, int? pageSize, int? page, string orderBy, SFSdotNet.Framework.Data.SortDirection? sortDirection)
        {
            return GetBy(predicate, new ContextRequest() { CustomQuery = new CustomQuery() { Page = page, PageSize = pageSize, OrderBy = orderBy, SortDirection = sortDirection } });
        }
        public List<SDCase> GetBy(Expression<Func<SDCase, bool>> predicate)
        {

			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
			contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
			            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            contextRequest.CustomQuery.FilterExpressionString = null;
            return this.GetBy(predicate, contextRequest, "");
        }
        #endregion
        #region Dynamic String
		protected override string GetSpecificFilter(string filter, ContextRequest contextRequest) {
            string result = "";
		    //string linqFilter = String.Empty;
            string freeTextFilter = String.Empty;
            if (filter.Contains("|"))
            {
               // linqFilter = filter.Split(char.Parse("|"))[0];
                freeTextFilter = filter.Split(char.Parse("|"))[1];
            }
            //else {
            //    freeTextFilter = filter;
            //}
            //else {
            //    linqFilter = filter;
            //}
			// linqFilter = SFSdotNet.Framework.Linq.Utils.ReplaceCustomDateFilters(linqFilter);
            //string specificFilter = linqFilter;
            if (!string.IsNullOrEmpty(freeTextFilter))
            {
                System.Text.StringBuilder sbCont = new System.Text.StringBuilder();
                /*if (specificFilter.Length > 0)
                {
                    sbCont.Append(" AND ");
                    sbCont.Append(" ({0})");
                }
                else
                {
                    sbCont.Append("{0}");
                }*/
                //var words = freeTextFilter.Split(char.Parse(" "));
				var word = freeTextFilter;
                System.Text.StringBuilder sbSpec = new System.Text.StringBuilder();
                 int nWords = 1;
				/*foreach (var word in words)
                {
					if (word.Length > 0){
                    if (sbSpec.Length > 0) sbSpec.Append(" AND ");
					if (words.Length > 1) sbSpec.Append("("); */
					
	
					
	
					
	
					
	
					
					
					
									
					sbSpec.Append(string.Format(@"BodyContent.Contains(""{0}"")", word));
					

					
					
										sbSpec.Append(" OR ");
					
									
					sbSpec.Append(string.Format(@"PreviewContent.Contains(""{0}"")", word));
					

					
	
					
					
										sbSpec.Append(" OR ");
					
									
					sbSpec.Append(string.Format(@"Title.Contains(""{0}"")", word));
					

					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
								sbSpec.Append(" OR ");
					
					//if (sbSpec.Length > 2)
					//	sbSpec.Append(" OR "); // test
					sbSpec.Append(string.Format(@"it.SDPerson.DisplayName.Contains(""{0}"")", word)+" OR "+string.Format(@"it.SDCasePriority.Title.Contains(""{0}"")", word)+" OR "+string.Format(@"it.SDCaseState.Title.Contains(""{0}"")", word));
								 //sbSpec.Append("*extraFreeText*");

                    /*if (words.Length > 1) sbSpec.Append(")");
					
					nWords++;

					}

                }*/
                //specificFilter = string.Format("{0}{1}", specificFilter, string.Format(sbCont.ToString(), sbSpec.ToString()));
                                 result = sbSpec.ToString();  
            }
			//result = specificFilter;
			
			return result;

		}
	
			public List<SDCase> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params object[] extraParams)
        {
			return GetBy(filter, pageSize, page, orderBy, orderDir,  null, extraParams);
		}
           public List<SDCase> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, string usemode, params object[] extraParams)
            { 
                return GetBy(filter, pageSize, page, orderBy, orderDir, usemode, null, extraParams);
            }


		public List<SDCase> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  string usemode, ContextRequest context, params object[] extraParams)

        {

            // string freetext = null;
            //if (filter.Contains("|"))
            //{
            //    int parts = filter.Split(char.Parse("|")).Count();
            //    if (parts > 1)
            //    {

            //        freetext = filter.Split(char.Parse("|"))[1];
            //    }
            //}
		
            //string specificFilter = "";
            //if (!string.IsNullOrEmpty(filter))
            //  specificFilter=  GetSpecificFilter(filter);
            if (string.IsNullOrEmpty(orderBy))
            {
			                orderBy = "UpdatedDate";
            }
			//orderDir = "desc";
			SFSdotNet.Framework.Data.SortDirection direction = SFSdotNet.Framework.Data.SortDirection.Ascending;
            if (!string.IsNullOrEmpty(orderDir))
            {
                if (orderDir == "desc")
                    direction = SFSdotNet.Framework.Data.SortDirection.Descending;
            }
            if (context == null)
                context = new ContextRequest();
			

             context.UseMode = usemode;
             if (context.CustomQuery == null )
                context.CustomQuery =new SFSdotNet.Framework.My.CustomQuery();

 
                context.CustomQuery.ExtraParams = extraParams;

                    context.CustomQuery.OrderBy = orderBy;
                   context.CustomQuery.SortDirection = direction;
                   context.CustomQuery.Page = page;
                  context.CustomQuery.PageSize = pageSize;
               

            

            if (!preventSecurityRestrictions) {
			 if (context.CurrentContext == null)
                {
					if (SFSdotNet.Framework.My.Context.CurrentContext != null &&  SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
					{
						context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
						context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

					}
					else {
						throw new Exception("The security rule require a specific user and company");
					}
				}
            }
            return GetBy(filter, context);
  
        }


        public List<SDCase> GetBy(string strWhere, ContextRequest contextRequest)
        {
        	#region old code
				
				 //Expression<Func<tvsReservationTransport, bool>> predicate = null;
				string strWhereClean = strWhere.Replace("*extraFreeText*", "").Replace("()", "");
                //if (!string.IsNullOrEmpty(strWhereClean)){

                //    object[] extraParams = null;
                //    //if (contextRequest != null )
                //    //    if (contextRequest.CustomQuery != null )
                //    //        extraParams = contextRequest.CustomQuery.ExtraParams;
                //    //predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<tvsReservationTransport, bool>(strWhereClean, extraParams != null? extraParams.Cast<Guid>(): null);				
                //}
				 if (contextRequest == null)
                {
                    contextRequest = new ContextRequest();
                    if (contextRequest.CustomQuery == null)
                        contextRequest.CustomQuery = new CustomQuery();
                }
                  if (!preventSecurityRestrictions) {
					if (contextRequest.User == null || contextRequest.Company == null)
                      {
                     if (SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
                     {
                         contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                         contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

                     }
                     else {
                         throw new Exception("The security rule require a specific User and Company ");
                     }
					 }
                 }
            contextRequest.CustomQuery.FilterExpressionString = strWhere;
				//return GetBy(predicate, contextRequest);  

			#endregion				
				
                    return GetBy(strWhere, contextRequest, "");  


        }
       public List<SDCase> GetBy(string strWhere)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
			
            return GetBy(strWhere, context, null);
        }

        public List<SDCase> GetBy(string strWhere, string includes)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
            return GetBy(strWhere, context, includes);
        }

        #endregion
        #endregion
		
		  #region SaveOrUpdate
        
 		 public SDCase Create(SDCase entity)
        {
				//ObjectContext context = null;
				    if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: Create");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

				return this.Create(entity, contextRequest);


        }
        
       
        public SDCase Create(SDCase entity, ContextRequest contextRequest)
        {
		
		bool graph = false;
	
				bool preventPartial = false;
                if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
               
			using (EFContext con = new EFContext()) {

				SDCase itemForSave = new SDCase();
#region Autos
		if(!preventSecurityRestrictions){

				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion
               BusinessRulesEventArgs<SDCase> e = null;
			    if (preventPartial == false )
                OnCreating(this,e = new BusinessRulesEventArgs<SDCase>() { ContextRequest = contextRequest, Item=entity });
				   if (e != null) {
						if (e.Cancel)
						{
							context = null;
							return e.Item;

						}
					}

                    if (entity.GuidCase == Guid.Empty)
                   {
                       entity.GuidCase = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   itemForSave.GuidCase = entity.GuidCase;
				  
		
			itemForSave.GuidCase = entity.GuidCase;

			itemForSave.ClosedDateTime = entity.ClosedDateTime;

			itemForSave.BodyContent = entity.BodyContent;

			itemForSave.PreviewContent = entity.PreviewContent;

			itemForSave.Title = entity.Title;

			itemForSave.GuidCompany = entity.GuidCompany;

			itemForSave.CreatedDate = entity.CreatedDate;

			itemForSave.UpdatedDate = entity.UpdatedDate;

			itemForSave.CreatedBy = entity.CreatedBy;

			itemForSave.UpdatedBy = entity.UpdatedBy;

			itemForSave.Bytes = entity.Bytes;

			itemForSave.IsDeleted = entity.IsDeleted;

				
				con.SDCases.Add(itemForSave);



					if (entity.SDPerson != null)
					{
						var sDPerson = new SDPerson();
						sDPerson.GuidPerson = entity.SDPerson.GuidPerson;
						itemForSave.SDPerson = sDPerson;
						SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDPerson>(con, itemForSave.SDPerson);
			
					}




					if (entity.SDCasePriority != null)
					{
						var sDCasePriority = new SDCasePriority();
						sDCasePriority.GuidCasePriority = entity.SDCasePriority.GuidCasePriority;
						itemForSave.SDCasePriority = sDCasePriority;
						SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCasePriority>(con, itemForSave.SDCasePriority);
			
					}




					if (entity.SDCaseState != null)
					{
						var sDCaseState = new SDCaseState();
						sDCaseState.GuidCaseState = entity.SDCaseState.GuidCaseState;
						itemForSave.SDCaseState = sDCaseState;
						SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCaseState>(con, itemForSave.SDCaseState);
			
					}







                
				con.ChangeTracker.Entries().Where(p => p.Entity != itemForSave && p.State != EntityState.Unchanged).ForEach(p => p.State = EntityState.Detached);

				con.Entry<SDCase>(itemForSave).State = EntityState.Added;

				con.SaveChanges();

					 
				

				//itemResult = entity;
                //if (e != null)
                //{
                 //   e.Item = itemResult;
                //}
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false )
                OnCreated(this, e == null ? e = new BusinessRulesEventArgs<SDCase>() { ContextRequest = contextRequest, Item = entity } : e);



                if (e != null && e.Item != null )
                {
                    return e.Item;
                }
                              return entity;
			}
            
        }
        //BusinessRulesEventArgs<SDCase> e = null;
        public void Create(List<SDCase> entities)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            Create(entities, contextRequest);
        }
        public void Create(List<SDCase> entities, ContextRequest contextRequest)
        
        {
			ObjectContext context = null;
            	foreach (SDCase entity in entities)
				{
					this.Create(entity, contextRequest);
				}
        }
		  public void CreateOrUpdateBulk(List<SDCase> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "cu", contextRequest);
        }

        private void CreateOrUpdateBulk(List<SDCase> entities, string actionKey, ContextRequest contextRequest)
        {
			if (entities.Count() > 0){
            bool graph = false;

            bool preventPartial = false;
            if (contextRequest != null && contextRequest.PreventInterceptors == true)
            {
                preventPartial = true;
            }
            foreach (var entity in entities)
            {
                    if (entity.GuidCase == Guid.Empty)
                   {
                       entity.GuidCase = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   
				  


#region Autos
		if(!preventSecurityRestrictions){


 if (actionKey != "u")
                        {
				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;


}
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion


		
			//entity.GuidCase = entity.GuidCase;

			//entity.ClosedDateTime = entity.ClosedDateTime;

			//entity.BodyContent = entity.BodyContent;

			//entity.PreviewContent = entity.PreviewContent;

			//entity.Title = entity.Title;

			//entity.GuidCompany = entity.GuidCompany;

			//entity.CreatedDate = entity.CreatedDate;

			//entity.UpdatedDate = entity.UpdatedDate;

			//entity.CreatedBy = entity.CreatedBy;

			//entity.UpdatedBy = entity.UpdatedBy;

			//entity.Bytes = entity.Bytes;

			//entity.IsDeleted = entity.IsDeleted;

				
				



				    if (entity.SDPerson != null)
					{
						//var sDPerson = new SDPerson();
						entity.GuidPersonClient = entity.SDPerson.GuidPerson;
						//entity.SDPerson = sDPerson;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDPerson>(con, itemForSave.SDPerson);
			
					}




				    if (entity.SDCasePriority != null)
					{
						//var sDCasePriority = new SDCasePriority();
						entity.GuidCasePriority = entity.SDCasePriority.GuidCasePriority;
						//entity.SDCasePriority = sDCasePriority;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCasePriority>(con, itemForSave.SDCasePriority);
			
					}




				    if (entity.SDCaseState != null)
					{
						//var sDCaseState = new SDCaseState();
						entity.GuidCaseState = entity.SDCaseState.GuidCaseState;
						//entity.SDCaseState = sDCaseState;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCaseState>(con, itemForSave.SDCaseState);
			
					}







                
				

					 
				

				//itemResult = entity;
            }
            using (EFContext con = new EFContext())
            {
                 if (actionKey == "c")
                    {
                        context.BulkInsert(entities);
                    }else if ( actionKey == "u")
                    {
                        context.BulkUpdate(entities);
                    }else
                    {
                        context.BulkInsertOrUpdate(entities);
                    }
            }

			}
        }
	
		public void CreateBulk(List<SDCase> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "c", contextRequest);
        }


		public void UpdateAgile(SDCase item, params string[] fields)
         {
			UpdateAgile(item, null, fields);
        }
		public void UpdateAgile(SDCase item, ContextRequest contextRequest, params string[] fields)
         {
            
             ContextRequest contextNew = null;
             if (contextRequest != null)
             {
                 contextNew = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
                 if (fields != null && fields.Length > 0)
                 {
                     contextNew.CustomQuery.SpecificProperties  = fields.ToList();
                 }
                 else if(contextRequest.CustomQuery.SpecificProperties.Count > 0)
                 {
                     fields = contextRequest.CustomQuery.SpecificProperties.ToArray();
                 }
             }
			

		   using (EFContext con = new EFContext())
            {



               
					List<string> propForCopy = new List<string>();
                    propForCopy.AddRange(fields);
                    
					  
					if (!propForCopy.Contains("GuidCase"))
						propForCopy.Add("GuidCase");
					if (!propForCopy.Contains("GuidCaseState"))
						propForCopy.Add("GuidCaseState");
					if (!propForCopy.Contains("GuidCasePriority"))
						propForCopy.Add("GuidCasePriority");
					if (!propForCopy.Contains("SDCasePriority"))
						propForCopy.Add("SDCasePriority");
					if (!propForCopy.Contains("SDCaseState"))
						propForCopy.Add("SDCaseState");

					var itemForUpdate = SFSdotNet.Framework.BR.Utils.GetConverted<SDCase,SDCase>(item, propForCopy.ToArray());
					 itemForUpdate.GuidCase = item.GuidCase;
                  var setT = con.Set<SDCase>().Attach(itemForUpdate);

					if (fields.Count() > 0)
					  {
						  item.ModifiedProperties = fields;
					  }
                    foreach (var property in item.ModifiedProperties)
					{						
                        if (property != "GuidCase")
                             con.Entry(setT).Property(property).IsModified = true;

                    }

                
               int result = con.SaveChanges();
               if (result != 1)
               {
                   SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: 1");
               }


            }

			OnUpdatedAgile(this, new BusinessRulesEventArgs<SDCase>() { Item = item, ContextRequest = contextNew  });

         }
		public void UpdateBulk(List<SDCase>  items, params string[] fields)
         {
             SFSdotNet.Framework.My.ContextRequest req = new SFSdotNet.Framework.My.ContextRequest();
             req.CustomQuery = new SFSdotNet.Framework.My.CustomQuery();
             foreach (var field in fields)
             {
                 req.CustomQuery.SpecificProperties.Add(field);
             }
             UpdateBulk(items, req);

         }

		 public void DeleteBulk(List<SDCase> entities, ContextRequest contextRequest = null)
        {

            using (EFContext con = new EFContext())
            {
                foreach (var entity in entities)
                {
					var entityProxy = new SDCase() { GuidCase = entity.GuidCase };

                    con.Entry<SDCase>(entityProxy).State = EntityState.Deleted;

                }

                int result = con.SaveChanges();
                if (result != entities.Count)
                {
                    SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: " + entities.Count.ToString());
                }
            }

        }

        public void UpdateBulk(List<SDCase> items, ContextRequest contextRequest)
        {
            if (items.Count() > 0){

			 foreach (var entity in items)
            {


#region Autos
		if(!preventSecurityRestrictions){

				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	



			}
#endregion




				    if (entity.SDPerson != null)
					{
						//var sDPerson = new SDPerson();
						entity.GuidPersonClient = entity.SDPerson.GuidPerson;
						//entity.SDPerson = sDPerson;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDPerson>(con, itemForSave.SDPerson);
			
					}




				    if (entity.SDCasePriority != null)
					{
						//var sDCasePriority = new SDCasePriority();
						entity.GuidCasePriority = entity.SDCasePriority.GuidCasePriority;
						//entity.SDCasePriority = sDCasePriority;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCasePriority>(con, itemForSave.SDCasePriority);
			
					}




				    if (entity.SDCaseState != null)
					{
						//var sDCaseState = new SDCaseState();
						entity.GuidCaseState = entity.SDCaseState.GuidCaseState;
						//entity.SDCaseState = sDCaseState;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCaseState>(con, itemForSave.SDCaseState);
			
					}







				}
				using (EFContext con = new EFContext())
				{

                    
                
                   con.BulkUpdate(items);

				}
             
			}	  
        }

         public SDCase Update(SDCase entity)
        {
            if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return Update(entity, contextRequest);
        }
       
         public SDCase Update(SDCase entity, ContextRequest contextRequest)
        {
		 if ((System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null) && contextRequest == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Update");
            }
            if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            }

			
				SDCase  itemResult = null;

	
			//entity.UpdatedDate = DateTime.Now.ToUniversalTime();
			//if(contextRequest.User != null)
				//entity.UpdatedBy = contextRequest.User.GuidUser;

//	    var oldentity = GetBy(p => p.GuidCase == entity.GuidCase, contextRequest).FirstOrDefault();
	//	if (oldentity != null) {
		
          //  entity.CreatedDate = oldentity.CreatedDate;
    //        entity.CreatedBy = oldentity.CreatedBy;
	
      //      entity.GuidCompany = oldentity.GuidCompany;
	
			

	
		//}

			 using( EFContext con = new EFContext()){
				BusinessRulesEventArgs<SDCase> e = null;
				bool preventPartial = false; 
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false)
                OnUpdating(this,e = new BusinessRulesEventArgs<SDCase>() { ContextRequest = contextRequest, Item=entity});
				   if (e != null) {
						if (e.Cancel)
						{
							//outcontext = null;
							return e.Item;

						}
					}

	string includes = "SDPerson,SDCasePriority,SDCaseState";
	IQueryable < SDCase > query = con.SDCases.AsQueryable();
	foreach (string include in includes.Split(char.Parse(",")))
                       {
                           if (!string.IsNullOrEmpty(include))
                               query = query.Include(include);
                       }
	var oldentity = query.FirstOrDefault(p => p.GuidCase == entity.GuidCase);
	if (oldentity.ClosedDateTime != entity.ClosedDateTime)
		oldentity.ClosedDateTime = entity.ClosedDateTime;
	if (oldentity.BodyContent != entity.BodyContent)
		oldentity.BodyContent = entity.BodyContent;
	if (oldentity.PreviewContent != entity.PreviewContent)
		oldentity.PreviewContent = entity.PreviewContent;
	if (oldentity.Title != entity.Title)
		oldentity.Title = entity.Title;

				//if (entity.UpdatedDate == null || (contextRequest != null && contextRequest.IsFromUI("SDCases", UIActions.Updating)))
			oldentity.UpdatedDate = DateTime.Now.ToUniversalTime();
			if(contextRequest.User != null)
				oldentity.UpdatedBy = contextRequest.User.GuidUser;

           


						if (SFSdotNet.Framework.BR.Utils.HasRelationPropertyChanged(oldentity.SDPerson, entity.SDPerson, "GuidPerson"))
							oldentity.SDPerson = entity.SDPerson != null? new SDPerson(){ GuidPerson = entity.SDPerson.GuidPerson } :null;

                


						if (SFSdotNet.Framework.BR.Utils.HasRelationPropertyChanged(oldentity.SDCasePriority, entity.SDCasePriority, "GuidCasePriority"))
							oldentity.SDCasePriority = entity.SDCasePriority != null? new SDCasePriority(){ GuidCasePriority = entity.SDCasePriority.GuidCasePriority } :null;

                


						if (SFSdotNet.Framework.BR.Utils.HasRelationPropertyChanged(oldentity.SDCaseState, entity.SDCaseState, "GuidCaseState"))
							oldentity.SDCaseState = entity.SDCaseState != null? new SDCaseState(){ GuidCaseState = entity.SDCaseState.GuidCaseState } :null;

                


				if (entity.SDCaseFiles != null)
                {
                    foreach (var item in entity.SDCaseFiles)
                    {


                        
                    }
					
                    

                }


				if (entity.SDCaseHistories != null)
                {
                    foreach (var item in entity.SDCaseHistories)
                    {


                        
                    }
					
                    

                }


				con.ChangeTracker.Entries().Where(p => p.Entity != oldentity).ForEach(p => p.State = EntityState.Unchanged);  
				  
				con.SaveChanges();
        
					 
					
               
				itemResult = entity;
				if(preventPartial == false)
					OnUpdated(this, e = new BusinessRulesEventArgs<SDCase>() { ContextRequest = contextRequest, Item=itemResult });

              	return itemResult;
			}
			  
        }
        public SDCase Save(SDCase entity)
        {
			return Create(entity);
        }
        public int Save(List<SDCase> entities)
        {
			 Create(entities);
            return entities.Count;

        }
        #endregion
        #region Delete
        public void Delete(SDCase entity)
        {
				this.Delete(entity, null);
			
        }
		 public void Delete(SDCase entity, ContextRequest contextRequest)
        {
				
				  List<SDCase> entities = new List<SDCase>();
				   entities.Add(entity);
				this.Delete(entities, contextRequest);
			
        }

         public void Delete(string query, Guid[] guids, ContextRequest contextRequest)
        {
			var br = new SDCasesBR(true);
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);
            
            Delete(items, contextRequest);

        }
        public void Delete(SDCase entity,  ContextRequest contextRequest, BusinessRulesEventArgs<SDCase> e = null)
        {
			
				using(EFContext con = new EFContext())
                 {
				
               	BusinessRulesEventArgs<SDCase> _e = null;
               List<SDCase> _items = new List<SDCase>();
                _items.Add(entity);
                if (e == null || e.PreventPartialPropagate == false)
                {
                    OnDeleting(this, _e = (e == null ? new BusinessRulesEventArgs<SDCase>() { ContextRequest = contextRequest, Item = entity, Items = null  } : e));
                }
                if (_e != null)
                {
                    if (_e.Cancel)
						{
							context = null;
							return;

						}
					}


				
									//IsDeleted
					bool logicDelete = true;
					if (entity.IsDeleted != null)
					{
						if (entity.IsDeleted.Value)
							logicDelete = false;
					}
					if (logicDelete)
					{
											//entity = GetBy(p =>, contextRequest).FirstOrDefault();
						entity.IsDeleted = true;
						if (contextRequest != null && contextRequest.User != null)
							entity.UpdatedBy = contextRequest.User.GuidUser;
                        entity.UpdatedDate = DateTime.UtcNow;
						UpdateAgile(entity, "IsDeleted","UpdatedBy","UpdatedDate");

						
					}
					else {
					con.Entry<SDCase>(entity).State = EntityState.Deleted;
					con.SaveChanges();
				
				 
					}
								
				
				 
					
					
			if (e == null || e.PreventPartialPropagate == false)
                {

                    if (_e == null)
                        _e = new BusinessRulesEventArgs<SDCase>() { ContextRequest = contextRequest, Item = entity, Items = null };

                    OnDeleted(this, _e);
                }

				//return null;
			}
        }
 public void UnDelete(string query, Guid[] guids, ContextRequest contextRequest)
        {
            var br = new SDCasesBR(true);
            contextRequest.CustomQuery.IncludeDeleted = true;
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);

            foreach (var item in items)
            {
                item.IsDeleted = false;
						if (contextRequest != null && contextRequest.User != null)
							item.UpdatedBy = contextRequest.User.GuidUser;
                        item.UpdatedDate = DateTime.UtcNow;
            }

            UpdateBulk(items, "IsDeleted","UpdatedBy","UpdatedDate");
        }

         public void Delete(List<SDCase> entities,  ContextRequest contextRequest = null )
        {
				
			 BusinessRulesEventArgs<SDCase> _e = null;

                OnDeleting(this, _e = new BusinessRulesEventArgs<SDCase>() { ContextRequest = contextRequest, Item = null, Items = entities });
                if (_e != null)
                {
                    if (_e.Cancel)
                    {
                        context = null;
                        return;

                    }
                }
                bool allSucced = true;
                BusinessRulesEventArgs<SDCase> eToChilds = new BusinessRulesEventArgs<SDCase>();
                if (_e != null)
                {
                    eToChilds = _e;
                }
                else
                {
                    eToChilds = new BusinessRulesEventArgs<SDCase>() { ContextRequest = contextRequest, Item = (entities.Count == 1 ? entities[0] : null), Items = entities };
                }
				foreach (SDCase item in entities)
				{
					try
                    {
                        this.Delete(item, contextRequest, e: eToChilds);
                    }
                    catch (Exception ex)
                    {
                        SFSdotNet.Framework.My.EventLog.Error(ex);
                        allSucced = false;
                    }
				}
				if (_e == null)
                    _e = new BusinessRulesEventArgs<SDCase>() { ContextRequest = contextRequest, CountResult = entities.Count, Item = null, Items = entities };
                OnDeleted(this, _e);

			
        }
        #endregion
 
        #region GetCount
		 public int GetCount(Expression<Func<SDCase, bool>> predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

			return GetCount(predicate, contextRequest);
		}
        public int GetCount(Expression<Func<SDCase, bool>> predicate, ContextRequest contextRequest)
        {


		
		 using (EFContext con = new EFContext())
            {


				if (predicate == null) predicate = PredicateBuilder.True<SDCase>();
           		predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted == null);
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    		if (contextRequest.User !=null )
                        		if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
									predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa

								}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				
				IQueryable<SDCase> query = con.SDCases.AsQueryable();
                return query.AsExpandable().Count(predicate);

			
				}
			

        }
		  public int GetCount(string predicate,  ContextRequest contextRequest)
         {
             return GetCount(predicate, null, contextRequest);
         }

         public int GetCount(string predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return GetCount(predicate, contextRequest);
        }
		 public int GetCount(string predicate, string usemode){
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
				return GetCount( predicate,  usemode,  contextRequest);
		 }
        public int GetCount(string predicate, string usemode, ContextRequest contextRequest){

		using (EFContext con = new EFContext()) {
				string computedFields = "";
				string fkIncludes = "SDPerson,SDCasePriority,SDCaseState";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDCase>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetCount(con, predicate, usemode, contextRequest, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields);

			}
			#region old code
			 /* string freetext = null;
            Filter filter = new Filter();

              if (predicate.Contains("|"))
              {
                 
                  filter.SetFilterPart("ft", GetSpecificFilter(predicate, contextRequest));
                 
                  filter.ProcessText(predicate.Split(char.Parse("|"))[0]);
                  freetext = predicate.Split(char.Parse("|"))[1];

				  if (!string.IsNullOrEmpty(freetext) && string.IsNullOrEmpty(contextRequest.FreeText))
                  {
                      contextRequest.FreeText = freetext;
                  }
              }
              else {
                  filter.ProcessText(predicate);
              }
			   predicate = filter.GetFilterComplete();
			// BusinessRulesEventArgs<SDCase>  e = null;
           	using (EFContext con = new EFContext())
			{
			
			

			 QueryBuild(predicate, filter, con, contextRequest, "count", new List<string>());


			
			BusinessRulesEventArgs<SDCase> e = null;

			contextRequest.FreeText = freetext;
			contextRequest.UseMode = usemode;
            OnCounting(this, e = new BusinessRulesEventArgs<SDCase>() {  Filter =filter, ContextRequest = contextRequest });
            if (e != null)
            {
                if (e.Cancel)
                {
                    context = null;
                    return e.CountResult;

                }

            

            }
			
			StringBuilder sbQuerySystem = new StringBuilder();
		
					
                    filter.SetFilterPart("de","(IsDeleted != true OR IsDeleted == null)");
			
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    	if (contextRequest.User !=null )
                        	if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
                        		
								filter.SetFilterPart("co", @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa
						
						
							}
							
							}
							if (preventSecurityRestrictions) preventSecurityRestrictions= false;
		
				   
                 filter.CleanAndProcess("");
				//string predicateWithFKAndComputed = SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicate );               
				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed();
               string predicateWithManyRelations = filter.GetFilterChildren();
			   ///QueryUtils.BreakeQuery1(predicate, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
			   predicate = filter.GetFilterComplete();
               if (!string.IsNullOrEmpty(predicate))
               {
				
					
                    return con.SDCases.Where(predicate).Count();
					
                }else
                    return con.SDCases.Count();
					
			}*/
			#endregion

		}
         public int GetCount()
        {
            return GetCount(p => true);
        }
        #endregion
        
         


        public void Delete(List<SDCase.CompositeKey> entityKeys)
        {

            List<SDCase> items = new List<SDCase>();
            foreach (var itemKey in entityKeys)
            {
                items.Add(GetByKey(itemKey.GuidCase));
            }

            Delete(items);

        }
		 public void UpdateAssociation(string relation, string relationValue, string query, Guid[] ids, ContextRequest contextRequest)
        {
            var items = GetBy(query, null, null, null, null, null, contextRequest, ids);
			 var module = SFSdotNet.Framework.Cache.Caching.SystemObjects.GetModuleByKey(SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(System.Web.HttpContext.Current.Request.RequestContext, "area"));
           
            foreach (var item in items)
            {
			  Guid ? guidRelationValue = null ;
                if (!string.IsNullOrEmpty(relationValue)){
                    guidRelationValue = Guid.Parse(relationValue );
                }

				 if (relation.Contains("."))
                {
                    var partsWithOtherProp = relation.Split(char.Parse("|"));
                    var parts = partsWithOtherProp[0].Split(char.Parse("."));

                    string proxyRelName = parts[0];
                    string proxyProperty = parts[1];
                    string proxyPropertyKeyNameFromOther = partsWithOtherProp[1];
                    //string proxyPropertyThis = parts[2];

                    var prop = item.GetType().GetProperty(proxyRelName);
                    //var entityInfo = //SFSdotNet.Framework.
                    // descubrir el tipo de entidad dentro de la colección
                    Type typeEntityInList = SFSdotNet.Framework.Entities.Utils.GetTypeFromList(prop);
                    var newProxyItem = Activator.CreateInstance(typeEntityInList);
                    var propThisForSet = newProxyItem.GetType().GetProperty(proxyProperty);
                    var entityInfoOfProxy = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(typeEntityInList);
                    var propOther = newProxyItem.GetType().GetProperty(proxyPropertyKeyNameFromOther);

                    if (propThisForSet != null && entityInfoOfProxy != null && propOther != null )
                    {
                        var entityInfoThis = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(item.GetType());
                        var valueThisId = item.GetType().GetProperty(entityInfoThis.PropertyKeyName).GetValue(item);
                        if (valueThisId != null)
                            propThisForSet.SetValue(newProxyItem, valueThisId);
                        propOther.SetValue(newProxyItem, Guid.Parse(relationValue));
                        
                        var entityNameProp = newProxyItem.GetType().GetField("EntityName").GetValue(null);
                        var entitySetNameProp = newProxyItem.GetType().GetField("EntitySetName").GetValue(null);

                        SFSdotNet.Framework.Apps.Integration.CreateItemFromApp(entityNameProp.ToString(), entitySetNameProp.ToString(), module.ModuleNamespace, newProxyItem, contextRequest);

                    }

                    // crear una instancia del tipo de entidad
                    // llenar los datos y registrar nuevo


                }
                else
                {
                var prop = item.GetType().GetProperty(relation);
                var entityInfo = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(prop.PropertyType);
                if (entityInfo != null)
                {
                    var ins = Activator.CreateInstance(prop.PropertyType);
                   if (guidRelationValue != null)
                    {
                        prop.PropertyType.GetProperty(entityInfo.PropertyKeyName).SetValue(ins, guidRelationValue);
                        item.GetType().GetProperty(relation).SetValue(item, ins);
                    }
                    else
                    {
                        item.GetType().GetProperty(relation).SetValue(item, null);
                    }

                    Update(item, contextRequest);
                }

				}
            }
        }
		
	}
		public partial class SDCaseFilesBR:BRBase<SDCaseFile>{
	 	
           
		 #region Partial methods

           partial void OnUpdating(object sender, BusinessRulesEventArgs<SDCaseFile> e);

            partial void OnUpdated(object sender, BusinessRulesEventArgs<SDCaseFile> e);
			partial void OnUpdatedAgile(object sender, BusinessRulesEventArgs<SDCaseFile> e);

            partial void OnCreating(object sender, BusinessRulesEventArgs<SDCaseFile> e);
            partial void OnCreated(object sender, BusinessRulesEventArgs<SDCaseFile> e);

            partial void OnDeleting(object sender, BusinessRulesEventArgs<SDCaseFile> e);
            partial void OnDeleted(object sender, BusinessRulesEventArgs<SDCaseFile> e);

            partial void OnGetting(object sender, BusinessRulesEventArgs<SDCaseFile> e);
            protected override void OnVirtualGetting(object sender, BusinessRulesEventArgs<SDCaseFile> e)
            {
                OnGetting(sender, e);
            }
			protected override void OnVirtualCounting(object sender, BusinessRulesEventArgs<SDCaseFile> e)
            {
                OnCounting(sender, e);
            }
			partial void OnTaken(object sender, BusinessRulesEventArgs<SDCaseFile> e);
			protected override void OnVirtualTaken(object sender, BusinessRulesEventArgs<SDCaseFile> e)
            {
                OnTaken(sender, e);
            }

            partial void OnCounting(object sender, BusinessRulesEventArgs<SDCaseFile> e);
 
			partial void OnQuerySettings(object sender, BusinessRulesEventArgs<SDCaseFile> e);
          
            #endregion
			
		private static SDCaseFilesBR singlenton =null;
				public static SDCaseFilesBR NewInstance(){
					return  new SDCaseFilesBR();
					
				}
		public static SDCaseFilesBR Instance{
			get{
				if (singlenton == null)
					singlenton = new SDCaseFilesBR();
				return singlenton;
			}
		}
		//private bool preventSecurityRestrictions = false;
		 public bool PreventAuditTrail { get; set;  }
		#region Fields
        EFContext context = null;
        #endregion
        #region Constructor
        public SDCaseFilesBR()
        {
            context = new EFContext();
        }
		 public SDCaseFilesBR(bool preventSecurity)
            {
                this.preventSecurityRestrictions = preventSecurity;
				context = new EFContext();
            }
        #endregion
		
		#region Get

 		public IQueryable<SDCaseFile> Get()
        {
            using (EFContext con = new EFContext())
            {
				
				var query = con.SDCaseFiles.AsQueryable();
                con.Configuration.ProxyCreationEnabled = false;

                //query = ContextQueryBuilder<Nutrient>.ApplyContextQuery(query, contextRequest);

                return query;




            }

        }
		


 	
		public List<SDCaseFile> GetAll()
        {
            return this.GetBy(p => true);
        }
        public List<SDCaseFile> GetAll(string includes)
        {
            return this.GetBy(p => true, includes);
        }
        public SDCaseFile GetByKey(Guid guidCasefile)
        {
            return GetByKey(guidCasefile, true);
        }
        public SDCaseFile GetByKey(Guid guidCasefile, bool loadIncludes)
        {
            SDCaseFile item = null;
			var query = PredicateBuilder.True<SDCaseFile>();
                    
			string strWhere = @"GuidCasefile = Guid(""" + guidCasefile.ToString()+@""")";
            Expression<Func<SDCaseFile, bool>> predicate = null;
            //if (!string.IsNullOrEmpty(strWhere))
            //    predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDCaseFile, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
			 ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
            contextRequest.CustomQuery.FilterExpressionString = strWhere;

			//item = GetBy(predicate, loadIncludes, contextRequest).FirstOrDefault();
			item = GetBy(strWhere,loadIncludes,contextRequest).FirstOrDefault();
            return item;
        }
         public List<SDCaseFile> GetBy(string strWhere, bool loadRelations, ContextRequest contextRequest)
        {
            if (!loadRelations)
                return GetBy(strWhere, contextRequest);
            else
                return GetBy(strWhere, contextRequest, "");

        }
		  public List<SDCaseFile> GetBy(string strWhere, bool loadRelations)
        {
              if (!loadRelations)
                return GetBy(strWhere, new ContextRequest());
            else
                return GetBy(strWhere, new ContextRequest(), "");

        }
		         public SDCaseFile GetByKey(Guid guidCasefile, params Expression<Func<SDCaseFile, object>>[] includes)
        {
            SDCaseFile item = null;
			string strWhere = @"GuidCasefile = Guid(""" + guidCasefile.ToString()+@""")";
          Expression<Func<SDCaseFile, bool>> predicate = p=> p.GuidCasefile == guidCasefile;
           // if (!string.IsNullOrEmpty(strWhere))
           //     predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDCaseFile, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
        item = GetBy(predicate, includes).FirstOrDefault();
         ////   item = GetBy(strWhere,includes).FirstOrDefault();
			return item;

        }
        public SDCaseFile GetByKey(Guid guidCasefile, string includes)
        {
            SDCaseFile item = null;
			string strWhere = @"GuidCasefile = Guid(""" + guidCasefile.ToString()+@""")";
            
			
            item = GetBy(strWhere, includes).FirstOrDefault();
            return item;

        }
		 public SDCaseFile GetByKey(Guid guidCasefile, string usemode, string includes)
		{
			return GetByKey(guidCasefile, usemode, null, includes);

		 }
		 public SDCaseFile GetByKey(Guid guidCasefile, string usemode, ContextRequest context,  string includes)
        {
            SDCaseFile item = null;
			string strWhere = @"GuidCasefile = Guid(""" + guidCasefile.ToString()+@""")";
			if (context == null){
				context = new ContextRequest();
				context.CustomQuery = new CustomQuery();
				context.CustomQuery.IsByKey = true;
				context.CustomQuery.FilterExpressionString = strWhere;
				context.UseMode = usemode;
			}
            item = GetBy(strWhere,context , includes).FirstOrDefault();
            return item;

        }

        #region Dynamic Predicate
        public List<SDCaseFile> GetBy(Expression<Func<SDCaseFile, bool>> predicate, int? pageSize, int? page)
        {
            return this.GetBy(predicate, pageSize, page, null, null);
        }
        public List<SDCaseFile> GetBy(Expression<Func<SDCaseFile, bool>> predicate, ContextRequest contextRequest)
        {

            return GetBy(predicate, contextRequest,"");
        }
        
        public List<SDCaseFile> GetBy(Expression<Func<SDCaseFile, bool>> predicate, ContextRequest contextRequest, params Expression<Func<SDCaseFile, object>>[] includes)
        {
            StringBuilder sb = new StringBuilder();
           if (includes != null)
            {
                foreach (var path in includes)
                {

						if (sb.Length > 0) sb.Append(",");
						sb.Append(SFSdotNet.Framework.Linq.Utils.IncludeToString<SDCaseFile>(path));

               }
            }
            return GetBy(predicate, contextRequest, sb.ToString());
        }
        
        
        public List<SDCaseFile> GetBy(Expression<Func<SDCaseFile, bool>> predicate, string includes)
        {
			ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";

            return GetBy(predicate, context, includes);
        }

        public List<SDCaseFile> GetBy(Expression<Func<SDCaseFile, bool>> predicate, params Expression<Func<SDCaseFile, object>>[] includes)
        {
			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest context = new ContextRequest();
			            context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";
            return GetBy(predicate, context, includes);
        }

      
		public bool DisableCache { get; set; }
		public List<SDCaseFile> GetBy(Expression<Func<SDCaseFile, bool>> predicate, ContextRequest contextRequest, string includes)
		{
            using (EFContext con = new EFContext()) {
				
				string fkIncludes = "SDCase,SDFile";
                List<string> multilangProperties = new List<string>();
				if (predicate == null) predicate = PredicateBuilder.True<SDCaseFile>();
                var notDeletedExpression = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;
					Expression<Func<SDCaseFile,bool>> multitenantExpression  = null;
					if (contextRequest != null && contextRequest.Company != null)	                        	
						multitenantExpression = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicate, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression);

#region Old code
/*
				List<SDCaseFile> result = null;
               BusinessRulesEventArgs<SDCaseFile>  e = null;
	
				OnGetting(con, e = new BusinessRulesEventArgs<SDCaseFile>() {  FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null) });

               // OnGetting(con,e = new BusinessRulesEventArgs<SDCaseFile>() { FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = contextRequest.CustomQuery.FilterExpressionString});
				   if (e != null) {
				    predicate = e.FilterExpression;
						if (e.Cancel)
						{
							context = null;
							 if (e.Items == null) e.Items = new List<SDCaseFile>();
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                if (predicate == null) predicate = PredicateBuilder.True<SDCaseFile>();
 				string fkIncludes = "SDCase,SDFile";
                if(contextRequest!=null){
					if (contextRequest.CustomQuery != null)
					{
						if (contextRequest.CustomQuery.IncludeForeignKeyPaths != null) {
							if (contextRequest.CustomQuery.IncludeForeignKeyPaths.Value == false)
								fkIncludes = "";
						}
					}
				}
				if (!string.IsNullOrEmpty(includes))
					includes = includes + "," + fkIncludes;
				else
					includes = fkIncludes;
                
                //var es = _repository.Queryable;

                IQueryable<SDCaseFile> query =  con.SDCaseFiles.AsQueryable();

                                if (!string.IsNullOrEmpty(includes))
                {
                    foreach (string include in includes.Split(char.Parse(",")))
                    {
						if (!string.IsNullOrEmpty(include))
                            query = query.Include(include);
                    }
                }
                    predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
					 	if (!preventSecurityRestrictions)
						{
							if (contextRequest != null )
		                    	if (contextRequest.User !=null )
		                        	if (contextRequest.Company != null){
		                        	
										predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
 									
									}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				query =query.AsExpandable().Where(predicate);
                query = ContextQueryBuilder<SDCaseFile>.ApplyContextQuery(query, contextRequest);

                result = query.AsNoTracking().ToList<SDCaseFile>();
				  
                if (e != null)
                {
                    e.Items = result;
                }
				//if (contextRequest != null ){
				//	 contextRequest = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
					contextRequest.CustomQuery = new CustomQuery();

				//}
				OnTaken(this, e == null ? e =  new BusinessRulesEventArgs<SDCaseFile>() { Items= result, IncludingComputedLinq = false, ContextRequest = contextRequest,  FilterExpression = predicate } :  e);
  
			

                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
				*/
#endregion
            }
        }


		/*public int Update(List<SDCaseFile> items, ContextRequest contextRequest)
            {
                int result = 0;
                using (EFContext con = new EFContext())
                {
                   
                

                    foreach (var item in items)
                    {
                        //secMessageToUser messageToUser = new secMessageToUser();
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            item.GetType().GetProperty(prop).SetValue(item, item.GetType().GetProperty(prop).GetValue(item));
                        }
                        //messageToUser.GuidMessageToUser = (Guid)item.GetType().GetProperty("GuidMessageToUser").GetValue(item);

                        var setObject = con.CreateObjectSet<SDCaseFile>("SDCaseFiles");
                        //messageToUser.Readed = DateTime.UtcNow;
                        setObject.Attach(item);
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            con.ObjectStateManager.GetObjectStateEntry(item).SetModifiedProperty(prop);
                        }
                       
                    }
                    result = con.SaveChanges();

                    


                }
                return result;
            }
           */
		

        public List<SDCaseFile> GetBy(string predicateString, ContextRequest contextRequest, string includes)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
				


				string computedFields = "";
				string fkIncludes = "SDCase,SDFile";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDCaseFile>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					//if (contextRequest != null && contextRequest.Company != null)                      	
					//	 multitenantExpression = @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))";
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicateString, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression,computedFields);


	#region Old Code
	/*
				BusinessRulesEventArgs<SDCaseFile> e = null;

				Filter filter = new Filter();
                if (predicateString.Contains("|"))
                {
                    string ft = GetSpecificFilter(predicateString, contextRequest);
                    if (!string.IsNullOrEmpty(ft))
                        filter.SetFilterPart("ft", ft);
                   
                    contextRequest.FreeText = predicateString.Split(char.Parse("|"))[1];
                    var q1 = predicateString.Split(char.Parse("|"))[0];
                    if (!string.IsNullOrEmpty(q1))
                    {
                        filter.ProcessText(q1);
                    }
                }
                else {
                    filter.ProcessText(predicateString);
                }
				 var includesList = (new List<string>());
                 if (!string.IsNullOrEmpty(includes))
                 {
                     includesList = includes.Split(char.Parse(",")).ToList();
                 }

				List<SDCaseFile> result = new List<SDCaseFile>();
         
			QueryBuild(predicateString, filter, con, contextRequest, "getby", includesList);
			 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }
				
				
					OnGetting(con, e == null ? e = new BusinessRulesEventArgs<SDCaseFile>() { Filter = filter, ContextRequest = contextRequest  } : e );

                  //OnGetting(con,e = new BusinessRulesEventArgs<SDCaseFile>() {  ContextRequest = contextRequest, FilterExpressionString = predicateString });
			   	if (e != null) {
				    //predicateString = e.GetQueryString();
						if (e.Cancel)
						{
							context = null;
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				//	 else {
                //      predicateString = predicateString.Replace("*extraFreeText*", "").Replace("()","");
                //  }
				//con.EnableChangeTrackingUsingProxies = false;
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                //if (predicate == null) predicate = PredicateBuilder.True<SDCaseFile>();
 				string fkIncludes = "SDCase,SDFile";
                if(contextRequest!=null){
					if (contextRequest.CustomQuery != null)
					{
						if (contextRequest.CustomQuery.IncludeForeignKeyPaths != null) {
							if (contextRequest.CustomQuery.IncludeForeignKeyPaths.Value == false)
								fkIncludes = "";
						}
					}
				}else{
                    contextRequest = new ContextRequest();
                    contextRequest.CustomQuery = new CustomQuery();

                }
				if (!string.IsNullOrEmpty(includes))
					includes = includes + "," + fkIncludes;
				else
					includes = fkIncludes;
                
                //var es = _repository.Queryable;
				IQueryable<SDCaseFile> query = con.SDCaseFiles.AsQueryable();
		
				// include relations FK
				if(string.IsNullOrEmpty(includes) ){
					includes ="";
				}
				StringBuilder sbQuerySystem = new StringBuilder();
                    //predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				

				//if (!string.IsNullOrEmpty(predicateString))
                //      sbQuerySystem.Append(" And ");
                //sbQuerySystem.Append(" (IsDeleted != true Or IsDeleted = null) ");
				 filter.SetFilterPart("de", "(IsDeleted != true OR IsDeleted = null)");


					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
	                    	if (contextRequest.User !=null )
	                        	if (contextRequest.Company != null ){
	                        		//if (sbQuerySystem.Length > 0)
	                        		//	    			sbQuerySystem.Append( " And ");	
									//sbQuerySystem.Append(@" (GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa

									filter.SetFilterPart("co",@"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))");

								}
						}	
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				//string predicateString = predicate.ToDynamicLinq<SDCaseFile>();
				//predicateString += sbQuerySystem.ToString();
				filter.CleanAndProcess("");

				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed(); //SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicateString );               
                string predicateWithManyRelations = filter.GetFilterChildren(); //SFSdotNet.Framework.Linq.Utils.CleanPartExpression(predicateString);

                //QueryUtils.BreakeQuery1(predicateString, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
                var _queryable = query.AsQueryable();
				bool includeAll = true; 
                if (!string.IsNullOrEmpty(predicateWithManyRelations))
                    _queryable = _queryable.Where(predicateWithManyRelations, contextRequest.CustomQuery.ExtraParams);
				if (contextRequest.CustomQuery.SpecificProperties.Count > 0)
                {

				includeAll = false; 
                }

				StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append("new (");
                bool existPrev = false;
                foreach (var selected in contextRequest.CustomQuery.SelectedFields.Where(p=> !string.IsNullOrEmpty(p.Linq)))
                {
                    if (existPrev) sbSelect.Append(", ");
                    if (!selected.Linq.Contains(".") && !selected.Linq.StartsWith("it."))
                        sbSelect.Append("it." + selected.Linq);
                    else
                        sbSelect.Append(selected.Linq);
                    existPrev = true;
                }
                sbSelect.Append(")");
                var queryable = _queryable.Select(sbSelect.ToString());                    


     				
                 if (!string.IsNullOrEmpty(predicateWithFKAndComputed))
                    queryable = queryable.Where(predicateWithFKAndComputed, contextRequest.CustomQuery.ExtraParams);

				QueryComplementOptions queryOps = ContextQueryBuilder.ApplyContextQuery(contextRequest);
            	if (!string.IsNullOrEmpty(queryOps.OrderByAndSort)){
					if (queryOps.OrderBy.Contains(".") && !queryOps.OrderBy.StartsWith("it.")) queryOps.OrderBy = "it." + queryOps.OrderBy;
					queryable = queryable.OrderBy(queryOps.OrderByAndSort);
					}
               	if (queryOps.Skip != null)
                {
                    queryable = queryable.Skip(queryOps.Skip.Value);
                }
                if (queryOps.PageSize != null)
                {
                    queryable = queryable.Take (queryOps.PageSize.Value);
                }


                var resultTemp = queryable.AsQueryable().ToListAsync().Result;
                foreach (var item in resultTemp)
                {

				   result.Add(SFSdotNet.Framework.BR.Utils.GetConverted<SDCaseFile,dynamic>(item, contextRequest.CustomQuery.SelectedFields.Select(p=>p.Name).ToArray()));
                }

			 if (e != null)
                {
                    e.Items = result;
                }
				 contextRequest.CustomQuery = new CustomQuery();
				OnTaken(this, e == null ? e = new BusinessRulesEventArgs<SDCaseFile>() { Items= result, IncludingComputedLinq = true, ContextRequest = contextRequest, FilterExpressionString  = predicateString } :  e);
  
			
  
                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
	
	*/
	#endregion

            }
        }
		public SDCaseFile GetFromOperation(string function, string filterString, string usemode, string fields, ContextRequest contextRequest)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
                string computedFields = "";
               // string fkIncludes = "accContpaqiClassification,accProjectConcept,accProjectType,accProxyUser";
                List<string> multilangProperties = new List<string>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					if (contextRequest != null && contextRequest.Company != null)
					{
						multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
						contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
					}
					 									
					string multiTenantField = "GuidCompany";


                return GetSummaryOperation(con, new SDCaseFile(), function, filterString, usemode, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields, contextRequest, fields.Split(char.Parse(",")).ToArray());
            }
        }

   protected override void QueryBuild(string predicate, Filter filter, DbContext efContext, ContextRequest contextRequest, string method, List<string> includesList)
      	{
				if (contextRequest.CustomQuery.SpecificProperties.Count == 0)
                {
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseFile.PropertyNames.GuidCase);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseFile.PropertyNames.GuidFile);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseFile.PropertyNames.GuidCompany);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseFile.PropertyNames.CreatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseFile.PropertyNames.UpdatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseFile.PropertyNames.CreatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseFile.PropertyNames.UpdatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseFile.PropertyNames.Bytes);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseFile.PropertyNames.IsDeleted);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseFile.PropertyNames.SDCase);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseFile.PropertyNames.SDFile);
                    
				}

				if (method == "getby" || method == "sum")
				{
					if (!contextRequest.CustomQuery.SpecificProperties.Contains("GuidCasefile")){
						contextRequest.CustomQuery.SpecificProperties.Add("GuidCasefile");
					}

					 if (!string.IsNullOrEmpty(contextRequest.CustomQuery.OrderBy))
					{
						string existPropertyOrderBy = contextRequest.CustomQuery.OrderBy;
						if (contextRequest.CustomQuery.OrderBy.Contains("."))
						{
							existPropertyOrderBy = contextRequest.CustomQuery.OrderBy.Split(char.Parse("."))[0];
						}
						if (!contextRequest.CustomQuery.SpecificProperties.Exists(p => p == existPropertyOrderBy))
						{
							contextRequest.CustomQuery.SpecificProperties.Add(existPropertyOrderBy);
						}
					}

				}
				
	bool isFullDetails = contextRequest.IsFromUI("SDCaseFiles", UIActions.GetForDetails);
	string filterForTest = predicate  + filter.GetFilterComplete();

				if (isFullDetails || !string.IsNullOrEmpty(predicate))
            {
            } 

			if (method == "sum")
            {
            } 
			if (contextRequest.CustomQuery.SelectedFields.Count == 0)
            {
				foreach (var selected in contextRequest.CustomQuery.SpecificProperties)
                {
					string linq = selected;
					switch (selected)
                    {

					case "SDCase":
					if (includesList.Contains(selected)){
                        linq = "it.SDCase as SDCase";
					}
                    else
						linq = "iif(it.SDCase != null, new (it.SDCase.GuidCase, it.SDCase.BodyContent), null) as SDCase";
 					break;
					case "SDFile":
					if (includesList.Contains(selected)){
                        linq = "it.SDFile as SDFile";
					}
                    else
						linq = "iif(it.SDFile != null, new (it.SDFile.GuidFile, it.SDFile.FileName), null) as SDFile";
 					break;
					 
						
					 default:
                            break;
                    }
					contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name=selected, Linq=linq});
					if (method == "getby" || method == "sum")
					{
						if (includesList.Contains(selected))
							includesList.Remove(selected);

					}

				}
			}
				if (method == "getby" || method == "sum")
				{
					foreach (var otherInclude in includesList.Where(p=> !string.IsNullOrEmpty(p)))
					{
						contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name = otherInclude, Linq = "it." + otherInclude +" as " + otherInclude });
					}
				}
				BusinessRulesEventArgs<SDCaseFile> e = null;
				if (contextRequest.PreventInterceptors == false)
					OnQuerySettings(efContext, e = new BusinessRulesEventArgs<SDCaseFile>() { Filter = filter, ContextRequest = contextRequest /*, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null)*/ });

				//List<SDCaseFile> result = new List<SDCaseFile>();
                 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }

}
		public List<SDCaseFile> GetBy(Expression<Func<SDCaseFile, bool>> predicate, bool loadRelations, ContextRequest contextRequest)
        {
			if(!loadRelations)
				return GetBy(predicate, contextRequest);
			else
				return GetBy(predicate, contextRequest, "");

        }

        public List<SDCaseFile> GetBy(Expression<Func<SDCaseFile, bool>> predicate, int? pageSize, int? page, string orderBy, SFSdotNet.Framework.Data.SortDirection? sortDirection)
        {
            return GetBy(predicate, new ContextRequest() { CustomQuery = new CustomQuery() { Page = page, PageSize = pageSize, OrderBy = orderBy, SortDirection = sortDirection } });
        }
        public List<SDCaseFile> GetBy(Expression<Func<SDCaseFile, bool>> predicate)
        {

			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
			contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
			            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            contextRequest.CustomQuery.FilterExpressionString = null;
            return this.GetBy(predicate, contextRequest, "");
        }
        #endregion
        #region Dynamic String
		protected override string GetSpecificFilter(string filter, ContextRequest contextRequest) {
            string result = "";
		    //string linqFilter = String.Empty;
            string freeTextFilter = String.Empty;
            if (filter.Contains("|"))
            {
               // linqFilter = filter.Split(char.Parse("|"))[0];
                freeTextFilter = filter.Split(char.Parse("|"))[1];
            }
            //else {
            //    freeTextFilter = filter;
            //}
            //else {
            //    linqFilter = filter;
            //}
			// linqFilter = SFSdotNet.Framework.Linq.Utils.ReplaceCustomDateFilters(linqFilter);
            //string specificFilter = linqFilter;
            if (!string.IsNullOrEmpty(freeTextFilter))
            {
                System.Text.StringBuilder sbCont = new System.Text.StringBuilder();
                /*if (specificFilter.Length > 0)
                {
                    sbCont.Append(" AND ");
                    sbCont.Append(" ({0})");
                }
                else
                {
                    sbCont.Append("{0}");
                }*/
                //var words = freeTextFilter.Split(char.Parse(" "));
				var word = freeTextFilter;
                System.Text.StringBuilder sbSpec = new System.Text.StringBuilder();
                 int nWords = 1;
				/*foreach (var word in words)
                {
					if (word.Length > 0){
                    if (sbSpec.Length > 0) sbSpec.Append(" AND ");
					if (words.Length > 1) sbSpec.Append("("); */
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
								
					//if (sbSpec.Length > 2)
					//	sbSpec.Append(" OR "); // test
					sbSpec.Append(string.Format(@"it.SDCase.BodyContent.Contains(""{0}"")", word)+" OR "+string.Format(@"it.SDFile.FileName.Contains(""{0}"")", word));
								 //sbSpec.Append("*extraFreeText*");

                    /*if (words.Length > 1) sbSpec.Append(")");
					
					nWords++;

					}

                }*/
                //specificFilter = string.Format("{0}{1}", specificFilter, string.Format(sbCont.ToString(), sbSpec.ToString()));
                                 result = sbSpec.ToString();  
            }
			//result = specificFilter;
			
			return result;

		}
	
			public List<SDCaseFile> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params object[] extraParams)
        {
			return GetBy(filter, pageSize, page, orderBy, orderDir,  null, extraParams);
		}
           public List<SDCaseFile> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, string usemode, params object[] extraParams)
            { 
                return GetBy(filter, pageSize, page, orderBy, orderDir, usemode, null, extraParams);
            }


		public List<SDCaseFile> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  string usemode, ContextRequest context, params object[] extraParams)

        {

            // string freetext = null;
            //if (filter.Contains("|"))
            //{
            //    int parts = filter.Split(char.Parse("|")).Count();
            //    if (parts > 1)
            //    {

            //        freetext = filter.Split(char.Parse("|"))[1];
            //    }
            //}
		
            //string specificFilter = "";
            //if (!string.IsNullOrEmpty(filter))
            //  specificFilter=  GetSpecificFilter(filter);
            if (string.IsNullOrEmpty(orderBy))
            {
			                orderBy = "UpdatedDate";
            }
			//orderDir = "desc";
			SFSdotNet.Framework.Data.SortDirection direction = SFSdotNet.Framework.Data.SortDirection.Ascending;
            if (!string.IsNullOrEmpty(orderDir))
            {
                if (orderDir == "desc")
                    direction = SFSdotNet.Framework.Data.SortDirection.Descending;
            }
            if (context == null)
                context = new ContextRequest();
			

             context.UseMode = usemode;
             if (context.CustomQuery == null )
                context.CustomQuery =new SFSdotNet.Framework.My.CustomQuery();

 
                context.CustomQuery.ExtraParams = extraParams;

                    context.CustomQuery.OrderBy = orderBy;
                   context.CustomQuery.SortDirection = direction;
                   context.CustomQuery.Page = page;
                  context.CustomQuery.PageSize = pageSize;
               

            

            if (!preventSecurityRestrictions) {
			 if (context.CurrentContext == null)
                {
					if (SFSdotNet.Framework.My.Context.CurrentContext != null &&  SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
					{
						context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
						context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

					}
					else {
						throw new Exception("The security rule require a specific user and company");
					}
				}
            }
            return GetBy(filter, context);
  
        }


        public List<SDCaseFile> GetBy(string strWhere, ContextRequest contextRequest)
        {
        	#region old code
				
				 //Expression<Func<tvsReservationTransport, bool>> predicate = null;
				string strWhereClean = strWhere.Replace("*extraFreeText*", "").Replace("()", "");
                //if (!string.IsNullOrEmpty(strWhereClean)){

                //    object[] extraParams = null;
                //    //if (contextRequest != null )
                //    //    if (contextRequest.CustomQuery != null )
                //    //        extraParams = contextRequest.CustomQuery.ExtraParams;
                //    //predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<tvsReservationTransport, bool>(strWhereClean, extraParams != null? extraParams.Cast<Guid>(): null);				
                //}
				 if (contextRequest == null)
                {
                    contextRequest = new ContextRequest();
                    if (contextRequest.CustomQuery == null)
                        contextRequest.CustomQuery = new CustomQuery();
                }
                  if (!preventSecurityRestrictions) {
					if (contextRequest.User == null || contextRequest.Company == null)
                      {
                     if (SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
                     {
                         contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                         contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

                     }
                     else {
                         throw new Exception("The security rule require a specific User and Company ");
                     }
					 }
                 }
            contextRequest.CustomQuery.FilterExpressionString = strWhere;
				//return GetBy(predicate, contextRequest);  

			#endregion				
				
                    return GetBy(strWhere, contextRequest, "");  


        }
       public List<SDCaseFile> GetBy(string strWhere)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
			
            return GetBy(strWhere, context, null);
        }

        public List<SDCaseFile> GetBy(string strWhere, string includes)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
            return GetBy(strWhere, context, includes);
        }

        #endregion
        #endregion
		
		  #region SaveOrUpdate
        
 		 public SDCaseFile Create(SDCaseFile entity)
        {
				//ObjectContext context = null;
				    if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: Create");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

				return this.Create(entity, contextRequest);


        }
        
       
        public SDCaseFile Create(SDCaseFile entity, ContextRequest contextRequest)
        {
		
		bool graph = false;
	
				bool preventPartial = false;
                if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
               
			using (EFContext con = new EFContext()) {

				SDCaseFile itemForSave = new SDCaseFile();
#region Autos
		if(!preventSecurityRestrictions){

				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion
               BusinessRulesEventArgs<SDCaseFile> e = null;
			    if (preventPartial == false )
                OnCreating(this,e = new BusinessRulesEventArgs<SDCaseFile>() { ContextRequest = contextRequest, Item=entity });
				   if (e != null) {
						if (e.Cancel)
						{
							context = null;
							return e.Item;

						}
					}

                    if (entity.GuidCasefile == Guid.Empty)
                   {
                       entity.GuidCasefile = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   itemForSave.GuidCasefile = entity.GuidCasefile;
				  
		
			itemForSave.GuidCasefile = entity.GuidCasefile;

			itemForSave.GuidCompany = entity.GuidCompany;

			itemForSave.CreatedDate = entity.CreatedDate;

			itemForSave.UpdatedDate = entity.UpdatedDate;

			itemForSave.CreatedBy = entity.CreatedBy;

			itemForSave.UpdatedBy = entity.UpdatedBy;

			itemForSave.Bytes = entity.Bytes;

			itemForSave.IsDeleted = entity.IsDeleted;

				
				con.SDCaseFiles.Add(itemForSave);



					if (entity.SDCase != null)
					{
						var sDCase = new SDCase();
						sDCase.GuidCase = entity.SDCase.GuidCase;
						itemForSave.SDCase = sDCase;
						SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCase>(con, itemForSave.SDCase);
			
					}




					if (entity.SDFile != null)
					{
						var sDFile = new SDFile();
						sDFile.GuidFile = entity.SDFile.GuidFile;
						itemForSave.SDFile = sDFile;
						SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDFile>(con, itemForSave.SDFile);
			
					}



                
				con.ChangeTracker.Entries().Where(p => p.Entity != itemForSave && p.State != EntityState.Unchanged).ForEach(p => p.State = EntityState.Detached);

				con.Entry<SDCaseFile>(itemForSave).State = EntityState.Added;

				con.SaveChanges();

					 
				

				//itemResult = entity;
                //if (e != null)
                //{
                 //   e.Item = itemResult;
                //}
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false )
                OnCreated(this, e == null ? e = new BusinessRulesEventArgs<SDCaseFile>() { ContextRequest = contextRequest, Item = entity } : e);



                if (e != null && e.Item != null )
                {
                    return e.Item;
                }
                              return entity;
			}
            
        }
        //BusinessRulesEventArgs<SDCaseFile> e = null;
        public void Create(List<SDCaseFile> entities)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            Create(entities, contextRequest);
        }
        public void Create(List<SDCaseFile> entities, ContextRequest contextRequest)
        
        {
			ObjectContext context = null;
            	foreach (SDCaseFile entity in entities)
				{
					this.Create(entity, contextRequest);
				}
        }
		  public void CreateOrUpdateBulk(List<SDCaseFile> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "cu", contextRequest);
        }

        private void CreateOrUpdateBulk(List<SDCaseFile> entities, string actionKey, ContextRequest contextRequest)
        {
			if (entities.Count() > 0){
            bool graph = false;

            bool preventPartial = false;
            if (contextRequest != null && contextRequest.PreventInterceptors == true)
            {
                preventPartial = true;
            }
            foreach (var entity in entities)
            {
                    if (entity.GuidCasefile == Guid.Empty)
                   {
                       entity.GuidCasefile = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   
				  


#region Autos
		if(!preventSecurityRestrictions){


 if (actionKey != "u")
                        {
				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;


}
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion


		
			//entity.GuidCasefile = entity.GuidCasefile;

			//entity.GuidCompany = entity.GuidCompany;

			//entity.CreatedDate = entity.CreatedDate;

			//entity.UpdatedDate = entity.UpdatedDate;

			//entity.CreatedBy = entity.CreatedBy;

			//entity.UpdatedBy = entity.UpdatedBy;

			//entity.Bytes = entity.Bytes;

			//entity.IsDeleted = entity.IsDeleted;

				
				



				    if (entity.SDCase != null)
					{
						//var sDCase = new SDCase();
						entity.GuidCase = entity.SDCase.GuidCase;
						//entity.SDCase = sDCase;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCase>(con, itemForSave.SDCase);
			
					}




				    if (entity.SDFile != null)
					{
						//var sDFile = new SDFile();
						entity.GuidFile = entity.SDFile.GuidFile;
						//entity.SDFile = sDFile;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDFile>(con, itemForSave.SDFile);
			
					}



                
				

					 
				

				//itemResult = entity;
            }
            using (EFContext con = new EFContext())
            {
                 if (actionKey == "c")
                    {
                        context.BulkInsert(entities);
                    }else if ( actionKey == "u")
                    {
                        context.BulkUpdate(entities);
                    }else
                    {
                        context.BulkInsertOrUpdate(entities);
                    }
            }

			}
        }
	
		public void CreateBulk(List<SDCaseFile> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "c", contextRequest);
        }


		public void UpdateAgile(SDCaseFile item, params string[] fields)
         {
			UpdateAgile(item, null, fields);
        }
		public void UpdateAgile(SDCaseFile item, ContextRequest contextRequest, params string[] fields)
         {
            
             ContextRequest contextNew = null;
             if (contextRequest != null)
             {
                 contextNew = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
                 if (fields != null && fields.Length > 0)
                 {
                     contextNew.CustomQuery.SpecificProperties  = fields.ToList();
                 }
                 else if(contextRequest.CustomQuery.SpecificProperties.Count > 0)
                 {
                     fields = contextRequest.CustomQuery.SpecificProperties.ToArray();
                 }
             }
			

		   using (EFContext con = new EFContext())
            {



               
					List<string> propForCopy = new List<string>();
                    propForCopy.AddRange(fields);
                    
					  
					if (!propForCopy.Contains("GuidCasefile"))
						propForCopy.Add("GuidCasefile");

					var itemForUpdate = SFSdotNet.Framework.BR.Utils.GetConverted<SDCaseFile,SDCaseFile>(item, propForCopy.ToArray());
					 itemForUpdate.GuidCasefile = item.GuidCasefile;
                  var setT = con.Set<SDCaseFile>().Attach(itemForUpdate);

					if (fields.Count() > 0)
					  {
						  item.ModifiedProperties = fields;
					  }
                    foreach (var property in item.ModifiedProperties)
					{						
                        if (property != "GuidCasefile")
                             con.Entry(setT).Property(property).IsModified = true;

                    }

                
               int result = con.SaveChanges();
               if (result != 1)
               {
                   SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: 1");
               }


            }

			OnUpdatedAgile(this, new BusinessRulesEventArgs<SDCaseFile>() { Item = item, ContextRequest = contextNew  });

         }
		public void UpdateBulk(List<SDCaseFile>  items, params string[] fields)
         {
             SFSdotNet.Framework.My.ContextRequest req = new SFSdotNet.Framework.My.ContextRequest();
             req.CustomQuery = new SFSdotNet.Framework.My.CustomQuery();
             foreach (var field in fields)
             {
                 req.CustomQuery.SpecificProperties.Add(field);
             }
             UpdateBulk(items, req);

         }

		 public void DeleteBulk(List<SDCaseFile> entities, ContextRequest contextRequest = null)
        {

            using (EFContext con = new EFContext())
            {
                foreach (var entity in entities)
                {
					var entityProxy = new SDCaseFile() { GuidCasefile = entity.GuidCasefile };

                    con.Entry<SDCaseFile>(entityProxy).State = EntityState.Deleted;

                }

                int result = con.SaveChanges();
                if (result != entities.Count)
                {
                    SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: " + entities.Count.ToString());
                }
            }

        }

        public void UpdateBulk(List<SDCaseFile> items, ContextRequest contextRequest)
        {
            if (items.Count() > 0){

			 foreach (var entity in items)
            {


#region Autos
		if(!preventSecurityRestrictions){

				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	



			}
#endregion




				    if (entity.SDCase != null)
					{
						//var sDCase = new SDCase();
						entity.GuidCase = entity.SDCase.GuidCase;
						//entity.SDCase = sDCase;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCase>(con, itemForSave.SDCase);
			
					}




				    if (entity.SDFile != null)
					{
						//var sDFile = new SDFile();
						entity.GuidFile = entity.SDFile.GuidFile;
						//entity.SDFile = sDFile;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDFile>(con, itemForSave.SDFile);
			
					}



				}
				using (EFContext con = new EFContext())
				{

                    
                
                   con.BulkUpdate(items);

				}
             
			}	  
        }

         public SDCaseFile Update(SDCaseFile entity)
        {
            if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return Update(entity, contextRequest);
        }
       
         public SDCaseFile Update(SDCaseFile entity, ContextRequest contextRequest)
        {
		 if ((System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null) && contextRequest == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Update");
            }
            if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            }

			
				SDCaseFile  itemResult = null;

	
			//entity.UpdatedDate = DateTime.Now.ToUniversalTime();
			//if(contextRequest.User != null)
				//entity.UpdatedBy = contextRequest.User.GuidUser;

//	    var oldentity = GetBy(p => p.GuidCasefile == entity.GuidCasefile, contextRequest).FirstOrDefault();
	//	if (oldentity != null) {
		
          //  entity.CreatedDate = oldentity.CreatedDate;
    //        entity.CreatedBy = oldentity.CreatedBy;
	
      //      entity.GuidCompany = oldentity.GuidCompany;
	
			

	
		//}

			 using( EFContext con = new EFContext()){
				BusinessRulesEventArgs<SDCaseFile> e = null;
				bool preventPartial = false; 
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false)
                OnUpdating(this,e = new BusinessRulesEventArgs<SDCaseFile>() { ContextRequest = contextRequest, Item=entity});
				   if (e != null) {
						if (e.Cancel)
						{
							//outcontext = null;
							return e.Item;

						}
					}

	string includes = "SDCase,SDFile";
	IQueryable < SDCaseFile > query = con.SDCaseFiles.AsQueryable();
	foreach (string include in includes.Split(char.Parse(",")))
                       {
                           if (!string.IsNullOrEmpty(include))
                               query = query.Include(include);
                       }
	var oldentity = query.FirstOrDefault(p => p.GuidCasefile == entity.GuidCasefile);

				//if (entity.UpdatedDate == null || (contextRequest != null && contextRequest.IsFromUI("SDCaseFiles", UIActions.Updating)))
			oldentity.UpdatedDate = DateTime.Now.ToUniversalTime();
			if(contextRequest.User != null)
				oldentity.UpdatedBy = contextRequest.User.GuidUser;

           


						if (SFSdotNet.Framework.BR.Utils.HasRelationPropertyChanged(oldentity.SDCase, entity.SDCase, "GuidCase"))
							oldentity.SDCase = entity.SDCase != null? new SDCase(){ GuidCase = entity.SDCase.GuidCase } :null;

                


						if (SFSdotNet.Framework.BR.Utils.HasRelationPropertyChanged(oldentity.SDFile, entity.SDFile, "GuidFile"))
							oldentity.SDFile = entity.SDFile != null? new SDFile(){ GuidFile = entity.SDFile.GuidFile } :null;

                


				con.ChangeTracker.Entries().Where(p => p.Entity != oldentity).ForEach(p => p.State = EntityState.Unchanged);  
				  
				con.SaveChanges();
        
					 
					
               
				itemResult = entity;
				if(preventPartial == false)
					OnUpdated(this, e = new BusinessRulesEventArgs<SDCaseFile>() { ContextRequest = contextRequest, Item=itemResult });

              	return itemResult;
			}
			  
        }
        public SDCaseFile Save(SDCaseFile entity)
        {
			return Create(entity);
        }
        public int Save(List<SDCaseFile> entities)
        {
			 Create(entities);
            return entities.Count;

        }
        #endregion
        #region Delete
        public void Delete(SDCaseFile entity)
        {
				this.Delete(entity, null);
			
        }
		 public void Delete(SDCaseFile entity, ContextRequest contextRequest)
        {
				
				  List<SDCaseFile> entities = new List<SDCaseFile>();
				   entities.Add(entity);
				this.Delete(entities, contextRequest);
			
        }

         public void Delete(string query, Guid[] guids, ContextRequest contextRequest)
        {
			var br = new SDCaseFilesBR(true);
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);
            
            Delete(items, contextRequest);

        }
        public void Delete(SDCaseFile entity,  ContextRequest contextRequest, BusinessRulesEventArgs<SDCaseFile> e = null)
        {
			
				using(EFContext con = new EFContext())
                 {
				
               	BusinessRulesEventArgs<SDCaseFile> _e = null;
               List<SDCaseFile> _items = new List<SDCaseFile>();
                _items.Add(entity);
                if (e == null || e.PreventPartialPropagate == false)
                {
                    OnDeleting(this, _e = (e == null ? new BusinessRulesEventArgs<SDCaseFile>() { ContextRequest = contextRequest, Item = entity, Items = null  } : e));
                }
                if (_e != null)
                {
                    if (_e.Cancel)
						{
							context = null;
							return;

						}
					}


				
									//IsDeleted
					bool logicDelete = true;
					if (entity.IsDeleted != null)
					{
						if (entity.IsDeleted.Value)
							logicDelete = false;
					}
					if (logicDelete)
					{
											//entity = GetBy(p =>, contextRequest).FirstOrDefault();
						entity.IsDeleted = true;
						if (contextRequest != null && contextRequest.User != null)
							entity.UpdatedBy = contextRequest.User.GuidUser;
                        entity.UpdatedDate = DateTime.UtcNow;
						UpdateAgile(entity, "IsDeleted","UpdatedBy","UpdatedDate");

						
					}
					else {
					con.Entry<SDCaseFile>(entity).State = EntityState.Deleted;
					con.SaveChanges();
				
				 
					}
								
				
				 
					
					
			if (e == null || e.PreventPartialPropagate == false)
                {

                    if (_e == null)
                        _e = new BusinessRulesEventArgs<SDCaseFile>() { ContextRequest = contextRequest, Item = entity, Items = null };

                    OnDeleted(this, _e);
                }

				//return null;
			}
        }
 public void UnDelete(string query, Guid[] guids, ContextRequest contextRequest)
        {
            var br = new SDCaseFilesBR(true);
            contextRequest.CustomQuery.IncludeDeleted = true;
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);

            foreach (var item in items)
            {
                item.IsDeleted = false;
						if (contextRequest != null && contextRequest.User != null)
							item.UpdatedBy = contextRequest.User.GuidUser;
                        item.UpdatedDate = DateTime.UtcNow;
            }

            UpdateBulk(items, "IsDeleted","UpdatedBy","UpdatedDate");
        }

         public void Delete(List<SDCaseFile> entities,  ContextRequest contextRequest = null )
        {
				
			 BusinessRulesEventArgs<SDCaseFile> _e = null;

                OnDeleting(this, _e = new BusinessRulesEventArgs<SDCaseFile>() { ContextRequest = contextRequest, Item = null, Items = entities });
                if (_e != null)
                {
                    if (_e.Cancel)
                    {
                        context = null;
                        return;

                    }
                }
                bool allSucced = true;
                BusinessRulesEventArgs<SDCaseFile> eToChilds = new BusinessRulesEventArgs<SDCaseFile>();
                if (_e != null)
                {
                    eToChilds = _e;
                }
                else
                {
                    eToChilds = new BusinessRulesEventArgs<SDCaseFile>() { ContextRequest = contextRequest, Item = (entities.Count == 1 ? entities[0] : null), Items = entities };
                }
				foreach (SDCaseFile item in entities)
				{
					try
                    {
                        this.Delete(item, contextRequest, e: eToChilds);
                    }
                    catch (Exception ex)
                    {
                        SFSdotNet.Framework.My.EventLog.Error(ex);
                        allSucced = false;
                    }
				}
				if (_e == null)
                    _e = new BusinessRulesEventArgs<SDCaseFile>() { ContextRequest = contextRequest, CountResult = entities.Count, Item = null, Items = entities };
                OnDeleted(this, _e);

			
        }
        #endregion
 
        #region GetCount
		 public int GetCount(Expression<Func<SDCaseFile, bool>> predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

			return GetCount(predicate, contextRequest);
		}
        public int GetCount(Expression<Func<SDCaseFile, bool>> predicate, ContextRequest contextRequest)
        {


		
		 using (EFContext con = new EFContext())
            {


				if (predicate == null) predicate = PredicateBuilder.True<SDCaseFile>();
           		predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted == null);
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    		if (contextRequest.User !=null )
                        		if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
									predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa

								}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				
				IQueryable<SDCaseFile> query = con.SDCaseFiles.AsQueryable();
                return query.AsExpandable().Count(predicate);

			
				}
			

        }
		  public int GetCount(string predicate,  ContextRequest contextRequest)
         {
             return GetCount(predicate, null, contextRequest);
         }

         public int GetCount(string predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return GetCount(predicate, contextRequest);
        }
		 public int GetCount(string predicate, string usemode){
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
				return GetCount( predicate,  usemode,  contextRequest);
		 }
        public int GetCount(string predicate, string usemode, ContextRequest contextRequest){

		using (EFContext con = new EFContext()) {
				string computedFields = "";
				string fkIncludes = "SDCase,SDFile";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDCaseFile>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetCount(con, predicate, usemode, contextRequest, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields);

			}
			#region old code
			 /* string freetext = null;
            Filter filter = new Filter();

              if (predicate.Contains("|"))
              {
                 
                  filter.SetFilterPart("ft", GetSpecificFilter(predicate, contextRequest));
                 
                  filter.ProcessText(predicate.Split(char.Parse("|"))[0]);
                  freetext = predicate.Split(char.Parse("|"))[1];

				  if (!string.IsNullOrEmpty(freetext) && string.IsNullOrEmpty(contextRequest.FreeText))
                  {
                      contextRequest.FreeText = freetext;
                  }
              }
              else {
                  filter.ProcessText(predicate);
              }
			   predicate = filter.GetFilterComplete();
			// BusinessRulesEventArgs<SDCaseFile>  e = null;
           	using (EFContext con = new EFContext())
			{
			
			

			 QueryBuild(predicate, filter, con, contextRequest, "count", new List<string>());


			
			BusinessRulesEventArgs<SDCaseFile> e = null;

			contextRequest.FreeText = freetext;
			contextRequest.UseMode = usemode;
            OnCounting(this, e = new BusinessRulesEventArgs<SDCaseFile>() {  Filter =filter, ContextRequest = contextRequest });
            if (e != null)
            {
                if (e.Cancel)
                {
                    context = null;
                    return e.CountResult;

                }

            

            }
			
			StringBuilder sbQuerySystem = new StringBuilder();
		
					
                    filter.SetFilterPart("de","(IsDeleted != true OR IsDeleted == null)");
			
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    	if (contextRequest.User !=null )
                        	if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
                        		
								filter.SetFilterPart("co", @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa
						
						
							}
							
							}
							if (preventSecurityRestrictions) preventSecurityRestrictions= false;
		
				   
                 filter.CleanAndProcess("");
				//string predicateWithFKAndComputed = SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicate );               
				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed();
               string predicateWithManyRelations = filter.GetFilterChildren();
			   ///QueryUtils.BreakeQuery1(predicate, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
			   predicate = filter.GetFilterComplete();
               if (!string.IsNullOrEmpty(predicate))
               {
				
					
                    return con.SDCaseFiles.Where(predicate).Count();
					
                }else
                    return con.SDCaseFiles.Count();
					
			}*/
			#endregion

		}
         public int GetCount()
        {
            return GetCount(p => true);
        }
        #endregion
        
         


        public void Delete(List<SDCaseFile.CompositeKey> entityKeys)
        {

            List<SDCaseFile> items = new List<SDCaseFile>();
            foreach (var itemKey in entityKeys)
            {
                items.Add(GetByKey(itemKey.GuidCasefile));
            }

            Delete(items);

        }
		 public void UpdateAssociation(string relation, string relationValue, string query, Guid[] ids, ContextRequest contextRequest)
        {
            var items = GetBy(query, null, null, null, null, null, contextRequest, ids);
			 var module = SFSdotNet.Framework.Cache.Caching.SystemObjects.GetModuleByKey(SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(System.Web.HttpContext.Current.Request.RequestContext, "area"));
           
            foreach (var item in items)
            {
			  Guid ? guidRelationValue = null ;
                if (!string.IsNullOrEmpty(relationValue)){
                    guidRelationValue = Guid.Parse(relationValue );
                }

				 if (relation.Contains("."))
                {
                    var partsWithOtherProp = relation.Split(char.Parse("|"));
                    var parts = partsWithOtherProp[0].Split(char.Parse("."));

                    string proxyRelName = parts[0];
                    string proxyProperty = parts[1];
                    string proxyPropertyKeyNameFromOther = partsWithOtherProp[1];
                    //string proxyPropertyThis = parts[2];

                    var prop = item.GetType().GetProperty(proxyRelName);
                    //var entityInfo = //SFSdotNet.Framework.
                    // descubrir el tipo de entidad dentro de la colección
                    Type typeEntityInList = SFSdotNet.Framework.Entities.Utils.GetTypeFromList(prop);
                    var newProxyItem = Activator.CreateInstance(typeEntityInList);
                    var propThisForSet = newProxyItem.GetType().GetProperty(proxyProperty);
                    var entityInfoOfProxy = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(typeEntityInList);
                    var propOther = newProxyItem.GetType().GetProperty(proxyPropertyKeyNameFromOther);

                    if (propThisForSet != null && entityInfoOfProxy != null && propOther != null )
                    {
                        var entityInfoThis = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(item.GetType());
                        var valueThisId = item.GetType().GetProperty(entityInfoThis.PropertyKeyName).GetValue(item);
                        if (valueThisId != null)
                            propThisForSet.SetValue(newProxyItem, valueThisId);
                        propOther.SetValue(newProxyItem, Guid.Parse(relationValue));
                        
                        var entityNameProp = newProxyItem.GetType().GetField("EntityName").GetValue(null);
                        var entitySetNameProp = newProxyItem.GetType().GetField("EntitySetName").GetValue(null);

                        SFSdotNet.Framework.Apps.Integration.CreateItemFromApp(entityNameProp.ToString(), entitySetNameProp.ToString(), module.ModuleNamespace, newProxyItem, contextRequest);

                    }

                    // crear una instancia del tipo de entidad
                    // llenar los datos y registrar nuevo


                }
                else
                {
                var prop = item.GetType().GetProperty(relation);
                var entityInfo = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(prop.PropertyType);
                if (entityInfo != null)
                {
                    var ins = Activator.CreateInstance(prop.PropertyType);
                   if (guidRelationValue != null)
                    {
                        prop.PropertyType.GetProperty(entityInfo.PropertyKeyName).SetValue(ins, guidRelationValue);
                        item.GetType().GetProperty(relation).SetValue(item, ins);
                    }
                    else
                    {
                        item.GetType().GetProperty(relation).SetValue(item, null);
                    }

                    Update(item, contextRequest);
                }

				}
            }
        }
		
	}
		public partial class SDCaseHistoriesBR:BRBase<SDCaseHistory>{
	 	
           
		 #region Partial methods

           partial void OnUpdating(object sender, BusinessRulesEventArgs<SDCaseHistory> e);

            partial void OnUpdated(object sender, BusinessRulesEventArgs<SDCaseHistory> e);
			partial void OnUpdatedAgile(object sender, BusinessRulesEventArgs<SDCaseHistory> e);

            partial void OnCreating(object sender, BusinessRulesEventArgs<SDCaseHistory> e);
            partial void OnCreated(object sender, BusinessRulesEventArgs<SDCaseHistory> e);

            partial void OnDeleting(object sender, BusinessRulesEventArgs<SDCaseHistory> e);
            partial void OnDeleted(object sender, BusinessRulesEventArgs<SDCaseHistory> e);

            partial void OnGetting(object sender, BusinessRulesEventArgs<SDCaseHistory> e);
            protected override void OnVirtualGetting(object sender, BusinessRulesEventArgs<SDCaseHistory> e)
            {
                OnGetting(sender, e);
            }
			protected override void OnVirtualCounting(object sender, BusinessRulesEventArgs<SDCaseHistory> e)
            {
                OnCounting(sender, e);
            }
			partial void OnTaken(object sender, BusinessRulesEventArgs<SDCaseHistory> e);
			protected override void OnVirtualTaken(object sender, BusinessRulesEventArgs<SDCaseHistory> e)
            {
                OnTaken(sender, e);
            }

            partial void OnCounting(object sender, BusinessRulesEventArgs<SDCaseHistory> e);
 
			partial void OnQuerySettings(object sender, BusinessRulesEventArgs<SDCaseHistory> e);
          
            #endregion
			
		private static SDCaseHistoriesBR singlenton =null;
				public static SDCaseHistoriesBR NewInstance(){
					return  new SDCaseHistoriesBR();
					
				}
		public static SDCaseHistoriesBR Instance{
			get{
				if (singlenton == null)
					singlenton = new SDCaseHistoriesBR();
				return singlenton;
			}
		}
		//private bool preventSecurityRestrictions = false;
		 public bool PreventAuditTrail { get; set;  }
		#region Fields
        EFContext context = null;
        #endregion
        #region Constructor
        public SDCaseHistoriesBR()
        {
            context = new EFContext();
        }
		 public SDCaseHistoriesBR(bool preventSecurity)
            {
                this.preventSecurityRestrictions = preventSecurity;
				context = new EFContext();
            }
        #endregion
		
		#region Get

 		public IQueryable<SDCaseHistory> Get()
        {
            using (EFContext con = new EFContext())
            {
				
				var query = con.SDCaseHistories.AsQueryable();
                con.Configuration.ProxyCreationEnabled = false;

                //query = ContextQueryBuilder<Nutrient>.ApplyContextQuery(query, contextRequest);

                return query;




            }

        }
		


 	
		public List<SDCaseHistory> GetAll()
        {
            return this.GetBy(p => true);
        }
        public List<SDCaseHistory> GetAll(string includes)
        {
            return this.GetBy(p => true, includes);
        }
        public SDCaseHistory GetByKey(Guid guidCaseHistory)
        {
            return GetByKey(guidCaseHistory, true);
        }
        public SDCaseHistory GetByKey(Guid guidCaseHistory, bool loadIncludes)
        {
            SDCaseHistory item = null;
			var query = PredicateBuilder.True<SDCaseHistory>();
                    
			string strWhere = @"GuidCaseHistory = Guid(""" + guidCaseHistory.ToString()+@""")";
            Expression<Func<SDCaseHistory, bool>> predicate = null;
            //if (!string.IsNullOrEmpty(strWhere))
            //    predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDCaseHistory, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
			 ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
            contextRequest.CustomQuery.FilterExpressionString = strWhere;

			//item = GetBy(predicate, loadIncludes, contextRequest).FirstOrDefault();
			item = GetBy(strWhere,loadIncludes,contextRequest).FirstOrDefault();
            return item;
        }
         public List<SDCaseHistory> GetBy(string strWhere, bool loadRelations, ContextRequest contextRequest)
        {
            if (!loadRelations)
                return GetBy(strWhere, contextRequest);
            else
                return GetBy(strWhere, contextRequest, "");

        }
		  public List<SDCaseHistory> GetBy(string strWhere, bool loadRelations)
        {
              if (!loadRelations)
                return GetBy(strWhere, new ContextRequest());
            else
                return GetBy(strWhere, new ContextRequest(), "");

        }
		         public SDCaseHistory GetByKey(Guid guidCaseHistory, params Expression<Func<SDCaseHistory, object>>[] includes)
        {
            SDCaseHistory item = null;
			string strWhere = @"GuidCaseHistory = Guid(""" + guidCaseHistory.ToString()+@""")";
          Expression<Func<SDCaseHistory, bool>> predicate = p=> p.GuidCaseHistory == guidCaseHistory;
           // if (!string.IsNullOrEmpty(strWhere))
           //     predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDCaseHistory, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
        item = GetBy(predicate, includes).FirstOrDefault();
         ////   item = GetBy(strWhere,includes).FirstOrDefault();
			return item;

        }
        public SDCaseHistory GetByKey(Guid guidCaseHistory, string includes)
        {
            SDCaseHistory item = null;
			string strWhere = @"GuidCaseHistory = Guid(""" + guidCaseHistory.ToString()+@""")";
            
			
            item = GetBy(strWhere, includes).FirstOrDefault();
            return item;

        }
		 public SDCaseHistory GetByKey(Guid guidCaseHistory, string usemode, string includes)
		{
			return GetByKey(guidCaseHistory, usemode, null, includes);

		 }
		 public SDCaseHistory GetByKey(Guid guidCaseHistory, string usemode, ContextRequest context,  string includes)
        {
            SDCaseHistory item = null;
			string strWhere = @"GuidCaseHistory = Guid(""" + guidCaseHistory.ToString()+@""")";
			if (context == null){
				context = new ContextRequest();
				context.CustomQuery = new CustomQuery();
				context.CustomQuery.IsByKey = true;
				context.CustomQuery.FilterExpressionString = strWhere;
				context.UseMode = usemode;
			}
            item = GetBy(strWhere,context , includes).FirstOrDefault();
            return item;

        }

        #region Dynamic Predicate
        public List<SDCaseHistory> GetBy(Expression<Func<SDCaseHistory, bool>> predicate, int? pageSize, int? page)
        {
            return this.GetBy(predicate, pageSize, page, null, null);
        }
        public List<SDCaseHistory> GetBy(Expression<Func<SDCaseHistory, bool>> predicate, ContextRequest contextRequest)
        {

            return GetBy(predicate, contextRequest,"");
        }
        
        public List<SDCaseHistory> GetBy(Expression<Func<SDCaseHistory, bool>> predicate, ContextRequest contextRequest, params Expression<Func<SDCaseHistory, object>>[] includes)
        {
            StringBuilder sb = new StringBuilder();
           if (includes != null)
            {
                foreach (var path in includes)
                {

						if (sb.Length > 0) sb.Append(",");
						sb.Append(SFSdotNet.Framework.Linq.Utils.IncludeToString<SDCaseHistory>(path));

               }
            }
            return GetBy(predicate, contextRequest, sb.ToString());
        }
        
        
        public List<SDCaseHistory> GetBy(Expression<Func<SDCaseHistory, bool>> predicate, string includes)
        {
			ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";

            return GetBy(predicate, context, includes);
        }

        public List<SDCaseHistory> GetBy(Expression<Func<SDCaseHistory, bool>> predicate, params Expression<Func<SDCaseHistory, object>>[] includes)
        {
			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest context = new ContextRequest();
			            context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";
            return GetBy(predicate, context, includes);
        }

      
		public bool DisableCache { get; set; }
		public List<SDCaseHistory> GetBy(Expression<Func<SDCaseHistory, bool>> predicate, ContextRequest contextRequest, string includes)
		{
            using (EFContext con = new EFContext()) {
				
				string fkIncludes = "SDCase,SDCaseState";
                List<string> multilangProperties = new List<string>();
				if (predicate == null) predicate = PredicateBuilder.True<SDCaseHistory>();
                var notDeletedExpression = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;
					Expression<Func<SDCaseHistory,bool>> multitenantExpression  = null;
					if (contextRequest != null && contextRequest.Company != null)	                        	
						multitenantExpression = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicate, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression);

#region Old code
/*
				List<SDCaseHistory> result = null;
               BusinessRulesEventArgs<SDCaseHistory>  e = null;
	
				OnGetting(con, e = new BusinessRulesEventArgs<SDCaseHistory>() {  FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null) });

               // OnGetting(con,e = new BusinessRulesEventArgs<SDCaseHistory>() { FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = contextRequest.CustomQuery.FilterExpressionString});
				   if (e != null) {
				    predicate = e.FilterExpression;
						if (e.Cancel)
						{
							context = null;
							 if (e.Items == null) e.Items = new List<SDCaseHistory>();
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                if (predicate == null) predicate = PredicateBuilder.True<SDCaseHistory>();
 				string fkIncludes = "SDCase,SDCaseState";
                if(contextRequest!=null){
					if (contextRequest.CustomQuery != null)
					{
						if (contextRequest.CustomQuery.IncludeForeignKeyPaths != null) {
							if (contextRequest.CustomQuery.IncludeForeignKeyPaths.Value == false)
								fkIncludes = "";
						}
					}
				}
				if (!string.IsNullOrEmpty(includes))
					includes = includes + "," + fkIncludes;
				else
					includes = fkIncludes;
                
                //var es = _repository.Queryable;

                IQueryable<SDCaseHistory> query =  con.SDCaseHistories.AsQueryable();

                                if (!string.IsNullOrEmpty(includes))
                {
                    foreach (string include in includes.Split(char.Parse(",")))
                    {
						if (!string.IsNullOrEmpty(include))
                            query = query.Include(include);
                    }
                }
                    predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
					 	if (!preventSecurityRestrictions)
						{
							if (contextRequest != null )
		                    	if (contextRequest.User !=null )
		                        	if (contextRequest.Company != null){
		                        	
										predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
 									
									}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				query =query.AsExpandable().Where(predicate);
                query = ContextQueryBuilder<SDCaseHistory>.ApplyContextQuery(query, contextRequest);

                result = query.AsNoTracking().ToList<SDCaseHistory>();
				  
                if (e != null)
                {
                    e.Items = result;
                }
				//if (contextRequest != null ){
				//	 contextRequest = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
					contextRequest.CustomQuery = new CustomQuery();

				//}
				OnTaken(this, e == null ? e =  new BusinessRulesEventArgs<SDCaseHistory>() { Items= result, IncludingComputedLinq = false, ContextRequest = contextRequest,  FilterExpression = predicate } :  e);
  
			

                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
				*/
#endregion
            }
        }


		/*public int Update(List<SDCaseHistory> items, ContextRequest contextRequest)
            {
                int result = 0;
                using (EFContext con = new EFContext())
                {
                   
                

                    foreach (var item in items)
                    {
                        //secMessageToUser messageToUser = new secMessageToUser();
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            item.GetType().GetProperty(prop).SetValue(item, item.GetType().GetProperty(prop).GetValue(item));
                        }
                        //messageToUser.GuidMessageToUser = (Guid)item.GetType().GetProperty("GuidMessageToUser").GetValue(item);

                        var setObject = con.CreateObjectSet<SDCaseHistory>("SDCaseHistories");
                        //messageToUser.Readed = DateTime.UtcNow;
                        setObject.Attach(item);
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            con.ObjectStateManager.GetObjectStateEntry(item).SetModifiedProperty(prop);
                        }
                       
                    }
                    result = con.SaveChanges();

                    


                }
                return result;
            }
           */
		

        public List<SDCaseHistory> GetBy(string predicateString, ContextRequest contextRequest, string includes)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
				


				string computedFields = "";
				string fkIncludes = "SDCase,SDCaseState";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDCaseHistory>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					//if (contextRequest != null && contextRequest.Company != null)                      	
					//	 multitenantExpression = @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))";
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicateString, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression,computedFields);


	#region Old Code
	/*
				BusinessRulesEventArgs<SDCaseHistory> e = null;

				Filter filter = new Filter();
                if (predicateString.Contains("|"))
                {
                    string ft = GetSpecificFilter(predicateString, contextRequest);
                    if (!string.IsNullOrEmpty(ft))
                        filter.SetFilterPart("ft", ft);
                   
                    contextRequest.FreeText = predicateString.Split(char.Parse("|"))[1];
                    var q1 = predicateString.Split(char.Parse("|"))[0];
                    if (!string.IsNullOrEmpty(q1))
                    {
                        filter.ProcessText(q1);
                    }
                }
                else {
                    filter.ProcessText(predicateString);
                }
				 var includesList = (new List<string>());
                 if (!string.IsNullOrEmpty(includes))
                 {
                     includesList = includes.Split(char.Parse(",")).ToList();
                 }

				List<SDCaseHistory> result = new List<SDCaseHistory>();
         
			QueryBuild(predicateString, filter, con, contextRequest, "getby", includesList);
			 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }
				
				
					OnGetting(con, e == null ? e = new BusinessRulesEventArgs<SDCaseHistory>() { Filter = filter, ContextRequest = contextRequest  } : e );

                  //OnGetting(con,e = new BusinessRulesEventArgs<SDCaseHistory>() {  ContextRequest = contextRequest, FilterExpressionString = predicateString });
			   	if (e != null) {
				    //predicateString = e.GetQueryString();
						if (e.Cancel)
						{
							context = null;
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				//	 else {
                //      predicateString = predicateString.Replace("*extraFreeText*", "").Replace("()","");
                //  }
				//con.EnableChangeTrackingUsingProxies = false;
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                //if (predicate == null) predicate = PredicateBuilder.True<SDCaseHistory>();
 				string fkIncludes = "SDCase,SDCaseState";
                if(contextRequest!=null){
					if (contextRequest.CustomQuery != null)
					{
						if (contextRequest.CustomQuery.IncludeForeignKeyPaths != null) {
							if (contextRequest.CustomQuery.IncludeForeignKeyPaths.Value == false)
								fkIncludes = "";
						}
					}
				}else{
                    contextRequest = new ContextRequest();
                    contextRequest.CustomQuery = new CustomQuery();

                }
				if (!string.IsNullOrEmpty(includes))
					includes = includes + "," + fkIncludes;
				else
					includes = fkIncludes;
                
                //var es = _repository.Queryable;
				IQueryable<SDCaseHistory> query = con.SDCaseHistories.AsQueryable();
		
				// include relations FK
				if(string.IsNullOrEmpty(includes) ){
					includes ="";
				}
				StringBuilder sbQuerySystem = new StringBuilder();
                    //predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				

				//if (!string.IsNullOrEmpty(predicateString))
                //      sbQuerySystem.Append(" And ");
                //sbQuerySystem.Append(" (IsDeleted != true Or IsDeleted = null) ");
				 filter.SetFilterPart("de", "(IsDeleted != true OR IsDeleted = null)");


					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
	                    	if (contextRequest.User !=null )
	                        	if (contextRequest.Company != null ){
	                        		//if (sbQuerySystem.Length > 0)
	                        		//	    			sbQuerySystem.Append( " And ");	
									//sbQuerySystem.Append(@" (GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa

									filter.SetFilterPart("co",@"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))");

								}
						}	
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				//string predicateString = predicate.ToDynamicLinq<SDCaseHistory>();
				//predicateString += sbQuerySystem.ToString();
				filter.CleanAndProcess("");

				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed(); //SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicateString );               
                string predicateWithManyRelations = filter.GetFilterChildren(); //SFSdotNet.Framework.Linq.Utils.CleanPartExpression(predicateString);

                //QueryUtils.BreakeQuery1(predicateString, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
                var _queryable = query.AsQueryable();
				bool includeAll = true; 
                if (!string.IsNullOrEmpty(predicateWithManyRelations))
                    _queryable = _queryable.Where(predicateWithManyRelations, contextRequest.CustomQuery.ExtraParams);
				if (contextRequest.CustomQuery.SpecificProperties.Count > 0)
                {

				includeAll = false; 
                }

				StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append("new (");
                bool existPrev = false;
                foreach (var selected in contextRequest.CustomQuery.SelectedFields.Where(p=> !string.IsNullOrEmpty(p.Linq)))
                {
                    if (existPrev) sbSelect.Append(", ");
                    if (!selected.Linq.Contains(".") && !selected.Linq.StartsWith("it."))
                        sbSelect.Append("it." + selected.Linq);
                    else
                        sbSelect.Append(selected.Linq);
                    existPrev = true;
                }
                sbSelect.Append(")");
                var queryable = _queryable.Select(sbSelect.ToString());                    


     				
                 if (!string.IsNullOrEmpty(predicateWithFKAndComputed))
                    queryable = queryable.Where(predicateWithFKAndComputed, contextRequest.CustomQuery.ExtraParams);

				QueryComplementOptions queryOps = ContextQueryBuilder.ApplyContextQuery(contextRequest);
            	if (!string.IsNullOrEmpty(queryOps.OrderByAndSort)){
					if (queryOps.OrderBy.Contains(".") && !queryOps.OrderBy.StartsWith("it.")) queryOps.OrderBy = "it." + queryOps.OrderBy;
					queryable = queryable.OrderBy(queryOps.OrderByAndSort);
					}
               	if (queryOps.Skip != null)
                {
                    queryable = queryable.Skip(queryOps.Skip.Value);
                }
                if (queryOps.PageSize != null)
                {
                    queryable = queryable.Take (queryOps.PageSize.Value);
                }


                var resultTemp = queryable.AsQueryable().ToListAsync().Result;
                foreach (var item in resultTemp)
                {

				   result.Add(SFSdotNet.Framework.BR.Utils.GetConverted<SDCaseHistory,dynamic>(item, contextRequest.CustomQuery.SelectedFields.Select(p=>p.Name).ToArray()));
                }

			 if (e != null)
                {
                    e.Items = result;
                }
				 contextRequest.CustomQuery = new CustomQuery();
				OnTaken(this, e == null ? e = new BusinessRulesEventArgs<SDCaseHistory>() { Items= result, IncludingComputedLinq = true, ContextRequest = contextRequest, FilterExpressionString  = predicateString } :  e);
  
			
  
                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
	
	*/
	#endregion

            }
        }
		public SDCaseHistory GetFromOperation(string function, string filterString, string usemode, string fields, ContextRequest contextRequest)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
                string computedFields = "";
               // string fkIncludes = "accContpaqiClassification,accProjectConcept,accProjectType,accProxyUser";
                List<string> multilangProperties = new List<string>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					if (contextRequest != null && contextRequest.Company != null)
					{
						multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
						contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
					}
					 									
					string multiTenantField = "GuidCompany";


                return GetSummaryOperation(con, new SDCaseHistory(), function, filterString, usemode, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields, contextRequest, fields.Split(char.Parse(",")).ToArray());
            }
        }

   protected override void QueryBuild(string predicate, Filter filter, DbContext efContext, ContextRequest contextRequest, string method, List<string> includesList)
      	{
				if (contextRequest.CustomQuery.SpecificProperties.Count == 0)
                {
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistory.PropertyNames.GuidCase);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistory.PropertyNames.GuidCaseStatus);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistory.PropertyNames.BodyContent);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistory.PropertyNames.PreviewContent);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistory.PropertyNames.GuidCompany);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistory.PropertyNames.CreatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistory.PropertyNames.UpdatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistory.PropertyNames.CreatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistory.PropertyNames.UpdatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistory.PropertyNames.Bytes);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistory.PropertyNames.IsDeleted);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistory.PropertyNames.SDCase);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistory.PropertyNames.SDCaseState);
                    
				}

				if (method == "getby" || method == "sum")
				{
					if (!contextRequest.CustomQuery.SpecificProperties.Contains("GuidCaseHistory")){
						contextRequest.CustomQuery.SpecificProperties.Add("GuidCaseHistory");
					}

					 if (!string.IsNullOrEmpty(contextRequest.CustomQuery.OrderBy))
					{
						string existPropertyOrderBy = contextRequest.CustomQuery.OrderBy;
						if (contextRequest.CustomQuery.OrderBy.Contains("."))
						{
							existPropertyOrderBy = contextRequest.CustomQuery.OrderBy.Split(char.Parse("."))[0];
						}
						if (!contextRequest.CustomQuery.SpecificProperties.Exists(p => p == existPropertyOrderBy))
						{
							contextRequest.CustomQuery.SpecificProperties.Add(existPropertyOrderBy);
						}
					}

				}
				
	bool isFullDetails = contextRequest.IsFromUI("SDCaseHistories", UIActions.GetForDetails);
	string filterForTest = predicate  + filter.GetFilterComplete();

				if (isFullDetails || !string.IsNullOrEmpty(predicate))
            {
            } 

			if (method == "sum")
            {
            } 
			if (contextRequest.CustomQuery.SelectedFields.Count == 0)
            {
				foreach (var selected in contextRequest.CustomQuery.SpecificProperties)
                {
					string linq = selected;
					switch (selected)
                    {

					case "SDCase":
					if (includesList.Contains(selected)){
                        linq = "it.SDCase as SDCase";
					}
                    else
						linq = "new (it.SDCase.GuidCase, it.SDCase.BodyContent) as SDCase";
 					break;
					case "SDCaseState":
					if (includesList.Contains(selected)){
                        linq = "it.SDCaseState as SDCaseState";
					}
                    else
						linq = "iif(it.SDCaseState != null, new (it.SDCaseState.GuidCaseState, it.SDCaseState.Title), null) as SDCaseState";
 					break;
					 
						
					 default:
                            break;
                    }
					contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name=selected, Linq=linq});
					if (method == "getby" || method == "sum")
					{
						if (includesList.Contains(selected))
							includesList.Remove(selected);

					}

				}
			}
				if (method == "getby" || method == "sum")
				{
					foreach (var otherInclude in includesList.Where(p=> !string.IsNullOrEmpty(p)))
					{
						contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name = otherInclude, Linq = "it." + otherInclude +" as " + otherInclude });
					}
				}
				BusinessRulesEventArgs<SDCaseHistory> e = null;
				if (contextRequest.PreventInterceptors == false)
					OnQuerySettings(efContext, e = new BusinessRulesEventArgs<SDCaseHistory>() { Filter = filter, ContextRequest = contextRequest /*, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null)*/ });

				//List<SDCaseHistory> result = new List<SDCaseHistory>();
                 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }

}
		public List<SDCaseHistory> GetBy(Expression<Func<SDCaseHistory, bool>> predicate, bool loadRelations, ContextRequest contextRequest)
        {
			if(!loadRelations)
				return GetBy(predicate, contextRequest);
			else
				return GetBy(predicate, contextRequest, "SDCaseHistoryFiles");

        }

        public List<SDCaseHistory> GetBy(Expression<Func<SDCaseHistory, bool>> predicate, int? pageSize, int? page, string orderBy, SFSdotNet.Framework.Data.SortDirection? sortDirection)
        {
            return GetBy(predicate, new ContextRequest() { CustomQuery = new CustomQuery() { Page = page, PageSize = pageSize, OrderBy = orderBy, SortDirection = sortDirection } });
        }
        public List<SDCaseHistory> GetBy(Expression<Func<SDCaseHistory, bool>> predicate)
        {

			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
			contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
			            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            contextRequest.CustomQuery.FilterExpressionString = null;
            return this.GetBy(predicate, contextRequest, "");
        }
        #endregion
        #region Dynamic String
		protected override string GetSpecificFilter(string filter, ContextRequest contextRequest) {
            string result = "";
		    //string linqFilter = String.Empty;
            string freeTextFilter = String.Empty;
            if (filter.Contains("|"))
            {
               // linqFilter = filter.Split(char.Parse("|"))[0];
                freeTextFilter = filter.Split(char.Parse("|"))[1];
            }
            //else {
            //    freeTextFilter = filter;
            //}
            //else {
            //    linqFilter = filter;
            //}
			// linqFilter = SFSdotNet.Framework.Linq.Utils.ReplaceCustomDateFilters(linqFilter);
            //string specificFilter = linqFilter;
            if (!string.IsNullOrEmpty(freeTextFilter))
            {
                System.Text.StringBuilder sbCont = new System.Text.StringBuilder();
                /*if (specificFilter.Length > 0)
                {
                    sbCont.Append(" AND ");
                    sbCont.Append(" ({0})");
                }
                else
                {
                    sbCont.Append("{0}");
                }*/
                //var words = freeTextFilter.Split(char.Parse(" "));
				var word = freeTextFilter;
                System.Text.StringBuilder sbSpec = new System.Text.StringBuilder();
                 int nWords = 1;
				/*foreach (var word in words)
                {
					if (word.Length > 0){
                    if (sbSpec.Length > 0) sbSpec.Append(" AND ");
					if (words.Length > 1) sbSpec.Append("("); */
					
	
					
	
					
	
					
					
					
									
					sbSpec.Append(string.Format(@"BodyContent.Contains(""{0}"")", word));
					

					
					
										sbSpec.Append(" OR ");
					
									
					sbSpec.Append(string.Format(@"PreviewContent.Contains(""{0}"")", word));
					

					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
								sbSpec.Append(" OR ");
					
					//if (sbSpec.Length > 2)
					//	sbSpec.Append(" OR "); // test
					sbSpec.Append(string.Format(@"it.SDCase.BodyContent.Contains(""{0}"")", word)+" OR "+string.Format(@"it.SDCaseState.Title.Contains(""{0}"")", word));
								 //sbSpec.Append("*extraFreeText*");

                    /*if (words.Length > 1) sbSpec.Append(")");
					
					nWords++;

					}

                }*/
                //specificFilter = string.Format("{0}{1}", specificFilter, string.Format(sbCont.ToString(), sbSpec.ToString()));
                                 result = sbSpec.ToString();  
            }
			//result = specificFilter;
			
			return result;

		}
	
			public List<SDCaseHistory> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params object[] extraParams)
        {
			return GetBy(filter, pageSize, page, orderBy, orderDir,  null, extraParams);
		}
           public List<SDCaseHistory> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, string usemode, params object[] extraParams)
            { 
                return GetBy(filter, pageSize, page, orderBy, orderDir, usemode, null, extraParams);
            }


		public List<SDCaseHistory> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  string usemode, ContextRequest context, params object[] extraParams)

        {

            // string freetext = null;
            //if (filter.Contains("|"))
            //{
            //    int parts = filter.Split(char.Parse("|")).Count();
            //    if (parts > 1)
            //    {

            //        freetext = filter.Split(char.Parse("|"))[1];
            //    }
            //}
		
            //string specificFilter = "";
            //if (!string.IsNullOrEmpty(filter))
            //  specificFilter=  GetSpecificFilter(filter);
            if (string.IsNullOrEmpty(orderBy))
            {
			                orderBy = "UpdatedDate";
            }
			//orderDir = "desc";
			SFSdotNet.Framework.Data.SortDirection direction = SFSdotNet.Framework.Data.SortDirection.Ascending;
            if (!string.IsNullOrEmpty(orderDir))
            {
                if (orderDir == "desc")
                    direction = SFSdotNet.Framework.Data.SortDirection.Descending;
            }
            if (context == null)
                context = new ContextRequest();
			

             context.UseMode = usemode;
             if (context.CustomQuery == null )
                context.CustomQuery =new SFSdotNet.Framework.My.CustomQuery();

 
                context.CustomQuery.ExtraParams = extraParams;

                    context.CustomQuery.OrderBy = orderBy;
                   context.CustomQuery.SortDirection = direction;
                   context.CustomQuery.Page = page;
                  context.CustomQuery.PageSize = pageSize;
               

            

            if (!preventSecurityRestrictions) {
			 if (context.CurrentContext == null)
                {
					if (SFSdotNet.Framework.My.Context.CurrentContext != null &&  SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
					{
						context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
						context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

					}
					else {
						throw new Exception("The security rule require a specific user and company");
					}
				}
            }
            return GetBy(filter, context);
  
        }


        public List<SDCaseHistory> GetBy(string strWhere, ContextRequest contextRequest)
        {
        	#region old code
				
				 //Expression<Func<tvsReservationTransport, bool>> predicate = null;
				string strWhereClean = strWhere.Replace("*extraFreeText*", "").Replace("()", "");
                //if (!string.IsNullOrEmpty(strWhereClean)){

                //    object[] extraParams = null;
                //    //if (contextRequest != null )
                //    //    if (contextRequest.CustomQuery != null )
                //    //        extraParams = contextRequest.CustomQuery.ExtraParams;
                //    //predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<tvsReservationTransport, bool>(strWhereClean, extraParams != null? extraParams.Cast<Guid>(): null);				
                //}
				 if (contextRequest == null)
                {
                    contextRequest = new ContextRequest();
                    if (contextRequest.CustomQuery == null)
                        contextRequest.CustomQuery = new CustomQuery();
                }
                  if (!preventSecurityRestrictions) {
					if (contextRequest.User == null || contextRequest.Company == null)
                      {
                     if (SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
                     {
                         contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                         contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

                     }
                     else {
                         throw new Exception("The security rule require a specific User and Company ");
                     }
					 }
                 }
            contextRequest.CustomQuery.FilterExpressionString = strWhere;
				//return GetBy(predicate, contextRequest);  

			#endregion				
				
                    return GetBy(strWhere, contextRequest, "");  


        }
       public List<SDCaseHistory> GetBy(string strWhere)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
			
            return GetBy(strWhere, context, null);
        }

        public List<SDCaseHistory> GetBy(string strWhere, string includes)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
            return GetBy(strWhere, context, includes);
        }

        #endregion
        #endregion
		
		  #region SaveOrUpdate
        
 		 public SDCaseHistory Create(SDCaseHistory entity)
        {
				//ObjectContext context = null;
				    if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: Create");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

				return this.Create(entity, contextRequest);


        }
        
       
        public SDCaseHistory Create(SDCaseHistory entity, ContextRequest contextRequest)
        {
		
		bool graph = false;
	
				bool preventPartial = false;
                if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
               
			using (EFContext con = new EFContext()) {

				SDCaseHistory itemForSave = new SDCaseHistory();
#region Autos
		if(!preventSecurityRestrictions){

				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion
               BusinessRulesEventArgs<SDCaseHistory> e = null;
			    if (preventPartial == false )
                OnCreating(this,e = new BusinessRulesEventArgs<SDCaseHistory>() { ContextRequest = contextRequest, Item=entity });
				   if (e != null) {
						if (e.Cancel)
						{
							context = null;
							return e.Item;

						}
					}

                    if (entity.GuidCaseHistory == Guid.Empty)
                   {
                       entity.GuidCaseHistory = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   itemForSave.GuidCaseHistory = entity.GuidCaseHistory;
				  
		
			itemForSave.GuidCaseHistory = entity.GuidCaseHistory;

			itemForSave.BodyContent = entity.BodyContent;

			itemForSave.PreviewContent = entity.PreviewContent;

			itemForSave.GuidCompany = entity.GuidCompany;

			itemForSave.CreatedDate = entity.CreatedDate;

			itemForSave.UpdatedDate = entity.UpdatedDate;

			itemForSave.CreatedBy = entity.CreatedBy;

			itemForSave.UpdatedBy = entity.UpdatedBy;

			itemForSave.Bytes = entity.Bytes;

			itemForSave.IsDeleted = entity.IsDeleted;

				
				con.SDCaseHistories.Add(itemForSave);



					if (entity.SDCase != null)
					{
						var sDCase = new SDCase();
						sDCase.GuidCase = entity.SDCase.GuidCase;
						itemForSave.SDCase = sDCase;
						SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCase>(con, itemForSave.SDCase);
			
					}




					if (entity.SDCaseState != null)
					{
						var sDCaseState = new SDCaseState();
						sDCaseState.GuidCaseState = entity.SDCaseState.GuidCaseState;
						itemForSave.SDCaseState = sDCaseState;
						SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCaseState>(con, itemForSave.SDCaseState);
			
					}





                
				con.ChangeTracker.Entries().Where(p => p.Entity != itemForSave && p.State != EntityState.Unchanged).ForEach(p => p.State = EntityState.Detached);

				con.Entry<SDCaseHistory>(itemForSave).State = EntityState.Added;

				con.SaveChanges();

					 
				

				//itemResult = entity;
                //if (e != null)
                //{
                 //   e.Item = itemResult;
                //}
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false )
                OnCreated(this, e == null ? e = new BusinessRulesEventArgs<SDCaseHistory>() { ContextRequest = contextRequest, Item = entity } : e);



                if (e != null && e.Item != null )
                {
                    return e.Item;
                }
                              return entity;
			}
            
        }
        //BusinessRulesEventArgs<SDCaseHistory> e = null;
        public void Create(List<SDCaseHistory> entities)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            Create(entities, contextRequest);
        }
        public void Create(List<SDCaseHistory> entities, ContextRequest contextRequest)
        
        {
			ObjectContext context = null;
            	foreach (SDCaseHistory entity in entities)
				{
					this.Create(entity, contextRequest);
				}
        }
		  public void CreateOrUpdateBulk(List<SDCaseHistory> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "cu", contextRequest);
        }

        private void CreateOrUpdateBulk(List<SDCaseHistory> entities, string actionKey, ContextRequest contextRequest)
        {
			if (entities.Count() > 0){
            bool graph = false;

            bool preventPartial = false;
            if (contextRequest != null && contextRequest.PreventInterceptors == true)
            {
                preventPartial = true;
            }
            foreach (var entity in entities)
            {
                    if (entity.GuidCaseHistory == Guid.Empty)
                   {
                       entity.GuidCaseHistory = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   
				  


#region Autos
		if(!preventSecurityRestrictions){


 if (actionKey != "u")
                        {
				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;


}
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion


		
			//entity.GuidCaseHistory = entity.GuidCaseHistory;

			//entity.BodyContent = entity.BodyContent;

			//entity.PreviewContent = entity.PreviewContent;

			//entity.GuidCompany = entity.GuidCompany;

			//entity.CreatedDate = entity.CreatedDate;

			//entity.UpdatedDate = entity.UpdatedDate;

			//entity.CreatedBy = entity.CreatedBy;

			//entity.UpdatedBy = entity.UpdatedBy;

			//entity.Bytes = entity.Bytes;

			//entity.IsDeleted = entity.IsDeleted;

				
				



				    if (entity.SDCase != null)
					{
						//var sDCase = new SDCase();
						entity.GuidCase = entity.SDCase.GuidCase;
						//entity.SDCase = sDCase;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCase>(con, itemForSave.SDCase);
			
					}




				    if (entity.SDCaseState != null)
					{
						//var sDCaseState = new SDCaseState();
						entity.GuidCaseStatus = entity.SDCaseState.GuidCaseState;
						//entity.SDCaseState = sDCaseState;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCaseState>(con, itemForSave.SDCaseState);
			
					}





                
				

					 
				

				//itemResult = entity;
            }
            using (EFContext con = new EFContext())
            {
                 if (actionKey == "c")
                    {
                        context.BulkInsert(entities);
                    }else if ( actionKey == "u")
                    {
                        context.BulkUpdate(entities);
                    }else
                    {
                        context.BulkInsertOrUpdate(entities);
                    }
            }

			}
        }
	
		public void CreateBulk(List<SDCaseHistory> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "c", contextRequest);
        }


		public void UpdateAgile(SDCaseHistory item, params string[] fields)
         {
			UpdateAgile(item, null, fields);
        }
		public void UpdateAgile(SDCaseHistory item, ContextRequest contextRequest, params string[] fields)
         {
            
             ContextRequest contextNew = null;
             if (contextRequest != null)
             {
                 contextNew = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
                 if (fields != null && fields.Length > 0)
                 {
                     contextNew.CustomQuery.SpecificProperties  = fields.ToList();
                 }
                 else if(contextRequest.CustomQuery.SpecificProperties.Count > 0)
                 {
                     fields = contextRequest.CustomQuery.SpecificProperties.ToArray();
                 }
             }
			

		   using (EFContext con = new EFContext())
            {



               
					List<string> propForCopy = new List<string>();
                    propForCopy.AddRange(fields);
                    
					  
					if (!propForCopy.Contains("GuidCaseHistory"))
						propForCopy.Add("GuidCaseHistory");
					if (!propForCopy.Contains("GuidCase"))
						propForCopy.Add("GuidCase");
					if (!propForCopy.Contains("BodyContent"))
						propForCopy.Add("BodyContent");
					if (!propForCopy.Contains("SDCase"))
						propForCopy.Add("SDCase");

					var itemForUpdate = SFSdotNet.Framework.BR.Utils.GetConverted<SDCaseHistory,SDCaseHistory>(item, propForCopy.ToArray());
					 itemForUpdate.GuidCaseHistory = item.GuidCaseHistory;
                  var setT = con.Set<SDCaseHistory>().Attach(itemForUpdate);

					if (fields.Count() > 0)
					  {
						  item.ModifiedProperties = fields;
					  }
                    foreach (var property in item.ModifiedProperties)
					{						
                        if (property != "GuidCaseHistory")
                             con.Entry(setT).Property(property).IsModified = true;

                    }

                
               int result = con.SaveChanges();
               if (result != 1)
               {
                   SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: 1");
               }


            }

			OnUpdatedAgile(this, new BusinessRulesEventArgs<SDCaseHistory>() { Item = item, ContextRequest = contextNew  });

         }
		public void UpdateBulk(List<SDCaseHistory>  items, params string[] fields)
         {
             SFSdotNet.Framework.My.ContextRequest req = new SFSdotNet.Framework.My.ContextRequest();
             req.CustomQuery = new SFSdotNet.Framework.My.CustomQuery();
             foreach (var field in fields)
             {
                 req.CustomQuery.SpecificProperties.Add(field);
             }
             UpdateBulk(items, req);

         }

		 public void DeleteBulk(List<SDCaseHistory> entities, ContextRequest contextRequest = null)
        {

            using (EFContext con = new EFContext())
            {
                foreach (var entity in entities)
                {
					var entityProxy = new SDCaseHistory() { GuidCaseHistory = entity.GuidCaseHistory };

                    con.Entry<SDCaseHistory>(entityProxy).State = EntityState.Deleted;

                }

                int result = con.SaveChanges();
                if (result != entities.Count)
                {
                    SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: " + entities.Count.ToString());
                }
            }

        }

        public void UpdateBulk(List<SDCaseHistory> items, ContextRequest contextRequest)
        {
            if (items.Count() > 0){

			 foreach (var entity in items)
            {


#region Autos
		if(!preventSecurityRestrictions){

				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	



			}
#endregion




				    if (entity.SDCase != null)
					{
						//var sDCase = new SDCase();
						entity.GuidCase = entity.SDCase.GuidCase;
						//entity.SDCase = sDCase;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCase>(con, itemForSave.SDCase);
			
					}




				    if (entity.SDCaseState != null)
					{
						//var sDCaseState = new SDCaseState();
						entity.GuidCaseStatus = entity.SDCaseState.GuidCaseState;
						//entity.SDCaseState = sDCaseState;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCaseState>(con, itemForSave.SDCaseState);
			
					}





				}
				using (EFContext con = new EFContext())
				{

                    
                
                   con.BulkUpdate(items);

				}
             
			}	  
        }

         public SDCaseHistory Update(SDCaseHistory entity)
        {
            if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return Update(entity, contextRequest);
        }
       
         public SDCaseHistory Update(SDCaseHistory entity, ContextRequest contextRequest)
        {
		 if ((System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null) && contextRequest == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Update");
            }
            if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            }

			
				SDCaseHistory  itemResult = null;

	
			//entity.UpdatedDate = DateTime.Now.ToUniversalTime();
			//if(contextRequest.User != null)
				//entity.UpdatedBy = contextRequest.User.GuidUser;

//	    var oldentity = GetBy(p => p.GuidCaseHistory == entity.GuidCaseHistory, contextRequest).FirstOrDefault();
	//	if (oldentity != null) {
		
          //  entity.CreatedDate = oldentity.CreatedDate;
    //        entity.CreatedBy = oldentity.CreatedBy;
	
      //      entity.GuidCompany = oldentity.GuidCompany;
	
			

	
		//}

			 using( EFContext con = new EFContext()){
				BusinessRulesEventArgs<SDCaseHistory> e = null;
				bool preventPartial = false; 
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false)
                OnUpdating(this,e = new BusinessRulesEventArgs<SDCaseHistory>() { ContextRequest = contextRequest, Item=entity});
				   if (e != null) {
						if (e.Cancel)
						{
							//outcontext = null;
							return e.Item;

						}
					}

	string includes = "SDCase,SDCaseState";
	IQueryable < SDCaseHistory > query = con.SDCaseHistories.AsQueryable();
	foreach (string include in includes.Split(char.Parse(",")))
                       {
                           if (!string.IsNullOrEmpty(include))
                               query = query.Include(include);
                       }
	var oldentity = query.FirstOrDefault(p => p.GuidCaseHistory == entity.GuidCaseHistory);
	if (oldentity.BodyContent != entity.BodyContent)
		oldentity.BodyContent = entity.BodyContent;
	if (oldentity.PreviewContent != entity.PreviewContent)
		oldentity.PreviewContent = entity.PreviewContent;

				//if (entity.UpdatedDate == null || (contextRequest != null && contextRequest.IsFromUI("SDCaseHistories", UIActions.Updating)))
			oldentity.UpdatedDate = DateTime.Now.ToUniversalTime();
			if(contextRequest.User != null)
				oldentity.UpdatedBy = contextRequest.User.GuidUser;

           


						if (SFSdotNet.Framework.BR.Utils.HasRelationPropertyChanged(oldentity.SDCase, entity.SDCase, "GuidCase"))
							oldentity.SDCase = entity.SDCase != null? new SDCase(){ GuidCase = entity.SDCase.GuidCase } :null;

                


						if (SFSdotNet.Framework.BR.Utils.HasRelationPropertyChanged(oldentity.SDCaseState, entity.SDCaseState, "GuidCaseState"))
							oldentity.SDCaseState = entity.SDCaseState != null? new SDCaseState(){ GuidCaseState = entity.SDCaseState.GuidCaseState } :null;

                


				if (entity.SDCaseHistoryFiles != null)
                {
                    foreach (var item in entity.SDCaseHistoryFiles)
                    {


                        
                    }
					
                    

                }


				con.ChangeTracker.Entries().Where(p => p.Entity != oldentity).ForEach(p => p.State = EntityState.Unchanged);  
				  
				con.SaveChanges();
        
					 
					
               
				itemResult = entity;
				if(preventPartial == false)
					OnUpdated(this, e = new BusinessRulesEventArgs<SDCaseHistory>() { ContextRequest = contextRequest, Item=itemResult });

              	return itemResult;
			}
			  
        }
        public SDCaseHistory Save(SDCaseHistory entity)
        {
			return Create(entity);
        }
        public int Save(List<SDCaseHistory> entities)
        {
			 Create(entities);
            return entities.Count;

        }
        #endregion
        #region Delete
        public void Delete(SDCaseHistory entity)
        {
				this.Delete(entity, null);
			
        }
		 public void Delete(SDCaseHistory entity, ContextRequest contextRequest)
        {
				
				  List<SDCaseHistory> entities = new List<SDCaseHistory>();
				   entities.Add(entity);
				this.Delete(entities, contextRequest);
			
        }

         public void Delete(string query, Guid[] guids, ContextRequest contextRequest)
        {
			var br = new SDCaseHistoriesBR(true);
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);
            
            Delete(items, contextRequest);

        }
        public void Delete(SDCaseHistory entity,  ContextRequest contextRequest, BusinessRulesEventArgs<SDCaseHistory> e = null)
        {
			
				using(EFContext con = new EFContext())
                 {
				
               	BusinessRulesEventArgs<SDCaseHistory> _e = null;
               List<SDCaseHistory> _items = new List<SDCaseHistory>();
                _items.Add(entity);
                if (e == null || e.PreventPartialPropagate == false)
                {
                    OnDeleting(this, _e = (e == null ? new BusinessRulesEventArgs<SDCaseHistory>() { ContextRequest = contextRequest, Item = entity, Items = null  } : e));
                }
                if (_e != null)
                {
                    if (_e.Cancel)
						{
							context = null;
							return;

						}
					}


				
									//IsDeleted
					bool logicDelete = true;
					if (entity.IsDeleted != null)
					{
						if (entity.IsDeleted.Value)
							logicDelete = false;
					}
					if (logicDelete)
					{
											//entity = GetBy(p =>, contextRequest).FirstOrDefault();
						entity.IsDeleted = true;
						if (contextRequest != null && contextRequest.User != null)
							entity.UpdatedBy = contextRequest.User.GuidUser;
                        entity.UpdatedDate = DateTime.UtcNow;
						UpdateAgile(entity, "IsDeleted","UpdatedBy","UpdatedDate");

						
					}
					else {
					con.Entry<SDCaseHistory>(entity).State = EntityState.Deleted;
					con.SaveChanges();
				
				 
					}
								
				
				 
					
					
			if (e == null || e.PreventPartialPropagate == false)
                {

                    if (_e == null)
                        _e = new BusinessRulesEventArgs<SDCaseHistory>() { ContextRequest = contextRequest, Item = entity, Items = null };

                    OnDeleted(this, _e);
                }

				//return null;
			}
        }
 public void UnDelete(string query, Guid[] guids, ContextRequest contextRequest)
        {
            var br = new SDCaseHistoriesBR(true);
            contextRequest.CustomQuery.IncludeDeleted = true;
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);

            foreach (var item in items)
            {
                item.IsDeleted = false;
						if (contextRequest != null && contextRequest.User != null)
							item.UpdatedBy = contextRequest.User.GuidUser;
                        item.UpdatedDate = DateTime.UtcNow;
            }

            UpdateBulk(items, "IsDeleted","UpdatedBy","UpdatedDate");
        }

         public void Delete(List<SDCaseHistory> entities,  ContextRequest contextRequest = null )
        {
				
			 BusinessRulesEventArgs<SDCaseHistory> _e = null;

                OnDeleting(this, _e = new BusinessRulesEventArgs<SDCaseHistory>() { ContextRequest = contextRequest, Item = null, Items = entities });
                if (_e != null)
                {
                    if (_e.Cancel)
                    {
                        context = null;
                        return;

                    }
                }
                bool allSucced = true;
                BusinessRulesEventArgs<SDCaseHistory> eToChilds = new BusinessRulesEventArgs<SDCaseHistory>();
                if (_e != null)
                {
                    eToChilds = _e;
                }
                else
                {
                    eToChilds = new BusinessRulesEventArgs<SDCaseHistory>() { ContextRequest = contextRequest, Item = (entities.Count == 1 ? entities[0] : null), Items = entities };
                }
				foreach (SDCaseHistory item in entities)
				{
					try
                    {
                        this.Delete(item, contextRequest, e: eToChilds);
                    }
                    catch (Exception ex)
                    {
                        SFSdotNet.Framework.My.EventLog.Error(ex);
                        allSucced = false;
                    }
				}
				if (_e == null)
                    _e = new BusinessRulesEventArgs<SDCaseHistory>() { ContextRequest = contextRequest, CountResult = entities.Count, Item = null, Items = entities };
                OnDeleted(this, _e);

			
        }
        #endregion
 
        #region GetCount
		 public int GetCount(Expression<Func<SDCaseHistory, bool>> predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

			return GetCount(predicate, contextRequest);
		}
        public int GetCount(Expression<Func<SDCaseHistory, bool>> predicate, ContextRequest contextRequest)
        {


		
		 using (EFContext con = new EFContext())
            {


				if (predicate == null) predicate = PredicateBuilder.True<SDCaseHistory>();
           		predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted == null);
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    		if (contextRequest.User !=null )
                        		if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
									predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa

								}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				
				IQueryable<SDCaseHistory> query = con.SDCaseHistories.AsQueryable();
                return query.AsExpandable().Count(predicate);

			
				}
			

        }
		  public int GetCount(string predicate,  ContextRequest contextRequest)
         {
             return GetCount(predicate, null, contextRequest);
         }

         public int GetCount(string predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return GetCount(predicate, contextRequest);
        }
		 public int GetCount(string predicate, string usemode){
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
				return GetCount( predicate,  usemode,  contextRequest);
		 }
        public int GetCount(string predicate, string usemode, ContextRequest contextRequest){

		using (EFContext con = new EFContext()) {
				string computedFields = "";
				string fkIncludes = "SDCase,SDCaseState";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDCaseHistory>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetCount(con, predicate, usemode, contextRequest, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields);

			}
			#region old code
			 /* string freetext = null;
            Filter filter = new Filter();

              if (predicate.Contains("|"))
              {
                 
                  filter.SetFilterPart("ft", GetSpecificFilter(predicate, contextRequest));
                 
                  filter.ProcessText(predicate.Split(char.Parse("|"))[0]);
                  freetext = predicate.Split(char.Parse("|"))[1];

				  if (!string.IsNullOrEmpty(freetext) && string.IsNullOrEmpty(contextRequest.FreeText))
                  {
                      contextRequest.FreeText = freetext;
                  }
              }
              else {
                  filter.ProcessText(predicate);
              }
			   predicate = filter.GetFilterComplete();
			// BusinessRulesEventArgs<SDCaseHistory>  e = null;
           	using (EFContext con = new EFContext())
			{
			
			

			 QueryBuild(predicate, filter, con, contextRequest, "count", new List<string>());


			
			BusinessRulesEventArgs<SDCaseHistory> e = null;

			contextRequest.FreeText = freetext;
			contextRequest.UseMode = usemode;
            OnCounting(this, e = new BusinessRulesEventArgs<SDCaseHistory>() {  Filter =filter, ContextRequest = contextRequest });
            if (e != null)
            {
                if (e.Cancel)
                {
                    context = null;
                    return e.CountResult;

                }

            

            }
			
			StringBuilder sbQuerySystem = new StringBuilder();
		
					
                    filter.SetFilterPart("de","(IsDeleted != true OR IsDeleted == null)");
			
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    	if (contextRequest.User !=null )
                        	if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
                        		
								filter.SetFilterPart("co", @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa
						
						
							}
							
							}
							if (preventSecurityRestrictions) preventSecurityRestrictions= false;
		
				   
                 filter.CleanAndProcess("");
				//string predicateWithFKAndComputed = SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicate );               
				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed();
               string predicateWithManyRelations = filter.GetFilterChildren();
			   ///QueryUtils.BreakeQuery1(predicate, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
			   predicate = filter.GetFilterComplete();
               if (!string.IsNullOrEmpty(predicate))
               {
				
					
                    return con.SDCaseHistories.Where(predicate).Count();
					
                }else
                    return con.SDCaseHistories.Count();
					
			}*/
			#endregion

		}
         public int GetCount()
        {
            return GetCount(p => true);
        }
        #endregion
        
         


        public void Delete(List<SDCaseHistory.CompositeKey> entityKeys)
        {

            List<SDCaseHistory> items = new List<SDCaseHistory>();
            foreach (var itemKey in entityKeys)
            {
                items.Add(GetByKey(itemKey.GuidCaseHistory));
            }

            Delete(items);

        }
		 public void UpdateAssociation(string relation, string relationValue, string query, Guid[] ids, ContextRequest contextRequest)
        {
            var items = GetBy(query, null, null, null, null, null, contextRequest, ids);
			 var module = SFSdotNet.Framework.Cache.Caching.SystemObjects.GetModuleByKey(SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(System.Web.HttpContext.Current.Request.RequestContext, "area"));
           
            foreach (var item in items)
            {
			  Guid ? guidRelationValue = null ;
                if (!string.IsNullOrEmpty(relationValue)){
                    guidRelationValue = Guid.Parse(relationValue );
                }

				 if (relation.Contains("."))
                {
                    var partsWithOtherProp = relation.Split(char.Parse("|"));
                    var parts = partsWithOtherProp[0].Split(char.Parse("."));

                    string proxyRelName = parts[0];
                    string proxyProperty = parts[1];
                    string proxyPropertyKeyNameFromOther = partsWithOtherProp[1];
                    //string proxyPropertyThis = parts[2];

                    var prop = item.GetType().GetProperty(proxyRelName);
                    //var entityInfo = //SFSdotNet.Framework.
                    // descubrir el tipo de entidad dentro de la colección
                    Type typeEntityInList = SFSdotNet.Framework.Entities.Utils.GetTypeFromList(prop);
                    var newProxyItem = Activator.CreateInstance(typeEntityInList);
                    var propThisForSet = newProxyItem.GetType().GetProperty(proxyProperty);
                    var entityInfoOfProxy = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(typeEntityInList);
                    var propOther = newProxyItem.GetType().GetProperty(proxyPropertyKeyNameFromOther);

                    if (propThisForSet != null && entityInfoOfProxy != null && propOther != null )
                    {
                        var entityInfoThis = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(item.GetType());
                        var valueThisId = item.GetType().GetProperty(entityInfoThis.PropertyKeyName).GetValue(item);
                        if (valueThisId != null)
                            propThisForSet.SetValue(newProxyItem, valueThisId);
                        propOther.SetValue(newProxyItem, Guid.Parse(relationValue));
                        
                        var entityNameProp = newProxyItem.GetType().GetField("EntityName").GetValue(null);
                        var entitySetNameProp = newProxyItem.GetType().GetField("EntitySetName").GetValue(null);

                        SFSdotNet.Framework.Apps.Integration.CreateItemFromApp(entityNameProp.ToString(), entitySetNameProp.ToString(), module.ModuleNamespace, newProxyItem, contextRequest);

                    }

                    // crear una instancia del tipo de entidad
                    // llenar los datos y registrar nuevo


                }
                else
                {
                var prop = item.GetType().GetProperty(relation);
                var entityInfo = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(prop.PropertyType);
                if (entityInfo != null)
                {
                    var ins = Activator.CreateInstance(prop.PropertyType);
                   if (guidRelationValue != null)
                    {
                        prop.PropertyType.GetProperty(entityInfo.PropertyKeyName).SetValue(ins, guidRelationValue);
                        item.GetType().GetProperty(relation).SetValue(item, ins);
                    }
                    else
                    {
                        item.GetType().GetProperty(relation).SetValue(item, null);
                    }

                    Update(item, contextRequest);
                }

				}
            }
        }
		
	}
		public partial class SDCaseHistoryFilesBR:BRBase<SDCaseHistoryFile>{
	 	
           
		 #region Partial methods

           partial void OnUpdating(object sender, BusinessRulesEventArgs<SDCaseHistoryFile> e);

            partial void OnUpdated(object sender, BusinessRulesEventArgs<SDCaseHistoryFile> e);
			partial void OnUpdatedAgile(object sender, BusinessRulesEventArgs<SDCaseHistoryFile> e);

            partial void OnCreating(object sender, BusinessRulesEventArgs<SDCaseHistoryFile> e);
            partial void OnCreated(object sender, BusinessRulesEventArgs<SDCaseHistoryFile> e);

            partial void OnDeleting(object sender, BusinessRulesEventArgs<SDCaseHistoryFile> e);
            partial void OnDeleted(object sender, BusinessRulesEventArgs<SDCaseHistoryFile> e);

            partial void OnGetting(object sender, BusinessRulesEventArgs<SDCaseHistoryFile> e);
            protected override void OnVirtualGetting(object sender, BusinessRulesEventArgs<SDCaseHistoryFile> e)
            {
                OnGetting(sender, e);
            }
			protected override void OnVirtualCounting(object sender, BusinessRulesEventArgs<SDCaseHistoryFile> e)
            {
                OnCounting(sender, e);
            }
			partial void OnTaken(object sender, BusinessRulesEventArgs<SDCaseHistoryFile> e);
			protected override void OnVirtualTaken(object sender, BusinessRulesEventArgs<SDCaseHistoryFile> e)
            {
                OnTaken(sender, e);
            }

            partial void OnCounting(object sender, BusinessRulesEventArgs<SDCaseHistoryFile> e);
 
			partial void OnQuerySettings(object sender, BusinessRulesEventArgs<SDCaseHistoryFile> e);
          
            #endregion
			
		private static SDCaseHistoryFilesBR singlenton =null;
				public static SDCaseHistoryFilesBR NewInstance(){
					return  new SDCaseHistoryFilesBR();
					
				}
		public static SDCaseHistoryFilesBR Instance{
			get{
				if (singlenton == null)
					singlenton = new SDCaseHistoryFilesBR();
				return singlenton;
			}
		}
		//private bool preventSecurityRestrictions = false;
		 public bool PreventAuditTrail { get; set;  }
		#region Fields
        EFContext context = null;
        #endregion
        #region Constructor
        public SDCaseHistoryFilesBR()
        {
            context = new EFContext();
        }
		 public SDCaseHistoryFilesBR(bool preventSecurity)
            {
                this.preventSecurityRestrictions = preventSecurity;
				context = new EFContext();
            }
        #endregion
		
		#region Get

 		public IQueryable<SDCaseHistoryFile> Get()
        {
            using (EFContext con = new EFContext())
            {
				
				var query = con.SDCaseHistoryFiles.AsQueryable();
                con.Configuration.ProxyCreationEnabled = false;

                //query = ContextQueryBuilder<Nutrient>.ApplyContextQuery(query, contextRequest);

                return query;




            }

        }
		


 	
		public List<SDCaseHistoryFile> GetAll()
        {
            return this.GetBy(p => true);
        }
        public List<SDCaseHistoryFile> GetAll(string includes)
        {
            return this.GetBy(p => true, includes);
        }
        public SDCaseHistoryFile GetByKey(Guid guidCasehistoryFile)
        {
            return GetByKey(guidCasehistoryFile, true);
        }
        public SDCaseHistoryFile GetByKey(Guid guidCasehistoryFile, bool loadIncludes)
        {
            SDCaseHistoryFile item = null;
			var query = PredicateBuilder.True<SDCaseHistoryFile>();
                    
			string strWhere = @"GuidCasehistoryFile = Guid(""" + guidCasehistoryFile.ToString()+@""")";
            Expression<Func<SDCaseHistoryFile, bool>> predicate = null;
            //if (!string.IsNullOrEmpty(strWhere))
            //    predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDCaseHistoryFile, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
			 ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
            contextRequest.CustomQuery.FilterExpressionString = strWhere;

			//item = GetBy(predicate, loadIncludes, contextRequest).FirstOrDefault();
			item = GetBy(strWhere,loadIncludes,contextRequest).FirstOrDefault();
            return item;
        }
         public List<SDCaseHistoryFile> GetBy(string strWhere, bool loadRelations, ContextRequest contextRequest)
        {
            if (!loadRelations)
                return GetBy(strWhere, contextRequest);
            else
                return GetBy(strWhere, contextRequest, "");

        }
		  public List<SDCaseHistoryFile> GetBy(string strWhere, bool loadRelations)
        {
              if (!loadRelations)
                return GetBy(strWhere, new ContextRequest());
            else
                return GetBy(strWhere, new ContextRequest(), "");

        }
		         public SDCaseHistoryFile GetByKey(Guid guidCasehistoryFile, params Expression<Func<SDCaseHistoryFile, object>>[] includes)
        {
            SDCaseHistoryFile item = null;
			string strWhere = @"GuidCasehistoryFile = Guid(""" + guidCasehistoryFile.ToString()+@""")";
          Expression<Func<SDCaseHistoryFile, bool>> predicate = p=> p.GuidCasehistoryFile == guidCasehistoryFile;
           // if (!string.IsNullOrEmpty(strWhere))
           //     predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDCaseHistoryFile, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
        item = GetBy(predicate, includes).FirstOrDefault();
         ////   item = GetBy(strWhere,includes).FirstOrDefault();
			return item;

        }
        public SDCaseHistoryFile GetByKey(Guid guidCasehistoryFile, string includes)
        {
            SDCaseHistoryFile item = null;
			string strWhere = @"GuidCasehistoryFile = Guid(""" + guidCasehistoryFile.ToString()+@""")";
            
			
            item = GetBy(strWhere, includes).FirstOrDefault();
            return item;

        }
		 public SDCaseHistoryFile GetByKey(Guid guidCasehistoryFile, string usemode, string includes)
		{
			return GetByKey(guidCasehistoryFile, usemode, null, includes);

		 }
		 public SDCaseHistoryFile GetByKey(Guid guidCasehistoryFile, string usemode, ContextRequest context,  string includes)
        {
            SDCaseHistoryFile item = null;
			string strWhere = @"GuidCasehistoryFile = Guid(""" + guidCasehistoryFile.ToString()+@""")";
			if (context == null){
				context = new ContextRequest();
				context.CustomQuery = new CustomQuery();
				context.CustomQuery.IsByKey = true;
				context.CustomQuery.FilterExpressionString = strWhere;
				context.UseMode = usemode;
			}
            item = GetBy(strWhere,context , includes).FirstOrDefault();
            return item;

        }

        #region Dynamic Predicate
        public List<SDCaseHistoryFile> GetBy(Expression<Func<SDCaseHistoryFile, bool>> predicate, int? pageSize, int? page)
        {
            return this.GetBy(predicate, pageSize, page, null, null);
        }
        public List<SDCaseHistoryFile> GetBy(Expression<Func<SDCaseHistoryFile, bool>> predicate, ContextRequest contextRequest)
        {

            return GetBy(predicate, contextRequest,"");
        }
        
        public List<SDCaseHistoryFile> GetBy(Expression<Func<SDCaseHistoryFile, bool>> predicate, ContextRequest contextRequest, params Expression<Func<SDCaseHistoryFile, object>>[] includes)
        {
            StringBuilder sb = new StringBuilder();
           if (includes != null)
            {
                foreach (var path in includes)
                {

						if (sb.Length > 0) sb.Append(",");
						sb.Append(SFSdotNet.Framework.Linq.Utils.IncludeToString<SDCaseHistoryFile>(path));

               }
            }
            return GetBy(predicate, contextRequest, sb.ToString());
        }
        
        
        public List<SDCaseHistoryFile> GetBy(Expression<Func<SDCaseHistoryFile, bool>> predicate, string includes)
        {
			ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";

            return GetBy(predicate, context, includes);
        }

        public List<SDCaseHistoryFile> GetBy(Expression<Func<SDCaseHistoryFile, bool>> predicate, params Expression<Func<SDCaseHistoryFile, object>>[] includes)
        {
			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest context = new ContextRequest();
			            context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";
            return GetBy(predicate, context, includes);
        }

      
		public bool DisableCache { get; set; }
		public List<SDCaseHistoryFile> GetBy(Expression<Func<SDCaseHistoryFile, bool>> predicate, ContextRequest contextRequest, string includes)
		{
            using (EFContext con = new EFContext()) {
				
				string fkIncludes = "SDCaseHistory,SDFile";
                List<string> multilangProperties = new List<string>();
				if (predicate == null) predicate = PredicateBuilder.True<SDCaseHistoryFile>();
                var notDeletedExpression = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;
					Expression<Func<SDCaseHistoryFile,bool>> multitenantExpression  = null;
					if (contextRequest != null && contextRequest.Company != null)	                        	
						multitenantExpression = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicate, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression);

#region Old code
/*
				List<SDCaseHistoryFile> result = null;
               BusinessRulesEventArgs<SDCaseHistoryFile>  e = null;
	
				OnGetting(con, e = new BusinessRulesEventArgs<SDCaseHistoryFile>() {  FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null) });

               // OnGetting(con,e = new BusinessRulesEventArgs<SDCaseHistoryFile>() { FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = contextRequest.CustomQuery.FilterExpressionString});
				   if (e != null) {
				    predicate = e.FilterExpression;
						if (e.Cancel)
						{
							context = null;
							 if (e.Items == null) e.Items = new List<SDCaseHistoryFile>();
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                if (predicate == null) predicate = PredicateBuilder.True<SDCaseHistoryFile>();
 				string fkIncludes = "SDCaseHistory,SDFile";
                if(contextRequest!=null){
					if (contextRequest.CustomQuery != null)
					{
						if (contextRequest.CustomQuery.IncludeForeignKeyPaths != null) {
							if (contextRequest.CustomQuery.IncludeForeignKeyPaths.Value == false)
								fkIncludes = "";
						}
					}
				}
				if (!string.IsNullOrEmpty(includes))
					includes = includes + "," + fkIncludes;
				else
					includes = fkIncludes;
                
                //var es = _repository.Queryable;

                IQueryable<SDCaseHistoryFile> query =  con.SDCaseHistoryFiles.AsQueryable();

                                if (!string.IsNullOrEmpty(includes))
                {
                    foreach (string include in includes.Split(char.Parse(",")))
                    {
						if (!string.IsNullOrEmpty(include))
                            query = query.Include(include);
                    }
                }
                    predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
					 	if (!preventSecurityRestrictions)
						{
							if (contextRequest != null )
		                    	if (contextRequest.User !=null )
		                        	if (contextRequest.Company != null){
		                        	
										predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
 									
									}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				query =query.AsExpandable().Where(predicate);
                query = ContextQueryBuilder<SDCaseHistoryFile>.ApplyContextQuery(query, contextRequest);

                result = query.AsNoTracking().ToList<SDCaseHistoryFile>();
				  
                if (e != null)
                {
                    e.Items = result;
                }
				//if (contextRequest != null ){
				//	 contextRequest = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
					contextRequest.CustomQuery = new CustomQuery();

				//}
				OnTaken(this, e == null ? e =  new BusinessRulesEventArgs<SDCaseHistoryFile>() { Items= result, IncludingComputedLinq = false, ContextRequest = contextRequest,  FilterExpression = predicate } :  e);
  
			

                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
				*/
#endregion
            }
        }


		/*public int Update(List<SDCaseHistoryFile> items, ContextRequest contextRequest)
            {
                int result = 0;
                using (EFContext con = new EFContext())
                {
                   
                

                    foreach (var item in items)
                    {
                        //secMessageToUser messageToUser = new secMessageToUser();
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            item.GetType().GetProperty(prop).SetValue(item, item.GetType().GetProperty(prop).GetValue(item));
                        }
                        //messageToUser.GuidMessageToUser = (Guid)item.GetType().GetProperty("GuidMessageToUser").GetValue(item);

                        var setObject = con.CreateObjectSet<SDCaseHistoryFile>("SDCaseHistoryFiles");
                        //messageToUser.Readed = DateTime.UtcNow;
                        setObject.Attach(item);
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            con.ObjectStateManager.GetObjectStateEntry(item).SetModifiedProperty(prop);
                        }
                       
                    }
                    result = con.SaveChanges();

                    


                }
                return result;
            }
           */
		

        public List<SDCaseHistoryFile> GetBy(string predicateString, ContextRequest contextRequest, string includes)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
				


				string computedFields = "";
				string fkIncludes = "SDCaseHistory,SDFile";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDCaseHistoryFile>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					//if (contextRequest != null && contextRequest.Company != null)                      	
					//	 multitenantExpression = @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))";
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicateString, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression,computedFields);


	#region Old Code
	/*
				BusinessRulesEventArgs<SDCaseHistoryFile> e = null;

				Filter filter = new Filter();
                if (predicateString.Contains("|"))
                {
                    string ft = GetSpecificFilter(predicateString, contextRequest);
                    if (!string.IsNullOrEmpty(ft))
                        filter.SetFilterPart("ft", ft);
                   
                    contextRequest.FreeText = predicateString.Split(char.Parse("|"))[1];
                    var q1 = predicateString.Split(char.Parse("|"))[0];
                    if (!string.IsNullOrEmpty(q1))
                    {
                        filter.ProcessText(q1);
                    }
                }
                else {
                    filter.ProcessText(predicateString);
                }
				 var includesList = (new List<string>());
                 if (!string.IsNullOrEmpty(includes))
                 {
                     includesList = includes.Split(char.Parse(",")).ToList();
                 }

				List<SDCaseHistoryFile> result = new List<SDCaseHistoryFile>();
         
			QueryBuild(predicateString, filter, con, contextRequest, "getby", includesList);
			 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }
				
				
					OnGetting(con, e == null ? e = new BusinessRulesEventArgs<SDCaseHistoryFile>() { Filter = filter, ContextRequest = contextRequest  } : e );

                  //OnGetting(con,e = new BusinessRulesEventArgs<SDCaseHistoryFile>() {  ContextRequest = contextRequest, FilterExpressionString = predicateString });
			   	if (e != null) {
				    //predicateString = e.GetQueryString();
						if (e.Cancel)
						{
							context = null;
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				//	 else {
                //      predicateString = predicateString.Replace("*extraFreeText*", "").Replace("()","");
                //  }
				//con.EnableChangeTrackingUsingProxies = false;
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                //if (predicate == null) predicate = PredicateBuilder.True<SDCaseHistoryFile>();
 				string fkIncludes = "SDCaseHistory,SDFile";
                if(contextRequest!=null){
					if (contextRequest.CustomQuery != null)
					{
						if (contextRequest.CustomQuery.IncludeForeignKeyPaths != null) {
							if (contextRequest.CustomQuery.IncludeForeignKeyPaths.Value == false)
								fkIncludes = "";
						}
					}
				}else{
                    contextRequest = new ContextRequest();
                    contextRequest.CustomQuery = new CustomQuery();

                }
				if (!string.IsNullOrEmpty(includes))
					includes = includes + "," + fkIncludes;
				else
					includes = fkIncludes;
                
                //var es = _repository.Queryable;
				IQueryable<SDCaseHistoryFile> query = con.SDCaseHistoryFiles.AsQueryable();
		
				// include relations FK
				if(string.IsNullOrEmpty(includes) ){
					includes ="";
				}
				StringBuilder sbQuerySystem = new StringBuilder();
                    //predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				

				//if (!string.IsNullOrEmpty(predicateString))
                //      sbQuerySystem.Append(" And ");
                //sbQuerySystem.Append(" (IsDeleted != true Or IsDeleted = null) ");
				 filter.SetFilterPart("de", "(IsDeleted != true OR IsDeleted = null)");


					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
	                    	if (contextRequest.User !=null )
	                        	if (contextRequest.Company != null ){
	                        		//if (sbQuerySystem.Length > 0)
	                        		//	    			sbQuerySystem.Append( " And ");	
									//sbQuerySystem.Append(@" (GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa

									filter.SetFilterPart("co",@"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))");

								}
						}	
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				//string predicateString = predicate.ToDynamicLinq<SDCaseHistoryFile>();
				//predicateString += sbQuerySystem.ToString();
				filter.CleanAndProcess("");

				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed(); //SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicateString );               
                string predicateWithManyRelations = filter.GetFilterChildren(); //SFSdotNet.Framework.Linq.Utils.CleanPartExpression(predicateString);

                //QueryUtils.BreakeQuery1(predicateString, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
                var _queryable = query.AsQueryable();
				bool includeAll = true; 
                if (!string.IsNullOrEmpty(predicateWithManyRelations))
                    _queryable = _queryable.Where(predicateWithManyRelations, contextRequest.CustomQuery.ExtraParams);
				if (contextRequest.CustomQuery.SpecificProperties.Count > 0)
                {

				includeAll = false; 
                }

				StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append("new (");
                bool existPrev = false;
                foreach (var selected in contextRequest.CustomQuery.SelectedFields.Where(p=> !string.IsNullOrEmpty(p.Linq)))
                {
                    if (existPrev) sbSelect.Append(", ");
                    if (!selected.Linq.Contains(".") && !selected.Linq.StartsWith("it."))
                        sbSelect.Append("it." + selected.Linq);
                    else
                        sbSelect.Append(selected.Linq);
                    existPrev = true;
                }
                sbSelect.Append(")");
                var queryable = _queryable.Select(sbSelect.ToString());                    


     				
                 if (!string.IsNullOrEmpty(predicateWithFKAndComputed))
                    queryable = queryable.Where(predicateWithFKAndComputed, contextRequest.CustomQuery.ExtraParams);

				QueryComplementOptions queryOps = ContextQueryBuilder.ApplyContextQuery(contextRequest);
            	if (!string.IsNullOrEmpty(queryOps.OrderByAndSort)){
					if (queryOps.OrderBy.Contains(".") && !queryOps.OrderBy.StartsWith("it.")) queryOps.OrderBy = "it." + queryOps.OrderBy;
					queryable = queryable.OrderBy(queryOps.OrderByAndSort);
					}
               	if (queryOps.Skip != null)
                {
                    queryable = queryable.Skip(queryOps.Skip.Value);
                }
                if (queryOps.PageSize != null)
                {
                    queryable = queryable.Take (queryOps.PageSize.Value);
                }


                var resultTemp = queryable.AsQueryable().ToListAsync().Result;
                foreach (var item in resultTemp)
                {

				   result.Add(SFSdotNet.Framework.BR.Utils.GetConverted<SDCaseHistoryFile,dynamic>(item, contextRequest.CustomQuery.SelectedFields.Select(p=>p.Name).ToArray()));
                }

			 if (e != null)
                {
                    e.Items = result;
                }
				 contextRequest.CustomQuery = new CustomQuery();
				OnTaken(this, e == null ? e = new BusinessRulesEventArgs<SDCaseHistoryFile>() { Items= result, IncludingComputedLinq = true, ContextRequest = contextRequest, FilterExpressionString  = predicateString } :  e);
  
			
  
                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
	
	*/
	#endregion

            }
        }
		public SDCaseHistoryFile GetFromOperation(string function, string filterString, string usemode, string fields, ContextRequest contextRequest)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
                string computedFields = "";
               // string fkIncludes = "accContpaqiClassification,accProjectConcept,accProjectType,accProxyUser";
                List<string> multilangProperties = new List<string>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					if (contextRequest != null && contextRequest.Company != null)
					{
						multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
						contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
					}
					 									
					string multiTenantField = "GuidCompany";


                return GetSummaryOperation(con, new SDCaseHistoryFile(), function, filterString, usemode, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields, contextRequest, fields.Split(char.Parse(",")).ToArray());
            }
        }

   protected override void QueryBuild(string predicate, Filter filter, DbContext efContext, ContextRequest contextRequest, string method, List<string> includesList)
      	{
				if (contextRequest.CustomQuery.SpecificProperties.Count == 0)
                {
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistoryFile.PropertyNames.GuidFile);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistoryFile.PropertyNames.GuidCaseHistory);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistoryFile.PropertyNames.GuidCompany);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistoryFile.PropertyNames.CreatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistoryFile.PropertyNames.UpdatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistoryFile.PropertyNames.CreatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistoryFile.PropertyNames.UpdatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistoryFile.PropertyNames.Bytes);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistoryFile.PropertyNames.IsDeleted);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistoryFile.PropertyNames.SDCaseHistory);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseHistoryFile.PropertyNames.SDFile);
                    
				}

				if (method == "getby" || method == "sum")
				{
					if (!contextRequest.CustomQuery.SpecificProperties.Contains("GuidCasehistoryFile")){
						contextRequest.CustomQuery.SpecificProperties.Add("GuidCasehistoryFile");
					}

					 if (!string.IsNullOrEmpty(contextRequest.CustomQuery.OrderBy))
					{
						string existPropertyOrderBy = contextRequest.CustomQuery.OrderBy;
						if (contextRequest.CustomQuery.OrderBy.Contains("."))
						{
							existPropertyOrderBy = contextRequest.CustomQuery.OrderBy.Split(char.Parse("."))[0];
						}
						if (!contextRequest.CustomQuery.SpecificProperties.Exists(p => p == existPropertyOrderBy))
						{
							contextRequest.CustomQuery.SpecificProperties.Add(existPropertyOrderBy);
						}
					}

				}
				
	bool isFullDetails = contextRequest.IsFromUI("SDCaseHistoryFiles", UIActions.GetForDetails);
	string filterForTest = predicate  + filter.GetFilterComplete();

				if (isFullDetails || !string.IsNullOrEmpty(predicate))
            {
            } 

			if (method == "sum")
            {
            } 
			if (contextRequest.CustomQuery.SelectedFields.Count == 0)
            {
				foreach (var selected in contextRequest.CustomQuery.SpecificProperties)
                {
					string linq = selected;
					switch (selected)
                    {

					case "SDCaseHistory":
					if (includesList.Contains(selected)){
                        linq = "it.SDCaseHistory as SDCaseHistory";
					}
                    else
						linq = "iif(it.SDCaseHistory != null, new (it.SDCaseHistory.GuidCaseHistory, it.SDCaseHistory.BodyContent), null) as SDCaseHistory";
 					break;
					case "SDFile":
					if (includesList.Contains(selected)){
                        linq = "it.SDFile as SDFile";
					}
                    else
						linq = "iif(it.SDFile != null, new (it.SDFile.GuidFile, it.SDFile.FileName), null) as SDFile";
 					break;
					 
						
					 default:
                            break;
                    }
					contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name=selected, Linq=linq});
					if (method == "getby" || method == "sum")
					{
						if (includesList.Contains(selected))
							includesList.Remove(selected);

					}

				}
			}
				if (method == "getby" || method == "sum")
				{
					foreach (var otherInclude in includesList.Where(p=> !string.IsNullOrEmpty(p)))
					{
						contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name = otherInclude, Linq = "it." + otherInclude +" as " + otherInclude });
					}
				}
				BusinessRulesEventArgs<SDCaseHistoryFile> e = null;
				if (contextRequest.PreventInterceptors == false)
					OnQuerySettings(efContext, e = new BusinessRulesEventArgs<SDCaseHistoryFile>() { Filter = filter, ContextRequest = contextRequest /*, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null)*/ });

				//List<SDCaseHistoryFile> result = new List<SDCaseHistoryFile>();
                 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }

}
		public List<SDCaseHistoryFile> GetBy(Expression<Func<SDCaseHistoryFile, bool>> predicate, bool loadRelations, ContextRequest contextRequest)
        {
			if(!loadRelations)
				return GetBy(predicate, contextRequest);
			else
				return GetBy(predicate, contextRequest, "");

        }

        public List<SDCaseHistoryFile> GetBy(Expression<Func<SDCaseHistoryFile, bool>> predicate, int? pageSize, int? page, string orderBy, SFSdotNet.Framework.Data.SortDirection? sortDirection)
        {
            return GetBy(predicate, new ContextRequest() { CustomQuery = new CustomQuery() { Page = page, PageSize = pageSize, OrderBy = orderBy, SortDirection = sortDirection } });
        }
        public List<SDCaseHistoryFile> GetBy(Expression<Func<SDCaseHistoryFile, bool>> predicate)
        {

			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
			contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
			            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            contextRequest.CustomQuery.FilterExpressionString = null;
            return this.GetBy(predicate, contextRequest, "");
        }
        #endregion
        #region Dynamic String
		protected override string GetSpecificFilter(string filter, ContextRequest contextRequest) {
            string result = "";
		    //string linqFilter = String.Empty;
            string freeTextFilter = String.Empty;
            if (filter.Contains("|"))
            {
               // linqFilter = filter.Split(char.Parse("|"))[0];
                freeTextFilter = filter.Split(char.Parse("|"))[1];
            }
            //else {
            //    freeTextFilter = filter;
            //}
            //else {
            //    linqFilter = filter;
            //}
			// linqFilter = SFSdotNet.Framework.Linq.Utils.ReplaceCustomDateFilters(linqFilter);
            //string specificFilter = linqFilter;
            if (!string.IsNullOrEmpty(freeTextFilter))
            {
                System.Text.StringBuilder sbCont = new System.Text.StringBuilder();
                /*if (specificFilter.Length > 0)
                {
                    sbCont.Append(" AND ");
                    sbCont.Append(" ({0})");
                }
                else
                {
                    sbCont.Append("{0}");
                }*/
                //var words = freeTextFilter.Split(char.Parse(" "));
				var word = freeTextFilter;
                System.Text.StringBuilder sbSpec = new System.Text.StringBuilder();
                 int nWords = 1;
				/*foreach (var word in words)
                {
					if (word.Length > 0){
                    if (sbSpec.Length > 0) sbSpec.Append(" AND ");
					if (words.Length > 1) sbSpec.Append("("); */
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
								
					//if (sbSpec.Length > 2)
					//	sbSpec.Append(" OR "); // test
					sbSpec.Append(string.Format(@"it.SDCaseHistory.BodyContent.Contains(""{0}"")", word)+" OR "+string.Format(@"it.SDFile.FileName.Contains(""{0}"")", word));
								 //sbSpec.Append("*extraFreeText*");

                    /*if (words.Length > 1) sbSpec.Append(")");
					
					nWords++;

					}

                }*/
                //specificFilter = string.Format("{0}{1}", specificFilter, string.Format(sbCont.ToString(), sbSpec.ToString()));
                                 result = sbSpec.ToString();  
            }
			//result = specificFilter;
			
			return result;

		}
	
			public List<SDCaseHistoryFile> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params object[] extraParams)
        {
			return GetBy(filter, pageSize, page, orderBy, orderDir,  null, extraParams);
		}
           public List<SDCaseHistoryFile> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, string usemode, params object[] extraParams)
            { 
                return GetBy(filter, pageSize, page, orderBy, orderDir, usemode, null, extraParams);
            }


		public List<SDCaseHistoryFile> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  string usemode, ContextRequest context, params object[] extraParams)

        {

            // string freetext = null;
            //if (filter.Contains("|"))
            //{
            //    int parts = filter.Split(char.Parse("|")).Count();
            //    if (parts > 1)
            //    {

            //        freetext = filter.Split(char.Parse("|"))[1];
            //    }
            //}
		
            //string specificFilter = "";
            //if (!string.IsNullOrEmpty(filter))
            //  specificFilter=  GetSpecificFilter(filter);
            if (string.IsNullOrEmpty(orderBy))
            {
			                orderBy = "UpdatedDate";
            }
			//orderDir = "desc";
			SFSdotNet.Framework.Data.SortDirection direction = SFSdotNet.Framework.Data.SortDirection.Ascending;
            if (!string.IsNullOrEmpty(orderDir))
            {
                if (orderDir == "desc")
                    direction = SFSdotNet.Framework.Data.SortDirection.Descending;
            }
            if (context == null)
                context = new ContextRequest();
			

             context.UseMode = usemode;
             if (context.CustomQuery == null )
                context.CustomQuery =new SFSdotNet.Framework.My.CustomQuery();

 
                context.CustomQuery.ExtraParams = extraParams;

                    context.CustomQuery.OrderBy = orderBy;
                   context.CustomQuery.SortDirection = direction;
                   context.CustomQuery.Page = page;
                  context.CustomQuery.PageSize = pageSize;
               

            

            if (!preventSecurityRestrictions) {
			 if (context.CurrentContext == null)
                {
					if (SFSdotNet.Framework.My.Context.CurrentContext != null &&  SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
					{
						context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
						context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

					}
					else {
						throw new Exception("The security rule require a specific user and company");
					}
				}
            }
            return GetBy(filter, context);
  
        }


        public List<SDCaseHistoryFile> GetBy(string strWhere, ContextRequest contextRequest)
        {
        	#region old code
				
				 //Expression<Func<tvsReservationTransport, bool>> predicate = null;
				string strWhereClean = strWhere.Replace("*extraFreeText*", "").Replace("()", "");
                //if (!string.IsNullOrEmpty(strWhereClean)){

                //    object[] extraParams = null;
                //    //if (contextRequest != null )
                //    //    if (contextRequest.CustomQuery != null )
                //    //        extraParams = contextRequest.CustomQuery.ExtraParams;
                //    //predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<tvsReservationTransport, bool>(strWhereClean, extraParams != null? extraParams.Cast<Guid>(): null);				
                //}
				 if (contextRequest == null)
                {
                    contextRequest = new ContextRequest();
                    if (contextRequest.CustomQuery == null)
                        contextRequest.CustomQuery = new CustomQuery();
                }
                  if (!preventSecurityRestrictions) {
					if (contextRequest.User == null || contextRequest.Company == null)
                      {
                     if (SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
                     {
                         contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                         contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

                     }
                     else {
                         throw new Exception("The security rule require a specific User and Company ");
                     }
					 }
                 }
            contextRequest.CustomQuery.FilterExpressionString = strWhere;
				//return GetBy(predicate, contextRequest);  

			#endregion				
				
                    return GetBy(strWhere, contextRequest, "");  


        }
       public List<SDCaseHistoryFile> GetBy(string strWhere)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
			
            return GetBy(strWhere, context, null);
        }

        public List<SDCaseHistoryFile> GetBy(string strWhere, string includes)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
            return GetBy(strWhere, context, includes);
        }

        #endregion
        #endregion
		
		  #region SaveOrUpdate
        
 		 public SDCaseHistoryFile Create(SDCaseHistoryFile entity)
        {
				//ObjectContext context = null;
				    if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: Create");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

				return this.Create(entity, contextRequest);


        }
        
       
        public SDCaseHistoryFile Create(SDCaseHistoryFile entity, ContextRequest contextRequest)
        {
		
		bool graph = false;
	
				bool preventPartial = false;
                if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
               
			using (EFContext con = new EFContext()) {

				SDCaseHistoryFile itemForSave = new SDCaseHistoryFile();
#region Autos
		if(!preventSecurityRestrictions){

				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion
               BusinessRulesEventArgs<SDCaseHistoryFile> e = null;
			    if (preventPartial == false )
                OnCreating(this,e = new BusinessRulesEventArgs<SDCaseHistoryFile>() { ContextRequest = contextRequest, Item=entity });
				   if (e != null) {
						if (e.Cancel)
						{
							context = null;
							return e.Item;

						}
					}

                    if (entity.GuidCasehistoryFile == Guid.Empty)
                   {
                       entity.GuidCasehistoryFile = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   itemForSave.GuidCasehistoryFile = entity.GuidCasehistoryFile;
				  
		
			itemForSave.GuidCasehistoryFile = entity.GuidCasehistoryFile;

			itemForSave.GuidCompany = entity.GuidCompany;

			itemForSave.CreatedDate = entity.CreatedDate;

			itemForSave.UpdatedDate = entity.UpdatedDate;

			itemForSave.CreatedBy = entity.CreatedBy;

			itemForSave.UpdatedBy = entity.UpdatedBy;

			itemForSave.Bytes = entity.Bytes;

			itemForSave.IsDeleted = entity.IsDeleted;

				
				con.SDCaseHistoryFiles.Add(itemForSave);



					if (entity.SDCaseHistory != null)
					{
						var sDCaseHistory = new SDCaseHistory();
						sDCaseHistory.GuidCaseHistory = entity.SDCaseHistory.GuidCaseHistory;
						itemForSave.SDCaseHistory = sDCaseHistory;
						SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCaseHistory>(con, itemForSave.SDCaseHistory);
			
					}




					if (entity.SDFile != null)
					{
						var sDFile = new SDFile();
						sDFile.GuidFile = entity.SDFile.GuidFile;
						itemForSave.SDFile = sDFile;
						SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDFile>(con, itemForSave.SDFile);
			
					}



                
				con.ChangeTracker.Entries().Where(p => p.Entity != itemForSave && p.State != EntityState.Unchanged).ForEach(p => p.State = EntityState.Detached);

				con.Entry<SDCaseHistoryFile>(itemForSave).State = EntityState.Added;

				con.SaveChanges();

					 
				

				//itemResult = entity;
                //if (e != null)
                //{
                 //   e.Item = itemResult;
                //}
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false )
                OnCreated(this, e == null ? e = new BusinessRulesEventArgs<SDCaseHistoryFile>() { ContextRequest = contextRequest, Item = entity } : e);



                if (e != null && e.Item != null )
                {
                    return e.Item;
                }
                              return entity;
			}
            
        }
        //BusinessRulesEventArgs<SDCaseHistoryFile> e = null;
        public void Create(List<SDCaseHistoryFile> entities)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            Create(entities, contextRequest);
        }
        public void Create(List<SDCaseHistoryFile> entities, ContextRequest contextRequest)
        
        {
			ObjectContext context = null;
            	foreach (SDCaseHistoryFile entity in entities)
				{
					this.Create(entity, contextRequest);
				}
        }
		  public void CreateOrUpdateBulk(List<SDCaseHistoryFile> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "cu", contextRequest);
        }

        private void CreateOrUpdateBulk(List<SDCaseHistoryFile> entities, string actionKey, ContextRequest contextRequest)
        {
			if (entities.Count() > 0){
            bool graph = false;

            bool preventPartial = false;
            if (contextRequest != null && contextRequest.PreventInterceptors == true)
            {
                preventPartial = true;
            }
            foreach (var entity in entities)
            {
                    if (entity.GuidCasehistoryFile == Guid.Empty)
                   {
                       entity.GuidCasehistoryFile = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   
				  


#region Autos
		if(!preventSecurityRestrictions){


 if (actionKey != "u")
                        {
				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;


}
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion


		
			//entity.GuidCasehistoryFile = entity.GuidCasehistoryFile;

			//entity.GuidCompany = entity.GuidCompany;

			//entity.CreatedDate = entity.CreatedDate;

			//entity.UpdatedDate = entity.UpdatedDate;

			//entity.CreatedBy = entity.CreatedBy;

			//entity.UpdatedBy = entity.UpdatedBy;

			//entity.Bytes = entity.Bytes;

			//entity.IsDeleted = entity.IsDeleted;

				
				



				    if (entity.SDCaseHistory != null)
					{
						//var sDCaseHistory = new SDCaseHistory();
						entity.GuidCaseHistory = entity.SDCaseHistory.GuidCaseHistory;
						//entity.SDCaseHistory = sDCaseHistory;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCaseHistory>(con, itemForSave.SDCaseHistory);
			
					}




				    if (entity.SDFile != null)
					{
						//var sDFile = new SDFile();
						entity.GuidFile = entity.SDFile.GuidFile;
						//entity.SDFile = sDFile;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDFile>(con, itemForSave.SDFile);
			
					}



                
				

					 
				

				//itemResult = entity;
            }
            using (EFContext con = new EFContext())
            {
                 if (actionKey == "c")
                    {
                        context.BulkInsert(entities);
                    }else if ( actionKey == "u")
                    {
                        context.BulkUpdate(entities);
                    }else
                    {
                        context.BulkInsertOrUpdate(entities);
                    }
            }

			}
        }
	
		public void CreateBulk(List<SDCaseHistoryFile> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "c", contextRequest);
        }


		public void UpdateAgile(SDCaseHistoryFile item, params string[] fields)
         {
			UpdateAgile(item, null, fields);
        }
		public void UpdateAgile(SDCaseHistoryFile item, ContextRequest contextRequest, params string[] fields)
         {
            
             ContextRequest contextNew = null;
             if (contextRequest != null)
             {
                 contextNew = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
                 if (fields != null && fields.Length > 0)
                 {
                     contextNew.CustomQuery.SpecificProperties  = fields.ToList();
                 }
                 else if(contextRequest.CustomQuery.SpecificProperties.Count > 0)
                 {
                     fields = contextRequest.CustomQuery.SpecificProperties.ToArray();
                 }
             }
			

		   using (EFContext con = new EFContext())
            {



               
					List<string> propForCopy = new List<string>();
                    propForCopy.AddRange(fields);
                    
					  
					if (!propForCopy.Contains("GuidCasehistoryFile"))
						propForCopy.Add("GuidCasehistoryFile");

					var itemForUpdate = SFSdotNet.Framework.BR.Utils.GetConverted<SDCaseHistoryFile,SDCaseHistoryFile>(item, propForCopy.ToArray());
					 itemForUpdate.GuidCasehistoryFile = item.GuidCasehistoryFile;
                  var setT = con.Set<SDCaseHistoryFile>().Attach(itemForUpdate);

					if (fields.Count() > 0)
					  {
						  item.ModifiedProperties = fields;
					  }
                    foreach (var property in item.ModifiedProperties)
					{						
                        if (property != "GuidCasehistoryFile")
                             con.Entry(setT).Property(property).IsModified = true;

                    }

                
               int result = con.SaveChanges();
               if (result != 1)
               {
                   SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: 1");
               }


            }

			OnUpdatedAgile(this, new BusinessRulesEventArgs<SDCaseHistoryFile>() { Item = item, ContextRequest = contextNew  });

         }
		public void UpdateBulk(List<SDCaseHistoryFile>  items, params string[] fields)
         {
             SFSdotNet.Framework.My.ContextRequest req = new SFSdotNet.Framework.My.ContextRequest();
             req.CustomQuery = new SFSdotNet.Framework.My.CustomQuery();
             foreach (var field in fields)
             {
                 req.CustomQuery.SpecificProperties.Add(field);
             }
             UpdateBulk(items, req);

         }

		 public void DeleteBulk(List<SDCaseHistoryFile> entities, ContextRequest contextRequest = null)
        {

            using (EFContext con = new EFContext())
            {
                foreach (var entity in entities)
                {
					var entityProxy = new SDCaseHistoryFile() { GuidCasehistoryFile = entity.GuidCasehistoryFile };

                    con.Entry<SDCaseHistoryFile>(entityProxy).State = EntityState.Deleted;

                }

                int result = con.SaveChanges();
                if (result != entities.Count)
                {
                    SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: " + entities.Count.ToString());
                }
            }

        }

        public void UpdateBulk(List<SDCaseHistoryFile> items, ContextRequest contextRequest)
        {
            if (items.Count() > 0){

			 foreach (var entity in items)
            {


#region Autos
		if(!preventSecurityRestrictions){

				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	



			}
#endregion




				    if (entity.SDCaseHistory != null)
					{
						//var sDCaseHistory = new SDCaseHistory();
						entity.GuidCaseHistory = entity.SDCaseHistory.GuidCaseHistory;
						//entity.SDCaseHistory = sDCaseHistory;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDCaseHistory>(con, itemForSave.SDCaseHistory);
			
					}




				    if (entity.SDFile != null)
					{
						//var sDFile = new SDFile();
						entity.GuidFile = entity.SDFile.GuidFile;
						//entity.SDFile = sDFile;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDFile>(con, itemForSave.SDFile);
			
					}



				}
				using (EFContext con = new EFContext())
				{

                    
                
                   con.BulkUpdate(items);

				}
             
			}	  
        }

         public SDCaseHistoryFile Update(SDCaseHistoryFile entity)
        {
            if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return Update(entity, contextRequest);
        }
       
         public SDCaseHistoryFile Update(SDCaseHistoryFile entity, ContextRequest contextRequest)
        {
		 if ((System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null) && contextRequest == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Update");
            }
            if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            }

			
				SDCaseHistoryFile  itemResult = null;

	
			//entity.UpdatedDate = DateTime.Now.ToUniversalTime();
			//if(contextRequest.User != null)
				//entity.UpdatedBy = contextRequest.User.GuidUser;

//	    var oldentity = GetBy(p => p.GuidCasehistoryFile == entity.GuidCasehistoryFile, contextRequest).FirstOrDefault();
	//	if (oldentity != null) {
		
          //  entity.CreatedDate = oldentity.CreatedDate;
    //        entity.CreatedBy = oldentity.CreatedBy;
	
      //      entity.GuidCompany = oldentity.GuidCompany;
	
			

	
		//}

			 using( EFContext con = new EFContext()){
				BusinessRulesEventArgs<SDCaseHistoryFile> e = null;
				bool preventPartial = false; 
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false)
                OnUpdating(this,e = new BusinessRulesEventArgs<SDCaseHistoryFile>() { ContextRequest = contextRequest, Item=entity});
				   if (e != null) {
						if (e.Cancel)
						{
							//outcontext = null;
							return e.Item;

						}
					}

	string includes = "SDCaseHistory,SDFile";
	IQueryable < SDCaseHistoryFile > query = con.SDCaseHistoryFiles.AsQueryable();
	foreach (string include in includes.Split(char.Parse(",")))
                       {
                           if (!string.IsNullOrEmpty(include))
                               query = query.Include(include);
                       }
	var oldentity = query.FirstOrDefault(p => p.GuidCasehistoryFile == entity.GuidCasehistoryFile);

				//if (entity.UpdatedDate == null || (contextRequest != null && contextRequest.IsFromUI("SDCaseHistoryFiles", UIActions.Updating)))
			oldentity.UpdatedDate = DateTime.Now.ToUniversalTime();
			if(contextRequest.User != null)
				oldentity.UpdatedBy = contextRequest.User.GuidUser;

           


						if (SFSdotNet.Framework.BR.Utils.HasRelationPropertyChanged(oldentity.SDCaseHistory, entity.SDCaseHistory, "GuidCaseHistory"))
							oldentity.SDCaseHistory = entity.SDCaseHistory != null? new SDCaseHistory(){ GuidCaseHistory = entity.SDCaseHistory.GuidCaseHistory } :null;

                


						if (SFSdotNet.Framework.BR.Utils.HasRelationPropertyChanged(oldentity.SDFile, entity.SDFile, "GuidFile"))
							oldentity.SDFile = entity.SDFile != null? new SDFile(){ GuidFile = entity.SDFile.GuidFile } :null;

                


				con.ChangeTracker.Entries().Where(p => p.Entity != oldentity).ForEach(p => p.State = EntityState.Unchanged);  
				  
				con.SaveChanges();
        
					 
					
               
				itemResult = entity;
				if(preventPartial == false)
					OnUpdated(this, e = new BusinessRulesEventArgs<SDCaseHistoryFile>() { ContextRequest = contextRequest, Item=itemResult });

              	return itemResult;
			}
			  
        }
        public SDCaseHistoryFile Save(SDCaseHistoryFile entity)
        {
			return Create(entity);
        }
        public int Save(List<SDCaseHistoryFile> entities)
        {
			 Create(entities);
            return entities.Count;

        }
        #endregion
        #region Delete
        public void Delete(SDCaseHistoryFile entity)
        {
				this.Delete(entity, null);
			
        }
		 public void Delete(SDCaseHistoryFile entity, ContextRequest contextRequest)
        {
				
				  List<SDCaseHistoryFile> entities = new List<SDCaseHistoryFile>();
				   entities.Add(entity);
				this.Delete(entities, contextRequest);
			
        }

         public void Delete(string query, Guid[] guids, ContextRequest contextRequest)
        {
			var br = new SDCaseHistoryFilesBR(true);
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);
            
            Delete(items, contextRequest);

        }
        public void Delete(SDCaseHistoryFile entity,  ContextRequest contextRequest, BusinessRulesEventArgs<SDCaseHistoryFile> e = null)
        {
			
				using(EFContext con = new EFContext())
                 {
				
               	BusinessRulesEventArgs<SDCaseHistoryFile> _e = null;
               List<SDCaseHistoryFile> _items = new List<SDCaseHistoryFile>();
                _items.Add(entity);
                if (e == null || e.PreventPartialPropagate == false)
                {
                    OnDeleting(this, _e = (e == null ? new BusinessRulesEventArgs<SDCaseHistoryFile>() { ContextRequest = contextRequest, Item = entity, Items = null  } : e));
                }
                if (_e != null)
                {
                    if (_e.Cancel)
						{
							context = null;
							return;

						}
					}


				
									//IsDeleted
					bool logicDelete = true;
					if (entity.IsDeleted != null)
					{
						if (entity.IsDeleted.Value)
							logicDelete = false;
					}
					if (logicDelete)
					{
											//entity = GetBy(p =>, contextRequest).FirstOrDefault();
						entity.IsDeleted = true;
						if (contextRequest != null && contextRequest.User != null)
							entity.UpdatedBy = contextRequest.User.GuidUser;
                        entity.UpdatedDate = DateTime.UtcNow;
						UpdateAgile(entity, "IsDeleted","UpdatedBy","UpdatedDate");

						
					}
					else {
					con.Entry<SDCaseHistoryFile>(entity).State = EntityState.Deleted;
					con.SaveChanges();
				
				 
					}
								
				
				 
					
					
			if (e == null || e.PreventPartialPropagate == false)
                {

                    if (_e == null)
                        _e = new BusinessRulesEventArgs<SDCaseHistoryFile>() { ContextRequest = contextRequest, Item = entity, Items = null };

                    OnDeleted(this, _e);
                }

				//return null;
			}
        }
 public void UnDelete(string query, Guid[] guids, ContextRequest contextRequest)
        {
            var br = new SDCaseHistoryFilesBR(true);
            contextRequest.CustomQuery.IncludeDeleted = true;
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);

            foreach (var item in items)
            {
                item.IsDeleted = false;
						if (contextRequest != null && contextRequest.User != null)
							item.UpdatedBy = contextRequest.User.GuidUser;
                        item.UpdatedDate = DateTime.UtcNow;
            }

            UpdateBulk(items, "IsDeleted","UpdatedBy","UpdatedDate");
        }

         public void Delete(List<SDCaseHistoryFile> entities,  ContextRequest contextRequest = null )
        {
				
			 BusinessRulesEventArgs<SDCaseHistoryFile> _e = null;

                OnDeleting(this, _e = new BusinessRulesEventArgs<SDCaseHistoryFile>() { ContextRequest = contextRequest, Item = null, Items = entities });
                if (_e != null)
                {
                    if (_e.Cancel)
                    {
                        context = null;
                        return;

                    }
                }
                bool allSucced = true;
                BusinessRulesEventArgs<SDCaseHistoryFile> eToChilds = new BusinessRulesEventArgs<SDCaseHistoryFile>();
                if (_e != null)
                {
                    eToChilds = _e;
                }
                else
                {
                    eToChilds = new BusinessRulesEventArgs<SDCaseHistoryFile>() { ContextRequest = contextRequest, Item = (entities.Count == 1 ? entities[0] : null), Items = entities };
                }
				foreach (SDCaseHistoryFile item in entities)
				{
					try
                    {
                        this.Delete(item, contextRequest, e: eToChilds);
                    }
                    catch (Exception ex)
                    {
                        SFSdotNet.Framework.My.EventLog.Error(ex);
                        allSucced = false;
                    }
				}
				if (_e == null)
                    _e = new BusinessRulesEventArgs<SDCaseHistoryFile>() { ContextRequest = contextRequest, CountResult = entities.Count, Item = null, Items = entities };
                OnDeleted(this, _e);

			
        }
        #endregion
 
        #region GetCount
		 public int GetCount(Expression<Func<SDCaseHistoryFile, bool>> predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

			return GetCount(predicate, contextRequest);
		}
        public int GetCount(Expression<Func<SDCaseHistoryFile, bool>> predicate, ContextRequest contextRequest)
        {


		
		 using (EFContext con = new EFContext())
            {


				if (predicate == null) predicate = PredicateBuilder.True<SDCaseHistoryFile>();
           		predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted == null);
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    		if (contextRequest.User !=null )
                        		if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
									predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa

								}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				
				IQueryable<SDCaseHistoryFile> query = con.SDCaseHistoryFiles.AsQueryable();
                return query.AsExpandable().Count(predicate);

			
				}
			

        }
		  public int GetCount(string predicate,  ContextRequest contextRequest)
         {
             return GetCount(predicate, null, contextRequest);
         }

         public int GetCount(string predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return GetCount(predicate, contextRequest);
        }
		 public int GetCount(string predicate, string usemode){
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
				return GetCount( predicate,  usemode,  contextRequest);
		 }
        public int GetCount(string predicate, string usemode, ContextRequest contextRequest){

		using (EFContext con = new EFContext()) {
				string computedFields = "";
				string fkIncludes = "SDCaseHistory,SDFile";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDCaseHistoryFile>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetCount(con, predicate, usemode, contextRequest, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields);

			}
			#region old code
			 /* string freetext = null;
            Filter filter = new Filter();

              if (predicate.Contains("|"))
              {
                 
                  filter.SetFilterPart("ft", GetSpecificFilter(predicate, contextRequest));
                 
                  filter.ProcessText(predicate.Split(char.Parse("|"))[0]);
                  freetext = predicate.Split(char.Parse("|"))[1];

				  if (!string.IsNullOrEmpty(freetext) && string.IsNullOrEmpty(contextRequest.FreeText))
                  {
                      contextRequest.FreeText = freetext;
                  }
              }
              else {
                  filter.ProcessText(predicate);
              }
			   predicate = filter.GetFilterComplete();
			// BusinessRulesEventArgs<SDCaseHistoryFile>  e = null;
           	using (EFContext con = new EFContext())
			{
			
			

			 QueryBuild(predicate, filter, con, contextRequest, "count", new List<string>());


			
			BusinessRulesEventArgs<SDCaseHistoryFile> e = null;

			contextRequest.FreeText = freetext;
			contextRequest.UseMode = usemode;
            OnCounting(this, e = new BusinessRulesEventArgs<SDCaseHistoryFile>() {  Filter =filter, ContextRequest = contextRequest });
            if (e != null)
            {
                if (e.Cancel)
                {
                    context = null;
                    return e.CountResult;

                }

            

            }
			
			StringBuilder sbQuerySystem = new StringBuilder();
		
					
                    filter.SetFilterPart("de","(IsDeleted != true OR IsDeleted == null)");
			
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    	if (contextRequest.User !=null )
                        	if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
                        		
								filter.SetFilterPart("co", @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa
						
						
							}
							
							}
							if (preventSecurityRestrictions) preventSecurityRestrictions= false;
		
				   
                 filter.CleanAndProcess("");
				//string predicateWithFKAndComputed = SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicate );               
				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed();
               string predicateWithManyRelations = filter.GetFilterChildren();
			   ///QueryUtils.BreakeQuery1(predicate, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
			   predicate = filter.GetFilterComplete();
               if (!string.IsNullOrEmpty(predicate))
               {
				
					
                    return con.SDCaseHistoryFiles.Where(predicate).Count();
					
                }else
                    return con.SDCaseHistoryFiles.Count();
					
			}*/
			#endregion

		}
         public int GetCount()
        {
            return GetCount(p => true);
        }
        #endregion
        
         


        public void Delete(List<SDCaseHistoryFile.CompositeKey> entityKeys)
        {

            List<SDCaseHistoryFile> items = new List<SDCaseHistoryFile>();
            foreach (var itemKey in entityKeys)
            {
                items.Add(GetByKey(itemKey.GuidCasehistoryFile));
            }

            Delete(items);

        }
		 public void UpdateAssociation(string relation, string relationValue, string query, Guid[] ids, ContextRequest contextRequest)
        {
            var items = GetBy(query, null, null, null, null, null, contextRequest, ids);
			 var module = SFSdotNet.Framework.Cache.Caching.SystemObjects.GetModuleByKey(SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(System.Web.HttpContext.Current.Request.RequestContext, "area"));
           
            foreach (var item in items)
            {
			  Guid ? guidRelationValue = null ;
                if (!string.IsNullOrEmpty(relationValue)){
                    guidRelationValue = Guid.Parse(relationValue );
                }

				 if (relation.Contains("."))
                {
                    var partsWithOtherProp = relation.Split(char.Parse("|"));
                    var parts = partsWithOtherProp[0].Split(char.Parse("."));

                    string proxyRelName = parts[0];
                    string proxyProperty = parts[1];
                    string proxyPropertyKeyNameFromOther = partsWithOtherProp[1];
                    //string proxyPropertyThis = parts[2];

                    var prop = item.GetType().GetProperty(proxyRelName);
                    //var entityInfo = //SFSdotNet.Framework.
                    // descubrir el tipo de entidad dentro de la colección
                    Type typeEntityInList = SFSdotNet.Framework.Entities.Utils.GetTypeFromList(prop);
                    var newProxyItem = Activator.CreateInstance(typeEntityInList);
                    var propThisForSet = newProxyItem.GetType().GetProperty(proxyProperty);
                    var entityInfoOfProxy = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(typeEntityInList);
                    var propOther = newProxyItem.GetType().GetProperty(proxyPropertyKeyNameFromOther);

                    if (propThisForSet != null && entityInfoOfProxy != null && propOther != null )
                    {
                        var entityInfoThis = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(item.GetType());
                        var valueThisId = item.GetType().GetProperty(entityInfoThis.PropertyKeyName).GetValue(item);
                        if (valueThisId != null)
                            propThisForSet.SetValue(newProxyItem, valueThisId);
                        propOther.SetValue(newProxyItem, Guid.Parse(relationValue));
                        
                        var entityNameProp = newProxyItem.GetType().GetField("EntityName").GetValue(null);
                        var entitySetNameProp = newProxyItem.GetType().GetField("EntitySetName").GetValue(null);

                        SFSdotNet.Framework.Apps.Integration.CreateItemFromApp(entityNameProp.ToString(), entitySetNameProp.ToString(), module.ModuleNamespace, newProxyItem, contextRequest);

                    }

                    // crear una instancia del tipo de entidad
                    // llenar los datos y registrar nuevo


                }
                else
                {
                var prop = item.GetType().GetProperty(relation);
                var entityInfo = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(prop.PropertyType);
                if (entityInfo != null)
                {
                    var ins = Activator.CreateInstance(prop.PropertyType);
                   if (guidRelationValue != null)
                    {
                        prop.PropertyType.GetProperty(entityInfo.PropertyKeyName).SetValue(ins, guidRelationValue);
                        item.GetType().GetProperty(relation).SetValue(item, ins);
                    }
                    else
                    {
                        item.GetType().GetProperty(relation).SetValue(item, null);
                    }

                    Update(item, contextRequest);
                }

				}
            }
        }
		
	}
		public partial class SDCasePrioritiesBR:BRBase<SDCasePriority>{
	 	
           
		 #region Partial methods

           partial void OnUpdating(object sender, BusinessRulesEventArgs<SDCasePriority> e);

            partial void OnUpdated(object sender, BusinessRulesEventArgs<SDCasePriority> e);
			partial void OnUpdatedAgile(object sender, BusinessRulesEventArgs<SDCasePriority> e);

            partial void OnCreating(object sender, BusinessRulesEventArgs<SDCasePriority> e);
            partial void OnCreated(object sender, BusinessRulesEventArgs<SDCasePriority> e);

            partial void OnDeleting(object sender, BusinessRulesEventArgs<SDCasePriority> e);
            partial void OnDeleted(object sender, BusinessRulesEventArgs<SDCasePriority> e);

            partial void OnGetting(object sender, BusinessRulesEventArgs<SDCasePriority> e);
            protected override void OnVirtualGetting(object sender, BusinessRulesEventArgs<SDCasePriority> e)
            {
                OnGetting(sender, e);
            }
			protected override void OnVirtualCounting(object sender, BusinessRulesEventArgs<SDCasePriority> e)
            {
                OnCounting(sender, e);
            }
			partial void OnTaken(object sender, BusinessRulesEventArgs<SDCasePriority> e);
			protected override void OnVirtualTaken(object sender, BusinessRulesEventArgs<SDCasePriority> e)
            {
                OnTaken(sender, e);
            }

            partial void OnCounting(object sender, BusinessRulesEventArgs<SDCasePriority> e);
 
			partial void OnQuerySettings(object sender, BusinessRulesEventArgs<SDCasePriority> e);
          
            #endregion
			
		private static SDCasePrioritiesBR singlenton =null;
				public static SDCasePrioritiesBR NewInstance(){
					return  new SDCasePrioritiesBR();
					
				}
		public static SDCasePrioritiesBR Instance{
			get{
				if (singlenton == null)
					singlenton = new SDCasePrioritiesBR();
				return singlenton;
			}
		}
		//private bool preventSecurityRestrictions = false;
		 public bool PreventAuditTrail { get; set;  }
		#region Fields
        EFContext context = null;
        #endregion
        #region Constructor
        public SDCasePrioritiesBR()
        {
            context = new EFContext();
        }
		 public SDCasePrioritiesBR(bool preventSecurity)
            {
                this.preventSecurityRestrictions = preventSecurity;
				context = new EFContext();
            }
        #endregion
		
		#region Get

 		public IQueryable<SDCasePriority> Get()
        {
            using (EFContext con = new EFContext())
            {
				
				var query = con.SDCasePriorities.AsQueryable();
                con.Configuration.ProxyCreationEnabled = false;

                //query = ContextQueryBuilder<Nutrient>.ApplyContextQuery(query, contextRequest);

                return query;




            }

        }
		


 	
		public List<SDCasePriority> GetAll()
        {
            return this.GetBy(p => true);
        }
        public List<SDCasePriority> GetAll(string includes)
        {
            return this.GetBy(p => true, includes);
        }
        public SDCasePriority GetByKey(Guid guidCasePriority)
        {
            return GetByKey(guidCasePriority, true);
        }
        public SDCasePriority GetByKey(Guid guidCasePriority, bool loadIncludes)
        {
            SDCasePriority item = null;
			var query = PredicateBuilder.True<SDCasePriority>();
                    
			string strWhere = @"GuidCasePriority = Guid(""" + guidCasePriority.ToString()+@""")";
            Expression<Func<SDCasePriority, bool>> predicate = null;
            //if (!string.IsNullOrEmpty(strWhere))
            //    predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDCasePriority, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
			 ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
            contextRequest.CustomQuery.FilterExpressionString = strWhere;

			//item = GetBy(predicate, loadIncludes, contextRequest).FirstOrDefault();
			item = GetBy(strWhere,loadIncludes,contextRequest).FirstOrDefault();
            return item;
        }
         public List<SDCasePriority> GetBy(string strWhere, bool loadRelations, ContextRequest contextRequest)
        {
            if (!loadRelations)
                return GetBy(strWhere, contextRequest);
            else
                return GetBy(strWhere, contextRequest, "");

        }
		  public List<SDCasePriority> GetBy(string strWhere, bool loadRelations)
        {
              if (!loadRelations)
                return GetBy(strWhere, new ContextRequest());
            else
                return GetBy(strWhere, new ContextRequest(), "");

        }
		         public SDCasePriority GetByKey(Guid guidCasePriority, params Expression<Func<SDCasePriority, object>>[] includes)
        {
            SDCasePriority item = null;
			string strWhere = @"GuidCasePriority = Guid(""" + guidCasePriority.ToString()+@""")";
          Expression<Func<SDCasePriority, bool>> predicate = p=> p.GuidCasePriority == guidCasePriority;
           // if (!string.IsNullOrEmpty(strWhere))
           //     predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDCasePriority, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
        item = GetBy(predicate, includes).FirstOrDefault();
         ////   item = GetBy(strWhere,includes).FirstOrDefault();
			return item;

        }
        public SDCasePriority GetByKey(Guid guidCasePriority, string includes)
        {
            SDCasePriority item = null;
			string strWhere = @"GuidCasePriority = Guid(""" + guidCasePriority.ToString()+@""")";
            
			
            item = GetBy(strWhere, includes).FirstOrDefault();
            return item;

        }
		 public SDCasePriority GetByKey(Guid guidCasePriority, string usemode, string includes)
		{
			return GetByKey(guidCasePriority, usemode, null, includes);

		 }
		 public SDCasePriority GetByKey(Guid guidCasePriority, string usemode, ContextRequest context,  string includes)
        {
            SDCasePriority item = null;
			string strWhere = @"GuidCasePriority = Guid(""" + guidCasePriority.ToString()+@""")";
			if (context == null){
				context = new ContextRequest();
				context.CustomQuery = new CustomQuery();
				context.CustomQuery.IsByKey = true;
				context.CustomQuery.FilterExpressionString = strWhere;
				context.UseMode = usemode;
			}
            item = GetBy(strWhere,context , includes).FirstOrDefault();
            return item;

        }

        #region Dynamic Predicate
        public List<SDCasePriority> GetBy(Expression<Func<SDCasePriority, bool>> predicate, int? pageSize, int? page)
        {
            return this.GetBy(predicate, pageSize, page, null, null);
        }
        public List<SDCasePriority> GetBy(Expression<Func<SDCasePriority, bool>> predicate, ContextRequest contextRequest)
        {

            return GetBy(predicate, contextRequest,"");
        }
        
        public List<SDCasePriority> GetBy(Expression<Func<SDCasePriority, bool>> predicate, ContextRequest contextRequest, params Expression<Func<SDCasePriority, object>>[] includes)
        {
            StringBuilder sb = new StringBuilder();
           if (includes != null)
            {
                foreach (var path in includes)
                {

						if (sb.Length > 0) sb.Append(",");
						sb.Append(SFSdotNet.Framework.Linq.Utils.IncludeToString<SDCasePriority>(path));

               }
            }
            return GetBy(predicate, contextRequest, sb.ToString());
        }
        
        
        public List<SDCasePriority> GetBy(Expression<Func<SDCasePriority, bool>> predicate, string includes)
        {
			ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";

            return GetBy(predicate, context, includes);
        }

        public List<SDCasePriority> GetBy(Expression<Func<SDCasePriority, bool>> predicate, params Expression<Func<SDCasePriority, object>>[] includes)
        {
			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest context = new ContextRequest();
			            context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";
            return GetBy(predicate, context, includes);
        }

      
		public bool DisableCache { get; set; }
		public List<SDCasePriority> GetBy(Expression<Func<SDCasePriority, bool>> predicate, ContextRequest contextRequest, string includes)
		{
            using (EFContext con = new EFContext()) {
				
				string fkIncludes = "";
                List<string> multilangProperties = new List<string>();
				if (predicate == null) predicate = PredicateBuilder.True<SDCasePriority>();
                var notDeletedExpression = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;
					Expression<Func<SDCasePriority,bool>> multitenantExpression  = null;
					if (contextRequest != null && contextRequest.Company != null)	                        	
						multitenantExpression = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicate, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression);

#region Old code
/*
				List<SDCasePriority> result = null;
               BusinessRulesEventArgs<SDCasePriority>  e = null;
	
				OnGetting(con, e = new BusinessRulesEventArgs<SDCasePriority>() {  FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null) });

               // OnGetting(con,e = new BusinessRulesEventArgs<SDCasePriority>() { FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = contextRequest.CustomQuery.FilterExpressionString});
				   if (e != null) {
				    predicate = e.FilterExpression;
						if (e.Cancel)
						{
							context = null;
							 if (e.Items == null) e.Items = new List<SDCasePriority>();
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                if (predicate == null) predicate = PredicateBuilder.True<SDCasePriority>();
                
                //var es = _repository.Queryable;

                IQueryable<SDCasePriority> query =  con.SDCasePriorities.AsQueryable();

                                if (!string.IsNullOrEmpty(includes))
                {
                    foreach (string include in includes.Split(char.Parse(",")))
                    {
						if (!string.IsNullOrEmpty(include))
                            query = query.Include(include);
                    }
                }
                    predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
					 	if (!preventSecurityRestrictions)
						{
							if (contextRequest != null )
		                    	if (contextRequest.User !=null )
		                        	if (contextRequest.Company != null){
		                        	
										predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
 									
									}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				query =query.AsExpandable().Where(predicate);
                query = ContextQueryBuilder<SDCasePriority>.ApplyContextQuery(query, contextRequest);

                result = query.AsNoTracking().ToList<SDCasePriority>();
				  
                if (e != null)
                {
                    e.Items = result;
                }
				//if (contextRequest != null ){
				//	 contextRequest = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
					contextRequest.CustomQuery = new CustomQuery();

				//}
				OnTaken(this, e == null ? e =  new BusinessRulesEventArgs<SDCasePriority>() { Items= result, IncludingComputedLinq = false, ContextRequest = contextRequest,  FilterExpression = predicate } :  e);
  
			

                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
				*/
#endregion
            }
        }


		/*public int Update(List<SDCasePriority> items, ContextRequest contextRequest)
            {
                int result = 0;
                using (EFContext con = new EFContext())
                {
                   
                

                    foreach (var item in items)
                    {
                        //secMessageToUser messageToUser = new secMessageToUser();
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            item.GetType().GetProperty(prop).SetValue(item, item.GetType().GetProperty(prop).GetValue(item));
                        }
                        //messageToUser.GuidMessageToUser = (Guid)item.GetType().GetProperty("GuidMessageToUser").GetValue(item);

                        var setObject = con.CreateObjectSet<SDCasePriority>("SDCasePriorities");
                        //messageToUser.Readed = DateTime.UtcNow;
                        setObject.Attach(item);
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            con.ObjectStateManager.GetObjectStateEntry(item).SetModifiedProperty(prop);
                        }
                       
                    }
                    result = con.SaveChanges();

                    


                }
                return result;
            }
           */
		

        public List<SDCasePriority> GetBy(string predicateString, ContextRequest contextRequest, string includes)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
				


				string computedFields = "";
				string fkIncludes = "";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDCasePriority>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					//if (contextRequest != null && contextRequest.Company != null)                      	
					//	 multitenantExpression = @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))";
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicateString, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression,computedFields);


	#region Old Code
	/*
				BusinessRulesEventArgs<SDCasePriority> e = null;

				Filter filter = new Filter();
                if (predicateString.Contains("|"))
                {
                    string ft = GetSpecificFilter(predicateString, contextRequest);
                    if (!string.IsNullOrEmpty(ft))
                        filter.SetFilterPart("ft", ft);
                   
                    contextRequest.FreeText = predicateString.Split(char.Parse("|"))[1];
                    var q1 = predicateString.Split(char.Parse("|"))[0];
                    if (!string.IsNullOrEmpty(q1))
                    {
                        filter.ProcessText(q1);
                    }
                }
                else {
                    filter.ProcessText(predicateString);
                }
				 var includesList = (new List<string>());
                 if (!string.IsNullOrEmpty(includes))
                 {
                     includesList = includes.Split(char.Parse(",")).ToList();
                 }

				List<SDCasePriority> result = new List<SDCasePriority>();
         
			QueryBuild(predicateString, filter, con, contextRequest, "getby", includesList);
			 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }
				
				
					OnGetting(con, e == null ? e = new BusinessRulesEventArgs<SDCasePriority>() { Filter = filter, ContextRequest = contextRequest  } : e );

                  //OnGetting(con,e = new BusinessRulesEventArgs<SDCasePriority>() {  ContextRequest = contextRequest, FilterExpressionString = predicateString });
			   	if (e != null) {
				    //predicateString = e.GetQueryString();
						if (e.Cancel)
						{
							context = null;
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				//	 else {
                //      predicateString = predicateString.Replace("*extraFreeText*", "").Replace("()","");
                //  }
				//con.EnableChangeTrackingUsingProxies = false;
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                //if (predicate == null) predicate = PredicateBuilder.True<SDCasePriority>();
                
                //var es = _repository.Queryable;
				IQueryable<SDCasePriority> query = con.SDCasePriorities.AsQueryable();
		
				// include relations FK
				if(string.IsNullOrEmpty(includes) ){
					includes ="";
				}
				StringBuilder sbQuerySystem = new StringBuilder();
                    //predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				

				//if (!string.IsNullOrEmpty(predicateString))
                //      sbQuerySystem.Append(" And ");
                //sbQuerySystem.Append(" (IsDeleted != true Or IsDeleted = null) ");
				 filter.SetFilterPart("de", "(IsDeleted != true OR IsDeleted = null)");


					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
	                    	if (contextRequest.User !=null )
	                        	if (contextRequest.Company != null ){
	                        		//if (sbQuerySystem.Length > 0)
	                        		//	    			sbQuerySystem.Append( " And ");	
									//sbQuerySystem.Append(@" (GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa

									filter.SetFilterPart("co",@"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))");

								}
						}	
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				//string predicateString = predicate.ToDynamicLinq<SDCasePriority>();
				//predicateString += sbQuerySystem.ToString();
				filter.CleanAndProcess("");

				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed(); //SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicateString );               
                string predicateWithManyRelations = filter.GetFilterChildren(); //SFSdotNet.Framework.Linq.Utils.CleanPartExpression(predicateString);

                //QueryUtils.BreakeQuery1(predicateString, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
                var _queryable = query.AsQueryable();
				bool includeAll = true; 
                if (!string.IsNullOrEmpty(predicateWithManyRelations))
                    _queryable = _queryable.Where(predicateWithManyRelations, contextRequest.CustomQuery.ExtraParams);
				if (contextRequest.CustomQuery.SpecificProperties.Count > 0)
                {

				includeAll = false; 
                }

				StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append("new (");
                bool existPrev = false;
                foreach (var selected in contextRequest.CustomQuery.SelectedFields.Where(p=> !string.IsNullOrEmpty(p.Linq)))
                {
                    if (existPrev) sbSelect.Append(", ");
                    if (!selected.Linq.Contains(".") && !selected.Linq.StartsWith("it."))
                        sbSelect.Append("it." + selected.Linq);
                    else
                        sbSelect.Append(selected.Linq);
                    existPrev = true;
                }
                sbSelect.Append(")");
                var queryable = _queryable.Select(sbSelect.ToString());                    


     				
                 if (!string.IsNullOrEmpty(predicateWithFKAndComputed))
                    queryable = queryable.Where(predicateWithFKAndComputed, contextRequest.CustomQuery.ExtraParams);

				QueryComplementOptions queryOps = ContextQueryBuilder.ApplyContextQuery(contextRequest);
            	if (!string.IsNullOrEmpty(queryOps.OrderByAndSort)){
					if (queryOps.OrderBy.Contains(".") && !queryOps.OrderBy.StartsWith("it.")) queryOps.OrderBy = "it." + queryOps.OrderBy;
					queryable = queryable.OrderBy(queryOps.OrderByAndSort);
					}
               	if (queryOps.Skip != null)
                {
                    queryable = queryable.Skip(queryOps.Skip.Value);
                }
                if (queryOps.PageSize != null)
                {
                    queryable = queryable.Take (queryOps.PageSize.Value);
                }


                var resultTemp = queryable.AsQueryable().ToListAsync().Result;
                foreach (var item in resultTemp)
                {

				   result.Add(SFSdotNet.Framework.BR.Utils.GetConverted<SDCasePriority,dynamic>(item, contextRequest.CustomQuery.SelectedFields.Select(p=>p.Name).ToArray()));
                }

			 if (e != null)
                {
                    e.Items = result;
                }
				 contextRequest.CustomQuery = new CustomQuery();
				OnTaken(this, e == null ? e = new BusinessRulesEventArgs<SDCasePriority>() { Items= result, IncludingComputedLinq = true, ContextRequest = contextRequest, FilterExpressionString  = predicateString } :  e);
  
			
  
                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
	
	*/
	#endregion

            }
        }
		public SDCasePriority GetFromOperation(string function, string filterString, string usemode, string fields, ContextRequest contextRequest)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
                string computedFields = "";
               // string fkIncludes = "accContpaqiClassification,accProjectConcept,accProjectType,accProxyUser";
                List<string> multilangProperties = new List<string>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					if (contextRequest != null && contextRequest.Company != null)
					{
						multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
						contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
					}
					 									
					string multiTenantField = "GuidCompany";


                return GetSummaryOperation(con, new SDCasePriority(), function, filterString, usemode, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields, contextRequest, fields.Split(char.Parse(",")).ToArray());
            }
        }

   protected override void QueryBuild(string predicate, Filter filter, DbContext efContext, ContextRequest contextRequest, string method, List<string> includesList)
      	{
				if (contextRequest.CustomQuery.SpecificProperties.Count == 0)
                {
					contextRequest.CustomQuery.SpecificProperties.Add(SDCasePriority.PropertyNames.Title);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCasePriority.PropertyNames.GuidCompany);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCasePriority.PropertyNames.CreatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCasePriority.PropertyNames.UpdatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCasePriority.PropertyNames.CreatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCasePriority.PropertyNames.UpdatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCasePriority.PropertyNames.Bytes);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCasePriority.PropertyNames.IsDeleted);
                    
				}

				if (method == "getby" || method == "sum")
				{
					if (!contextRequest.CustomQuery.SpecificProperties.Contains("GuidCasePriority")){
						contextRequest.CustomQuery.SpecificProperties.Add("GuidCasePriority");
					}

					 if (!string.IsNullOrEmpty(contextRequest.CustomQuery.OrderBy))
					{
						string existPropertyOrderBy = contextRequest.CustomQuery.OrderBy;
						if (contextRequest.CustomQuery.OrderBy.Contains("."))
						{
							existPropertyOrderBy = contextRequest.CustomQuery.OrderBy.Split(char.Parse("."))[0];
						}
						if (!contextRequest.CustomQuery.SpecificProperties.Exists(p => p == existPropertyOrderBy))
						{
							contextRequest.CustomQuery.SpecificProperties.Add(existPropertyOrderBy);
						}
					}

				}
				
	bool isFullDetails = contextRequest.IsFromUI("SDCasePriorities", UIActions.GetForDetails);
	string filterForTest = predicate  + filter.GetFilterComplete();

				if (isFullDetails || !string.IsNullOrEmpty(predicate))
            {
            } 

			if (method == "sum")
            {
            } 
			if (contextRequest.CustomQuery.SelectedFields.Count == 0)
            {
				foreach (var selected in contextRequest.CustomQuery.SpecificProperties)
                {
					string linq = selected;
					switch (selected)
                    {

					 
						
					 default:
                            break;
                    }
					contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name=selected, Linq=linq});
					if (method == "getby" || method == "sum")
					{
						if (includesList.Contains(selected))
							includesList.Remove(selected);

					}

				}
			}
				if (method == "getby" || method == "sum")
				{
					foreach (var otherInclude in includesList.Where(p=> !string.IsNullOrEmpty(p)))
					{
						contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name = otherInclude, Linq = "it." + otherInclude +" as " + otherInclude });
					}
				}
				BusinessRulesEventArgs<SDCasePriority> e = null;
				if (contextRequest.PreventInterceptors == false)
					OnQuerySettings(efContext, e = new BusinessRulesEventArgs<SDCasePriority>() { Filter = filter, ContextRequest = contextRequest /*, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null)*/ });

				//List<SDCasePriority> result = new List<SDCasePriority>();
                 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }

}
		public List<SDCasePriority> GetBy(Expression<Func<SDCasePriority, bool>> predicate, bool loadRelations, ContextRequest contextRequest)
        {
			if(!loadRelations)
				return GetBy(predicate, contextRequest);
			else
				return GetBy(predicate, contextRequest, "SDCases");

        }

        public List<SDCasePriority> GetBy(Expression<Func<SDCasePriority, bool>> predicate, int? pageSize, int? page, string orderBy, SFSdotNet.Framework.Data.SortDirection? sortDirection)
        {
            return GetBy(predicate, new ContextRequest() { CustomQuery = new CustomQuery() { Page = page, PageSize = pageSize, OrderBy = orderBy, SortDirection = sortDirection } });
        }
        public List<SDCasePriority> GetBy(Expression<Func<SDCasePriority, bool>> predicate)
        {

			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
			contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
			            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            contextRequest.CustomQuery.FilterExpressionString = null;
            return this.GetBy(predicate, contextRequest, "");
        }
        #endregion
        #region Dynamic String
		protected override string GetSpecificFilter(string filter, ContextRequest contextRequest) {
            string result = "";
		    //string linqFilter = String.Empty;
            string freeTextFilter = String.Empty;
            if (filter.Contains("|"))
            {
               // linqFilter = filter.Split(char.Parse("|"))[0];
                freeTextFilter = filter.Split(char.Parse("|"))[1];
            }
            //else {
            //    freeTextFilter = filter;
            //}
            //else {
            //    linqFilter = filter;
            //}
			// linqFilter = SFSdotNet.Framework.Linq.Utils.ReplaceCustomDateFilters(linqFilter);
            //string specificFilter = linqFilter;
            if (!string.IsNullOrEmpty(freeTextFilter))
            {
                System.Text.StringBuilder sbCont = new System.Text.StringBuilder();
                /*if (specificFilter.Length > 0)
                {
                    sbCont.Append(" AND ");
                    sbCont.Append(" ({0})");
                }
                else
                {
                    sbCont.Append("{0}");
                }*/
                //var words = freeTextFilter.Split(char.Parse(" "));
				var word = freeTextFilter;
                System.Text.StringBuilder sbSpec = new System.Text.StringBuilder();
                 int nWords = 1;
				/*foreach (var word in words)
                {
					if (word.Length > 0){
                    if (sbSpec.Length > 0) sbSpec.Append(" AND ");
					if (words.Length > 1) sbSpec.Append("("); */
					
	
					
					
					
									
					sbSpec.Append(string.Format(@"Title.Contains(""{0}"")", word));
					

					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
								 //sbSpec.Append("*extraFreeText*");

                    /*if (words.Length > 1) sbSpec.Append(")");
					
					nWords++;

					}

                }*/
                //specificFilter = string.Format("{0}{1}", specificFilter, string.Format(sbCont.ToString(), sbSpec.ToString()));
                                 result = sbSpec.ToString();  
            }
			//result = specificFilter;
			
			return result;

		}
	
			public List<SDCasePriority> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params object[] extraParams)
        {
			return GetBy(filter, pageSize, page, orderBy, orderDir,  null, extraParams);
		}
           public List<SDCasePriority> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, string usemode, params object[] extraParams)
            { 
                return GetBy(filter, pageSize, page, orderBy, orderDir, usemode, null, extraParams);
            }


		public List<SDCasePriority> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  string usemode, ContextRequest context, params object[] extraParams)

        {

            // string freetext = null;
            //if (filter.Contains("|"))
            //{
            //    int parts = filter.Split(char.Parse("|")).Count();
            //    if (parts > 1)
            //    {

            //        freetext = filter.Split(char.Parse("|"))[1];
            //    }
            //}
		
            //string specificFilter = "";
            //if (!string.IsNullOrEmpty(filter))
            //  specificFilter=  GetSpecificFilter(filter);
            if (string.IsNullOrEmpty(orderBy))
            {
			                orderBy = "UpdatedDate";
            }
			//orderDir = "desc";
			SFSdotNet.Framework.Data.SortDirection direction = SFSdotNet.Framework.Data.SortDirection.Ascending;
            if (!string.IsNullOrEmpty(orderDir))
            {
                if (orderDir == "desc")
                    direction = SFSdotNet.Framework.Data.SortDirection.Descending;
            }
            if (context == null)
                context = new ContextRequest();
			

             context.UseMode = usemode;
             if (context.CustomQuery == null )
                context.CustomQuery =new SFSdotNet.Framework.My.CustomQuery();

 
                context.CustomQuery.ExtraParams = extraParams;

                    context.CustomQuery.OrderBy = orderBy;
                   context.CustomQuery.SortDirection = direction;
                   context.CustomQuery.Page = page;
                  context.CustomQuery.PageSize = pageSize;
               

            

            if (!preventSecurityRestrictions) {
			 if (context.CurrentContext == null)
                {
					if (SFSdotNet.Framework.My.Context.CurrentContext != null &&  SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
					{
						context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
						context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

					}
					else {
						throw new Exception("The security rule require a specific user and company");
					}
				}
            }
            return GetBy(filter, context);
  
        }


        public List<SDCasePriority> GetBy(string strWhere, ContextRequest contextRequest)
        {
        	#region old code
				
				 //Expression<Func<tvsReservationTransport, bool>> predicate = null;
				string strWhereClean = strWhere.Replace("*extraFreeText*", "").Replace("()", "");
                //if (!string.IsNullOrEmpty(strWhereClean)){

                //    object[] extraParams = null;
                //    //if (contextRequest != null )
                //    //    if (contextRequest.CustomQuery != null )
                //    //        extraParams = contextRequest.CustomQuery.ExtraParams;
                //    //predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<tvsReservationTransport, bool>(strWhereClean, extraParams != null? extraParams.Cast<Guid>(): null);				
                //}
				 if (contextRequest == null)
                {
                    contextRequest = new ContextRequest();
                    if (contextRequest.CustomQuery == null)
                        contextRequest.CustomQuery = new CustomQuery();
                }
                  if (!preventSecurityRestrictions) {
					if (contextRequest.User == null || contextRequest.Company == null)
                      {
                     if (SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
                     {
                         contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                         contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

                     }
                     else {
                         throw new Exception("The security rule require a specific User and Company ");
                     }
					 }
                 }
            contextRequest.CustomQuery.FilterExpressionString = strWhere;
				//return GetBy(predicate, contextRequest);  

			#endregion				
				
                    return GetBy(strWhere, contextRequest, "");  


        }
       public List<SDCasePriority> GetBy(string strWhere)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
			
            return GetBy(strWhere, context, null);
        }

        public List<SDCasePriority> GetBy(string strWhere, string includes)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
            return GetBy(strWhere, context, includes);
        }

        #endregion
        #endregion
		
		  #region SaveOrUpdate
        
 		 public SDCasePriority Create(SDCasePriority entity)
        {
				//ObjectContext context = null;
				    if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: Create");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

				return this.Create(entity, contextRequest);


        }
        
       
        public SDCasePriority Create(SDCasePriority entity, ContextRequest contextRequest)
        {
		
		bool graph = false;
	
				bool preventPartial = false;
                if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
               
			using (EFContext con = new EFContext()) {

				SDCasePriority itemForSave = new SDCasePriority();
#region Autos
		if(!preventSecurityRestrictions){

				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion
               BusinessRulesEventArgs<SDCasePriority> e = null;
			    if (preventPartial == false )
                OnCreating(this,e = new BusinessRulesEventArgs<SDCasePriority>() { ContextRequest = contextRequest, Item=entity });
				   if (e != null) {
						if (e.Cancel)
						{
							context = null;
							return e.Item;

						}
					}

                    if (entity.GuidCasePriority == Guid.Empty)
                   {
                       entity.GuidCasePriority = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   itemForSave.GuidCasePriority = entity.GuidCasePriority;
				  
		
			itemForSave.GuidCasePriority = entity.GuidCasePriority;

			itemForSave.Title = entity.Title;

			itemForSave.GuidCompany = entity.GuidCompany;

			itemForSave.CreatedDate = entity.CreatedDate;

			itemForSave.UpdatedDate = entity.UpdatedDate;

			itemForSave.CreatedBy = entity.CreatedBy;

			itemForSave.UpdatedBy = entity.UpdatedBy;

			itemForSave.Bytes = entity.Bytes;

			itemForSave.IsDeleted = entity.IsDeleted;

				
				con.SDCasePriorities.Add(itemForSave);




                
				con.ChangeTracker.Entries().Where(p => p.Entity != itemForSave && p.State != EntityState.Unchanged).ForEach(p => p.State = EntityState.Detached);

				con.Entry<SDCasePriority>(itemForSave).State = EntityState.Added;

				con.SaveChanges();

					 
				

				//itemResult = entity;
                //if (e != null)
                //{
                 //   e.Item = itemResult;
                //}
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false )
                OnCreated(this, e == null ? e = new BusinessRulesEventArgs<SDCasePriority>() { ContextRequest = contextRequest, Item = entity } : e);



                if (e != null && e.Item != null )
                {
                    return e.Item;
                }
                              return entity;
			}
            
        }
        //BusinessRulesEventArgs<SDCasePriority> e = null;
        public void Create(List<SDCasePriority> entities)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            Create(entities, contextRequest);
        }
        public void Create(List<SDCasePriority> entities, ContextRequest contextRequest)
        
        {
			ObjectContext context = null;
            	foreach (SDCasePriority entity in entities)
				{
					this.Create(entity, contextRequest);
				}
        }
		  public void CreateOrUpdateBulk(List<SDCasePriority> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "cu", contextRequest);
        }

        private void CreateOrUpdateBulk(List<SDCasePriority> entities, string actionKey, ContextRequest contextRequest)
        {
			if (entities.Count() > 0){
            bool graph = false;

            bool preventPartial = false;
            if (contextRequest != null && contextRequest.PreventInterceptors == true)
            {
                preventPartial = true;
            }
            foreach (var entity in entities)
            {
                    if (entity.GuidCasePriority == Guid.Empty)
                   {
                       entity.GuidCasePriority = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   
				  


#region Autos
		if(!preventSecurityRestrictions){


 if (actionKey != "u")
                        {
				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;


}
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion


		
			//entity.GuidCasePriority = entity.GuidCasePriority;

			//entity.Title = entity.Title;

			//entity.GuidCompany = entity.GuidCompany;

			//entity.CreatedDate = entity.CreatedDate;

			//entity.UpdatedDate = entity.UpdatedDate;

			//entity.CreatedBy = entity.CreatedBy;

			//entity.UpdatedBy = entity.UpdatedBy;

			//entity.Bytes = entity.Bytes;

			//entity.IsDeleted = entity.IsDeleted;

				
				




                
				

					 
				

				//itemResult = entity;
            }
            using (EFContext con = new EFContext())
            {
                 if (actionKey == "c")
                    {
                        context.BulkInsert(entities);
                    }else if ( actionKey == "u")
                    {
                        context.BulkUpdate(entities);
                    }else
                    {
                        context.BulkInsertOrUpdate(entities);
                    }
            }

			}
        }
	
		public void CreateBulk(List<SDCasePriority> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "c", contextRequest);
        }


		public void UpdateAgile(SDCasePriority item, params string[] fields)
         {
			UpdateAgile(item, null, fields);
        }
		public void UpdateAgile(SDCasePriority item, ContextRequest contextRequest, params string[] fields)
         {
            
             ContextRequest contextNew = null;
             if (contextRequest != null)
             {
                 contextNew = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
                 if (fields != null && fields.Length > 0)
                 {
                     contextNew.CustomQuery.SpecificProperties  = fields.ToList();
                 }
                 else if(contextRequest.CustomQuery.SpecificProperties.Count > 0)
                 {
                     fields = contextRequest.CustomQuery.SpecificProperties.ToArray();
                 }
             }
			

		   using (EFContext con = new EFContext())
            {



               
					List<string> propForCopy = new List<string>();
                    propForCopy.AddRange(fields);
                    
					  
					if (!propForCopy.Contains("GuidCasePriority"))
						propForCopy.Add("GuidCasePriority");
					if (!propForCopy.Contains("Title"))
						propForCopy.Add("Title");

					var itemForUpdate = SFSdotNet.Framework.BR.Utils.GetConverted<SDCasePriority,SDCasePriority>(item, propForCopy.ToArray());
					 itemForUpdate.GuidCasePriority = item.GuidCasePriority;
                  var setT = con.Set<SDCasePriority>().Attach(itemForUpdate);

					if (fields.Count() > 0)
					  {
						  item.ModifiedProperties = fields;
					  }
                    foreach (var property in item.ModifiedProperties)
					{						
                        if (property != "GuidCasePriority")
                             con.Entry(setT).Property(property).IsModified = true;

                    }

                
               int result = con.SaveChanges();
               if (result != 1)
               {
                   SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: 1");
               }


            }

			OnUpdatedAgile(this, new BusinessRulesEventArgs<SDCasePriority>() { Item = item, ContextRequest = contextNew  });

         }
		public void UpdateBulk(List<SDCasePriority>  items, params string[] fields)
         {
             SFSdotNet.Framework.My.ContextRequest req = new SFSdotNet.Framework.My.ContextRequest();
             req.CustomQuery = new SFSdotNet.Framework.My.CustomQuery();
             foreach (var field in fields)
             {
                 req.CustomQuery.SpecificProperties.Add(field);
             }
             UpdateBulk(items, req);

         }

		 public void DeleteBulk(List<SDCasePriority> entities, ContextRequest contextRequest = null)
        {

            using (EFContext con = new EFContext())
            {
                foreach (var entity in entities)
                {
					var entityProxy = new SDCasePriority() { GuidCasePriority = entity.GuidCasePriority };

                    con.Entry<SDCasePriority>(entityProxy).State = EntityState.Deleted;

                }

                int result = con.SaveChanges();
                if (result != entities.Count)
                {
                    SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: " + entities.Count.ToString());
                }
            }

        }

        public void UpdateBulk(List<SDCasePriority> items, ContextRequest contextRequest)
        {
            if (items.Count() > 0){

			 foreach (var entity in items)
            {


#region Autos
		if(!preventSecurityRestrictions){

				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	



			}
#endregion





				}
				using (EFContext con = new EFContext())
				{

                    
                
                   con.BulkUpdate(items);

				}
             
			}	  
        }

         public SDCasePriority Update(SDCasePriority entity)
        {
            if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return Update(entity, contextRequest);
        }
       
         public SDCasePriority Update(SDCasePriority entity, ContextRequest contextRequest)
        {
		 if ((System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null) && contextRequest == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Update");
            }
            if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            }

			
				SDCasePriority  itemResult = null;

	
			//entity.UpdatedDate = DateTime.Now.ToUniversalTime();
			//if(contextRequest.User != null)
				//entity.UpdatedBy = contextRequest.User.GuidUser;

//	    var oldentity = GetBy(p => p.GuidCasePriority == entity.GuidCasePriority, contextRequest).FirstOrDefault();
	//	if (oldentity != null) {
		
          //  entity.CreatedDate = oldentity.CreatedDate;
    //        entity.CreatedBy = oldentity.CreatedBy;
	
      //      entity.GuidCompany = oldentity.GuidCompany;
	
			

	
		//}

			 using( EFContext con = new EFContext()){
				BusinessRulesEventArgs<SDCasePriority> e = null;
				bool preventPartial = false; 
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false)
                OnUpdating(this,e = new BusinessRulesEventArgs<SDCasePriority>() { ContextRequest = contextRequest, Item=entity});
				   if (e != null) {
						if (e.Cancel)
						{
							//outcontext = null;
							return e.Item;

						}
					}

	string includes = "";
	IQueryable < SDCasePriority > query = con.SDCasePriorities.AsQueryable();
	foreach (string include in includes.Split(char.Parse(",")))
                       {
                           if (!string.IsNullOrEmpty(include))
                               query = query.Include(include);
                       }
	var oldentity = query.FirstOrDefault(p => p.GuidCasePriority == entity.GuidCasePriority);
	if (oldentity.Title != entity.Title)
		oldentity.Title = entity.Title;

				//if (entity.UpdatedDate == null || (contextRequest != null && contextRequest.IsFromUI("SDCasePriorities", UIActions.Updating)))
			oldentity.UpdatedDate = DateTime.Now.ToUniversalTime();
			if(contextRequest.User != null)
				oldentity.UpdatedBy = contextRequest.User.GuidUser;

           


				if (entity.SDCases != null)
                {
                    foreach (var item in entity.SDCases)
                    {


                        
                    }
					
                    

                }


				con.ChangeTracker.Entries().Where(p => p.Entity != oldentity).ForEach(p => p.State = EntityState.Unchanged);  
				  
				con.SaveChanges();
        
					 
					
               
				itemResult = entity;
				if(preventPartial == false)
					OnUpdated(this, e = new BusinessRulesEventArgs<SDCasePriority>() { ContextRequest = contextRequest, Item=itemResult });

              	return itemResult;
			}
			  
        }
        public SDCasePriority Save(SDCasePriority entity)
        {
			return Create(entity);
        }
        public int Save(List<SDCasePriority> entities)
        {
			 Create(entities);
            return entities.Count;

        }
        #endregion
        #region Delete
        public void Delete(SDCasePriority entity)
        {
				this.Delete(entity, null);
			
        }
		 public void Delete(SDCasePriority entity, ContextRequest contextRequest)
        {
				
				  List<SDCasePriority> entities = new List<SDCasePriority>();
				   entities.Add(entity);
				this.Delete(entities, contextRequest);
			
        }

         public void Delete(string query, Guid[] guids, ContextRequest contextRequest)
        {
			var br = new SDCasePrioritiesBR(true);
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);
            
            Delete(items, contextRequest);

        }
        public void Delete(SDCasePriority entity,  ContextRequest contextRequest, BusinessRulesEventArgs<SDCasePriority> e = null)
        {
			
				using(EFContext con = new EFContext())
                 {
				
               	BusinessRulesEventArgs<SDCasePriority> _e = null;
               List<SDCasePriority> _items = new List<SDCasePriority>();
                _items.Add(entity);
                if (e == null || e.PreventPartialPropagate == false)
                {
                    OnDeleting(this, _e = (e == null ? new BusinessRulesEventArgs<SDCasePriority>() { ContextRequest = contextRequest, Item = entity, Items = null  } : e));
                }
                if (_e != null)
                {
                    if (_e.Cancel)
						{
							context = null;
							return;

						}
					}


				
									//IsDeleted
					bool logicDelete = true;
					if (entity.IsDeleted != null)
					{
						if (entity.IsDeleted.Value)
							logicDelete = false;
					}
					if (logicDelete)
					{
											//entity = GetBy(p =>, contextRequest).FirstOrDefault();
						entity.IsDeleted = true;
						if (contextRequest != null && contextRequest.User != null)
							entity.UpdatedBy = contextRequest.User.GuidUser;
                        entity.UpdatedDate = DateTime.UtcNow;
						UpdateAgile(entity, "IsDeleted","UpdatedBy","UpdatedDate");

						
					}
					else {
					con.Entry<SDCasePriority>(entity).State = EntityState.Deleted;
					con.SaveChanges();
				
				 
					}
								
				
				 
					
					
			if (e == null || e.PreventPartialPropagate == false)
                {

                    if (_e == null)
                        _e = new BusinessRulesEventArgs<SDCasePriority>() { ContextRequest = contextRequest, Item = entity, Items = null };

                    OnDeleted(this, _e);
                }

				//return null;
			}
        }
 public void UnDelete(string query, Guid[] guids, ContextRequest contextRequest)
        {
            var br = new SDCasePrioritiesBR(true);
            contextRequest.CustomQuery.IncludeDeleted = true;
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);

            foreach (var item in items)
            {
                item.IsDeleted = false;
						if (contextRequest != null && contextRequest.User != null)
							item.UpdatedBy = contextRequest.User.GuidUser;
                        item.UpdatedDate = DateTime.UtcNow;
            }

            UpdateBulk(items, "IsDeleted","UpdatedBy","UpdatedDate");
        }

         public void Delete(List<SDCasePriority> entities,  ContextRequest contextRequest = null )
        {
				
			 BusinessRulesEventArgs<SDCasePriority> _e = null;

                OnDeleting(this, _e = new BusinessRulesEventArgs<SDCasePriority>() { ContextRequest = contextRequest, Item = null, Items = entities });
                if (_e != null)
                {
                    if (_e.Cancel)
                    {
                        context = null;
                        return;

                    }
                }
                bool allSucced = true;
                BusinessRulesEventArgs<SDCasePriority> eToChilds = new BusinessRulesEventArgs<SDCasePriority>();
                if (_e != null)
                {
                    eToChilds = _e;
                }
                else
                {
                    eToChilds = new BusinessRulesEventArgs<SDCasePriority>() { ContextRequest = contextRequest, Item = (entities.Count == 1 ? entities[0] : null), Items = entities };
                }
				foreach (SDCasePriority item in entities)
				{
					try
                    {
                        this.Delete(item, contextRequest, e: eToChilds);
                    }
                    catch (Exception ex)
                    {
                        SFSdotNet.Framework.My.EventLog.Error(ex);
                        allSucced = false;
                    }
				}
				if (_e == null)
                    _e = new BusinessRulesEventArgs<SDCasePriority>() { ContextRequest = contextRequest, CountResult = entities.Count, Item = null, Items = entities };
                OnDeleted(this, _e);

			
        }
        #endregion
 
        #region GetCount
		 public int GetCount(Expression<Func<SDCasePriority, bool>> predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

			return GetCount(predicate, contextRequest);
		}
        public int GetCount(Expression<Func<SDCasePriority, bool>> predicate, ContextRequest contextRequest)
        {


		
		 using (EFContext con = new EFContext())
            {


				if (predicate == null) predicate = PredicateBuilder.True<SDCasePriority>();
           		predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted == null);
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    		if (contextRequest.User !=null )
                        		if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
									predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa

								}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				
				IQueryable<SDCasePriority> query = con.SDCasePriorities.AsQueryable();
                return query.AsExpandable().Count(predicate);

			
				}
			

        }
		  public int GetCount(string predicate,  ContextRequest contextRequest)
         {
             return GetCount(predicate, null, contextRequest);
         }

         public int GetCount(string predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return GetCount(predicate, contextRequest);
        }
		 public int GetCount(string predicate, string usemode){
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
				return GetCount( predicate,  usemode,  contextRequest);
		 }
        public int GetCount(string predicate, string usemode, ContextRequest contextRequest){

		using (EFContext con = new EFContext()) {
				string computedFields = "";
				string fkIncludes = "";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDCasePriority>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetCount(con, predicate, usemode, contextRequest, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields);

			}
			#region old code
			 /* string freetext = null;
            Filter filter = new Filter();

              if (predicate.Contains("|"))
              {
                 
                  filter.SetFilterPart("ft", GetSpecificFilter(predicate, contextRequest));
                 
                  filter.ProcessText(predicate.Split(char.Parse("|"))[0]);
                  freetext = predicate.Split(char.Parse("|"))[1];

				  if (!string.IsNullOrEmpty(freetext) && string.IsNullOrEmpty(contextRequest.FreeText))
                  {
                      contextRequest.FreeText = freetext;
                  }
              }
              else {
                  filter.ProcessText(predicate);
              }
			   predicate = filter.GetFilterComplete();
			// BusinessRulesEventArgs<SDCasePriority>  e = null;
           	using (EFContext con = new EFContext())
			{
			
			

			 QueryBuild(predicate, filter, con, contextRequest, "count", new List<string>());


			
			BusinessRulesEventArgs<SDCasePriority> e = null;

			contextRequest.FreeText = freetext;
			contextRequest.UseMode = usemode;
            OnCounting(this, e = new BusinessRulesEventArgs<SDCasePriority>() {  Filter =filter, ContextRequest = contextRequest });
            if (e != null)
            {
                if (e.Cancel)
                {
                    context = null;
                    return e.CountResult;

                }

            

            }
			
			StringBuilder sbQuerySystem = new StringBuilder();
		
					
                    filter.SetFilterPart("de","(IsDeleted != true OR IsDeleted == null)");
			
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    	if (contextRequest.User !=null )
                        	if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
                        		
								filter.SetFilterPart("co", @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa
						
						
							}
							
							}
							if (preventSecurityRestrictions) preventSecurityRestrictions= false;
		
				   
                 filter.CleanAndProcess("");
				//string predicateWithFKAndComputed = SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicate );               
				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed();
               string predicateWithManyRelations = filter.GetFilterChildren();
			   ///QueryUtils.BreakeQuery1(predicate, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
			   predicate = filter.GetFilterComplete();
               if (!string.IsNullOrEmpty(predicate))
               {
				
					
                    return con.SDCasePriorities.Where(predicate).Count();
					
                }else
                    return con.SDCasePriorities.Count();
					
			}*/
			#endregion

		}
         public int GetCount()
        {
            return GetCount(p => true);
        }
        #endregion
        
         


        public void Delete(List<SDCasePriority.CompositeKey> entityKeys)
        {

            List<SDCasePriority> items = new List<SDCasePriority>();
            foreach (var itemKey in entityKeys)
            {
                items.Add(GetByKey(itemKey.GuidCasePriority));
            }

            Delete(items);

        }
		 public void UpdateAssociation(string relation, string relationValue, string query, Guid[] ids, ContextRequest contextRequest)
        {
            var items = GetBy(query, null, null, null, null, null, contextRequest, ids);
			 var module = SFSdotNet.Framework.Cache.Caching.SystemObjects.GetModuleByKey(SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(System.Web.HttpContext.Current.Request.RequestContext, "area"));
           
            foreach (var item in items)
            {
			  Guid ? guidRelationValue = null ;
                if (!string.IsNullOrEmpty(relationValue)){
                    guidRelationValue = Guid.Parse(relationValue );
                }

				 if (relation.Contains("."))
                {
                    var partsWithOtherProp = relation.Split(char.Parse("|"));
                    var parts = partsWithOtherProp[0].Split(char.Parse("."));

                    string proxyRelName = parts[0];
                    string proxyProperty = parts[1];
                    string proxyPropertyKeyNameFromOther = partsWithOtherProp[1];
                    //string proxyPropertyThis = parts[2];

                    var prop = item.GetType().GetProperty(proxyRelName);
                    //var entityInfo = //SFSdotNet.Framework.
                    // descubrir el tipo de entidad dentro de la colección
                    Type typeEntityInList = SFSdotNet.Framework.Entities.Utils.GetTypeFromList(prop);
                    var newProxyItem = Activator.CreateInstance(typeEntityInList);
                    var propThisForSet = newProxyItem.GetType().GetProperty(proxyProperty);
                    var entityInfoOfProxy = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(typeEntityInList);
                    var propOther = newProxyItem.GetType().GetProperty(proxyPropertyKeyNameFromOther);

                    if (propThisForSet != null && entityInfoOfProxy != null && propOther != null )
                    {
                        var entityInfoThis = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(item.GetType());
                        var valueThisId = item.GetType().GetProperty(entityInfoThis.PropertyKeyName).GetValue(item);
                        if (valueThisId != null)
                            propThisForSet.SetValue(newProxyItem, valueThisId);
                        propOther.SetValue(newProxyItem, Guid.Parse(relationValue));
                        
                        var entityNameProp = newProxyItem.GetType().GetField("EntityName").GetValue(null);
                        var entitySetNameProp = newProxyItem.GetType().GetField("EntitySetName").GetValue(null);

                        SFSdotNet.Framework.Apps.Integration.CreateItemFromApp(entityNameProp.ToString(), entitySetNameProp.ToString(), module.ModuleNamespace, newProxyItem, contextRequest);

                    }

                    // crear una instancia del tipo de entidad
                    // llenar los datos y registrar nuevo


                }
                else
                {
                var prop = item.GetType().GetProperty(relation);
                var entityInfo = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(prop.PropertyType);
                if (entityInfo != null)
                {
                    var ins = Activator.CreateInstance(prop.PropertyType);
                   if (guidRelationValue != null)
                    {
                        prop.PropertyType.GetProperty(entityInfo.PropertyKeyName).SetValue(ins, guidRelationValue);
                        item.GetType().GetProperty(relation).SetValue(item, ins);
                    }
                    else
                    {
                        item.GetType().GetProperty(relation).SetValue(item, null);
                    }

                    Update(item, contextRequest);
                }

				}
            }
        }
		
	}
		public partial class SDCaseStatesBR:BRBase<SDCaseState>{
	 	
           
		 #region Partial methods

           partial void OnUpdating(object sender, BusinessRulesEventArgs<SDCaseState> e);

            partial void OnUpdated(object sender, BusinessRulesEventArgs<SDCaseState> e);
			partial void OnUpdatedAgile(object sender, BusinessRulesEventArgs<SDCaseState> e);

            partial void OnCreating(object sender, BusinessRulesEventArgs<SDCaseState> e);
            partial void OnCreated(object sender, BusinessRulesEventArgs<SDCaseState> e);

            partial void OnDeleting(object sender, BusinessRulesEventArgs<SDCaseState> e);
            partial void OnDeleted(object sender, BusinessRulesEventArgs<SDCaseState> e);

            partial void OnGetting(object sender, BusinessRulesEventArgs<SDCaseState> e);
            protected override void OnVirtualGetting(object sender, BusinessRulesEventArgs<SDCaseState> e)
            {
                OnGetting(sender, e);
            }
			protected override void OnVirtualCounting(object sender, BusinessRulesEventArgs<SDCaseState> e)
            {
                OnCounting(sender, e);
            }
			partial void OnTaken(object sender, BusinessRulesEventArgs<SDCaseState> e);
			protected override void OnVirtualTaken(object sender, BusinessRulesEventArgs<SDCaseState> e)
            {
                OnTaken(sender, e);
            }

            partial void OnCounting(object sender, BusinessRulesEventArgs<SDCaseState> e);
 
			partial void OnQuerySettings(object sender, BusinessRulesEventArgs<SDCaseState> e);
          
            #endregion
			
		private static SDCaseStatesBR singlenton =null;
				public static SDCaseStatesBR NewInstance(){
					return  new SDCaseStatesBR();
					
				}
		public static SDCaseStatesBR Instance{
			get{
				if (singlenton == null)
					singlenton = new SDCaseStatesBR();
				return singlenton;
			}
		}
		//private bool preventSecurityRestrictions = false;
		 public bool PreventAuditTrail { get; set;  }
		#region Fields
        EFContext context = null;
        #endregion
        #region Constructor
        public SDCaseStatesBR()
        {
            context = new EFContext();
        }
		 public SDCaseStatesBR(bool preventSecurity)
            {
                this.preventSecurityRestrictions = preventSecurity;
				context = new EFContext();
            }
        #endregion
		
		#region Get

 		public IQueryable<SDCaseState> Get()
        {
            using (EFContext con = new EFContext())
            {
				
				var query = con.SDCaseStates.AsQueryable();
                con.Configuration.ProxyCreationEnabled = false;

                //query = ContextQueryBuilder<Nutrient>.ApplyContextQuery(query, contextRequest);

                return query;




            }

        }
		


 	
		public List<SDCaseState> GetAll()
        {
            return this.GetBy(p => true);
        }
        public List<SDCaseState> GetAll(string includes)
        {
            return this.GetBy(p => true, includes);
        }
        public SDCaseState GetByKey(Guid guidCaseState)
        {
            return GetByKey(guidCaseState, true);
        }
        public SDCaseState GetByKey(Guid guidCaseState, bool loadIncludes)
        {
            SDCaseState item = null;
			var query = PredicateBuilder.True<SDCaseState>();
                    
			string strWhere = @"GuidCaseState = Guid(""" + guidCaseState.ToString()+@""")";
            Expression<Func<SDCaseState, bool>> predicate = null;
            //if (!string.IsNullOrEmpty(strWhere))
            //    predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDCaseState, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
			 ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
            contextRequest.CustomQuery.FilterExpressionString = strWhere;

			//item = GetBy(predicate, loadIncludes, contextRequest).FirstOrDefault();
			item = GetBy(strWhere,loadIncludes,contextRequest).FirstOrDefault();
            return item;
        }
         public List<SDCaseState> GetBy(string strWhere, bool loadRelations, ContextRequest contextRequest)
        {
            if (!loadRelations)
                return GetBy(strWhere, contextRequest);
            else
                return GetBy(strWhere, contextRequest, "");

        }
		  public List<SDCaseState> GetBy(string strWhere, bool loadRelations)
        {
              if (!loadRelations)
                return GetBy(strWhere, new ContextRequest());
            else
                return GetBy(strWhere, new ContextRequest(), "");

        }
		         public SDCaseState GetByKey(Guid guidCaseState, params Expression<Func<SDCaseState, object>>[] includes)
        {
            SDCaseState item = null;
			string strWhere = @"GuidCaseState = Guid(""" + guidCaseState.ToString()+@""")";
          Expression<Func<SDCaseState, bool>> predicate = p=> p.GuidCaseState == guidCaseState;
           // if (!string.IsNullOrEmpty(strWhere))
           //     predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDCaseState, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
        item = GetBy(predicate, includes).FirstOrDefault();
         ////   item = GetBy(strWhere,includes).FirstOrDefault();
			return item;

        }
        public SDCaseState GetByKey(Guid guidCaseState, string includes)
        {
            SDCaseState item = null;
			string strWhere = @"GuidCaseState = Guid(""" + guidCaseState.ToString()+@""")";
            
			
            item = GetBy(strWhere, includes).FirstOrDefault();
            return item;

        }
		 public SDCaseState GetByKey(Guid guidCaseState, string usemode, string includes)
		{
			return GetByKey(guidCaseState, usemode, null, includes);

		 }
		 public SDCaseState GetByKey(Guid guidCaseState, string usemode, ContextRequest context,  string includes)
        {
            SDCaseState item = null;
			string strWhere = @"GuidCaseState = Guid(""" + guidCaseState.ToString()+@""")";
			if (context == null){
				context = new ContextRequest();
				context.CustomQuery = new CustomQuery();
				context.CustomQuery.IsByKey = true;
				context.CustomQuery.FilterExpressionString = strWhere;
				context.UseMode = usemode;
			}
            item = GetBy(strWhere,context , includes).FirstOrDefault();
            return item;

        }

        #region Dynamic Predicate
        public List<SDCaseState> GetBy(Expression<Func<SDCaseState, bool>> predicate, int? pageSize, int? page)
        {
            return this.GetBy(predicate, pageSize, page, null, null);
        }
        public List<SDCaseState> GetBy(Expression<Func<SDCaseState, bool>> predicate, ContextRequest contextRequest)
        {

            return GetBy(predicate, contextRequest,"");
        }
        
        public List<SDCaseState> GetBy(Expression<Func<SDCaseState, bool>> predicate, ContextRequest contextRequest, params Expression<Func<SDCaseState, object>>[] includes)
        {
            StringBuilder sb = new StringBuilder();
           if (includes != null)
            {
                foreach (var path in includes)
                {

						if (sb.Length > 0) sb.Append(",");
						sb.Append(SFSdotNet.Framework.Linq.Utils.IncludeToString<SDCaseState>(path));

               }
            }
            return GetBy(predicate, contextRequest, sb.ToString());
        }
        
        
        public List<SDCaseState> GetBy(Expression<Func<SDCaseState, bool>> predicate, string includes)
        {
			ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";

            return GetBy(predicate, context, includes);
        }

        public List<SDCaseState> GetBy(Expression<Func<SDCaseState, bool>> predicate, params Expression<Func<SDCaseState, object>>[] includes)
        {
			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest context = new ContextRequest();
			            context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";
            return GetBy(predicate, context, includes);
        }

      
		public bool DisableCache { get; set; }
		public List<SDCaseState> GetBy(Expression<Func<SDCaseState, bool>> predicate, ContextRequest contextRequest, string includes)
		{
            using (EFContext con = new EFContext()) {
				
				string fkIncludes = "";
                List<string> multilangProperties = new List<string>();
				if (predicate == null) predicate = PredicateBuilder.True<SDCaseState>();
                var notDeletedExpression = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;
					Expression<Func<SDCaseState,bool>> multitenantExpression  = null;
					if (contextRequest != null && contextRequest.Company != null)	                        	
						multitenantExpression = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicate, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression);

#region Old code
/*
				List<SDCaseState> result = null;
               BusinessRulesEventArgs<SDCaseState>  e = null;
	
				OnGetting(con, e = new BusinessRulesEventArgs<SDCaseState>() {  FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null) });

               // OnGetting(con,e = new BusinessRulesEventArgs<SDCaseState>() { FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = contextRequest.CustomQuery.FilterExpressionString});
				   if (e != null) {
				    predicate = e.FilterExpression;
						if (e.Cancel)
						{
							context = null;
							 if (e.Items == null) e.Items = new List<SDCaseState>();
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                if (predicate == null) predicate = PredicateBuilder.True<SDCaseState>();
                
                //var es = _repository.Queryable;

                IQueryable<SDCaseState> query =  con.SDCaseStates.AsQueryable();

                                if (!string.IsNullOrEmpty(includes))
                {
                    foreach (string include in includes.Split(char.Parse(",")))
                    {
						if (!string.IsNullOrEmpty(include))
                            query = query.Include(include);
                    }
                }
                    predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
					 	if (!preventSecurityRestrictions)
						{
							if (contextRequest != null )
		                    	if (contextRequest.User !=null )
		                        	if (contextRequest.Company != null){
		                        	
										predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
 									
									}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				query =query.AsExpandable().Where(predicate);
                query = ContextQueryBuilder<SDCaseState>.ApplyContextQuery(query, contextRequest);

                result = query.AsNoTracking().ToList<SDCaseState>();
				  
                if (e != null)
                {
                    e.Items = result;
                }
				//if (contextRequest != null ){
				//	 contextRequest = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
					contextRequest.CustomQuery = new CustomQuery();

				//}
				OnTaken(this, e == null ? e =  new BusinessRulesEventArgs<SDCaseState>() { Items= result, IncludingComputedLinq = false, ContextRequest = contextRequest,  FilterExpression = predicate } :  e);
  
			

                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
				*/
#endregion
            }
        }


		/*public int Update(List<SDCaseState> items, ContextRequest contextRequest)
            {
                int result = 0;
                using (EFContext con = new EFContext())
                {
                   
                

                    foreach (var item in items)
                    {
                        //secMessageToUser messageToUser = new secMessageToUser();
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            item.GetType().GetProperty(prop).SetValue(item, item.GetType().GetProperty(prop).GetValue(item));
                        }
                        //messageToUser.GuidMessageToUser = (Guid)item.GetType().GetProperty("GuidMessageToUser").GetValue(item);

                        var setObject = con.CreateObjectSet<SDCaseState>("SDCaseStates");
                        //messageToUser.Readed = DateTime.UtcNow;
                        setObject.Attach(item);
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            con.ObjectStateManager.GetObjectStateEntry(item).SetModifiedProperty(prop);
                        }
                       
                    }
                    result = con.SaveChanges();

                    


                }
                return result;
            }
           */
		

        public List<SDCaseState> GetBy(string predicateString, ContextRequest contextRequest, string includes)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
				


				string computedFields = "";
				string fkIncludes = "";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDCaseState>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					//if (contextRequest != null && contextRequest.Company != null)                      	
					//	 multitenantExpression = @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))";
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicateString, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression,computedFields);


	#region Old Code
	/*
				BusinessRulesEventArgs<SDCaseState> e = null;

				Filter filter = new Filter();
                if (predicateString.Contains("|"))
                {
                    string ft = GetSpecificFilter(predicateString, contextRequest);
                    if (!string.IsNullOrEmpty(ft))
                        filter.SetFilterPart("ft", ft);
                   
                    contextRequest.FreeText = predicateString.Split(char.Parse("|"))[1];
                    var q1 = predicateString.Split(char.Parse("|"))[0];
                    if (!string.IsNullOrEmpty(q1))
                    {
                        filter.ProcessText(q1);
                    }
                }
                else {
                    filter.ProcessText(predicateString);
                }
				 var includesList = (new List<string>());
                 if (!string.IsNullOrEmpty(includes))
                 {
                     includesList = includes.Split(char.Parse(",")).ToList();
                 }

				List<SDCaseState> result = new List<SDCaseState>();
         
			QueryBuild(predicateString, filter, con, contextRequest, "getby", includesList);
			 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }
				
				
					OnGetting(con, e == null ? e = new BusinessRulesEventArgs<SDCaseState>() { Filter = filter, ContextRequest = contextRequest  } : e );

                  //OnGetting(con,e = new BusinessRulesEventArgs<SDCaseState>() {  ContextRequest = contextRequest, FilterExpressionString = predicateString });
			   	if (e != null) {
				    //predicateString = e.GetQueryString();
						if (e.Cancel)
						{
							context = null;
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				//	 else {
                //      predicateString = predicateString.Replace("*extraFreeText*", "").Replace("()","");
                //  }
				//con.EnableChangeTrackingUsingProxies = false;
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                //if (predicate == null) predicate = PredicateBuilder.True<SDCaseState>();
                
                //var es = _repository.Queryable;
				IQueryable<SDCaseState> query = con.SDCaseStates.AsQueryable();
		
				// include relations FK
				if(string.IsNullOrEmpty(includes) ){
					includes ="";
				}
				StringBuilder sbQuerySystem = new StringBuilder();
                    //predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				

				//if (!string.IsNullOrEmpty(predicateString))
                //      sbQuerySystem.Append(" And ");
                //sbQuerySystem.Append(" (IsDeleted != true Or IsDeleted = null) ");
				 filter.SetFilterPart("de", "(IsDeleted != true OR IsDeleted = null)");


					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
	                    	if (contextRequest.User !=null )
	                        	if (contextRequest.Company != null ){
	                        		//if (sbQuerySystem.Length > 0)
	                        		//	    			sbQuerySystem.Append( " And ");	
									//sbQuerySystem.Append(@" (GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa

									filter.SetFilterPart("co",@"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))");

								}
						}	
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				//string predicateString = predicate.ToDynamicLinq<SDCaseState>();
				//predicateString += sbQuerySystem.ToString();
				filter.CleanAndProcess("");

				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed(); //SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicateString );               
                string predicateWithManyRelations = filter.GetFilterChildren(); //SFSdotNet.Framework.Linq.Utils.CleanPartExpression(predicateString);

                //QueryUtils.BreakeQuery1(predicateString, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
                var _queryable = query.AsQueryable();
				bool includeAll = true; 
                if (!string.IsNullOrEmpty(predicateWithManyRelations))
                    _queryable = _queryable.Where(predicateWithManyRelations, contextRequest.CustomQuery.ExtraParams);
				if (contextRequest.CustomQuery.SpecificProperties.Count > 0)
                {

				includeAll = false; 
                }

				StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append("new (");
                bool existPrev = false;
                foreach (var selected in contextRequest.CustomQuery.SelectedFields.Where(p=> !string.IsNullOrEmpty(p.Linq)))
                {
                    if (existPrev) sbSelect.Append(", ");
                    if (!selected.Linq.Contains(".") && !selected.Linq.StartsWith("it."))
                        sbSelect.Append("it." + selected.Linq);
                    else
                        sbSelect.Append(selected.Linq);
                    existPrev = true;
                }
                sbSelect.Append(")");
                var queryable = _queryable.Select(sbSelect.ToString());                    


     				
                 if (!string.IsNullOrEmpty(predicateWithFKAndComputed))
                    queryable = queryable.Where(predicateWithFKAndComputed, contextRequest.CustomQuery.ExtraParams);

				QueryComplementOptions queryOps = ContextQueryBuilder.ApplyContextQuery(contextRequest);
            	if (!string.IsNullOrEmpty(queryOps.OrderByAndSort)){
					if (queryOps.OrderBy.Contains(".") && !queryOps.OrderBy.StartsWith("it.")) queryOps.OrderBy = "it." + queryOps.OrderBy;
					queryable = queryable.OrderBy(queryOps.OrderByAndSort);
					}
               	if (queryOps.Skip != null)
                {
                    queryable = queryable.Skip(queryOps.Skip.Value);
                }
                if (queryOps.PageSize != null)
                {
                    queryable = queryable.Take (queryOps.PageSize.Value);
                }


                var resultTemp = queryable.AsQueryable().ToListAsync().Result;
                foreach (var item in resultTemp)
                {

				   result.Add(SFSdotNet.Framework.BR.Utils.GetConverted<SDCaseState,dynamic>(item, contextRequest.CustomQuery.SelectedFields.Select(p=>p.Name).ToArray()));
                }

			 if (e != null)
                {
                    e.Items = result;
                }
				 contextRequest.CustomQuery = new CustomQuery();
				OnTaken(this, e == null ? e = new BusinessRulesEventArgs<SDCaseState>() { Items= result, IncludingComputedLinq = true, ContextRequest = contextRequest, FilterExpressionString  = predicateString } :  e);
  
			
  
                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
	
	*/
	#endregion

            }
        }
		public SDCaseState GetFromOperation(string function, string filterString, string usemode, string fields, ContextRequest contextRequest)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
                string computedFields = "";
               // string fkIncludes = "accContpaqiClassification,accProjectConcept,accProjectType,accProxyUser";
                List<string> multilangProperties = new List<string>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					if (contextRequest != null && contextRequest.Company != null)
					{
						multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
						contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
					}
					 									
					string multiTenantField = "GuidCompany";


                return GetSummaryOperation(con, new SDCaseState(), function, filterString, usemode, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields, contextRequest, fields.Split(char.Parse(",")).ToArray());
            }
        }

   protected override void QueryBuild(string predicate, Filter filter, DbContext efContext, ContextRequest contextRequest, string method, List<string> includesList)
      	{
				if (contextRequest.CustomQuery.SpecificProperties.Count == 0)
                {
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseState.PropertyNames.Title);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseState.PropertyNames.GuidCompany);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseState.PropertyNames.CreatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseState.PropertyNames.UpdatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseState.PropertyNames.CreatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseState.PropertyNames.UpdatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseState.PropertyNames.Bytes);
					contextRequest.CustomQuery.SpecificProperties.Add(SDCaseState.PropertyNames.IsDeleted);
                    
				}

				if (method == "getby" || method == "sum")
				{
					if (!contextRequest.CustomQuery.SpecificProperties.Contains("GuidCaseState")){
						contextRequest.CustomQuery.SpecificProperties.Add("GuidCaseState");
					}

					 if (!string.IsNullOrEmpty(contextRequest.CustomQuery.OrderBy))
					{
						string existPropertyOrderBy = contextRequest.CustomQuery.OrderBy;
						if (contextRequest.CustomQuery.OrderBy.Contains("."))
						{
							existPropertyOrderBy = contextRequest.CustomQuery.OrderBy.Split(char.Parse("."))[0];
						}
						if (!contextRequest.CustomQuery.SpecificProperties.Exists(p => p == existPropertyOrderBy))
						{
							contextRequest.CustomQuery.SpecificProperties.Add(existPropertyOrderBy);
						}
					}

				}
				
	bool isFullDetails = contextRequest.IsFromUI("SDCaseStates", UIActions.GetForDetails);
	string filterForTest = predicate  + filter.GetFilterComplete();

				if (isFullDetails || !string.IsNullOrEmpty(predicate))
            {
            } 

			if (method == "sum")
            {
            } 
			if (contextRequest.CustomQuery.SelectedFields.Count == 0)
            {
				foreach (var selected in contextRequest.CustomQuery.SpecificProperties)
                {
					string linq = selected;
					switch (selected)
                    {

					 
						
					 default:
                            break;
                    }
					contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name=selected, Linq=linq});
					if (method == "getby" || method == "sum")
					{
						if (includesList.Contains(selected))
							includesList.Remove(selected);

					}

				}
			}
				if (method == "getby" || method == "sum")
				{
					foreach (var otherInclude in includesList.Where(p=> !string.IsNullOrEmpty(p)))
					{
						contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name = otherInclude, Linq = "it." + otherInclude +" as " + otherInclude });
					}
				}
				BusinessRulesEventArgs<SDCaseState> e = null;
				if (contextRequest.PreventInterceptors == false)
					OnQuerySettings(efContext, e = new BusinessRulesEventArgs<SDCaseState>() { Filter = filter, ContextRequest = contextRequest /*, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null)*/ });

				//List<SDCaseState> result = new List<SDCaseState>();
                 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }

}
		public List<SDCaseState> GetBy(Expression<Func<SDCaseState, bool>> predicate, bool loadRelations, ContextRequest contextRequest)
        {
			if(!loadRelations)
				return GetBy(predicate, contextRequest);
			else
				return GetBy(predicate, contextRequest, "SDCases,SDCaseHistories");

        }

        public List<SDCaseState> GetBy(Expression<Func<SDCaseState, bool>> predicate, int? pageSize, int? page, string orderBy, SFSdotNet.Framework.Data.SortDirection? sortDirection)
        {
            return GetBy(predicate, new ContextRequest() { CustomQuery = new CustomQuery() { Page = page, PageSize = pageSize, OrderBy = orderBy, SortDirection = sortDirection } });
        }
        public List<SDCaseState> GetBy(Expression<Func<SDCaseState, bool>> predicate)
        {

			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
			contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
			            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            contextRequest.CustomQuery.FilterExpressionString = null;
            return this.GetBy(predicate, contextRequest, "");
        }
        #endregion
        #region Dynamic String
		protected override string GetSpecificFilter(string filter, ContextRequest contextRequest) {
            string result = "";
		    //string linqFilter = String.Empty;
            string freeTextFilter = String.Empty;
            if (filter.Contains("|"))
            {
               // linqFilter = filter.Split(char.Parse("|"))[0];
                freeTextFilter = filter.Split(char.Parse("|"))[1];
            }
            //else {
            //    freeTextFilter = filter;
            //}
            //else {
            //    linqFilter = filter;
            //}
			// linqFilter = SFSdotNet.Framework.Linq.Utils.ReplaceCustomDateFilters(linqFilter);
            //string specificFilter = linqFilter;
            if (!string.IsNullOrEmpty(freeTextFilter))
            {
                System.Text.StringBuilder sbCont = new System.Text.StringBuilder();
                /*if (specificFilter.Length > 0)
                {
                    sbCont.Append(" AND ");
                    sbCont.Append(" ({0})");
                }
                else
                {
                    sbCont.Append("{0}");
                }*/
                //var words = freeTextFilter.Split(char.Parse(" "));
				var word = freeTextFilter;
                System.Text.StringBuilder sbSpec = new System.Text.StringBuilder();
                 int nWords = 1;
				/*foreach (var word in words)
                {
					if (word.Length > 0){
                    if (sbSpec.Length > 0) sbSpec.Append(" AND ");
					if (words.Length > 1) sbSpec.Append("("); */
					
	
					
					
					
									
					sbSpec.Append(string.Format(@"Title.Contains(""{0}"")", word));
					

					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
								 //sbSpec.Append("*extraFreeText*");

                    /*if (words.Length > 1) sbSpec.Append(")");
					
					nWords++;

					}

                }*/
                //specificFilter = string.Format("{0}{1}", specificFilter, string.Format(sbCont.ToString(), sbSpec.ToString()));
                                 result = sbSpec.ToString();  
            }
			//result = specificFilter;
			
			return result;

		}
	
			public List<SDCaseState> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params object[] extraParams)
        {
			return GetBy(filter, pageSize, page, orderBy, orderDir,  null, extraParams);
		}
           public List<SDCaseState> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, string usemode, params object[] extraParams)
            { 
                return GetBy(filter, pageSize, page, orderBy, orderDir, usemode, null, extraParams);
            }


		public List<SDCaseState> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  string usemode, ContextRequest context, params object[] extraParams)

        {

            // string freetext = null;
            //if (filter.Contains("|"))
            //{
            //    int parts = filter.Split(char.Parse("|")).Count();
            //    if (parts > 1)
            //    {

            //        freetext = filter.Split(char.Parse("|"))[1];
            //    }
            //}
		
            //string specificFilter = "";
            //if (!string.IsNullOrEmpty(filter))
            //  specificFilter=  GetSpecificFilter(filter);
            if (string.IsNullOrEmpty(orderBy))
            {
			                orderBy = "UpdatedDate";
            }
			//orderDir = "desc";
			SFSdotNet.Framework.Data.SortDirection direction = SFSdotNet.Framework.Data.SortDirection.Ascending;
            if (!string.IsNullOrEmpty(orderDir))
            {
                if (orderDir == "desc")
                    direction = SFSdotNet.Framework.Data.SortDirection.Descending;
            }
            if (context == null)
                context = new ContextRequest();
			

             context.UseMode = usemode;
             if (context.CustomQuery == null )
                context.CustomQuery =new SFSdotNet.Framework.My.CustomQuery();

 
                context.CustomQuery.ExtraParams = extraParams;

                    context.CustomQuery.OrderBy = orderBy;
                   context.CustomQuery.SortDirection = direction;
                   context.CustomQuery.Page = page;
                  context.CustomQuery.PageSize = pageSize;
               

            

            if (!preventSecurityRestrictions) {
			 if (context.CurrentContext == null)
                {
					if (SFSdotNet.Framework.My.Context.CurrentContext != null &&  SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
					{
						context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
						context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

					}
					else {
						throw new Exception("The security rule require a specific user and company");
					}
				}
            }
            return GetBy(filter, context);
  
        }


        public List<SDCaseState> GetBy(string strWhere, ContextRequest contextRequest)
        {
        	#region old code
				
				 //Expression<Func<tvsReservationTransport, bool>> predicate = null;
				string strWhereClean = strWhere.Replace("*extraFreeText*", "").Replace("()", "");
                //if (!string.IsNullOrEmpty(strWhereClean)){

                //    object[] extraParams = null;
                //    //if (contextRequest != null )
                //    //    if (contextRequest.CustomQuery != null )
                //    //        extraParams = contextRequest.CustomQuery.ExtraParams;
                //    //predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<tvsReservationTransport, bool>(strWhereClean, extraParams != null? extraParams.Cast<Guid>(): null);				
                //}
				 if (contextRequest == null)
                {
                    contextRequest = new ContextRequest();
                    if (contextRequest.CustomQuery == null)
                        contextRequest.CustomQuery = new CustomQuery();
                }
                  if (!preventSecurityRestrictions) {
					if (contextRequest.User == null || contextRequest.Company == null)
                      {
                     if (SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
                     {
                         contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                         contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

                     }
                     else {
                         throw new Exception("The security rule require a specific User and Company ");
                     }
					 }
                 }
            contextRequest.CustomQuery.FilterExpressionString = strWhere;
				//return GetBy(predicate, contextRequest);  

			#endregion				
				
                    return GetBy(strWhere, contextRequest, "");  


        }
       public List<SDCaseState> GetBy(string strWhere)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
			
            return GetBy(strWhere, context, null);
        }

        public List<SDCaseState> GetBy(string strWhere, string includes)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
            return GetBy(strWhere, context, includes);
        }

        #endregion
        #endregion
		
		  #region SaveOrUpdate
        
 		 public SDCaseState Create(SDCaseState entity)
        {
				//ObjectContext context = null;
				    if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: Create");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

				return this.Create(entity, contextRequest);


        }
        
       
        public SDCaseState Create(SDCaseState entity, ContextRequest contextRequest)
        {
		
		bool graph = false;
	
				bool preventPartial = false;
                if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
               
			using (EFContext con = new EFContext()) {

				SDCaseState itemForSave = new SDCaseState();
#region Autos
		if(!preventSecurityRestrictions){

				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion
               BusinessRulesEventArgs<SDCaseState> e = null;
			    if (preventPartial == false )
                OnCreating(this,e = new BusinessRulesEventArgs<SDCaseState>() { ContextRequest = contextRequest, Item=entity });
				   if (e != null) {
						if (e.Cancel)
						{
							context = null;
							return e.Item;

						}
					}

                    if (entity.GuidCaseState == Guid.Empty)
                   {
                       entity.GuidCaseState = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   itemForSave.GuidCaseState = entity.GuidCaseState;
				  
		
			itemForSave.GuidCaseState = entity.GuidCaseState;

			itemForSave.Title = entity.Title;

			itemForSave.GuidCompany = entity.GuidCompany;

			itemForSave.CreatedDate = entity.CreatedDate;

			itemForSave.UpdatedDate = entity.UpdatedDate;

			itemForSave.CreatedBy = entity.CreatedBy;

			itemForSave.UpdatedBy = entity.UpdatedBy;

			itemForSave.Bytes = entity.Bytes;

			itemForSave.IsDeleted = entity.IsDeleted;

				
				con.SDCaseStates.Add(itemForSave);






                
				con.ChangeTracker.Entries().Where(p => p.Entity != itemForSave && p.State != EntityState.Unchanged).ForEach(p => p.State = EntityState.Detached);

				con.Entry<SDCaseState>(itemForSave).State = EntityState.Added;

				con.SaveChanges();

					 
				

				//itemResult = entity;
                //if (e != null)
                //{
                 //   e.Item = itemResult;
                //}
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false )
                OnCreated(this, e == null ? e = new BusinessRulesEventArgs<SDCaseState>() { ContextRequest = contextRequest, Item = entity } : e);



                if (e != null && e.Item != null )
                {
                    return e.Item;
                }
                              return entity;
			}
            
        }
        //BusinessRulesEventArgs<SDCaseState> e = null;
        public void Create(List<SDCaseState> entities)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            Create(entities, contextRequest);
        }
        public void Create(List<SDCaseState> entities, ContextRequest contextRequest)
        
        {
			ObjectContext context = null;
            	foreach (SDCaseState entity in entities)
				{
					this.Create(entity, contextRequest);
				}
        }
		  public void CreateOrUpdateBulk(List<SDCaseState> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "cu", contextRequest);
        }

        private void CreateOrUpdateBulk(List<SDCaseState> entities, string actionKey, ContextRequest contextRequest)
        {
			if (entities.Count() > 0){
            bool graph = false;

            bool preventPartial = false;
            if (contextRequest != null && contextRequest.PreventInterceptors == true)
            {
                preventPartial = true;
            }
            foreach (var entity in entities)
            {
                    if (entity.GuidCaseState == Guid.Empty)
                   {
                       entity.GuidCaseState = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   
				  


#region Autos
		if(!preventSecurityRestrictions){


 if (actionKey != "u")
                        {
				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;


}
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion


		
			//entity.GuidCaseState = entity.GuidCaseState;

			//entity.Title = entity.Title;

			//entity.GuidCompany = entity.GuidCompany;

			//entity.CreatedDate = entity.CreatedDate;

			//entity.UpdatedDate = entity.UpdatedDate;

			//entity.CreatedBy = entity.CreatedBy;

			//entity.UpdatedBy = entity.UpdatedBy;

			//entity.Bytes = entity.Bytes;

			//entity.IsDeleted = entity.IsDeleted;

				
				






                
				

					 
				

				//itemResult = entity;
            }
            using (EFContext con = new EFContext())
            {
                 if (actionKey == "c")
                    {
                        context.BulkInsert(entities);
                    }else if ( actionKey == "u")
                    {
                        context.BulkUpdate(entities);
                    }else
                    {
                        context.BulkInsertOrUpdate(entities);
                    }
            }

			}
        }
	
		public void CreateBulk(List<SDCaseState> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "c", contextRequest);
        }


		public void UpdateAgile(SDCaseState item, params string[] fields)
         {
			UpdateAgile(item, null, fields);
        }
		public void UpdateAgile(SDCaseState item, ContextRequest contextRequest, params string[] fields)
         {
            
             ContextRequest contextNew = null;
             if (contextRequest != null)
             {
                 contextNew = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
                 if (fields != null && fields.Length > 0)
                 {
                     contextNew.CustomQuery.SpecificProperties  = fields.ToList();
                 }
                 else if(contextRequest.CustomQuery.SpecificProperties.Count > 0)
                 {
                     fields = contextRequest.CustomQuery.SpecificProperties.ToArray();
                 }
             }
			

		   using (EFContext con = new EFContext())
            {



               
					List<string> propForCopy = new List<string>();
                    propForCopy.AddRange(fields);
                    
					  
					if (!propForCopy.Contains("GuidCaseState"))
						propForCopy.Add("GuidCaseState");
					if (!propForCopy.Contains("Title"))
						propForCopy.Add("Title");

					var itemForUpdate = SFSdotNet.Framework.BR.Utils.GetConverted<SDCaseState,SDCaseState>(item, propForCopy.ToArray());
					 itemForUpdate.GuidCaseState = item.GuidCaseState;
                  var setT = con.Set<SDCaseState>().Attach(itemForUpdate);

					if (fields.Count() > 0)
					  {
						  item.ModifiedProperties = fields;
					  }
                    foreach (var property in item.ModifiedProperties)
					{						
                        if (property != "GuidCaseState")
                             con.Entry(setT).Property(property).IsModified = true;

                    }

                
               int result = con.SaveChanges();
               if (result != 1)
               {
                   SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: 1");
               }


            }

			OnUpdatedAgile(this, new BusinessRulesEventArgs<SDCaseState>() { Item = item, ContextRequest = contextNew  });

         }
		public void UpdateBulk(List<SDCaseState>  items, params string[] fields)
         {
             SFSdotNet.Framework.My.ContextRequest req = new SFSdotNet.Framework.My.ContextRequest();
             req.CustomQuery = new SFSdotNet.Framework.My.CustomQuery();
             foreach (var field in fields)
             {
                 req.CustomQuery.SpecificProperties.Add(field);
             }
             UpdateBulk(items, req);

         }

		 public void DeleteBulk(List<SDCaseState> entities, ContextRequest contextRequest = null)
        {

            using (EFContext con = new EFContext())
            {
                foreach (var entity in entities)
                {
					var entityProxy = new SDCaseState() { GuidCaseState = entity.GuidCaseState };

                    con.Entry<SDCaseState>(entityProxy).State = EntityState.Deleted;

                }

                int result = con.SaveChanges();
                if (result != entities.Count)
                {
                    SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: " + entities.Count.ToString());
                }
            }

        }

        public void UpdateBulk(List<SDCaseState> items, ContextRequest contextRequest)
        {
            if (items.Count() > 0){

			 foreach (var entity in items)
            {


#region Autos
		if(!preventSecurityRestrictions){

				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	



			}
#endregion







				}
				using (EFContext con = new EFContext())
				{

                    
                
                   con.BulkUpdate(items);

				}
             
			}	  
        }

         public SDCaseState Update(SDCaseState entity)
        {
            if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return Update(entity, contextRequest);
        }
       
         public SDCaseState Update(SDCaseState entity, ContextRequest contextRequest)
        {
		 if ((System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null) && contextRequest == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Update");
            }
            if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            }

			
				SDCaseState  itemResult = null;

	
			//entity.UpdatedDate = DateTime.Now.ToUniversalTime();
			//if(contextRequest.User != null)
				//entity.UpdatedBy = contextRequest.User.GuidUser;

//	    var oldentity = GetBy(p => p.GuidCaseState == entity.GuidCaseState, contextRequest).FirstOrDefault();
	//	if (oldentity != null) {
		
          //  entity.CreatedDate = oldentity.CreatedDate;
    //        entity.CreatedBy = oldentity.CreatedBy;
	
      //      entity.GuidCompany = oldentity.GuidCompany;
	
			

	
		//}

			 using( EFContext con = new EFContext()){
				BusinessRulesEventArgs<SDCaseState> e = null;
				bool preventPartial = false; 
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false)
                OnUpdating(this,e = new BusinessRulesEventArgs<SDCaseState>() { ContextRequest = contextRequest, Item=entity});
				   if (e != null) {
						if (e.Cancel)
						{
							//outcontext = null;
							return e.Item;

						}
					}

	string includes = "";
	IQueryable < SDCaseState > query = con.SDCaseStates.AsQueryable();
	foreach (string include in includes.Split(char.Parse(",")))
                       {
                           if (!string.IsNullOrEmpty(include))
                               query = query.Include(include);
                       }
	var oldentity = query.FirstOrDefault(p => p.GuidCaseState == entity.GuidCaseState);
	if (oldentity.Title != entity.Title)
		oldentity.Title = entity.Title;

				//if (entity.UpdatedDate == null || (contextRequest != null && contextRequest.IsFromUI("SDCaseStates", UIActions.Updating)))
			oldentity.UpdatedDate = DateTime.Now.ToUniversalTime();
			if(contextRequest.User != null)
				oldentity.UpdatedBy = contextRequest.User.GuidUser;

           


				if (entity.SDCases != null)
                {
                    foreach (var item in entity.SDCases)
                    {


                        
                    }
					
                    

                }


				if (entity.SDCaseHistories != null)
                {
                    foreach (var item in entity.SDCaseHistories)
                    {


                        
                    }
					
                    

                }


				con.ChangeTracker.Entries().Where(p => p.Entity != oldentity).ForEach(p => p.State = EntityState.Unchanged);  
				  
				con.SaveChanges();
        
					 
					
               
				itemResult = entity;
				if(preventPartial == false)
					OnUpdated(this, e = new BusinessRulesEventArgs<SDCaseState>() { ContextRequest = contextRequest, Item=itemResult });

              	return itemResult;
			}
			  
        }
        public SDCaseState Save(SDCaseState entity)
        {
			return Create(entity);
        }
        public int Save(List<SDCaseState> entities)
        {
			 Create(entities);
            return entities.Count;

        }
        #endregion
        #region Delete
        public void Delete(SDCaseState entity)
        {
				this.Delete(entity, null);
			
        }
		 public void Delete(SDCaseState entity, ContextRequest contextRequest)
        {
				
				  List<SDCaseState> entities = new List<SDCaseState>();
				   entities.Add(entity);
				this.Delete(entities, contextRequest);
			
        }

         public void Delete(string query, Guid[] guids, ContextRequest contextRequest)
        {
			var br = new SDCaseStatesBR(true);
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);
            
            Delete(items, contextRequest);

        }
        public void Delete(SDCaseState entity,  ContextRequest contextRequest, BusinessRulesEventArgs<SDCaseState> e = null)
        {
			
				using(EFContext con = new EFContext())
                 {
				
               	BusinessRulesEventArgs<SDCaseState> _e = null;
               List<SDCaseState> _items = new List<SDCaseState>();
                _items.Add(entity);
                if (e == null || e.PreventPartialPropagate == false)
                {
                    OnDeleting(this, _e = (e == null ? new BusinessRulesEventArgs<SDCaseState>() { ContextRequest = contextRequest, Item = entity, Items = null  } : e));
                }
                if (_e != null)
                {
                    if (_e.Cancel)
						{
							context = null;
							return;

						}
					}


				
									//IsDeleted
					bool logicDelete = true;
					if (entity.IsDeleted != null)
					{
						if (entity.IsDeleted.Value)
							logicDelete = false;
					}
					if (logicDelete)
					{
											//entity = GetBy(p =>, contextRequest).FirstOrDefault();
						entity.IsDeleted = true;
						if (contextRequest != null && contextRequest.User != null)
							entity.UpdatedBy = contextRequest.User.GuidUser;
                        entity.UpdatedDate = DateTime.UtcNow;
						UpdateAgile(entity, "IsDeleted","UpdatedBy","UpdatedDate");

						
					}
					else {
					con.Entry<SDCaseState>(entity).State = EntityState.Deleted;
					con.SaveChanges();
				
				 
					}
								
				
				 
					
					
			if (e == null || e.PreventPartialPropagate == false)
                {

                    if (_e == null)
                        _e = new BusinessRulesEventArgs<SDCaseState>() { ContextRequest = contextRequest, Item = entity, Items = null };

                    OnDeleted(this, _e);
                }

				//return null;
			}
        }
 public void UnDelete(string query, Guid[] guids, ContextRequest contextRequest)
        {
            var br = new SDCaseStatesBR(true);
            contextRequest.CustomQuery.IncludeDeleted = true;
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);

            foreach (var item in items)
            {
                item.IsDeleted = false;
						if (contextRequest != null && contextRequest.User != null)
							item.UpdatedBy = contextRequest.User.GuidUser;
                        item.UpdatedDate = DateTime.UtcNow;
            }

            UpdateBulk(items, "IsDeleted","UpdatedBy","UpdatedDate");
        }

         public void Delete(List<SDCaseState> entities,  ContextRequest contextRequest = null )
        {
				
			 BusinessRulesEventArgs<SDCaseState> _e = null;

                OnDeleting(this, _e = new BusinessRulesEventArgs<SDCaseState>() { ContextRequest = contextRequest, Item = null, Items = entities });
                if (_e != null)
                {
                    if (_e.Cancel)
                    {
                        context = null;
                        return;

                    }
                }
                bool allSucced = true;
                BusinessRulesEventArgs<SDCaseState> eToChilds = new BusinessRulesEventArgs<SDCaseState>();
                if (_e != null)
                {
                    eToChilds = _e;
                }
                else
                {
                    eToChilds = new BusinessRulesEventArgs<SDCaseState>() { ContextRequest = contextRequest, Item = (entities.Count == 1 ? entities[0] : null), Items = entities };
                }
				foreach (SDCaseState item in entities)
				{
					try
                    {
                        this.Delete(item, contextRequest, e: eToChilds);
                    }
                    catch (Exception ex)
                    {
                        SFSdotNet.Framework.My.EventLog.Error(ex);
                        allSucced = false;
                    }
				}
				if (_e == null)
                    _e = new BusinessRulesEventArgs<SDCaseState>() { ContextRequest = contextRequest, CountResult = entities.Count, Item = null, Items = entities };
                OnDeleted(this, _e);

			
        }
        #endregion
 
        #region GetCount
		 public int GetCount(Expression<Func<SDCaseState, bool>> predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

			return GetCount(predicate, contextRequest);
		}
        public int GetCount(Expression<Func<SDCaseState, bool>> predicate, ContextRequest contextRequest)
        {


		
		 using (EFContext con = new EFContext())
            {


				if (predicate == null) predicate = PredicateBuilder.True<SDCaseState>();
           		predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted == null);
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    		if (contextRequest.User !=null )
                        		if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
									predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa

								}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				
				IQueryable<SDCaseState> query = con.SDCaseStates.AsQueryable();
                return query.AsExpandable().Count(predicate);

			
				}
			

        }
		  public int GetCount(string predicate,  ContextRequest contextRequest)
         {
             return GetCount(predicate, null, contextRequest);
         }

         public int GetCount(string predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return GetCount(predicate, contextRequest);
        }
		 public int GetCount(string predicate, string usemode){
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
				return GetCount( predicate,  usemode,  contextRequest);
		 }
        public int GetCount(string predicate, string usemode, ContextRequest contextRequest){

		using (EFContext con = new EFContext()) {
				string computedFields = "";
				string fkIncludes = "";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDCaseState>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetCount(con, predicate, usemode, contextRequest, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields);

			}
			#region old code
			 /* string freetext = null;
            Filter filter = new Filter();

              if (predicate.Contains("|"))
              {
                 
                  filter.SetFilterPart("ft", GetSpecificFilter(predicate, contextRequest));
                 
                  filter.ProcessText(predicate.Split(char.Parse("|"))[0]);
                  freetext = predicate.Split(char.Parse("|"))[1];

				  if (!string.IsNullOrEmpty(freetext) && string.IsNullOrEmpty(contextRequest.FreeText))
                  {
                      contextRequest.FreeText = freetext;
                  }
              }
              else {
                  filter.ProcessText(predicate);
              }
			   predicate = filter.GetFilterComplete();
			// BusinessRulesEventArgs<SDCaseState>  e = null;
           	using (EFContext con = new EFContext())
			{
			
			

			 QueryBuild(predicate, filter, con, contextRequest, "count", new List<string>());


			
			BusinessRulesEventArgs<SDCaseState> e = null;

			contextRequest.FreeText = freetext;
			contextRequest.UseMode = usemode;
            OnCounting(this, e = new BusinessRulesEventArgs<SDCaseState>() {  Filter =filter, ContextRequest = contextRequest });
            if (e != null)
            {
                if (e.Cancel)
                {
                    context = null;
                    return e.CountResult;

                }

            

            }
			
			StringBuilder sbQuerySystem = new StringBuilder();
		
					
                    filter.SetFilterPart("de","(IsDeleted != true OR IsDeleted == null)");
			
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    	if (contextRequest.User !=null )
                        	if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
                        		
								filter.SetFilterPart("co", @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa
						
						
							}
							
							}
							if (preventSecurityRestrictions) preventSecurityRestrictions= false;
		
				   
                 filter.CleanAndProcess("");
				//string predicateWithFKAndComputed = SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicate );               
				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed();
               string predicateWithManyRelations = filter.GetFilterChildren();
			   ///QueryUtils.BreakeQuery1(predicate, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
			   predicate = filter.GetFilterComplete();
               if (!string.IsNullOrEmpty(predicate))
               {
				
					
                    return con.SDCaseStates.Where(predicate).Count();
					
                }else
                    return con.SDCaseStates.Count();
					
			}*/
			#endregion

		}
         public int GetCount()
        {
            return GetCount(p => true);
        }
        #endregion
        
         


        public void Delete(List<SDCaseState.CompositeKey> entityKeys)
        {

            List<SDCaseState> items = new List<SDCaseState>();
            foreach (var itemKey in entityKeys)
            {
                items.Add(GetByKey(itemKey.GuidCaseState));
            }

            Delete(items);

        }
		 public void UpdateAssociation(string relation, string relationValue, string query, Guid[] ids, ContextRequest contextRequest)
        {
            var items = GetBy(query, null, null, null, null, null, contextRequest, ids);
			 var module = SFSdotNet.Framework.Cache.Caching.SystemObjects.GetModuleByKey(SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(System.Web.HttpContext.Current.Request.RequestContext, "area"));
           
            foreach (var item in items)
            {
			  Guid ? guidRelationValue = null ;
                if (!string.IsNullOrEmpty(relationValue)){
                    guidRelationValue = Guid.Parse(relationValue );
                }

				 if (relation.Contains("."))
                {
                    var partsWithOtherProp = relation.Split(char.Parse("|"));
                    var parts = partsWithOtherProp[0].Split(char.Parse("."));

                    string proxyRelName = parts[0];
                    string proxyProperty = parts[1];
                    string proxyPropertyKeyNameFromOther = partsWithOtherProp[1];
                    //string proxyPropertyThis = parts[2];

                    var prop = item.GetType().GetProperty(proxyRelName);
                    //var entityInfo = //SFSdotNet.Framework.
                    // descubrir el tipo de entidad dentro de la colección
                    Type typeEntityInList = SFSdotNet.Framework.Entities.Utils.GetTypeFromList(prop);
                    var newProxyItem = Activator.CreateInstance(typeEntityInList);
                    var propThisForSet = newProxyItem.GetType().GetProperty(proxyProperty);
                    var entityInfoOfProxy = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(typeEntityInList);
                    var propOther = newProxyItem.GetType().GetProperty(proxyPropertyKeyNameFromOther);

                    if (propThisForSet != null && entityInfoOfProxy != null && propOther != null )
                    {
                        var entityInfoThis = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(item.GetType());
                        var valueThisId = item.GetType().GetProperty(entityInfoThis.PropertyKeyName).GetValue(item);
                        if (valueThisId != null)
                            propThisForSet.SetValue(newProxyItem, valueThisId);
                        propOther.SetValue(newProxyItem, Guid.Parse(relationValue));
                        
                        var entityNameProp = newProxyItem.GetType().GetField("EntityName").GetValue(null);
                        var entitySetNameProp = newProxyItem.GetType().GetField("EntitySetName").GetValue(null);

                        SFSdotNet.Framework.Apps.Integration.CreateItemFromApp(entityNameProp.ToString(), entitySetNameProp.ToString(), module.ModuleNamespace, newProxyItem, contextRequest);

                    }

                    // crear una instancia del tipo de entidad
                    // llenar los datos y registrar nuevo


                }
                else
                {
                var prop = item.GetType().GetProperty(relation);
                var entityInfo = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(prop.PropertyType);
                if (entityInfo != null)
                {
                    var ins = Activator.CreateInstance(prop.PropertyType);
                   if (guidRelationValue != null)
                    {
                        prop.PropertyType.GetProperty(entityInfo.PropertyKeyName).SetValue(ins, guidRelationValue);
                        item.GetType().GetProperty(relation).SetValue(item, ins);
                    }
                    else
                    {
                        item.GetType().GetProperty(relation).SetValue(item, null);
                    }

                    Update(item, contextRequest);
                }

				}
            }
        }
		
	}
		public partial class SDFilesBR:BRBase<SDFile>{
	 	
           
		 #region Partial methods

           partial void OnUpdating(object sender, BusinessRulesEventArgs<SDFile> e);

            partial void OnUpdated(object sender, BusinessRulesEventArgs<SDFile> e);
			partial void OnUpdatedAgile(object sender, BusinessRulesEventArgs<SDFile> e);

            partial void OnCreating(object sender, BusinessRulesEventArgs<SDFile> e);
            partial void OnCreated(object sender, BusinessRulesEventArgs<SDFile> e);

            partial void OnDeleting(object sender, BusinessRulesEventArgs<SDFile> e);
            partial void OnDeleted(object sender, BusinessRulesEventArgs<SDFile> e);

            partial void OnGetting(object sender, BusinessRulesEventArgs<SDFile> e);
            protected override void OnVirtualGetting(object sender, BusinessRulesEventArgs<SDFile> e)
            {
                OnGetting(sender, e);
            }
			protected override void OnVirtualCounting(object sender, BusinessRulesEventArgs<SDFile> e)
            {
                OnCounting(sender, e);
            }
			partial void OnTaken(object sender, BusinessRulesEventArgs<SDFile> e);
			protected override void OnVirtualTaken(object sender, BusinessRulesEventArgs<SDFile> e)
            {
                OnTaken(sender, e);
            }

            partial void OnCounting(object sender, BusinessRulesEventArgs<SDFile> e);
 
			partial void OnQuerySettings(object sender, BusinessRulesEventArgs<SDFile> e);
          
            #endregion
			
		private static SDFilesBR singlenton =null;
				public static SDFilesBR NewInstance(){
					return  new SDFilesBR();
					
				}
		public static SDFilesBR Instance{
			get{
				if (singlenton == null)
					singlenton = new SDFilesBR();
				return singlenton;
			}
		}
		//private bool preventSecurityRestrictions = false;
		 public bool PreventAuditTrail { get; set;  }
		#region Fields
        EFContext context = null;
        #endregion
        #region Constructor
        public SDFilesBR()
        {
            context = new EFContext();
        }
		 public SDFilesBR(bool preventSecurity)
            {
                this.preventSecurityRestrictions = preventSecurity;
				context = new EFContext();
            }
        #endregion
		
		#region Get

 		public IQueryable<SDFile> Get()
        {
            using (EFContext con = new EFContext())
            {
				
				var query = con.SDFiles.AsQueryable();
                con.Configuration.ProxyCreationEnabled = false;

                //query = ContextQueryBuilder<Nutrient>.ApplyContextQuery(query, contextRequest);

                return query;




            }

        }
		


 	
		public List<SDFile> GetAll()
        {
            return this.GetBy(p => true);
        }
        public List<SDFile> GetAll(string includes)
        {
            return this.GetBy(p => true, includes);
        }
        public SDFile GetByKey(Guid guidFile)
        {
            return GetByKey(guidFile, true);
        }
        public SDFile GetByKey(Guid guidFile, bool loadIncludes)
        {
            SDFile item = null;
			var query = PredicateBuilder.True<SDFile>();
                    
			string strWhere = @"GuidFile = Guid(""" + guidFile.ToString()+@""")";
            Expression<Func<SDFile, bool>> predicate = null;
            //if (!string.IsNullOrEmpty(strWhere))
            //    predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDFile, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
			 ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
            contextRequest.CustomQuery.FilterExpressionString = strWhere;

			//item = GetBy(predicate, loadIncludes, contextRequest).FirstOrDefault();
			item = GetBy(strWhere,loadIncludes,contextRequest).FirstOrDefault();
            return item;
        }
         public List<SDFile> GetBy(string strWhere, bool loadRelations, ContextRequest contextRequest)
        {
            if (!loadRelations)
                return GetBy(strWhere, contextRequest);
            else
                return GetBy(strWhere, contextRequest, "");

        }
		  public List<SDFile> GetBy(string strWhere, bool loadRelations)
        {
              if (!loadRelations)
                return GetBy(strWhere, new ContextRequest());
            else
                return GetBy(strWhere, new ContextRequest(), "");

        }
		         public SDFile GetByKey(Guid guidFile, params Expression<Func<SDFile, object>>[] includes)
        {
            SDFile item = null;
			string strWhere = @"GuidFile = Guid(""" + guidFile.ToString()+@""")";
          Expression<Func<SDFile, bool>> predicate = p=> p.GuidFile == guidFile;
           // if (!string.IsNullOrEmpty(strWhere))
           //     predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDFile, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
        item = GetBy(predicate, includes).FirstOrDefault();
         ////   item = GetBy(strWhere,includes).FirstOrDefault();
			return item;

        }
        public SDFile GetByKey(Guid guidFile, string includes)
        {
            SDFile item = null;
			string strWhere = @"GuidFile = Guid(""" + guidFile.ToString()+@""")";
            
			
            item = GetBy(strWhere, includes).FirstOrDefault();
            return item;

        }
		 public SDFile GetByKey(Guid guidFile, string usemode, string includes)
		{
			return GetByKey(guidFile, usemode, null, includes);

		 }
		 public SDFile GetByKey(Guid guidFile, string usemode, ContextRequest context,  string includes)
        {
            SDFile item = null;
			string strWhere = @"GuidFile = Guid(""" + guidFile.ToString()+@""")";
			if (context == null){
				context = new ContextRequest();
				context.CustomQuery = new CustomQuery();
				context.CustomQuery.IsByKey = true;
				context.CustomQuery.FilterExpressionString = strWhere;
				context.UseMode = usemode;
			}
            item = GetBy(strWhere,context , includes).FirstOrDefault();
            return item;

        }

        #region Dynamic Predicate
        public List<SDFile> GetBy(Expression<Func<SDFile, bool>> predicate, int? pageSize, int? page)
        {
            return this.GetBy(predicate, pageSize, page, null, null);
        }
        public List<SDFile> GetBy(Expression<Func<SDFile, bool>> predicate, ContextRequest contextRequest)
        {

            return GetBy(predicate, contextRequest,"");
        }
        
        public List<SDFile> GetBy(Expression<Func<SDFile, bool>> predicate, ContextRequest contextRequest, params Expression<Func<SDFile, object>>[] includes)
        {
            StringBuilder sb = new StringBuilder();
           if (includes != null)
            {
                foreach (var path in includes)
                {

						if (sb.Length > 0) sb.Append(",");
						sb.Append(SFSdotNet.Framework.Linq.Utils.IncludeToString<SDFile>(path));

               }
            }
            return GetBy(predicate, contextRequest, sb.ToString());
        }
        
        
        public List<SDFile> GetBy(Expression<Func<SDFile, bool>> predicate, string includes)
        {
			ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";

            return GetBy(predicate, context, includes);
        }

        public List<SDFile> GetBy(Expression<Func<SDFile, bool>> predicate, params Expression<Func<SDFile, object>>[] includes)
        {
			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest context = new ContextRequest();
			            context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";
            return GetBy(predicate, context, includes);
        }

      
		public bool DisableCache { get; set; }
		public List<SDFile> GetBy(Expression<Func<SDFile, bool>> predicate, ContextRequest contextRequest, string includes)
		{
            using (EFContext con = new EFContext()) {
				
				string fkIncludes = "";
                List<string> multilangProperties = new List<string>();
				if (predicate == null) predicate = PredicateBuilder.True<SDFile>();
                var notDeletedExpression = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;
					Expression<Func<SDFile,bool>> multitenantExpression  = null;
					if (contextRequest != null && contextRequest.Company != null)	                        	
						multitenantExpression = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicate, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression);

#region Old code
/*
				List<SDFile> result = null;
               BusinessRulesEventArgs<SDFile>  e = null;
	
				OnGetting(con, e = new BusinessRulesEventArgs<SDFile>() {  FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null) });

               // OnGetting(con,e = new BusinessRulesEventArgs<SDFile>() { FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = contextRequest.CustomQuery.FilterExpressionString});
				   if (e != null) {
				    predicate = e.FilterExpression;
						if (e.Cancel)
						{
							context = null;
							 if (e.Items == null) e.Items = new List<SDFile>();
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                if (predicate == null) predicate = PredicateBuilder.True<SDFile>();
                
                //var es = _repository.Queryable;

                IQueryable<SDFile> query =  con.SDFiles.AsQueryable();

                                if (!string.IsNullOrEmpty(includes))
                {
                    foreach (string include in includes.Split(char.Parse(",")))
                    {
						if (!string.IsNullOrEmpty(include))
                            query = query.Include(include);
                    }
                }
                    predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
					 	if (!preventSecurityRestrictions)
						{
							if (contextRequest != null )
		                    	if (contextRequest.User !=null )
		                        	if (contextRequest.Company != null){
		                        	
										predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
 									
									}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				query =query.AsExpandable().Where(predicate);
                query = ContextQueryBuilder<SDFile>.ApplyContextQuery(query, contextRequest);

                result = query.AsNoTracking().ToList<SDFile>();
				  
                if (e != null)
                {
                    e.Items = result;
                }
				//if (contextRequest != null ){
				//	 contextRequest = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
					contextRequest.CustomQuery = new CustomQuery();

				//}
				OnTaken(this, e == null ? e =  new BusinessRulesEventArgs<SDFile>() { Items= result, IncludingComputedLinq = false, ContextRequest = contextRequest,  FilterExpression = predicate } :  e);
  
			

                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
				*/
#endregion
            }
        }


		/*public int Update(List<SDFile> items, ContextRequest contextRequest)
            {
                int result = 0;
                using (EFContext con = new EFContext())
                {
                   
                

                    foreach (var item in items)
                    {
                        //secMessageToUser messageToUser = new secMessageToUser();
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            item.GetType().GetProperty(prop).SetValue(item, item.GetType().GetProperty(prop).GetValue(item));
                        }
                        //messageToUser.GuidMessageToUser = (Guid)item.GetType().GetProperty("GuidMessageToUser").GetValue(item);

                        var setObject = con.CreateObjectSet<SDFile>("SDFiles");
                        //messageToUser.Readed = DateTime.UtcNow;
                        setObject.Attach(item);
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            con.ObjectStateManager.GetObjectStateEntry(item).SetModifiedProperty(prop);
                        }
                       
                    }
                    result = con.SaveChanges();

                    


                }
                return result;
            }
           */
		

        public List<SDFile> GetBy(string predicateString, ContextRequest contextRequest, string includes)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
				


				string computedFields = "";
				string fkIncludes = "";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDFile>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					//if (contextRequest != null && contextRequest.Company != null)                      	
					//	 multitenantExpression = @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))";
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicateString, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression,computedFields);


	#region Old Code
	/*
				BusinessRulesEventArgs<SDFile> e = null;

				Filter filter = new Filter();
                if (predicateString.Contains("|"))
                {
                    string ft = GetSpecificFilter(predicateString, contextRequest);
                    if (!string.IsNullOrEmpty(ft))
                        filter.SetFilterPart("ft", ft);
                   
                    contextRequest.FreeText = predicateString.Split(char.Parse("|"))[1];
                    var q1 = predicateString.Split(char.Parse("|"))[0];
                    if (!string.IsNullOrEmpty(q1))
                    {
                        filter.ProcessText(q1);
                    }
                }
                else {
                    filter.ProcessText(predicateString);
                }
				 var includesList = (new List<string>());
                 if (!string.IsNullOrEmpty(includes))
                 {
                     includesList = includes.Split(char.Parse(",")).ToList();
                 }

				List<SDFile> result = new List<SDFile>();
         
			QueryBuild(predicateString, filter, con, contextRequest, "getby", includesList);
			 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }
				
				
					OnGetting(con, e == null ? e = new BusinessRulesEventArgs<SDFile>() { Filter = filter, ContextRequest = contextRequest  } : e );

                  //OnGetting(con,e = new BusinessRulesEventArgs<SDFile>() {  ContextRequest = contextRequest, FilterExpressionString = predicateString });
			   	if (e != null) {
				    //predicateString = e.GetQueryString();
						if (e.Cancel)
						{
							context = null;
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				//	 else {
                //      predicateString = predicateString.Replace("*extraFreeText*", "").Replace("()","");
                //  }
				//con.EnableChangeTrackingUsingProxies = false;
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                //if (predicate == null) predicate = PredicateBuilder.True<SDFile>();
                
                //var es = _repository.Queryable;
				IQueryable<SDFile> query = con.SDFiles.AsQueryable();
		
				// include relations FK
				if(string.IsNullOrEmpty(includes) ){
					includes ="";
				}
				StringBuilder sbQuerySystem = new StringBuilder();
                    //predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				

				//if (!string.IsNullOrEmpty(predicateString))
                //      sbQuerySystem.Append(" And ");
                //sbQuerySystem.Append(" (IsDeleted != true Or IsDeleted = null) ");
				 filter.SetFilterPart("de", "(IsDeleted != true OR IsDeleted = null)");


					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
	                    	if (contextRequest.User !=null )
	                        	if (contextRequest.Company != null ){
	                        		//if (sbQuerySystem.Length > 0)
	                        		//	    			sbQuerySystem.Append( " And ");	
									//sbQuerySystem.Append(@" (GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa

									filter.SetFilterPart("co",@"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))");

								}
						}	
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				//string predicateString = predicate.ToDynamicLinq<SDFile>();
				//predicateString += sbQuerySystem.ToString();
				filter.CleanAndProcess("");

				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed(); //SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicateString );               
                string predicateWithManyRelations = filter.GetFilterChildren(); //SFSdotNet.Framework.Linq.Utils.CleanPartExpression(predicateString);

                //QueryUtils.BreakeQuery1(predicateString, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
                var _queryable = query.AsQueryable();
				bool includeAll = true; 
                if (!string.IsNullOrEmpty(predicateWithManyRelations))
                    _queryable = _queryable.Where(predicateWithManyRelations, contextRequest.CustomQuery.ExtraParams);
				if (contextRequest.CustomQuery.SpecificProperties.Count > 0)
                {

				includeAll = false; 
                }

				StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append("new (");
                bool existPrev = false;
                foreach (var selected in contextRequest.CustomQuery.SelectedFields.Where(p=> !string.IsNullOrEmpty(p.Linq)))
                {
                    if (existPrev) sbSelect.Append(", ");
                    if (!selected.Linq.Contains(".") && !selected.Linq.StartsWith("it."))
                        sbSelect.Append("it." + selected.Linq);
                    else
                        sbSelect.Append(selected.Linq);
                    existPrev = true;
                }
                sbSelect.Append(")");
                var queryable = _queryable.Select(sbSelect.ToString());                    


     				
                 if (!string.IsNullOrEmpty(predicateWithFKAndComputed))
                    queryable = queryable.Where(predicateWithFKAndComputed, contextRequest.CustomQuery.ExtraParams);

				QueryComplementOptions queryOps = ContextQueryBuilder.ApplyContextQuery(contextRequest);
            	if (!string.IsNullOrEmpty(queryOps.OrderByAndSort)){
					if (queryOps.OrderBy.Contains(".") && !queryOps.OrderBy.StartsWith("it.")) queryOps.OrderBy = "it." + queryOps.OrderBy;
					queryable = queryable.OrderBy(queryOps.OrderByAndSort);
					}
               	if (queryOps.Skip != null)
                {
                    queryable = queryable.Skip(queryOps.Skip.Value);
                }
                if (queryOps.PageSize != null)
                {
                    queryable = queryable.Take (queryOps.PageSize.Value);
                }


                var resultTemp = queryable.AsQueryable().ToListAsync().Result;
                foreach (var item in resultTemp)
                {

				   result.Add(SFSdotNet.Framework.BR.Utils.GetConverted<SDFile,dynamic>(item, contextRequest.CustomQuery.SelectedFields.Select(p=>p.Name).ToArray()));
                }

			 if (e != null)
                {
                    e.Items = result;
                }
				 contextRequest.CustomQuery = new CustomQuery();
				OnTaken(this, e == null ? e = new BusinessRulesEventArgs<SDFile>() { Items= result, IncludingComputedLinq = true, ContextRequest = contextRequest, FilterExpressionString  = predicateString } :  e);
  
			
  
                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
	
	*/
	#endregion

            }
        }
		public SDFile GetFromOperation(string function, string filterString, string usemode, string fields, ContextRequest contextRequest)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
                string computedFields = "";
               // string fkIncludes = "accContpaqiClassification,accProjectConcept,accProjectType,accProxyUser";
                List<string> multilangProperties = new List<string>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					if (contextRequest != null && contextRequest.Company != null)
					{
						multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
						contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
					}
					 									
					string multiTenantField = "GuidCompany";


                return GetSummaryOperation(con, new SDFile(), function, filterString, usemode, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields, contextRequest, fields.Split(char.Parse(",")).ToArray());
            }
        }

   protected override void QueryBuild(string predicate, Filter filter, DbContext efContext, ContextRequest contextRequest, string method, List<string> includesList)
      	{
				if (contextRequest.CustomQuery.SpecificProperties.Count == 0)
                {
					contextRequest.CustomQuery.SpecificProperties.Add(SDFile.PropertyNames.FileName);
					contextRequest.CustomQuery.SpecificProperties.Add(SDFile.PropertyNames.FileType);
					contextRequest.CustomQuery.SpecificProperties.Add(SDFile.PropertyNames.FileSize);
					if (includesList.Contains(SDFile.PropertyNames.FileData))
					    contextRequest.CustomQuery.SpecificProperties.Add(SDFile.PropertyNames.FileData);
					
					contextRequest.CustomQuery.SpecificProperties.Add(SDFile.PropertyNames.StorageLocation);
					contextRequest.CustomQuery.SpecificProperties.Add(SDFile.PropertyNames.GuidCompany);
					contextRequest.CustomQuery.SpecificProperties.Add(SDFile.PropertyNames.CreatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDFile.PropertyNames.UpdatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDFile.PropertyNames.CreatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDFile.PropertyNames.UpdatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDFile.PropertyNames.Bytes);
					contextRequest.CustomQuery.SpecificProperties.Add(SDFile.PropertyNames.IsDeleted);
                    
				}

				if (method == "getby" || method == "sum")
				{
					if (!contextRequest.CustomQuery.SpecificProperties.Contains("GuidFile")){
						contextRequest.CustomQuery.SpecificProperties.Add("GuidFile");
					}

					 if (!string.IsNullOrEmpty(contextRequest.CustomQuery.OrderBy))
					{
						string existPropertyOrderBy = contextRequest.CustomQuery.OrderBy;
						if (contextRequest.CustomQuery.OrderBy.Contains("."))
						{
							existPropertyOrderBy = contextRequest.CustomQuery.OrderBy.Split(char.Parse("."))[0];
						}
						if (!contextRequest.CustomQuery.SpecificProperties.Exists(p => p == existPropertyOrderBy))
						{
							contextRequest.CustomQuery.SpecificProperties.Add(existPropertyOrderBy);
						}
					}

				}
				
	bool isFullDetails = contextRequest.IsFromUI("SDFiles", UIActions.GetForDetails);
	string filterForTest = predicate  + filter.GetFilterComplete();

				if (isFullDetails || !string.IsNullOrEmpty(predicate))
            {
            } 

			if (method == "sum")
            {
            } 
			if (contextRequest.CustomQuery.SelectedFields.Count == 0)
            {
				foreach (var selected in contextRequest.CustomQuery.SpecificProperties)
                {
					string linq = selected;
					switch (selected)
                    {

					 
						
					 default:
                            break;
                    }
					contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name=selected, Linq=linq});
					if (method == "getby" || method == "sum")
					{
						if (includesList.Contains(selected))
							includesList.Remove(selected);

					}

				}
			}
				if (method == "getby" || method == "sum")
				{
					foreach (var otherInclude in includesList.Where(p=> !string.IsNullOrEmpty(p)))
					{
						contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name = otherInclude, Linq = "it." + otherInclude +" as " + otherInclude });
					}
				}
				BusinessRulesEventArgs<SDFile> e = null;
				if (contextRequest.PreventInterceptors == false)
					OnQuerySettings(efContext, e = new BusinessRulesEventArgs<SDFile>() { Filter = filter, ContextRequest = contextRequest /*, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null)*/ });

				//List<SDFile> result = new List<SDFile>();
                 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }

}
		public List<SDFile> GetBy(Expression<Func<SDFile, bool>> predicate, bool loadRelations, ContextRequest contextRequest)
        {
			if(!loadRelations)
				return GetBy(predicate, contextRequest);
			else
				return GetBy(predicate, contextRequest, "SDCaseFiles,SDCaseHistoryFiles");

        }

        public List<SDFile> GetBy(Expression<Func<SDFile, bool>> predicate, int? pageSize, int? page, string orderBy, SFSdotNet.Framework.Data.SortDirection? sortDirection)
        {
            return GetBy(predicate, new ContextRequest() { CustomQuery = new CustomQuery() { Page = page, PageSize = pageSize, OrderBy = orderBy, SortDirection = sortDirection } });
        }
        public List<SDFile> GetBy(Expression<Func<SDFile, bool>> predicate)
        {

			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
			contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
			            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            contextRequest.CustomQuery.FilterExpressionString = null;
            return this.GetBy(predicate, contextRequest, "");
        }
        #endregion
        #region Dynamic String
		protected override string GetSpecificFilter(string filter, ContextRequest contextRequest) {
            string result = "";
		    //string linqFilter = String.Empty;
            string freeTextFilter = String.Empty;
            if (filter.Contains("|"))
            {
               // linqFilter = filter.Split(char.Parse("|"))[0];
                freeTextFilter = filter.Split(char.Parse("|"))[1];
            }
            //else {
            //    freeTextFilter = filter;
            //}
            //else {
            //    linqFilter = filter;
            //}
			// linqFilter = SFSdotNet.Framework.Linq.Utils.ReplaceCustomDateFilters(linqFilter);
            //string specificFilter = linqFilter;
            if (!string.IsNullOrEmpty(freeTextFilter))
            {
                System.Text.StringBuilder sbCont = new System.Text.StringBuilder();
                /*if (specificFilter.Length > 0)
                {
                    sbCont.Append(" AND ");
                    sbCont.Append(" ({0})");
                }
                else
                {
                    sbCont.Append("{0}");
                }*/
                //var words = freeTextFilter.Split(char.Parse(" "));
				var word = freeTextFilter;
                System.Text.StringBuilder sbSpec = new System.Text.StringBuilder();
                 int nWords = 1;
				/*foreach (var word in words)
                {
					if (word.Length > 0){
                    if (sbSpec.Length > 0) sbSpec.Append(" AND ");
					if (words.Length > 1) sbSpec.Append("("); */
					
	
					
					
					
									
					sbSpec.Append(string.Format(@"FileName.Contains(""{0}"")", word));
					

					
					
										sbSpec.Append(" OR ");
					
									
					sbSpec.Append(string.Format(@"FileType.Contains(""{0}"")", word));
					

					
	
					
					
										sbSpec.Append(" OR ");
					
									
					sbSpec.Append(string.Format(@"StorageLocation.Contains(""{0}"")", word));
					

					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
								 //sbSpec.Append("*extraFreeText*");

                    /*if (words.Length > 1) sbSpec.Append(")");
					
					nWords++;

					}

                }*/
                //specificFilter = string.Format("{0}{1}", specificFilter, string.Format(sbCont.ToString(), sbSpec.ToString()));
                                 result = sbSpec.ToString();  
            }
			//result = specificFilter;
			
			return result;

		}
	
			public List<SDFile> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params object[] extraParams)
        {
			return GetBy(filter, pageSize, page, orderBy, orderDir,  null, extraParams);
		}
           public List<SDFile> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, string usemode, params object[] extraParams)
            { 
                return GetBy(filter, pageSize, page, orderBy, orderDir, usemode, null, extraParams);
            }


		public List<SDFile> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  string usemode, ContextRequest context, params object[] extraParams)

        {

            // string freetext = null;
            //if (filter.Contains("|"))
            //{
            //    int parts = filter.Split(char.Parse("|")).Count();
            //    if (parts > 1)
            //    {

            //        freetext = filter.Split(char.Parse("|"))[1];
            //    }
            //}
		
            //string specificFilter = "";
            //if (!string.IsNullOrEmpty(filter))
            //  specificFilter=  GetSpecificFilter(filter);
            if (string.IsNullOrEmpty(orderBy))
            {
			                orderBy = "UpdatedDate";
            }
			//orderDir = "desc";
			SFSdotNet.Framework.Data.SortDirection direction = SFSdotNet.Framework.Data.SortDirection.Ascending;
            if (!string.IsNullOrEmpty(orderDir))
            {
                if (orderDir == "desc")
                    direction = SFSdotNet.Framework.Data.SortDirection.Descending;
            }
            if (context == null)
                context = new ContextRequest();
			

             context.UseMode = usemode;
             if (context.CustomQuery == null )
                context.CustomQuery =new SFSdotNet.Framework.My.CustomQuery();

 
                context.CustomQuery.ExtraParams = extraParams;

                    context.CustomQuery.OrderBy = orderBy;
                   context.CustomQuery.SortDirection = direction;
                   context.CustomQuery.Page = page;
                  context.CustomQuery.PageSize = pageSize;
               

            

            if (!preventSecurityRestrictions) {
			 if (context.CurrentContext == null)
                {
					if (SFSdotNet.Framework.My.Context.CurrentContext != null &&  SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
					{
						context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
						context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

					}
					else {
						throw new Exception("The security rule require a specific user and company");
					}
				}
            }
            return GetBy(filter, context);
  
        }


        public List<SDFile> GetBy(string strWhere, ContextRequest contextRequest)
        {
        	#region old code
				
				 //Expression<Func<tvsReservationTransport, bool>> predicate = null;
				string strWhereClean = strWhere.Replace("*extraFreeText*", "").Replace("()", "");
                //if (!string.IsNullOrEmpty(strWhereClean)){

                //    object[] extraParams = null;
                //    //if (contextRequest != null )
                //    //    if (contextRequest.CustomQuery != null )
                //    //        extraParams = contextRequest.CustomQuery.ExtraParams;
                //    //predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<tvsReservationTransport, bool>(strWhereClean, extraParams != null? extraParams.Cast<Guid>(): null);				
                //}
				 if (contextRequest == null)
                {
                    contextRequest = new ContextRequest();
                    if (contextRequest.CustomQuery == null)
                        contextRequest.CustomQuery = new CustomQuery();
                }
                  if (!preventSecurityRestrictions) {
					if (contextRequest.User == null || contextRequest.Company == null)
                      {
                     if (SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
                     {
                         contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                         contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

                     }
                     else {
                         throw new Exception("The security rule require a specific User and Company ");
                     }
					 }
                 }
            contextRequest.CustomQuery.FilterExpressionString = strWhere;
				//return GetBy(predicate, contextRequest);  

			#endregion				
				
                    return GetBy(strWhere, contextRequest, "");  


        }
       public List<SDFile> GetBy(string strWhere)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
			
            return GetBy(strWhere, context, null);
        }

        public List<SDFile> GetBy(string strWhere, string includes)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
            return GetBy(strWhere, context, includes);
        }

        #endregion
        #endregion
		
		  #region SaveOrUpdate
        
 		 public SDFile Create(SDFile entity)
        {
				//ObjectContext context = null;
				    if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: Create");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

				return this.Create(entity, contextRequest);


        }
        
       
        public SDFile Create(SDFile entity, ContextRequest contextRequest)
        {
		
		bool graph = false;
	
				bool preventPartial = false;
                if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
               
			using (EFContext con = new EFContext()) {

				SDFile itemForSave = new SDFile();
#region Autos
		if(!preventSecurityRestrictions){

				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion
               BusinessRulesEventArgs<SDFile> e = null;
			    if (preventPartial == false )
                OnCreating(this,e = new BusinessRulesEventArgs<SDFile>() { ContextRequest = contextRequest, Item=entity });
				   if (e != null) {
						if (e.Cancel)
						{
							context = null;
							return e.Item;

						}
					}

                    if (entity.GuidFile == Guid.Empty)
                   {
                       entity.GuidFile = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   itemForSave.GuidFile = entity.GuidFile;
				  
		
			itemForSave.GuidFile = entity.GuidFile;

			itemForSave.FileName = entity.FileName;

			itemForSave.FileType = entity.FileType;

			itemForSave.FileSize = entity.FileSize;

			itemForSave.FileData = entity.FileData;

			itemForSave.StorageLocation = entity.StorageLocation;

			itemForSave.GuidCompany = entity.GuidCompany;

			itemForSave.CreatedDate = entity.CreatedDate;

			itemForSave.UpdatedDate = entity.UpdatedDate;

			itemForSave.CreatedBy = entity.CreatedBy;

			itemForSave.UpdatedBy = entity.UpdatedBy;

			itemForSave.Bytes = entity.Bytes;

			itemForSave.IsDeleted = entity.IsDeleted;

				
				con.SDFiles.Add(itemForSave);






                
				con.ChangeTracker.Entries().Where(p => p.Entity != itemForSave && p.State != EntityState.Unchanged).ForEach(p => p.State = EntityState.Detached);

				con.Entry<SDFile>(itemForSave).State = EntityState.Added;

				con.SaveChanges();

					 
				

				//itemResult = entity;
                //if (e != null)
                //{
                 //   e.Item = itemResult;
                //}
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false )
                OnCreated(this, e == null ? e = new BusinessRulesEventArgs<SDFile>() { ContextRequest = contextRequest, Item = entity } : e);



                if (e != null && e.Item != null )
                {
                    return e.Item;
                }
                              return entity;
			}
            
        }
        //BusinessRulesEventArgs<SDFile> e = null;
        public void Create(List<SDFile> entities)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            Create(entities, contextRequest);
        }
        public void Create(List<SDFile> entities, ContextRequest contextRequest)
        
        {
			ObjectContext context = null;
            	foreach (SDFile entity in entities)
				{
					this.Create(entity, contextRequest);
				}
        }
		  public void CreateOrUpdateBulk(List<SDFile> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "cu", contextRequest);
        }

        private void CreateOrUpdateBulk(List<SDFile> entities, string actionKey, ContextRequest contextRequest)
        {
			if (entities.Count() > 0){
            bool graph = false;

            bool preventPartial = false;
            if (contextRequest != null && contextRequest.PreventInterceptors == true)
            {
                preventPartial = true;
            }
            foreach (var entity in entities)
            {
                    if (entity.GuidFile == Guid.Empty)
                   {
                       entity.GuidFile = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   
				  


#region Autos
		if(!preventSecurityRestrictions){


 if (actionKey != "u")
                        {
				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;


}
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion


		
			//entity.GuidFile = entity.GuidFile;

			//entity.FileName = entity.FileName;

			//entity.FileType = entity.FileType;

			//entity.FileSize = entity.FileSize;

			//entity.FileData = entity.FileData;

			//entity.StorageLocation = entity.StorageLocation;

			//entity.GuidCompany = entity.GuidCompany;

			//entity.CreatedDate = entity.CreatedDate;

			//entity.UpdatedDate = entity.UpdatedDate;

			//entity.CreatedBy = entity.CreatedBy;

			//entity.UpdatedBy = entity.UpdatedBy;

			//entity.Bytes = entity.Bytes;

			//entity.IsDeleted = entity.IsDeleted;

				
				






                
				

					 
				

				//itemResult = entity;
            }
            using (EFContext con = new EFContext())
            {
                 if (actionKey == "c")
                    {
                        context.BulkInsert(entities);
                    }else if ( actionKey == "u")
                    {
                        context.BulkUpdate(entities);
                    }else
                    {
                        context.BulkInsertOrUpdate(entities);
                    }
            }

			}
        }
	
		public void CreateBulk(List<SDFile> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "c", contextRequest);
        }


		public void UpdateAgile(SDFile item, params string[] fields)
         {
			UpdateAgile(item, null, fields);
        }
		public void UpdateAgile(SDFile item, ContextRequest contextRequest, params string[] fields)
         {
            
             ContextRequest contextNew = null;
             if (contextRequest != null)
             {
                 contextNew = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
                 if (fields != null && fields.Length > 0)
                 {
                     contextNew.CustomQuery.SpecificProperties  = fields.ToList();
                 }
                 else if(contextRequest.CustomQuery.SpecificProperties.Count > 0)
                 {
                     fields = contextRequest.CustomQuery.SpecificProperties.ToArray();
                 }
             }
			

		   using (EFContext con = new EFContext())
            {



               
					List<string> propForCopy = new List<string>();
                    propForCopy.AddRange(fields);
                    
					  
					if (!propForCopy.Contains("GuidFile"))
						propForCopy.Add("GuidFile");
					if (!propForCopy.Contains("FileName"))
						propForCopy.Add("FileName");

					var itemForUpdate = SFSdotNet.Framework.BR.Utils.GetConverted<SDFile,SDFile>(item, propForCopy.ToArray());
					 itemForUpdate.GuidFile = item.GuidFile;
                  var setT = con.Set<SDFile>().Attach(itemForUpdate);

					if (fields.Count() > 0)
					  {
						  item.ModifiedProperties = fields;
					  }
                    foreach (var property in item.ModifiedProperties)
					{						
                        if (property != "GuidFile")
                             con.Entry(setT).Property(property).IsModified = true;

                    }

                
               int result = con.SaveChanges();
               if (result != 1)
               {
                   SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: 1");
               }


            }

			OnUpdatedAgile(this, new BusinessRulesEventArgs<SDFile>() { Item = item, ContextRequest = contextNew  });

         }
		public void UpdateBulk(List<SDFile>  items, params string[] fields)
         {
             SFSdotNet.Framework.My.ContextRequest req = new SFSdotNet.Framework.My.ContextRequest();
             req.CustomQuery = new SFSdotNet.Framework.My.CustomQuery();
             foreach (var field in fields)
             {
                 req.CustomQuery.SpecificProperties.Add(field);
             }
             UpdateBulk(items, req);

         }

		 public void DeleteBulk(List<SDFile> entities, ContextRequest contextRequest = null)
        {

            using (EFContext con = new EFContext())
            {
                foreach (var entity in entities)
                {
					var entityProxy = new SDFile() { GuidFile = entity.GuidFile };

                    con.Entry<SDFile>(entityProxy).State = EntityState.Deleted;

                }

                int result = con.SaveChanges();
                if (result != entities.Count)
                {
                    SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: " + entities.Count.ToString());
                }
            }

        }

        public void UpdateBulk(List<SDFile> items, ContextRequest contextRequest)
        {
            if (items.Count() > 0){

			 foreach (var entity in items)
            {


#region Autos
		if(!preventSecurityRestrictions){

				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	



			}
#endregion







				}
				using (EFContext con = new EFContext())
				{

                    
                
                   con.BulkUpdate(items);

				}
             
			}	  
        }

         public SDFile Update(SDFile entity)
        {
            if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return Update(entity, contextRequest);
        }
       
         public SDFile Update(SDFile entity, ContextRequest contextRequest)
        {
		 if ((System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null) && contextRequest == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Update");
            }
            if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            }

			
				SDFile  itemResult = null;

	
			//entity.UpdatedDate = DateTime.Now.ToUniversalTime();
			//if(contextRequest.User != null)
				//entity.UpdatedBy = contextRequest.User.GuidUser;

//	    var oldentity = GetBy(p => p.GuidFile == entity.GuidFile, contextRequest).FirstOrDefault();
	//	if (oldentity != null) {
		
          //  entity.CreatedDate = oldentity.CreatedDate;
    //        entity.CreatedBy = oldentity.CreatedBy;
	
      //      entity.GuidCompany = oldentity.GuidCompany;
	
			

	
		//}

			 using( EFContext con = new EFContext()){
				BusinessRulesEventArgs<SDFile> e = null;
				bool preventPartial = false; 
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false)
                OnUpdating(this,e = new BusinessRulesEventArgs<SDFile>() { ContextRequest = contextRequest, Item=entity});
				   if (e != null) {
						if (e.Cancel)
						{
							//outcontext = null;
							return e.Item;

						}
					}

	string includes = "";
	IQueryable < SDFile > query = con.SDFiles.AsQueryable();
	foreach (string include in includes.Split(char.Parse(",")))
                       {
                           if (!string.IsNullOrEmpty(include))
                               query = query.Include(include);
                       }
	var oldentity = query.FirstOrDefault(p => p.GuidFile == entity.GuidFile);
	if (oldentity.FileName != entity.FileName)
		oldentity.FileName = entity.FileName;
	if (oldentity.FileType != entity.FileType)
		oldentity.FileType = entity.FileType;
	if (oldentity.FileSize != entity.FileSize)
		oldentity.FileSize = entity.FileSize;
	if (oldentity.FileData != entity.FileData)
		oldentity.FileData = entity.FileData;
	if (oldentity.StorageLocation != entity.StorageLocation)
		oldentity.StorageLocation = entity.StorageLocation;

				//if (entity.UpdatedDate == null || (contextRequest != null && contextRequest.IsFromUI("SDFiles", UIActions.Updating)))
			oldentity.UpdatedDate = DateTime.Now.ToUniversalTime();
			if(contextRequest.User != null)
				oldentity.UpdatedBy = contextRequest.User.GuidUser;

           


				if (entity.SDCaseFiles != null)
                {
                    foreach (var item in entity.SDCaseFiles)
                    {


                        
                    }
					
                    

                }


				if (entity.SDCaseHistoryFiles != null)
                {
                    foreach (var item in entity.SDCaseHistoryFiles)
                    {


                        
                    }
					
                    

                }


				con.ChangeTracker.Entries().Where(p => p.Entity != oldentity).ForEach(p => p.State = EntityState.Unchanged);  
				  
				con.SaveChanges();
        
					 
					
               
				itemResult = entity;
				if(preventPartial == false)
					OnUpdated(this, e = new BusinessRulesEventArgs<SDFile>() { ContextRequest = contextRequest, Item=itemResult });

              	return itemResult;
			}
			  
        }
        public SDFile Save(SDFile entity)
        {
			return Create(entity);
        }
        public int Save(List<SDFile> entities)
        {
			 Create(entities);
            return entities.Count;

        }
        #endregion
        #region Delete
        public void Delete(SDFile entity)
        {
				this.Delete(entity, null);
			
        }
		 public void Delete(SDFile entity, ContextRequest contextRequest)
        {
				
				  List<SDFile> entities = new List<SDFile>();
				   entities.Add(entity);
				this.Delete(entities, contextRequest);
			
        }

         public void Delete(string query, Guid[] guids, ContextRequest contextRequest)
        {
			var br = new SDFilesBR(true);
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);
            
            Delete(items, contextRequest);

        }
        public void Delete(SDFile entity,  ContextRequest contextRequest, BusinessRulesEventArgs<SDFile> e = null)
        {
			
				using(EFContext con = new EFContext())
                 {
				
               	BusinessRulesEventArgs<SDFile> _e = null;
               List<SDFile> _items = new List<SDFile>();
                _items.Add(entity);
                if (e == null || e.PreventPartialPropagate == false)
                {
                    OnDeleting(this, _e = (e == null ? new BusinessRulesEventArgs<SDFile>() { ContextRequest = contextRequest, Item = entity, Items = null  } : e));
                }
                if (_e != null)
                {
                    if (_e.Cancel)
						{
							context = null;
							return;

						}
					}


				
									//IsDeleted
					bool logicDelete = true;
					if (entity.IsDeleted != null)
					{
						if (entity.IsDeleted.Value)
							logicDelete = false;
					}
					if (logicDelete)
					{
											//entity = GetBy(p =>, contextRequest).FirstOrDefault();
						entity.IsDeleted = true;
						if (contextRequest != null && contextRequest.User != null)
							entity.UpdatedBy = contextRequest.User.GuidUser;
                        entity.UpdatedDate = DateTime.UtcNow;
						UpdateAgile(entity, "IsDeleted","UpdatedBy","UpdatedDate");

						
					}
					else {
					con.Entry<SDFile>(entity).State = EntityState.Deleted;
					con.SaveChanges();
				
				 
					}
								
				
				 
					
					
			if (e == null || e.PreventPartialPropagate == false)
                {

                    if (_e == null)
                        _e = new BusinessRulesEventArgs<SDFile>() { ContextRequest = contextRequest, Item = entity, Items = null };

                    OnDeleted(this, _e);
                }

				//return null;
			}
        }
 public void UnDelete(string query, Guid[] guids, ContextRequest contextRequest)
        {
            var br = new SDFilesBR(true);
            contextRequest.CustomQuery.IncludeDeleted = true;
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);

            foreach (var item in items)
            {
                item.IsDeleted = false;
						if (contextRequest != null && contextRequest.User != null)
							item.UpdatedBy = contextRequest.User.GuidUser;
                        item.UpdatedDate = DateTime.UtcNow;
            }

            UpdateBulk(items, "IsDeleted","UpdatedBy","UpdatedDate");
        }

         public void Delete(List<SDFile> entities,  ContextRequest contextRequest = null )
        {
				
			 BusinessRulesEventArgs<SDFile> _e = null;

                OnDeleting(this, _e = new BusinessRulesEventArgs<SDFile>() { ContextRequest = contextRequest, Item = null, Items = entities });
                if (_e != null)
                {
                    if (_e.Cancel)
                    {
                        context = null;
                        return;

                    }
                }
                bool allSucced = true;
                BusinessRulesEventArgs<SDFile> eToChilds = new BusinessRulesEventArgs<SDFile>();
                if (_e != null)
                {
                    eToChilds = _e;
                }
                else
                {
                    eToChilds = new BusinessRulesEventArgs<SDFile>() { ContextRequest = contextRequest, Item = (entities.Count == 1 ? entities[0] : null), Items = entities };
                }
				foreach (SDFile item in entities)
				{
					try
                    {
                        this.Delete(item, contextRequest, e: eToChilds);
                    }
                    catch (Exception ex)
                    {
                        SFSdotNet.Framework.My.EventLog.Error(ex);
                        allSucced = false;
                    }
				}
				if (_e == null)
                    _e = new BusinessRulesEventArgs<SDFile>() { ContextRequest = contextRequest, CountResult = entities.Count, Item = null, Items = entities };
                OnDeleted(this, _e);

			
        }
        #endregion
 
        #region GetCount
		 public int GetCount(Expression<Func<SDFile, bool>> predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

			return GetCount(predicate, contextRequest);
		}
        public int GetCount(Expression<Func<SDFile, bool>> predicate, ContextRequest contextRequest)
        {


		
		 using (EFContext con = new EFContext())
            {


				if (predicate == null) predicate = PredicateBuilder.True<SDFile>();
           		predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted == null);
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    		if (contextRequest.User !=null )
                        		if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
									predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa

								}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				
				IQueryable<SDFile> query = con.SDFiles.AsQueryable();
                return query.AsExpandable().Count(predicate);

			
				}
			

        }
		  public int GetCount(string predicate,  ContextRequest contextRequest)
         {
             return GetCount(predicate, null, contextRequest);
         }

         public int GetCount(string predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return GetCount(predicate, contextRequest);
        }
		 public int GetCount(string predicate, string usemode){
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
				return GetCount( predicate,  usemode,  contextRequest);
		 }
        public int GetCount(string predicate, string usemode, ContextRequest contextRequest){

		using (EFContext con = new EFContext()) {
				string computedFields = "";
				string fkIncludes = "";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDFile>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetCount(con, predicate, usemode, contextRequest, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields);

			}
			#region old code
			 /* string freetext = null;
            Filter filter = new Filter();

              if (predicate.Contains("|"))
              {
                 
                  filter.SetFilterPart("ft", GetSpecificFilter(predicate, contextRequest));
                 
                  filter.ProcessText(predicate.Split(char.Parse("|"))[0]);
                  freetext = predicate.Split(char.Parse("|"))[1];

				  if (!string.IsNullOrEmpty(freetext) && string.IsNullOrEmpty(contextRequest.FreeText))
                  {
                      contextRequest.FreeText = freetext;
                  }
              }
              else {
                  filter.ProcessText(predicate);
              }
			   predicate = filter.GetFilterComplete();
			// BusinessRulesEventArgs<SDFile>  e = null;
           	using (EFContext con = new EFContext())
			{
			
			

			 QueryBuild(predicate, filter, con, contextRequest, "count", new List<string>());


			
			BusinessRulesEventArgs<SDFile> e = null;

			contextRequest.FreeText = freetext;
			contextRequest.UseMode = usemode;
            OnCounting(this, e = new BusinessRulesEventArgs<SDFile>() {  Filter =filter, ContextRequest = contextRequest });
            if (e != null)
            {
                if (e.Cancel)
                {
                    context = null;
                    return e.CountResult;

                }

            

            }
			
			StringBuilder sbQuerySystem = new StringBuilder();
		
					
                    filter.SetFilterPart("de","(IsDeleted != true OR IsDeleted == null)");
			
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    	if (contextRequest.User !=null )
                        	if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
                        		
								filter.SetFilterPart("co", @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa
						
						
							}
							
							}
							if (preventSecurityRestrictions) preventSecurityRestrictions= false;
		
				   
                 filter.CleanAndProcess("");
				//string predicateWithFKAndComputed = SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicate );               
				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed();
               string predicateWithManyRelations = filter.GetFilterChildren();
			   ///QueryUtils.BreakeQuery1(predicate, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
			   predicate = filter.GetFilterComplete();
               if (!string.IsNullOrEmpty(predicate))
               {
				
					
                    return con.SDFiles.Where(predicate).Count();
					
                }else
                    return con.SDFiles.Count();
					
			}*/
			#endregion

		}
         public int GetCount()
        {
            return GetCount(p => true);
        }
        #endregion
        
         


        public void Delete(List<SDFile.CompositeKey> entityKeys)
        {

            List<SDFile> items = new List<SDFile>();
            foreach (var itemKey in entityKeys)
            {
                items.Add(GetByKey(itemKey.GuidFile));
            }

            Delete(items);

        }
		 public void UpdateAssociation(string relation, string relationValue, string query, Guid[] ids, ContextRequest contextRequest)
        {
            var items = GetBy(query, null, null, null, null, null, contextRequest, ids);
			 var module = SFSdotNet.Framework.Cache.Caching.SystemObjects.GetModuleByKey(SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(System.Web.HttpContext.Current.Request.RequestContext, "area"));
           
            foreach (var item in items)
            {
			  Guid ? guidRelationValue = null ;
                if (!string.IsNullOrEmpty(relationValue)){
                    guidRelationValue = Guid.Parse(relationValue );
                }

				 if (relation.Contains("."))
                {
                    var partsWithOtherProp = relation.Split(char.Parse("|"));
                    var parts = partsWithOtherProp[0].Split(char.Parse("."));

                    string proxyRelName = parts[0];
                    string proxyProperty = parts[1];
                    string proxyPropertyKeyNameFromOther = partsWithOtherProp[1];
                    //string proxyPropertyThis = parts[2];

                    var prop = item.GetType().GetProperty(proxyRelName);
                    //var entityInfo = //SFSdotNet.Framework.
                    // descubrir el tipo de entidad dentro de la colección
                    Type typeEntityInList = SFSdotNet.Framework.Entities.Utils.GetTypeFromList(prop);
                    var newProxyItem = Activator.CreateInstance(typeEntityInList);
                    var propThisForSet = newProxyItem.GetType().GetProperty(proxyProperty);
                    var entityInfoOfProxy = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(typeEntityInList);
                    var propOther = newProxyItem.GetType().GetProperty(proxyPropertyKeyNameFromOther);

                    if (propThisForSet != null && entityInfoOfProxy != null && propOther != null )
                    {
                        var entityInfoThis = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(item.GetType());
                        var valueThisId = item.GetType().GetProperty(entityInfoThis.PropertyKeyName).GetValue(item);
                        if (valueThisId != null)
                            propThisForSet.SetValue(newProxyItem, valueThisId);
                        propOther.SetValue(newProxyItem, Guid.Parse(relationValue));
                        
                        var entityNameProp = newProxyItem.GetType().GetField("EntityName").GetValue(null);
                        var entitySetNameProp = newProxyItem.GetType().GetField("EntitySetName").GetValue(null);

                        SFSdotNet.Framework.Apps.Integration.CreateItemFromApp(entityNameProp.ToString(), entitySetNameProp.ToString(), module.ModuleNamespace, newProxyItem, contextRequest);

                    }

                    // crear una instancia del tipo de entidad
                    // llenar los datos y registrar nuevo


                }
                else
                {
                var prop = item.GetType().GetProperty(relation);
                var entityInfo = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(prop.PropertyType);
                if (entityInfo != null)
                {
                    var ins = Activator.CreateInstance(prop.PropertyType);
                   if (guidRelationValue != null)
                    {
                        prop.PropertyType.GetProperty(entityInfo.PropertyKeyName).SetValue(ins, guidRelationValue);
                        item.GetType().GetProperty(relation).SetValue(item, ins);
                    }
                    else
                    {
                        item.GetType().GetProperty(relation).SetValue(item, null);
                    }

                    Update(item, contextRequest);
                }

				}
            }
        }
		
	}
		public partial class SDOrganizationsBR:BRBase<SDOrganization>{
	 	
           
		 #region Partial methods

           partial void OnUpdating(object sender, BusinessRulesEventArgs<SDOrganization> e);

            partial void OnUpdated(object sender, BusinessRulesEventArgs<SDOrganization> e);
			partial void OnUpdatedAgile(object sender, BusinessRulesEventArgs<SDOrganization> e);

            partial void OnCreating(object sender, BusinessRulesEventArgs<SDOrganization> e);
            partial void OnCreated(object sender, BusinessRulesEventArgs<SDOrganization> e);

            partial void OnDeleting(object sender, BusinessRulesEventArgs<SDOrganization> e);
            partial void OnDeleted(object sender, BusinessRulesEventArgs<SDOrganization> e);

            partial void OnGetting(object sender, BusinessRulesEventArgs<SDOrganization> e);
            protected override void OnVirtualGetting(object sender, BusinessRulesEventArgs<SDOrganization> e)
            {
                OnGetting(sender, e);
            }
			protected override void OnVirtualCounting(object sender, BusinessRulesEventArgs<SDOrganization> e)
            {
                OnCounting(sender, e);
            }
			partial void OnTaken(object sender, BusinessRulesEventArgs<SDOrganization> e);
			protected override void OnVirtualTaken(object sender, BusinessRulesEventArgs<SDOrganization> e)
            {
                OnTaken(sender, e);
            }

            partial void OnCounting(object sender, BusinessRulesEventArgs<SDOrganization> e);
 
			partial void OnQuerySettings(object sender, BusinessRulesEventArgs<SDOrganization> e);
          
            #endregion
			
		private static SDOrganizationsBR singlenton =null;
				public static SDOrganizationsBR NewInstance(){
					return  new SDOrganizationsBR();
					
				}
		public static SDOrganizationsBR Instance{
			get{
				if (singlenton == null)
					singlenton = new SDOrganizationsBR();
				return singlenton;
			}
		}
		//private bool preventSecurityRestrictions = false;
		 public bool PreventAuditTrail { get; set;  }
		#region Fields
        EFContext context = null;
        #endregion
        #region Constructor
        public SDOrganizationsBR()
        {
            context = new EFContext();
        }
		 public SDOrganizationsBR(bool preventSecurity)
            {
                this.preventSecurityRestrictions = preventSecurity;
				context = new EFContext();
            }
        #endregion
		
		#region Get

 		public IQueryable<SDOrganization> Get()
        {
            using (EFContext con = new EFContext())
            {
				
				var query = con.SDOrganizations.AsQueryable();
                con.Configuration.ProxyCreationEnabled = false;

                //query = ContextQueryBuilder<Nutrient>.ApplyContextQuery(query, contextRequest);

                return query;




            }

        }
		


 	
		public List<SDOrganization> GetAll()
        {
            return this.GetBy(p => true);
        }
        public List<SDOrganization> GetAll(string includes)
        {
            return this.GetBy(p => true, includes);
        }
        public SDOrganization GetByKey(Guid guidOrganization)
        {
            return GetByKey(guidOrganization, true);
        }
        public SDOrganization GetByKey(Guid guidOrganization, bool loadIncludes)
        {
            SDOrganization item = null;
			var query = PredicateBuilder.True<SDOrganization>();
                    
			string strWhere = @"GuidOrganization = Guid(""" + guidOrganization.ToString()+@""")";
            Expression<Func<SDOrganization, bool>> predicate = null;
            //if (!string.IsNullOrEmpty(strWhere))
            //    predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDOrganization, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
			 ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
            contextRequest.CustomQuery.FilterExpressionString = strWhere;

			//item = GetBy(predicate, loadIncludes, contextRequest).FirstOrDefault();
			item = GetBy(strWhere,loadIncludes,contextRequest).FirstOrDefault();
            return item;
        }
         public List<SDOrganization> GetBy(string strWhere, bool loadRelations, ContextRequest contextRequest)
        {
            if (!loadRelations)
                return GetBy(strWhere, contextRequest);
            else
                return GetBy(strWhere, contextRequest, "");

        }
		  public List<SDOrganization> GetBy(string strWhere, bool loadRelations)
        {
              if (!loadRelations)
                return GetBy(strWhere, new ContextRequest());
            else
                return GetBy(strWhere, new ContextRequest(), "");

        }
		         public SDOrganization GetByKey(Guid guidOrganization, params Expression<Func<SDOrganization, object>>[] includes)
        {
            SDOrganization item = null;
			string strWhere = @"GuidOrganization = Guid(""" + guidOrganization.ToString()+@""")";
          Expression<Func<SDOrganization, bool>> predicate = p=> p.GuidOrganization == guidOrganization;
           // if (!string.IsNullOrEmpty(strWhere))
           //     predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDOrganization, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
        item = GetBy(predicate, includes).FirstOrDefault();
         ////   item = GetBy(strWhere,includes).FirstOrDefault();
			return item;

        }
        public SDOrganization GetByKey(Guid guidOrganization, string includes)
        {
            SDOrganization item = null;
			string strWhere = @"GuidOrganization = Guid(""" + guidOrganization.ToString()+@""")";
            
			
            item = GetBy(strWhere, includes).FirstOrDefault();
            return item;

        }
		 public SDOrganization GetByKey(Guid guidOrganization, string usemode, string includes)
		{
			return GetByKey(guidOrganization, usemode, null, includes);

		 }
		 public SDOrganization GetByKey(Guid guidOrganization, string usemode, ContextRequest context,  string includes)
        {
            SDOrganization item = null;
			string strWhere = @"GuidOrganization = Guid(""" + guidOrganization.ToString()+@""")";
			if (context == null){
				context = new ContextRequest();
				context.CustomQuery = new CustomQuery();
				context.CustomQuery.IsByKey = true;
				context.CustomQuery.FilterExpressionString = strWhere;
				context.UseMode = usemode;
			}
            item = GetBy(strWhere,context , includes).FirstOrDefault();
            return item;

        }

        #region Dynamic Predicate
        public List<SDOrganization> GetBy(Expression<Func<SDOrganization, bool>> predicate, int? pageSize, int? page)
        {
            return this.GetBy(predicate, pageSize, page, null, null);
        }
        public List<SDOrganization> GetBy(Expression<Func<SDOrganization, bool>> predicate, ContextRequest contextRequest)
        {

            return GetBy(predicate, contextRequest,"");
        }
        
        public List<SDOrganization> GetBy(Expression<Func<SDOrganization, bool>> predicate, ContextRequest contextRequest, params Expression<Func<SDOrganization, object>>[] includes)
        {
            StringBuilder sb = new StringBuilder();
           if (includes != null)
            {
                foreach (var path in includes)
                {

						if (sb.Length > 0) sb.Append(",");
						sb.Append(SFSdotNet.Framework.Linq.Utils.IncludeToString<SDOrganization>(path));

               }
            }
            return GetBy(predicate, contextRequest, sb.ToString());
        }
        
        
        public List<SDOrganization> GetBy(Expression<Func<SDOrganization, bool>> predicate, string includes)
        {
			ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";

            return GetBy(predicate, context, includes);
        }

        public List<SDOrganization> GetBy(Expression<Func<SDOrganization, bool>> predicate, params Expression<Func<SDOrganization, object>>[] includes)
        {
			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest context = new ContextRequest();
			            context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";
            return GetBy(predicate, context, includes);
        }

      
		public bool DisableCache { get; set; }
		public List<SDOrganization> GetBy(Expression<Func<SDOrganization, bool>> predicate, ContextRequest contextRequest, string includes)
		{
            using (EFContext con = new EFContext()) {
				
				string fkIncludes = "";
                List<string> multilangProperties = new List<string>();
				if (predicate == null) predicate = PredicateBuilder.True<SDOrganization>();
                var notDeletedExpression = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;
					Expression<Func<SDOrganization,bool>> multitenantExpression  = null;
					if (contextRequest != null && contextRequest.Company != null)	                        	
						multitenantExpression = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicate, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression);

#region Old code
/*
				List<SDOrganization> result = null;
               BusinessRulesEventArgs<SDOrganization>  e = null;
	
				OnGetting(con, e = new BusinessRulesEventArgs<SDOrganization>() {  FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null) });

               // OnGetting(con,e = new BusinessRulesEventArgs<SDOrganization>() { FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = contextRequest.CustomQuery.FilterExpressionString});
				   if (e != null) {
				    predicate = e.FilterExpression;
						if (e.Cancel)
						{
							context = null;
							 if (e.Items == null) e.Items = new List<SDOrganization>();
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                if (predicate == null) predicate = PredicateBuilder.True<SDOrganization>();
                
                //var es = _repository.Queryable;

                IQueryable<SDOrganization> query =  con.SDOrganizations.AsQueryable();

                                if (!string.IsNullOrEmpty(includes))
                {
                    foreach (string include in includes.Split(char.Parse(",")))
                    {
						if (!string.IsNullOrEmpty(include))
                            query = query.Include(include);
                    }
                }
                    predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
					 	if (!preventSecurityRestrictions)
						{
							if (contextRequest != null )
		                    	if (contextRequest.User !=null )
		                        	if (contextRequest.Company != null){
		                        	
										predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
 									
									}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				query =query.AsExpandable().Where(predicate);
                query = ContextQueryBuilder<SDOrganization>.ApplyContextQuery(query, contextRequest);

                result = query.AsNoTracking().ToList<SDOrganization>();
				  
                if (e != null)
                {
                    e.Items = result;
                }
				//if (contextRequest != null ){
				//	 contextRequest = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
					contextRequest.CustomQuery = new CustomQuery();

				//}
				OnTaken(this, e == null ? e =  new BusinessRulesEventArgs<SDOrganization>() { Items= result, IncludingComputedLinq = false, ContextRequest = contextRequest,  FilterExpression = predicate } :  e);
  
			

                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
				*/
#endregion
            }
        }


		/*public int Update(List<SDOrganization> items, ContextRequest contextRequest)
            {
                int result = 0;
                using (EFContext con = new EFContext())
                {
                   
                

                    foreach (var item in items)
                    {
                        //secMessageToUser messageToUser = new secMessageToUser();
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            item.GetType().GetProperty(prop).SetValue(item, item.GetType().GetProperty(prop).GetValue(item));
                        }
                        //messageToUser.GuidMessageToUser = (Guid)item.GetType().GetProperty("GuidMessageToUser").GetValue(item);

                        var setObject = con.CreateObjectSet<SDOrganization>("SDOrganizations");
                        //messageToUser.Readed = DateTime.UtcNow;
                        setObject.Attach(item);
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            con.ObjectStateManager.GetObjectStateEntry(item).SetModifiedProperty(prop);
                        }
                       
                    }
                    result = con.SaveChanges();

                    


                }
                return result;
            }
           */
		

        public List<SDOrganization> GetBy(string predicateString, ContextRequest contextRequest, string includes)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
				


				string computedFields = "";
				string fkIncludes = "";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDOrganization>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					//if (contextRequest != null && contextRequest.Company != null)                      	
					//	 multitenantExpression = @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))";
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicateString, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression,computedFields);


	#region Old Code
	/*
				BusinessRulesEventArgs<SDOrganization> e = null;

				Filter filter = new Filter();
                if (predicateString.Contains("|"))
                {
                    string ft = GetSpecificFilter(predicateString, contextRequest);
                    if (!string.IsNullOrEmpty(ft))
                        filter.SetFilterPart("ft", ft);
                   
                    contextRequest.FreeText = predicateString.Split(char.Parse("|"))[1];
                    var q1 = predicateString.Split(char.Parse("|"))[0];
                    if (!string.IsNullOrEmpty(q1))
                    {
                        filter.ProcessText(q1);
                    }
                }
                else {
                    filter.ProcessText(predicateString);
                }
				 var includesList = (new List<string>());
                 if (!string.IsNullOrEmpty(includes))
                 {
                     includesList = includes.Split(char.Parse(",")).ToList();
                 }

				List<SDOrganization> result = new List<SDOrganization>();
         
			QueryBuild(predicateString, filter, con, contextRequest, "getby", includesList);
			 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }
				
				
					OnGetting(con, e == null ? e = new BusinessRulesEventArgs<SDOrganization>() { Filter = filter, ContextRequest = contextRequest  } : e );

                  //OnGetting(con,e = new BusinessRulesEventArgs<SDOrganization>() {  ContextRequest = contextRequest, FilterExpressionString = predicateString });
			   	if (e != null) {
				    //predicateString = e.GetQueryString();
						if (e.Cancel)
						{
							context = null;
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				//	 else {
                //      predicateString = predicateString.Replace("*extraFreeText*", "").Replace("()","");
                //  }
				//con.EnableChangeTrackingUsingProxies = false;
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                //if (predicate == null) predicate = PredicateBuilder.True<SDOrganization>();
                
                //var es = _repository.Queryable;
				IQueryable<SDOrganization> query = con.SDOrganizations.AsQueryable();
		
				// include relations FK
				if(string.IsNullOrEmpty(includes) ){
					includes ="";
				}
				StringBuilder sbQuerySystem = new StringBuilder();
                    //predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				

				//if (!string.IsNullOrEmpty(predicateString))
                //      sbQuerySystem.Append(" And ");
                //sbQuerySystem.Append(" (IsDeleted != true Or IsDeleted = null) ");
				 filter.SetFilterPart("de", "(IsDeleted != true OR IsDeleted = null)");


					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
	                    	if (contextRequest.User !=null )
	                        	if (contextRequest.Company != null ){
	                        		//if (sbQuerySystem.Length > 0)
	                        		//	    			sbQuerySystem.Append( " And ");	
									//sbQuerySystem.Append(@" (GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa

									filter.SetFilterPart("co",@"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))");

								}
						}	
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				//string predicateString = predicate.ToDynamicLinq<SDOrganization>();
				//predicateString += sbQuerySystem.ToString();
				filter.CleanAndProcess("");

				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed(); //SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicateString );               
                string predicateWithManyRelations = filter.GetFilterChildren(); //SFSdotNet.Framework.Linq.Utils.CleanPartExpression(predicateString);

                //QueryUtils.BreakeQuery1(predicateString, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
                var _queryable = query.AsQueryable();
				bool includeAll = true; 
                if (!string.IsNullOrEmpty(predicateWithManyRelations))
                    _queryable = _queryable.Where(predicateWithManyRelations, contextRequest.CustomQuery.ExtraParams);
				if (contextRequest.CustomQuery.SpecificProperties.Count > 0)
                {

				includeAll = false; 
                }

				StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append("new (");
                bool existPrev = false;
                foreach (var selected in contextRequest.CustomQuery.SelectedFields.Where(p=> !string.IsNullOrEmpty(p.Linq)))
                {
                    if (existPrev) sbSelect.Append(", ");
                    if (!selected.Linq.Contains(".") && !selected.Linq.StartsWith("it."))
                        sbSelect.Append("it." + selected.Linq);
                    else
                        sbSelect.Append(selected.Linq);
                    existPrev = true;
                }
                sbSelect.Append(")");
                var queryable = _queryable.Select(sbSelect.ToString());                    


     				
                 if (!string.IsNullOrEmpty(predicateWithFKAndComputed))
                    queryable = queryable.Where(predicateWithFKAndComputed, contextRequest.CustomQuery.ExtraParams);

				QueryComplementOptions queryOps = ContextQueryBuilder.ApplyContextQuery(contextRequest);
            	if (!string.IsNullOrEmpty(queryOps.OrderByAndSort)){
					if (queryOps.OrderBy.Contains(".") && !queryOps.OrderBy.StartsWith("it.")) queryOps.OrderBy = "it." + queryOps.OrderBy;
					queryable = queryable.OrderBy(queryOps.OrderByAndSort);
					}
               	if (queryOps.Skip != null)
                {
                    queryable = queryable.Skip(queryOps.Skip.Value);
                }
                if (queryOps.PageSize != null)
                {
                    queryable = queryable.Take (queryOps.PageSize.Value);
                }


                var resultTemp = queryable.AsQueryable().ToListAsync().Result;
                foreach (var item in resultTemp)
                {

				   result.Add(SFSdotNet.Framework.BR.Utils.GetConverted<SDOrganization,dynamic>(item, contextRequest.CustomQuery.SelectedFields.Select(p=>p.Name).ToArray()));
                }

			 if (e != null)
                {
                    e.Items = result;
                }
				 contextRequest.CustomQuery = new CustomQuery();
				OnTaken(this, e == null ? e = new BusinessRulesEventArgs<SDOrganization>() { Items= result, IncludingComputedLinq = true, ContextRequest = contextRequest, FilterExpressionString  = predicateString } :  e);
  
			
  
                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
	
	*/
	#endregion

            }
        }
		public SDOrganization GetFromOperation(string function, string filterString, string usemode, string fields, ContextRequest contextRequest)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
                string computedFields = "";
               // string fkIncludes = "accContpaqiClassification,accProjectConcept,accProjectType,accProxyUser";
                List<string> multilangProperties = new List<string>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					if (contextRequest != null && contextRequest.Company != null)
					{
						multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
						contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
					}
					 									
					string multiTenantField = "GuidCompany";


                return GetSummaryOperation(con, new SDOrganization(), function, filterString, usemode, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields, contextRequest, fields.Split(char.Parse(",")).ToArray());
            }
        }

   protected override void QueryBuild(string predicate, Filter filter, DbContext efContext, ContextRequest contextRequest, string method, List<string> includesList)
      	{
				if (contextRequest.CustomQuery.SpecificProperties.Count == 0)
                {
					contextRequest.CustomQuery.SpecificProperties.Add(SDOrganization.PropertyNames.FullName);
					contextRequest.CustomQuery.SpecificProperties.Add(SDOrganization.PropertyNames.GuidCompany);
					contextRequest.CustomQuery.SpecificProperties.Add(SDOrganization.PropertyNames.CreatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDOrganization.PropertyNames.UpdatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDOrganization.PropertyNames.CreatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDOrganization.PropertyNames.UpdatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDOrganization.PropertyNames.Bytes);
					contextRequest.CustomQuery.SpecificProperties.Add(SDOrganization.PropertyNames.IsDeleted);
                    
				}

				if (method == "getby" || method == "sum")
				{
					if (!contextRequest.CustomQuery.SpecificProperties.Contains("GuidOrganization")){
						contextRequest.CustomQuery.SpecificProperties.Add("GuidOrganization");
					}

					 if (!string.IsNullOrEmpty(contextRequest.CustomQuery.OrderBy))
					{
						string existPropertyOrderBy = contextRequest.CustomQuery.OrderBy;
						if (contextRequest.CustomQuery.OrderBy.Contains("."))
						{
							existPropertyOrderBy = contextRequest.CustomQuery.OrderBy.Split(char.Parse("."))[0];
						}
						if (!contextRequest.CustomQuery.SpecificProperties.Exists(p => p == existPropertyOrderBy))
						{
							contextRequest.CustomQuery.SpecificProperties.Add(existPropertyOrderBy);
						}
					}

				}
				
	bool isFullDetails = contextRequest.IsFromUI("SDOrganizations", UIActions.GetForDetails);
	string filterForTest = predicate  + filter.GetFilterComplete();

				if (isFullDetails || !string.IsNullOrEmpty(predicate))
            {
            } 

			if (method == "sum")
            {
            } 
			if (contextRequest.CustomQuery.SelectedFields.Count == 0)
            {
				foreach (var selected in contextRequest.CustomQuery.SpecificProperties)
                {
					string linq = selected;
					switch (selected)
                    {

					 
						
					 default:
                            break;
                    }
					contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name=selected, Linq=linq});
					if (method == "getby" || method == "sum")
					{
						if (includesList.Contains(selected))
							includesList.Remove(selected);

					}

				}
			}
				if (method == "getby" || method == "sum")
				{
					foreach (var otherInclude in includesList.Where(p=> !string.IsNullOrEmpty(p)))
					{
						contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name = otherInclude, Linq = "it." + otherInclude +" as " + otherInclude });
					}
				}
				BusinessRulesEventArgs<SDOrganization> e = null;
				if (contextRequest.PreventInterceptors == false)
					OnQuerySettings(efContext, e = new BusinessRulesEventArgs<SDOrganization>() { Filter = filter, ContextRequest = contextRequest /*, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null)*/ });

				//List<SDOrganization> result = new List<SDOrganization>();
                 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }

}
		public List<SDOrganization> GetBy(Expression<Func<SDOrganization, bool>> predicate, bool loadRelations, ContextRequest contextRequest)
        {
			if(!loadRelations)
				return GetBy(predicate, contextRequest);
			else
				return GetBy(predicate, contextRequest, "SDAreas,SDPersons");

        }

        public List<SDOrganization> GetBy(Expression<Func<SDOrganization, bool>> predicate, int? pageSize, int? page, string orderBy, SFSdotNet.Framework.Data.SortDirection? sortDirection)
        {
            return GetBy(predicate, new ContextRequest() { CustomQuery = new CustomQuery() { Page = page, PageSize = pageSize, OrderBy = orderBy, SortDirection = sortDirection } });
        }
        public List<SDOrganization> GetBy(Expression<Func<SDOrganization, bool>> predicate)
        {

			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
			contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
			            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            contextRequest.CustomQuery.FilterExpressionString = null;
            return this.GetBy(predicate, contextRequest, "");
        }
        #endregion
        #region Dynamic String
		protected override string GetSpecificFilter(string filter, ContextRequest contextRequest) {
            string result = "";
		    //string linqFilter = String.Empty;
            string freeTextFilter = String.Empty;
            if (filter.Contains("|"))
            {
               // linqFilter = filter.Split(char.Parse("|"))[0];
                freeTextFilter = filter.Split(char.Parse("|"))[1];
            }
            //else {
            //    freeTextFilter = filter;
            //}
            //else {
            //    linqFilter = filter;
            //}
			// linqFilter = SFSdotNet.Framework.Linq.Utils.ReplaceCustomDateFilters(linqFilter);
            //string specificFilter = linqFilter;
            if (!string.IsNullOrEmpty(freeTextFilter))
            {
                System.Text.StringBuilder sbCont = new System.Text.StringBuilder();
                /*if (specificFilter.Length > 0)
                {
                    sbCont.Append(" AND ");
                    sbCont.Append(" ({0})");
                }
                else
                {
                    sbCont.Append("{0}");
                }*/
                //var words = freeTextFilter.Split(char.Parse(" "));
				var word = freeTextFilter;
                System.Text.StringBuilder sbSpec = new System.Text.StringBuilder();
                 int nWords = 1;
				/*foreach (var word in words)
                {
					if (word.Length > 0){
                    if (sbSpec.Length > 0) sbSpec.Append(" AND ");
					if (words.Length > 1) sbSpec.Append("("); */
					
	
					
					
					
									
					sbSpec.Append(string.Format(@"FullName.Contains(""{0}"")", word));
					

					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
								 //sbSpec.Append("*extraFreeText*");

                    /*if (words.Length > 1) sbSpec.Append(")");
					
					nWords++;

					}

                }*/
                //specificFilter = string.Format("{0}{1}", specificFilter, string.Format(sbCont.ToString(), sbSpec.ToString()));
                                 result = sbSpec.ToString();  
            }
			//result = specificFilter;
			
			return result;

		}
	
			public List<SDOrganization> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params object[] extraParams)
        {
			return GetBy(filter, pageSize, page, orderBy, orderDir,  null, extraParams);
		}
           public List<SDOrganization> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, string usemode, params object[] extraParams)
            { 
                return GetBy(filter, pageSize, page, orderBy, orderDir, usemode, null, extraParams);
            }


		public List<SDOrganization> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  string usemode, ContextRequest context, params object[] extraParams)

        {

            // string freetext = null;
            //if (filter.Contains("|"))
            //{
            //    int parts = filter.Split(char.Parse("|")).Count();
            //    if (parts > 1)
            //    {

            //        freetext = filter.Split(char.Parse("|"))[1];
            //    }
            //}
		
            //string specificFilter = "";
            //if (!string.IsNullOrEmpty(filter))
            //  specificFilter=  GetSpecificFilter(filter);
            if (string.IsNullOrEmpty(orderBy))
            {
			                orderBy = "UpdatedDate";
            }
			//orderDir = "desc";
			SFSdotNet.Framework.Data.SortDirection direction = SFSdotNet.Framework.Data.SortDirection.Ascending;
            if (!string.IsNullOrEmpty(orderDir))
            {
                if (orderDir == "desc")
                    direction = SFSdotNet.Framework.Data.SortDirection.Descending;
            }
            if (context == null)
                context = new ContextRequest();
			

             context.UseMode = usemode;
             if (context.CustomQuery == null )
                context.CustomQuery =new SFSdotNet.Framework.My.CustomQuery();

 
                context.CustomQuery.ExtraParams = extraParams;

                    context.CustomQuery.OrderBy = orderBy;
                   context.CustomQuery.SortDirection = direction;
                   context.CustomQuery.Page = page;
                  context.CustomQuery.PageSize = pageSize;
               

            

            if (!preventSecurityRestrictions) {
			 if (context.CurrentContext == null)
                {
					if (SFSdotNet.Framework.My.Context.CurrentContext != null &&  SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
					{
						context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
						context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

					}
					else {
						throw new Exception("The security rule require a specific user and company");
					}
				}
            }
            return GetBy(filter, context);
  
        }


        public List<SDOrganization> GetBy(string strWhere, ContextRequest contextRequest)
        {
        	#region old code
				
				 //Expression<Func<tvsReservationTransport, bool>> predicate = null;
				string strWhereClean = strWhere.Replace("*extraFreeText*", "").Replace("()", "");
                //if (!string.IsNullOrEmpty(strWhereClean)){

                //    object[] extraParams = null;
                //    //if (contextRequest != null )
                //    //    if (contextRequest.CustomQuery != null )
                //    //        extraParams = contextRequest.CustomQuery.ExtraParams;
                //    //predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<tvsReservationTransport, bool>(strWhereClean, extraParams != null? extraParams.Cast<Guid>(): null);				
                //}
				 if (contextRequest == null)
                {
                    contextRequest = new ContextRequest();
                    if (contextRequest.CustomQuery == null)
                        contextRequest.CustomQuery = new CustomQuery();
                }
                  if (!preventSecurityRestrictions) {
					if (contextRequest.User == null || contextRequest.Company == null)
                      {
                     if (SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
                     {
                         contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                         contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

                     }
                     else {
                         throw new Exception("The security rule require a specific User and Company ");
                     }
					 }
                 }
            contextRequest.CustomQuery.FilterExpressionString = strWhere;
				//return GetBy(predicate, contextRequest);  

			#endregion				
				
                    return GetBy(strWhere, contextRequest, "");  


        }
       public List<SDOrganization> GetBy(string strWhere)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
			
            return GetBy(strWhere, context, null);
        }

        public List<SDOrganization> GetBy(string strWhere, string includes)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
            return GetBy(strWhere, context, includes);
        }

        #endregion
        #endregion
		
		  #region SaveOrUpdate
        
 		 public SDOrganization Create(SDOrganization entity)
        {
				//ObjectContext context = null;
				    if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: Create");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

				return this.Create(entity, contextRequest);


        }
        
       
        public SDOrganization Create(SDOrganization entity, ContextRequest contextRequest)
        {
		
		bool graph = false;
	
				bool preventPartial = false;
                if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
               
			using (EFContext con = new EFContext()) {

				SDOrganization itemForSave = new SDOrganization();
#region Autos
		if(!preventSecurityRestrictions){

				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion
               BusinessRulesEventArgs<SDOrganization> e = null;
			    if (preventPartial == false )
                OnCreating(this,e = new BusinessRulesEventArgs<SDOrganization>() { ContextRequest = contextRequest, Item=entity });
				   if (e != null) {
						if (e.Cancel)
						{
							context = null;
							return e.Item;

						}
					}

                    if (entity.GuidOrganization == Guid.Empty)
                   {
                       entity.GuidOrganization = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   itemForSave.GuidOrganization = entity.GuidOrganization;
				  
		
			itemForSave.GuidOrganization = entity.GuidOrganization;

			itemForSave.FullName = entity.FullName;

			itemForSave.GuidCompany = entity.GuidCompany;

			itemForSave.CreatedDate = entity.CreatedDate;

			itemForSave.UpdatedDate = entity.UpdatedDate;

			itemForSave.CreatedBy = entity.CreatedBy;

			itemForSave.UpdatedBy = entity.UpdatedBy;

			itemForSave.Bytes = entity.Bytes;

			itemForSave.IsDeleted = entity.IsDeleted;

				
				con.SDOrganizations.Add(itemForSave);






                
				con.ChangeTracker.Entries().Where(p => p.Entity != itemForSave && p.State != EntityState.Unchanged).ForEach(p => p.State = EntityState.Detached);

				con.Entry<SDOrganization>(itemForSave).State = EntityState.Added;

				con.SaveChanges();

					 
				

				//itemResult = entity;
                //if (e != null)
                //{
                 //   e.Item = itemResult;
                //}
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false )
                OnCreated(this, e == null ? e = new BusinessRulesEventArgs<SDOrganization>() { ContextRequest = contextRequest, Item = entity } : e);



                if (e != null && e.Item != null )
                {
                    return e.Item;
                }
                              return entity;
			}
            
        }
        //BusinessRulesEventArgs<SDOrganization> e = null;
        public void Create(List<SDOrganization> entities)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            Create(entities, contextRequest);
        }
        public void Create(List<SDOrganization> entities, ContextRequest contextRequest)
        
        {
			ObjectContext context = null;
            	foreach (SDOrganization entity in entities)
				{
					this.Create(entity, contextRequest);
				}
        }
		  public void CreateOrUpdateBulk(List<SDOrganization> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "cu", contextRequest);
        }

        private void CreateOrUpdateBulk(List<SDOrganization> entities, string actionKey, ContextRequest contextRequest)
        {
			if (entities.Count() > 0){
            bool graph = false;

            bool preventPartial = false;
            if (contextRequest != null && contextRequest.PreventInterceptors == true)
            {
                preventPartial = true;
            }
            foreach (var entity in entities)
            {
                    if (entity.GuidOrganization == Guid.Empty)
                   {
                       entity.GuidOrganization = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   
				  


#region Autos
		if(!preventSecurityRestrictions){


 if (actionKey != "u")
                        {
				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;


}
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion


		
			//entity.GuidOrganization = entity.GuidOrganization;

			//entity.FullName = entity.FullName;

			//entity.GuidCompany = entity.GuidCompany;

			//entity.CreatedDate = entity.CreatedDate;

			//entity.UpdatedDate = entity.UpdatedDate;

			//entity.CreatedBy = entity.CreatedBy;

			//entity.UpdatedBy = entity.UpdatedBy;

			//entity.Bytes = entity.Bytes;

			//entity.IsDeleted = entity.IsDeleted;

				
				






                
				

					 
				

				//itemResult = entity;
            }
            using (EFContext con = new EFContext())
            {
                 if (actionKey == "c")
                    {
                        context.BulkInsert(entities);
                    }else if ( actionKey == "u")
                    {
                        context.BulkUpdate(entities);
                    }else
                    {
                        context.BulkInsertOrUpdate(entities);
                    }
            }

			}
        }
	
		public void CreateBulk(List<SDOrganization> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "c", contextRequest);
        }


		public void UpdateAgile(SDOrganization item, params string[] fields)
         {
			UpdateAgile(item, null, fields);
        }
		public void UpdateAgile(SDOrganization item, ContextRequest contextRequest, params string[] fields)
         {
            
             ContextRequest contextNew = null;
             if (contextRequest != null)
             {
                 contextNew = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
                 if (fields != null && fields.Length > 0)
                 {
                     contextNew.CustomQuery.SpecificProperties  = fields.ToList();
                 }
                 else if(contextRequest.CustomQuery.SpecificProperties.Count > 0)
                 {
                     fields = contextRequest.CustomQuery.SpecificProperties.ToArray();
                 }
             }
			

		   using (EFContext con = new EFContext())
            {



               
					List<string> propForCopy = new List<string>();
                    propForCopy.AddRange(fields);
                    
					  
					if (!propForCopy.Contains("GuidOrganization"))
						propForCopy.Add("GuidOrganization");
					if (!propForCopy.Contains("FullName"))
						propForCopy.Add("FullName");

					var itemForUpdate = SFSdotNet.Framework.BR.Utils.GetConverted<SDOrganization,SDOrganization>(item, propForCopy.ToArray());
					 itemForUpdate.GuidOrganization = item.GuidOrganization;
                  var setT = con.Set<SDOrganization>().Attach(itemForUpdate);

					if (fields.Count() > 0)
					  {
						  item.ModifiedProperties = fields;
					  }
                    foreach (var property in item.ModifiedProperties)
					{						
                        if (property != "GuidOrganization")
                             con.Entry(setT).Property(property).IsModified = true;

                    }

                
               int result = con.SaveChanges();
               if (result != 1)
               {
                   SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: 1");
               }


            }

			OnUpdatedAgile(this, new BusinessRulesEventArgs<SDOrganization>() { Item = item, ContextRequest = contextNew  });

         }
		public void UpdateBulk(List<SDOrganization>  items, params string[] fields)
         {
             SFSdotNet.Framework.My.ContextRequest req = new SFSdotNet.Framework.My.ContextRequest();
             req.CustomQuery = new SFSdotNet.Framework.My.CustomQuery();
             foreach (var field in fields)
             {
                 req.CustomQuery.SpecificProperties.Add(field);
             }
             UpdateBulk(items, req);

         }

		 public void DeleteBulk(List<SDOrganization> entities, ContextRequest contextRequest = null)
        {

            using (EFContext con = new EFContext())
            {
                foreach (var entity in entities)
                {
					var entityProxy = new SDOrganization() { GuidOrganization = entity.GuidOrganization };

                    con.Entry<SDOrganization>(entityProxy).State = EntityState.Deleted;

                }

                int result = con.SaveChanges();
                if (result != entities.Count)
                {
                    SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: " + entities.Count.ToString());
                }
            }

        }

        public void UpdateBulk(List<SDOrganization> items, ContextRequest contextRequest)
        {
            if (items.Count() > 0){

			 foreach (var entity in items)
            {


#region Autos
		if(!preventSecurityRestrictions){

				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	



			}
#endregion







				}
				using (EFContext con = new EFContext())
				{

                    
                
                   con.BulkUpdate(items);

				}
             
			}	  
        }

         public SDOrganization Update(SDOrganization entity)
        {
            if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return Update(entity, contextRequest);
        }
       
         public SDOrganization Update(SDOrganization entity, ContextRequest contextRequest)
        {
		 if ((System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null) && contextRequest == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Update");
            }
            if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            }

			
				SDOrganization  itemResult = null;

	
			//entity.UpdatedDate = DateTime.Now.ToUniversalTime();
			//if(contextRequest.User != null)
				//entity.UpdatedBy = contextRequest.User.GuidUser;

//	    var oldentity = GetBy(p => p.GuidOrganization == entity.GuidOrganization, contextRequest).FirstOrDefault();
	//	if (oldentity != null) {
		
          //  entity.CreatedDate = oldentity.CreatedDate;
    //        entity.CreatedBy = oldentity.CreatedBy;
	
      //      entity.GuidCompany = oldentity.GuidCompany;
	
			

	
		//}

			 using( EFContext con = new EFContext()){
				BusinessRulesEventArgs<SDOrganization> e = null;
				bool preventPartial = false; 
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false)
                OnUpdating(this,e = new BusinessRulesEventArgs<SDOrganization>() { ContextRequest = contextRequest, Item=entity});
				   if (e != null) {
						if (e.Cancel)
						{
							//outcontext = null;
							return e.Item;

						}
					}

	string includes = "";
	IQueryable < SDOrganization > query = con.SDOrganizations.AsQueryable();
	foreach (string include in includes.Split(char.Parse(",")))
                       {
                           if (!string.IsNullOrEmpty(include))
                               query = query.Include(include);
                       }
	var oldentity = query.FirstOrDefault(p => p.GuidOrganization == entity.GuidOrganization);
	if (oldentity.FullName != entity.FullName)
		oldentity.FullName = entity.FullName;

				//if (entity.UpdatedDate == null || (contextRequest != null && contextRequest.IsFromUI("SDOrganizations", UIActions.Updating)))
			oldentity.UpdatedDate = DateTime.Now.ToUniversalTime();
			if(contextRequest.User != null)
				oldentity.UpdatedBy = contextRequest.User.GuidUser;

           


				if (entity.SDAreas != null)
                {
                    foreach (var item in entity.SDAreas)
                    {


                        
                    }
					
                    

                }


				if (entity.SDPersons != null)
                {
                    foreach (var item in entity.SDPersons)
                    {


                        
                    }
					
                    

                }


				con.ChangeTracker.Entries().Where(p => p.Entity != oldentity).ForEach(p => p.State = EntityState.Unchanged);  
				  
				con.SaveChanges();
        
					 
					
               
				itemResult = entity;
				if(preventPartial == false)
					OnUpdated(this, e = new BusinessRulesEventArgs<SDOrganization>() { ContextRequest = contextRequest, Item=itemResult });

              	return itemResult;
			}
			  
        }
        public SDOrganization Save(SDOrganization entity)
        {
			return Create(entity);
        }
        public int Save(List<SDOrganization> entities)
        {
			 Create(entities);
            return entities.Count;

        }
        #endregion
        #region Delete
        public void Delete(SDOrganization entity)
        {
				this.Delete(entity, null);
			
        }
		 public void Delete(SDOrganization entity, ContextRequest contextRequest)
        {
				
				  List<SDOrganization> entities = new List<SDOrganization>();
				   entities.Add(entity);
				this.Delete(entities, contextRequest);
			
        }

         public void Delete(string query, Guid[] guids, ContextRequest contextRequest)
        {
			var br = new SDOrganizationsBR(true);
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);
            
            Delete(items, contextRequest);

        }
        public void Delete(SDOrganization entity,  ContextRequest contextRequest, BusinessRulesEventArgs<SDOrganization> e = null)
        {
			
				using(EFContext con = new EFContext())
                 {
				
               	BusinessRulesEventArgs<SDOrganization> _e = null;
               List<SDOrganization> _items = new List<SDOrganization>();
                _items.Add(entity);
                if (e == null || e.PreventPartialPropagate == false)
                {
                    OnDeleting(this, _e = (e == null ? new BusinessRulesEventArgs<SDOrganization>() { ContextRequest = contextRequest, Item = entity, Items = null  } : e));
                }
                if (_e != null)
                {
                    if (_e.Cancel)
						{
							context = null;
							return;

						}
					}


				
									//IsDeleted
					bool logicDelete = true;
					if (entity.IsDeleted != null)
					{
						if (entity.IsDeleted.Value)
							logicDelete = false;
					}
					if (logicDelete)
					{
											//entity = GetBy(p =>, contextRequest).FirstOrDefault();
						entity.IsDeleted = true;
						if (contextRequest != null && contextRequest.User != null)
							entity.UpdatedBy = contextRequest.User.GuidUser;
                        entity.UpdatedDate = DateTime.UtcNow;
						UpdateAgile(entity, "IsDeleted","UpdatedBy","UpdatedDate");

						
					}
					else {
					con.Entry<SDOrganization>(entity).State = EntityState.Deleted;
					con.SaveChanges();
				
				 
					}
								
				
				 
					
					
			if (e == null || e.PreventPartialPropagate == false)
                {

                    if (_e == null)
                        _e = new BusinessRulesEventArgs<SDOrganization>() { ContextRequest = contextRequest, Item = entity, Items = null };

                    OnDeleted(this, _e);
                }

				//return null;
			}
        }
 public void UnDelete(string query, Guid[] guids, ContextRequest contextRequest)
        {
            var br = new SDOrganizationsBR(true);
            contextRequest.CustomQuery.IncludeDeleted = true;
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);

            foreach (var item in items)
            {
                item.IsDeleted = false;
						if (contextRequest != null && contextRequest.User != null)
							item.UpdatedBy = contextRequest.User.GuidUser;
                        item.UpdatedDate = DateTime.UtcNow;
            }

            UpdateBulk(items, "IsDeleted","UpdatedBy","UpdatedDate");
        }

         public void Delete(List<SDOrganization> entities,  ContextRequest contextRequest = null )
        {
				
			 BusinessRulesEventArgs<SDOrganization> _e = null;

                OnDeleting(this, _e = new BusinessRulesEventArgs<SDOrganization>() { ContextRequest = contextRequest, Item = null, Items = entities });
                if (_e != null)
                {
                    if (_e.Cancel)
                    {
                        context = null;
                        return;

                    }
                }
                bool allSucced = true;
                BusinessRulesEventArgs<SDOrganization> eToChilds = new BusinessRulesEventArgs<SDOrganization>();
                if (_e != null)
                {
                    eToChilds = _e;
                }
                else
                {
                    eToChilds = new BusinessRulesEventArgs<SDOrganization>() { ContextRequest = contextRequest, Item = (entities.Count == 1 ? entities[0] : null), Items = entities };
                }
				foreach (SDOrganization item in entities)
				{
					try
                    {
                        this.Delete(item, contextRequest, e: eToChilds);
                    }
                    catch (Exception ex)
                    {
                        SFSdotNet.Framework.My.EventLog.Error(ex);
                        allSucced = false;
                    }
				}
				if (_e == null)
                    _e = new BusinessRulesEventArgs<SDOrganization>() { ContextRequest = contextRequest, CountResult = entities.Count, Item = null, Items = entities };
                OnDeleted(this, _e);

			
        }
        #endregion
 
        #region GetCount
		 public int GetCount(Expression<Func<SDOrganization, bool>> predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

			return GetCount(predicate, contextRequest);
		}
        public int GetCount(Expression<Func<SDOrganization, bool>> predicate, ContextRequest contextRequest)
        {


		
		 using (EFContext con = new EFContext())
            {


				if (predicate == null) predicate = PredicateBuilder.True<SDOrganization>();
           		predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted == null);
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    		if (contextRequest.User !=null )
                        		if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
									predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa

								}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				
				IQueryable<SDOrganization> query = con.SDOrganizations.AsQueryable();
                return query.AsExpandable().Count(predicate);

			
				}
			

        }
		  public int GetCount(string predicate,  ContextRequest contextRequest)
         {
             return GetCount(predicate, null, contextRequest);
         }

         public int GetCount(string predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return GetCount(predicate, contextRequest);
        }
		 public int GetCount(string predicate, string usemode){
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
				return GetCount( predicate,  usemode,  contextRequest);
		 }
        public int GetCount(string predicate, string usemode, ContextRequest contextRequest){

		using (EFContext con = new EFContext()) {
				string computedFields = "";
				string fkIncludes = "";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDOrganization>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetCount(con, predicate, usemode, contextRequest, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields);

			}
			#region old code
			 /* string freetext = null;
            Filter filter = new Filter();

              if (predicate.Contains("|"))
              {
                 
                  filter.SetFilterPart("ft", GetSpecificFilter(predicate, contextRequest));
                 
                  filter.ProcessText(predicate.Split(char.Parse("|"))[0]);
                  freetext = predicate.Split(char.Parse("|"))[1];

				  if (!string.IsNullOrEmpty(freetext) && string.IsNullOrEmpty(contextRequest.FreeText))
                  {
                      contextRequest.FreeText = freetext;
                  }
              }
              else {
                  filter.ProcessText(predicate);
              }
			   predicate = filter.GetFilterComplete();
			// BusinessRulesEventArgs<SDOrganization>  e = null;
           	using (EFContext con = new EFContext())
			{
			
			

			 QueryBuild(predicate, filter, con, contextRequest, "count", new List<string>());


			
			BusinessRulesEventArgs<SDOrganization> e = null;

			contextRequest.FreeText = freetext;
			contextRequest.UseMode = usemode;
            OnCounting(this, e = new BusinessRulesEventArgs<SDOrganization>() {  Filter =filter, ContextRequest = contextRequest });
            if (e != null)
            {
                if (e.Cancel)
                {
                    context = null;
                    return e.CountResult;

                }

            

            }
			
			StringBuilder sbQuerySystem = new StringBuilder();
		
					
                    filter.SetFilterPart("de","(IsDeleted != true OR IsDeleted == null)");
			
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    	if (contextRequest.User !=null )
                        	if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
                        		
								filter.SetFilterPart("co", @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa
						
						
							}
							
							}
							if (preventSecurityRestrictions) preventSecurityRestrictions= false;
		
				   
                 filter.CleanAndProcess("");
				//string predicateWithFKAndComputed = SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicate );               
				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed();
               string predicateWithManyRelations = filter.GetFilterChildren();
			   ///QueryUtils.BreakeQuery1(predicate, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
			   predicate = filter.GetFilterComplete();
               if (!string.IsNullOrEmpty(predicate))
               {
				
					
                    return con.SDOrganizations.Where(predicate).Count();
					
                }else
                    return con.SDOrganizations.Count();
					
			}*/
			#endregion

		}
         public int GetCount()
        {
            return GetCount(p => true);
        }
        #endregion
        
         


        public void Delete(List<SDOrganization.CompositeKey> entityKeys)
        {

            List<SDOrganization> items = new List<SDOrganization>();
            foreach (var itemKey in entityKeys)
            {
                items.Add(GetByKey(itemKey.GuidOrganization));
            }

            Delete(items);

        }
		 public void UpdateAssociation(string relation, string relationValue, string query, Guid[] ids, ContextRequest contextRequest)
        {
            var items = GetBy(query, null, null, null, null, null, contextRequest, ids);
			 var module = SFSdotNet.Framework.Cache.Caching.SystemObjects.GetModuleByKey(SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(System.Web.HttpContext.Current.Request.RequestContext, "area"));
           
            foreach (var item in items)
            {
			  Guid ? guidRelationValue = null ;
                if (!string.IsNullOrEmpty(relationValue)){
                    guidRelationValue = Guid.Parse(relationValue );
                }

				 if (relation.Contains("."))
                {
                    var partsWithOtherProp = relation.Split(char.Parse("|"));
                    var parts = partsWithOtherProp[0].Split(char.Parse("."));

                    string proxyRelName = parts[0];
                    string proxyProperty = parts[1];
                    string proxyPropertyKeyNameFromOther = partsWithOtherProp[1];
                    //string proxyPropertyThis = parts[2];

                    var prop = item.GetType().GetProperty(proxyRelName);
                    //var entityInfo = //SFSdotNet.Framework.
                    // descubrir el tipo de entidad dentro de la colección
                    Type typeEntityInList = SFSdotNet.Framework.Entities.Utils.GetTypeFromList(prop);
                    var newProxyItem = Activator.CreateInstance(typeEntityInList);
                    var propThisForSet = newProxyItem.GetType().GetProperty(proxyProperty);
                    var entityInfoOfProxy = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(typeEntityInList);
                    var propOther = newProxyItem.GetType().GetProperty(proxyPropertyKeyNameFromOther);

                    if (propThisForSet != null && entityInfoOfProxy != null && propOther != null )
                    {
                        var entityInfoThis = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(item.GetType());
                        var valueThisId = item.GetType().GetProperty(entityInfoThis.PropertyKeyName).GetValue(item);
                        if (valueThisId != null)
                            propThisForSet.SetValue(newProxyItem, valueThisId);
                        propOther.SetValue(newProxyItem, Guid.Parse(relationValue));
                        
                        var entityNameProp = newProxyItem.GetType().GetField("EntityName").GetValue(null);
                        var entitySetNameProp = newProxyItem.GetType().GetField("EntitySetName").GetValue(null);

                        SFSdotNet.Framework.Apps.Integration.CreateItemFromApp(entityNameProp.ToString(), entitySetNameProp.ToString(), module.ModuleNamespace, newProxyItem, contextRequest);

                    }

                    // crear una instancia del tipo de entidad
                    // llenar los datos y registrar nuevo


                }
                else
                {
                var prop = item.GetType().GetProperty(relation);
                var entityInfo = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(prop.PropertyType);
                if (entityInfo != null)
                {
                    var ins = Activator.CreateInstance(prop.PropertyType);
                   if (guidRelationValue != null)
                    {
                        prop.PropertyType.GetProperty(entityInfo.PropertyKeyName).SetValue(ins, guidRelationValue);
                        item.GetType().GetProperty(relation).SetValue(item, ins);
                    }
                    else
                    {
                        item.GetType().GetProperty(relation).SetValue(item, null);
                    }

                    Update(item, contextRequest);
                }

				}
            }
        }
		
	}
		public partial class SDPersonsBR:BRBase<SDPerson>{
	 	
           
		 #region Partial methods

           partial void OnUpdating(object sender, BusinessRulesEventArgs<SDPerson> e);

            partial void OnUpdated(object sender, BusinessRulesEventArgs<SDPerson> e);
			partial void OnUpdatedAgile(object sender, BusinessRulesEventArgs<SDPerson> e);

            partial void OnCreating(object sender, BusinessRulesEventArgs<SDPerson> e);
            partial void OnCreated(object sender, BusinessRulesEventArgs<SDPerson> e);

            partial void OnDeleting(object sender, BusinessRulesEventArgs<SDPerson> e);
            partial void OnDeleted(object sender, BusinessRulesEventArgs<SDPerson> e);

            partial void OnGetting(object sender, BusinessRulesEventArgs<SDPerson> e);
            protected override void OnVirtualGetting(object sender, BusinessRulesEventArgs<SDPerson> e)
            {
                OnGetting(sender, e);
            }
			protected override void OnVirtualCounting(object sender, BusinessRulesEventArgs<SDPerson> e)
            {
                OnCounting(sender, e);
            }
			partial void OnTaken(object sender, BusinessRulesEventArgs<SDPerson> e);
			protected override void OnVirtualTaken(object sender, BusinessRulesEventArgs<SDPerson> e)
            {
                OnTaken(sender, e);
            }

            partial void OnCounting(object sender, BusinessRulesEventArgs<SDPerson> e);
 
			partial void OnQuerySettings(object sender, BusinessRulesEventArgs<SDPerson> e);
          
            #endregion
			
		private static SDPersonsBR singlenton =null;
				public static SDPersonsBR NewInstance(){
					return  new SDPersonsBR();
					
				}
		public static SDPersonsBR Instance{
			get{
				if (singlenton == null)
					singlenton = new SDPersonsBR();
				return singlenton;
			}
		}
		//private bool preventSecurityRestrictions = false;
		 public bool PreventAuditTrail { get; set;  }
		#region Fields
        EFContext context = null;
        #endregion
        #region Constructor
        public SDPersonsBR()
        {
            context = new EFContext();
        }
		 public SDPersonsBR(bool preventSecurity)
            {
                this.preventSecurityRestrictions = preventSecurity;
				context = new EFContext();
            }
        #endregion
		
		#region Get

 		public IQueryable<SDPerson> Get()
        {
            using (EFContext con = new EFContext())
            {
				
				var query = con.SDPersons.AsQueryable();
                con.Configuration.ProxyCreationEnabled = false;

                //query = ContextQueryBuilder<Nutrient>.ApplyContextQuery(query, contextRequest);

                return query;




            }

        }
		


 	
		public List<SDPerson> GetAll()
        {
            return this.GetBy(p => true);
        }
        public List<SDPerson> GetAll(string includes)
        {
            return this.GetBy(p => true, includes);
        }
        public SDPerson GetByKey(Guid guidPerson)
        {
            return GetByKey(guidPerson, true);
        }
        public SDPerson GetByKey(Guid guidPerson, bool loadIncludes)
        {
            SDPerson item = null;
			var query = PredicateBuilder.True<SDPerson>();
                    
			string strWhere = @"GuidPerson = Guid(""" + guidPerson.ToString()+@""")";
            Expression<Func<SDPerson, bool>> predicate = null;
            //if (!string.IsNullOrEmpty(strWhere))
            //    predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDPerson, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
			 ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
            contextRequest.CustomQuery.FilterExpressionString = strWhere;

			//item = GetBy(predicate, loadIncludes, contextRequest).FirstOrDefault();
			item = GetBy(strWhere,loadIncludes,contextRequest).FirstOrDefault();
            return item;
        }
         public List<SDPerson> GetBy(string strWhere, bool loadRelations, ContextRequest contextRequest)
        {
            if (!loadRelations)
                return GetBy(strWhere, contextRequest);
            else
                return GetBy(strWhere, contextRequest, "");

        }
		  public List<SDPerson> GetBy(string strWhere, bool loadRelations)
        {
              if (!loadRelations)
                return GetBy(strWhere, new ContextRequest());
            else
                return GetBy(strWhere, new ContextRequest(), "");

        }
		         public SDPerson GetByKey(Guid guidPerson, params Expression<Func<SDPerson, object>>[] includes)
        {
            SDPerson item = null;
			string strWhere = @"GuidPerson = Guid(""" + guidPerson.ToString()+@""")";
          Expression<Func<SDPerson, bool>> predicate = p=> p.GuidPerson == guidPerson;
           // if (!string.IsNullOrEmpty(strWhere))
           //     predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDPerson, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
        item = GetBy(predicate, includes).FirstOrDefault();
         ////   item = GetBy(strWhere,includes).FirstOrDefault();
			return item;

        }
        public SDPerson GetByKey(Guid guidPerson, string includes)
        {
            SDPerson item = null;
			string strWhere = @"GuidPerson = Guid(""" + guidPerson.ToString()+@""")";
            
			
            item = GetBy(strWhere, includes).FirstOrDefault();
            return item;

        }
		 public SDPerson GetByKey(Guid guidPerson, string usemode, string includes)
		{
			return GetByKey(guidPerson, usemode, null, includes);

		 }
		 public SDPerson GetByKey(Guid guidPerson, string usemode, ContextRequest context,  string includes)
        {
            SDPerson item = null;
			string strWhere = @"GuidPerson = Guid(""" + guidPerson.ToString()+@""")";
			if (context == null){
				context = new ContextRequest();
				context.CustomQuery = new CustomQuery();
				context.CustomQuery.IsByKey = true;
				context.CustomQuery.FilterExpressionString = strWhere;
				context.UseMode = usemode;
			}
            item = GetBy(strWhere,context , includes).FirstOrDefault();
            return item;

        }

        #region Dynamic Predicate
        public List<SDPerson> GetBy(Expression<Func<SDPerson, bool>> predicate, int? pageSize, int? page)
        {
            return this.GetBy(predicate, pageSize, page, null, null);
        }
        public List<SDPerson> GetBy(Expression<Func<SDPerson, bool>> predicate, ContextRequest contextRequest)
        {

            return GetBy(predicate, contextRequest,"");
        }
        
        public List<SDPerson> GetBy(Expression<Func<SDPerson, bool>> predicate, ContextRequest contextRequest, params Expression<Func<SDPerson, object>>[] includes)
        {
            StringBuilder sb = new StringBuilder();
           if (includes != null)
            {
                foreach (var path in includes)
                {

						if (sb.Length > 0) sb.Append(",");
						sb.Append(SFSdotNet.Framework.Linq.Utils.IncludeToString<SDPerson>(path));

               }
            }
            return GetBy(predicate, contextRequest, sb.ToString());
        }
        
        
        public List<SDPerson> GetBy(Expression<Func<SDPerson, bool>> predicate, string includes)
        {
			ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";

            return GetBy(predicate, context, includes);
        }

        public List<SDPerson> GetBy(Expression<Func<SDPerson, bool>> predicate, params Expression<Func<SDPerson, object>>[] includes)
        {
			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest context = new ContextRequest();
			            context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";
            return GetBy(predicate, context, includes);
        }

      
		public bool DisableCache { get; set; }
		public List<SDPerson> GetBy(Expression<Func<SDPerson, bool>> predicate, ContextRequest contextRequest, string includes)
		{
            using (EFContext con = new EFContext()) {
				
				string fkIncludes = "SDOrganization,SDProxyUser";
                List<string> multilangProperties = new List<string>();
				if (predicate == null) predicate = PredicateBuilder.True<SDPerson>();
                var notDeletedExpression = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;
					Expression<Func<SDPerson,bool>> multitenantExpression  = null;
					if (contextRequest != null && contextRequest.Company != null)	                        	
						multitenantExpression = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicate, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression);

#region Old code
/*
				List<SDPerson> result = null;
               BusinessRulesEventArgs<SDPerson>  e = null;
	
				OnGetting(con, e = new BusinessRulesEventArgs<SDPerson>() {  FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null) });

               // OnGetting(con,e = new BusinessRulesEventArgs<SDPerson>() { FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = contextRequest.CustomQuery.FilterExpressionString});
				   if (e != null) {
				    predicate = e.FilterExpression;
						if (e.Cancel)
						{
							context = null;
							 if (e.Items == null) e.Items = new List<SDPerson>();
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                if (predicate == null) predicate = PredicateBuilder.True<SDPerson>();
 				string fkIncludes = "SDOrganization,SDProxyUser";
                if(contextRequest!=null){
					if (contextRequest.CustomQuery != null)
					{
						if (contextRequest.CustomQuery.IncludeForeignKeyPaths != null) {
							if (contextRequest.CustomQuery.IncludeForeignKeyPaths.Value == false)
								fkIncludes = "";
						}
					}
				}
				if (!string.IsNullOrEmpty(includes))
					includes = includes + "," + fkIncludes;
				else
					includes = fkIncludes;
                
                //var es = _repository.Queryable;

                IQueryable<SDPerson> query =  con.SDPersons.AsQueryable();

                                if (!string.IsNullOrEmpty(includes))
                {
                    foreach (string include in includes.Split(char.Parse(",")))
                    {
						if (!string.IsNullOrEmpty(include))
                            query = query.Include(include);
                    }
                }
                    predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
					 	if (!preventSecurityRestrictions)
						{
							if (contextRequest != null )
		                    	if (contextRequest.User !=null )
		                        	if (contextRequest.Company != null){
		                        	
										predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa
 									
									}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				query =query.AsExpandable().Where(predicate);
                query = ContextQueryBuilder<SDPerson>.ApplyContextQuery(query, contextRequest);

                result = query.AsNoTracking().ToList<SDPerson>();
				  
                if (e != null)
                {
                    e.Items = result;
                }
				//if (contextRequest != null ){
				//	 contextRequest = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
					contextRequest.CustomQuery = new CustomQuery();

				//}
				OnTaken(this, e == null ? e =  new BusinessRulesEventArgs<SDPerson>() { Items= result, IncludingComputedLinq = false, ContextRequest = contextRequest,  FilterExpression = predicate } :  e);
  
			

                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
				*/
#endregion
            }
        }


		/*public int Update(List<SDPerson> items, ContextRequest contextRequest)
            {
                int result = 0;
                using (EFContext con = new EFContext())
                {
                   
                

                    foreach (var item in items)
                    {
                        //secMessageToUser messageToUser = new secMessageToUser();
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            item.GetType().GetProperty(prop).SetValue(item, item.GetType().GetProperty(prop).GetValue(item));
                        }
                        //messageToUser.GuidMessageToUser = (Guid)item.GetType().GetProperty("GuidMessageToUser").GetValue(item);

                        var setObject = con.CreateObjectSet<SDPerson>("SDPersons");
                        //messageToUser.Readed = DateTime.UtcNow;
                        setObject.Attach(item);
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            con.ObjectStateManager.GetObjectStateEntry(item).SetModifiedProperty(prop);
                        }
                       
                    }
                    result = con.SaveChanges();

                    


                }
                return result;
            }
           */
		

        public List<SDPerson> GetBy(string predicateString, ContextRequest contextRequest, string includes)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
				


				string computedFields = "";
				string fkIncludes = "SDOrganization,SDProxyUser";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDPerson>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					//if (contextRequest != null && contextRequest.Company != null)                      	
					//	 multitenantExpression = @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))";
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetBy(con, predicateString, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression,computedFields);


	#region Old Code
	/*
				BusinessRulesEventArgs<SDPerson> e = null;

				Filter filter = new Filter();
                if (predicateString.Contains("|"))
                {
                    string ft = GetSpecificFilter(predicateString, contextRequest);
                    if (!string.IsNullOrEmpty(ft))
                        filter.SetFilterPart("ft", ft);
                   
                    contextRequest.FreeText = predicateString.Split(char.Parse("|"))[1];
                    var q1 = predicateString.Split(char.Parse("|"))[0];
                    if (!string.IsNullOrEmpty(q1))
                    {
                        filter.ProcessText(q1);
                    }
                }
                else {
                    filter.ProcessText(predicateString);
                }
				 var includesList = (new List<string>());
                 if (!string.IsNullOrEmpty(includes))
                 {
                     includesList = includes.Split(char.Parse(",")).ToList();
                 }

				List<SDPerson> result = new List<SDPerson>();
         
			QueryBuild(predicateString, filter, con, contextRequest, "getby", includesList);
			 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }
				
				
					OnGetting(con, e == null ? e = new BusinessRulesEventArgs<SDPerson>() { Filter = filter, ContextRequest = contextRequest  } : e );

                  //OnGetting(con,e = new BusinessRulesEventArgs<SDPerson>() {  ContextRequest = contextRequest, FilterExpressionString = predicateString });
			   	if (e != null) {
				    //predicateString = e.GetQueryString();
						if (e.Cancel)
						{
							context = null;
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				//	 else {
                //      predicateString = predicateString.Replace("*extraFreeText*", "").Replace("()","");
                //  }
				//con.EnableChangeTrackingUsingProxies = false;
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                //if (predicate == null) predicate = PredicateBuilder.True<SDPerson>();
 				string fkIncludes = "SDOrganization,SDProxyUser";
                if(contextRequest!=null){
					if (contextRequest.CustomQuery != null)
					{
						if (contextRequest.CustomQuery.IncludeForeignKeyPaths != null) {
							if (contextRequest.CustomQuery.IncludeForeignKeyPaths.Value == false)
								fkIncludes = "";
						}
					}
				}else{
                    contextRequest = new ContextRequest();
                    contextRequest.CustomQuery = new CustomQuery();

                }
				if (!string.IsNullOrEmpty(includes))
					includes = includes + "," + fkIncludes;
				else
					includes = fkIncludes;
                
                //var es = _repository.Queryable;
				IQueryable<SDPerson> query = con.SDPersons.AsQueryable();
		
				// include relations FK
				if(string.IsNullOrEmpty(includes) ){
					includes ="";
				}
				StringBuilder sbQuerySystem = new StringBuilder();
                    //predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted ==null );
				

				//if (!string.IsNullOrEmpty(predicateString))
                //      sbQuerySystem.Append(" And ");
                //sbQuerySystem.Append(" (IsDeleted != true Or IsDeleted = null) ");
				 filter.SetFilterPart("de", "(IsDeleted != true OR IsDeleted = null)");


					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
	                    	if (contextRequest.User !=null )
	                        	if (contextRequest.Company != null ){
	                        		//if (sbQuerySystem.Length > 0)
	                        		//	    			sbQuerySystem.Append( " And ");	
									//sbQuerySystem.Append(@" (GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa

									filter.SetFilterPart("co",@"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @"""))");

								}
						}	
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				//string predicateString = predicate.ToDynamicLinq<SDPerson>();
				//predicateString += sbQuerySystem.ToString();
				filter.CleanAndProcess("");

				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed(); //SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicateString );               
                string predicateWithManyRelations = filter.GetFilterChildren(); //SFSdotNet.Framework.Linq.Utils.CleanPartExpression(predicateString);

                //QueryUtils.BreakeQuery1(predicateString, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
                var _queryable = query.AsQueryable();
				bool includeAll = true; 
                if (!string.IsNullOrEmpty(predicateWithManyRelations))
                    _queryable = _queryable.Where(predicateWithManyRelations, contextRequest.CustomQuery.ExtraParams);
				if (contextRequest.CustomQuery.SpecificProperties.Count > 0)
                {

				includeAll = false; 
                }

				StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append("new (");
                bool existPrev = false;
                foreach (var selected in contextRequest.CustomQuery.SelectedFields.Where(p=> !string.IsNullOrEmpty(p.Linq)))
                {
                    if (existPrev) sbSelect.Append(", ");
                    if (!selected.Linq.Contains(".") && !selected.Linq.StartsWith("it."))
                        sbSelect.Append("it." + selected.Linq);
                    else
                        sbSelect.Append(selected.Linq);
                    existPrev = true;
                }
                sbSelect.Append(")");
                var queryable = _queryable.Select(sbSelect.ToString());                    


     				
                 if (!string.IsNullOrEmpty(predicateWithFKAndComputed))
                    queryable = queryable.Where(predicateWithFKAndComputed, contextRequest.CustomQuery.ExtraParams);

				QueryComplementOptions queryOps = ContextQueryBuilder.ApplyContextQuery(contextRequest);
            	if (!string.IsNullOrEmpty(queryOps.OrderByAndSort)){
					if (queryOps.OrderBy.Contains(".") && !queryOps.OrderBy.StartsWith("it.")) queryOps.OrderBy = "it." + queryOps.OrderBy;
					queryable = queryable.OrderBy(queryOps.OrderByAndSort);
					}
               	if (queryOps.Skip != null)
                {
                    queryable = queryable.Skip(queryOps.Skip.Value);
                }
                if (queryOps.PageSize != null)
                {
                    queryable = queryable.Take (queryOps.PageSize.Value);
                }


                var resultTemp = queryable.AsQueryable().ToListAsync().Result;
                foreach (var item in resultTemp)
                {

				   result.Add(SFSdotNet.Framework.BR.Utils.GetConverted<SDPerson,dynamic>(item, contextRequest.CustomQuery.SelectedFields.Select(p=>p.Name).ToArray()));
                }

			 if (e != null)
                {
                    e.Items = result;
                }
				 contextRequest.CustomQuery = new CustomQuery();
				OnTaken(this, e == null ? e = new BusinessRulesEventArgs<SDPerson>() { Items= result, IncludingComputedLinq = true, ContextRequest = contextRequest, FilterExpressionString  = predicateString } :  e);
  
			
  
                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
	
	*/
	#endregion

            }
        }
		public SDPerson GetFromOperation(string function, string filterString, string usemode, string fields, ContextRequest contextRequest)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
                string computedFields = "";
               // string fkIncludes = "accContpaqiClassification,accProjectConcept,accProjectType,accProxyUser";
                List<string> multilangProperties = new List<string>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
					if (contextRequest != null && contextRequest.Company != null)
					{
						multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
						contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
					}
					 									
					string multiTenantField = "GuidCompany";


                return GetSummaryOperation(con, new SDPerson(), function, filterString, usemode, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields, contextRequest, fields.Split(char.Parse(",")).ToArray());
            }
        }

   protected override void QueryBuild(string predicate, Filter filter, DbContext efContext, ContextRequest contextRequest, string method, List<string> includesList)
      	{
				if (contextRequest.CustomQuery.SpecificProperties.Count == 0)
                {
					contextRequest.CustomQuery.SpecificProperties.Add(SDPerson.PropertyNames.DisplayName);
					contextRequest.CustomQuery.SpecificProperties.Add(SDPerson.PropertyNames.GuidUser);
					contextRequest.CustomQuery.SpecificProperties.Add(SDPerson.PropertyNames.GuidOrganization);
					contextRequest.CustomQuery.SpecificProperties.Add(SDPerson.PropertyNames.GuidCompany);
					contextRequest.CustomQuery.SpecificProperties.Add(SDPerson.PropertyNames.CreatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDPerson.PropertyNames.UpdatedDate);
					contextRequest.CustomQuery.SpecificProperties.Add(SDPerson.PropertyNames.CreatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDPerson.PropertyNames.UpdatedBy);
					contextRequest.CustomQuery.SpecificProperties.Add(SDPerson.PropertyNames.Bytes);
					contextRequest.CustomQuery.SpecificProperties.Add(SDPerson.PropertyNames.IsDeleted);
					contextRequest.CustomQuery.SpecificProperties.Add(SDPerson.PropertyNames.SDOrganization);
					contextRequest.CustomQuery.SpecificProperties.Add(SDPerson.PropertyNames.SDProxyUser);
                    
				}

				if (method == "getby" || method == "sum")
				{
					if (!contextRequest.CustomQuery.SpecificProperties.Contains("GuidPerson")){
						contextRequest.CustomQuery.SpecificProperties.Add("GuidPerson");
					}

					 if (!string.IsNullOrEmpty(contextRequest.CustomQuery.OrderBy))
					{
						string existPropertyOrderBy = contextRequest.CustomQuery.OrderBy;
						if (contextRequest.CustomQuery.OrderBy.Contains("."))
						{
							existPropertyOrderBy = contextRequest.CustomQuery.OrderBy.Split(char.Parse("."))[0];
						}
						if (!contextRequest.CustomQuery.SpecificProperties.Exists(p => p == existPropertyOrderBy))
						{
							contextRequest.CustomQuery.SpecificProperties.Add(existPropertyOrderBy);
						}
					}

				}
				
	bool isFullDetails = contextRequest.IsFromUI("SDPersons", UIActions.GetForDetails);
	string filterForTest = predicate  + filter.GetFilterComplete();

				if (isFullDetails || !string.IsNullOrEmpty(predicate))
            {
            } 

			if (method == "sum")
            {
            } 
			if (contextRequest.CustomQuery.SelectedFields.Count == 0)
            {
				foreach (var selected in contextRequest.CustomQuery.SpecificProperties)
                {
					string linq = selected;
					switch (selected)
                    {

					case "SDOrganization":
					if (includesList.Contains(selected)){
                        linq = "it.SDOrganization as SDOrganization";
					}
                    else
						linq = "iif(it.SDOrganization != null, new (it.SDOrganization.GuidOrganization, it.SDOrganization.FullName), null) as SDOrganization";
 					break;
					case "SDProxyUser":
					if (includesList.Contains(selected)){
                        linq = "it.SDProxyUser as SDProxyUser";
					}
                    else
						linq = "iif(it.SDProxyUser != null, new (it.SDProxyUser.GuidUser, it.SDProxyUser.Email), null) as SDProxyUser";
 					break;
					 
						
					 default:
                            break;
                    }
					contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name=selected, Linq=linq});
					if (method == "getby" || method == "sum")
					{
						if (includesList.Contains(selected))
							includesList.Remove(selected);

					}

				}
			}
				if (method == "getby" || method == "sum")
				{
					foreach (var otherInclude in includesList.Where(p=> !string.IsNullOrEmpty(p)))
					{
						contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name = otherInclude, Linq = "it." + otherInclude +" as " + otherInclude });
					}
				}
				BusinessRulesEventArgs<SDPerson> e = null;
				if (contextRequest.PreventInterceptors == false)
					OnQuerySettings(efContext, e = new BusinessRulesEventArgs<SDPerson>() { Filter = filter, ContextRequest = contextRequest /*, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null)*/ });

				//List<SDPerson> result = new List<SDPerson>();
                 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }

}
		public List<SDPerson> GetBy(Expression<Func<SDPerson, bool>> predicate, bool loadRelations, ContextRequest contextRequest)
        {
			if(!loadRelations)
				return GetBy(predicate, contextRequest);
			else
				return GetBy(predicate, contextRequest, "SDAreaPersons,SDCases");

        }

        public List<SDPerson> GetBy(Expression<Func<SDPerson, bool>> predicate, int? pageSize, int? page, string orderBy, SFSdotNet.Framework.Data.SortDirection? sortDirection)
        {
            return GetBy(predicate, new ContextRequest() { CustomQuery = new CustomQuery() { Page = page, PageSize = pageSize, OrderBy = orderBy, SortDirection = sortDirection } });
        }
        public List<SDPerson> GetBy(Expression<Func<SDPerson, bool>> predicate)
        {

			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
			contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
			            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            contextRequest.CustomQuery.FilterExpressionString = null;
            return this.GetBy(predicate, contextRequest, "");
        }
        #endregion
        #region Dynamic String
		protected override string GetSpecificFilter(string filter, ContextRequest contextRequest) {
            string result = "";
		    //string linqFilter = String.Empty;
            string freeTextFilter = String.Empty;
            if (filter.Contains("|"))
            {
               // linqFilter = filter.Split(char.Parse("|"))[0];
                freeTextFilter = filter.Split(char.Parse("|"))[1];
            }
            //else {
            //    freeTextFilter = filter;
            //}
            //else {
            //    linqFilter = filter;
            //}
			// linqFilter = SFSdotNet.Framework.Linq.Utils.ReplaceCustomDateFilters(linqFilter);
            //string specificFilter = linqFilter;
            if (!string.IsNullOrEmpty(freeTextFilter))
            {
                System.Text.StringBuilder sbCont = new System.Text.StringBuilder();
                /*if (specificFilter.Length > 0)
                {
                    sbCont.Append(" AND ");
                    sbCont.Append(" ({0})");
                }
                else
                {
                    sbCont.Append("{0}");
                }*/
                //var words = freeTextFilter.Split(char.Parse(" "));
				var word = freeTextFilter;
                System.Text.StringBuilder sbSpec = new System.Text.StringBuilder();
                 int nWords = 1;
				/*foreach (var word in words)
                {
					if (word.Length > 0){
                    if (sbSpec.Length > 0) sbSpec.Append(" AND ");
					if (words.Length > 1) sbSpec.Append("("); */
					
	
					
					
					
									
					sbSpec.Append(string.Format(@"DisplayName.Contains(""{0}"")", word));
					

					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
	
					
								sbSpec.Append(" OR ");
					
					//if (sbSpec.Length > 2)
					//	sbSpec.Append(" OR "); // test
					sbSpec.Append(string.Format(@"it.SDOrganization.FullName.Contains(""{0}"")", word)+" OR "+string.Format(@"it.SDProxyUser.Email.Contains(""{0}"")", word));
								 //sbSpec.Append("*extraFreeText*");

                    /*if (words.Length > 1) sbSpec.Append(")");
					
					nWords++;

					}

                }*/
                //specificFilter = string.Format("{0}{1}", specificFilter, string.Format(sbCont.ToString(), sbSpec.ToString()));
                                 result = sbSpec.ToString();  
            }
			//result = specificFilter;
			
			return result;

		}
	
			public List<SDPerson> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params object[] extraParams)
        {
			return GetBy(filter, pageSize, page, orderBy, orderDir,  null, extraParams);
		}
           public List<SDPerson> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, string usemode, params object[] extraParams)
            { 
                return GetBy(filter, pageSize, page, orderBy, orderDir, usemode, null, extraParams);
            }


		public List<SDPerson> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  string usemode, ContextRequest context, params object[] extraParams)

        {

            // string freetext = null;
            //if (filter.Contains("|"))
            //{
            //    int parts = filter.Split(char.Parse("|")).Count();
            //    if (parts > 1)
            //    {

            //        freetext = filter.Split(char.Parse("|"))[1];
            //    }
            //}
		
            //string specificFilter = "";
            //if (!string.IsNullOrEmpty(filter))
            //  specificFilter=  GetSpecificFilter(filter);
            if (string.IsNullOrEmpty(orderBy))
            {
			                orderBy = "UpdatedDate";
            }
			//orderDir = "desc";
			SFSdotNet.Framework.Data.SortDirection direction = SFSdotNet.Framework.Data.SortDirection.Ascending;
            if (!string.IsNullOrEmpty(orderDir))
            {
                if (orderDir == "desc")
                    direction = SFSdotNet.Framework.Data.SortDirection.Descending;
            }
            if (context == null)
                context = new ContextRequest();
			

             context.UseMode = usemode;
             if (context.CustomQuery == null )
                context.CustomQuery =new SFSdotNet.Framework.My.CustomQuery();

 
                context.CustomQuery.ExtraParams = extraParams;

                    context.CustomQuery.OrderBy = orderBy;
                   context.CustomQuery.SortDirection = direction;
                   context.CustomQuery.Page = page;
                  context.CustomQuery.PageSize = pageSize;
               

            

            if (!preventSecurityRestrictions) {
			 if (context.CurrentContext == null)
                {
					if (SFSdotNet.Framework.My.Context.CurrentContext != null &&  SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
					{
						context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
						context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

					}
					else {
						throw new Exception("The security rule require a specific user and company");
					}
				}
            }
            return GetBy(filter, context);
  
        }


        public List<SDPerson> GetBy(string strWhere, ContextRequest contextRequest)
        {
        	#region old code
				
				 //Expression<Func<tvsReservationTransport, bool>> predicate = null;
				string strWhereClean = strWhere.Replace("*extraFreeText*", "").Replace("()", "");
                //if (!string.IsNullOrEmpty(strWhereClean)){

                //    object[] extraParams = null;
                //    //if (contextRequest != null )
                //    //    if (contextRequest.CustomQuery != null )
                //    //        extraParams = contextRequest.CustomQuery.ExtraParams;
                //    //predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<tvsReservationTransport, bool>(strWhereClean, extraParams != null? extraParams.Cast<Guid>(): null);				
                //}
				 if (contextRequest == null)
                {
                    contextRequest = new ContextRequest();
                    if (contextRequest.CustomQuery == null)
                        contextRequest.CustomQuery = new CustomQuery();
                }
                  if (!preventSecurityRestrictions) {
					if (contextRequest.User == null || contextRequest.Company == null)
                      {
                     if (SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
                     {
                         contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                         contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

                     }
                     else {
                         throw new Exception("The security rule require a specific User and Company ");
                     }
					 }
                 }
            contextRequest.CustomQuery.FilterExpressionString = strWhere;
				//return GetBy(predicate, contextRequest);  

			#endregion				
				
                    return GetBy(strWhere, contextRequest, "");  


        }
       public List<SDPerson> GetBy(string strWhere)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
			
            return GetBy(strWhere, context, null);
        }

        public List<SDPerson> GetBy(string strWhere, string includes)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
            return GetBy(strWhere, context, includes);
        }

        #endregion
        #endregion
		
		  #region SaveOrUpdate
        
 		 public SDPerson Create(SDPerson entity)
        {
				//ObjectContext context = null;
				    if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: Create");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

				return this.Create(entity, contextRequest);


        }
        
       
        public SDPerson Create(SDPerson entity, ContextRequest contextRequest)
        {
		
		bool graph = false;
	
				bool preventPartial = false;
                if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
               
			using (EFContext con = new EFContext()) {

				SDPerson itemForSave = new SDPerson();
#region Autos
		if(!preventSecurityRestrictions){

				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion
               BusinessRulesEventArgs<SDPerson> e = null;
			    if (preventPartial == false )
                OnCreating(this,e = new BusinessRulesEventArgs<SDPerson>() { ContextRequest = contextRequest, Item=entity });
				   if (e != null) {
						if (e.Cancel)
						{
							context = null;
							return e.Item;

						}
					}

                    if (entity.GuidPerson == Guid.Empty)
                   {
                       entity.GuidPerson = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   itemForSave.GuidPerson = entity.GuidPerson;
				  
		
			itemForSave.GuidPerson = entity.GuidPerson;

			itemForSave.DisplayName = entity.DisplayName;

			itemForSave.GuidCompany = entity.GuidCompany;

			itemForSave.CreatedDate = entity.CreatedDate;

			itemForSave.UpdatedDate = entity.UpdatedDate;

			itemForSave.CreatedBy = entity.CreatedBy;

			itemForSave.UpdatedBy = entity.UpdatedBy;

			itemForSave.Bytes = entity.Bytes;

			itemForSave.IsDeleted = entity.IsDeleted;

				
				con.SDPersons.Add(itemForSave);







					if (entity.SDOrganization != null)
					{
						var sDOrganization = new SDOrganization();
						sDOrganization.GuidOrganization = entity.SDOrganization.GuidOrganization;
						itemForSave.SDOrganization = sDOrganization;
						SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDOrganization>(con, itemForSave.SDOrganization);
			
					}




					if (entity.SDProxyUser != null)
					{
						var sDProxyUser = new SDProxyUser();
						sDProxyUser.GuidUser = entity.SDProxyUser.GuidUser;
						itemForSave.SDProxyUser = sDProxyUser;
						SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDProxyUser>(con, itemForSave.SDProxyUser);
			
					}



                
				con.ChangeTracker.Entries().Where(p => p.Entity != itemForSave && p.State != EntityState.Unchanged).ForEach(p => p.State = EntityState.Detached);

				con.Entry<SDPerson>(itemForSave).State = EntityState.Added;

				con.SaveChanges();

					 
				

				//itemResult = entity;
                //if (e != null)
                //{
                 //   e.Item = itemResult;
                //}
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false )
                OnCreated(this, e == null ? e = new BusinessRulesEventArgs<SDPerson>() { ContextRequest = contextRequest, Item = entity } : e);



                if (e != null && e.Item != null )
                {
                    return e.Item;
                }
                              return entity;
			}
            
        }
        //BusinessRulesEventArgs<SDPerson> e = null;
        public void Create(List<SDPerson> entities)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            Create(entities, contextRequest);
        }
        public void Create(List<SDPerson> entities, ContextRequest contextRequest)
        
        {
			ObjectContext context = null;
            	foreach (SDPerson entity in entities)
				{
					this.Create(entity, contextRequest);
				}
        }
		  public void CreateOrUpdateBulk(List<SDPerson> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "cu", contextRequest);
        }

        private void CreateOrUpdateBulk(List<SDPerson> entities, string actionKey, ContextRequest contextRequest)
        {
			if (entities.Count() > 0){
            bool graph = false;

            bool preventPartial = false;
            if (contextRequest != null && contextRequest.PreventInterceptors == true)
            {
                preventPartial = true;
            }
            foreach (var entity in entities)
            {
                    if (entity.GuidPerson == Guid.Empty)
                   {
                       entity.GuidPerson = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   
				  


#region Autos
		if(!preventSecurityRestrictions){


 if (actionKey != "u")
                        {
				if (entity.CreatedDate == null )
			entity.CreatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.CreatedBy = contextRequest.User.GuidUser;


}
				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	
			if (contextRequest != null)
				if(contextRequest.User != null)
					if (contextRequest.Company != null)
						entity.GuidCompany = contextRequest.Company.GuidCompany;
	


			}
#endregion


		
			//entity.GuidPerson = entity.GuidPerson;

			//entity.DisplayName = entity.DisplayName;

			//entity.GuidCompany = entity.GuidCompany;

			//entity.CreatedDate = entity.CreatedDate;

			//entity.UpdatedDate = entity.UpdatedDate;

			//entity.CreatedBy = entity.CreatedBy;

			//entity.UpdatedBy = entity.UpdatedBy;

			//entity.Bytes = entity.Bytes;

			//entity.IsDeleted = entity.IsDeleted;

				
				







				    if (entity.SDOrganization != null)
					{
						//var sDOrganization = new SDOrganization();
						entity.GuidOrganization = entity.SDOrganization.GuidOrganization;
						//entity.SDOrganization = sDOrganization;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDOrganization>(con, itemForSave.SDOrganization);
			
					}




				    if (entity.SDProxyUser != null)
					{
						//var sDProxyUser = new SDProxyUser();
						entity.GuidUser = entity.SDProxyUser.GuidUser;
						//entity.SDProxyUser = sDProxyUser;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDProxyUser>(con, itemForSave.SDProxyUser);
			
					}



                
				

					 
				

				//itemResult = entity;
            }
            using (EFContext con = new EFContext())
            {
                 if (actionKey == "c")
                    {
                        context.BulkInsert(entities);
                    }else if ( actionKey == "u")
                    {
                        context.BulkUpdate(entities);
                    }else
                    {
                        context.BulkInsertOrUpdate(entities);
                    }
            }

			}
        }
	
		public void CreateBulk(List<SDPerson> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "c", contextRequest);
        }


		public void UpdateAgile(SDPerson item, params string[] fields)
         {
			UpdateAgile(item, null, fields);
        }
		public void UpdateAgile(SDPerson item, ContextRequest contextRequest, params string[] fields)
         {
            
             ContextRequest contextNew = null;
             if (contextRequest != null)
             {
                 contextNew = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
                 if (fields != null && fields.Length > 0)
                 {
                     contextNew.CustomQuery.SpecificProperties  = fields.ToList();
                 }
                 else if(contextRequest.CustomQuery.SpecificProperties.Count > 0)
                 {
                     fields = contextRequest.CustomQuery.SpecificProperties.ToArray();
                 }
             }
			

		   using (EFContext con = new EFContext())
            {



               
					List<string> propForCopy = new List<string>();
                    propForCopy.AddRange(fields);
                    
					  
					if (!propForCopy.Contains("GuidPerson"))
						propForCopy.Add("GuidPerson");
					if (!propForCopy.Contains("DisplayName"))
						propForCopy.Add("DisplayName");

					var itemForUpdate = SFSdotNet.Framework.BR.Utils.GetConverted<SDPerson,SDPerson>(item, propForCopy.ToArray());
					 itemForUpdate.GuidPerson = item.GuidPerson;
                  var setT = con.Set<SDPerson>().Attach(itemForUpdate);

					if (fields.Count() > 0)
					  {
						  item.ModifiedProperties = fields;
					  }
                    foreach (var property in item.ModifiedProperties)
					{						
                        if (property != "GuidPerson")
                             con.Entry(setT).Property(property).IsModified = true;

                    }

                
               int result = con.SaveChanges();
               if (result != 1)
               {
                   SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: 1");
               }


            }

			OnUpdatedAgile(this, new BusinessRulesEventArgs<SDPerson>() { Item = item, ContextRequest = contextNew  });

         }
		public void UpdateBulk(List<SDPerson>  items, params string[] fields)
         {
             SFSdotNet.Framework.My.ContextRequest req = new SFSdotNet.Framework.My.ContextRequest();
             req.CustomQuery = new SFSdotNet.Framework.My.CustomQuery();
             foreach (var field in fields)
             {
                 req.CustomQuery.SpecificProperties.Add(field);
             }
             UpdateBulk(items, req);

         }

		 public void DeleteBulk(List<SDPerson> entities, ContextRequest contextRequest = null)
        {

            using (EFContext con = new EFContext())
            {
                foreach (var entity in entities)
                {
					var entityProxy = new SDPerson() { GuidPerson = entity.GuidPerson };

                    con.Entry<SDPerson>(entityProxy).State = EntityState.Deleted;

                }

                int result = con.SaveChanges();
                if (result != entities.Count)
                {
                    SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: " + entities.Count.ToString());
                }
            }

        }

        public void UpdateBulk(List<SDPerson> items, ContextRequest contextRequest)
        {
            if (items.Count() > 0){

			 foreach (var entity in items)
            {


#region Autos
		if(!preventSecurityRestrictions){

				if (entity.UpdatedDate == null )
			entity.UpdatedDate = DateTime.Now.ToUniversalTime();
		if(contextRequest.User != null)
			entity.UpdatedBy = contextRequest.User.GuidUser;
	



			}
#endregion








				    if (entity.SDOrganization != null)
					{
						//var sDOrganization = new SDOrganization();
						entity.GuidOrganization = entity.SDOrganization.GuidOrganization;
						//entity.SDOrganization = sDOrganization;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDOrganization>(con, itemForSave.SDOrganization);
			
					}




				    if (entity.SDProxyUser != null)
					{
						//var sDProxyUser = new SDProxyUser();
						entity.GuidUser = entity.SDProxyUser.GuidUser;
						//entity.SDProxyUser = sDProxyUser;
						//SFSdotNet.Framework.BR.Utils.TryAttachFKRelation<SDProxyUser>(con, itemForSave.SDProxyUser);
			
					}



				}
				using (EFContext con = new EFContext())
				{

                    
                
                   con.BulkUpdate(items);

				}
             
			}	  
        }

         public SDPerson Update(SDPerson entity)
        {
            if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return Update(entity, contextRequest);
        }
       
         public SDPerson Update(SDPerson entity, ContextRequest contextRequest)
        {
		 if ((System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null) && contextRequest == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Update");
            }
            if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            }

			
				SDPerson  itemResult = null;

	
			//entity.UpdatedDate = DateTime.Now.ToUniversalTime();
			//if(contextRequest.User != null)
				//entity.UpdatedBy = contextRequest.User.GuidUser;

//	    var oldentity = GetBy(p => p.GuidPerson == entity.GuidPerson, contextRequest).FirstOrDefault();
	//	if (oldentity != null) {
		
          //  entity.CreatedDate = oldentity.CreatedDate;
    //        entity.CreatedBy = oldentity.CreatedBy;
	
      //      entity.GuidCompany = oldentity.GuidCompany;
	
			

	
		//}

			 using( EFContext con = new EFContext()){
				BusinessRulesEventArgs<SDPerson> e = null;
				bool preventPartial = false; 
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false)
                OnUpdating(this,e = new BusinessRulesEventArgs<SDPerson>() { ContextRequest = contextRequest, Item=entity});
				   if (e != null) {
						if (e.Cancel)
						{
							//outcontext = null;
							return e.Item;

						}
					}

	string includes = "SDOrganization,SDProxyUser";
	IQueryable < SDPerson > query = con.SDPersons.AsQueryable();
	foreach (string include in includes.Split(char.Parse(",")))
                       {
                           if (!string.IsNullOrEmpty(include))
                               query = query.Include(include);
                       }
	var oldentity = query.FirstOrDefault(p => p.GuidPerson == entity.GuidPerson);
	if (oldentity.DisplayName != entity.DisplayName)
		oldentity.DisplayName = entity.DisplayName;

				//if (entity.UpdatedDate == null || (contextRequest != null && contextRequest.IsFromUI("SDPersons", UIActions.Updating)))
			oldentity.UpdatedDate = DateTime.Now.ToUniversalTime();
			if(contextRequest.User != null)
				oldentity.UpdatedBy = contextRequest.User.GuidUser;

           


				if (entity.SDAreaPersons != null)
                {
                    foreach (var item in entity.SDAreaPersons)
                    {


                        
                    }
					
                    

                }


				if (entity.SDCases != null)
                {
                    foreach (var item in entity.SDCases)
                    {


                        
                    }
					
                    

                }


						if (SFSdotNet.Framework.BR.Utils.HasRelationPropertyChanged(oldentity.SDOrganization, entity.SDOrganization, "GuidOrganization"))
							oldentity.SDOrganization = entity.SDOrganization != null? new SDOrganization(){ GuidOrganization = entity.SDOrganization.GuidOrganization } :null;

                


						if (SFSdotNet.Framework.BR.Utils.HasRelationPropertyChanged(oldentity.SDProxyUser, entity.SDProxyUser, "GuidUser"))
							oldentity.SDProxyUser = entity.SDProxyUser != null? new SDProxyUser(){ GuidUser = entity.SDProxyUser.GuidUser } :null;

                


				con.ChangeTracker.Entries().Where(p => p.Entity != oldentity).ForEach(p => p.State = EntityState.Unchanged);  
				  
				con.SaveChanges();
        
					 
					
               
				itemResult = entity;
				if(preventPartial == false)
					OnUpdated(this, e = new BusinessRulesEventArgs<SDPerson>() { ContextRequest = contextRequest, Item=itemResult });

              	return itemResult;
			}
			  
        }
        public SDPerson Save(SDPerson entity)
        {
			return Create(entity);
        }
        public int Save(List<SDPerson> entities)
        {
			 Create(entities);
            return entities.Count;

        }
        #endregion
        #region Delete
        public void Delete(SDPerson entity)
        {
				this.Delete(entity, null);
			
        }
		 public void Delete(SDPerson entity, ContextRequest contextRequest)
        {
				
				  List<SDPerson> entities = new List<SDPerson>();
				   entities.Add(entity);
				this.Delete(entities, contextRequest);
			
        }

         public void Delete(string query, Guid[] guids, ContextRequest contextRequest)
        {
			var br = new SDPersonsBR(true);
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);
            
            Delete(items, contextRequest);

        }
        public void Delete(SDPerson entity,  ContextRequest contextRequest, BusinessRulesEventArgs<SDPerson> e = null)
        {
			
				using(EFContext con = new EFContext())
                 {
				
               	BusinessRulesEventArgs<SDPerson> _e = null;
               List<SDPerson> _items = new List<SDPerson>();
                _items.Add(entity);
                if (e == null || e.PreventPartialPropagate == false)
                {
                    OnDeleting(this, _e = (e == null ? new BusinessRulesEventArgs<SDPerson>() { ContextRequest = contextRequest, Item = entity, Items = null  } : e));
                }
                if (_e != null)
                {
                    if (_e.Cancel)
						{
							context = null;
							return;

						}
					}


				
									//IsDeleted
					bool logicDelete = true;
					if (entity.IsDeleted != null)
					{
						if (entity.IsDeleted.Value)
							logicDelete = false;
					}
					if (logicDelete)
					{
											//entity = GetBy(p =>, contextRequest).FirstOrDefault();
						entity.IsDeleted = true;
						if (contextRequest != null && contextRequest.User != null)
							entity.UpdatedBy = contextRequest.User.GuidUser;
                        entity.UpdatedDate = DateTime.UtcNow;
						UpdateAgile(entity, "IsDeleted","UpdatedBy","UpdatedDate");

						
					}
					else {
					con.Entry<SDPerson>(entity).State = EntityState.Deleted;
					con.SaveChanges();
				
				 
					}
								
				
				 
					
					
			if (e == null || e.PreventPartialPropagate == false)
                {

                    if (_e == null)
                        _e = new BusinessRulesEventArgs<SDPerson>() { ContextRequest = contextRequest, Item = entity, Items = null };

                    OnDeleted(this, _e);
                }

				//return null;
			}
        }
 public void UnDelete(string query, Guid[] guids, ContextRequest contextRequest)
        {
            var br = new SDPersonsBR(true);
            contextRequest.CustomQuery.IncludeDeleted = true;
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);

            foreach (var item in items)
            {
                item.IsDeleted = false;
						if (contextRequest != null && contextRequest.User != null)
							item.UpdatedBy = contextRequest.User.GuidUser;
                        item.UpdatedDate = DateTime.UtcNow;
            }

            UpdateBulk(items, "IsDeleted","UpdatedBy","UpdatedDate");
        }

         public void Delete(List<SDPerson> entities,  ContextRequest contextRequest = null )
        {
				
			 BusinessRulesEventArgs<SDPerson> _e = null;

                OnDeleting(this, _e = new BusinessRulesEventArgs<SDPerson>() { ContextRequest = contextRequest, Item = null, Items = entities });
                if (_e != null)
                {
                    if (_e.Cancel)
                    {
                        context = null;
                        return;

                    }
                }
                bool allSucced = true;
                BusinessRulesEventArgs<SDPerson> eToChilds = new BusinessRulesEventArgs<SDPerson>();
                if (_e != null)
                {
                    eToChilds = _e;
                }
                else
                {
                    eToChilds = new BusinessRulesEventArgs<SDPerson>() { ContextRequest = contextRequest, Item = (entities.Count == 1 ? entities[0] : null), Items = entities };
                }
				foreach (SDPerson item in entities)
				{
					try
                    {
                        this.Delete(item, contextRequest, e: eToChilds);
                    }
                    catch (Exception ex)
                    {
                        SFSdotNet.Framework.My.EventLog.Error(ex);
                        allSucced = false;
                    }
				}
				if (_e == null)
                    _e = new BusinessRulesEventArgs<SDPerson>() { ContextRequest = contextRequest, CountResult = entities.Count, Item = null, Items = entities };
                OnDeleted(this, _e);

			
        }
        #endregion
 
        #region GetCount
		 public int GetCount(Expression<Func<SDPerson, bool>> predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

			return GetCount(predicate, contextRequest);
		}
        public int GetCount(Expression<Func<SDPerson, bool>> predicate, ContextRequest contextRequest)
        {


		
		 using (EFContext con = new EFContext())
            {


				if (predicate == null) predicate = PredicateBuilder.True<SDPerson>();
           		predicate = predicate.And(p => p.IsDeleted != true || p.IsDeleted == null);
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    		if (contextRequest.User !=null )
                        		if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
									predicate = predicate.And(p => p.GuidCompany == contextRequest.Company.GuidCompany); //todo: multiempresa

								}
						}
						if (preventSecurityRestrictions) preventSecurityRestrictions= false;
				
				IQueryable<SDPerson> query = con.SDPersons.AsQueryable();
                return query.AsExpandable().Count(predicate);

			
				}
			

        }
		  public int GetCount(string predicate,  ContextRequest contextRequest)
         {
             return GetCount(predicate, null, contextRequest);
         }

         public int GetCount(string predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return GetCount(predicate, contextRequest);
        }
		 public int GetCount(string predicate, string usemode){
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
				return GetCount( predicate,  usemode,  contextRequest);
		 }
        public int GetCount(string predicate, string usemode, ContextRequest contextRequest){

		using (EFContext con = new EFContext()) {
				string computedFields = "";
				string fkIncludes = "SDOrganization,SDProxyUser";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDPerson>();
                var notDeletedExpression = "(IsDeleted != true OR IsDeleted = null)";
				string isDeletedField = "IsDeleted";
	
					bool sharedAndMultiTenant = false;	  
					string multitenantExpression = null;
				if (contextRequest != null && contextRequest.Company != null)
				 {
                    multitenantExpression = @"(GuidCompany = @GuidCompanyMultiTenant)";
                    contextRequest.CustomQuery.SetParam("GuidCompanyMultiTenant", new Nullable<Guid>(contextRequest.Company.GuidCompany));
                }
					 									
					string multiTenantField = "GuidCompany";

                
                return GetCount(con, predicate, usemode, contextRequest, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields);

			}
			#region old code
			 /* string freetext = null;
            Filter filter = new Filter();

              if (predicate.Contains("|"))
              {
                 
                  filter.SetFilterPart("ft", GetSpecificFilter(predicate, contextRequest));
                 
                  filter.ProcessText(predicate.Split(char.Parse("|"))[0]);
                  freetext = predicate.Split(char.Parse("|"))[1];

				  if (!string.IsNullOrEmpty(freetext) && string.IsNullOrEmpty(contextRequest.FreeText))
                  {
                      contextRequest.FreeText = freetext;
                  }
              }
              else {
                  filter.ProcessText(predicate);
              }
			   predicate = filter.GetFilterComplete();
			// BusinessRulesEventArgs<SDPerson>  e = null;
           	using (EFContext con = new EFContext())
			{
			
			

			 QueryBuild(predicate, filter, con, contextRequest, "count", new List<string>());


			
			BusinessRulesEventArgs<SDPerson> e = null;

			contextRequest.FreeText = freetext;
			contextRequest.UseMode = usemode;
            OnCounting(this, e = new BusinessRulesEventArgs<SDPerson>() {  Filter =filter, ContextRequest = contextRequest });
            if (e != null)
            {
                if (e.Cancel)
                {
                    context = null;
                    return e.CountResult;

                }

            

            }
			
			StringBuilder sbQuerySystem = new StringBuilder();
		
					
                    filter.SetFilterPart("de","(IsDeleted != true OR IsDeleted == null)");
			
					if (!preventSecurityRestrictions)
						{
						if (contextRequest != null )
                    	if (contextRequest.User !=null )
                        	if (contextRequest.Company != null && contextRequest.CustomQuery.IncludeAllCompanies == false){
                        		
								filter.SetFilterPart("co", @"(GuidCompany = Guid(""" + contextRequest.Company.GuidCompany + @""")) "); //todo: multiempresa
						
						
							}
							
							}
							if (preventSecurityRestrictions) preventSecurityRestrictions= false;
		
				   
                 filter.CleanAndProcess("");
				//string predicateWithFKAndComputed = SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicate );               
				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed();
               string predicateWithManyRelations = filter.GetFilterChildren();
			   ///QueryUtils.BreakeQuery1(predicate, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
			   predicate = filter.GetFilterComplete();
               if (!string.IsNullOrEmpty(predicate))
               {
				
					
                    return con.SDPersons.Where(predicate).Count();
					
                }else
                    return con.SDPersons.Count();
					
			}*/
			#endregion

		}
         public int GetCount()
        {
            return GetCount(p => true);
        }
        #endregion
        
         


        public void Delete(List<SDPerson.CompositeKey> entityKeys)
        {

            List<SDPerson> items = new List<SDPerson>();
            foreach (var itemKey in entityKeys)
            {
                items.Add(GetByKey(itemKey.GuidPerson));
            }

            Delete(items);

        }
		 public void UpdateAssociation(string relation, string relationValue, string query, Guid[] ids, ContextRequest contextRequest)
        {
            var items = GetBy(query, null, null, null, null, null, contextRequest, ids);
			 var module = SFSdotNet.Framework.Cache.Caching.SystemObjects.GetModuleByKey(SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(System.Web.HttpContext.Current.Request.RequestContext, "area"));
           
            foreach (var item in items)
            {
			  Guid ? guidRelationValue = null ;
                if (!string.IsNullOrEmpty(relationValue)){
                    guidRelationValue = Guid.Parse(relationValue );
                }

				 if (relation.Contains("."))
                {
                    var partsWithOtherProp = relation.Split(char.Parse("|"));
                    var parts = partsWithOtherProp[0].Split(char.Parse("."));

                    string proxyRelName = parts[0];
                    string proxyProperty = parts[1];
                    string proxyPropertyKeyNameFromOther = partsWithOtherProp[1];
                    //string proxyPropertyThis = parts[2];

                    var prop = item.GetType().GetProperty(proxyRelName);
                    //var entityInfo = //SFSdotNet.Framework.
                    // descubrir el tipo de entidad dentro de la colección
                    Type typeEntityInList = SFSdotNet.Framework.Entities.Utils.GetTypeFromList(prop);
                    var newProxyItem = Activator.CreateInstance(typeEntityInList);
                    var propThisForSet = newProxyItem.GetType().GetProperty(proxyProperty);
                    var entityInfoOfProxy = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(typeEntityInList);
                    var propOther = newProxyItem.GetType().GetProperty(proxyPropertyKeyNameFromOther);

                    if (propThisForSet != null && entityInfoOfProxy != null && propOther != null )
                    {
                        var entityInfoThis = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(item.GetType());
                        var valueThisId = item.GetType().GetProperty(entityInfoThis.PropertyKeyName).GetValue(item);
                        if (valueThisId != null)
                            propThisForSet.SetValue(newProxyItem, valueThisId);
                        propOther.SetValue(newProxyItem, Guid.Parse(relationValue));
                        
                        var entityNameProp = newProxyItem.GetType().GetField("EntityName").GetValue(null);
                        var entitySetNameProp = newProxyItem.GetType().GetField("EntitySetName").GetValue(null);

                        SFSdotNet.Framework.Apps.Integration.CreateItemFromApp(entityNameProp.ToString(), entitySetNameProp.ToString(), module.ModuleNamespace, newProxyItem, contextRequest);

                    }

                    // crear una instancia del tipo de entidad
                    // llenar los datos y registrar nuevo


                }
                else
                {
                var prop = item.GetType().GetProperty(relation);
                var entityInfo = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(prop.PropertyType);
                if (entityInfo != null)
                {
                    var ins = Activator.CreateInstance(prop.PropertyType);
                   if (guidRelationValue != null)
                    {
                        prop.PropertyType.GetProperty(entityInfo.PropertyKeyName).SetValue(ins, guidRelationValue);
                        item.GetType().GetProperty(relation).SetValue(item, ins);
                    }
                    else
                    {
                        item.GetType().GetProperty(relation).SetValue(item, null);
                    }

                    Update(item, contextRequest);
                }

				}
            }
        }
		
	}
		public partial class SDProxyUsersBR:BRBase<SDProxyUser>{
	 	
           
		 #region Partial methods

           partial void OnUpdating(object sender, BusinessRulesEventArgs<SDProxyUser> e);

            partial void OnUpdated(object sender, BusinessRulesEventArgs<SDProxyUser> e);
			partial void OnUpdatedAgile(object sender, BusinessRulesEventArgs<SDProxyUser> e);

            partial void OnCreating(object sender, BusinessRulesEventArgs<SDProxyUser> e);
            partial void OnCreated(object sender, BusinessRulesEventArgs<SDProxyUser> e);

            partial void OnDeleting(object sender, BusinessRulesEventArgs<SDProxyUser> e);
            partial void OnDeleted(object sender, BusinessRulesEventArgs<SDProxyUser> e);

            partial void OnGetting(object sender, BusinessRulesEventArgs<SDProxyUser> e);
            protected override void OnVirtualGetting(object sender, BusinessRulesEventArgs<SDProxyUser> e)
            {
                OnGetting(sender, e);
            }
			protected override void OnVirtualCounting(object sender, BusinessRulesEventArgs<SDProxyUser> e)
            {
                OnCounting(sender, e);
            }
			partial void OnTaken(object sender, BusinessRulesEventArgs<SDProxyUser> e);
			protected override void OnVirtualTaken(object sender, BusinessRulesEventArgs<SDProxyUser> e)
            {
                OnTaken(sender, e);
            }

            partial void OnCounting(object sender, BusinessRulesEventArgs<SDProxyUser> e);
 
			partial void OnQuerySettings(object sender, BusinessRulesEventArgs<SDProxyUser> e);
          
            #endregion
			
		private static SDProxyUsersBR singlenton =null;
				public static SDProxyUsersBR NewInstance(){
					return  new SDProxyUsersBR();
					
				}
		public static SDProxyUsersBR Instance{
			get{
				if (singlenton == null)
					singlenton = new SDProxyUsersBR();
				return singlenton;
			}
		}
		//private bool preventSecurityRestrictions = false;
		 public bool PreventAuditTrail { get; set;  }
		#region Fields
        EFContext context = null;
        #endregion
        #region Constructor
        public SDProxyUsersBR()
        {
            context = new EFContext();
        }
		 public SDProxyUsersBR(bool preventSecurity)
            {
                this.preventSecurityRestrictions = preventSecurity;
				context = new EFContext();
            }
        #endregion
		
		#region Get

 		public IQueryable<SDProxyUser> Get()
        {
            using (EFContext con = new EFContext())
            {
				
				var query = con.SDProxyUsers.AsQueryable();
                con.Configuration.ProxyCreationEnabled = false;

                //query = ContextQueryBuilder<Nutrient>.ApplyContextQuery(query, contextRequest);

                return query;




            }

        }
		


 	
		public List<SDProxyUser> GetAll()
        {
            return this.GetBy(p => true);
        }
        public List<SDProxyUser> GetAll(string includes)
        {
            return this.GetBy(p => true, includes);
        }
        public SDProxyUser GetByKey(Guid guidUser)
        {
            return GetByKey(guidUser, true);
        }
        public SDProxyUser GetByKey(Guid guidUser, bool loadIncludes)
        {
            SDProxyUser item = null;
			var query = PredicateBuilder.True<SDProxyUser>();
                    
			string strWhere = @"GuidUser = Guid(""" + guidUser.ToString()+@""")";
            Expression<Func<SDProxyUser, bool>> predicate = null;
            //if (!string.IsNullOrEmpty(strWhere))
            //    predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDProxyUser, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
			 ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
            contextRequest.CustomQuery.FilterExpressionString = strWhere;

			//item = GetBy(predicate, loadIncludes, contextRequest).FirstOrDefault();
			item = GetBy(strWhere,loadIncludes,contextRequest).FirstOrDefault();
            return item;
        }
         public List<SDProxyUser> GetBy(string strWhere, bool loadRelations, ContextRequest contextRequest)
        {
            if (!loadRelations)
                return GetBy(strWhere, contextRequest);
            else
                return GetBy(strWhere, contextRequest, "");

        }
		  public List<SDProxyUser> GetBy(string strWhere, bool loadRelations)
        {
              if (!loadRelations)
                return GetBy(strWhere, new ContextRequest());
            else
                return GetBy(strWhere, new ContextRequest(), "");

        }
		         public SDProxyUser GetByKey(Guid guidUser, params Expression<Func<SDProxyUser, object>>[] includes)
        {
            SDProxyUser item = null;
			string strWhere = @"GuidUser = Guid(""" + guidUser.ToString()+@""")";
          Expression<Func<SDProxyUser, bool>> predicate = p=> p.GuidUser == guidUser;
           // if (!string.IsNullOrEmpty(strWhere))
           //     predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<SDProxyUser, bool>(strWhere.Replace("*extraFreeText*", "").Replace("()",""));
			
        item = GetBy(predicate, includes).FirstOrDefault();
         ////   item = GetBy(strWhere,includes).FirstOrDefault();
			return item;

        }
        public SDProxyUser GetByKey(Guid guidUser, string includes)
        {
            SDProxyUser item = null;
			string strWhere = @"GuidUser = Guid(""" + guidUser.ToString()+@""")";
            
			
            item = GetBy(strWhere, includes).FirstOrDefault();
            return item;

        }
		 public SDProxyUser GetByKey(Guid guidUser, string usemode, string includes)
		{
			return GetByKey(guidUser, usemode, null, includes);

		 }
		 public SDProxyUser GetByKey(Guid guidUser, string usemode, ContextRequest context,  string includes)
        {
            SDProxyUser item = null;
			string strWhere = @"GuidUser = Guid(""" + guidUser.ToString()+@""")";
			if (context == null){
				context = new ContextRequest();
				context.CustomQuery = new CustomQuery();
				context.CustomQuery.IsByKey = true;
				context.CustomQuery.FilterExpressionString = strWhere;
				context.UseMode = usemode;
			}
            item = GetBy(strWhere,context , includes).FirstOrDefault();
            return item;

        }

        #region Dynamic Predicate
        public List<SDProxyUser> GetBy(Expression<Func<SDProxyUser, bool>> predicate, int? pageSize, int? page)
        {
            return this.GetBy(predicate, pageSize, page, null, null);
        }
        public List<SDProxyUser> GetBy(Expression<Func<SDProxyUser, bool>> predicate, ContextRequest contextRequest)
        {

            return GetBy(predicate, contextRequest,"");
        }
        
        public List<SDProxyUser> GetBy(Expression<Func<SDProxyUser, bool>> predicate, ContextRequest contextRequest, params Expression<Func<SDProxyUser, object>>[] includes)
        {
            StringBuilder sb = new StringBuilder();
           if (includes != null)
            {
                foreach (var path in includes)
                {

						if (sb.Length > 0) sb.Append(",");
						sb.Append(SFSdotNet.Framework.Linq.Utils.IncludeToString<SDProxyUser>(path));

               }
            }
            return GetBy(predicate, contextRequest, sb.ToString());
        }
        
        
        public List<SDProxyUser> GetBy(Expression<Func<SDProxyUser, bool>> predicate, string includes)
        {
			ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";

            return GetBy(predicate, context, includes);
        }

        public List<SDProxyUser> GetBy(Expression<Func<SDProxyUser, bool>> predicate, params Expression<Func<SDProxyUser, object>>[] includes)
        {
			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest context = new ContextRequest();
			            context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = "";
            return GetBy(predicate, context, includes);
        }

      
		public bool DisableCache { get; set; }
		public List<SDProxyUser> GetBy(Expression<Func<SDProxyUser, bool>> predicate, ContextRequest contextRequest, string includes)
		{
            using (EFContext con = new EFContext()) {
				
				string fkIncludes = "";
                List<string> multilangProperties = new List<string>();
				if (predicate == null) predicate = PredicateBuilder.True<SDProxyUser>();
				string isDeletedField = null;
				Expression<Func<SDProxyUser,bool>> notDeletedExpression = null;
					bool sharedAndMultiTenant = false;
					string multiTenantField = null; 
					Expression<Func<SDProxyUser,bool>> multitenantExpression = null;
 
                
                return GetBy(con, predicate, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression);

#region Old code
/*
				List<SDProxyUser> result = null;
               BusinessRulesEventArgs<SDProxyUser>  e = null;
	
				OnGetting(con, e = new BusinessRulesEventArgs<SDProxyUser>() {  FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null) });

               // OnGetting(con,e = new BusinessRulesEventArgs<SDProxyUser>() { FilterExpression = predicate, ContextRequest = contextRequest, FilterExpressionString = contextRequest.CustomQuery.FilterExpressionString});
				   if (e != null) {
				    predicate = e.FilterExpression;
						if (e.Cancel)
						{
							context = null;
							 if (e.Items == null) e.Items = new List<SDProxyUser>();
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                if (predicate == null) predicate = PredicateBuilder.True<SDProxyUser>();
                
                //var es = _repository.Queryable;

                IQueryable<SDProxyUser> query =  con.SDProxyUsers.AsQueryable();

                                if (!string.IsNullOrEmpty(includes))
                {
                    foreach (string include in includes.Split(char.Parse(",")))
                    {
						if (!string.IsNullOrEmpty(include))
                            query = query.Include(include);
                    }
                }
				query =query.AsExpandable().Where(predicate);
                query = ContextQueryBuilder<SDProxyUser>.ApplyContextQuery(query, contextRequest);

                result = query.AsNoTracking().ToList<SDProxyUser>();
				  
                if (e != null)
                {
                    e.Items = result;
                }
				//if (contextRequest != null ){
				//	 contextRequest = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
					contextRequest.CustomQuery = new CustomQuery();

				//}
				OnTaken(this, e == null ? e =  new BusinessRulesEventArgs<SDProxyUser>() { Items= result, IncludingComputedLinq = false, ContextRequest = contextRequest,  FilterExpression = predicate } :  e);
  
			

                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
				*/
#endregion
            }
        }


		/*public int Update(List<SDProxyUser> items, ContextRequest contextRequest)
            {
                int result = 0;
                using (EFContext con = new EFContext())
                {
                   
                

                    foreach (var item in items)
                    {
                        //secMessageToUser messageToUser = new secMessageToUser();
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            item.GetType().GetProperty(prop).SetValue(item, item.GetType().GetProperty(prop).GetValue(item));
                        }
                        //messageToUser.GuidMessageToUser = (Guid)item.GetType().GetProperty("GuidMessageToUser").GetValue(item);

                        var setObject = con.CreateObjectSet<SDProxyUser>("SDProxyUsers");
                        //messageToUser.Readed = DateTime.UtcNow;
                        setObject.Attach(item);
                        foreach (var prop in contextRequest.CustomQuery.SpecificProperties)
                        {
                            con.ObjectStateManager.GetObjectStateEntry(item).SetModifiedProperty(prop);
                        }
                       
                    }
                    result = con.SaveChanges();

                    


                }
                return result;
            }
           */
		

        public List<SDProxyUser> GetBy(string predicateString, ContextRequest contextRequest, string includes)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
				


				string computedFields = "";
				string fkIncludes = "";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDProxyUser>();
				string isDeletedField = null;
				string notDeletedExpression = null;
					bool sharedAndMultiTenant = false;
					string multiTenantField = null; 
					string multitenantExpression = null;
 
                
                return GetBy(con, predicateString, contextRequest, includes, fkIncludes, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression,computedFields);


	#region Old Code
	/*
				BusinessRulesEventArgs<SDProxyUser> e = null;

				Filter filter = new Filter();
                if (predicateString.Contains("|"))
                {
                    string ft = GetSpecificFilter(predicateString, contextRequest);
                    if (!string.IsNullOrEmpty(ft))
                        filter.SetFilterPart("ft", ft);
                   
                    contextRequest.FreeText = predicateString.Split(char.Parse("|"))[1];
                    var q1 = predicateString.Split(char.Parse("|"))[0];
                    if (!string.IsNullOrEmpty(q1))
                    {
                        filter.ProcessText(q1);
                    }
                }
                else {
                    filter.ProcessText(predicateString);
                }
				 var includesList = (new List<string>());
                 if (!string.IsNullOrEmpty(includes))
                 {
                     includesList = includes.Split(char.Parse(",")).ToList();
                 }

				List<SDProxyUser> result = new List<SDProxyUser>();
         
			QueryBuild(predicateString, filter, con, contextRequest, "getby", includesList);
			 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }
				
				
					OnGetting(con, e == null ? e = new BusinessRulesEventArgs<SDProxyUser>() { Filter = filter, ContextRequest = contextRequest  } : e );

                  //OnGetting(con,e = new BusinessRulesEventArgs<SDProxyUser>() {  ContextRequest = contextRequest, FilterExpressionString = predicateString });
			   	if (e != null) {
				    //predicateString = e.GetQueryString();
						if (e.Cancel)
						{
							context = null;
							return e.Items;

						}
						if (!string.IsNullOrEmpty(e.StringIncludes))
                            includes = e.StringIncludes;
					}
				//	 else {
                //      predicateString = predicateString.Replace("*extraFreeText*", "").Replace("()","");
                //  }
				//con.EnableChangeTrackingUsingProxies = false;
				con.Configuration.ProxyCreationEnabled = false;
                con.Configuration.AutoDetectChangesEnabled = false;
                con.Configuration.ValidateOnSaveEnabled = false;

                //if (predicate == null) predicate = PredicateBuilder.True<SDProxyUser>();
                
                //var es = _repository.Queryable;
				IQueryable<SDProxyUser> query = con.SDProxyUsers.AsQueryable();
		
				// include relations FK
				if(string.IsNullOrEmpty(includes) ){
					includes ="";
				}
				StringBuilder sbQuerySystem = new StringBuilder();
				//string predicateString = predicate.ToDynamicLinq<SDProxyUser>();
				//predicateString += sbQuerySystem.ToString();
				filter.CleanAndProcess("");

				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed(); //SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicateString );               
                string predicateWithManyRelations = filter.GetFilterChildren(); //SFSdotNet.Framework.Linq.Utils.CleanPartExpression(predicateString);

                //QueryUtils.BreakeQuery1(predicateString, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
                var _queryable = query.AsQueryable();
				bool includeAll = true; 
                if (!string.IsNullOrEmpty(predicateWithManyRelations))
                    _queryable = _queryable.Where(predicateWithManyRelations, contextRequest.CustomQuery.ExtraParams);
				if (contextRequest.CustomQuery.SpecificProperties.Count > 0)
                {

				includeAll = false; 
                }

				StringBuilder sbSelect = new StringBuilder();
                sbSelect.Append("new (");
                bool existPrev = false;
                foreach (var selected in contextRequest.CustomQuery.SelectedFields.Where(p=> !string.IsNullOrEmpty(p.Linq)))
                {
                    if (existPrev) sbSelect.Append(", ");
                    if (!selected.Linq.Contains(".") && !selected.Linq.StartsWith("it."))
                        sbSelect.Append("it." + selected.Linq);
                    else
                        sbSelect.Append(selected.Linq);
                    existPrev = true;
                }
                sbSelect.Append(")");
                var queryable = _queryable.Select(sbSelect.ToString());                    


     				
                 if (!string.IsNullOrEmpty(predicateWithFKAndComputed))
                    queryable = queryable.Where(predicateWithFKAndComputed, contextRequest.CustomQuery.ExtraParams);

				QueryComplementOptions queryOps = ContextQueryBuilder.ApplyContextQuery(contextRequest);
            	if (!string.IsNullOrEmpty(queryOps.OrderByAndSort)){
					if (queryOps.OrderBy.Contains(".") && !queryOps.OrderBy.StartsWith("it.")) queryOps.OrderBy = "it." + queryOps.OrderBy;
					queryable = queryable.OrderBy(queryOps.OrderByAndSort);
					}
               	if (queryOps.Skip != null)
                {
                    queryable = queryable.Skip(queryOps.Skip.Value);
                }
                if (queryOps.PageSize != null)
                {
                    queryable = queryable.Take (queryOps.PageSize.Value);
                }


                var resultTemp = queryable.AsQueryable().ToListAsync().Result;
                foreach (var item in resultTemp)
                {

				   result.Add(SFSdotNet.Framework.BR.Utils.GetConverted<SDProxyUser,dynamic>(item, contextRequest.CustomQuery.SelectedFields.Select(p=>p.Name).ToArray()));
                }

			 if (e != null)
                {
                    e.Items = result;
                }
				 contextRequest.CustomQuery = new CustomQuery();
				OnTaken(this, e == null ? e = new BusinessRulesEventArgs<SDProxyUser>() { Items= result, IncludingComputedLinq = true, ContextRequest = contextRequest, FilterExpressionString  = predicateString } :  e);
  
			
  
                if (e != null) {
                    //if (e.ReplaceResult)
                        result = e.Items;
                }
                return result;
	
	*/
	#endregion

            }
        }
		public SDProxyUser GetFromOperation(string function, string filterString, string usemode, string fields, ContextRequest contextRequest)
        {
            using (EFContext con = new EFContext(contextRequest))
            {
                string computedFields = "";
               // string fkIncludes = "accContpaqiClassification,accProjectConcept,accProjectType,accProxyUser";
                List<string> multilangProperties = new List<string>();
				string isDeletedField = null;
				string notDeletedExpression = null;
					bool sharedAndMultiTenant = false;
					string multiTenantField = null; 
					string multitenantExpression = null;
 

                return GetSummaryOperation(con, new SDProxyUser(), function, filterString, usemode, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields, contextRequest, fields.Split(char.Parse(",")).ToArray());
            }
        }

   protected override void QueryBuild(string predicate, Filter filter, DbContext efContext, ContextRequest contextRequest, string method, List<string> includesList)
      	{
				if (contextRequest.CustomQuery.SpecificProperties.Count == 0)
                {
					contextRequest.CustomQuery.SpecificProperties.Add(SDProxyUser.PropertyNames.Email);
					contextRequest.CustomQuery.SpecificProperties.Add(SDProxyUser.PropertyNames.DisplayName);
                    
				}

				if (method == "getby" || method == "sum")
				{
					if (!contextRequest.CustomQuery.SpecificProperties.Contains("GuidUser")){
						contextRequest.CustomQuery.SpecificProperties.Add("GuidUser");
					}

					 if (!string.IsNullOrEmpty(contextRequest.CustomQuery.OrderBy))
					{
						string existPropertyOrderBy = contextRequest.CustomQuery.OrderBy;
						if (contextRequest.CustomQuery.OrderBy.Contains("."))
						{
							existPropertyOrderBy = contextRequest.CustomQuery.OrderBy.Split(char.Parse("."))[0];
						}
						if (!contextRequest.CustomQuery.SpecificProperties.Exists(p => p == existPropertyOrderBy))
						{
							contextRequest.CustomQuery.SpecificProperties.Add(existPropertyOrderBy);
						}
					}

				}
				
	bool isFullDetails = contextRequest.IsFromUI("SDProxyUsers", UIActions.GetForDetails);
	string filterForTest = predicate  + filter.GetFilterComplete();

				if (isFullDetails || !string.IsNullOrEmpty(predicate))
            {
            } 

			if (method == "sum")
            {
            } 
			if (contextRequest.CustomQuery.SelectedFields.Count == 0)
            {
				foreach (var selected in contextRequest.CustomQuery.SpecificProperties)
                {
					string linq = selected;
					switch (selected)
                    {

					 
						
					 default:
                            break;
                    }
					contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name=selected, Linq=linq});
					if (method == "getby" || method == "sum")
					{
						if (includesList.Contains(selected))
							includesList.Remove(selected);

					}

				}
			}
				if (method == "getby" || method == "sum")
				{
					foreach (var otherInclude in includesList.Where(p=> !string.IsNullOrEmpty(p)))
					{
						contextRequest.CustomQuery.SelectedFields.Add(new SelectedField() { Name = otherInclude, Linq = "it." + otherInclude +" as " + otherInclude });
					}
				}
				BusinessRulesEventArgs<SDProxyUser> e = null;
				if (contextRequest.PreventInterceptors == false)
					OnQuerySettings(efContext, e = new BusinessRulesEventArgs<SDProxyUser>() { Filter = filter, ContextRequest = contextRequest /*, FilterExpressionString = (contextRequest != null ? (contextRequest.CustomQuery != null ? contextRequest.CustomQuery.FilterExpressionString : null) : null)*/ });

				//List<SDProxyUser> result = new List<SDProxyUser>();
                 if (e != null)
                {
                    contextRequest = e.ContextRequest;
                }

}
		public List<SDProxyUser> GetBy(Expression<Func<SDProxyUser, bool>> predicate, bool loadRelations, ContextRequest contextRequest)
        {
			if(!loadRelations)
				return GetBy(predicate, contextRequest);
			else
				return GetBy(predicate, contextRequest, "SDPersons");

        }

        public List<SDProxyUser> GetBy(Expression<Func<SDProxyUser, bool>> predicate, int? pageSize, int? page, string orderBy, SFSdotNet.Framework.Data.SortDirection? sortDirection)
        {
            return GetBy(predicate, new ContextRequest() { CustomQuery = new CustomQuery() { Page = page, PageSize = pageSize, OrderBy = orderBy, SortDirection = sortDirection } });
        }
        public List<SDProxyUser> GetBy(Expression<Func<SDProxyUser, bool>> predicate)
        {

			if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: GetBy");
            }
			ContextRequest contextRequest = new ContextRequest();
            contextRequest.CustomQuery = new CustomQuery();
			contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
			            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

            contextRequest.CustomQuery.FilterExpressionString = null;
            return this.GetBy(predicate, contextRequest, "");
        }
        #endregion
        #region Dynamic String
		protected override string GetSpecificFilter(string filter, ContextRequest contextRequest) {
            string result = "";
		    //string linqFilter = String.Empty;
            string freeTextFilter = String.Empty;
            if (filter.Contains("|"))
            {
               // linqFilter = filter.Split(char.Parse("|"))[0];
                freeTextFilter = filter.Split(char.Parse("|"))[1];
            }
            //else {
            //    freeTextFilter = filter;
            //}
            //else {
            //    linqFilter = filter;
            //}
			// linqFilter = SFSdotNet.Framework.Linq.Utils.ReplaceCustomDateFilters(linqFilter);
            //string specificFilter = linqFilter;
            if (!string.IsNullOrEmpty(freeTextFilter))
            {
                System.Text.StringBuilder sbCont = new System.Text.StringBuilder();
                /*if (specificFilter.Length > 0)
                {
                    sbCont.Append(" AND ");
                    sbCont.Append(" ({0})");
                }
                else
                {
                    sbCont.Append("{0}");
                }*/
                //var words = freeTextFilter.Split(char.Parse(" "));
				var word = freeTextFilter;
                System.Text.StringBuilder sbSpec = new System.Text.StringBuilder();
                 int nWords = 1;
				/*foreach (var word in words)
                {
					if (word.Length > 0){
                    if (sbSpec.Length > 0) sbSpec.Append(" AND ");
					if (words.Length > 1) sbSpec.Append("("); */
					
	
					
					
					
									
					sbSpec.Append(string.Format(@"Email.Contains(""{0}"")", word));
					

					
					
										sbSpec.Append(" OR ");
					
									
					sbSpec.Append(string.Format(@"DisplayName.Contains(""{0}"")", word));
					

					
								 //sbSpec.Append("*extraFreeText*");

                    /*if (words.Length > 1) sbSpec.Append(")");
					
					nWords++;

					}

                }*/
                //specificFilter = string.Format("{0}{1}", specificFilter, string.Format(sbCont.ToString(), sbSpec.ToString()));
                                 result = sbSpec.ToString();  
            }
			//result = specificFilter;
			
			return result;

		}
	
			public List<SDProxyUser> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params object[] extraParams)
        {
			return GetBy(filter, pageSize, page, orderBy, orderDir,  null, extraParams);
		}
           public List<SDProxyUser> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, string usemode, params object[] extraParams)
            { 
                return GetBy(filter, pageSize, page, orderBy, orderDir, usemode, null, extraParams);
            }


		public List<SDProxyUser> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  string usemode, ContextRequest context, params object[] extraParams)

        {

            // string freetext = null;
            //if (filter.Contains("|"))
            //{
            //    int parts = filter.Split(char.Parse("|")).Count();
            //    if (parts > 1)
            //    {

            //        freetext = filter.Split(char.Parse("|"))[1];
            //    }
            //}
		
            //string specificFilter = "";
            //if (!string.IsNullOrEmpty(filter))
            //  specificFilter=  GetSpecificFilter(filter);
            if (string.IsNullOrEmpty(orderBy))
            {
			                orderBy = "Email";
            }
			//orderDir = "";
			SFSdotNet.Framework.Data.SortDirection direction = SFSdotNet.Framework.Data.SortDirection.Ascending;
            if (!string.IsNullOrEmpty(orderDir))
            {
                if (orderDir == "desc")
                    direction = SFSdotNet.Framework.Data.SortDirection.Descending;
            }
            if (context == null)
                context = new ContextRequest();
			

             context.UseMode = usemode;
             if (context.CustomQuery == null )
                context.CustomQuery =new SFSdotNet.Framework.My.CustomQuery();

 
                context.CustomQuery.ExtraParams = extraParams;

                    context.CustomQuery.OrderBy = orderBy;
                   context.CustomQuery.SortDirection = direction;
                   context.CustomQuery.Page = page;
                  context.CustomQuery.PageSize = pageSize;
               

            

            if (!preventSecurityRestrictions) {
			 if (context.CurrentContext == null)
                {
					if (SFSdotNet.Framework.My.Context.CurrentContext != null &&  SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
					{
						context.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
						context.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

					}
					else {
						throw new Exception("The security rule require a specific user and company");
					}
				}
            }
            return GetBy(filter, context);
  
        }


        public List<SDProxyUser> GetBy(string strWhere, ContextRequest contextRequest)
        {
        	#region old code
				
				 //Expression<Func<tvsReservationTransport, bool>> predicate = null;
				string strWhereClean = strWhere.Replace("*extraFreeText*", "").Replace("()", "");
                //if (!string.IsNullOrEmpty(strWhereClean)){

                //    object[] extraParams = null;
                //    //if (contextRequest != null )
                //    //    if (contextRequest.CustomQuery != null )
                //    //        extraParams = contextRequest.CustomQuery.ExtraParams;
                //    //predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<tvsReservationTransport, bool>(strWhereClean, extraParams != null? extraParams.Cast<Guid>(): null);				
                //}
				 if (contextRequest == null)
                {
                    contextRequest = new ContextRequest();
                    if (contextRequest.CustomQuery == null)
                        contextRequest.CustomQuery = new CustomQuery();
                }
                  if (!preventSecurityRestrictions) {
					if (contextRequest.User == null || contextRequest.Company == null)
                      {
                     if (SFSdotNet.Framework.My.Context.CurrentContext.Company != null && SFSdotNet.Framework.My.Context.CurrentContext.User != null)
                     {
                         contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                         contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

                     }
                     else {
                         throw new Exception("The security rule require a specific User and Company ");
                     }
					 }
                 }
            contextRequest.CustomQuery.FilterExpressionString = strWhere;
				//return GetBy(predicate, contextRequest);  

			#endregion				
				
                    return GetBy(strWhere, contextRequest, "");  


        }
       public List<SDProxyUser> GetBy(string strWhere)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
			
            return GetBy(strWhere, context, null);
        }

        public List<SDProxyUser> GetBy(string strWhere, string includes)
        {
		 	ContextRequest context = new ContextRequest();
            context.CustomQuery = new CustomQuery();
            context.CustomQuery.FilterExpressionString = strWhere;
            return GetBy(strWhere, context, includes);
        }

        #endregion
        #endregion
		
		  #region SaveOrUpdate
        
 		 public SDProxyUser Create(SDProxyUser entity)
        {
				//ObjectContext context = null;
				    if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: Create");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

				return this.Create(entity, contextRequest);


        }
        
       
        public SDProxyUser Create(SDProxyUser entity, ContextRequest contextRequest)
        {
		
		bool graph = false;
	
				bool preventPartial = false;
                if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
               
			using (EFContext con = new EFContext()) {

				SDProxyUser itemForSave = new SDProxyUser();
#region Autos
		if(!preventSecurityRestrictions){

	
	


			}
#endregion
               BusinessRulesEventArgs<SDProxyUser> e = null;
			    if (preventPartial == false )
                OnCreating(this,e = new BusinessRulesEventArgs<SDProxyUser>() { ContextRequest = contextRequest, Item=entity });
				   if (e != null) {
						if (e.Cancel)
						{
							context = null;
							return e.Item;

						}
					}

                    if (entity.GuidUser == Guid.Empty)
                   {
                       entity.GuidUser = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   itemForSave.GuidUser = entity.GuidUser;
				  
		
			itemForSave.GuidUser = entity.GuidUser;

			itemForSave.Email = entity.Email;

			itemForSave.DisplayName = entity.DisplayName;

				
				con.SDProxyUsers.Add(itemForSave);




                
				con.ChangeTracker.Entries().Where(p => p.Entity != itemForSave && p.State != EntityState.Unchanged).ForEach(p => p.State = EntityState.Detached);

				con.Entry<SDProxyUser>(itemForSave).State = EntityState.Added;

				con.SaveChanges();

					 
				

				//itemResult = entity;
                //if (e != null)
                //{
                 //   e.Item = itemResult;
                //}
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false )
                OnCreated(this, e == null ? e = new BusinessRulesEventArgs<SDProxyUser>() { ContextRequest = contextRequest, Item = entity } : e);



                if (e != null && e.Item != null )
                {
                    return e.Item;
                }
                              return entity;
			}
            
        }
        //BusinessRulesEventArgs<SDProxyUser> e = null;
        public void Create(List<SDProxyUser> entities)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            Create(entities, contextRequest);
        }
        public void Create(List<SDProxyUser> entities, ContextRequest contextRequest)
        
        {
			ObjectContext context = null;
            	foreach (SDProxyUser entity in entities)
				{
					this.Create(entity, contextRequest);
				}
        }
		  public void CreateOrUpdateBulk(List<SDProxyUser> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "cu", contextRequest);
        }

        private void CreateOrUpdateBulk(List<SDProxyUser> entities, string actionKey, ContextRequest contextRequest)
        {
			if (entities.Count() > 0){
            bool graph = false;

            bool preventPartial = false;
            if (contextRequest != null && contextRequest.PreventInterceptors == true)
            {
                preventPartial = true;
            }
            foreach (var entity in entities)
            {
                    if (entity.GuidUser == Guid.Empty)
                   {
                       entity.GuidUser = SFSdotNet.Framework.Utilities.UUID.NewSequential();
					   
                   }
				   
				  


#region Autos
		if(!preventSecurityRestrictions){


 if (actionKey != "u")
                        {


}
	
	


			}
#endregion


		
			//entity.GuidUser = entity.GuidUser;

			//entity.Email = entity.Email;

			//entity.DisplayName = entity.DisplayName;

				
				




                
				

					 
				

				//itemResult = entity;
            }
            using (EFContext con = new EFContext())
            {
                 if (actionKey == "c")
                    {
                        context.BulkInsert(entities);
                    }else if ( actionKey == "u")
                    {
                        context.BulkUpdate(entities);
                    }else
                    {
                        context.BulkInsertOrUpdate(entities);
                    }
            }

			}
        }
	
		public void CreateBulk(List<SDProxyUser> entities, ContextRequest contextRequest)
        {
            CreateOrUpdateBulk(entities, "c", contextRequest);
        }


		public void UpdateAgile(SDProxyUser item, params string[] fields)
         {
			UpdateAgile(item, null, fields);
        }
		public void UpdateAgile(SDProxyUser item, ContextRequest contextRequest, params string[] fields)
         {
            
             ContextRequest contextNew = null;
             if (contextRequest != null)
             {
                 contextNew = SFSdotNet.Framework.My.Context.BuildContextRequestCopySafe(contextRequest);
                 if (fields != null && fields.Length > 0)
                 {
                     contextNew.CustomQuery.SpecificProperties  = fields.ToList();
                 }
                 else if(contextRequest.CustomQuery.SpecificProperties.Count > 0)
                 {
                     fields = contextRequest.CustomQuery.SpecificProperties.ToArray();
                 }
             }
			

		   using (EFContext con = new EFContext())
            {



               
					List<string> propForCopy = new List<string>();
                    propForCopy.AddRange(fields);
                    
					  
					if (!propForCopy.Contains("GuidUser"))
						propForCopy.Add("GuidUser");
					if (!propForCopy.Contains("Email"))
						propForCopy.Add("Email");

					var itemForUpdate = SFSdotNet.Framework.BR.Utils.GetConverted<SDProxyUser,SDProxyUser>(item, propForCopy.ToArray());
					 itemForUpdate.GuidUser = item.GuidUser;
                  var setT = con.Set<SDProxyUser>().Attach(itemForUpdate);

					if (fields.Count() > 0)
					  {
						  item.ModifiedProperties = fields;
					  }
                    foreach (var property in item.ModifiedProperties)
					{						
                        if (property != "GuidUser")
                             con.Entry(setT).Property(property).IsModified = true;

                    }

                
               int result = con.SaveChanges();
               if (result != 1)
               {
                   SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: 1");
               }


            }

			OnUpdatedAgile(this, new BusinessRulesEventArgs<SDProxyUser>() { Item = item, ContextRequest = contextNew  });

         }
		public void UpdateBulk(List<SDProxyUser>  items, params string[] fields)
         {
             SFSdotNet.Framework.My.ContextRequest req = new SFSdotNet.Framework.My.ContextRequest();
             req.CustomQuery = new SFSdotNet.Framework.My.CustomQuery();
             foreach (var field in fields)
             {
                 req.CustomQuery.SpecificProperties.Add(field);
             }
             UpdateBulk(items, req);

         }

		 public void DeleteBulk(List<SDProxyUser> entities, ContextRequest contextRequest = null)
        {

            using (EFContext con = new EFContext())
            {
                foreach (var entity in entities)
                {
					var entityProxy = new SDProxyUser() { GuidUser = entity.GuidUser };

                    con.Entry<SDProxyUser>(entityProxy).State = EntityState.Deleted;

                }

                int result = con.SaveChanges();
                if (result != entities.Count)
                {
                    SFSdotNet.Framework.My.EventLog.Error("Has been changed " + result.ToString() + " items but the expected value is: " + entities.Count.ToString());
                }
            }

        }

        public void UpdateBulk(List<SDProxyUser> items, ContextRequest contextRequest)
        {
            if (items.Count() > 0){

			 foreach (var entity in items)
            {


#region Autos
		if(!preventSecurityRestrictions){

	



			}
#endregion





				}
				using (EFContext con = new EFContext())
				{

                    
                
                   con.BulkUpdate(items);

				}
             
			}	  
        }

         public SDProxyUser Update(SDProxyUser entity)
        {
            if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Create");
            }

            ContextRequest contextRequest = new ContextRequest();
            contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
            contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return Update(entity, contextRequest);
        }
       
         public SDProxyUser Update(SDProxyUser entity, ContextRequest contextRequest)
        {
		 if ((System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null) && contextRequest == null)
            {
                throw new Exception("Please, specific the contextRequest parameter in the method: Update");
            }
            if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            }

			
				SDProxyUser  itemResult = null;

	

			 using( EFContext con = new EFContext()){
				BusinessRulesEventArgs<SDProxyUser> e = null;
				bool preventPartial = false; 
				if (contextRequest != null && contextRequest.PreventInterceptors == true )
                {
                    preventPartial = true;
                } 
				if (preventPartial == false)
                OnUpdating(this,e = new BusinessRulesEventArgs<SDProxyUser>() { ContextRequest = contextRequest, Item=entity});
				   if (e != null) {
						if (e.Cancel)
						{
							//outcontext = null;
							return e.Item;

						}
					}

	string includes = "";
	IQueryable < SDProxyUser > query = con.SDProxyUsers.AsQueryable();
	foreach (string include in includes.Split(char.Parse(",")))
                       {
                           if (!string.IsNullOrEmpty(include))
                               query = query.Include(include);
                       }
	var oldentity = query.FirstOrDefault(p => p.GuidUser == entity.GuidUser);
	if (oldentity.Email != entity.Email)
		oldentity.Email = entity.Email;
	if (oldentity.DisplayName != entity.DisplayName)
		oldentity.DisplayName = entity.DisplayName;


           


				if (entity.SDPersons != null)
                {
                    foreach (var item in entity.SDPersons)
                    {


                        
                    }
					
                    

                }


				con.ChangeTracker.Entries().Where(p => p.Entity != oldentity).ForEach(p => p.State = EntityState.Unchanged);  
				  
				con.SaveChanges();
        
					 
					
               
				itemResult = entity;
				if(preventPartial == false)
					OnUpdated(this, e = new BusinessRulesEventArgs<SDProxyUser>() { ContextRequest = contextRequest, Item=itemResult });

              	return itemResult;
			}
			  
        }
        public SDProxyUser Save(SDProxyUser entity)
        {
			return Create(entity);
        }
        public int Save(List<SDProxyUser> entities)
        {
			 Create(entities);
            return entities.Count;

        }
        #endregion
        #region Delete
        public void Delete(SDProxyUser entity)
        {
				this.Delete(entity, null);
			
        }
		 public void Delete(SDProxyUser entity, ContextRequest contextRequest)
        {
				
				  List<SDProxyUser> entities = new List<SDProxyUser>();
				   entities.Add(entity);
				this.Delete(entities, contextRequest);
			
        }

         public void Delete(string query, Guid[] guids, ContextRequest contextRequest)
        {
			var br = new SDProxyUsersBR(true);
            var items = br.GetBy(query, null, null, null, null, null, contextRequest, guids);
            
            Delete(items, contextRequest);

        }
        public void Delete(SDProxyUser entity,  ContextRequest contextRequest, BusinessRulesEventArgs<SDProxyUser> e = null)
        {
			
				using(EFContext con = new EFContext())
                 {
				
               	BusinessRulesEventArgs<SDProxyUser> _e = null;
               List<SDProxyUser> _items = new List<SDProxyUser>();
                _items.Add(entity);
                if (e == null || e.PreventPartialPropagate == false)
                {
                    OnDeleting(this, _e = (e == null ? new BusinessRulesEventArgs<SDProxyUser>() { ContextRequest = contextRequest, Item = entity, Items = null  } : e));
                }
                if (_e != null)
                {
                    if (_e.Cancel)
						{
							context = null;
							return;

						}
					}


				
								
				con.Entry<SDProxyUser>(entity).State = EntityState.Deleted;
				con.SaveChanges();
				 
                				
				
				 
					
					
			if (e == null || e.PreventPartialPropagate == false)
                {

                    if (_e == null)
                        _e = new BusinessRulesEventArgs<SDProxyUser>() { ContextRequest = contextRequest, Item = entity, Items = null };

                    OnDeleted(this, _e);
                }

				//return null;
			}
        }
        public void Delete(List<SDProxyUser> entities,  ContextRequest contextRequest = null )
        {
				
			 BusinessRulesEventArgs<SDProxyUser> _e = null;

                OnDeleting(this, _e = new BusinessRulesEventArgs<SDProxyUser>() { ContextRequest = contextRequest, Item = null, Items = entities });
                if (_e != null)
                {
                    if (_e.Cancel)
                    {
                        context = null;
                        return;

                    }
                }
                bool allSucced = true;
                BusinessRulesEventArgs<SDProxyUser> eToChilds = new BusinessRulesEventArgs<SDProxyUser>();
                if (_e != null)
                {
                    eToChilds = _e;
                }
                else
                {
                    eToChilds = new BusinessRulesEventArgs<SDProxyUser>() { ContextRequest = contextRequest, Item = (entities.Count == 1 ? entities[0] : null), Items = entities };
                }
				foreach (SDProxyUser item in entities)
				{
					try
                    {
                        this.Delete(item, contextRequest, e: eToChilds);
                    }
                    catch (Exception ex)
                    {
                        SFSdotNet.Framework.My.EventLog.Error(ex);
                        allSucced = false;
                    }
				}
				if (_e == null)
                    _e = new BusinessRulesEventArgs<SDProxyUser>() { ContextRequest = contextRequest, CountResult = entities.Count, Item = null, Items = entities };
                OnDeleted(this, _e);

			
        }
        #endregion
 
        #region GetCount
		 public int GetCount(Expression<Func<SDProxyUser, bool>> predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;

			return GetCount(predicate, contextRequest);
		}
        public int GetCount(Expression<Func<SDProxyUser, bool>> predicate, ContextRequest contextRequest)
        {


		
		 using (EFContext con = new EFContext())
            {


				if (predicate == null) predicate = PredicateBuilder.True<SDProxyUser>();
				
				IQueryable<SDProxyUser> query = con.SDProxyUsers.AsQueryable();
                return query.AsExpandable().Count(predicate);

			
				}
			

        }
		  public int GetCount(string predicate,  ContextRequest contextRequest)
         {
             return GetCount(predicate, null, contextRequest);
         }

         public int GetCount(string predicate)
        {
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
            return GetCount(predicate, contextRequest);
        }
		 public int GetCount(string predicate, string usemode){
				if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session  == null){
                    throw new Exception("Please, specific the contextRequest parameter in the method: GetCount");
                }

                ContextRequest contextRequest = new ContextRequest();
                contextRequest.User = SFSdotNet.Framework.My.Context.CurrentContext.User;
                contextRequest.Company = SFSdotNet.Framework.My.Context.CurrentContext.Company;
				return GetCount( predicate,  usemode,  contextRequest);
		 }
        public int GetCount(string predicate, string usemode, ContextRequest contextRequest){

		using (EFContext con = new EFContext()) {
				string computedFields = "";
				string fkIncludes = "";
                List<string> multilangProperties = new List<string>();
				//if (predicate == null) predicate = PredicateBuilder.True<SDProxyUser>();
				string isDeletedField = null;
				string notDeletedExpression = null;
					bool sharedAndMultiTenant = false;
					string multiTenantField = null; 
					string multitenantExpression = null;
 
                
                return GetCount(con, predicate, usemode, contextRequest, multilangProperties, multiTenantField, isDeletedField, sharedAndMultiTenant, notDeletedExpression, multitenantExpression, computedFields);

			}
			#region old code
			 /* string freetext = null;
            Filter filter = new Filter();

              if (predicate.Contains("|"))
              {
                 
                  filter.SetFilterPart("ft", GetSpecificFilter(predicate, contextRequest));
                 
                  filter.ProcessText(predicate.Split(char.Parse("|"))[0]);
                  freetext = predicate.Split(char.Parse("|"))[1];

				  if (!string.IsNullOrEmpty(freetext) && string.IsNullOrEmpty(contextRequest.FreeText))
                  {
                      contextRequest.FreeText = freetext;
                  }
              }
              else {
                  filter.ProcessText(predicate);
              }
			   predicate = filter.GetFilterComplete();
			// BusinessRulesEventArgs<SDProxyUser>  e = null;
           	using (EFContext con = new EFContext())
			{
			
			

			 QueryBuild(predicate, filter, con, contextRequest, "count", new List<string>());


			
			BusinessRulesEventArgs<SDProxyUser> e = null;

			contextRequest.FreeText = freetext;
			contextRequest.UseMode = usemode;
            OnCounting(this, e = new BusinessRulesEventArgs<SDProxyUser>() {  Filter =filter, ContextRequest = contextRequest });
            if (e != null)
            {
                if (e.Cancel)
                {
                    context = null;
                    return e.CountResult;

                }

            

            }
			
			StringBuilder sbQuerySystem = new StringBuilder();
		
		
				   
                 filter.CleanAndProcess("");
				//string predicateWithFKAndComputed = SFSdotNet.Framework.Linq.Utils.ExtractSpecificProperties("", ref predicate );               
				string predicateWithFKAndComputed = filter.GetFilterParentAndCoumputed();
               string predicateWithManyRelations = filter.GetFilterChildren();
			   ///QueryUtils.BreakeQuery1(predicate, ref predicateWithManyRelations, ref predicateWithFKAndComputed);
			   predicate = filter.GetFilterComplete();
               if (!string.IsNullOrEmpty(predicate))
               {
				
					
                    return con.SDProxyUsers.Where(predicate).Count();
					
                }else
                    return con.SDProxyUsers.Count();
					
			}*/
			#endregion

		}
         public int GetCount()
        {
            return GetCount(p => true);
        }
        #endregion
        
         


        public void Delete(List<SDProxyUser.CompositeKey> entityKeys)
        {

            List<SDProxyUser> items = new List<SDProxyUser>();
            foreach (var itemKey in entityKeys)
            {
                items.Add(GetByKey(itemKey.GuidUser));
            }

            Delete(items);

        }
		 public void UpdateAssociation(string relation, string relationValue, string query, Guid[] ids, ContextRequest contextRequest)
        {
            var items = GetBy(query, null, null, null, null, null, contextRequest, ids);
			 var module = SFSdotNet.Framework.Cache.Caching.SystemObjects.GetModuleByKey(SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(System.Web.HttpContext.Current.Request.RequestContext, "area"));
           
            foreach (var item in items)
            {
			  Guid ? guidRelationValue = null ;
                if (!string.IsNullOrEmpty(relationValue)){
                    guidRelationValue = Guid.Parse(relationValue );
                }

				 if (relation.Contains("."))
                {
                    var partsWithOtherProp = relation.Split(char.Parse("|"));
                    var parts = partsWithOtherProp[0].Split(char.Parse("."));

                    string proxyRelName = parts[0];
                    string proxyProperty = parts[1];
                    string proxyPropertyKeyNameFromOther = partsWithOtherProp[1];
                    //string proxyPropertyThis = parts[2];

                    var prop = item.GetType().GetProperty(proxyRelName);
                    //var entityInfo = //SFSdotNet.Framework.
                    // descubrir el tipo de entidad dentro de la colección
                    Type typeEntityInList = SFSdotNet.Framework.Entities.Utils.GetTypeFromList(prop);
                    var newProxyItem = Activator.CreateInstance(typeEntityInList);
                    var propThisForSet = newProxyItem.GetType().GetProperty(proxyProperty);
                    var entityInfoOfProxy = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(typeEntityInList);
                    var propOther = newProxyItem.GetType().GetProperty(proxyPropertyKeyNameFromOther);

                    if (propThisForSet != null && entityInfoOfProxy != null && propOther != null )
                    {
                        var entityInfoThis = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(item.GetType());
                        var valueThisId = item.GetType().GetProperty(entityInfoThis.PropertyKeyName).GetValue(item);
                        if (valueThisId != null)
                            propThisForSet.SetValue(newProxyItem, valueThisId);
                        propOther.SetValue(newProxyItem, Guid.Parse(relationValue));
                        
                        var entityNameProp = newProxyItem.GetType().GetField("EntityName").GetValue(null);
                        var entitySetNameProp = newProxyItem.GetType().GetField("EntitySetName").GetValue(null);

                        SFSdotNet.Framework.Apps.Integration.CreateItemFromApp(entityNameProp.ToString(), entitySetNameProp.ToString(), module.ModuleNamespace, newProxyItem, contextRequest);

                    }

                    // crear una instancia del tipo de entidad
                    // llenar los datos y registrar nuevo


                }
                else
                {
                var prop = item.GetType().GetProperty(relation);
                var entityInfo = SFSdotNet.Framework.Common.Entities.Metadata.MetadataAttributes.GetMyAttribute<SFSdotNet.Framework.Common.Entities.Metadata.EntityInfoAttribute>(prop.PropertyType);
                if (entityInfo != null)
                {
                    var ins = Activator.CreateInstance(prop.PropertyType);
                   if (guidRelationValue != null)
                    {
                        prop.PropertyType.GetProperty(entityInfo.PropertyKeyName).SetValue(ins, guidRelationValue);
                        item.GetType().GetProperty(relation).SetValue(item, ins);
                    }
                    else
                    {
                        item.GetType().GetProperty(relation).SetValue(item, null);
                    }

                    Update(item, contextRequest);
                }

				}
            }
        }
		
	}
	 
}


