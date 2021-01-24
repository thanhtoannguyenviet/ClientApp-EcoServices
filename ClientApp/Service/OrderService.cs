using ClientApp.Common;
using ClientApp.Models;
using ClientApp.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace ClientApp.Service
{
    public class OrderService
    {
        public OrderEntity Post(OrderEntity or)
        {
            var orEntity = GRestfulApi<OrderEntity>.Post(PropertiesFile.HOST + "Order/Post/",or);
            return orEntity;
           
        }
        public OrderEntity Put(OrderEntity or)
        {
            var orEntity = GRestfulApi<OrderEntity>.Put(PropertiesFile.HOST + "Order/Put/", or);
            return orEntity;
        }
        public string Delete(int id)
        {
            var del = GRestfulApi<OrderEntity>.Delete(PropertiesFile.HOST + "Order/Delete/" + id);
            return del;
        }
        public OrderEntity GetDetail(int id)
        {
            var order = GRestfulApi<OrderEntity>.Get(PropertiesFile.HOST + "Order/GetDetail/" + id);
            return order;
        }
        public List<OrderDTO> GetListClientByIdCs(int id)
        {
            var orderList = GRestfulApi<List<OrderDTO>>.Get(PropertiesFile.HOST + "Order/GetListClientByIdCs/" + id);
            return orderList;
        }
        public OrderEntity GetDetail(long id)
        {
            var order = GRestfulApi<OrderEntity>.Get(PropertiesFile.HOST + "Order/GetDetail/" + id);
            return order;
        }
        public List<OrderDTO> GetListOrdertByIdCs(long id)
        {
            var orderList = GRestfulApi<List<OrderDTO>>.Get(PropertiesFile.HOST + "Order/GetListClientByIdCs/" + id);
            return orderList;
        }
        public OrderEntity UpdateStatus(OrderEntity order)
        {
            var updateorder = GRestfulApi<OrderEntity>.Post(PropertiesFile.HOST + "Order/UpdateStatus/" + order.idOrder + "/" + order.status, order);
            return updateorder;
        }


    }
}