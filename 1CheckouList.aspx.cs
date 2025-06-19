using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_List : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //only update the list on the first page load
        if (IsPostBack == false)
        {
            DisplayCheckouts();
        }
    }

    void DisplayCheckouts()
    {
        //create an instance of the collection class
        clsCheckoutCollection Checkouts = new clsCheckoutCollection();

        //set the data source to the list of checkouts
        lstCheckoutList.DataSource = Checkouts.CheckoutList;

        //set the value and text fields
        lstCheckoutList.DataValueField = "OrderId";
        lstCheckoutList.DataTextField = "OrderStatus";

        //bind the data to the list control
        lstCheckoutList.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Session["OrderId"] = -1; 
        Response.Redirect("1CheckouDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (lstCheckoutList.SelectedIndex != -1)
        {
            int OrderId = Convert.ToInt32(lstCheckoutList.SelectedValue);
            Session["OrderId"] = OrderId;
            Response.Redirect("1CheckouDataEntry.aspx");
        }
        else
        {
            lblError.Text = "Please select a record to edit.";
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (lstCheckoutList.SelectedIndex != -1)
        {
            int OrderId = Convert.ToInt32(lstCheckoutList.SelectedValue);
            Session["OrderId"] = OrderId;
            Response.Redirect("1CheckoutConfirmDelete.aspx");
        }
        else
        {
            lblError.Text = "Please select a record to delete from the list.";
        }
    }
    protected void btnClearFilter_Click(object sender, EventArgs e)
    {
        clsCheckoutCollection AllCheckouts = new clsCheckoutCollection();
        txtFilter.Text = "";

        lstCheckoutList.DataSource = AllCheckouts.CheckoutList;
        lstCheckoutList.DataValueField = "OrderId";
        lstCheckoutList.DataTextField = "OrderStatus";
        lstCheckoutList.DataBind();
    }
    protected void btnApplyFilter_Click(object sender, EventArgs e)
    {
        clsCheckoutCollection FilteredCheckouts = new clsCheckoutCollection();
        FilteredCheckouts.ReportByOrderStatus("");

        lstCheckoutList.DataSource = FilteredCheckouts.CheckoutList;
        lstCheckoutList.DataValueField = "OrderId";
        lstCheckoutList.DataTextField = "OrderStatus";
        lstCheckoutList.DataBind();
    }

    protected void btnViewStatistics_Click(object sender, EventArgs e)
    {
        Response.Redirect("1CheckoutStatistics.aspx");
    }

    protected void btnReturnToMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("TeamMainMenu.aspx");
    }

}