using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BakeryOrders.Models;

namespace BakeryOrders.Controllers
{
  public class OrdersController : Controller
  {

    [HttpGet("/vendors/{vendorId}/orders/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpGet("/vendors/{vendorId}/orders/{orderId}/items")]
    public ActionResult Show(int vendorId , int orderId )
    {
      Vendor vendor = Vendor.Find(vendorId);
      Order order = Order.Find(orderId);
      List<Item> items = order.GetItems();
      Dictionary <string,object> model = new Dictionary<string,object>();
      model.Add("vendor", vendor);
      model.Add("order" , order);
      model.Add("items", items);
      return View(model);
    }    
  }
}