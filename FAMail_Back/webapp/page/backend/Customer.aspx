<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/management.master"
    AutoEventWireup="true" CodeFile="customer.aspx.cs" Inherits="webapp_page_backend_Customer"
    Title="FASTAUTOMATICMAIL" %>

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
                            Danh sách khách hàng</h3>
                        <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">
                            Mở ra</span>
                    </div>
                    <!-- end content-module-heading -->
                    <div class="content-module-main">
                        <%--<form  runat="server">--%>
                        <asp:Button ID="btnSearch" runat="server" CssClass="button round blue image-right ic-search text-upper"
                            Text="Tìm kiếm khách hàng" OnClick="btnSearch_Click" />
                        <asp:Panel ID="pnSearch" runat="server">
                            <table id="FilterTable">
                                <thead>
                                    <tr>
                                        <th colspan="7" style="height: 27px; padding-left: 10px; text-align: left">
                                            Tìm kiếm khách hàng
                                        </th>
                                    </tr>
                                </thead>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="btnFillter" runat="server" ImageUrl="~/webapp/resource/images/users-mixed-gender-icon.png" />
                                    </td>
                                    <td align="left" style="text-align: left;">
                                        <asp:Label ID="Label1" runat="server" Text="<b>Theo tên :</b>"></asp:Label>
                                        <asp:TextBox ID="txtName" runat="server" Width="60%" CssClass="Hung"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="<b>Nhóm mail :</b>"></asp:Label>
                                        <asp:DropDownList ID="drlNhomMail" runat="server" Height="30px">
                                            <asp:ListItem Value="0">Tất cả</asp:ListItem>
                                        </asp:DropDownList>
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
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/webapp/resource/images/phone-icon.png" />
                                    </td>
                                    <td align="left" style="text-align: left;">
                                        <asp:Label ID="Label2" runat="server" Text="<b>Theo số điện thoại:</b>"></asp:Label>
                                        <asp:TextBox ID="txtPhone" runat="server" Width="60%" CssClass="Hung"></asp:TextBox>
                                    </td>
                                    <td>
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
                                        <asp:Label ID="Label3" runat="server" Text="<b>Theo Email :</b>"></asp:Label>
                                        <asp:TextBox ID="txtEmail" runat="server" Width="60%" CssClass="Hung"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 30px;">
                                        <asp:Button ID="btnFilter" runat="server" CssClass="button round blue image-right ic-search text-upper"
                                            OnClick="btnFilter_Click" Text="Lọc dữ liệu" />
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
                            </table>
                        </asp:Panel>
                        <table>
                            
                            <asp:DataList ID="dtlCustomer" runat="server">
                                <HeaderTemplate>
                                    <thead>
                                        <tr style="font-size: 0.8em;">
                                        
                                            <th style="text-align: left; padding-left: 10px; width:auto;">
                                                Họ và tên
                                            </th>
                                            <th>
                                                Giới tính
                                            </th>
                                            <th>
                                                Email
                                            </th>
                                            <th>
                                                Số điện thoại
                                            </th>
                                            <th>
                                                Địa chỉ
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
                                           
                                            <td style="text-align: left; padding-left: 10px; width:auto;">
                                             <asp:HiddenField ID="hdfId" runat="server" Value='<%# Eval("Id") %>' />
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAddr" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                            </td>
                                            <td style="width: 100px;">
                                                              <asp:ImageButton ID="btnOrder" runat="server" ImageUrl="~/webapp/resource/images/Actions-view-list-details-icon.png"
                                                    PostBackUrl='<%#"~/webapp/page/backend/ListOrder.aspx?CustomerId=" + Eval("Id")%>' />
                                                <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/webapp/resource/images/edit-validated-icon.png"
                                                    PostBackUrl='<%#"~/webapp/page/backend/AddCustomer.aspx?CustomerId=" + Eval("Id")%>' />
                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                                    CommandArgument='<%# Eval("id") %>' OnClick="btnDelete_Click" OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa khách hàng này không ?')" />
                                                    
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
                        <%-- </form>--%>
                    </div>
                    <!-- end content-module-main -->
                </div>
            </div>
</asp:Content>
