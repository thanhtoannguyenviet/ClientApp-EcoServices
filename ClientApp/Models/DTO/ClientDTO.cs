using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models.DTO
{
    public class ClientDTO
    {
        public ClientEntity clientEntity { get;set;}
        public RoleEntity roleEntity { get;set;}
        public ImgEntity imgEntity { get;set;}
    }
}