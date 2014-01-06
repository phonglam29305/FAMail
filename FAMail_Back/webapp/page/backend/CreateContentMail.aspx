<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/SendMail.master" AutoEventWireup="true"
 CodeFile="createcontentmail.aspx.cs" Inherits="webapp_page_backend_CreateContentMail" Title="FASTAUTOMATICMAIL"
  ValidateRequest="false"  %>
<%@Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style type="text/css">
        .heartbeat {
            display: none;
            margin: 5px;
            color: blue;
        }
    </style>
      <script type="text/javascript">
          function insertHello() {
              var firtHello = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtWelcome");
              var lastHello = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtAfterWelcome");
              var customerName = document.getElementById("ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_rdoCustomerName");
              var Wellcome = firtHello.value + " " + "[khachhang]" + " " + lastHello.value;
              if (customerName.checked == true) {
                  Wellcome;
              }

              var currentData = CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.getData();
              var displayData = Wellcome + "</br>" + currentData;
              CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.setData(displayData);
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
              var currentData = CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.getData();
              var displayData = currentData + "</br>" + dataResponse;
              CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtBody.setData(displayData);
          }
        </script>
    <script language="javascript" type="text/javascript">
        $(function () {
            setInterval(KeepSessionAlive, 10000);
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
            }, 1000);
            setTimeout(function () { clearInterval(interval); }, (2000 * times) + 500);
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                      <ContentTemplate>
<div class="side-content fr">
  <div class="content-module">
		        <div class="content-module-heading cf">				
				    <h3 class="fl">Soạn thư</h3>
				    <span class="fr expand-collapse-text">Thu vào</span>
				    <span class="fr expand-collapse-text initial-expand">Mở ra</span>
    			
			    </div> <!-- end content-module-heading -->
			    
			    <div class="content-module-main">
		          <asp:Panel Visible="false" ID="pnError" runat="server">
                    <div class="error-box round">
                        <asp:Label ID="lblError"  runat="server" Text=""></asp:Label> 
                    </div>
                  </asp:Panel>
                  <asp:Panel Visible="false" ID="pnSuccess" runat="server">
                    <div class="confirmation-box round">
                        <asp:Label ID="lblSuccess"  runat="server" Text=""></asp:Label> 
                    </div>
                  </asp:Panel>
			      <div class="content-module-main cf">
                 
			         <p>

        				<asp:HiddenField ID="hdfContentId" runat="server" />
        				
				        <asp:Label ID="Label1" runat="server" Text="Tiêu đề "></asp:Label> 
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        <asp:TextBox ID="txtSubject" CssClass="round default-width-input" runat="server" 
                             Width="98.5%" ToolTip="Nhập tiêu đề bức thư của bạn"></asp:TextBox>
                         <br>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                    ControlToValidate="txtSubject" Display="Dynamic" ErrorMessage="Vui lòng nhập vào tiêu đề !" 
                                                                    ValidationGroup="Check_Input_Insert"></asp:RequiredFieldValidator>
			        </p>			        
			         
			       <p>
			            <asp:Label ID="Label2" runat="server" Text="Nội dung"></asp:Label> &nbsp;&nbsp;&nbsp; 
                        <em><div class="information-box round">Để đưa tên khách hàng vào nội dung bạn vui lòng nhập [khachhang] hệ thống sẽ tự động thay vào<br />
                            VD:Khách hàng là: Nguyễn Văn A khi bạn điền:  Chào, [khachhang] chúc mừng bạn...=> Chào, Nguyễn Văn A chúc mừng bạn...<br />
                            Lưu ý: nếu khách hàng chưa cung cấp thông tin họ tên, hệ thống sẽ thay đổi bằng địa chỉ email.
                            </div>
                        </em>
                    </p>
                      
                    <p>
                        <asp:TextBox ID="txtWelcome" CssClass="round default-width-input" Width="15%" runat="server" ToolTip="Nhập lời chào cho bức thư!">Chào</asp:TextBox>
                        <asp:RadioButton ID="rdoCustomerName" Checked="true" GroupName="groupWelcome" runat="server" />Tên khách hàng
                        <asp:RadioButton ID="rdoCustomerEmail" GroupName="groupWelcome" runat="server" />Mail khách hàng
                        <asp:TextBox ID="txtAfterWelcome" CssClass="round default-width-input" Width="35%" runat="server">thân mến !</asp:TextBox>
                       <%-- <asp:LinkButton ID="lbtAddWelcome" 
                            class="round button dark menu-user image-left" runat="server" 
                            onclick="lbtAddWelcome_Click" ToolTip="Click thêm lời chào vào nội dung">Thêm lời chào</asp:LinkButton>                             --%>

                          <input type="button" value="Thêm lời chào" onclick="insertHello()" class="round button dark menu-user image-left"/ >
                    </p>
                  
                    <p>
                           <table ID="No_can_desc_tbl" style="margin-right: 0px" width="100%">
                                        <tr>
                                            <td>
                        <CKEditor:CKEditorControl ID="txtBody" runat="server" CausesValidation="True" ResizeEnabled="False"></CKEditor:CKEditorControl>
                                                    <br>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                    ControlToValidate="txtBody" Display="Dynamic" ErrorMessage="Vui lòng nhập vào nội dung !" 
                                                                    ValidationGroup="Check_Input_Insert"></asp:RequiredFieldValidator>
			              <%--  <asp:TextBox ID="txtBody" CssClass="ckeditor" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
                            <%--<asp:TextBox ID="txtBody" rows="15" style="width: 100%" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
                        </td>
                                            </tr>
                               </table>
                    </p>     
                          
                       <p>  
                     <td>
                                    <label for="simple-input" style="width: auto; font-weight: bolder; text-transform: none">
                                        Thêm chữ ký</label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drlSign" CssClass="round default-width-dropdown" runat="server"
                                        AutoPostBack="false" onchange="signatureChange()">
                                    </asp:DropDownList>
                                </td>
                      <br>
                           </p>
                    <p>					
                        <asp:Button ID="btnSaveContent" runat="server" ValidationGroup="Check_Input_Insert" Text="Lưu" 
                            CssClass="button round blue image-right ic-add text-upper" 
                          onclick="btnSaveContent_Click"/>	
                            <asp:Button ID="btnRefesh" runat="server" Text="Làm mới" 
                            CssClass="button round blue image-right ic-refresh text-upper" 
                          onclick="btnRefesh_Click"/>                   

                            <%--<input id="btnCheck" type="button" value="Đánh giá nội dung" class="round blue ic-right-arrow"
                            onclick = "ShowCurrentTime()" />  --%>                  

                            <asp:Button ID="btnPreview" runat="server" Text="Kiểm tra HTML" 
                            CssClass="round blue ic-right-arrow" 
                            ToolTip="Xem với các trình duyệt Email: Gmail, Yahoo, Hotmail.." 
                            onclick="btnPreview_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Hủy" 
                            CssClass="round blue ic-right-arrow" onclick="btnCancel_Click" 
                          PostBackUrl="~/webapp/page/backend/list-content-mail.aspx"/>	
                           
                       
                    </p>
                    <div class="stripe-separator"><!--  --></div> 
			      </div>
	        </div>
    </div> 
    <div class="heartbeat">&hearts;</div>   		     	      
 </div>	  
           </ContentTemplate>
          </asp:UpdatePanel>

</asp:Content>

