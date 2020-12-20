using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientApp.Models;
using ClientApp.Service;

namespace ClientApp.Controllers
{
    using ClientApp.Models;
    using ClientApp.Models.DTO;
    using ClientApp.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    namespace ClientApp.Controllers
    {
        public class ServiceController : Controller
        {
            //GET: Service
            public ActionResult Index()
            {
                var companySer = new Service.CompanyService();
                var list = companySer.GetAllByClient(0);
                return View(list);
            }
            [HttpGet]
            public ActionResult UpdateStatus(int id)
            {
                var companySer = new Service.CompanyService();
                var update = companySer.GetDetail(id);
                update.status = "1";
                var updatestatus = companySer.UpdateStatus(update);
                return RedirectToAction("Index", "Service");
            }
            public ActionResult getAllByAdmin()
            {
                var jobService = new JobService();
                var ls = jobService.GetAllByAdmin(0);
                List<ServiceEntity> list = new List<ServiceEntity>();
                foreach (var item in ls)
                {
                    list.Add(item);
                }
                return View(list);
            }

            public ActionResult NewService()
            {
                return View();
            }
            [HttpPost]
            public ActionResult NewService(ServiceEntity service_)
            {

                JobService jobS = new JobService();
                if (ModelState.IsValid)
                {
                    var s = jobS.Post(service_);
                    return RedirectToAction("getAllByAdmin");
                }
                ViewBag.message = "Insert failed!";
                return View();
            }

            public ActionResult Detail(int id)
            {
                JobService jobS = new JobService();
                var service_ = jobS.GetDetail(id);
                return View(service_);
            }
            public ActionResult Edit(int id)
            {

                JobService jobS = new JobService();
                var service_ = jobS.GetDetail(id);
                return View(service_);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int id, ServiceEntity service)
            {

                var jobS = new JobService();
                var ser = service;
                ser.idService = id;

                jobS.Post(ser);
                return RedirectToAction("getAllByAdmin");
            }
            public ActionResult Delete(int id)
            {
                JobService jobS = new JobService();
                jobS.Delete(id);
                return RedirectToAction("getAllByAdmin");
            }
        }
    }
}