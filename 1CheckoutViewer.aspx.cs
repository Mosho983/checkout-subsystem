using System;
using ClassLibrary;

public partial class CheckoutViewer1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsCheckouts checkout = (clsCheckouts)Session["Checkout"];

        lblOrderId.Text = "Order ID: " + checkout.OrderId.ToString();
        lblCustomerId.Text = "Customer ID: " + checkout.CustomerId.ToString();
        lblTotalPrice.Text = "Total Price: " + checkout.TotalPrice.ToString("C");
        lblOrderDate.Text = "Order Date: " + checkout.OrderDate.ToShortDateString();
        lblOrderStatus.Text = "Order Status: " + checkout.OrderStatus;
        lblActive.Text = "Active: " + (checkout.Active ? "Yes" : "No");
    }
}
