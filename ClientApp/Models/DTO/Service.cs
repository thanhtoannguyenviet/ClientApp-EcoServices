using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models.DTO
{
    public class Service
    {
        Service service { get;set;}
        Client client { get;set;}
        CompanyService companyService {get;set;}
        Img img { get;set;}
    }
}