<%@ Page Language="C#" Debug="true" MasterPageFile="~/webapp/template/backend/event.master" AutoEventWireup="true"
    CodeFile="create-event.aspx.cs" Inherits="webapp_page_backend_create_event" Title="FASTAUTOMATICMAIL"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .heartbeat {
            display: none;
            margin: 5px;
            color: blue;
        }
    </style>
    <script language="javascript" type="text/javascript">
        $(function () {
            //setInterval(KeepSessionAlive, 10000);
        });

        function KeepSessionAlive() {
            $.post("/FAMail_Back/webapp/page/backend/KeepSessionAlive.ashx", null, function () {
                //$("#result").append("<p>Session is alive and kicking!<p/>");
                setInterval(function () { beatHeart(5); }, 10000);
            });
        }
        function beatHeart(times) {
            var interval = setInterval(function () {
                $(".heartbeat").fadeIn(500, function () {
                    $(".heartbeat").fadeOut(500);
                });
            }, 1000); // beat every second

            // after n times, let's clear the interval (adding 100ms of safe gap)
            setTimeout(function () { clearInterval(interval); }, (2000 * times) + 500);
        }

    </script>
    <script type="text/javascript">
        function templateChange() {
            var contentId = $('select#<%=drlContent.ClientID%> option:selected').val();
            var Content = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_drlContent");
            var subject = Content.options[Content.selectedIndex].text;
            document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtSubject").value = subject;
            $.ajax({
                type: "POST",
                url: "send-register.aspx/getContentTemplate",
                data: '{contentId: "' + contentId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: templateChangeSuccess,
                failure: function (response) {
                    alert("Không tồn tại mẫu này !");
                }
            });
        }

        function templateChangeSuccess(response) {
            if (response.d != null) {
                CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.setData(response.d);
                var contentId = $('select#<%=drlContent.ClientID%> option:selected').val();
                var hiddenContentID = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_hdfContentID");
                hiddenContentID.value = contentId;
            }
        }
        function signatureChange() {
            var SignId = $('select#<%=drlSign.ClientID%> option:selected').val();
            $.ajax({
                type: "POST",
                url: "send-register.aspx/getSign",
                data: '{SignId: "' + SignId + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: signatureChangeSuccess,
                failure: function (response) {
                    alert("Chữ ký không tồn tại!");
                }
            });
        }
        function signatureChangeSuccess(response) {
            var dataResponse = response.d;
            if (dataResponse != null) {
                var currentData = CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.getData();
                var displayData = currentData + "</br>" + dataResponse;
                CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.setData(displayData);
            }
        }
        function openNewWindow() {
            window.open("CreateContentMail.aspx?Id=0", "_blank",
            "toolbar=yes, scrollbars=yes, resizable=yes,top=100, left=100, width=1000, height=600");
        }
        function insertHello() {
            var firtHello = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtWelcome");
            var lastHello = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtAfterWelcome");
            var customerName = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_rdoCustomerName");
            var Wellcome = firtHello.value + " " + "[khachhang]" + " " + lastHello.value;
            if (customerName.checked == true) {
                Wellcome;
            }
            else {
                Wellcome = firtHello.value + " " + "[email]" + " " + lastHello.value;
                alert(Wellcome);
            }
            var currentData = CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.getData();
            var displayData = Wellcome + "</br>" + currentData;
            CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.setData(displayData);
        }

        function contentUpdate() {
        }
    </script>
    <div class="side-content fr">

        <!--start content 01-->
        <div class="content-module">
            <div class="content-module-heading cf">
                <h3 class="fl">Quản lý sự kiện</h3>
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
                <asp:HiddenField ID="hdfEventId" runat="server" />


                <p>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:Label ID="Label2" runat="server" Text="Tên AutoResponders" Style="font-weight: bolder; text-transform: none; color: Black;"></asp:Label>
                    <asp:TextBox ID="txtAutoName" CssClass="round default-width-input" runat="server"
                        Width="98.5%" ToolTip="Nhập tiêu đề bức thư của bạn"></asp:TextBox>
                </p>
                <p>
                    <label for="full-width-input">Chọn nhóm email gửi kèm</label>
                    <asp:DropDownList ID="drlMailGroup" CssClass="round default-width-dropdown" runat="server">
                    </asp:DropDownList>
                    <em>Tùy chọn này dùng để phân nhóm mail ! (<a href="group-mail.aspx">Thêm nhóm mới</a>)</em>
                </p>

                <p>
                    <label for="another-simple-input">Sử dụng email gửi đi</label>
                    <asp:DropDownList ID="drlMailConfig" CssClass="round default-width-dropdown" runat="server">
                    </asp:DropDownList>
                    <em>Tùy chọn này sẽ quyết định mail gửi đi (<a href="AmazonManage.aspx">Cấu hình mail</a>)</em>
                </p>


                <div class="full-width-editor">

                    <p>
                        <label for="Content">Nội dung</label>
                        <em>Nội dung này sẽ được gửi đến mail của khách hàng khi đăng ký thành công !<br />

                        </em>
                    </p>


                    <!-- start update panel-->
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <p>
                                <label for="simple-input">Trang thông báo đăng ký thành công </label>
                                <asp:TextBox ID="txtResponeUrl" Enabled="false" CssClass="round default-width-input"
                                    runat="server"></asp:TextBox>
                                <em>
                                    <br />
                                    <asp:CheckBox ID="chkDefaultPage" runat="server" Checked="true"
                                        OnCheckedChanged="chkDefaultPage_CheckedChanged" AutoPostBack="True" />
                                    Sử dụng trang mặc định (<a href="event-register-success.aspx" target="_blank">Xem trang mặc định</a>)</em>


                            </p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <!-- end update panel-->

                    <!-- start update panel -->
                    <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>--%>
                    <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
                    <label for="simple-input">Cấu hình danh sách gửi từng phần ! </label>
                    <table>
                        <asp:DataList ID="dlContentSendEvent" runat="server"
                            RepeatColumns="1" Width="48%">
                            <HeaderTemplate>
                                <thead>
                                    <tr>
                                        <th>No.</th>
                                        <th>Nội dung</th>
                                        <th>Thời gian</th>
                                        <th>Thao tác</th>
                                    </tr>
                                </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblNo" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lbtContent" runat="server" Width="200px"></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblHour" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <%--<asp:LinkButton ID="lbtEdit" runat="server" Height="15px" 
                                                                     Width="15px" CssClass="table-actions-button ic-table-edit"></asp:LinkButton>--%>
                                            <asp:LinkButton ID="lbtContentDelete" runat="server" Height="15px"
                                                OnClientClick="return confirmDelete('Nếu tiếp tục dữ liệu sẽ bị xóa khỏi hệ thống ?')"
                                                Width="15px" CssClass="table-actions-button ic-table-delete"
                                                OnClick="lbtContentDelete_Click"></asp:LinkButton>
                                        </td>

                                    </tr>
                                </tbody>

                            </ItemTemplate>
                            <FooterTemplate>
                                <tfoot>
                                    <tr>
                                        <td colspan="5" class="table-footer"></td>
                                    </tr>
                                </tfoot>
                            </FooterTemplate>
                        </asp:DataList>
                    </table>

                    <p>
                        &nbsp;<asp:Panel Visible="false" ID="PanelHourError" runat="server" Style="width: 39%">
                            <div class="error-box round">
                                <asp:Label ID="lblHourError" runat="server" Text=""></asp:Label>
                            </div>
                        </asp:Panel>
                    </p>
                    <p>
                        <asp:HiddenField ID="hdfContentID" runat="server" />
                        <asp:Label ID="Label1" runat="server" Text="Tiêu đề nội dung" Style="font-weight: bolder; text-transform: none; color: Black;"></asp:Label>
                        <asp:TextBox ID="txtSubject" CssClass="round default-width-input" runat="server"
                            Width="98.5%" ToolTip="Nhập tiêu đề bức thư của bạn"></asp:TextBox>
                    </p>
                    <p>
                        <asp:TextBox ID="txtWelcome" CssClass="round default-width-input" Width="15%" runat="server"
                            ToolTip="Nhập lời chào cho bức thư!">Chào</asp:TextBox>
                        <asp:RadioButton ID="rdoCustomerName" Checked="true" GroupName="groupWelcome" runat="server" />Tên
                            khách hàng
                            <asp:RadioButton ID="rdoCustomerEmail" GroupName="groupWelcome" runat="server" />Mail
                            khách hàng
                            <asp:TextBox ID="txtAfterWelcome" CssClass="round default-width-input" Width="35%"
                                runat="server">thân mến !</asp:TextBox>
                        <input type="button" value="Thêm lời chào" onclick="insertHello()" class="round button dark menu-user image-left" />
                    </p>
                    <table>
                        <tr>
                            <td>
                                <label for="simple-input" style="width: auto; font-weight: bolder; text-transform: none">
                                    Chọn nội dung</label>
                            </td>
                            <td>

                                <asp:DropDownList ID="drlContent" CssClass="round default-width-dropdown" runat="server"
                                    AutoPostBack="false" onchange="templateChange()">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <label for="simple-input" style="width: auto; font-weight: bolder; text-transform: none">
                                    Thêm chữ ký</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drlSign" CssClass="round default-width-dropdown" runat="server"
                                    AutoPostBack="false" onchange="signatureChange()">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <table width="1000px">

                        <tr>


                            <td style="width: 330px">
                                <label for="simple-input"
                                    style="width: auto; font-weight: bolder; text-transform: none">
                                    Thời gian gửi nội dung đi (tính theo hệ số giờ)</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHour" runat="server" CssClass="round default-width-input"
                                    Width="35%"></asp:TextBox>
                                <asp:Button ID="btnSaveContent" runat="server"
                                    CssClass="button round blue image-right ic-add text-upper"
                                    OnClick="btnSaveContent_Click" Text="Thêm" />
                            </td>
                        </tr>

                    </table>
                    <p>
                    </p>
                    </p>
                            <!-- end update panel-->

                    <%--<asp:TextBox ID="txtBody" class="ckeditor" Rows="20" Columns="20" style="width:100%" runat="server" TextMode="MultiLine"></asp:TextBox>--%>

                    <p>
                        <asp:TextBox ID="txtBody" class="ckeditor" runat="server" TextMode="MultiLine" Width="900px" AutoPostBack="true"></asp:TextBox>
                        <%--<asp:TextBox ID="txtBody" class="ckeditor" Rows="20" Columns="20" style="width:100%" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
                    </p>


                    <%--                        </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    <p>
                    </p>

                    <div class="stripe-separator">
                        <!--  -->
                    </div>

                    <asp:Button ID="btnSaveEvent" runat="server" Text="Lưu Sự kiện"
                        CssClass="button round blue image-right ic-add text-upper" OnClick="btnSaveContentAndEvent_Click" />

                    <asp:Button ID="btnSave" runat="server" Text="Lưu Nội dung và Sự kiện"
                        CssClass="button round blue image-right ic-add text-upper" OnClick="btnSaveContentAndEvent_Click" Visible="false" />
                    <asp:Button ID="btnCreateNew" runat="server" Text="Tạo mới"
                        CssClass="button round blue image-right ic-refresh text-upper" OnClick="btnCreateNew_Click" />
                    <asp:Button ID="btnGenerate" runat="server" Text="Phát sinh Code HTML"
                        CssClass="round blue ic-right-arrow" OnClick="btnGenerate_Click" />

                </div>

                <div class="stripe-separator">
                    <!--  -->
                </div>

                <div class="full-width-editor">
                    <table>
                        <asp:DataList ID="dlEvent" runat="server"
                            RepeatColumns="1" Width="100%">
                            <HeaderTemplate>
                                <thead>
                                    <tr>
                                        <th>Tiêu đề</th>
                                        <th>Email Gửi</th>
                                        <th>Thời gian bắt đầu</th>
                                        <th>Thời gian kết thúc</th>
                                        <th>Voucher</th>
                                        <th>Thao tác</th>
                                    </tr>
                                </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lbtSubject" runat="server" Width="200px"></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEmailGui" runat="server" Text="ConfigId"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblStartDate" runat="server" Text="StartDate"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEndDate" runat="server" Text="EndDate"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblVoucher" runat="server" Text="Voucher"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lbtEdit" runat="server" Height="15px"
                                                OnClick="lbtEdit_Click" Width="15px"></asp:LinkButton>
                                            <asp:LinkButton ID="lbtDelete" runat="server" Height="15px"
                                                OnClientClick="return confirmDelete('Nếu tiếp tục dữ liệu sẽ bị xóa khỏi hệ thống ?')"
                                                OnClick="lbtDelete_Click" Width="15px"></asp:LinkButton>
                                        </td>

                                    </tr>
                                </tbody>


                            </ItemTemplate>
                            <FooterTemplate>
                                <tfoot>

                                    <tr>

                                        <td colspan="5" class="table-footer"></td>

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
    <div class="heartbeat">&hearts;</div>
    </div>

    <!-- ============= datetime picker -->

    <script type="text/javascript">
        $(function () {
            $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtStartDate').datetimepicker();
            $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtEndDate').datetimepicker();
        });
    </script>


</asp:Content>

