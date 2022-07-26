using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BakeryOrders.Models;

namespace BakeryOrders.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {

    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesVendorObject_Vendor()
    {
      Vendor testVendor = new Vendor("test name", "test description");
      Assert.AreEqual(typeof(Vendor), testVendor.GetType());
    }

    [TestMethod]
    public void VendorConstructor_ReturnsNameAndDescription_String()
    {
      string name = "test name";
      string description = "test description";
      Vendor testVendor = new Vendor(name, description);
      string resultName = testVendor.Name;
      string resultDescription = testVendor.Description;
      
      Assert.AreEqual(name, resultName);
      Assert.AreEqual(description, resultDescription);
    }

    [TestMethod]
    public void GetAll_ReturnAllVendor_VendorList()
    {
      Vendor testVendor1 = new Vendor("name1", "description1");
      Vendor testVendor2 = new Vendor("name2", "description2");
      List<Vendor> expected = new List<Vendor> {testVendor1, testVendor2};
      List<Vendor> actual = Vendor.GetAll();

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Find_ReturnSpecificVendor_Vendor()
    {
      Vendor testVendor1 = new Vendor("name1", "description1");
      Vendor testVendor2 = new Vendor("name2", "description2");
      Vendor result = Vendor.Find(2);

      Assert.AreEqual(testVendor2, result);
    }

    [TestMethod]
    public void Delete_DeleteSpecificVendor_VendorList()
    {
      Vendor testVendor1 = new Vendor("name1", "description1");
      Vendor testVendor2 = new Vendor("name2", "description2");
      Vendor testVendor3 = new Vendor("name3", "description3");
      List<Vendor> expected = new List<Vendor> { testVendor1, testVendor3 };

      Vendor.Delete(2);
      List<Vendor> result = Vendor.GetAll();

      CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void AddOrder_AddOrderObjectToVendorObject_OrderList()
    {
      Vendor testVendor = new Vendor("name", "description");
      Order testOrder = new Order("title", "description", "date",0,0,0,0,0,0);
      List<Order> expected = new List<Order> { testOrder };

      testVendor.AddOrder(testOrder);
      List<Order> actual = testVendor.Orders;

      CollectionAssert.AreEqual(expected, actual);      
    }    
  }
}