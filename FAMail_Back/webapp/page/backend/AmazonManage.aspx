<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" CodeFile="AmazonManage.aspx.cs" Inherits="webapp_page_backend_AmazonManage" Title="FASTAUTOMATICMAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="side-content fr">
                <!--start content 01-->
                <div class="content-module">
                    <div class="content-module-heading cf">
                        <h3 class="fl"> Danh sách Email Verify với AMAZON</h3>
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

                          <asp:Panel Visible="false" ID="pnSuccessverify" runat="server">
                            <div class="confirmation-box round">
                               <asp:Label ID="lbverify" runat="server" Text="Label"></asp:Label>
                               <asp:Button ID="btnSaveAndSend" runat="server" Text="Kích hoạt " CssClass="round blue ic-right-arrow" OnClientClick="return confirmDelete('Chúng tôi đã gởi một email đến địa chỉ mail bạn cần verify.Bạn vui lòng mở mail để kích hoạt sử dụng') " OnClick="btnSaveAndSend_Click"       />
                                                              
                            </div>
                        </asp:Panel>

                        <div class="content-module-main cf">
                           
                            <div class="full-width-editor">
                                <table>
                                   <tr >
                                      <td style="border-color:White; background-color:White; text-align:left; padding: 5px;">
                                        Email verify&nbsp;&nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtEmailVerify" 
                                              runat="server" Height="20px" ToolTip="Nhập địa chỉ Email muốn xác thực với Amazon"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailVerify"
                                    Display="Dynamic" ErrorMessage="Email không hợp lệ" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
                                    ValidationGroup="CheckInput_Email"></asp:RegularExpressionValidator>
                                           
                                      Tên cấu hình: &nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtNameConfig" runat="server" ToolTip="Tên cấu hình là tên hiện thị khi bạn gửi đến hộp thư của người khác"></asp:TextBox>
                                      &nbsp;&nbsp;&nbsp;&nbsp;
                                          <asp:Button
                                            ID="btnVerify" runat="server" Text="Verify Email" ValidationGroup="CheckInput_Email"
                                              CssClass="button round blue image-right ic-add text-upper" 
                                              onclick="btnVerify_Click" />&nbsp;&nbsp;<asp:Button
                                            ID="Button1" runat="server" Text="Cập nhật danh sách" 
                                              CssClass="button round blue image-right ic-add text-upper" 
                                              onclick="btnReload_Click" />
                                          <asp:Label ID="lbuser" runat="server" Visible="False"></asp:Label>
                                       </td>
                                      </tr>
                                  <asp:DataList ID="dtlEmail" runat="server">
                                   <HeaderTemplate>
                                            <thead>
                                                <tr>
                                                    <th>  STT</th>
                                                    <th>  Email xác thực</th>
                                                     <th> Tên cấu hình</th>
                                                    <th>  Trạng thái</th>
                                                    <th>  Chức năng </th>
                                                </tr>
                                            </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                     
                                            <tbody>
                                                <tr>
                                                    <td>  <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("No") %>'></asp:Label></td>
                                                    <td>  <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label></td>
                                                    <td>  <asp:Label ID="Label2" runat="server" Text='<%# Eval("Name") %>'></asp:Label></td>
                                                    <td>  <asp:Label ID="Label1" runat="server" Text='<%# Eval("Status") %>'></asp:Label></td>
                                                    <td>  <asp:LinkButton ID="lbtContentDelete" runat="server" Height="15px" 
								                                OnClientClick="return confirmDelete('Nếu tiếp tục dữ liệu sẽ bị xóa khỏi hệ thống ?')"
                                                                    Width="15px" CssClass="table-actions-button ic-table-delete" 
                                                                     CommandArgument='<%# Eval("Email") %>' 
                                                            onclick="lbtContentDelete_Click"></asp:LinkButton>
                                                   </td>
                                                </tr>
                                            </tbody>
                                       
                                          
                                </ItemTemplate>
                                <FooterTemplate>
                            
                                </FooterTemplate>
                            </asp:DataList>
                                   
                                </table>
                            </div>
                        </div>
                        <!-- end content-module-main -->
                    </div>
                </div>
                <!--end content 01-->
            </div>
   
</asp:Content>

