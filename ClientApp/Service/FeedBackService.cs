using ClientApp.Common;
using ClientApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace ClientApp.Service
{
    public class FeedBackService
    {
        public Feedback Post(Feedback cl)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync(PropertiesFile.HOST + "Feedback/Post/", new StringContent(
                    new JavaScriptSerializer().Serialize(cl), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    return cl;
            }
            return null;
        }
        public Feedback Put(Feedback fb)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync(PropertiesFile.HOST + "Feedback/Put/", new StringContent(
                    new JavaScriptSerializer().Serialize(fb), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    return fb;
            }
            return null;
        }
        public string Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(PropertiesFile.HOST + "Feedback/Delete/" + id);
                var responseTask = client.DeleteAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {


                    return result.Content.ReadAsStringAsync().Result; // nếu return ngay đây sao k return lại method trên luôn
                }

                return null;
            }
            return null;
        }
        public Feedback GetDetail(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(PropertiesFile.HOST + "Feedback/GetDetail/" + id);

                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Feedback>(result.Content.ReadAsStringAsync().Result);
                }
                return null;
            }
        }
       
    }
}