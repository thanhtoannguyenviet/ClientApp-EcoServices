using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientApp.Models
{
    public class ClientEntity
    {
        [Key]
        public long idClient { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(70)]
        public string password { get; set; }

        [StringLength(50)]
        public string fullname { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(15)]
        public string phone { get; set; }

        [StringLength(200)]
        public string privatekey { get; set; }

        public int? actived { get; set; }

        public int? role { get; set; }
    }
}