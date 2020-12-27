using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClientApp.Common;
using ClientApp.Models;
using ClientApp.Models.DTO;

namespace ClientApp.Service
{
    public class ImageService
    {
        public ImgEntity Post(ImgEntity imgE)
        {
            var img = GRestfulApi<ImgEntity>.Post(PropertiesFile.HOST + "Image/Post/", imgE);
            return img;
        }
        public ImgEntity Put(ImgEntity imgE)
        {
            var img = GRestfulApi<ImgEntity>.Post(PropertiesFile.HOST + "Image/Put/", imgE);
            return img;
        }
        public string Delete(int id)
        {
            var img = GRestfulApi<string>.Delete(PropertiesFile.HOST + "Image/Delete/");
            return img;
        }
        public ImgEntity GetDetail(int id)
        {
            var img = GRestfulApi<ImgEntity>.Get(PropertiesFile.HOST + "Image/GetDetail/" + id);
            return img;
        }
        public List<ImgEntity> GetAllDetail(string table,string idInTable,string status)
        {
            var lsImgEntities =
                GRestfulApi<List<ImgEntity>>.Get(PropertiesFile.HOST + "Image/GetListImgDetail/" + table+"/"+ idInTable + "/"+ status);
            return lsImgEntities;
        }
    }
}