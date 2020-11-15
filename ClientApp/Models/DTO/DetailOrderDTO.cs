using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models.DTO
{
    public class DetailOrderDTO
    {
        DetailOrder detailOrder { get;set;}
        Order order { get;set;}
    }
}