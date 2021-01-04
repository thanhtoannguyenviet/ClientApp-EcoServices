using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models.DTO
{
    public class OrderDTO
    {
        public OrderEntity order { get;set;}
        public DetailOrderEntity detailOrderEntity { get;set;}
        public ClientEntity client { get;set;}
        public CompanyServiceEntity companyService { get; set; }
        public double amountPrice { get; set; }
    }
}