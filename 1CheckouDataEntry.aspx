<%@ Page Language="C#" AutoEventWireup="true" CodeFile="1CheckouDataEntry.aspx.cs" Inherits="CheckouDataEntry1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout Data Entry</title>

    <!-- Bootstrap 5.3.3 and Bootstrap Icons -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet" />
</head>
<body style="background-color: #e6f0ff;">
    <form id="form1" runat="server">
        <div class="container mt-5">

            <h2 class="text-center fw-bold mb-4">Checkout Management System</h2>

            <div class="card shadow-lg mx-auto" style="max-width: 800px; border-radius: 12px;">
                <div class="card-header bg-light text-dark fw-semibold">
                    Checkout Form
                </div>
                <div class="card-body">

                   
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="txtOrderId" class="form-label">Order ID</label>
                            <asp:TextBox ID="txtOrderId" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-6 d-flex align-items-end">
                            <asp:LinkButton ID="btnFind" runat="server" OnClick="btnFind_Click" CssClass="btn btn-primary w-100">
                                <i class="bi bi-search"></i> Find
                            </asp:LinkButton>
                        </div>
                    </div>

                    <div class="mb-3">
                        <label for="txtCustomerId" class="form-label">Customer ID</label>
                        <asp:TextBox ID="txtCustomerId" runat="server" CssClass="form-control" />
                    </div>

                    <div class="mb-3">
                        <label for="txtTotalPrice" class="form-label">Total Price</label>
                        <asp:TextBox ID="txtTotalPrice" runat="server" CssClass="form-control" />
                    </div>

                    <div class="mb-3">
                        <label for="txtOrderDate" class="form-label">Order Date</label>
                        <asp:TextBox ID="txtOrderDate" runat="server" CssClass="form-control" />
                    </div>

                    <div class="mb-3">
                        <label for="txtOrderStatus" class="form-label">Order Status</label>
                        <asp:TextBox ID="txtOrderStatus" runat="server" CssClass="form-control" />
                    </div>

                    <div class="form-check mb-3">
                        <asp:CheckBox ID="chkActive" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkActive">Active</label>
                    </div>

                    
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger d-block mb-3" />

                   
                    <div class="d-flex justify-content-between gap-3">

                       
                        <asp:LinkButton ID="btnOK" runat="server" OnClick="btnOK_Click" CssClass="btn btn-success w-100 fw-bold">
                            <i class="bi bi-check-circle"></i> Ok
                        </asp:LinkButton>

                        
                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-danger w-100">
                            <i class="bi bi-x-circle"></i> Cancel
                        </asp:LinkButton>

                      
                        <asp:LinkButton ID="btnReturnToMenu" runat="server" OnClick="btnReturnToMenu_Click" CssClass="btn btn-primary w-100 text-white fw-bold">
                            <i class="bi bi-house"></i> Main Menu
                        </asp:LinkButton>

                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
