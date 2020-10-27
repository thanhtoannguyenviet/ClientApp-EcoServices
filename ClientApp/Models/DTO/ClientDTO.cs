using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models.DTO
{
    public class ClientDTO
    {
        public Client clientEntity { get;set;}
        public Role roleEntity { get;set;}
        public Img imgEntity { get;set;}
    }
}