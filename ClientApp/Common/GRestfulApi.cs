using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace ClientApp.Common
{
    public class GRestfulApi<T>
    {
        private static string Authorization;

        private static void SetHeader()
        {
           
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("username","admin123");

                    client.DefaultRequestHeaders.Add("password", "admin123");
                    var response = client.PostAsync("http://localhost:8080/Server/login", new StringContent(
                        new JavaScriptSerializer().Serialize(""), Encoding.UTF8, "application/json")).Result;
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        HttpHeaders headers = response.Headers;
                        IEnumerable<string> values;
                        if (headers.TryGetValues("Authorization", out values))
                        {
                            Authorization = values.First(); 
                        }
                    }
                }
        }

       
        public static T Post(string url, T t)
        {
            using (HttpClient client = new HttpClient())
            {
                SetHeader();
                client.DefaultRequestHeaders.Add("Authorization", Authorization);
                var response = client.PostAsync(url, new StringContent(
                    new JavaScriptSerializer().Serialize(t), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    return t;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    SetHeader();
                }
            }
            return t;
        }
        public static T Put(string url, T t)
        {
            using (HttpClient client = new HttpClient())
            {
                SetHeader();
                client.DefaultRequestHeaders.Add("Authorization", Authorization);
                var response = client.PutAsync(url, new StringContent(
                    new JavaScriptSerializer().Serialize(t), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    return t;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    SetHeader();
                }
            }
            return t;
        }
        public static string Delete(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                SetHeader();
                client.DefaultRequestHeaders.Add("Authorization", Authorization);
                var response = client.DeleteAsync(url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    return PropertiesFile.MSG_SUCCESS;
            }
            return PropertiesFile.MSG_FAILURE;
        }
        public static T Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                SetHeader();
                client.DefaultRequestHeaders.Add("Authorization", Authorization);
                var response = client.GetAsync(url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var rs = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    return rs;
                }
            }
            return default(T);
        }
    }
}