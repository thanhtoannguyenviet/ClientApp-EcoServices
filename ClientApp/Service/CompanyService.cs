using ClientApp.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using ClientApp.Models;

namespace ClientApp.Service
{
    public class CompanyService
    {
        public CompanyServiceEntity Post(CompanyServiceEntity cs)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync(PropertiesFile.HOST + "CompanyService/Post/", new StringContent(
                    new JavaScriptSerializer().Serialize(cs), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    return cs;
            }
            return null;
        }
        public string Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(PropertiesFile.HOST + "CompanyService/Delete/" + id);
                var responseTask = client.DeleteAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return result.Content.ReadAsStringAsync().Result;
                }

                return null;
            }
            return null;
        }
        public CompanyServiceEntity UpdateStatus(CompanyServiceEntity cs)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync(PropertiesFile.HOST + "CompanyService/UpdateStatus/" + cs.idCs + "/" + cs.status, new StringContent(
                    new JavaScriptSerializer().Serialize(cs), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    return cs;
            }
            return null;
        }
        public List<CompanyServiceEntity> GetAllByClient(int page)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(PropertiesFile.HOST + "CompanyService/GetAll10/" + page);

                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = JsonConvert.DeserializeObject<List<CompanyServiceEntity>>(result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
                return null;
            }
        }
        public CompanyServiceEntity GetDetail(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(PropertiesFile.HOST + "CompanyService/GetDetail/" + id);

                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = JsonConvert.DeserializeObject<CompanyServiceEntity > (result.Content.ReadAsStringAsync().Result);
                    return readTask;
                }
                return null;
            }
        }
    }
}