using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFS.ServiceDesk.Web.Mvc.Models
{
    public class EntityModel
    {
        public int Changes { get; set; }
        public string EntityName { get; set; }
        //public int Added { get; set; }
        //public int Deleted { get; set; }
        //public int Updated { get; set; }

    }
    public class ExistsChangesModel
    {
        public ExistsChangesModel()
        {
            this.Entities = new List<Models.EntityModel>();
        }
        public bool WithChanges { get; set; }
        public List<EntityModel> Entities { get; set; }
    }
}