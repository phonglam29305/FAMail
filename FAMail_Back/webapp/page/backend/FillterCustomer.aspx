<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" CodeFile="FillterCustomer.aspx.cs"
    Inherits="webapp_page_backend_FillterCustomer" Title="FASTAUTOMATICMAIL" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <script>
            function checkAll() {
                var checked = !$(this).data('checked');
                $('input:checkbox').prop('checked', checked);
                $(this).data('checked', checked);
            }
        </script>

        <script>
            $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_dtlCustomer_ctl00_chkAll:checkbox').change(function () {
                if ($(this).attr("checked")) $('input:checkbox').attr('checked', 'checked');
                else $('input:checkbox').removeAttr('checked');
            });
        </script>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                        <h3 class="fl">Danh sách khách hàng</h3>
                        <span class="fr expand-collapse-text">Thu vào</span>
                        <span class="fr expand-collapse-text initial-expand">Mở ra</span>
                    </div>
                    <!-- end content-module-heading -->


                    <div class="content-module-main">
                        <%--<form  runat="server">--%>
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
                                       <td>Lựa chọn:<asp:DropDownList ID="drlSubGroup" runat="server" AutoPostBack="false" Height="30px" Width="200px">
                                        <asp:ListItem Value="0">All</asp:ListItem>
                                    </asp:DropDownList>
                                        <asp:Button ID="btnSave" runat="server" Text="Thêm vào"
                                            CssClass="round button blue text-upper small-button" OnClick="btnSave_Click" />
                                    </td>
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
                                        <th>
                                            <input type="checkbox" onclick="checkAll()" value="All" /></th>
                                        <th style="width: 200px; text-align: left;">Họ và tên</th>
                                        <th>Giới tính</th>
                                        <th>Ngày sinh</th>
                                        <th>Email</th>
                                        <th>Số điện thoại</th>
                                        <th>Địa chỉ</th>
                                    </thead>
                                    <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>


                                    <tr>
                                        <td style="width: 50px;">
                                            <asp:CheckBox ID="chkCheck" runat="server" />
                                            <asp:HiddenField ID="hdfId" runat="server" Value='<%# Eval("Id") %>' />
                                        </td>
                                        <td style="text-align: left; padding-left: 10px;">
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblBirthDay" runat="server" Text='<%# Eval("Birthday") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblAddr" runat="server" Text='<%# Eval("Address") %>'></asp:Label></td>

                                    </tr>

                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                 <tfoot style="padding: 10px;">
                     <tr style="margin: 5px;">
                         <td colspan="7" class="table-footer"></td>

                     </tr>
                 </tfoot>


                                </FooterTemplate>
                            </asp:DataList>
                            <cc1:CollectionPager ID="dlPager" runat="server"
                                ControlCssClass="hung" BackNextDisplay="HyperLinks" BackText="« Trước"
                                LabelText="Trang:" NextText="Sau »"
                                ResultsFormat="Hiện thị kết quả {0}-{1} ({2})" ResultsLocation="None">
                            </cc1:CollectionPager>
                            <asp:Panel ID="pnSelectGroup" runat="server">
                                <tr>
                                    <td style="width: 50px;" colspan="5">

                                        <asp:DropDownList ID="drlSubGroup123" Visible="false" runat="server" AutoPostBack="false" Height="30px" Width="200px">
                                            <asp:ListItem Value="0">Tất cả</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="btnSave222" Visible="false" runat="server" Text="Thêm vào"
                                            CssClass="round button blue text-upper small-button" OnClick="btnSave_Click" />
                                    </td>

                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="pnBackAddGroup" runat="server">
                                <br />
                                <a href="group-mail.aspx">Tạo nhóm mail mới</a>
                            </asp:Panel>
                        </table>
                        <%-- </form>--%>
                    </div>
                    <!-- end content-module-main -->
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

