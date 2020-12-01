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
        public FeedbackEntity Post(FeedbackEntity feedbackEntity)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync(PropertiesFile.HOST + "Feedback/Post/", new StringContent(
                    new JavaScriptSerializer().Serialize(feedbackEntity), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    return feedbackEntity;
            }
            return null;
        }
        public FeedbackEntity Put(FeedbackEntity feedbackEntity)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync(PropertiesFile.HOST + "Feedback/Put/", new StringContent(
                    new JavaScriptSerializer().Serialize(feedbackEntity), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    return feedbackEntity;
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
                    return result.Content.ReadAsStringAsync().Result; 
                }

                return null;
            }
            return null;
        }
        public FeedbackEntity GetDetail(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(PropertiesFile.HOST + "Feedback/GetDetail/" + id);

                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<FeedbackEntity>(result.Content.ReadAsStringAsync().Result);
                }
                return null;
            }
        }
       
    }
}