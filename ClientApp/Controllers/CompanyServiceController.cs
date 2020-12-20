using ClientApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientApp.Models;

namespace ClientApp.Controllers
{
    public class CompanyServiceController : Controller
    {
        // GET: CompanyService
        public ActionResult Index()
        {
            var companySer = new CompanyService();
            var ls = companySer.GetAllByClient(0);
            List<CompanyServiceEntity> list = new List<CompanyServiceEntity>();
            foreach (var item in ls)
            {
                list.Add(item);
            }
            return View(list);
        }
        public ActionResult NewCompanyService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCompanyService(CompanyServiceEntity compservice)
        {

            CompanyService comser = new CompanyService();
            if (ModelState.IsValid)
            {
                var s = comser.Post(compservice);
                return RedirectToAction("Index");
            }
            ViewBag.message = "Insert failed!";
            return View();
        }
        public ActionResult Detail(int id)
        {
            var companyser = new CompanyService();
            var coS = companyser.GetDetail(id);
            return View(coS);
        }

        public ActionResult Delete(int id)
        {
            CompanyService comser = new CompanyService();
            comser.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var companyser = new CompanyService();
            var coS = companyser.GetDetail(id);
            return View(coS);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompanyServiceEntity compservice)
        {
            var companyser = new CompanyService();
            var compser = compservice;
            compser.idCs = id;
            companyser.Post(compser);
            return RedirectToAction("Index");
        }
     
       
       

    }
}