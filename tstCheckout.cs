using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace TestingCheckout
{
    [TestClass]
    public class tstCheckout
    {
        /******************INSTANCE OF THE CLASS TEST******************/
        [TestMethod]
        public void InstanceOK()
        {   
            // create an instance of the class
            clsCheckouts checkout = new clsCheckouts();

            // check that the instance exists
            Assert.IsNotNull(checkout);
        }

        /******************PROPERTY OK TESTS******************/
        [TestMethod]
        public void OrderIdPropertyOK()
        {
            //create an instance of the class
            clsCheckouts checkout = new clsCheckouts();

            //create test data to assign to the property
            int testData = 123;

            //assign the data to the property
            checkout.OrderId = testData;

            //test to see that the two values are the same
            Assert.AreEqual(testData, checkout.OrderId);
        }

        [TestMethod]
        public void CustomerIdPropertyOK()
        {
            clsCheckouts checkout = new clsCheckouts();
            int testData = 999;
            checkout.CustomerId = testData;
            Assert.AreEqual(testData, checkout.CustomerId);
        }

        [TestMethod]
        public void TotalPricePropertyOK()
        {
            clsCheckouts checkout = new clsCheckouts();
            decimal testData = 99.99m;
            checkout.TotalPrice = testData;
            Assert.AreEqual(testData, checkout.TotalPrice);
        }

        [TestMethod]
        public void OrderDatePropertyOK()
        {
            clsCheckouts checkout = new clsCheckouts();
            DateTime testData = DateTime.Today;
            checkout.OrderDate = testData;
            Assert.AreEqual(testData, checkout.OrderDate);
        }

        [TestMethod]
        public void OrderStatusPropertyOK()
        {
            clsCheckouts checkout = new clsCheckouts();
            string testData = "Pending";
            checkout.OrderStatus = testData;
            Assert.AreEqual(testData, checkout.OrderStatus);
        }

        [TestMethod]
        public void ActivePropertyOK()
        {
            clsCheckouts checkout = new clsCheckouts();
            bool testData = true;
            checkout.Active = testData;
            Assert.AreEqual(testData, checkout.Active);
        }

        /******************FIND METHOD TEST******************/
        [TestMethod]
        public void FindMethodOK()
        {
            //create an instance of the class we want to create
            clsCheckouts checkout = new clsCheckouts();

            //create a Boolean variable to store the results of the validation
            bool found;

            //invoke the method
            found = checkout.Find(1);

            //test to see if the result is true
            Assert.IsTrue(found);
        }

        [TestMethod]
        public void TestActiveFound()
        {
            clsCheckouts checkout = new clsCheckouts();
            bool found = checkout.Find(1);
            Assert.AreEqual(true, checkout.Active);
        }

        /******************PROPERTY DATA TESTS******************/
        [TestMethod]
        public void TestOrderIdFound()
        {
            //create an instance of the class we want to create
            clsCheckouts checkout = new clsCheckouts();

            //invoke the Find method
            bool found = checkout.Find(1);

            //check if the OrderId property was correctly set
            Assert.AreEqual(1, checkout.OrderId);
        }

        [TestMethod]
        public void TestCustomerIdFound()
        {
            //create an instance of the class we want to create
            clsCheckouts checkout = new clsCheckouts();

            //invoke the Find method
            bool found = checkout.Find(1);

            //check if the CustomerId property was correctly set
            Assert.AreEqual(123, checkout.CustomerId);
        }

        [TestMethod]
        public void TestTotalPriceFound()
        {
            //create an instance of the class we want to create
            clsCheckouts checkout = new clsCheckouts();

            //invoke the Find method
            bool found = checkout.Find(1);

            //check if the TotalPrice property was correctly set
            Assert.AreEqual(49.99m, checkout.TotalPrice);
        }

        [TestMethod]
        public void TestOrderDateFound()
        {
            //create an instance of the class we want to create
            clsCheckouts checkout = new clsCheckouts();

            //invoke the Find method
            bool found = checkout.Find(1);

            //Check if the OrderDate property was correctly set
            DateTime expected = new DateTime(2023, 12, 25);
            Assert.AreEqual(expected, checkout.OrderDate);
        }

        [TestMethod]
        public void TestOrderStatusFound()
        {
            //create an instance of the class we want to create
            clsCheckouts checkout = new clsCheckouts();

            //invoke the Find method
            bool found = checkout.Find(1);

            //check if the OrderStatus property was correctly set
            Assert.AreEqual("Pending", checkout.OrderStatus);
        }

        [TestMethod]
        public void ValidMethodOK()
        {
            //create instance of the class
            clsCheckouts checkout = new clsCheckouts();

            //Sample good data
            string orderId = "1";
            string customerId = "123";
            string totalPrice = "49.99";
            string orderDate = DateTime.Now.Date.ToString();
            string orderStatus = "Confirmed";

            //call the method and store result
            string error = checkout.Valid(orderId, customerId, totalPrice, orderDate, orderStatus);

            //test that no error was returned
            Assert.AreEqual("", error);
        }

        /******************* ORDER STATUS VALIDATION TESTS *******************/

        [TestMethod]
        public void OrderStatusMinLessOne()
        {
            clsCheckouts checkout = new clsCheckouts();

            //use blank input for OrderStatus
            string error = checkout.Valid("1", "123", "49.99", DateTime.Now.ToShortDateString(), "");

            //expect an error for blank input
            Assert.AreNotEqual("", error);
        }

        [TestMethod]
        public void OrderStatusMinBoundary()
        {
            clsCheckouts checkout = new clsCheckouts();

            string error = checkout.Valid("1", "123", "49.99", DateTime.Now.ToShortDateString(), "A");

            //no error expected
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void OrderStatusMaxPlusOne()
        {
            clsCheckouts checkout = new clsCheckouts();

            string testOrderStatus = new string('A', 51); //51-character string

            string error = checkout.Valid("1", "123", "49.99", DateTime.Now.ToShortDateString(), testOrderStatus);

            //expect an error because it's too long
            Assert.AreNotEqual("", error);
        }

        [TestMethod]
        public void OrderStatusMaxBoundary()
        {
            clsCheckouts checkout = new clsCheckouts();

            string testOrderStatus = new string('A', 50);

            string error = checkout.Valid("1", "123", "49.99", DateTime.Now.ToShortDateString(), testOrderStatus);

            //expect no error to occur
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void OrderStatusWhitespaceOnly()
        {
            clsCheckouts checkout = new clsCheckouts();

            string error = checkout.Valid("1", "123", "49.99", DateTime.Now.ToShortDateString(), "   ");

            //expect an error for whitespace-only input
            Assert.AreNotEqual("", error);
        }

        [TestMethod]
        public void OrderStatusValidMid()
        {
            clsCheckouts checkout = new clsCheckouts();

            string error = checkout.Valid("1", "123", "49.99", DateTime.Now.ToShortDateString(), "Confirmed");

            //expect no error
            Assert.AreEqual("", error);
        }

        /******************* TOTAL PRICE VALIDATION TESTS *******************/

        [TestMethod]
        public void TotalPriceInvalidLetters()
        {
            clsCheckouts checkout = new clsCheckouts();

            string error = checkout.Valid("1", "123", "abc", DateTime.Now.ToShortDateString(), "Confirmed");

            //expect an error for invalid decimal format
            Assert.AreNotEqual("", error);
        }

        [TestMethod]
        public void TotalPriceNegative()
        {
            clsCheckouts checkout = new clsCheckouts();

            string error = checkout.Valid("1", "123", "-1", DateTime.Now.ToShortDateString(), "Confirmed");

            //error for negative value
            Assert.AreNotEqual("", error);
        }

        [TestMethod]
        public void TotalPriceZero()
        {
            clsCheckouts checkout = new clsCheckouts();

            string error = checkout.Valid("1", "123", "0", DateTime.Now.ToShortDateString(), "Confirmed");

            //assume zero is allowed, change to AreNotEqual if not allowed
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void TotalPriceValidMid()
        {
            clsCheckouts checkout = new clsCheckouts();

            string error = checkout.Valid("1", "123", "49.99", DateTime.Now.ToShortDateString(), "Confirmed");

            //no error expected 
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void TotalPriceExtremeMax()
        {
            clsCheckouts checkout = new clsCheckouts();

            string error = checkout.Valid("1", "123", "99999999", DateTime.Now.ToShortDateString(), "Confirmed");

            //expect no error unless you add a max price rule
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void TotalPriceEmpty()
        {
            clsCheckouts checkout = new clsCheckouts();

            string error = checkout.Valid("1", "123", "", DateTime.Now.ToShortDateString(), "Confirmed");

            //expect an error for blank price
            Assert.AreNotEqual("", error);
        }

        /******************* ORDER DATE VALIDATION TESTS *******************/

        [TestMethod]
        public void OrderDateInvalidFormat()
        {
            clsCheckouts checkout = new clsCheckouts();

            string error = checkout.Valid("1", "123", "49.99", "abc", "Confirmed");

            //expect an error for invalid date format
            Assert.AreNotEqual("", error);
        }

        [TestMethod]
        public void OrderDateEmpty()
        {
            clsCheckouts checkout = new clsCheckouts();

            string error = checkout.Valid("1", "123", "49.99", "", "Confirmed");

            //error for empty input
            Assert.AreNotEqual("", error);
        }

        [TestMethod]
        public void OrderDateFuture()
        {
            clsCheckouts checkout = new clsCheckouts();

            string futureDate = DateTime.Now.AddDays(1).ToShortDateString();

            string error = checkout.Valid("1", "123", "49.99", futureDate, "Confirmed");

            //expect error for future dates
            Assert.AreNotEqual("", error);
        }

        [TestMethod]
        public void OrderDateToday()
        {
            clsCheckouts checkout = new clsCheckouts();

            string today = DateTime.Now.ToShortDateString();

            string error = checkout.Valid("1", "123", "49.99", today, "Confirmed");

            //expect no error
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void OrderDatePastMid()
        {
            clsCheckouts checkout = new clsCheckouts();

            string midDate = DateTime.Now.AddYears(-2).ToShortDateString();

            string error = checkout.Valid("1", "123", "49.99", midDate, "Confirmed");

            //no error
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void OrderDateExtremeMax()
        {
            clsCheckouts checkout = new clsCheckouts();

            string extremeDate = "31/12/9999";

            string error = checkout.Valid("1", "123", "49.99", extremeDate, "Confirmed");

            //error due to future date
            Assert.AreNotEqual("", error);
        }




    }
}
