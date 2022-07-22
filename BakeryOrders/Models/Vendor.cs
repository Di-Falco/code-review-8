using System;
using System.Collections.Generic;

namespace BakeryOrders.Models
{
  public class Vendor
  {
    private static List<Vendor> _vendors = new List<Vendor> {};
    public string Name { get; set; }
    public string Description { get; set; }
    public int Id { get; set; }
    public List<Order> Orders { get; set; }

    public Vendor(string name, string description)
    {
      Name =name;
      Description = description;
      _vendors.Add(this);
      Id = _vendors.Count;
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

    public static Vendor Find(int id)
    {
      return _vendors[id-1];
    }

    public static void Delete(int id)
    {
      _vendors.RemoveAt(id-1);
      for(int i=id-1; i<_vendors.Count; i++) {
        _vendors[i].Id--;
      }
    }
  }
}