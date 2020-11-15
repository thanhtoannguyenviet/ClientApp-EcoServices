using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models.DTO
{
    public class OrderDTO
    {
        Order order { get;set;}
        CompanyService companyService { get;set;}
        Client client { get;set;}
    }
}