<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/SendMail.master"
    CodeFile="sendVIP.aspx.cs" Inherits="webapp_page_backend_sendVIP"
    Title="FASTAUTOMATICMAIL" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="side-content fr">
        <!--start content 01-->
        <div class="content-module">
            <div class="content-module-heading cf">
                <h3 class="fl">
                    Thiết lập thời gian gửi</h3>
                <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">
                    Mở ra</span>
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
                    <div class="half-size-column fl" style="height: auto">
                        <fieldset>
                            <p>
                                <label for="simple-input" style="font-weight: bolder; text-transform: none">
                                    Mail sử dụng gửi đi</label>
                                <asp:DropDownList ID="drlMailConfig" CssClass="round default-width-dropdown" runat="server">
                                </asp:DropDownList>
                                <em>Email người gửi thư.</em>
                            </p>
                            <p>
                            </p>
                        </fieldset>
                    </div>
                    <!-- end half-size-column -->
                    <div class="half-size-column fr" style="height: auto">
                        <fieldset>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                   <p>
                                <label for="full-width-input" style="font-weight: bolder; text-transform: none">
                                    Nhóm người nhận</label>
                                <asp:DropDownList ID="drlMailGroup" CssClass="round default-width-dropdown" runat="server"
                                    AutoPostBack="True" OnSelectedIndexChanged="drlMailGroup_SelectedIndexChanged">
                                </asp:DropDownList>
                            </p>
                            <p>
                                <em>
                                    <asp:Label ID="lblCountCustomer" runat="server" Text=""></asp:Label></em>
                            </p>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            <p>
                            </p>
                            <%-- <p>
                                        <label for="simple-input">
                                            Gửi từng phần </label>
                                         <label for="selected-checkbox" class="alt-label">
                                         <asp:CheckBox ID="chkPartSend" runat="server" /> Chấp nhận</label>                                          
                                        <em>Tùy chọn này sẽ chấp nhận đây là chiến dịch gửi mail từng phần !</em>
                                        <em>Nhóm mail đã chọn có 
                                            <asp:HyperLink ID="hplCountPartSend" runat="server" Target="_blank"></asp:HyperLink>
                                             được gửi đi !</em>
                                        <em>Bạn có thể 
                                            <asp:LinkButton ID="lbtResetPartSend" 
                                            OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ hủy bỏ chiến dịch gửi mail từng phần với nhóm mail này không  ?')"  
                                            runat="server" onclick="lbtResetPartSend_Click"> reset </asp:LinkButton> chiến dịch gửi từng phần với nhóm này</em>
                                    </p>--%>
                        </fieldset>
                    </div>
                    <table style="border: 0px">
                        <tr>
                            <td style="font-weight: bolder;">
                                Thời gian gửi
                            </td>
                            <td style="text-align: left;">
                                <asp:CheckBox ID="chkNow" runat="server" onclick="checkChange()"  />
                                Gửi bây giờ
                            </td>
                            <td style="text-align: left;">
                                <asp:CheckBox ID="chkSet" runat="server" onclick="checkChange2()" 
                                    Checked="True" />
                                Gửi hẹn giờ
                            </td>
                            <td style="text-align: left; width: 480px;">
                                <asp:TextBox ID="txtStartDate" CssClass="round default-width-input" runat="server"
                                    BackColor="#CCFFFF" ></asp:TextBox>
                                <%-- <em>Thiết lập thời gian bắt đầu gửi. Định dạng ( MM/dd/yyyy hh:mm )</em>--%>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- end content-module-main -->
            </div>
            <div class="content-module">
                <div class="content-module-heading cf">
                    <h3 class="fl">
                        Cấu hình nội dung</h3>
                    <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">
                        Mở ra</span>
                </div>
                <div class="content-module-main">
                    <div class="content-module-main cf">
                        <p>
                            <asp:HiddenField ID="hdfContentID" runat="server" />
                            <asp:Label ID="Label1" runat="server" Text="Tiêu đề " Style="font-weight: bolder;
                                text-transform: none; color: Black;"></asp:Label>
                            <asp:TextBox ID="txtSubject" CssClass="round default-width-input" runat="server"
                                Width="98.5%" ToolTip="Nhập tiêu đề bức thư của bạn"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="Label2" runat="server" Text="Nội dung" Style="font-weight: bolder;
                                text-transform: none; color: Black;"></asp:Label>
                            <%--         <em>
                                        <div class="information-box round">
                                            Để đưa tên khách hàng vào nội dung bạn vui lòng nhập [khachhang] hệ thống sẽ tự
                                            động thay vào<br />
                                            VD:Khách hàng là: Nguyễn Văn A khi bạn điền: Chào, [khachhang] chúc mừng bạn...=>
                                            Chào, Nguyễn Văn A chúc mừng bạn...<br />
                                            Lưu ý: nếu khách hàng chưa cung cấp thông tin họ tên, hệ thống sẽ thay đổi bằng
                                            địa chỉ email.
                                        </div>
                                    </em>--%>
                        </p>
                        <p>
                            <asp:TextBox ID="txtWelcome" CssClass="round default-width-input" Width="15%" runat="server"
                                ToolTip="Nhập lời chào cho bức thư!">Chào</asp:TextBox>
                            <asp:RadioButton ID="rdoCustomerName" Checked="true" GroupName="groupWelcome" runat="server" />Tên
                            khách hàng
                            <asp:RadioButton ID="rdoCustomerEmail" GroupName="groupWelcome" runat="server" />Mail
                            khách hàng
                            <asp:TextBox ID="txtAfterWelcome" CssClass="round default-width-input" Width="40%"
                                runat="server">thân mến !</asp:TextBox>
                            <%--<asp:LinkButton ID="lbtAddWelcome" class="round button dark menu-user image-left"
                                runat="server" ToolTip="Click thêm lời chào vào nội dung"  OnClientClick="insertHello()">Thêm lời chào</asp:LinkButton>--%>
                                <input type="button" value="Thêm lời chào" onclick="insertHello()" class="round button dark menu-user image-left"/ >
                        </p>
                        <table>
                            <tr>
                                <td>
                                    <label for="simple-input" style="width: auto; font-weight: bolder; text-transform: none">
                                        Chọn mẫu</label>
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
                        <p>
                            <asp:TextBox ID="txtBody" CssClass="ckeditor" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <%--<asp:TextBox ID="txtBody" rows="15" style="width: 100%" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
                        </p>
                        <fieldset style="width: 100%; margin: 20px 20px 20px 0px;">
                            <asp:Button ID="btnSave" runat="server" Text="Gửi thư" CssClass="round blue ic-right-arrow"
                                OnClick="btnSave_Click" />
                            <asp:Button ID="btnSendNow" runat="server" Text="Gửi bây giờ" CssClass="round blue ic-right-arrow"
                                OnClick="btnSendNow_Click" Visible="False" />
                            <asp:Button ID="btnRefesh" runat="server" Text="Thiết lập lại" CssClass="round blue ic-right-arrow"
                                />
                            <%--<input id="btnCheck" type="button" value="Đánh giá nội dung" class="round blue ic-right-arrow"
                                                        onclick = "ShowCurrentTime()" />  --%>
                            <asp:Button ID="btnPreview" runat="server" Text="Xem với các trình duyệt mail" CssClass="round blue ic-right-arrow"
                                ToolTip="Xem với các trình duyệt Email: Gmail, Yahoo, Hotmail.." />
                            <asp:Button ID="btnClose" runat="server" Text="Đóng" CssClass="round blue ic-right-arrow"
                                OnClick="btnClose_Click" />
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        function checkChange() {

            var startDate = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtStartDate");
            var sendNow = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_chkNow");
            var sendWithTime = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_chkSet");
            if (sendNow.checked == true) {
                sendWithTime.checked = false;
                startDate.style.visibility = "hidden";
            } else {
                 sendWithTime.checked = true;
                startDate.style.visibility = "visible";
            }

        }
        function checkChange2() {

            var startDate = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtStartDate");
            var sendNow = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_chkNow");
            var sendWithTime = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_chkSet");

            if (sendWithTime.checked == true) {
                sendNow.checked = false;
                startDate.style.visibility = "visible";
            }
            else {
                sendNow.checked = true;
                startDate.style.visibility = "hidden";
            }
        }
        function templateChange() {

            //var editor_data = CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.getData();
            //var a = "<h1>Hung</h1>";
            //CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.setData(a);

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
                failure: function(response) {
                    alert("Không tồn tại mẫu này !");
                }
            });
        }
        
        function templateChangeSuccess(response) {

            CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.setData(response.d);
            var contentId = $('select#<%=drlContent.ClientID%> option:selected').val();
            var hiddenContentID = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_hdfContentID");
            hiddenContentID.value = contentId;
            
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
                failure: function(response) {
                    alert("Chữ ký không tồn tại!");
                }
            });
        }
        function signatureChangeSuccess(response) {
            var dataResponse = response.d;
            var currentData = CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.getData();
           
            var displayData = currentData +  "</br>" + dataResponse;
   
            CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.setData(displayData);
        }
         function insertHello()
        {
            var firtHello = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtWelcome");
            var lastHello= document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtAfterWelcome");
            var customerName= document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_rdoCustomerName");
            var Wellcome = firtHello.value + " " + "[khachhang]" + " " + lastHello.value;
            if(customerName.checked== true)
            {
               Wellcome;
            }
            else
            {
                Wellcome= firtHello.text +" "+"[email]"+ " "+ lastHello;
                alert(Wellcome);
            }
            var currentData = CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.getData();
            var displayData = Wellcome +  "</br>" + currentData;
            CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.setData(displayData);
        }
    </script>

</asp:Content>
