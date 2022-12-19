<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="SabaSoftwareLock.Web.Lock.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel ID="Panel1" runat="server" BorderColor="Gray" BorderStyle="Solid" style="margin-top: 5px;padding: 5px;">
        <asp:Label ID="Label1" runat="server" Text="نام نرم افزار :‌ " style="margin-right: 5px"></asp:Label>
        <asp:DropDownList ID="ddlSoftName" runat="server" AutoPostBack="false" >
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="جستجو بر اساس :‌ " style="margin-right: 5px"></asp:Label>
        <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="false" >
            <asp:ListItem Selected="True" Value="PackageSerial">سریال روی بسته</asp:ListItem>
            <asp:ListItem Value="HardwareSerial">سریال سخت افزار</asp:ListItem>
            <asp:ListItem Value="LastEnablingState">وضعیت فعلی</asp:ListItem>
            <asp:ListItem Value="UsedCount">دفعات استفاده</asp:ListItem>
            <asp:ListItem Value="TrackingCode">کد رهگیری</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label3" runat="server" Text="کلید جستجو :‌ " style="margin-right: 5px"></asp:Label>
        <asp:TextBox ID="txtKey" runat="server"></asp:TextBox>

        <asp:Button ID="Button1" runat="server" Text="جستجو" onclick="Button1_Click" />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <telerik:RadListView ID="RadListView1" runat="server" 
    AllowPaging="True" AllowNaturalSort="True">
            <ItemTemplate>
            <asp:Panel runat="server" BorderColor="Gray" BorderStyle="Solid" style="float: right; margin:5px; padding:5px;" >
                <label>سریال روی بسته: <h3><%# Eval("PackageSerial.Serial") %></h3></label>
                <label>وضعیت فعلی: <h3><%# Eval("UserSerialState.LastEnablingState") %></h3></label>
                <label>حداکثر دفعات استفاده: <h3><%# Eval("SerialTrackingCode.SerialUsingCount")%></h3></label>
                <label>نام نرم افزار: <h3><%# Eval("SerialTrackingCode.SoftwareName")%></h3></label>
            </asp:Panel>
            </ItemTemplate>
        </telerik:RadListView>
    </asp:Panel>
</asp:Content>
