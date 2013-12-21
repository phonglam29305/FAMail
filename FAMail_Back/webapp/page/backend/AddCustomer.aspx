<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/management.master" 
AutoEventWireup="true" CodeFile="AddCustomer.aspx.cs" Inherits="webapp_page_backend_AddCustomer" Title="FASTAUTOMATICMAIL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
        $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_dtlCustomer_ctl00_chkAll:checkbox').change(function () {
            if ($(this).attr("checked")) $('input:checkbox').attr('checked', 'checked');
            else $('input:checkbox').removeAttr('checked');
        });
</script>
 <div class="side-content fr">
          <asp:HiddenField ID="hdfCustomerId" runat="server" /> 
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
                        THÊM KHÁCH HÀNG</h3>
                    <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">
                        Mở ra</span>
                </div>
                <!-- end content-module-heading -->
                <div class="content-module-main" style="height: 440px; padding-left: 40px;">
                    <%--<form  runat="server">--%>
                    <div class="half-size-column fl">
                        <fieldset style="font-weight: bold; font-family: Times New Roman , Arial, MS Gothic;">
                            <p>
                                <label for="full-width-input">
                                    Họ và tên</label>
                                <asp:TextBox ID="txtName" CssClass="round default-width-input" runat="server"></asp:TextBox>
                                <em>Tên đầy đủ của khách hàng ! </em>
                            </p>
                            <p>
                                <label for="simple-input">
                                    Giới tính</label>
                                <asp:DropDownList ID="drlGender" runat="server" CssClass="round default-width-input"
                                    Style="height: 35px; border: 1px solid #bbbdbe; width: 200px;" AutoPostBack="true">
                                    <asp:ListItem Value="Nam">Nam</asp:ListItem>
                                    <asp:ListItem Value="Nu">Nữ</asp:ListItem>
                                </asp:DropDownList>
                                <em>Giới tính666</em>
                            </p>
                            <p>
                                <label for="simple-input">
                                    Ngày sinh</label>
                                <asp:TextBox ID="txtBirthday" CssClass="round default-width-input" runat="server"></asp:TextBox>
                                <em>Ngày sinh của khách hàng!</em>
                            </p>
                            <p>
                                <label for="full-width-input">
                                    Email</label>
                                <asp:TextBox ID="txtEmail" CssClass="round default-width-input" runat="server"> </asp:TextBox>
                                <em>Email của khách hàng! </em>
                            </p>
                            <asp:Button ID="btnAdd" runat="server" Text="Lưu" CssClass="button round blue image-right ic-add text-upper"
                                OnClick="btnAdd_Click" />
                            <asp:Button ID="btnRefesh" runat="server" Text="Nhập lại" CssClass="button round blue image-right ic-refresh text-upper"
                                OnClick="btnRefesh_Click" />
                            <asp:Button ID="btnBack" runat="server" Text="Về danh sách" CssClass="button round blue image-right ic-upload text-upper"
                                OnClick="btnBack_Click" />
                        </fieldset>
                    </div>
                    <!-- end half-size-column -->
                    <div class="half-size-column fr">
                        <fieldset style="font-weight: bold; font-family: Times New Roman , Arial, MS Gothic;">
                            <p>
                                <label for="full-width-input">
                                    Di đông</label>
                                <asp:TextBox ID="txtPhone" CssClass="round default-width-input" runat="server"></asp:TextBox>
                                <em>Số điện thoại di động ! </em>
                            </p>
                            <p>
                                <label for="simple-input">
                                    Điện thoại bàn</label>
                                <asp:TextBox ID="txtHomePhone" CssClass="round default-width-input" runat="server"></asp:TextBox>
                                <em>Số điện thoại nhà hoặc cơ quan !</em>
                            </p>
                            <p>
                                <label for="simple-input">
                                    Đỉa chỉ</label>
                                <asp:TextBox ID="txtAddress" CssClass="round default-width-input" runat="server"></asp:TextBox>
                                <em>Địa chỉ của khách hàng .</em>
                            </p>
                            <p>
                                <label for="simple-input">
                                    Nhóm Mail</label>
                                <asp:DropDownList ID="drlGroup" runat="server" CssClass="round default-width-input"
                                    Style="height: 35px; border: 1px solid #bbbdbe; width: 360px;">
                                </asp:DropDownList>
                                <em>Chọn nhóm mail</em>
                            </p>
                            <p>
                                <asp:HiddenField ID="CustomerID" runat="server" />
                            </p>
                        </fieldset>
                    </div>
                    <%-- </form>--%>
                </div>
                <!-- end content-module-main -->
            </div>
 
        </div>
 <div class="side-content fr">
            <div class="content-module">
                <div class="content-module-heading cf">
                    <h3 class="fl">
                        Thêm từ file Excel</h3>
                    <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">
                        Mở ra</span>
                </div>
                <!-- end content-module-heading -->
                <div class="content-module-main" style="display: none">
                    <%--<form  runat="server">--%>
                    <fieldset>
                        <p>
                            <asp:FileUpload ID="fileExcel" runat="server" CssClass="button round blue image-right ic-upload text-upper" />
                            <asp:Button ID="btnReadExcel" runat="server" Text="Đọc file" CssClass="button round blue image-right ic-upload text-upper"
                                OnClick="btnReadExcel_Click" />
                            >>Tải danh sách khách hàng mẫu <a href="../../../file/Customer.xls">tại đây</a>
                        </p>
                    </fieldset>
                               <script>
                                   function checkAll() {
                                       var checked = !$(this).data('checked');
                                       $('input:checkbox').prop('checked', checked);
                                       $(this).data('checked', checked);
                                   }
                              </script>
                    <table id="tbl" width="100px">
                    
                       <asp:DataList ID="dtlCustomer" runat="server">
                            <HeaderTemplate>
                                <thead>
                                    <tr>
                                        <th style="width: 50px;">
                                            <input type="checkbox" onclick="checkAll()" value = "All" />
                                        </th>
                                        <th style="text-align: left; padding-left: 10px;">
                                            Họ và tên
                                        </th>
                                        <th>
                                            Giới tính
                                        </th>
                                        <th>
                                            Ngày sinh
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
                                    </tr>
                                </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td style="width: 50px;">
                                            <asp:CheckBox ID="chkCheck" runat="server" />
                                        </td>
                                        <td style="text-align: left; padding-left: 10px;">
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBirthDay" runat="server" Text='<%# Eval("Birthday") %>'></asp:Label>
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
                                    </tr>
                                </tbody>
                            </ItemTemplate>
                             <FooterTemplate>
                </tbody>
                 <tfoot style="padding:10px;">
                        <tr style="margin:5px;">
                            <td colspan="7" class="table-footer">
                  
                            </td>
                           
                        </tr>
                    </tfoot>	 
        	    
        	   
                </FooterTemplate>
                        </asp:DataList>
                        <asp:Panel ID="pnSelectGroup" runat="server">
                            <tr>
                                <td style="width: 50px;" colspan="5">
                                    <label for="table-select-actions" style="font-weight: bolder;">
                                        Lựa chọn:</label>
                                    <asp:DropDownList ID="drlMailGroup" runat="server"  Height="30px">
                                        <asp:ListItem Value="0">All</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Button ID="btnSave" runat="server" Text="Thêm vào" CssClass="round button blue text-upper small-button"
                                        OnClick="btnSave_Click" />
                                </td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnBackAddGroup" runat="server">
                            <a href="group-mail.aspx">Tạo nhóm mail mới</a>
                        </asp:Panel>
                    </table>
                    <%-- </form>--%>
                </div>
                <!-- end content-module-main -->
            </div>
        </div>
        <!-- ============= datetime picker -->

    <script type="text/javascript">
        $(function() {
            $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBirthday').datetimepicker({
	            changeMonth:true, changeYear:true, timeFormat: "", dateFormat: "dd/mm/yy"
            });
        });	
    </script>

    

</asp:Content>

