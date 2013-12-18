<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" CodeFile="ClientDetail.aspx.cs" Inherits="webapp_page_backend_CustomerDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="side-content fr">
                <!--start content 01-->
                <div class="content-module">
                    <div class="content-module-heading cf">
                        <h3 class="fl"> Thông tin tài khoản</h3>
                        <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">Mở ra</span>
                    </div>
                    <!-- end content-module-heading -->
                    <div class="content-module-main">
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
                        <div class="content-module-main cf">
                           
                            <div class="full-width-editor">
                                <table>
                                   <tr >
                                      <td style="width:150px;">
                                        Gói sử dụng: 
                                      </td>
                                       <td align="left" style="width:150px;">
                                           <asp:Label ID="lblTenGoi" runat="server" Text=""></asp:Label>
                                       </td>
                                      <td style="width:150px;">
                                        Ngày kích hoạt: 
                                      </td>
                                       <td  align="left" style="width:150px;">
                                           <asp:Label ID="lblNgayKichHoat" runat="server" Text=""></asp:Label>
                                       </td>
                                   </tr>
                                   <tr >
                                      <td style="width:150px;">
                                        Số tài khoản con: 
                                      </td>
                                       <td align="left" style="width:150px;">
                                           <asp:Label ID="lblSoTaiKhoanCon" runat="server" Text=""></asp:Label>
                                       </td>
                                      <td style="width:150px;">
                                        Ngày đến hạn: 
                                      </td>
                                       <td align="left" style="width:150px;">
                                          <asp:Label ID="lblNgayDenHan" runat="server" Text=""></asp:Label>
                                       </td>
                                   </tr>
                                    <tr >
                                      <td style="width:150px;" style="width:150px;">
                                        Số lượng Email 
                                      </td>
                                       <td align="left">
                                           <asp:Label ID="lblSoLuongEmail" runat="server" Text=""></asp:Label>
                                       </td>
                                      <td style="width:150px;" >
                                        Giới hạn email gửi đi:
                                      </td>
                                       <td align="left" style="width:150px;">
                                           <asp:Label ID="lblGioiHanEmail" runat="server" Text=""></asp:Label>
                                       </td>
                                   </tr>
                                </table>
                                <div style="margin-bottom:20px;">Các tính năng sử dụng</div>
                                <div class="full-width-editor">
                                    <div style="float:left;padding:5px;height:100%;width:510px;border: 1px solid rgb(221, 231, 255);">
                                        <asp:Repeater ID="rptFunction" runat="server">
                                            <ItemTemplate>
                                                <div class="confirmation-box" style="width:199px;float:left;border:none !important">
                                                     <%#Eval("functionName") %>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div style="width:408px;float:left;">
                                        
                                        <table class="full-width-editor">
                                            <tr>
                                                <td>Gia hạn</td>
                                                <td align="left" style="text-align:left !important">
                                                    <asp:Button ID="btnGiahan" runat="server" Text="Gia hạn" CssClass="button round blue image-right ic-add text-upper"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Điều chỉnh gói dịch vụ</td>
                                                <td align="left" style="text-align:left !important">
                                                    <asp:Button ID="btnGiahan0" runat="server" Text="Điều chỉnh gói dịch vụ" CssClass="button round blue image-right ic-add text-upper"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div style="clear:both;margin-bottom:20px;"></div>
                                <div class="full-width-editor">
                                    <div>Email:<asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></div>
                                    <table class="full-width-editor">
                                        <tr>
                                            <td>Họ tên</td>
                                            <td>
                                                <asp:TextBox ID="txtHoTen" runat="server" CssClass="full-width-input"></asp:TextBox>
                                            </td>
                                            <td>Ngày sinh</td>
                                            <td>
                                                  <script type="text/javascript">
                                                      $(function () {
                                                          $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtDateofBirth').datetimepicker({
                                                              changeMonth: true, changeYear: true, timeFormat: "", dateFormat: "dd/mm/yy"
                                                          });
                                                      });
                                                  </script>
                                                <asp:TextBox ID="txtDateofBirth" CssClass="full-width-input" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Địa chỉ</td>
                                            <td><asp:TextBox ID="txtDiaChi" runat="server" CssClass="full-width-input"></asp:TextBox></td>
                                            <td>Số điện thoại</td>
                                            <td><asp:TextBox ID="txtSoDienThoai" runat="server" CssClass="full-width-input"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                    <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CssClass="button round blue image-right ic-add text-upper" OnClick="btnUpdate_Click"/>            
                                </div>
                            </div>
                        
                        <!-- end content-module-main -->
                    </div>
                </div>
                <!--end content 01-->
            </div>
</asp:Content>

