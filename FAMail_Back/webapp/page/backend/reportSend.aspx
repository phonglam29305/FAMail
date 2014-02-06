<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/report.master" AutoEventWireup="true"
    CodeFile="reportSend.aspx.cs" Inherits="webapp_page_backend_reportSend" Title="FASTAUTOMATICMAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="side-content fr">
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
        <div class="content-module">
            <div class="content-module-heading cf">
                <h3 class="fl">
                    Thông kê tổng quát</h3>
                <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">
                    Mở ra</span>
            </div>
            <!-- end content-module-heading -->
            <div class="content-module-main cf">
                <div class="half-size-column fl" style="height: auto">
                    <fieldset style="margin-left: 15px;">
                        <p>
                            <label for="full-width-input">
                                Chọn chiến dịch cần xem</label>
                            <asp:DropDownList ID="drlCampaign" CssClass="round default-width-dropdown" runat="server"
                                AutoPostBack="True" OnSelectedIndexChanged="drlCampaign_SelectedIndexChanged">
                            </asp:DropDownList>
                        </p>
                    </fieldset>
                </div>
                <!-- end half-size-column -->
            </div>
            <div class="content-module-main" style="margin-top: -32px;">
                <!-- start update panel-->
                <div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </div>
             
                        <div class="content-module-main cf">
                            <asp:Panel ID="pnReport" runat="server">
                            <div class="half-size-column fl">
                                <fieldset>
                                    <table>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Tên chiến dịch :</b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblCampianName" runat="server" Text="Không hiển thị"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Email gửi :</b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblEmailSend" runat="server" Text="Không hiển thị "></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Nhóm email nhận : </b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblGroupEmailTo" runat="server" Text="Không hiển thị"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Thời gian bắt đầu gửi :</b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblDateStart" runat="server" Text="Không hiển thị "></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Thời gian kết thúc gửi :</b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblDateEnd" runat="server" Text="Không hiển thị "></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Số mail gửi :</b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTotalMailSend" runat="server" Text="Không hiển thị"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Số email đã mở :</b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblOpened" runat="server" Text="Không hiển thị"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Số mail chưa mở :</b>
                                            </td>
                                            <td style="text-align: left; border-bottom: none;">
                                                <asp:Label ID="lblNotOpen2" runat="server" Text="Không hiển thị"></asp:Label>
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
         <div class="content-module">
            <div class="content-module-heading cf">
                <h3 class="fl">
                    Danh sách mail đã đọc</h3>
                <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">
                    Mở ra</span>
            </div>
            <!-- end content-module-heading -->
            <div class="content-module-main" style="margin-top: -32px;">
                <!-- start update panel-->
        
                        <div class="content-module-main cf">
                               
                                <table>
                                    <asp:DataList ID="dlReport" runat="server">
                                        <HeaderTemplate>
                                            <tbody>
                                                <tr>
                                                    <th>
                                                        STT
                                                    </th>
                                                    <th>
                                                        Email
                                                    </th>
                                                    <th>
                                                        Thời gian gửi
                                                    </th>
                                                    <th>
                                                        Thời gian mở Email
                                                    </th>
                                                    <th>
                                                        Đã đọc
                                                    </th>
                                                </tr>
                                            </tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tbody>
                                                <tr>
                                                    <td style="width: 50px;">
                                                        <asp:Label ID="lblNo" runat="server" Text='<%#Eval("STT") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblStartDate" runat="server" Text='<%#Eval("StartDate") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblOpenDate" runat="server" Text='<%#Eval("DateOpen") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="ibtStatus" runat="server" ImageUrl="~/webapp/resource/images/ok.png" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <tfoot>
                                                <tr>
                                                </tr>
                                            </tfoot>
                                        </FooterTemplate>
                                    </asp:DataList>
                                </table>
                           
                        </div>
         
                <!-- end update panel-->
                <%-- </form>--%>
            </div>
            <!-- end content-module-main -->
        </div>
    </div>
</asp:Content>
