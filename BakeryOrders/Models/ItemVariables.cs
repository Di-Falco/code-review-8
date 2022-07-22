using System;
using System.Collections.Generic;

namespace BakeryOrders.Models
{
  public partial class Item
  {
    public static Item baguette = new Item(5.00, "Baguette");
    public static Item sourdough = new Item(7.50, "Sourdough");
    public static Item eclair = new Item(2.00, "Eclair");
    public static Item macaron = new Item(1.50, "Macaron");
    public static Item escargo = new Item(9.00, "Escargo");
    public static Item cigarette = new Item(1.00, "Cigarette");

    private static List<Item> _menu = new List<Item> {baguette, sourdough, eclair, macaron, escargo, cigarette};
  }
}