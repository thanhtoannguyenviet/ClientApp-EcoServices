using ClientApp.Common;
using ClientApp.Models;
using ClientApp.Models.DTO;
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
    public class ClientService
    {
        public ClientEntity Post (ClientEntity cl)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync(PropertiesFile.HOST+ "Client/Post/", new StringContent(
                    new JavaScriptSerializer().Serialize(cl), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    return cl;
            }
            return null;
        }
        public ClientEntity Put(ClientEntity cl)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync(PropertiesFile.HOST + "Client/Put/", new StringContent(
                    new JavaScriptSerializer().Serialize(cl), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    return cl;
            }
            return null;
        }
        public string Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(PropertiesFile.HOST + "Client/Delete/" + id);
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
        public List<ClientDTO> GetDetail(int idRole)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(PropertiesFile.HOST + "Client/GetDetail/" + idRole);

                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                      return JsonConvert.DeserializeObject<List<ClientDTO>>(result.Content.ReadAsStringAsync().Result);
                }
                return null;
            }
        }
        public List<ClientDTO> GetAllDetail(int idRole)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(PropertiesFile.HOST+ "Client/GetListClientByRole/"+ idRole);

                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = JsonConvert.DeserializeObject<List<ClientDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask; // nếu return ngay đây sao k return lại method trên luôn
                }
                return null;
            }
        }
        public List<ClientDTO> Search(string searchString)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(PropertiesFile.HOST + "Client/Search/q=" + searchString);

                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = JsonConvert.DeserializeObject<List<ClientDTO>>(result.Content.ReadAsStringAsync().Result);
                    return readTask; // nếu return ngay đây sao k return lại method trên luôn
                }
                return null;
            }
        }
        public ClientDTO GetClient(String username, String password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(PropertiesFile.HOST + "Client/Login/");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = JsonConvert.DeserializeObject<ClientDTO>(result.Content.ReadAsStringAsync().Result);
                    return readTask; // nếu return ngay đây sao k return lại method trên luôn
                }
                return null;
            }
        }
        public ClientEntity ForgotPassword(ClientEntity cl,String secret_key)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.PostAsync(PropertiesFile.HOST + "Client/ForgotPassword/secret_key="+ secret_key, new StringContent(
                    new JavaScriptSerializer().Serialize(cl), Encoding.UTF8, "application/json")).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                    return cl;
            }
            return null;
        }
    }
}