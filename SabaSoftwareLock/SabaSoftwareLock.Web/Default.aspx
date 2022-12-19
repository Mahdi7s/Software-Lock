<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SabaSoftwareLock.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style1 {
            width: 95%;
            margin-right: 10px;
            text-align: center;
        }

        #divPage {
            position: absolute;
            text-align: center;
            background-color: #b0b0b0;
            display: none;
        }

        #divInfo {
            padding: 5px;
            width: 48.2%;
            float: right;            
            overflow: auto;
        }

        /*#divInfo:hover {
                background-color: #b0a9a9;
            }*/

        #divLoginReg {
            padding-top: 20px;
            text-align: center;
            /*padding: 5px;*/
            width: 49%;
            float: right;
            border-left: 3px solid black;
            overflow: auto;
        }

        /*#divLoginReg:hover {
            background-color: #b0a9a9;
        }*/

        #divLogin {
            /*height: 400px;*/
        }

        #divRegister {
        }

        #divButtons {
            display: block;
            width: 50%;
            text-align: center;
            padding-top: 20px;
            padding-right: 26%;
        }

        .buttonSegment {
            margin-top: 10px;
            display: inline;
            width: 50%;
        }

        #divLoginButtons {
            float: right;
        }

        #divRegisterButtons {
            float: left;
        }

        #divErrors {
            position: absolute;
            top: 35%;
            text-align: right;
            z-index: 100;
        }
    </style>
    <script type="text/javascript">
        var showingLogin = true;

        $(window).on("load", pageLoaded);

        function pageLoaded() {
            var redirect = $("#<%= ckRedirect.ClientID %>").val() === "on";
            if (redirect) {
                setInterval(function () {
                    window.location.replace("/Default.aspx");
                }, 6000);
            }

            // ---------------------------- styling ------------------------------------

            var winSize = { height: $(window).height(), width: $(window).width() },
                centralDivSize = { height: winSize.height / 2 + 20, width: winSize.width / 2 };

            $("#divPage").height(centralDivSize.height).width(centralDivSize.width)
                .offset({ top: (winSize.height - centralDivSize.height) / 2, left: (winSize.width - centralDivSize.width) / 2 });
            var margin = 20;
            $("#divInfo").height(centralDivSize.height - margin+10);
            $("#divLoginReg").height(centralDivSize.height - margin);

            $("#divPage").delay(500).fadeIn();

            // ------------------------------------------------------------------------------

            $("#<%= btnRegister.ClientID %>").click(function (evt) {
                $("#divLogin").hide("slow");
                $("#divRegister").show("slow");

                if (showingLogin) {
                    showingLogin = false;                    
                    return false;
                }
            });

            $("#<%= btnLogin.ClientID %>").click(function (evt) {
                $("#divRegister").hide("slow");
                $("#divLogin").show("slow");

                if (!showingLogin) {
                    showingLogin = true;                    
                    return false;
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" />
    <div id="divPage">        
        <div id="divLoginReg">
            <div id="divLogin">
                <asp:Panel ID="Panel2" runat="server" DefaultButton="btnLogin">
                <table class="style1">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="نام کاربری : "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLUserName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtLUserName" ID="RequiredFieldValidator1" runat="server" CssClass="lVal" ValidationGroup="logVal"
                                ErrorMessage="لطفا فیلد نام کاربری را پرکنید." Text="*" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="رمز عبور : "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLPasssword" TextMode="Password" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtLPasssword" ID="RequiredFieldValidator2" runat="server" CssClass="lVal" ValidationGroup="logVal"
                                ErrorMessage="لطفا فیلد رمز عبور را پرکنید." Text="*" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="cbRememberMe" runat="server" Text="به خاطر سپردن" Checked="true" ValidationGroup="logVal"/>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                    </asp:Panel>
            </div>
            <div id="divRegister" style="display: none">
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnRegister">
                            <table class="style1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="نام : "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="*" CssClass="rVal" ValidationGroup="regVal"
                                            ErrorMessage="فیلد نام را پرکنید." Font-Bold="True" ForeColor="Red" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="نام خانوادگی : "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLastName" runat="server" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtLastName" ID="RequiredFieldValidator4" CssClass="rVal" ValidationGroup="regVal"
                                            runat="server" Text="*" Font-Bold="True" ForeColor="Red" ErrorMessage="فیلد نام خانوادگی را پرکنید."></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="نام شرکت : "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCoName" runat="server" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtCoName" ID="RequiredFieldValidator5" CssClass="rVal" ValidationGroup="regVal"
                                            runat="server" Text="*" Font-Bold="True" ForeColor="Red" ErrorMessage="فیلد نام شرکت را پرکنید."></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="نام کاربری : "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUserName" runat="server" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtUserName" ID="RequiredFieldValidator6" CssClass="rVal" ValidationGroup="regVal"
                                            runat="server" Text="*" Font-Bold="True" ForeColor="Red" ErrorMessage="فیلد نام کاربری را پرکنید"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="رمز عبور : "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtPassword" ID="RequiredFieldValidator7" CssClass="rVal"  ValidationGroup="regVal"
                                            runat="server" Text="*" Font-Bold="True" ForeColor="Red" ErrorMessage="فیلد رمز عبور را پرکنید."></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="تکرار رمز عبور : "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"  ></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtPasswordConfirm" ID="RequiredFieldValidator8" CssClass="rVal" ValidationGroup="regVal"
                                            runat="server" Text="*" Font-Bold="True" ForeColor="Red" ErrorMessage="فیلد تکرار رمز عبور را پرکنید."></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm" CssClass="rVal" ValidationGroup="regVal"
                                            runat="server" ErrorMessage="فیلد تکرار رمز عبور با رمز عبور همخوانی ندارد" Text="*" ForeColor="Red" Style="margin-left: -10px"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                            <asp:CheckBox runat="server" ID="ckRedirect" Visible="false" Checked="false" />
                        </asp:Panel>
                        <asp:Panel ID="pnlError" runat="server">
                        </asp:Panel>
            </div>
            <div id="divButtons">
                <div id="divLoginButtons" class="buttonSegment">
                    <telerik:RadButton ID="btnLogin" runat="server" Text="ورود" OnClick="btnLogin_Click" ValidationGroup="logVal">
                        <Icon PrimaryIconLeft="8px" PrimaryIconUrl="~/Resources/Images/sign-in.png" />
                    </telerik:RadButton><br />
                </div>
                <div id="divRegisterButtons" class="buttonSegment">
                    <telerik:RadButton ID="btnRegister" runat="server" Text="ثبت نام" 
                        OnClick="btnRegister_Click" ValidationGroup="regVal" >
                        <Icon PrimaryIconUrl="~/Resources/Images/register.png" PrimaryIconLeft="8px" />
                    </telerik:RadButton>
                </div>
            </div>
            <br />
        </div>
        <div id="divInfo">
            <pre>! Welcome To My Life !</pre>
            <h4>asfdsgfhjklkjhgfddfghgmhgfdsfghjhgfdghj</h4>
            <h4>asfdsgfhjklkjhgfddfghgmhgfdsfghjhgfdghj</h4>
            <h4>asfdsgfhjklkjhgfddfghgmhgfdsfghjhgfdghj</h4>
            <h4>asfdsgfhjklkjhgfddfghgmhgfdsfghjhgfdghj</h4>
            <h4>asfdsgfhjklkjhgfddfghgmhgfdsfghjhgfdghj</h4>
        </div>
    </div>
    <div id="divErrors">
        <asp:CustomValidator ID="regCustomValidator" ForeColor="#ff0000" Font-Size="Medium" runat="server" Font-Bold="true" Display="None" ValidationGroup="regVal"></asp:CustomValidator>
        <asp:CustomValidator ID="logCustomValidator" ForeColor="#ff0000" Font-Size="Medium" runat="server" Font-Bold="true" Display="None" ValidationGroup="logVal"></asp:CustomValidator>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Size="Medium" ForeColor="#ff0000" Font-Bold="true" EnableViewState="false" ValidationGroup="regVal"/>
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" Font-Size="Medium" ForeColor="#ff0000" Font-Bold="true" EnableViewState="false" ValidationGroup="logVal"/>
    </div>
</asp:Content>
