using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models.DTO
{
    public class CompanyServiceDTO
    {
        public CompanyServiceEntity companyServiceEntity { get; set; }
        public List<OrderEntity> orderEntities { get; set; }
    }
}