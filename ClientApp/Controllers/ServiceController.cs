using ClientApp.Models;
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
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Service()
        {
            JobService jobS = new JobService();
            List<Models.Service> ls = jobS.GetAllByClient(0);
            return View(ls);
        }
        public ActionResult NewService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewService(Models.Service service_)
        {

            JobService jobS = new JobService();
            if (ModelState.IsValid)
            {
                var s = jobS.Post(service_);
                return RedirectToAction("Index");
            }
            ViewBag.message = "Insert failed!";
            return View();
        }
        public ActionResult Detail(Models.Service service_)
        {
           
            return View(service_);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idService,nameservice,description,actived")] Models.Service service_)
        {

            if (ModelState.IsValid)
            {
                JobService jobS = new JobService();
                jobS.UpdateStatus(service_);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            JobService jobS = new JobService();
            jobS.Delete(id);
            return RedirectToAction("Index");
        }

    }
}