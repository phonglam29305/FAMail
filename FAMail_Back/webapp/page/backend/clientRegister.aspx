<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" CodeFile="clientRegister.aspx.cs" Inherits="webapp_page_backend_clientRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="side-content fr">

        <!--start content 01-->
        <div class="content-module">
            <div class="content-module-heading cf">
                <h3 class="fl">Thông tin khách hàng</h3>
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
                                <label for="full-width-input">Tên khách hàng</label>
                                <asp:TextBox ID="txtname" CssClass="round default-width-input" Width="820px"
                                    runat="server"></asp:TextBox>

                            </p>                                       
                           
                             <p>
                                <label for="full-width-input">Gói dich vụ</label>                          
                                 <asp:DropDownList ID="Dropgoidichvu" runat="server" CssClass="round default-width-input" Style="height: 35px; border: 1px solid #bbbdbe; width: 360px;">
                                  <asp:ListItem Value="-1">Tất cả</asp:ListItem>
                                 </asp:DropDownList>                             
                               </p>                     
                            
                            <p>
                                <label for="simple-input">Ngày đăng ký từ </label>
                               <asp:TextBox ID="txtngaydangky" CssClass="round default-width-input" 
                                runat="server"></asp:TextBox>
                            </p>
                              
                            <p>
                                <label for="simple-input">Ngày hết hạng từ </label>
                               <asp:TextBox ID="txtngayhethang" CssClass="round default-width-input" 
                                runat="server"></asp:TextBox>
                            </p>
                           
                           
                        </fieldset>

                    </div>
                    <!-- end half-size-column -->
                    <div class="half-size-column fr" style="height: 170px; margin-top:76px;">
                        <fieldset>
                            
                             <p>
                                <label for="full-width-input">Loại giao dịch</label>                          
                                 <asp:DropDownList ID="Droploaigiaodich" runat="server" CssClass="round default-width-input" Style="height: 35px; border: 1px solid #bbbdbe; width: 360px;">
                                 <asp:ListItem Value="-1">Tất cả</asp:ListItem>
                                 </asp:DropDownList>                             
                               </p>                     
                          
                            <p>
                                <label for="simple-input">Đến </label>
                               <asp:TextBox ID="txtdenngaydangky" CssClass="round default-width-input" 
                                runat="server"></asp:TextBox>
                            </p>
                             
                            <p>
                                <label for="simple-input">Đến </label>
                               <asp:TextBox ID="txtdenngayhethang" CssClass="round default-width-input" 
                                runat="server"></asp:TextBox>
                            </p>
                           


                        </fieldset>
                    </div>
                    <div class="full-width-editor" style="float: left; margin-top: 30px; height: 60px;">

                        <br />
                        <fieldset>

                            <asp:Button ID="btnSave" runat="server" Text="Tìm kiếm"
                                CssClass="button round blue image-right ic-add text-upper" 
                                 />


                        </fieldset>
                    </div>


                    <!-- end content-module-main -->
                </div>
            </div>

            <!--end content 01-->
        </div>



        <div class="content-module">

            <div class="full-width-editor">
                <!-- end content-module-heading -->
                <%--<table>	                --%>
                <%--  <table>--%>
                <asp:DataList ID="dtregister" runat="server" RepeatColumns="1" Width="100%">
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
                                        CommandArgument='<%# Eval("packageId") %>'  />
                                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                        CommandArgument='<%# Eval("packageId") %>'
                                        OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa thuộc tính này không ?')"
                                         />
                                    <a href="packagefunction.aspx?id=<%# Eval("packageId") %>">
                                    <img src="../../resource/images/list-function.png" /></a>
                                       
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:DataList>
                <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.\sqlexpress;Initial Catalog=SendMailVersion3;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT [functionId], [functionName], [cost], [diengiai], [isDefault] FROM [tblFunction] ORDER BY [functionId], [functionId], [functionId]"></asp:SqlDataSource>--%>
                                </table>
                  
            </div>

        </div>
    </div>


    <!-- ============= datetime picker -->

    <script type="text/javascript">
        $(function () {
            $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtngayhethang').datetimepicker({
                changeMonth: true, changeYear: true, timeFormat: "", dateFormat: "dd/mm/yy"
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtngaydangky').datetimepicker({
                changeMonth: true, changeYear: true, timeFormat: "", dateFormat: "dd/mm/yy"
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtdenngayhethang').datetimepicker({
                changeMonth: true, changeYear: true, timeFormat: "", dateFormat: "dd/mm/yy"
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtdenngaydangky').datetimepicker({
                changeMonth: true, changeYear: true, timeFormat: "", dateFormat: "dd/mm/yy"
            });
        });
    </script>
</asp:Content>

