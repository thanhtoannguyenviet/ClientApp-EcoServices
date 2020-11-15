using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models
{
    public class Service
    {
        public long idService { get; set; }
        public String nameservice { get; set; }
        public String description { get; set; }
        public int actived { get; set; }
    }
}