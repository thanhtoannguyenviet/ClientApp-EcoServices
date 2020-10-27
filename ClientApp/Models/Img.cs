using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models.DTO
{
    public class Img
    {
        public int idImg { get;set;}

        public string link { get; set; }
        public int? idtable { get; set; }
        public string table { get; set; }
        public int? status { get; set; }
    }
}