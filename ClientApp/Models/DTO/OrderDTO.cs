using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models.DTO
{
    public class OrderDTO
    {
        OrderEntity order { get;set;}
        CompanyServiceEntity companyService { get;set;}
        ClientEntity client { get;set;}
    }
}