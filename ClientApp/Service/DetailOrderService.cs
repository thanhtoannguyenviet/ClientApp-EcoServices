using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClientApp.Common;
using ClientApp.Models;

namespace ClientApp.Service
{
    public class DetailOrderService
    {
        public DetailOrderEntity Post(DetailOrderEntity cs)
        {
            var detailOrder = GRestfulApi<DetailOrderEntity>.Post(PropertiesFile.HOST + "DetailOrder/Post/", cs);
            return detailOrder;
        }
        public string Delete(int id)
        {
            var detailOrder = GRestfulApi<DetailOrderEntity>.Delete(PropertiesFile.HOST + "DetailOrder/Delete/" + id);
            return detailOrder;
        } 
        public List<DetailOrderEntity> GetAllByClient(int page)
        {
            var lsDetailOrder = GRestfulApi<List<DetailOrderEntity>>.Get(PropertiesFile.HOST + "DetailOrder/GetAll10/" + page);
            return lsDetailOrder;

        }
        public DetailOrderEntity GetDetail(long id)
        {
            var detailOrder = GRestfulApi<DetailOrderEntity>.Get(PropertiesFile.HOST + "DetailOrder/GetDetail/" + id);
            return detailOrder;
        }
    }
}