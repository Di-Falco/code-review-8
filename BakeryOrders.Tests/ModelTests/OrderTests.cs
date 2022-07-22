using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BakeryOrders.Models;

namespace BakeryOrders.Tests
{
  [TestClass]
  public class OrderTests
  {
    [TestMethod]
    public void OrderConstructor_CreatesOrderObject_Order()
    {
      Order testOrder = new Order("test title", "test description", "test date");
      Assert.AreEqual(typeof(Order), testOrder.GetType());
    }

  }
}