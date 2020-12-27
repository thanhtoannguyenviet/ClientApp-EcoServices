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
            var clientEntity = GRestfulApi<ClientEntity>.Post(PropertiesFile.HOST + "Client/Post/", cl);
            return clientEntity;
        }
        public ClientEntity Put(ClientEntity cl)
        {
            var clientEntity = GRestfulApi<ClientEntity>.Post(PropertiesFile.HOST + "Client/Put/", cl);
            return clientEntity;
        }
        public string Delete(int id)
        {
            var clientEntity = GRestfulApi<string>.Delete(PropertiesFile.HOST + "Client/Delete/");
            return clientEntity;
        }
        public ClientDTO GetDetail(int id)
        {
            var clientEntity = GRestfulApi<ClientDTO>.Get(PropertiesFile.HOST + "Client/GetDetail/" + id);
            return clientEntity;
        }
        public List<ClientDTO> GetAllDetail(int idRole)
        {
            var lsClientDtos =
                GRestfulApi<List<ClientDTO>>.Get(PropertiesFile.HOST + "Client/GetListClientByRole/" + idRole);
            return lsClientDtos;
        }
        public List<ClientDTO> Search(string searchString)
        {
            var lsClientDtos =
                GRestfulApi<List<ClientDTO>>.Get(PropertiesFile.HOST + "Client/Search/q=" + searchString);
            return lsClientDtos;
        }
        public ClientDTO GetClient(String username, String password)
        {
            var client = new ClientDTO {clientEntity = {username = username, password = password}};
            var clientDto =
                GRestfulApi<ClientDTO>.Post(PropertiesFile.HOST + "Client/Login/", client);
            return clientDto;
        }
        public ClientEntity ForgotPassword(ClientEntity cl,String secret_key)
        {
            var clientDto =
                GRestfulApi<ClientEntity>.Post("Client/ForgotPassword/secret_key=" + secret_key, cl);
            return clientDto;
        }
    }
}