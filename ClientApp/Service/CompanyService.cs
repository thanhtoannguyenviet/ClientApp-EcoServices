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
            var companyServiceEntity = GRestfulApi<CompanyServiceEntity>.Post(PropertiesFile.HOST + "CompanyService/Post/", cs);
            return companyServiceEntity;
        }
        public string Delete(int id)
        {
            var companyServiceEntity = GRestfulApi<CompanyServiceEntity>.Delete(PropertiesFile.HOST + "CompanyService/Delete/" + id);
            return companyServiceEntity;
         }
        public CompanyServiceEntity UpdateStatus(CompanyServiceEntity cs)
        {
            var companyServiceEntity = GRestfulApi<CompanyServiceEntity>.Post(PropertiesFile.HOST + "CompanyService/UpdateStatus/" + cs.idCs + "/" + cs.status, cs);
            return companyServiceEntity;
           
        }
        public List<CompanyServiceEntity> GetAllByClient(int page)
        {
            var lsCompanyServiceEntity = GRestfulApi<List<CompanyServiceEntity>>.Get(PropertiesFile.HOST + "CompanyService/GetAll10/" + page);
            return lsCompanyServiceEntity;
           
        }
        public CompanyServiceEntity GetDetail(int id)
        {
            var companyService = GRestfulApi<CompanyServiceEntity>.Get(PropertiesFile.HOST + "CompanyService/GetDetail/" + id);
            return companyService;
        }
    }
}