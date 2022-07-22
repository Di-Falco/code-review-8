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
    public bool Fulfilled { get; set; }
    public List<Item> Items { get; set; }

    public Order(string title, string description, string date)
    {
      Title = title;
      Description = description;
      Date = date;
      _orders.Add(this);
      Id = _orders.Count;
      Fulfilled = false;
      Items = new List<Item> {};
    }

    public static List<Order> GetAll()
    {
      return _orders;
    }

    public static void ClearAll()
    {
      _orders.Clear();
    }

    public static Order Find(int id)
    {
      return _orders[id-1];
    }

    public static void Delete(int id)
    {
      _orders.RemoveAt(id-1);
      for(int i=id-1; i<_orders.Count; i++){
        _orders[i].Id--;
      }
    }

    public void Complete()
    {
      switch(this.Fulfilled){
      case(true):
        this.Fulfilled = false;
        break;
      case(false):
        this.Fulfilled = true;
        break;
      }
    }

    public void AddItem(Item item)
    {
      Items.Add(item);
    }
  }
}