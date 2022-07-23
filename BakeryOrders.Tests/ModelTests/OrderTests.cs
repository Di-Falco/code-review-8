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
      Order testOrder = new Order("test title", "test description", "test date",0,0,0,0,0,0);
      Assert.AreEqual(typeof(Order), testOrder.GetType());
    }

    [TestMethod]
    public void OrderConstructor_ReturnsTitleDescriptionAndDate_String()
    {
      string title = "test title";
      string description = "test description";
      string date = "test date";
      Order testOrder = new Order(title, description, date,0,0,0,0,0,0);
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
      Order testOrder1 = new Order("title1", "description1", "date1",0,0,0,0,0,0);
      Order testOrder2 = new Order("title2", "description2", "date2",0,0,0,0,0,0);
      List<Order> expected = new List<Order> {testOrder1, testOrder2};
      List<Order> actual = Order.GetAll();

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Find_ReturnSpecificOrder_Order()
    {
      Order testOrder1 = new Order("title1", "description1", "date1",0,0,0,0,0,0);
      Order testOrder2 = new Order("title2", "description2", "date2",0,0,0,0,0,0);
      Order result = Order.Find(2);

      Assert.AreEqual(testOrder2, result);
    }

    [TestMethod]
    public void Delete_DeleteSpecificOrder_OrderList()
    {
      Order testOrder1 = new Order("title1", "description1", "date1",0,0,0,0,0,0);
      Order testOrder2 = new Order("title2", "description2", "date2",0,0,0,0,0,0);
      Order testOrder3 = new Order("title3", "description3", "date3",0,0,0,0,0,0);
      List<Order> expected = new List<Order> { testOrder1, testOrder3 };

      Order.Delete(2);
      List<Order> result = Order.GetAll();

      CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Complete_ToggleCompleteValue_True()
    {
      Order testOrder = new Order("title", "description", "date",0,0,0,0,0,0);
      testOrder.Complete();

      Assert.AreEqual(true, testOrder.Fulfilled);
    }

    [TestMethod]
    public void Complete_ToggleCompleteValue_False()
    {
      Order testOrder = new Order("title", "description", "date",0,0,0,0,0,0);
      testOrder.Complete();
      testOrder.Complete();      

      Assert.AreEqual(false, testOrder.Fulfilled);
    }    

    [TestMethod]
    public void AddAllItems_AddCorrectItemsToOrder_Item()
    {
      int item1 = 1; int item2 = 2; int item3 = 3; int item4 = 4; int item5 = 5; int item6 = 6;
      Order testOrder = new Order("title", "description", "date", item1,item2,item3,item4,item5,item6);

      Assert.AreEqual(1, testOrder.Items[0].Quantity);
      Assert.AreEqual(2, testOrder.Items[1].Quantity);
      Assert.AreEqual(3, testOrder.Items[2].Quantity);
      Assert.AreEqual(4, testOrder.Items[3].Quantity);
      Assert.AreEqual(5, testOrder.Items[4].Quantity);
      Assert.AreEqual(6, testOrder.Items[5].Quantity);
    } 
  }
}