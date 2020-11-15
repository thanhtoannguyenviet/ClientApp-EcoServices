using ClientApp.Models;
using ClientApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
            return PartialView("Login");
        }
        [HttpPost]
        public ActionResult Login(Client account)
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
        public ActionResult Register()
        {
            //var accountCus = new AccountCustomer();
            //accountCus.customer.headName = Request["Fullname"].Trim();
            //accountCus.customer.headEmail = Request["Email"].Trim();
            //accountCus.account.pass_word = EnCrypt(Request["Password"]);
            //accountCus.customer.headPhone = Request["Phone"].Trim();
            //accountCus.account.userName = Request["Username"].Trim();
            ////accountCus.customer.headBirtday =DateTime.Parse( Request["Birthday"]);
            //accountCus.customer.taxCode = Request["taxCode"];
            //accountCus.account.role_ = 1;
            //var done = RegisterCustomer(accountCus);
            //if (done != null)
            //{
            //    Session["Account"] = done;
            //    ViewBag.Name = done.customer.headName;
            //    var username = Common.Role.GetValue(done.account.role_);
            //    FormsAuthentication.SetAuthCookie(Common.Role.GetValue(done.account.role_), true);
            //    return Redirect("/Customer/");
            //}
            ////Chua tra ve loi khong dang ky duoc
            //else return Redirect("/Home/");
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
    }
}