using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models.DTO
{
    public class DetailOrderDTO
    {
        public DetailOrderEntity detailOrder { get; set; }
        public CompanyServiceEntity companyService { get;set;}
        public double amountPrice { get; set; }
    }
}