<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/backend.master" AutoEventWireup="true" CodeFile="mail-send.aspx.cs" Inherits="webapp_page_backend_Mail_Sended" Title="FASTAUTOMATICMAIL" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content">
        <div class="page-full-width cf">
            <asp:Panel Visible="false" ID="pnError" runat="server">
                <div class="error-box round">
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </div>
            </asp:Panel>
            <asp:Panel Visible="false" ID="pnSuccess" runat="server">
                <div class="confirmation-box round">
                    <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
                </div>
            </asp:Panel>
            <div class="side-menu fl">
                <h3>Báo cáo</h3>
                <ul>
                    <li><a href="reportsend.aspx">Thống kê</a></li>
                    <li><a href="Mail-Send.aspx">Thư đã gửi</a></li>
                    <li><a href="Mail-Error.aspx">Thư gửi lỗi</a></li>
                </ul>
            </div>
            <!-- end side-menu -->
            <div class="side-content fr">
                <div class="content-module">
                    <div class="content-module-heading cf">
                        <h3 class="fl">Danh sách đã gửi</h3>
                        <span class="fr expand-collapse-text">Thu vào</span>
                        <span class="fr expand-collapse-text initial-expand">Mở ra</span>
                    </div>
                    <!-- end content-module-heading -->


                    <div class="content-module-main">


                        <!-- start update panel-->
                        <div>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <table>
                                    <asp:DataList ID="dlReport" runat="server">
                                        <HeaderTemplate>

                                            <tbody>
                                                <tr>
                                                    <th>Email
                                                    </th>

                                                    <th>Thời gian bắt đầu</th>
                                                    <th>Thời gian kết thúc
                                                    </th>
                                                    <th>Trạng thái
                                                    </th>

                                                </tr>
                                            </tbody>

                                        </HeaderTemplate>
                                        <ItemTemplate>

                                            <tbody>
                                                <tr>

                                                    <td>
                                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("StartDate") %>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("EndDate") %>'></asp:Label></td>
                                                    <td>
                                                        <asp:ImageButton ID="ibtStatus" runat="server"
                                                            ImageUrl="~/webapp/resource/images/ok.png" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:DataList>
                                    <cc1:CollectionPager ID="dlPager" runat="server"
                                        ControlCssClass="hung" BackNextDisplay="HyperLinks" BackText="« Trước"
                                        LabelText="Trang:" NextText="Sau »"
                                        ResultsFormat="Hiện thị kết quả {0}-{1} ({2})" ResultsLocation="None">
                                    </cc1:CollectionPager>
                                </table>


                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <!-- end update panel-->

                    </div>
                    <!-- end content-module-main -->
                </div>
            </div>
        </div>
    </div>

</asp:Content>

