using ClientApp.Models;
using ClientApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyServiceEntity = ClientApp.Models.CompanyServiceEntity;

namespace ClientApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          var jobService = new JobService();
          List<Models.DTO.ServiceDTO> services = jobService.GetAllByClient(0);
            return View(services);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(ClientEntity account)
        {
           
            ClientService clientServer = new ClientService();
            var person = clientServer.GetClient(account.username,account.password);
            if (person != null)
            {

                //if (person.role_ == 1)
                //{
                //    var customer = LoginCustomer(person);
                //    customer.account = person;
                //    Response.Cookies.Add(new HttpCookie("Account", new JavaScriptSerializer().Serialize(customer)));
                //    ViewBag.Name = customer.customer.headName;
                //    var username = Common.ROLE.GetValue(person.role_);
                //    FormsAuthentication.SetAuthCookie(Common.ROLE.GetValue(person.role_), true);
                //    return Redirect("/Customer/");
                //}
                //else if (person.role_ > 1)
                //{
                //    var staff = LoginStaff(person);
                //    staff.account = person;
                //    Response.Cookies.Add(new HttpCookie("Account", new JavaScriptSerializer().Serialize(staff)));
                //    ViewBag.Name = staff.staff.staffName;
                //    var username = Common.ROLE.GetValue(person.role_);
                //    FormsAuthentication.SetAuthCookie(Common.ROLE.GetValue(person.role_), true);
                //    return Redirect("/Admin/");
                //}
                ViewBag.Error = "1";
                ModelState.AddModelError("", "Success Login");
            }
            else
            {
                ViewBag.Error = "1";
                ModelState.AddModelError("", "Invalid user and password");
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Register(ClientEntity client)
        {
            var clientService = new ClientService();
            var cl = clientService.Post(client);
            if (cl != null)
            {
                Session["Account"] = cl;
                ViewBag.Name = cl.fullname;
                //var username = Common.Role.GetValue(done.account.role_);
                //FormsAuthentication.SetAuthCookie(Common.Role.GetValue(done.account.role_), true);
                return Redirect("/Customer/");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            if (Request.Cookies["Account"] != null)
            {
                HttpCookie c = new HttpCookie("Account");
                c.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(c);
            }
            Request.Cookies.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Registe()
        {
            return PartialView("Index");
        }
        public ActionResult _PartialLogin()
        {
            return PartialView("../Share/_PartialLogin");
        }
        [HttpGet]
        public ActionResult CompanyServiceDetail(int id)
        {
            var companyService = new Service.CompanyService();
            var cl = companyService.GetDetail(id);
            return View(cl);
        }

        public ActionResult AddToCart(int id)
        {

            var companyService = new Service.CompanyService();
            var coms = companyService.GetDetail(id);
            return View(coms);
        }

    }
}