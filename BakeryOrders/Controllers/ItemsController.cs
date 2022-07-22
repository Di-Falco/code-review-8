using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BakeryOrders.Models;

namespace BakeryOrders.Controllers
{
  public class ItemsController : Controller
  {
    [HttpGet("/vendors/{vendorId}/orders/{orderId}/items/new")]
    public ActionResult New(int vendorId, int orderId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      Order order = Order.Find(orderId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("vendor", vendor);
      model.Add("order", order);
      return View(model);
    }
  }
}