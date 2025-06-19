using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsCheckoutCollection
    {
        //private data member for the list
        List<clsCheckouts> mCheckoutList = new List<clsCheckouts>();

        //private data member for the current checkout
        clsCheckouts mThisCheckout = new clsCheckouts();
        //public property for the checkout list
        public List<clsCheckouts> CheckoutList
        {
            get
            {
                return mCheckoutList;
            }
            set
            {
                mCheckoutList = value;
            }
        }

        //public property for the current checkout
        public clsCheckouts ThisCheckout
        {

            get
            {
                return mThisCheckout;
            }
            set
            {
                mThisCheckout = value;
            }
        }

        


        //public property for the count
        public int Count
        {
            get { return mCheckoutList.Count; }
            set {}
        }

        // constructor for the class
        public clsCheckoutCollection()
        {
            int Index = 0;
            int RecordCount = 0;

            //create the object for the data connection
            clsDataConnection DB = new clsDataConnection();

            //execute the stored procedure
            DB.Execute("sproc_CheckoutManagement_SelectAll");
            populateArray(DB);

            //get the count of records
            RecordCount = DB.Count;

            //loop through each record
            while (Index < RecordCount)
            {
                //create a blank checkout
                clsCheckouts ACheckout = new clsCheckouts();

                //read in fields for the current record
                ACheckout.OrderId = Convert.ToInt32(DB.DataTable.Rows[Index]["OrderId"]);
                ACheckout.CustomerId = Convert.ToInt32(DB.DataTable.Rows[Index]["CustomerId"]);
                ACheckout.TotalPrice = Convert.ToDecimal(DB.DataTable.Rows[Index]["TotalPrice"]);
                ACheckout.OrderDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["OrderDate"]);
                ACheckout.OrderStatus = Convert.ToString(DB.DataTable.Rows[Index]["OrderStatus"]);
                ACheckout.Active = Convert.ToBoolean(DB.DataTable.Rows[Index]["Active"]);

                //add the record to the private data member
                mCheckoutList.Add(ACheckout);

                //move to the next record
                Index++;
            }
        }

        //add method 
        public int Add()
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();

            // set the parameters for the stored procedure
            DB.AddParameter("@CustomerId", ThisCheckout.CustomerId);
            DB.AddParameter("@TotalPrice", ThisCheckout.TotalPrice);
            DB.AddParameter("@OrderDate", ThisCheckout.OrderDate);
            DB.AddParameter("@OrderStatus", ThisCheckout.OrderStatus);
            DB.AddParameter("@Active", ThisCheckout.Active);

            // execute the query returning the primary key value
            return DB.Execute("sproc_CheckoutManagement_Insert");
        }

        //update method 
        public void Update()
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();

            //set the parameters for the stored procedure
            DB.AddParameter("@OrderId", ThisCheckout.OrderId);
            DB.AddParameter("@CustomerId", ThisCheckout.CustomerId);
            DB.AddParameter("@TotalPrice", ThisCheckout.TotalPrice);
            DB.AddParameter("@OrderDate", ThisCheckout.OrderDate);
            DB.AddParameter("@OrderStatus", ThisCheckout.OrderStatus);
            DB.AddParameter("@Active", ThisCheckout.Active);

            //execute the stored procedure
            DB.Execute("sproc_CheckoutManagement_Update");
        }

        //delete method
        public void Delete()
        {
            //delets the record pointed to by ThisCheckout
            //coonnect to the database  
            clsDataConnection DB = new clsDataConnection();
            //set the parameter for the stored procedure
            DB.AddParameter("@OrderId", ThisCheckout.OrderId);
            //execute the stored procedure
            DB.Execute("sproc_CheckoutManagement_Delete");
        }

        public void ReportByOrderStatus(string OrderStatus)
        {
            //filters the checkout list by order status
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //send the parameter to the database
            DB.AddParameter("@OrderStatus", OrderStatus);
            //execute the stored procedure
            DB.Execute("sproc_CheckoutManagement_FilterByOrderStatus");
            //populate the array list with the data from the database
            populateArray(DB);
        }

        void populateArray(clsDataConnection DB)
        {
            //populate the array list with the data from the database
            int Index = 0;
            int RecordCount = 0;
            //get the count of records
            RecordCount = DB.Count;
            //clear the private data member
            mCheckoutList.Clear();
            //loop through each record
            while (Index < RecordCount)
            {
                //create a blank checkout
                clsCheckouts ACheckout = new clsCheckouts();
                //read in fields for the current record
                ACheckout.OrderId = Convert.ToInt32(DB.DataTable.Rows[Index]["OrderId"]);
                ACheckout.CustomerId = Convert.ToInt32(DB.DataTable.Rows[Index]["CustomerId"]);
                ACheckout.TotalPrice = Convert.ToDecimal(DB.DataTable.Rows[Index]["TotalPrice"]);
                ACheckout.OrderDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["OrderDate"]);
                ACheckout.OrderStatus = Convert.ToString(DB.DataTable.Rows[Index]["OrderStatus"]);
                ACheckout.Active = Convert.ToBoolean(DB.DataTable.Rows[Index]["Active"]);
                //add the record to the private data member
                mCheckoutList.Add(ACheckout);
                //move to the next record
                Index++;
            }

        }

        
    }
}
