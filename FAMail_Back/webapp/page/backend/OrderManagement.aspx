<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/backend.master"
    AutoEventWireup="true" CodeFile="OrderManagement.aspx.cs" Inherits="webapp_page_backend_OrderManagement"
    Title="EMAILMARKETING.1ONLINEBUSINESSSYSTEM.COM" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../../resource/other/FancySlidingForm/sliding.form.js" type="text/javascript"></script>

    <script type="text/javascript">
        function ValidateKeypress(numcheck, e) {
            var keynum, keychar, numcheck;
            if (window.event) {//IE
                keynum = e.keyCode;
            }
            else if (e.which) {// Netscape/Firefox/Opera
                keynum = e.which;
            }
            if (keynum == 8 || keynum == 127 || keynum == null || keynum == 9 || keynum == 0 || keynum == 13) return true;
            keychar = String.fromCharCode(keynum);
            var result = numcheck.test(keychar);
            return result;
        }
    </script>

    <link href="../../resource/other/FancySlidingForm/css/style.css" rel="stylesheet"
        type="text/css" />
    <style>
        span.reference
        {
            position: fixed;
            left: 5px;
            top: 5px;
            font-size: 10px;
            text-shadow: 1px 1px 1px #fff;
        }
        span.reference a
        {
            color: #555;
            text-decoration: none;
            text-transform: uppercase;
        }
        span.reference a:hover
        {
            color: #000;
        }
        h1
        {
            color: #ccc;
            font-size: 36px;
            text-shadow: 1px 1px 1px #fff;
            padding: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="page-full-width cf">
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
            <div class="side-menu fl">
                <h3>
                    Đơn đặt hàng</h3>
                <ul>
                    <li><a href="ListOrder.aspx">Danh sách đơn hàng</a></li>
                    <li><a href="OrderManagement.aspx">Thêm đơn hàng</a></li>
                    <li><a href="Customer.aspx">Danh sách khách hàng</a></li>
                </ul>
            </div>
            <!-- end side-menu -->
            <div class="side-content fr">
                <div class="content-module">
                    <div class="content-module-heading cf">
                        <h3 class="fl">
                            Nhập hóa đơn</h3>
                        <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">
                            Mở ra</span>
                    </div>
                    <!-- end content-module-heading -->
                    <div class="content-module-main" style="">
                        <div id="wrapper">
                            <div id="steps">
                                <div id="formElem" name="formElem">
                                    <fieldset class="step">
                                        <legend>Thông tin khách hàng</legend>
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
                                                        <asp:ListItem Value="Nữ">Nữ</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <em>Giới tính</em>
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
                                            </fieldset>
                                        </div>
                                        <!-- end half-size-column -->
                                        <div class="half-size-column fr">
                                            <fieldset style="font-weight: bold; font-family: Times New Roman , Arial, MS Gothic;">
                                                <p>
                                                    <label for="full-width-input">
                                                        Di đông</label>
                                                    <asp:TextBox ID="txtPhoneNumber" CssClass="round default-width-input" runat="server"></asp:TextBox>
                                                    <asp:HiddenField ID="hdfUpdate" runat="server" />
                                                    <em>Số điện thoại di động ! </em>
                                                </p>
                                                <p>
                                                    <label for="simple-input">
                                                        Điện thoại bàn</label>
                                                    <asp:TextBox ID="txtSecondPhone" CssClass="round default-width-input" runat="server"></asp:TextBox>
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
                                                    <asp:DropDownList ID="drlGroupMail" runat="server" CssClass="round default-width-input"
                                                        Style="height: 35px; border: 1px solid #bbbdbe; width: 360px;">
                                                    </asp:DropDownList>
                                                    <em>Chọn nhóm mail</em>
                                                </p>
                                            </fieldset>
                                        </div>
                                    </fieldset>
                                    <fieldset class="step">
                                        <legend>Thông tin hóa đơn</legend>
                                        <div class="half-size-column fl">
                                            <fieldset style="font-weight: bold; font-family: Times New Roman , Arial, MS Gothic;">
                                                <p>
                                                    <label for="full-width-input">
                                                        Mã hóa đơn</label>
                                                    <asp:TextBox ID="txtOrderID" CssClass="round default-width-input" runat="server"
                                                        Enabled="False" ToolTip="Mã hóa đơn được phát sinh tự động"></asp:TextBox>
                                                    <em>Mã hóa đơn tự động phát sinh</em></p>
                                                <p>
                                                    <label for="simple-input">
                                                        Người lập</label>
                                                    <asp:TextBox ID="txtPersonCreate" CssClass="round default-width-input" runat="server"
                                                        ToolTip="Người dùng tạo ra hóa đơn này"></asp:TextBox>
                                                    <em>Người lập hóa đơn</em>
                                                </p>
                                                <p>
                                                    <label for="simple-input">
                                                        phương thức giao hàng</label>
                                                    <asp:TextBox ID="txtDiliveryMethod" CssClass="round default-width-input" runat="server"
                                                        ToolTip="Bạn nhập phương thức giao hàng"></asp:TextBox>
                                                    <em>Phương thức giao hàng , ví dụ : Gửi bưu điện ,giao trực tiếp</em>
                                                </p>
                                                <p>
                                                    <label for="full-width-input">
                                                        hình thức thanh toán</label>
                                                    <asp:TextBox ID="txtPaymentMethod" CssClass="round default-width-input" runat="server"> </asp:TextBox>
                                                    <em>Chọn hình thức thanh toán , ví dụ : tiền mặt , chuyển khoản , ...</em></p>
                                            </fieldset>
                                        </div>
                                        <!-- end half-size-column -->
                                        <div class="half-size-column fr">
                                            <fieldset style="font-weight: bold; font-family: Times New Roman , Arial, MS Gothic;">
                                                <p>
                                                    <label for="full-width-input">
                                                        Ngày lập</label>
                                                    <asp:TextBox ID="txtCreateDate" CssClass="round default-width-input" runat="server"></asp:TextBox>
                                                    <em>Ngày lập hóa đơn </em>
                                                </p>
                                                <p>
                                                    <label for="simple-input">
                                                        Ngày giao hàng</label>
                                                    <asp:TextBox ID="txtDeliveryDate" CssClass="round default-width-input" runat="server"></asp:TextBox>
                                                    <em>Ngày giao hàng cho khách</em>
                                                </p>
                                                 <p>
                                                    <label for="simple-input">
                                                        TIỀN ĐẶT CỌC</label>
                                                    <asp:TextBox ID="txtHandsel" CssClass="round default-width-input" runat="server"></asp:TextBox>
                                                    <em>Tiền khách hàng trả trước</em>
                                                </p>
                                                <p>
                                                    <label for="simple-input">
                                                        trạng thái</label>
                                                    <asp:DropDownList ID="drlStatus" runat="server" CssClass="round default-width-input"
                                                        Style="height: 35px; border: 1px solid #bbbdbe; width: 360px;">
                                                        <asp:ListItem Value="False">Chưa giao hàng</asp:ListItem>
                                                        <asp:ListItem Value="True">Đã giao hàng</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <em>Tình trạng của đơn hàng , ví dụ : Đã giao , hủy đơn hàng, chưa giao</em>
                                                </p>
                                            </fieldset>
                                        </div>
                                    </fieldset>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <fieldset class="step">
                                                <legend>Chi tiết hóa đơn</legend><br />
                                                <div style="margin-top:20px;">
                                                   <asp:Panel ID="pnInfo" runat="server" Visible="false">
                                                  <div class="error-box round">
                                                    <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                                                </div>
                                                </asp:Panel>
                                                </div>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            Mã sản phẩm
                                                        </td>
                                                        <td style="border-bottom: 0px;">
                                                            <asp:TextBox ID="txtProductID" runat="server" Width="85%" AutoPostBack="True" OnTextChanged="txtProductID_TextChanged"></asp:TextBox>
                                                            <asp:HiddenField ID="hdfUpdateProduct" runat="server" Value="" />
                                                        </td>
                                                        <td style="border-bottom: 0px;">
                                                            Tên sản phẩm
                                                        </td>
                                                        <td style="border-bottom: 0px;">
                                                            <asp:TextBox ID="txtProductName" runat="server" Width="85%"></asp:TextBox>
                                                        </td>
                                                      <td style="border-bottom: 0px;">
                                                            Mã giao hàng
                                                        </td>
                                                     
                                                         <td style="border-bottom: 0px;">
                                                            <asp:TextBox ID="txtDeliveryCode" runat="server" Width="85%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-bottom: 0px;">
                                                            Đơn giá
                                                        </td>
                                                        <td style="border-bottom: 0px;">
                                                            <asp:TextBox ID="txtUnitPrice" runat="server" Width="85%" OnTextChanged="txtUnitPrice_TextChanged"
                                                                AutoPostBack="true" onkeypress="return ValidateKeypress(/\d/,event);"></asp:TextBox>
                                                        </td>
                                                        <td style="border-bottom: 0px;">
                                                            Số lượng
                                                        </td>
                                                        <td style="border-bottom: 0px;">
                                                            <asp:TextBox ID="txtQuantity" runat="server" OnTextChanged="txtQuantity_TextChanged"
                                                                Width="85%" AutoPostBack="true"></asp:TextBox>
                                                        </td>
                                                        <td style="border-bottom: 0px;">
                                                            Tổng cộng
                                                        </td>
                                                        <td style="border-bottom: 0px;">
                                                            <asp:TextBox ID="txtTotal" runat="server" Enabled="False" Width="85%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                       
                                                             <td style="border-bottom: 0px;">
                                                            Ghi chú
                                                        </td>
                                                        <td style="border-bottom: 0px;" colspan="4">
                                                            <asp:TextBox ID="txtNote" runat="server" Width="85%"></asp:TextBox>
                                                        </td>
                                                        <td style="border-bottom: 0px;">
                                                            <asp:Button ID="btnAddProduct" runat="server" Text="Thêm" CssClass="button round blue image-right ic-add text-upper"
                                                                OnClick="btnAddProduct_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:GridView ID="grvProduct" runat="server" AutoGenerateColumns="False"
                                                    PageSize="6">
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                    <Columns>
                                                        <asp:BoundField DataField="ProductID" HeaderText="Mã sản phẩm" />
                                                        <asp:BoundField DataField="ProductName" HeaderText="Tên sản phẩm" />
                                                        <asp:BoundField DataField="DeliveryCode" HeaderText="Mã giao hàng" />
                                                        <asp:BoundField DataField="UnitPrice" HeaderText="Đơn giá" />
                                                        <asp:BoundField DataField="Quantity" HeaderText="Số lượng" />
                                                        <asp:BoundField DataField="Total" HeaderText="Tổng cộng" />
                                                        <asp:BoundField DataField="Note" HeaderText="Ghi chú" />
                                                        <asp:TemplateField HeaderText="Chức năng">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/webapp/resource/images/edit-validated-icon.png"
                                                                    CommandArgument='<%# Eval("ProductID") %>' 
                                                                    ToolTip="Click để thay đổi thông tin sản phẩm này!" 
                                                                    onclick="btnEdit_Click" />
                                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                                                    OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa sản phẩm này không ?')"
                                                                    CommandArgument='<%# Eval("ProductID") %>' ToolTip="Click để xóa sản phẩm này!"
                                                                    OnClick="btnDelete_Click" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </fieldset>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <fieldset class="step">
                                        <legend>Bạn có muốn lưu lại hóa đơn </legend>
                                        <div style="text-align: left; padding: 20px;">
                                            <asp:Button ID="btnSave" runat="server" Text="Lưu hóa đơn" CssClass="button round blue image-right ic-add text-upper"
                                                OnClick="btnSave_Click" />
                                            <asp:Button ID="btnRefesh" runat="server" Text="Nhập lại" CssClass="button round blue image-right ic-add text-upper" />
                                            <asp:Button ID="Button1" runat="server" Text="Trở lại" CssClass="button round blue image-right ic-add text-upper" />
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                            <div id="navigation" style="display: none;">
                                <ul>
                                    <li class="selected"><a href="#">Thông tin khách hàng<li><a href="#">Thông tin hóa
                                        đơn</a> </li>
                                        <li><a href="#">Chi tiết hóa đơn</a> </li>
                                        <li><a href="#">Hoàn thành</a> </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ============= datetime picker -->

    <script type="text/javascript">
        $(function() {
            $('#ctl00_ContentPlaceHolder1_txtCreateDate').datetimepicker({
	            changeMonth:true, changeYear:true, timeFormat: ""
            });
        });	
    </script>

    <script type="text/javascript">
        $(function() {
            $('#ctl00_ContentPlaceHolder1_txtDeliveryDate').datetimepicker({
	            changeMonth:true, changeYear:true, timeFormat: ""
            });
        });	
    </script>

    <script type="text/javascript">
        $(function () {
            $('#ctl00_ContentPlaceHolder1_txtBirthday').datetimepicker({
                changeMonth: true, changeYear: true, timeFormat: "", dateFormat: "dd/mm/yy"
            });
        });	
    </script>

    

</asp:Content>
