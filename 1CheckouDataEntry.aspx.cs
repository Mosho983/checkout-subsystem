using System;
using ClassLibrary;

public partial class CheckouDataEntry1 : System.Web.UI.Page
{
    // global variable for OrderId
    int OrderId;

    protected void Page_Load(object sender, EventArgs e)
    {
        OrderId = Convert.ToInt32(Session["OrderId"]);

        if (!IsPostBack && OrderId != -1)
        {
            DisplayCheckout();
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        clsCheckouts checkout = new clsCheckouts();

        string orderId = txtOrderId.Text;
        string customerId = txtCustomerId.Text;
        string totalPrice = txtTotalPrice.Text;
        string orderDate = txtOrderDate.Text;
        string orderStatus = txtOrderStatus.Text;

        string error = checkout.Valid(orderId, customerId, totalPrice, orderDate, orderStatus);

        if (error == "")
        {
            checkout.OrderId = OrderId;
            checkout.CustomerId = Convert.ToInt32(customerId);
            checkout.TotalPrice = Convert.ToDecimal(totalPrice);
            checkout.OrderDate = Convert.ToDateTime(orderDate);
            checkout.OrderStatus = orderStatus;
            checkout.Active = chkActive.Checked;

            clsCheckoutCollection checkoutCollection = new clsCheckoutCollection();
            checkoutCollection.ThisCheckout = checkout;

            if (OrderId == -1)
            {
                // new record
                checkoutCollection.Add();
            }
            else
            {
                // existing record
                checkoutCollection.Update();
            }

            Response.Redirect("1CheckoutList.aspx");
        }
        else
        {
            lblError.Text = error;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("1CheckoutList.aspx");
    }

    protected void btnReturnToMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("TeamMainMenu.aspx");
    }

    void DisplayCheckout()
    {
        clsCheckouts checkout = new clsCheckouts();
        checkout.Find(OrderId);

        txtOrderId.Text = checkout.OrderId.ToString();
        txtCustomerId.Text = checkout.CustomerId.ToString();
        txtTotalPrice.Text = checkout.TotalPrice.ToString();
        txtOrderDate.Text = checkout.OrderDate.ToString("yyyy-MM-dd");
        txtOrderStatus.Text = checkout.OrderStatus;
        chkActive.Checked = checkout.Active;
    }

    
    protected void btnFind_Click(object sender, EventArgs e)
    {
        clsCheckouts checkout = new clsCheckouts();
        int enteredOrderId;

        if (int.TryParse(txtOrderId.Text, out enteredOrderId))
        {
            bool found = checkout.Find(enteredOrderId);

            if (found)
            {
                txtCustomerId.Text = checkout.CustomerId.ToString();
                txtTotalPrice.Text = checkout.TotalPrice.ToString();
                txtOrderDate.Text = checkout.OrderDate.ToString("yyyy-MM-dd");
                txtOrderStatus.Text = checkout.OrderStatus;
                chkActive.Checked = checkout.Active;
                lblError.Text = ""; 
            }
            else
            {
                lblError.Text = "Order ID not found.";
            }
        }
        else
        {
            lblError.Text = "Please enter a valid Order ID.";
        }
    }
}
