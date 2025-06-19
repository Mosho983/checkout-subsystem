using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1CheckoutStatistics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsCheckouts clsCheckout = new clsCheckouts();

        // retrieve data from the database
        DataTable dt = clsCheckout.StatisticsGroupedByOrderStatus();

        // upload DT into GridView
        GridViewStGroupByOrderStatus.DataSource = dt;
        GridViewStGroupByOrderStatus.DataBind();

        // change the header of the first column
        GridViewStGroupByOrderStatus.HeaderRow.Cells[0].Text = "Total";

        // retrieve data from the database
        dt = clsCheckout.StatisticsGroupedByOrderDate();

        // upload DT into GridView
        GridViewStGroupByOrderDate.DataSource = dt;
        GridViewStGroupByOrderDate.DataBind();

        // change the header of the first column
        GridViewStGroupByOrderDate.HeaderRow.Cells[0].Text = "Total";
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("1CheckoutList.aspx");
    }


}