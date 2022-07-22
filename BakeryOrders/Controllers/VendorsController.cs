using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BakeryOrders.Models;

namespace BakeryOrders.Controllers
{
  public class VendorsController : Controller
  {

    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> vendors = Vendor.GetAll();
      return View(vendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string name, string description)
    {
      Vendor vendor = new Vendor(name, description);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}/orders")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor vendor = Vendor.Find(id);
      List<Order> orders = vendor.Orders;
      model.Add("vendor", vendor);
      model.Add("orders", orders);
      return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Show(int vendorId, string orderTitle, string orderDescription, string orderDate, int baguette, int sourdough, int eclair, int macaron, int escargo, int cigarette)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor vendor = Vendor.Find(vendorId);
      Order order = new Order(orderTitle, orderDescription, orderDate, baguette, sourdough, eclair, macaron, escargo, cigarette);
      vendor.AddOrder(order);
      List<Order> orders = vendor.Orders;
      model.Add("vendor", vendor);
      model.Add("orders", orders);
      return View("Show", model);
    }
  }
}