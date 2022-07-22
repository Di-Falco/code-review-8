using System;
using System.Collections.Generic;

namespace BakeryOrders.Models
{
  public class Vendor
  {
    private static List<Vendor> _vendors = new List<Vendor> {};
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Order> Orders { get; set; }

    public Vendor(string name, string description)
    {
      Name =name;
      Description = description;
      _vendors.Add(this);
      Orders = new List<Order>{};
    }

    public static List<Vendor> GetAll()
    {
      return _vendors;
    }

    public static void ClearAll()
    {
      _vendors.Clear();
    }
  }
}