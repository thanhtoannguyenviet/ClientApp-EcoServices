using ClientApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientApp.Models;
using ClientApp.Models.DTO;

namespace ClientApp.Controllers
{
    public class CompanyServiceController : Controller
    {
        // GET: CompanyService
        public ActionResult Index()
        {
            var orderS = new OrderService();
            var ls = orderS.GetListOrdertByIdCs(3);
            ViewBag.Order = new OrderDTO();
            ViewBag.Model = ls.Where(a => a.order.status == null);
            return View();

        }
        [HttpGet]
        public ActionResult AcceptOrder(long id)
        {
            var orderSer = new OrderService();

            var update = orderSer.GetListOrdertByIdCs(3).Find(s => s.order.idOrder == id);
            update.order.status = "Chấp Thuận";
            var updateOrder = orderSer.UpdateStatus(update.order);
            string message = "Đơn hàng của bạn đã được xác nhận! Cảm ơn bạn đã tin tưởng chúng tôi!";
            return Json(message, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");
        }
        public ActionResult getAllOrder()
        {
            var orderS = new OrderService();
            var ls = orderS.GetListOrdertByIdCs(3);
            List<OrderEntity> list = new List<OrderEntity>();
            foreach (var item in ls)
            {
                list.Add(item.order);
            }
            return View(list);

        }
        [HttpGet]
        public ActionResult DenyOrder(long id)
        {
            var orderSer = new OrderService();

            var update = orderSer.GetListOrdertByIdCs(3).Find(s => s.order.idOrder == id);
            update.order.status = "Từ chối";
            var updateOrder = orderSer.UpdateStatus(update.order);
            string result = "Hiện chúng tôi không thể phục vụ yêu cầu của bạn. Xin lỗi vì sự bất tiện này!";
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getAll()
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