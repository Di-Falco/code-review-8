using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BakeryOrders.Models;

namespace BakeryOrders.Tests
{
  [TestClass]
  public class ItemTests
  {
    [TestMethod]
    public void ItemConstructor_CreateItemObject_Item()
    {
      Item testItem = new Item(1.00, "test item");
      Assert.AreEqual(typeof(Item), testItem.GetType());
    }

    [TestMethod]
    public void AddQuantity_AddQuantityToItem_Int()
    {
      Item testItem = new Item(1.00, "test item");
      testItem.AddQuantity(10);

      Assert.AreEqual(10, testItem.Quantity);
    }

    [TestMethod]
    public void Buy_ReturnCostToPurchaseAllOfOneItem_Double()
    {
      Item testItem = new Item(1.25, "test item");
      testItem.AddQuantity(10);
      
      double price = testItem.Buy();

      Assert.AreEqual(12.5, price);
    }
  }
}