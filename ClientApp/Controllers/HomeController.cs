using ClientApp.Models;
using ClientApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using ClientApp.Models.DTO;
using Newtonsoft.Json;
using PayPal.Api;
using CompanyServiceEntity = ClientApp.Models.CompanyServiceEntity;

namespace ClientApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          var jobService = new JobService();
          List<Models.DTO.ServiceDTO> services = jobService.GetAllByClient(0);
          if (Session["cart"] != null)
          {
              List<OrderDTO> ls = Session["cart"] as List<OrderDTO>;
          }
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
        public ActionResult Error404()
        {
            ViewBag.Error = "Bạn cần đăng nhập để thực hiện";
            return View("Login");
        }
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(ClientEntity account)
        {
            account.password = Common.CryptSecurity.Crypts.EnCrypt(account.password);
            ClientService clientServer = new ClientService();
            var person = clientServer.GetClient(account.username,account.password);
            if (person != null)
            {
                var customer = person.clientEntity;
                Response.Cookies.Add(new HttpCookie("Account", new JavaScriptSerializer().Serialize(customer)));
                ViewBag.Name = customer.fullname;
                var username = Common.RoleSecurity.GetValue(customer.role);
                FormsAuthentication.SetAuthCookie(Common.RoleSecurity.GetValue(customer.role), true);
                return Redirect("/Customer/");
            }
                //ViewBag.Error = "1";
                //ModelState.AddModelError("", "Success Login");
            
            //else
            //{
            //    ViewBag.Error = "1";
            //    ModelState.AddModelError("", "Invalid user and password");
            //}
            return View("Index");
        }
        [HttpPost]
        public ActionResult Register(ClientEntity client)
        {
            client.password = Common.CryptSecurity.Crypts.EnCrypt(client.password);
            var clientService = new ClientService();
            var cl = clientService.Post(client);
            if (cl != null)
            {
                Session["Account"] = cl;
                ViewBag.Name = cl.fullname;
                var username = Common.RoleSecurity.GetValue(cl.role);
                FormsAuthentication.SetAuthCookie(Common.RoleSecurity.GetValue(cl.role), true);
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
            var order = new OrderDTO()
            {
                client = new ClientEntity(),
                companyService = coms,
                detailOrderEntity = new DetailOrderEntity(),
                order = new OrderEntity()
            };
            return View(order);
        }

        //public ActionResult AddToCart(CompanyService comp)
        //{

        //    return Index();
        //}

        public ActionResult Buy(OrderDTO d)
        {
           // var accountCustomer = JsonConvert.DeserializeObject<ClientEntity>(Request.Cookies["Account"]?.Value);
           var price =Convert.ToDouble(Request["total"]);
           var weekly = Request["weekly"];
           var start = Convert.ToDateTime(Request["from"]);
           var end = Convert.ToDateTime(Request["to"]);
           var idCs = Convert.ToInt64(Request["idcs"]);
           var email = Request["email"];
           var phone = Request["phone"];
           var address = Request["address"];
            APIContext apiContext = PayPalConfiguration.GetAPIContext();
            string payerId = Request.Params["PayerID"];
            OrderDTO orderDto = new OrderDTO()
            {
                client = new ClientEntity(),
                companyService = new CompanyServiceEntity(){idCs = idCs},
                order = new OrderEntity(){idCustomer = 1,idCs = idCs},
                detailOrderEntity = new DetailOrderEntity()
                {
                    start = start,
                    end = end,
                    weekly = weekly,
                    address = address,
                    email = email,
                    phone = phone,
                    price = price
                },
                amountPrice = price
            };
            if (string.IsNullOrEmpty(payerId))
            {
                string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Home/Buy?";
                var guid = Convert.ToString((new Random()).Next(100000));
                var cancelURL = Request.Url.Scheme + "://" + Request.Url.Authority + "/Home/Index";
                
                var createdPayment = PaypalService.CreatePaymentPaypalAPI(apiContext, baseURI + "guid=" + guid, orderDto, cancelURL);
                var links = createdPayment.links.GetEnumerator();
                string paypalRedirectUrl = null;
                while (links.MoveNext())
                {
                    Links lnk = links.Current;
                    if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                    {
                        //saving the payapalredirect URL to which user will be redirected for payment  
                        paypalRedirectUrl = lnk.href;
                    }
                }
                TempData[guid] = createdPayment.id;
                //return Redirect(paypalRedirectUrl);
                return Json("OK");
            }
            else
            {
                var guid = Request.Params["guid"];
                var executedPayment = PaypalService.ExecutePayment(apiContext, payerId, TempData[guid] as string);
                var cus = "admin1";
                    //accountCustomer.fullname;
                var pay = new OrderEntity()
                {
                    idTradeCode = executedPayment.id,
                    idCustomer = 2,
                                 //accountCustomer.idClient,
                    typeTradeCode = "PayPal"
                };
                var companyService = new OrderService();
                var comp = companyService.Post(pay);

                var detailService = new DetailOrderService();
                var detail = new DetailOrderEntity()
                {
                    idOrder = orderDto.companyService.idCompany,
                    start = orderDto.detailOrderEntity.start,
                    end = orderDto.detailOrderEntity.end,
                    price = orderDto.amountPrice,
                    weekly = orderDto.detailOrderEntity.weekly,
                };
                detailService.Post(detail);
                //If executed payment failed then we will show payment failure message to user  
                if (executedPayment.state.ToLower() != "approved")
                {
                    Session.Remove("cart");
                    return JavaScript("Payment Error!");
                }

                return Index();
            }
        }
    }
}