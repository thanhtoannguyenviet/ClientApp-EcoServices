using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models
{
    public class Feedback
    {
        public long idFeedback{get;set;}
        public long idCustomer { get; set;}
        public String detail { get; set;}
        public long rate { get; set;}
        public long idCos { get; set;}

    }
}