using System;
using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _1_ConfirmDelete : System.Web.UI.Page
{
    int OrderId;

    protected void Page_Load(object sender, EventArgs e)
    {
        OrderId = Convert.ToInt32(Session["OrderId"]);
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        //create instance of the collection
        clsCheckoutCollection checkoutCollection = new clsCheckoutCollection();
        //find the record to delete
        checkoutCollection.ThisCheckout.Find(OrderId);
        //delete the record
        checkoutCollection.Delete();
        //redirect back to list page
        Response.Redirect("1CheckouList.aspx");
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        //just return to list without deleting
        Response.Redirect("1CheckouList.aspx");

    }
}
