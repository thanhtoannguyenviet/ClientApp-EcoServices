using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClientApp.Models;
using ClientApp.Models.DTO;
using PayPal.Api;

namespace ClientApp.Service
{
    public class PaypalService
    {
        //public static Payment CreatePayment(Payment payment)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        var response = client.PostAsync("https://localhost:44305/api/payment/createPayment/", new StringContent(
        //            new JavaScriptSerializer().Serialize(payment), Encoding.UTF8, "application/json")).Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var readTask = JsonConvert.DeserializeObject<Payment>(response.Content.ReadAsStringAsync().Result);
        //            return readTask; // nếu return ngay đây sao k return lại method trên luôn
        //        }     
        //        return null;
        //    }
        //}
        public static PayPal.Api.Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            PayPal.Api.Payment payment;
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            payment = new PayPal.Api.Payment()
            {
                id = paymentId
            };
            return payment.Execute(apiContext, paymentExecution);
        }
        public static PayPal.Api.Payment CreatePaymentPaypalAPI(APIContext apiContext, string redirectUrl, OrderDTO orderDto, String cancelURL)
        {
           
            //create itemlist and add item objects to it
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc
            double totalAll = 0;
            itemList.items.Add(new Item()
            {
                name = "1",
                currency = "USD",
                price = orderDto.amountPrice.ToString(),
                quantity = "1",
                description = orderDto.detailOrderEntity.weekly
            });
            totalAll += orderDto.amountPrice;
            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = cancelURL,
                return_url = redirectUrl
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "USD",
                total = totalAll+"",
                details = new Details()
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction  
            transactionList.Add(new Transaction()
            {
                description = "Chi tiet don hang",
                invoice_number = ClientApp.Common.FormatPaypal.RANDOMINVOICENUMBER(), //Generate an Invoice No  
                amount = amount,
                item_list = itemList
            });
            PayPal.Api.Payment payment = new PayPal.Api.Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            
            return payment.Create(apiContext);
            }
        
        }
    }
