<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Typetale.aspx.cs" Inherits="TypeTable.Typetale" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management</title>
    <script src="bootstrap.bundle.min.js"></script>
    <link href="bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="card shadow p-4">
                <h2 class="text-center mb-4">Add Employee</h2>

                <div class="row mb-3">
                    <label class="col-sm-3 col-form-label">Employee ID:</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtEmployeeID" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-3 col-form-label">First Name:</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-3 col-form-label">Last Name:</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-3 col-form-label">Email:</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-3 col-form-label">Phone:</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="text-center">
                    <asp:Button ID="btnAddEmployee" Text="Add Employee" CssClass="btn btn-primary" runat="server" OnClick="btnAddEmployee_Click" />
                </div>
            </div>

            <div class="card mt-4 shadow p-4">
                <h2 class="text-center mb-4">Employee List</h2>

                <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" CssClass="table table-bordered table-hover bg-white">
                    <Columns>
                        <asp:TemplateField HeaderText="EmpID">
                            <ItemTemplate>
                                <asp:Label CssClass="text-center d-block" ID="glblID" Text='<%#Eval("EmployeeID") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="First Name">
                            <ItemTemplate>
                                <asp:Label CssClass="text-center d-block" ID="glblFirstName" Text='<%#Eval("FirstName")%>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Last Name">
                            <ItemTemplate>
                                <asp:Label CssClass="text-center d-block" ID="glblLastName" Text='<%#Eval("LastName")%>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Label CssClass="text-center d-block" ID="glblEmail" Text='<%#Eval("Email")%>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Phone Number">
                            <ItemTemplate>
                                <asp:Label CssClass="text-center d-block" ID="glblPhone" Text='<%#Eval("Phone")%>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>



                <div class=" row text-center mt-3">
                    <div class="row-md-4">
                        <asp:Label Text="" ID="ErrorMsg" runat="server" />
                    </div>
                    <div class="row-md-3">
                        <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>


</body>
</html>
