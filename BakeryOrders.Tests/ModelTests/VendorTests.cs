using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BakeryOrders.Models;

namespace BakeryOrders.TestClass
{
  [TestClass]
  public class VendorTests
  {
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

    
  }
}