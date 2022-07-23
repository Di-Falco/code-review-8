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
      List<Item> items = Item.GetAll();
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("vendor", vendor);
      model.Add("items", items);
      return View(model);
    }

    [HttpGet("/vendors/{vendorId}/orders/{orderId}/items")]
    public ActionResult Show(int vendorId , int orderId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      Order order = Order.Find(orderId);
      List<Item> items = order.GetItems();
      Dictionary <string, object> model = new Dictionary<string, object>();
      model.Add("vendor", vendor);
      model.Add("order" , order);
      model.Add("items", items);
      return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders/{orderId}/complete")]
    public ActionResult Complete(int orderId)
    {
      Order order = Order.Find(orderId);
      order.Complete();
      return View();
    }

    [HttpPost("/vendors/{vendorId}/delete/orders/{orderId}")]
    public ActionResult Delete(int vendorId, int orderId)
    {
      Order.Delete(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      vendor.DeleteOrder(orderId);
      Dictionary <string, object> model = new Dictionary<string, object>();
      model.Add("vendor", vendorId);
      model.Add("order" , orderId);      
      return View(model);
    }   
  }
}