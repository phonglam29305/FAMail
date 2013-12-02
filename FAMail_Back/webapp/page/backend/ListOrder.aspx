<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/OrderManager.master"
    AutoEventWireup="true" CodeFile="ListOrder.aspx.cs" Inherits="webapp_page_backend_ListOrder"
    Title="FASTAUTOMATICMAIL.COM" %>
<%@ Register assembly="CollectionPager" namespace="SiteUtils" tagprefix="cc1" %>
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
                            Danh sách đơn hàng</h3>
                        <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">
                            Mở ra</span>
                    </div>
                    <!-- end content-module-heading -->
                    <div class="content-module-main">
                        <%--<form  runat="server">--%>
                        <asp:Panel ID="pnSearch" runat="server">
                            <table id="FilterTable">
                                <thead>
                                    <tr>
                                        <th colspan="7" style="height: 27px; padding-left: 10px; text-align: left">
                                            Tìm kiếm đơn hàng
                                        </th>
                                    </tr>
                                </thead>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="btnFillter" runat="server" ImageUrl="~/webapp/resource/images/Calendar-icon.png" />
                                    </td>
                                    <td align="left" style="text-align: left;">
                                        <asp:Label ID="Label1" runat="server" Text="<b>Từ ngày :</b>"></asp:Label>
                                        <asp:TextBox ID="txtDateFrom" runat="server" Width="60%" CssClass="Hung"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="<b>Đến ngày :</b>"></asp:Label>
                                        <asp:TextBox ID="txtDateTo" runat="server" Width="60%" CssClass="Hung"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/webapp/resource/images/EMail-icon.png" />
                                    </td>
                                    <td align="left" style="text-align: left;">
                                        <asp:Label ID="Label3" runat="server" Text="<b>Mã đơn hàng:</b>"></asp:Label>
                                        <asp:TextBox ID="txtOrderID" runat="server" Width="60%" CssClass="Hung"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="<b>Trạng thái đơn hàng</b>"></asp:Label>
                                        <asp:DropDownList ID="drlStatus" runat="server" Height="30px" Width="200px" 
                                            AutoPostBack="True" onselectedindexchanged="drlStatus_SelectedIndexChanged">
                                            <asp:ListItem Value="false">Chưa giao hàng</asp:ListItem>
                                            <asp:ListItem Value="True">Đã giao hàng</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="padding-left: 30px;">
                                        <asp:Button ID="btnFilter" runat="server" CssClass="button round blue image-right ic-search text-upper"
                                            Text="Lọc dữ liệu" onclick="btnFilter_Click" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <table>
                            <asp:DataList ID="dtlOrder" runat="server">
                                <HeaderTemplate>
                                    <thead>
                                        <tr style="font-size: 0.8em;">
                                 
                                            <th style="text-align: left; padding-left: 10px;">
                                                Mã đơn hàng
                                            </th>
                                            <th>
                                                Ngày lập
                                            </th>
                                            <th>
                                                Ngày giao hàng
                                            </th>
                                            <th>
                                                Người lập
                                            </th>
                                            <th>
                                                Trạng thái
                                            </th>
                                            <th>
                                                Chức năng
                                            </th>
                                        </tr>
                                    </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tbody>
                                        <tr>
                                        
                                            <td>
                                                <asp:Label ID="lblOrderId" runat="server" Text='<%# Eval("OrderID") %>' />
                                            </td>
                                            <td style="text-align: left; padding-left: 10px;">
                                                <asp:Label ID="lblDateCreate" runat="server" Text='<%# Eval("CreateDate") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDeliveryDate" runat="server" Text='<%# Eval("DeliveryDate") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPersonCreate" runat="server" Text='<%# Eval("PersonCreate") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                            </td>
                                            <td style="width: 150px;">
                                                <asp:ImageButton ID="btnDetail" runat="server" ImageUrl="~/webapp/resource/images/Actions-view-list-details-icon.png"
                                                    PostBackUrl='<%#"~/webapp/page/backend/PrintOrder.aspx?OrderId=" + Eval("OrderId")%>' />
                                                <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/webapp/resource/images/edit-validated-icon.png"
                                                    PostBackUrl='<%#"~/webapp/page/backend/OrderManagement.aspx?OrderId=" + Eval("OrderId")%>' />
                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                                    CommandArgument='<%# Eval("OrderId") %>' 
                                                    OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa khách hàng này không ?')" 
                                                    onclick="btnDelete_Click" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tfoot>
                                        <tr>
                                            <td colspan="7" class="table-footer">
                                            
                                            </td>
                                        </tr>
                                    </tfoot>
                                </FooterTemplate>
                            </asp:DataList>
                                   <cc1:CollectionPager ID="dlPager" runat="server" 
                                                 ControlCssClass="hung" BackNextDisplay="HyperLinks" BackText="« Trước" 
                                    LabelText="Trang:" NextText="Sau »" 
                                    ResultsFormat="Hiện thị kết quả {0}-{1} ({2})" ResultsLocation="None">
                            </cc1:CollectionPager>
                        </table>
                        <%-- </form>--%>
                    </div>
                    <!-- end content-module-main -->
                </div>
            </div>
            

    <!-- ============= datetime picker -->

    <script type="text/javascript">
        $(function() {
            $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtDateFrom').datetimepicker({
	            changeMonth:true, changeYear:true, timeFormat: "", dateFormat: "dd/mm/yy"
            });
        });	
    </script>

    <script type="text/javascript">
        $(function() {
            $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtDateTo').datetimepicker({
	            changeMonth:true, changeYear:true, timeFormat: "", dateFormat: "dd/mm/yy"
            });
        });	
    </script>

</asp:Content>
