using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models.DTO
{
    public class ServiceDTO
    {
        public ServiceEntity serviceEntity { get;set;}
        public ClientEntity clientEntity { get;set;}
        public List<CompanyServiceEntity> companyServiceEntity { get;set;}
        public ImgEntity imgEntity { get;set;}
    }
}