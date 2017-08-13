using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS.ServiceDesk.Client.Models

{

    public class Result
    {
        public string status { get; set; }
        public string message { get; set; }
        public string reason { get; set; }



    }

    public class Result<T> : Result where T : class
    {
        //public string status { get; set; }
        //public string message { get; set; }
        //public string reason { get; set; }

        public T data { get; set; }
    }
    public class UserDataLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserDataRegister
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AppKey { get; set; }

    }

    public class UserDataResponse
    {
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AppKey { get; set; }
        public string IdUser { get; set; }
        public string IdCompany { get; set; }

    }

    public class UserDataChangePassword
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }


    }

    public class UserDataWithToken
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string FullName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }


    }


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
