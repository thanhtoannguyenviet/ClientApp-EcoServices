using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Models
{
    public class ImgEntity
    {
        public long idImg { get;set;}

        public string link { get; set; }
        public long? idtable { get; set; }
        public string table { get; set; }
        public string status { get; set; }
    }
}