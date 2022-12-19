<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Softwares.aspx.cs" Inherits="SabaSoftwareLock.Web.Lock.Softwares" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .disabledButton {
            background-color: #808080;
        }

        .editPanelStyle {
            margin-top: 20px;
            border: 2px solid grey;
            background-color: #e8e6e6;
            padding: 5px;
        }

        .validName {
            background-color: #7AFF85;
        }

        .invalidName {
            background-color: #FF7D7D;
        }
    </style>
    <script type="text/javascript">
        var txtSoftName, txtSoftUniqueName, softNameVal, softUniqVal,
            notification, grid,
            btnNew, btnAdd, btnDelete, btnSave;

        var onPageLoaded = function () {
            txtSoftName = $("#<%= txtSoftName.ClientID %>"),
                txtSoftUniqueName = $("#<%= txtSoftUniqueName.ClientID %>");
            softNameVal = $(txtSoftName).val();
            softUniqVal = $(txtSoftUniqueName).val();

            notification = $find("<%= RadNotification1.ClientID %>");
            grid = $find("<%= RadGrid1.ClientID %>");

            btnNew = $("#<%= btnNew.ClientID %>"),
                btnAdd = $("#<%= btnAdd.ClientID %>"),
                btnSave = $("#<%= btnApply.ClientID %>"),
                btnDelete = $("#<%= btnDel.ClientID %>");

            $("#<%= btnNo.ClientID %>").click(function () {
                var noty = $find("<%= delNotification.ClientID %>");
                noty._hide();
            });

            var initForm = function () {
                if ($(txtSoftName).val() !== "") {
                    enableButton(btnAdd, btnSave);
                } else {
                    disableButton(btnAdd, btnSave);
                }
                if (grid.get_selectedItems().length) {
                    enableButton(btnDelete);
                } else {
                    disableButton(btnDelete);
                }
            }
            initForm();
            $("#<%= txtSoftName.ClientID %>").keyup(function (evt) {
                initForm();
            });

            var validateForm = function (evt) {
                if (txtSoftName.val() === '') {
                    showNotification("تکمیل فرم", "نام کامل برنامه را وارد نمایید.");
                    txtSoftName.focus();

                    return false;
                }
            };

            btnAdd.click(validateForm);
            btnSave.click(validateForm);
        };

        $(window).on("load", onPageLoaded);

        function onAjaxResponseEnd() {
            onPageLoaded();
        }

        function onNew() {
            $(txtSoftName).val('').focus();
            $(txtSoftUniqueName).val('');

            disableButton(btnAdd, btnSave);
        }

        function onRowDeselected() {
            disableButton(btnDelete);
        }

        function onEditingColumn(evt) {
            var softName, softUniqueName;
        }

        function onRowSelected(sender, evt) {
            $(txtSoftName).val(evt.getDataKeyValue("SoftwareName"));
            $(txtSoftUniqueName).val(evt.getDataKeyValue("SoftwareUniqueName"));

            enableButton(btnAdd, btnNew, btnSave, btnDelete);
        }

        function disableButton() {
            $.each(arguments, function (idx, elem) {
                $(elem).addClass('disabledButton')/*.attr('disabled', 'disabled')*/;
            });
        }

        function enableButton() {
            $.each(arguments, function (idx, elem) {
                $(elem).removeAttr('disabled').removeClass('disabledButton');
            });
        }

        function showNotification(title, text) {
            notification.set_title(title);
            notification.set_text(text);
            notification.show();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1" ClientEvents-OnResponseEnd="onAjaxResponseEnd">
        <asp:Panel ID="pnlSoftwareInfoes" runat="server">
            <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" MasterTableView-Dir="RTL" OnNeedDataSource="RadGrid1_NeedDataSource">
                <ClientSettings>
                    <Selecting AllowRowSelect="true" />
                    <ClientEvents OnRowSelected="onRowSelected" OnRowDeselected="onRowDeselected" />
                </ClientSettings>
                <MasterTableView DataKeyNames="SoftwareInfoId" ClientDataKeyNames="SoftwareName, SoftwareUniqueName">
                    <NoRecordsTemplate>
                        <h4 style="text-align: center; margin-top: 10px; margin-bottom: 10px;color: #ff8a8a">برنامه ای برای نمایش وجود ندارد</h4>
                    </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="SoftwareInfoId" DataType="System.Int32" FilterControlAltText="Filter SoftwareInfoId column" HeaderText="کلید جدول" ReadOnly="True" SortExpression="SoftwareInfoId" UniqueName="SoftwareInfoId">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SoftwareName" FilterControlAltText="Filter SoftwareName column" HeaderText="نام کامل برنامه" SortExpression="SoftwareName" UniqueName="SoftwareName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SoftwareUniqueName" FilterControlAltText="Filter SoftwareUniqueName column" HeaderText="نام مختصر برنامه" SortExpression="SoftwareUniqueName" UniqueName="SoftwareUniqueName">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False">
                    <WebServiceSettings>
                        <ODataSettings InitialContainerName="">
                        </ODataSettings>
                    </WebServiceSettings>
                </FilterMenu>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                    <WebServiceSettings>
                        <ODataSettings InitialContainerName="">
                        </ODataSettings>
                    </WebServiceSettings>
                </HeaderContextMenu>
            </telerik:RadGrid>
        </asp:Panel>
        <asp:Panel ID="pnlEdit" runat="server" Visible="true" CssClass="editPanelStyle">
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="نام کامل برنامه : "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSoftName" runat="server" Width="200px" CssClass="ftinput">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="نام مختصر برنامه : " Visible="true" ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSoftUniqueName" runat="server" Width="200px" CssClass="ftinput" Visible="true" Enabled="false"></asp:TextBox>
                        <asp:ImageButton ID="btnValidateUniqName" runat="server" Visible="false" ImageUrl="~/Resources/Images/validation-22.png" ToolTip="اعتبارسنجی نام مختصر" OnClick="btnValidateUniqName_Click" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnNew" runat="server" ImageUrl="~/Resources/Images/new.png" ToolTip="جدید" ClientIDMode="AutoID" OnClientClick="onNew(); return false;" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Resources/Images/insert.png" ToolTip="اضافه کردن" ClientIDMode="AutoID" CssClass="disabledButton" OnClick="btnAdd_Click" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnApply" runat="server" ImageUrl="~/Resources/Images/apply.png" ToolTip="ویرایش" OnClick="btnApply_Click" CssClass="disabledButton" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnDel" runat="server" ImageUrl="~/Resources/Images/delete.png" ToolTip="حذف" OnClientClick="onDelete();" CssClass="disabledButton" OnClick="btnDel_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <telerik:RadNotification ID="RadNotification1" runat="server" ContentIcon="/Resources/Images/warning-32.png" CloseButtonToolTip="بستن" Title="" Text="" Position="Center">
        </telerik:RadNotification>
        <telerik:RadNotification ID="delNotification" runat="server" ContentIcon="/Resources/Images/warning-32.png" CloseButtonToolTip="بستن" Title="اخطار" Text="" Position="Center" AutoCloseDelay="108000000">
            <ContentTemplate>
                <label>برنامه انتخاب شده برای حذف حاوی سریال های تولید شده می باشد آیا مایل به حذف تمام آنها هستید؟</label><br />
                <div style="text-align: center; margin-top: 10px;">
                    <telerik:RadButton ID="btnYes" runat="server" Text="بله" OnClick="btnYes_Click"></telerik:RadButton>
                    <telerik:RadButton ID="btnNo" runat="server" Text="خیر" OnClick="btnNo_Click" AutoPostBack="false"></telerik:RadButton>
                </div>
            </ContentTemplate>
        </telerik:RadNotification>
    </telerik:RadAjaxPanel>
</asp:Content>
