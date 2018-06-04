<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="WebApplication1.Contacts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.9.1.js"></script>
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnNew" runat="server" Text="Create Contact" OnClick="btnNew_Click"/>
        <asp:Button ID="btnDelete" runat="server" Text="Delete Contact" OnClick="btnDelete_Click"/>
        <br />
        <br />
    <div>
        <asp:GridView ID="grdContacts" runat="server" AutoGenerateColumns="false"  DataKeyNames="id" OnRowCommand="grdContacts_OnRowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="S.No." Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("id") %>'>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="First Name">
                    <ItemTemplate>
                        <asp:LinkButton ID="lblfirstName" runat="server" CommandArgument='<%#Eval("id")%>' CommandName="Edit" Text='<%# Bind("firstName") %>'>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name">
                    <ItemTemplate>
                        <asp:Label ID="lbllastName" runat="server" Text='<%# Bind("lastName") %>'>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label ID="lblemail" runat="server" Text='<%# Bind("email") %>'>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone Number">
                    <ItemTemplate>
                        <asp:Label ID="lblphoneNumber" runat="server" Text='<%# Bind("phoneNumber") %>'>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("Status") %>'>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
