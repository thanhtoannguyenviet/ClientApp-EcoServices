using ClientApp.Common;
using ClientApp.Models;
using ClientApp.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ClientApp.Service
{
    public  class ClientService
    {
        
        public List<ClientDTO> GetAllDetail(int idRole)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(PropertiesFile.HOST+ "Server/api/Client/GetListClientByRole/"+ idRole);

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
    }
}