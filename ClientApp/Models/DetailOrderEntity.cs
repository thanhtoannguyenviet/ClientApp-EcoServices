using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models
{
    public class DetailOrderEntity
    {
        public long idDetailOder{get;set; }
        public long idOrder { get; set; }
        public long price { get; set; }
        public String weekly { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}