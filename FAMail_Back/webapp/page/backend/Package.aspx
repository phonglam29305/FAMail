<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" CodeFile="Package.aspx.cs" Inherits="webapp_page_backend_Package" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="side-content fr">

        <!--start content 01-->
        <div class="content-module">
            <div class="content-module-heading cf">
                <h3 class="fl">Thông tin gói dịch vụ</h3>
                <span class="fr expand-collapse-text">Thu vào</span>
                <span class="fr expand-collapse-text initial-expand">Mở ra</span>
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
                    <div class="half-size-column fl">
                        <asp:HiddenField ID="hdfId" runat="server" />
                        <fieldset>
                            <p>
                                <label for="full-width-input">Tên gói dịch vụ</label>
                                <asp:TextBox ID="txtname" CssClass="round default-width-input"
                                    runat="server"></asp:TextBox>

                            </p>
                            <p>
                                <label for="full-width-input">Diễn giải</label>
                                <asp:TextBox ID="txtdescription" CssClass="round default-width-input" TextMode="MultiLine"
                                    runat="server"></asp:TextBox>

                                <br />
                                
                                <br />

                                <label for="simple-input">Giới hạn mail</label>
                                <asp:DropDownList ID="drlPackageLimit" runat="server" CssClass="round default-width-input" Style="height: 35px; border: 1px solid #bbbdbe; width: 360px;">
                                </asp:DropDownList>
                            </p>


                            <br />
                        </fieldset>

                    </div>
                    <!-- end half-size-column -->
                    <div class="half-size-column fr" style="height: 170px;">
                        <fieldset>
                            <p>

                                <label for="full-width-input">Số tài khoản con </label>
                                <asp:TextBox ID="txtsubaccount" CssClass="round default-width-input"
                                    runat="server"></asp:TextBox>


                                <br />
                            </p>
                            
                            <p>
                                <label for="simple-input">Không giới hạn số email quản lý</label>
                                <asp:CheckBox ID="ceIsUnlimit" runat="server" />

                            </p>
                            <p>

                                <label for="full-width-input">Số Email quản lý </label>
                                <asp:TextBox ID="txtEmailCount" CssClass="round default-width-input"
                                    runat="server"></asp:TextBox>


                                <br />
                            </p>
                            <p>
                                <label for="simple-input">Dùng thử</label>
                                <asp:CheckBox ID="ceTry" runat="server" />

                            </p>
                            <p>
                                <label for="simple-input">Kích hoạt</label>
                                <asp:CheckBox ID="ceIsActive" runat="server" />

                            </p>


                        </fieldset>
                    </div>
                    <div class="full-width-editor" style="float: left; margin-top: 30px;">

                        <br />
                        <fieldset>

                            <asp:Button ID="btnSave" runat="server" Text="Lưu"
                                CssClass="button round blue image-right ic-add text-upper"
                                OnClick="btnSave_Click" />


                        </fieldset>
                    </div>


                    <!-- end content-module-main -->
                </div>
            </div>

            <!--end content 01-->
        </div>



        <div class="content-module">

            <div class="full-width-editor">
                <div class="content-module-heading cf">
                    <h3 class="fl">Danh sách chức năng </h3>
                    <span class="fr expand-collapse-text">Thu vào</span>
                    <span class="fr expand-collapse-text initial-expand">Mở ra</span>
                </div>
                <!-- end content-module-heading -->
                <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.\sqlexpress;Initial Catalog=SendMailVersion3;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT [functionId], [functionName], [cost], [description], [isDefault] FROM [tblFunction] ORDER BY [functionId], [functionId], [functionId]"></asp:SqlDataSource>--%>                <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.\sqlexpress;Initial Catalog=SendMailVersion3;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT [functionId], [functionName], [cost], [description], [isDefault] FROM [tblFunction] ORDER BY [functionId], [functionId], [functionId]"></asp:SqlDataSource>--%>
                <asp:DataList ID="dtfunction" runat="server" RepeatColumns="1" Width="100%">
                    <HeaderTemplate>
                        <thead>
                            <tr>

                                <th>Tên gói dịch vụ </th>
                                <th>Số lượng tk con  </th>
                                <th>Giới hạn mail </th>
                                <th>Hiệu lực </th>
                                <th>Diều chỉnh </th>
                            </tr>
                        </thead>
                    </HeaderTemplate>
                    <FooterTemplate>
                        <tfoot>
                            <tr>
                                <td colspan="5" class="table-footer"></td>
                            </tr>
                        </tfoot>
                    </FooterTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>

                                <td style="text-align: left; padding-left: 10px;">
                                    <asp:Label ID="lblAttr" runat="server" Text='<%# Eval("packageName") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblGmail" runat="server" Text='<%# Eval("subAccontCount") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblYahooMail" runat="server" Text='<%# Eval("limitId") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("isActive") %>'></asp:Label>
                                </td>



                                <td>

                                    <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/webapp/resource/images/edit-validated-icon.png"
                                        CommandArgument='<%# Eval("packageId") %>' OnClick="btnEdit_Click" />
                                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                        CommandArgument='<%# Eval("packageId") %>'
                                        OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa thuộc tính này không ?')"
                                        OnClick="btnDelete_Click" />
                                    <a href="packagefunction.aspx?id=<%# Eval("packageId") %>">
                                    <img src="../../resource/images/list-function.png" /></a>
                                       
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:DataList>
                <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.\sqlexpress;Initial Catalog=SendMailVersion3;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT [functionId], [functionName], [cost], [description], [isDefault] FROM [tblFunction] ORDER BY [functionId], [functionId], [functionId]"></asp:SqlDataSource>--%>
                                </table>
                  
            </div>

        </div>
    </div>
</asp:Content>

