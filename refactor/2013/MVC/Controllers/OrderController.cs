using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Domain;
using MVC.Models.Order;

namespace MVC.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            var product_repo = (IProductRepo)System.Web.HttpContext.Current.Application["product_repository"];
            var items = product_repo.GetItems();

            ViewData["items"] = items;
            Session["order_items"] = new List<OrderItemModel>();

            return View();
        }

        public ActionResult ViewPastOrders()
        {
            var order_repository = (IOrderRepository)System.Web.HttpContext.Current.Application["order_repository"];
            var orders = order_repository.GetOrders();

            ViewData["orders"] = orders;

            return View("PastOrders");
        }

        [HttpGet]
        public JsonResult GetProducts()
        {
            var product_repo = (IProductRepo)System.Web.HttpContext.Current.Application["product_repository"];
            var items = product_repo.GetItems();

            return Json(items, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(FormCollection form_collection)
        {
            //Save Order
            var order_repository = (IOrderRepository)System.Web.HttpContext.Current.Application["order_repository"];
            var order_items = (IList<OrderItemModel>)Session["order_items"];
            var order = new Order();

            foreach (var order_item in order_items)
            {
                var item = new OrderItem {item_id = order_item.item_id, quantity = order_item.quantity, price = order_item.price};
                order.items.Add(item);
            }

            order_repository.Save(order);

            //Send email
            MailMessage email = new MailMessage("peter@initech.com","ordering@initech.com");
            email.Subject = "Order submitted";

            SmtpClient client = new SmtpClient("localhost");

            try
            {
                client.Send(email);
            }
            catch(Exception)
            {
                //It is ok that it doesn't actually send the email for this project    
            }

            ViewData["order"] = order;
            return View("ThankYou");
        }

        [HttpPost]
        public JsonResult AddToOrder(FormCollection form_collection)
        {
            var product_repo = (IProductRepo)System.Web.HttpContext.Current.Application["product_repository"];
            var items = product_repo.GetItems();

            ViewData["items"] = items;

            IList<OrderItemModel> order_items = (IList<OrderItemModel>)Session["order_items"];
            if (order_items == null)
            {
                order_items = new List<OrderItemModel>();
            }

            int item_id = 0;
            int item_quantity = 0;

            foreach (var key in form_collection.Keys)
            {
                if (key.ToString().StartsWith("item_id"))
                {
                    item_id = int.Parse(form_collection[key.ToString()]);
                }

                if (key.ToString().StartsWith("item_quantity"))
                {
                    item_quantity = int.Parse(form_collection[key.ToString()]);
                }
            }

            var item = items.First(x => x.id == item_id);
            var order_item = new OrderItemModel
                                    {
                                        item_id=item.id,
                                        price=item.price,
                                        description = item.description,
                                        quantity = item_quantity
                                    };

            order_items.Add(order_item);

            Session["order_items"] = order_items;

            return Json(order_item);
        }
    }
}
