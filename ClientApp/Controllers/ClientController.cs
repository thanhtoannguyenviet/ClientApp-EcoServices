using ClientApp.Models;
using ClientApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientApp.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            var clientService = new ClientService();
            return View();
        }
        public ActionResult getClientByRole()
        {
            var clientService = new ClientService();
            var res = clientService.GetAllDetail(2);
            List<Client> lsClient = new List<Client>();
            foreach (var item in res)
            {
                lsClient.Add(item.clientEntity);
            }
            return PartialView(lsClient);
        } 
    }
}