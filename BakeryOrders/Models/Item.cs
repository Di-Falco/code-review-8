using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryOrders.Models
{
  public partial class Item
  {
    public double Price { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }

    public Item(double price, string name)
    {
      Price = price;
      Name = name;
      Quantity = 0;
    }

    public void AddQuantity(int quantity)
    {
      Quantity = quantity;
    }

    public double Buy()
    {
      return (Quantity * Price);
    }

    public static List<Item> GetAll()
    {
      return _menu;
    }
  }
}