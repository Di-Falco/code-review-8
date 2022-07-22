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

    public Order(string title, string description, string date, int baguette, int sourdough, int eclair, int macaron, int escargo, int cigarette)
    {
      Title = title;
      Description = description;
      Date = date;
      _orders.Add(this);
      Id = _orders.Count;
      Fulfilled = false;
      Items = AddAllItems(baguette, sourdough, eclair, macaron, escargo, cigarette);
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
      switch(Fulfilled){
      case(true):
        Fulfilled = false;
        break;
      case(false):
        Fulfilled = true;
        break;
      }
    }

    public List<Item> GetItems()
    {
      return Items;
    }

    public List<Item> AddAllItems(int q1, int q2, int q3, int q4, int q5, int q6)
    {
      List<Item> items = new List<Item> { };
      if (q1 > 0) {
        Item Baguette = new Item(Item.baguette.Price, Item.baguette.Name);
        Baguette.AddQuantity(q1);
        items.Add(Baguette);
      }
      if (q2 > 0) {
        Item Sourdough = new Item(Item.sourdough.Price, Item.sourdough.Name);
        Sourdough.AddQuantity(q2);
        items.Add(Sourdough);
      }
      if (q3 > 0) {
        Item Eclair = new Item(Item.eclair.Price, Item.eclair.Name);
        Eclair.AddQuantity(q3);
        items.Add(Eclair);
      }
      if (q4 > 0) {
        Item Macaron = new Item(Item.macaron.Price, Item.macaron.Name);
        Macaron.AddQuantity(q4);
        items.Add(Macaron);
      }
      if (q5 > 0) {
        Item Escargo = new Item(Item.escargo.Price, Item.escargo.Name);
        Escargo.AddQuantity(q5);
        items.Add(Escargo);
      }
      if (q6 > 0) {
        Item Cigarette = new Item(Item.cigarette.Price, Item.cigarette.Name);
        Cigarette.AddQuantity(q6);
        items.Add(Cigarette);
      }
      return items;
    }
  }
}