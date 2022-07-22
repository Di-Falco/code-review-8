using System;
using System.Collections.Generic;

namespace BakeryOrders.Models
{
  public class Order
  {
    private static List<Order> _orders = new List<Order>{};
    public string Title { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public int Id { get; set; }
    public bool Complete { get; set; }

    public Order(string title, string description, string date)
    {
      Title = title;
      Description = description;
      Date = date;
      _orders.Add(this);
      Id = _orders.Count;
      Complete = false;
    }

    public static List<Order> GetAll()
    {
      return _orders;
    }

    public static void ClearAll()
    {
      _orders.Clear();
    }
  }
}