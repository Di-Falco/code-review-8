using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BakeryOrders.Models;

namespace BakeryOrders.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {

    public void Dispose()
    {
      Order.ClearAll();
    }

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

    [TestMethod]
    public void GetAll_ReturnAllOrders_OrderList()
    {
      Order testOrder1 = new Order("title1", "description1", "date1");
      Order testOrder2 = new Order("title2", "description2", "date2");
      List<Order> expected = new List<Order> {testOrder1, testOrder2};
      List<Order> actual = Order.GetAll();

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Find_ReturnSpecificOrder_Order()
    {
      Order testOrder1 = new Order("title1", "description1", "date1");
      Order testOrder2 = new Order("title2", "description2", "date2");
      Order result = Order.Find(2);

      Assert.AreEqual(testOrder2, result);
    }

    [TestMethod]
    public void Delete_DeleteSpecificOrder_OrderList()
    {
      Order testOrder1 = new Order("title1", "description1", "date1");
      Order testOrder2 = new Order("title2", "description2", "date2");
      Order testOrder3 = new Order("title3", "description3", "date3");
      List<Order> expected = new List<Order> { testOrder1, testOrder3 };

      Order.Delete(2);
      List<Order> result = Order.GetAll();

      CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Complete_ToggleCompleteValue_True()
    {
      Order testOrder = new Order("title", "description", "date");
      testOrder.Complete();

      Assert.AreEqual(true, testOrder.Fulfilled);
    }
  }
}