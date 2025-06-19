<%@ Page Language="C#" AutoEventWireup="true" CodeFile="1CheckouList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout List</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body style="background-color: #e6f0ff;">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center fw-bold mb-4">Checkout List</h2>

            <div class="card shadow-lg mx-auto" style="max-width: 800px; border-radius: 12px;">
                <div class="card-body">

                    <asp:ListBox ID="lstCheckoutList" runat="server" CssClass="form-control mb-4" Height="300px" />

                    <div class="d-flex flex-wrap gap-3 mb-4">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary w-100" OnClick="btnAdd_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary w-100" OnClick="btnEdit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-primary w-100" OnClick="btnDelete_Click" />
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="lblFilter" runat="server" Text="Enter an Order Status:" CssClass="form-label" />
                        <asp:TextBox ID="txtFilter" runat="server" CssClass="form-control" />
                    </div>

                    <div class="d-flex flex-wrap gap-3 mb-4">
                        <asp:Button ID="btnApplyFilter" runat="server" Text="Apply Filter" CssClass="btn btn-primary w-100" OnClick="btnApplyFilter_Click" />
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnClearFilter" runat="server" Text="Clear Filter" CssClass="btn btn-primary w-100" OnClick="btnClearFilter_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnViewStatistics" runat="server" Text="View Statistics" CssClass="btn btn-primary w-100" OnClick="btnViewStatistics_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnReturnToMenu" runat="server" Text="Return to Main Menu" CssClass="btn btn-primary w-100" OnClick="btnReturnToMenu_Click" />
                    </div>

                    <asp:Label ID="lblError" runat="server" CssClass="text-danger" />

                </div>
            </div>
        </div>
    </form>
</body>
</html>
