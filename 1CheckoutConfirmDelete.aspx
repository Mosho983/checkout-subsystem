<%@ Page Language="C#" AutoEventWireup="true" CodeFile="1CheckoutConfirmDelete.aspx.cs" Inherits="_1_ConfirmDelete" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirm Delete</title>
    <link href="Content/bootstrap-reboot.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.bundle.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Are you sure you want to delete this record?</h2>
            <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click" Width="120px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnNo" runat="server" Text="No" OnClick="btnNo_Click" Width="120px" />
        </div>
    </form>
</body>
</html>
