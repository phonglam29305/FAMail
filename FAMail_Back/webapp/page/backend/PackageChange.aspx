<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" CodeFile="PackageChange.aspx.cs" Inherits="webapp_page_backend_PackageChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                                        <asp:DropDownList ID="ddlExtend" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlExtend_SelectedIndexChanged">
                                            <asp:ListItem>-------------Chọn thời hạn-------------</asp:ListItem>
                                            <asp:ListItem Value="30">1 tháng</asp:ListItem>
                                            <asp:ListItem Value="90">3 tháng</asp:ListItem>
                                            <asp:ListItem Value="180">6 tháng</asp:ListItem>
                                            <asp:ListItem Value="365">1 năm</asp:ListItem>
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
                                    <td>
                                        <asp:Label ID="lblTenGoi" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Gói dịch vụ có thể nâng cấp</td>
                                    <td>
                                        <asp:DropDownList ID="ddlUpgradeServices" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>

                        </div>
                    </div>
                </div>
    </div>
</asp:Content>

