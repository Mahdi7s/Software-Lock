<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CreatePackageSerial.aspx.cs" Inherits="SabaSoftwareLock.Web.Lock.CreatePackageSerial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" BorderColor="Gray" BorderStyle="Solid" style="padding: 5px;margin-top: 10px;">
        <asp:Label ID="Label1" runat="server" Text="شارژ شما :‌ "></asp:Label>
        <asp:Label ID="lblCharge" runat="server" style="margin-right: 5px;"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="تعداد سریال : " style="margin-right: 10px;"></asp:Label>
        <telerik:RadNumericTextBox runat="server" ID="txtCount" Value="10"  >
            <NumberFormat DecimalDigits="0" GroupSeparator="" NegativePattern=""
                ZeroPattern="n" />
        </telerik:RadNumericTextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtCount"
            runat="server" ForeColor="Red" Font-Bold="true" Text="*"></asp:RequiredFieldValidator>
        <%--<asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtCount" runat="server" MinimumValue="1" Text="*" ForeColor="Red"></asp:RangeValidator>--%>
        <asp:Label ID="Label2" runat="server" Text="دفعات استفاده : " style="margin-right: 5px;"></asp:Label>
        <telerik:RadNumericTextBox ID="txtUsingCount" runat="server" Value="2">
            <NumberFormat DecimalDigits="0" GroupSeparator="" NegativePattern="" 
                ZeroPattern="n" />
        </telerik:RadNumericTextBox>
        <%--<asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtUsingCount" runat="server" MinimumValue="1" Text="*" ForeColor="Red"></asp:RangeValidator>--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtUsingCount"
            runat="server" ForeColor="Red" Font-Bold="true" Text="*"></asp:RequiredFieldValidator>
        <asp:Label ID="Label6" runat="server" Text="طول سریال : " style="margin-right: 5px;"></asp:Label>
        <telerik:RadNumericTextBox ID="txtSerialLen" runat="server" MinValue="4" EmptyMessage="حداقل: 4 - حداکثر: 24" MaxValue="24">
            <NumberFormat DecimalDigits="0" GroupSeparator="" NegativePattern=""  ZeroPattern="n" />
        </telerik:RadNumericTextBox>
        <%--<asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtSerialLen" MinimumValue="4" Text="*" ForeColor="Red"></asp:RangeValidator>--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtSerialLen"
            runat="server" ForeColor="Red" Font-Bold="true" Text="*"></asp:RequiredFieldValidator>
        <asp:Label ID="Label4" runat="server" Text="نام نرم افزار : " style="margin-right: 5px;"></asp:Label>
        <telerik:RadComboBox ID="cmbSoftName" runat="server" AutoPostBack="False" DataTextField="SoftwareName" DataValueField="SoftwareInfoId"></telerik:RadComboBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="cmbSoftName"
            runat="server" ForeColor="Red" Font-Bold="true" Text="*"></asp:RequiredFieldValidator>
        <asp:Button ID="Button1" runat="server" Text="تولید" OnClick="Button1_Click" />        
        <asp:Label ID="Label7" runat="server" style="margin-right: 5px;" Text="کد رهگیری :‌ " Visible="false"></asp:Label>
        <asp:Label ID="lblTrackingCode" runat="server" style="margin-right: 5px;"></asp:Label>
        <asp:CustomValidator ID="CustomValidator1" runat="server" Display="None"></asp:CustomValidator>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" Font-Bold="true" />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" style="margin-top: 10px">
        <telerik:RadListView ID="RadListView1" runat="server">
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" BorderColor="Black" BorderStyle="Solid" Style="padding: 5px 10px;"
                    Text='<%# Container.DataItem %>'></asp:Label>
            </ItemTemplate>
        </telerik:RadListView>
    </asp:Panel>
</asp:Content>
