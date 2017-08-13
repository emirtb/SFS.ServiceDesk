using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SFS.ServiceDesk.Tests
{
    public class APIResult
    {

    }
    public class ApiWrapper<TModel> : ApiWrapper where TModel : class
    {
        public ApiWrapper()
        {
            this.Items = new List<TModel>();
        }
        public TModel Item { get; set; }
        public List<TModel> Items { get; set; }
    }

    public class ApiWrapper
    {
        //   public bo MyProperty { get; set; }
        public ApiWrapper()
        {

        }
        public string MethodName { get; set; }
        public bool AllFields { get; set; }
        public object[] ExtraParams { get; set; }
        public List<string> Ids { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string EntitySetName { get; set; }
        public string EntityKeyName { get; set; }
        public string AppKey { get; set; }
        public string QueryFilter { get; set; }
        public string SortBy { get; set; }
        public string SortDirection { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CompanyId { get; set; }
        public string Token { get; set; }
        public object ItemKey { get; set; }
    }

    public class Services
    {

        public static string ApiCreate(string urlApp, ApiWrapper wrap)
        {
            string urlApi = urlApp + "/" + wrap.EntitySetName + "/Create?rok=1";
            return CallApi(urlApi, "c", wrap);
        }
        public static T ApiGetByKey<T>(string urlApp, ApiWrapper wrap)
        {
            string urlApi = urlApp + "/" + wrap.EntitySetName + "/Get";
            var result = CallApi(urlApi, "r", wrap);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
        }

        public static T ApiGet<T>(string urlApp, ApiWrapper wrap)
        {
            string extra = "";
            if (wrap.AllFields == true)
            {
                extra = "allFields=1";
            }
            string urlApi = urlApp + "/" + wrap.EntitySetName + "/Get?" + extra;
            var result = CallApi(urlApi, "r", wrap);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
        }

        public static int ApiGetCount(string urlApp, ApiWrapper wrap)
        {

            string urlApi = urlApp + "/" + wrap.EntitySetName + "/GetCount";
            var result = CallApi(urlApi, "r", wrap);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<int>(result);
        }


        public static T ApiRequest<T>(string url, ApiWrapper wrap)
        {
            string urlApi = url;
            var result = CallApi(urlApi, "r", wrap);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
        }


        //public static ApiWrapper ApiGetWrap(string urlApp, ApiWrapper wrap)
        //{
        //    string urlApi = urlApp + "/" + wrap.EntitySetName + "/Get";
        //    var result = CallApi(urlApi, "r", wrap);
        //    return Newtonsoft.Json.JsonConvert.DeserializeObject<bool>(result);
        //}

        public static bool ApiLogin(string urlApp, ApiWrapper wrap)
        {
            string urlApi = urlApp + "/SFSdotNetFrameworkSecurity/Account/ValidateLogin";
            var result = CallApi(urlApi, wrap);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<bool>(result);
        }

        //public static UserInfo ApiLoginAndGetUser(string urlApp, ApiWrapper wrap)
        //{
        //    string urlApi = urlApp + "/SFSdotNetFrameworkSecurity/Account/ValidateLoginAndGetUser";
        //    var result = CallApi(urlApi, wrap);
        //    return Newtonsoft.Json.JsonConvert.DeserializeObject<UserInfo>(result);
        //}
        public static string CallApi(string urlApi, ApiWrapper wrap)
        {
            return CallApi(urlApi, "r", wrap);
        }
        public static string CallApi(string urlApi, string action, ApiWrapper wrap)
        {
            string url = urlApi; //"";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = Newtonsoft.Json.JsonConvert.SerializeObject(wrap);
            request.Headers.Add("Token", wrap.Token);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            // Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

        public static string CallApi(string urlApi, string method, Object data)
        {
            string url = urlApi; //"";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            // Set the Method property of the request to POST.
            request.Method = method;
            // Create POST data and convert it to a byte array.
            string postData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
           
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
           
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            // Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

    }


    public class Utils
    {


        public static Int32 GetInt32()
        {
            return SFSdotNet.Framework.Utilities.Random.GetInt32();
        }
        public static int GetInt()
        {
            return GetInt32();
        }
        public static int GetInt(int start, int end)
        {
            return SFSdotNet.Framework.Utilities.Random.GetInt32(start, end);
        }
        public static DateTime GetDateTime()
        {
            return DateTime.Now;
        }
        public static string GetString(int? max)
        {
            if (max == null)
            {
                max = 20;
            }
            return SFSdotNet.Framework.Utilities.Random.GetString(max.Value);
        }
        public static bool GetBoolean()
        {
            return SFSdotNet.Framework.Utilities.Random.GetBoolean();

        }
        public static bool GetBool()
        {
            return GetBoolean();
        }
        public static Decimal GetDecimal()
        {
            return SFSdotNet.Framework.Utilities.Random.GetDecimal();
        }
    }
}
