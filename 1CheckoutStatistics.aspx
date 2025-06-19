<%@ Page Language="C#" AutoEventWireup="true" CodeFile="1CheckoutStatistics.aspx.cs" Inherits="_1CheckoutStatistics" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout Statistics</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body style="background-color: #e6f0ff;">
    <form id="form1" runat="server">
        <div class="container mt-5">

            <h2 class="text-center fw-bold mb-4">Checkout Statistics</h2>

            <div class="card shadow-lg mx-auto mb-4" style="max-width: 800px; border-radius: 12px;">
                <div class="card-header fw-semibold bg-light">Grouped by Order Status</div>
                <div class="card-body">
                    <asp:GridView ID="GridViewStGroupByOrderStatus" runat="server" CssClass="table table-striped table-bordered" />
                </div>
            </div>

            <div class="card shadow-lg mx-auto mb-4" style="max-width: 800px; border-radius: 12px;">
                <div class="card-header fw-semibold bg-light">Grouped by Order Date</div>
                <div class="card-body">
                    <asp:GridView ID="GridViewStGroupByOrderDate" runat="server" CssClass="table table-striped table-bordered" />
                </div>
            </div>

            <div class="text-center">
                <asp:Button ID="btnBack" runat="server" Text="Return to List" CssClass="btn btn-primary px-4" OnClick="btnBack_Click" />
            </div>

        </div>
    </form>
</body>
</html>
