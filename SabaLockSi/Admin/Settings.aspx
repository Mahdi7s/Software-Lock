<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="SabaSoftwareLock.Web.Admin.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            direction:rtl;
        }
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    <fieldset>
        <legend>
            <asp:RadioButton ID="RadioButton1" runat="server" Text="" Checked="true" 
                GroupName="g" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="true"/></legend>
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="قیمت سریال روی بسته :‌ "></asp:Label>
                <asp:TextBox ID="txtPackageSerialPrice" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                    ErrorMessage="RangeValidator" Font-Bold="True" ForeColor="Red" 
                    MinimumValue="0" ControlToValidate="txtPackageSerialPrice" MaximumValue="5">*</asp:RangeValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
        </fieldset>
        <fieldset>
        <legend>
            <asp:RadioButton ID="RadioButton2" runat="server" Text="بله ای" GroupName="g" 
                AutoPostBack="True" OnCheckedChanged="RadioButton2_CheckedChanged" /></legend>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <telerik:RadListBox ID="RadListBox1" runat="server" AllowDelete="True" 
                            AllowReorder="True">
                        </telerik:RadListBox>
                    </td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="از : "></asp:Label>
                        <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="RequiredFieldValidator" ControlToValidate="txtFrom" ForeColor="Red" Font-Bold="true" Text="*"></asp:RequiredFieldValidator>
                  
                        <asp:Label ID="Label4" runat="server" Text="تا : "></asp:Label>
                        <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Font-Bold="true" Text="*"
                            ErrorMessage="RequiredFieldValidator" ControlToValidate="txtTo"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="قیمت : "></asp:Label>
                        <asp:TextBox ID="txtPrice" runat="server" Width="168px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPrice" ForeColor="Red" Font-Bold="true" Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
   <asp:Button ID="Button2" runat="server" Text="اضافه کردن" OnClick="Button2_Click" />

                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            </asp:Panel>
        </fieldset>
   <asp:Button ID="Button1" runat="server" Text="ثبت" onclick="Button1_Click" />

</asp:Content>
