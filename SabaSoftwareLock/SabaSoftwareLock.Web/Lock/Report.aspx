<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="SabaSoftwareLock.Web.Lock.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script runat="server">
        private string GetState(object state)
        {
            var sState = (string)state;
            switch (sState)
            {
                case "IsValid":
                    return "معتبر";
                case "IsUsedMoreThan":
                    return "تلاش برای استفاده بیشتر";
                case "PackageSerialIsNotInDb":
                    return "موجود نبودن سریال";
                case "HardwareSerialNotMatches":
                    return "مشخصات سخت افزاری نادرست";
                case "SoftwareNameNotMatchesPackageSerial":
                    return "متناسب نبودن نام نرم افزار و سریال بسته";
                default:
                    return "استفاده نشده";
            }
        }
    </script>

    <script type="text/javascript">
        function onCurrentPageClick() {
            var divCurrPage = $("#divCurrPage");
            var divNextPage = $("#divGoTo");

            divCurrPage.hide("slow");
            divNextPage.show("fast");
        }

        function onCategorySelectedIndexChanged(sender, evt) {
            initializingCategory(sender, evt);
        }

        function onCategoryLoad(sender, evt) {
            initializingCategory(sender, evt);
        }

        function initializingCategory(sender, evt) {
            var selItem = sender.get_selectedItem(), selVal = selItem.get_value();

            if (selVal) {
                switch (selVal) {
                    case "LastEnablingState":
                        $("#<%= txtKey.ClientID %>").hide("slow");
                        $("#divCurrentState").show("slow", function () {
                            $find("<%= cmbCurrentState.ClientID %>").showDropDown();
                        });
                        break;
                    default:
                        $("#<%= txtKey.ClientID %>").show("slow");
                        $("#divCurrentState").hide("slow");
                        break;
                }
            }
        }

        function onAjaxRequestStart(sender, evt) {
            if (evt.get_eventTarget() === $("#<%= btnExportToExcel.ClientID %>").attr("name")) {
                evt.set_enableAjax(false);// this is postback !
            }
        }
    </script>

    <style type="text/css">
        .auto-style1 {
            width: 16%;
            margin-right: 42%;
        }

        .pager {
            padding-top: 30px;
            padding-bottom: 30px;
            opacity: 1;
            padding: 5px;
            border-top-style: solid;
            border-top-color: black;
            border-top-width: 2px;
            text-align: center;
            bottom: 0px;
            left: 0px;
            background-color: #808080;
            margin-left: 0;
            position: fixed;
            width: 100%;
        }

        .reportItemStyle {
            float: right;
            margin-right: 2px;
            margin-top: 2px;
            padding: 5px;
            width: 30%;
        }

            .reportItemStyle:hover {
                background-color: #808080;
            }

        .inlineElem {
            display: inline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel3" runat="server">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1" ClientEvents-OnRequestStart="onAjaxRequestStart">
            <asp:Panel ID="Panel1" runat="server" BorderColor="Gray" BorderStyle="Solid" Style="margin-top: 5px; padding: 5px; padding-top: 30px;">
                <asp:Label ID="Label1" runat="server" Text="نام نرم افزار :‌ " Style="margin-right: 10px"></asp:Label>
                <telerik:RadComboBox ID="ddlSoftName" runat="server" Style="direction: rtl" />
                <asp:Label ID="Label2" runat="server" Text="جستجو بر اساس :‌ " Style="margin-right: 10px"></asp:Label>
                <telerik:RadComboBox ID="ddlCategory" runat="server" AutoPostBack="false" Style="direction: rtl" OnClientSelectedIndexChanged="onCategorySelectedIndexChanged" OnClientLoad="onCategoryLoad">
                    <Items>
                        <telerik:RadComboBoxItem Selected="True" Value="PackageSerial" Text="سریال روی بسته"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="HardwareSerial" Text="سریال سخت افزار"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="LastEnablingState" Text="وضعیت فعلی"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="UsedCount" Text="دفعات استفاده"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="TrackingCode" Text="کد رهگیری"></telerik:RadComboBoxItem>
                    </Items>
                </telerik:RadComboBox>
                <asp:Label ID="Label3" runat="server" Text="کلید جستجو :‌ " Style="margin-right: 10px"></asp:Label>
                <asp:TextBox ID="txtKey" Style="margin-left: 10px" runat="server"></asp:TextBox>
                <div id="divCurrentState" class="inlineElem" style="display: none">
                <telerik:RadComboBox ID="cmbCurrentState" runat="server" Width="200px" >
                    <Items>
                        <telerik:RadComboBoxItem Value="NotUsed"  Text="استفاده نشده"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="IsValid"  Text="معتبر"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="IsUsedMoreThan"  Text="تلاش برای استفاده بیشتر"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="HardwareSerialNotMatches"  Text="مشخصات سخت افزاری نادرست"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Value="SoftwareNameNotMatchesPackageSerial"  Text="متناسب نبودن نام نرم افزار و سریال بسته"></telerik:RadComboBoxItem>
                    </Items>
                </telerik:RadComboBox>
                    </div>
                <asp:Button ID="Button1" runat="server" Text="جستجو" OnClick="Button1_Click" />

                <%--<asp:ImageButton ID="btnExportToExcel" runat="server" ImageUrl="~/Resources/Images/excelExp.png" OnClick="btnExportToExcel_Click" style="float: left;" />--%>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <asp:Panel ID="Panel4" runat="server" Style="overflow: auto; height: 95%; margin-bottom: 50px;">
                    <telerik:RadListView ID="RadListView1" runat="server"
                        AllowPaging="True" AllowNaturalSort="True" PageSize="20" OnNeedDataSource="RadListView1_NeedDataSource">                        
                        <ItemTemplate>
                            <asp:Panel runat="server" BorderColor="Gray" BorderStyle="Solid" CssClass="reportItemStyle">
                                <label>
                                    سریال روی بسته:
                                <h3 class="inlineElem"><%# Eval("PackageSerial.Serial") %></h3>
                                </label>
                                <br />
                                <label>
                                    وضعیت فعلی:
                                <h3 class="inlineElem"><%# GetState(Eval("UserSerialState.LastEnablingState"))  %></h3>
                                </label>
                                <br />
                                <label>
                                    دفعات استفاده:
                                <h3 class="inlineElem"><%# Eval("UsedCount") %></h3>
                                </label>
                                <br />
                                <label>
                                    حداکثر دفعات استفاده:
                                <h3 class="inlineElem"><%# Eval("SerialTrackingCode.SerialUsingCount")%></h3>
                                </label>
                                <br />
                                <label>
                                    نام نرم افزار:
                                <h3 class="inlineElem"><%# Eval("SerialTrackingCode.SoftwareInfo.SoftwareName")%></h3>
                                </label>
                            </asp:Panel>
                        </ItemTemplate>
                    </telerik:RadListView>
                </asp:Panel>

                <div id="pagerWrapper">
                    <asp:Panel ID="pnlPager" runat="server" CssClass="pager">
                        <table class="auto-style1">
                            <tr>
                                <td>
                                    <telerik:RadButton ID="btnFirstPage" runat="server" Text="" OnClick="btnFirstPage_Click"></telerik:RadButton>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnPrev" runat="server" ImageUrl="~/Resources/Images/prev.png" OnClick="btnPrev_Click" />
                                </td>
                                <td>
                                    <asp:Panel ID="pnlCurrentPage" runat="server" CssClass="inlineElem">
                                        <div id="divCurrPage" class="inlineElem">
                                            <asp:Button ID="lblCurrPage" runat="server" Text="1" OnClientClick="onCurrentPageClick(); return false;" />
                                        </div>
                                        <div id="divGoTo" class="inlineElem" style="display: none">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <telerik:RadNumericTextBox ID="txtGoToPage" Width="50px" runat="server" >
                                                            <NumberFormat DecimalDigits="0" GroupSeparator="" NegativePattern=""
                                                                ZeroPattern="n" />
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="btnGoTo" runat="server" ImageUrl="~/Resources/Images/goto.png" OnClick="btnGoTo_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnNext" runat="server" ImageUrl="~/Resources/Images/next.png" OnClick="btnNext_Click" />
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnLastPage" runat="server" Text="" OnClick="btnLastPage_Click"></telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                        <asp:ImageButton ID="btnExportToExcel" ToolTip="خروجی اکسل" runat="server" ImageUrl="~/Resources/Images/excelExp.png" OnClick="btnExportToExcel_Click" style="float: left;text-align:center;margin-top:-35px;" />
                    </asp:Panel>
                </div>
            </asp:Panel>
        </telerik:RadAjaxPanel>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>        
    </asp:Panel>
</asp:Content>
