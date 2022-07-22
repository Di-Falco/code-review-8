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

    [TestMethod]
    public void OrderConstructor_ReturnsTitleDescriptionAndDate_String()
    {
      string title = "test title";
      string description = "test description";
      string date = "test date";
      Order testOrder = new Order(title, description, date);
      string resultTitle = testOrder.Title;
      string resultDescription = testOrder.Description;
      string resultDate = testOrder.Date;
      
      Assert.AreEqual(title, resultTitle);
      Assert.AreEqual(description, resultDescription);
      Assert.AreEqual(date, resultDate);
    }

  }
}