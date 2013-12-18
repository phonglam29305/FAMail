<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" CodeFile="PackageChange.aspx.cs" Inherits="webapp_page_backend_PackageChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=ddlLimitPackage.ClientID%>").change(function () {
                var myparam = $("#<%=ddlLimitPackage.ClientID%>").val();
                $.ajax({
                    type: "POST",
                    url: "PackageChange.aspx/CalculateCost",
                    data: '{param:"' + myparam + '"}',
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        alert(data.d)
                    }
                });
            });
        });
    </script>
    <script type="text/javascript">
            $(document).ready(function () {
                alert("ready");
            });
    </script>
    <div class="side-content fr">
                <!--start content 01-->
                <div class="content-module">
                    <div class="content-module-heading cf">
                        <h3 class="fl"><asp:Label ID="lblTitle" runat="server" Font-Size="1em" ForeColor="White"></asp:Label></h3>
                        <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">Mở ra</span>
                    </div>
                    <div class="content-module-main">
                        <div id="extendbox" runat="server" class="full-width-editor" align="center">
                        
                            <table class="full-width-editor">
                                <tr>
                                    <td>Thời gian:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlExtend" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlExtend_SelectedIndexChanged">
                                            <asp:ListItem Value="0">-------------Chọn thời hạn-------------</asp:ListItem>
                                           <%-- <asp:ListItem Value="30">1 tháng</asp:ListItem>
                                            <asp:ListItem Value="90">3 tháng</asp:ListItem>
                                            <asp:ListItem Value="180">6 tháng</asp:ListItem>
                                            <asp:ListItem Value="365">1 năm</asp:ListItem>--%>
                                        </asp:DropDownList>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ngày hết hạn:</td>
                                    <td><asp:Label ID="lblExpireDate" runat="server" Text=""></asp:Label> </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnGiahan" runat="server" Text="Gia hạn dịch vụ" CssClass="button round blue image-right ic-add text-upper" OnClick="btnGiahan_Click"/>
                                    </td>
                                </tr>
                            </table>
                        
                        </div>
                        <div id="upgradeservices" class="full-width-editor" runat="server" visible="false">

                            <table class="full-width-editor">
                                <tr>
                                    <td>Gói dịch vụ hiện tại:</td>
                                    <td style="text-align:left !important;">
                                        <asp:Label ID="lblTenGoi" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Gói dịch vụ có thể nâng cấp:</td>
                                    <td style="text-align:left !important;">
                                        <asp:DropDownList ID="ddlUpgradeServices" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Thời gian:</td>
                                    <td style="text-align:left !important;">
                                        <asp:DropDownList ID="ddlUpgradeTime" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlUpgradeTime_SelectedIndexChanged">
                                            <asp:ListItem Value="0">-------------Chọn thời hạn-------------</asp:ListItem>
                                            <%--<asp:ListItem Value="30">1 tháng</asp:ListItem>
                                            <asp:ListItem Value="90">3 tháng</asp:ListItem>
                                            <asp:ListItem Value="180">6 tháng</asp:ListItem>
                                            <asp:ListItem Value="365">1 năm</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Đơn giá gói:</td>
                                    <td style="text-align:left !important;">
                                        <asp:Label ID="lblFee" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tiền thừa gói cũ(đơn giá gói/ngày sử dụng còn lại):</td>
                                    <td style="text-align:left !important;">
                                        <asp:Label ID="lblFeeRemain" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Thời gian còn lại của gói cũ:</td>
                                    <td style="text-align:left !important;">
                                        <asp:Label ID="lblTimeLeft" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Thời gian hết hạn:</td>
                                    <td style="text-align:left !important;">
                                        <asp:Label ID="lblUpgradeExpireTime" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnUpgrade" runat="server" Text="Nâng cấp dịch vụ" CssClass="button round blue image-right ic-add text-upper" OnClick="btnUpgrade_Click" />
                                    </td>
                                </tr>
                            </table>

                        </div>
                        <div id="changeoptionbox" class="full-width-editor" runat="server" visible="false">

                            <table class="full-width-editor">
                                <tr>
                                    <td>Chức năng:</td>
                                    <td style="max-width:800px;">
                                        <asp:Repeater ID="rptListOptions" runat="server">
                                            <ItemTemplate>
                                                <div class="confirmation-box" style="float:left;border:none !important">
                                                    <asp:CheckBox ID="chkOptions" runat="server"/><%#Eval("functionName") %>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Gói giới hạn</td>
                                    <td style="text-align:left !important;">
                                        <asp:DropDownList ID="ddlLimitPackage" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>

                        </div>
                    </div>
                </div>
    </div>
</asp:Content>

