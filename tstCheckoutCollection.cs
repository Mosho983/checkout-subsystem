

using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace Testing4
{
    [TestClass]
    public class tstCheckoutCollection
    {
        [TestMethod]
        public void InstanceOK()
        {

            clsCheckoutCollection allCheckouts = new clsCheckoutCollection();
            Assert.IsNotNull(allCheckouts);

        }

        [TestMethod]

        public void CheckoutListOK()
        {
            //create an instance of the collection
            clsCheckoutCollection allCheckouts = new clsCheckoutCollection();

            //create a test list
            List<clsCheckouts> testList = new List<clsCheckouts>();

            //create a test item
            clsCheckouts testItem = new clsCheckouts();

            testItem.OrderId = 1;
            testItem.CustomerId = 101;
            testItem.TotalPrice = 29.99m;
            testItem.OrderDate = DateTime.Now.Date;
            testItem.OrderStatus = "Pending";

            //cdd the test item to the list
            testList.Add(testItem);

            //assign the list to the collection
            allCheckouts.CheckoutList = testList;

            //assert that the two are equal
            Assert.AreEqual(allCheckouts.CheckoutList, testList);

        }

        [TestMethod]
        public void ThisCheckoutPropertyOK()
        {
            clsCheckoutCollection allCheckouts = new clsCheckoutCollection();
            clsCheckouts testItem = new clsCheckouts();

            testItem.OrderId = 2;
            testItem.CustomerId = 202;
            testItem.TotalPrice = 59.99m;
            testItem.OrderDate = DateTime.Now.Date;
            testItem.OrderStatus = "Shipped";

            allCheckouts.ThisCheckout = testItem;

            Assert.AreEqual(allCheckouts.ThisCheckout, testItem);
        }
        [TestMethod]
        public void CountPropertyOK()
        {
            clsCheckoutCollection allCheckouts = new clsCheckoutCollection();
            int testCount = 2;

            allCheckouts.Count = testCount;

            Assert.AreEqual(allCheckouts.Count, testCount);

        }

        [TestMethod]
        public void ListAndCountOK()
        {
            //create an instance of the collection we want to test
            clsCheckoutCollection allCheckouts = new clsCheckoutCollection();

            //create some test data to assign to the CheckoutList property
            List<clsCheckouts> testList = new List<clsCheckouts>();

            //create a single test item
            clsCheckouts testItem = new clsCheckouts();
            testItem.OrderId = 1;
            testItem.CustomerId = 101;
            testItem.TotalPrice = 29.99m;
            testItem.OrderDate = DateTime.Now.Date;
            testItem.OrderStatus = "Pending";

            //add the test item to the test list
            testList.Add(testItem);

            //set the Count manually (if using the basic Count property)
            allCheckouts.CheckoutList = testList;

            //test to confirm Count matches and the list is stored correctly
            Assert.AreEqual(allCheckouts.Count, testList.Count);
        }

        [TestMethod]
        public void TwoRecordsPresent()
        {
            clsCheckoutCollection allCheckouts = new clsCheckoutCollection();
            Assert.AreEqual(allCheckouts.Count, 2);


        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            clsCheckoutCollection allCheckouts = new clsCheckoutCollection();
            clsCheckouts testItem = new clsCheckouts();


            testItem.CustomerId = 200;
            testItem.TotalPrice = 19.99m;
            testItem.OrderDate = DateTime.Now.Date;
            testItem.OrderStatus = "Initial";
            testItem.Active = true;

            allCheckouts.ThisCheckout = testItem;
            int primaryKey = allCheckouts.Add();
            testItem.OrderId = primaryKey;


            testItem.CustomerId = 300;
            testItem.TotalPrice = 29.99m;
            testItem.OrderDate = DateTime.Now.Date.AddDays(-1);
            testItem.OrderStatus = "Updated";
            testItem.Active = false;

            allCheckouts.ThisCheckout = testItem;
            allCheckouts.Update();


            allCheckouts.ThisCheckout.Find(primaryKey);
            Assert.AreEqual(allCheckouts.ThisCheckout.CustomerId, testItem.CustomerId);
            Assert.AreEqual(allCheckouts.ThisCheckout.TotalPrice, testItem.TotalPrice);
            Assert.AreEqual(allCheckouts.ThisCheckout.OrderDate, testItem.OrderDate);
            Assert.AreEqual(allCheckouts.ThisCheckout.OrderStatus, testItem.OrderStatus);
            Assert.AreEqual(allCheckouts.ThisCheckout.Active, testItem.Active);
        }

        [TestMethod]

        public void DeleteMethodOK()
        {
            //create an instance of the class we want to create
            clsCheckoutCollection allCheckouts = new clsCheckoutCollection();
            //create the tiem of test data
            clsCheckouts testItem = new clsCheckouts();

            //set its properties
            testItem.CustomerId = 400;
            testItem.TotalPrice = 49.99m;
            testItem.OrderDate = DateTime.Now.Date;
            testItem.OrderStatus = "To be deleted";
            testItem.Active = true;

            //set this ThisCheckout to the test data
            allCheckouts.ThisCheckout = testItem;

            //add the record to the collection
            int primaryKey = allCheckouts.Add();

            //set the primary key of the test data
            testItem.OrderId = (primaryKey);

            //find the record in the collection
            allCheckouts.ThisCheckout.Find(primaryKey);

            //delete the record
            allCheckouts.Delete();

            //now try to find the record again
            bool found = allCheckouts.ThisCheckout.Find(primaryKey);

            //test to see if record was not found
            Assert.IsFalse(found);

        }

        [TestMethod]
        public void ReportByOrderStatusOK()
        {
            //create an instance of the class we want to create
            clsCheckoutCollection allCheckouts = new clsCheckoutCollection();
            //create a filtered collection
            clsCheckoutCollection filteredCheckouts = new clsCheckoutCollection();
            //apply a filter
            filteredCheckouts.ReportByOrderStatus("");
            //test to see if the two collections are equal
            Assert.AreEqual(allCheckouts.Count, filteredCheckouts.Count);
        }

        [TestMethod]
        public void ReportByOrderStatusNoneFound()
        {
            //create an instance of the class we want to create
            clsCheckoutCollection filteredCheckouts = new clsCheckoutCollection();
            //apply a filter that should return no results
            filteredCheckouts.ReportByOrderStatus("NonExistentStatus");
            //test to see if the count is zero
            Assert.AreEqual(0, filteredCheckouts.Count);
        }
        [TestMethod]

        public void ReportByOrderStatus(string orderStatus)
        {
            //create an instance of the class we want to create
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@OrderStatus", orderStatus);
            DB.Execute("sproc_CheckoutManagement_FilterByOrderStatus");
        }

        [TestMethod]
        public void ReportByOrderStatusTestDataFound()
        {
            // Create an instance of the filtered data
            clsCheckoutCollection FilteredCheckouts = new clsCheckoutCollection();
            // Variable to store the outcome
            Boolean OK = true;
            // Apply a filter that should return two records
            FilteredCheckouts.ReportByOrderStatus("Shipped");

            // Check if the count is exactly 2
            if (FilteredCheckouts.Count == 2)
            {
                // Check the first record's OrderId
                if (FilteredCheckouts.CheckoutList[0].OrderId != 3)
                {
                    OK = false;
                }
                // Check the second record's OrderId
                if (FilteredCheckouts.CheckoutList[1].OrderId != 5)
                {
                    OK = false;
                }
            }
            else
            {
                OK = false;
            }

            // Final assertion
            Assert.IsTrue(OK);
        }
    }
}






