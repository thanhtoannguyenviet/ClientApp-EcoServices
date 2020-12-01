using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models.DTO
{
    public class DetailOrderDTO
    {
        DetailOrderEntity detailOrder { get;set;}
        OrderEntity order { get;set;}
    }
}