<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactDetails.aspx.cs" Inherits="WebApplication1.ContactDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
                    <span>*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="FirstName_RequiredField" runat="server" ErrorMessage="First Name Cannot be Empty" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                    <span>*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="LastName_RequiredField" runat="server" ErrorMessage="Last Name Cannot be Empty" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    <span>*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtEmail_RequiredField" runat="server" ErrorMessage="Email Cannot be Empty" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="Email_REGX" runat="server" ErrorMessage="Invalid Email Format" ControlToValidate="txtEmail" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblphno" runat="server" Text="Phone No."></asp:Label>
                    <span>*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtphno" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtphno_RequiredField" runat="server" ErrorMessage="Phone Number Cannot be Empty" ControlToValidate="txtphno"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="MobileNo_REGX" runat="server" ErrorMessage="Invalid Mobile Number" ValidationExpression="[0-9]{10}" ControlToValidate="txtphno"></asp:RegularExpressionValidator>
                    
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>
                    
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btn_SaveClick"/>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btn_CancelClick"/>
                </td>
            </tr>
        </table>
        

    </div>
    </form>
</body>
</html>
