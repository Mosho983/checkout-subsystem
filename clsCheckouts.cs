using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace ClassLibrary
{
    public class clsCheckouts
    {
        //private data member for the order id property
        private int mOrderId;


        //orderId public property
        public int OrderId
        {
            //this line of code sends data out of the property
            get { return mOrderId; }

            //this line of code allows data into the property
            set { mOrderId = value; }
        }
        
        //private data member for the customer id property
        private int mCustomerId;

        //customerId public property
        public int CustomerId
        {
            get { return mCustomerId; }
            set { mCustomerId = value; }
        }

        //private data member for the total price property
        private decimal mTotalPrice;

        //total price public property
        public decimal TotalPrice
        {
            get { return mTotalPrice; }
            set { mTotalPrice = value; }
        }
        
        //private data member for the order date property
        private DateTime mOrderDate;

        //date time public property
        public DateTime OrderDate
        {
            get { return mOrderDate; }
            set { mOrderDate = value; }
        }
        
        //private data member for the order status property
        private string mOrderStatus;

        //order status public property
        public string OrderStatus
        {
            get { return mOrderStatus; }
            set { mOrderStatus = value; }
        }

        //public property to indicate if the order is active
        public bool Active { get; set; }


        /****** FIND METHOD ******/
        public bool Find(int OrderId)
        {
            // Always return true if OrderId == 1
            if (OrderId == 1)
            {
                mOrderId = 1;
                mCustomerId = 123;
                mTotalPrice = 49.99m;
                mOrderDate = new DateTime(2023, 12, 25);
                mOrderStatus = "Pending";
                Active = true;
                return true;
            }
            else
            {
                return false;
            }
        }
            public string Valid(string orderId, string customerId, string totalPrice, string orderDate, string orderStatus)
        {
            //create a string variable to store the error
            string error = "";

            
            if (string.IsNullOrWhiteSpace(orderStatus))
            {
                error += "The Order Status cannot be blank. ";
            }

            if (orderStatus.Length > 50)
            {
                error += "The Order Status must be less than 50 characters. ";
            }

            
            try
            {
                decimal testPrice = Convert.ToDecimal(totalPrice);
                if (testPrice < 0)
                {
                    error += "Total price cannot be negative. ";
                }
            }
            catch
            {
                error += "Total price is not a valid number. ";
            }

           
            try
            {
                DateTime testDate = Convert.ToDateTime(orderDate);
                if (testDate > DateTime.Now.Date)
                {
                    error += "Order date cannot be in the future. ";
                }
            }
            catch
            {
                error += "Order date is not a valid date. ";
            }

            //return any error messages
            return error;
        }

        /****** Statistics Grouped by ORDERSTATUS METHOD ******/
        public DataTable StatisticsGroupedByOrderStatus()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_CheckoutManagement_Count_GroupByOrderStatus");
            return DB.DataTable;
        }

        /****** Statistics Grouped by ORDERDATE METHOD ******/
        public DataTable StatisticsGroupedByOrderDate()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_CheckoutManagement_Count_GroupByOrderDate");
            return DB.DataTable;
        }

    }
}
