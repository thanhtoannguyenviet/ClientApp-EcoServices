using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using ClientApp.Common;
using ClientApp.Models;
using Newtonsoft.Json;

namespace ClientApp.Service
{
    public class JobService
    {
        public ServiceEntity Post(ServiceEntity ser)
        {
            var service = GRestfulApi<ServiceEntity>.Post(PropertiesFile.HOST + "Service/Post/",ser);
            return service;
        }
        public string Delete(int id)
        {
            var service = GRestfulApi<ServiceEntity>.Delete(PropertiesFile.HOST + "Service/Delete/"+id);
            return service.ToString();
        }
        public ServiceEntity UpdateStatus(ServiceEntity ser)
        {
            var service = GRestfulApi<ServiceEntity>.Post(PropertiesFile.HOST + "Service/UpdateStatus/" + ser.idService + "/" + ser.actived, ser);
            return service;
           
        }
        public List<Models.DTO.ServiceDTO> GetAllByClient(int page)
        {
            var lsService = GRestfulApi<List<Models.DTO.ServiceDTO>>.Get(PropertiesFile.HOST + "Service/Client/GetAll10/" + page);
            return lsService;
        }
        public List<ServiceEntity> GetAllByAdmin(int page)
        {
            var lsService = GRestfulApi<List<ServiceEntity>>.Get(PropertiesFile.HOST + "Service/Admin/GetAll10/" + page);
            return lsService;
        }
        public ServiceEntity GetDetail(int id)
        {
            var service = GRestfulApi<ServiceEntity>.Get(PropertiesFile.HOST + "Service/GetDetail/" + id);
            return service;
        }
    }
}