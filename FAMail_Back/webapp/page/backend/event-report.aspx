<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/event.master" AutoEventWireup="true"
    CodeFile="event-report.aspx.cs" Inherits="webapp_page_backend_Mail_Sended" Title="FASTAUTOMATICMAIL " ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <div class="side-content fr">
        <asp:Panel ID="pnSearch" runat="server">
            <table id="FilterTable">
                <tr>
                    <td align="right">Sự kiện:
                                        <asp:DropDownList ID="drlNhomMail" runat="server" Height="30px" Width="200px">
                                            <asp:ListItem Value="0">Tất cả</asp:ListItem>
                                        </asp:DropDownList>
                        <asp:Button ID="btnFilter" runat="server" CssClass="button round blue image-right ic-search text-upper" OnClick="btnFilter_Click" Text="Lọc dữ liệu" />
                    </td>

                </tr>

            </table>
        </asp:Panel>
    </div>
    <asp:Repeater ID="rptGroup" runat="server">
        <ItemTemplate>

            <div class="side-content fr">

                <div class="content-module">
                    <div class="content-module-heading cf">
                        <h3 class="fl">
                            <asp:Label ID="lblGroupName" runat="server" Text="" Font-Size="11"></asp:Label></h3>
                        <span class="fr expand-collapse-text">Thu vào</span>
                        <span class="fr expand-collapse-text initial-expand">Mở ra</span>
                    </div>
                    <!-- end content-module-heading -->


                    <div class="content-module-main">

                        <table>
                            <asp:DataList ID="dlEventRegister" runat="server">
                                <HeaderTemplate>

                                    <tbody>
                                        <tr>
                                            <th style="width: 50px;">
                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="false" />
                                            </th>
                                            <th>Email
                                            </th>

                                            <th>Họ tên</th>
                                            <th>Địa chỉ
                                            </th>
                                            <th>Ngày đăng ký
                                            </th>
                                            <th>Nhóm
                                            </th>
                                            <th>Sự kiện
                                            </th>
                                        </tr>
                                    </tbody>

                                </HeaderTemplate>
                                <ItemTemplate>

                                    <tbody>
                                        <tr>
                                            <td style="width: 50px;">
                                                <asp:CheckBox ID="chkXoa" runat="server" />
                                                <asp:HiddenField ID="hdfId" Value="" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCreateDate" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGroupName" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEvent" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tfoot>
                                        <tr>
                                            <td colspan="5" class="table-footer"></td>
                                        </tr>
                                    </tfoot>

                                </FooterTemplate>
                            </asp:DataList>
                        </table>

                    </div>
                    <!-- end content-module-main -->
                </div>
            </div>

        </ItemTemplate>
    </asp:Repeater>
    <asp:DataList ID="dlContentSendEvent" runat="server"
        RepeatColumns="1">
        <ItemTemplate>
            <div class="side-content fr">

                <div class="content-module">
                    <div class="content-module-heading cf">
                        <h3 class="fl">
                            <asp:Label ID="lblGroupName" runat="server" Text="" Font-Size="11"> <%#Eval("subject") %></asp:Label></h3>
                        <%--<asp:HiddenField ID="hdfId" runat="server" Value='<%#Eval("id") %>'></asp:HiddenField>--%>
                        <span class="fr expand-collapse-text">Thu vào</span>
                        <span class="fr expand-collapse-text initial-expand">Mở ra</span>
                    </div>
                    <!-- end content-module-heading -->
                    <%--<label> <%#LoadChart(Eval("id")) %></label>--%>
                    <div class="content-module-main cf">
                        <asp:Panel ID="pnReport" runat="server">
                            <div class="half-size-column fl">
                                <fieldset>
                                    <table>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Tên chiến dịch : </b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblCampianName" runat="server" Text='<%#Eval("Subject") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Email gửi :</b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblEmailSend" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Nhóm email nhận : </b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblGroupEmailTo" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Thời gian bắt đầu gửi :</b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblDateStart" runat="server" Text='<%#Eval("StartSend") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Thời gian kết thúc gửi :</b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblDateEnd" runat="server" Text='<%#Eval("EndSend") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Số mail gửi :</b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTotalMailSend" runat="server" Text='<%#Eval("TotalSend") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Số email đã mở :</b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblOpened" runat="server" Text='<%#Eval("TotalOpen") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Số mail chưa mở :</b>
                                            </td>
                                            <td style="text-align: left; border-bottom: none;">
                                                <asp:Label ID="lblNotOpen2" runat="server" Text='<%#Eval("TotalNotOpen") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>

                            <!-- end half-size-column -->
                            <div class="half-size-column fr">
                                <!--
				        	Thêm vào đây
				        	-->
                                <asp:Label ID="lblChart" runat="server" Text="Không có dữ liệu"></asp:Label>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>


        </ItemTemplate>
    </asp:DataList>

</asp:Content>

