using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models
{
    public class OrderEntity
    {
        public long idOrder { get; set; }
        public long idCustomer { get; set; }
        public long idCs { get; set; }
        public String idTradeCode { get; set; }
        public String typeTradeCode { get; set; }
        public String status { get; set; }
    }
}