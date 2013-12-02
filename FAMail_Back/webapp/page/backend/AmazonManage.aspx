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
                        <div class="content-module-main cf">
                           
                            <div class="full-width-editor">
                                <table>
                                   <tr >
                                      <td style="border-color:White; background-color:White; text-align:left; padding: 5px;">
                                        Email verify&nbsp;&nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtEmailVerify" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                            ID="btnVerify" runat="server" Text="Verify Email" 
                                              CssClass="button round blue image-right ic-add text-upper" 
                                              onclick="btnVerify_Click" />
                                      </td>
                                      
                                   </tr>
                                  <asp:DataList ID="dtlEmail" runat="server">
                                   <HeaderTemplate>
                                            <thead>
                                                <tr>
                                                    <th>  STT </th>
                                                    <th>  Email</th>
                                                    <th>  Chức năng </th>
                                                </tr>
                                            </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                     
                                            <tbody>
                                                <tr>
                                                    <td>   <asp:Label ID="lblNo" runat="server" Text='<%# Eval("No") %>'></asp:Label></td>
                                                    <td>  <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label></td>
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

