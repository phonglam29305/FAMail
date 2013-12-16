<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/management.master"
    AutoEventWireup="true" CodeFile="group-mail.aspx.cs" Inherits="webapp_page_backend_group_mail"
    Title="FASTAUTOMATICMAIL"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="side-content fr">
                <!--start content 01-->
                <div class="content-module">
                    <div class="content-module-heading cf">
                        <h3 class="fl"> Thêm nhóm Email</h3>
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
                            &nbsp;<div class="full-width-editor">
                                <fieldset>
                                    <p>
                                        <asp:HiddenField ID="GroupId" runat="server" />
                                        <label for="simple-input"> Tên Nhóm email</label>
                                        <asp:TextBox ID="txtGroupName" CssClass="round default-width-input" Width="98%" runat="server"></asp:TextBox>
                                        <em>Tên nhóm email, Ví dụ: Chomy.com, Người trẻ..</em>
                                         <label for="simple-input"> Tài khoản con</label>
                                         <asp:DropDownList ID="dropSubClient" runat="server" CssClass="round default-width-input" style="height: 35px; border: 1px solid #bbbdbe; width:360px;">
                                         </asp:DropDownList>
                                        <em>Tài khoản con</em>
                                        <label for="simple-input"> chú thích</label>
                                        <asp:TextBox ID="txtDescription" CssClass="round default-width-input" Width="98%"
                                            runat="server"></asp:TextBox>
                                        <em>Giải thích cho nhóm mail trên</em>
                                    </p>
                                    <div class="stripe-separator">
                                        <!--  -->
                                    </div>
                                    <asp:Button ID="btnSave" runat="server" Text="Lưu nhóm Email" CssClass="button round blue image-right ic-add text-upper"
                                        OnClick="btnSave_Click" />
                                    <%--<asp:Button ID="btnTestEvent" runat="server" Text="Test" 
                                CssClass="round blue ic-right-arrow"/>--%>
                                </fieldset>
                            </div>
                            <div class="stripe-separator">
                                <!--  -->
                            </div>
                            <div class="full-width-editor">
                                <table>
                                    <asp:DataList ID="dlGroupMail" runat="server" RepeatColumns="1" Width="100%">
                                        <HeaderTemplate>
                                            <thead>
                                                <tr>
                                                    <th> NO. </th>
                                                    <th>  Nhóm Mail </th>
                                                     <th>  Tài khoản con </th>
                                                    <th>  Chú thích </th>
                                                    <th>  Chức năng </th>
                                                </tr>
                                            </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tbody>
                                                <tr>
                                                    <td> <asp:Label ID="lblNO" runat="server"></asp:Label> </td>
                                                    <td> <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label></td>
                                                     <td> <asp:Label ID="lblSub" runat="server" Text='<%# Eval("AssignTo") %>'></asp:Label></td>
                                                    <td>  <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>  </td>
                                                    <td>
                                                        <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/webapp/resource/images/edit-validated-icon.png"
                                                            CommandArgument='<%# Eval("id") %>' OnClick="btnEdit_Click" />
                                                        <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                                            CommandArgument='<%# Eval("id") %>' OnClientClick="return confirmDelete('Nếu tiếp tục dữ liệu sẽ bị xóa khỏi hệ thống ?')"
                                                            OnClick="btnDelete_Click" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <tfoot>
                                                <tr>
                                                    <td colspan="5" class="table-footer">
                                                    </td>
                                                </tr>
                                            </tfoot>
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
