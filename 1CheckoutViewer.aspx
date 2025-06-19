<%@ Page Language="C#" AutoEventWireup="true" CodeFile="1CheckoutViewer.aspx.cs" Inherits="CheckoutViewer1" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout Viewer</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 20px;">

            <asp:Label ID="lblOrderId" runat="server" Text="" /><br /><br />
            <asp:Label ID="lblCustomerId" runat="server" Text="" /><br /><br />
            <asp:Label ID="lblTotalPrice" runat="server" Text="" /><br /><br />
            <asp:Label ID="lblOrderDate" runat="server" Text="" /><br /><br />
            <asp:Label ID="lblOrderStatus" runat="server" Text="" /><br /><br />
            <asp:Label ID="lblActive" runat="server" Text="" /><br /><br />

        </div>
    </form>
</body>
</html>
