using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models.DTO
{
    public class ServiceDTO
    {
        public Models.Service serviceEntity { get;set;}
        public Client clientEntity { get;set;}
        public List<CompanyService> companyServiceEntity { get;set;}
        public Img imgEntity { get;set;}
    }
}