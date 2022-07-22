using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryOrders.Models
{
  public class Item
  {      
    private static Item baguette = new Item(5.00, "Baguette");
    private static Item sourdough = new Item(7.50, "Pain de Campagne");
    private static Item eclair = new Item(2.00, "Eclair");
    private static Item macaron = new Item(1.50, "Macarón");
    private static Item escargo = new Item(9.00, "Escargo");
    private static Item cigarette = new Item(4.00, "Cigarette");
  
    public double Price { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    private static List<Item> _menu = new List<Item> {baguette, sourdough, eclair, macaron, escargo, cigarette};

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