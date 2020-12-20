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
        public ActionResult getClientByRole_Admin()
        {
            var clientService = new ClientService();
            var res = clientService.GetAllDetail(1);
            List<ClientEntity> lsClient = new List<ClientEntity>();
            foreach (var item in res)
            {
                lsClient.Add(item.clientEntity);
            }
            return PartialView(lsClient);
        }
        public ActionResult getClientByRole_Staff()
        {
            var clientService = new ClientService();
            var res = clientService.GetAllDetail(2);
            List<ClientEntity> lsClient = new List<ClientEntity>();
            foreach (var item in res)
            {
                lsClient.Add(item.clientEntity);
            }
            return PartialView(lsClient);
        }
        public ActionResult NewClient()
        {
            return View();
        }
        [HttpPost]

        public ActionResult NewClient(Models.ClientEntity client_)
        {

            ClientService CliS = new ClientService();
            if (ModelState.IsValid)
            {
                Random r = new Random();
                string auto = "";
                try
                {
                    for (int a = 0; a <= 10; a++)
                    {
                        string[] str = new string[10];
                        str[a] = Convert.ToChar(Convert.ToInt32(r.Next(65, 87))).ToString();
                        auto += str[a].ToString();
                    }
                }
                catch { }
                client_.privatekey = DateTime.Now + " " + auto;

                var s = CliS.Post(client_);
                return RedirectToAction("Index");
            }
            ViewBag.message = "Insert failed!";
            return View();
        }


        public ActionResult Delete(int id)
        {

            ClientService CliS = new ClientService();
            CliS.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var cliS = new ClientService();
            var client_ = cliS.GetDetail(id);
            return View(client_);
        }
        public ActionResult Edit(int id)
        {

            var cliS = new ClientService();
            var client_ = cliS.GetDetail(id);
            return View(client_);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "idClient,username,password,fullname,email,phone,privatekey,actived,role")] Models.ClientEntity client_)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        ClientService jobS = new ClientService();
        //        jobS.Put(client_);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        public ActionResult Edit(int id, Models.ClientEntity client_)
        {

            var CliS = new ClientService();
            var cli = client_;
            cli.idClient = id;
            CliS.Post(cli);

            return RedirectToAction("Index");
        }


    }
}