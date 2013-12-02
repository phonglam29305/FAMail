<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/backend.master" AutoEventWireup="true"
CodeFile="send-mail.aspx.cs" Inherits="webapp_page_backend_send_mail" Title="FASTAUTOMATICMAIL"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<%--<div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>  
</div>--%>   
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
         <!-- MAIN CONTENT -->
	<div id="content">
	  <div class="page-full-width cf">
	<div class="side-menu fl">				
				<h3>Gửi thư</h3>				    
				    <ul>
					    <li><a href="CreateContentMail.aspx?Id=0">Tạo nội dung</a></li>
					    <li><a href="list-content-mail.aspx">Danh sách nội dung</a></li>
					    <li><a href="send-register.aspx">Đăng ký gửi</a></li>
                        <li><a href="wait-send.aspx">Danh sách chờ gửi</a></li>    										
				    </ul>		
	 </div> <!-- end side-menu -->
			
	  <div class="side-content fr">
				         
	  <!--start content 01-->
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
				
				    <div class="half-size-column fl">					
					    <fieldset>    	
                                <asp:HiddenField ID="hdfEventId" runat="server" />	
                                <p>
								    <label for="simple-input">Người gửi</label>    								
                                      <asp:DropDownList ID="drlMailConfig" CssClass="round default-width-dropdown" runat="server">
                                    </asp:DropDownList>
                                    <em>Email người gửi thư.</em>
							    </p>	
							        <p>
								    <label for="simple-input">Người nhận</label>    								
                                    <asp:TextBox ID="TextBox2" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
                                    <em>Người nhận thư, bạn có thể nhập trực tiếp hoặc chon nhóm người nhận</em>
							    </p>			
    						    <p>
								    <label for="simple-input">Tiêu đề</label>    								
                                    <asp:TextBox ID="txtSubject" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
                                    <em>Nhập tiêu đè bức thư. ví dụ: Khuyến mãi cuối năm...</em>
							    </p>
    							
						  
							   

							    <%--<p class="form-error">
								    <label for="error-input">Error text input</label>
								    <input type="text" id="error-input" class="round default-width-input error-input"/>
								    <em>This is can be associated with an input.</em>								
							    </p>  --%>  
    							
						    </fieldset>	
    				
				    </div> <!-- end half-size-column -->
				    <div class="half-size-column fr">
				        <fieldset>
				                 <p>
								    <label for="full-width-input">Nhóm người nhận</label>
								    <asp:DropDownList ID="drlMailGroup" CssClass="round default-width-dropdown" runat="server">
                                    </asp:DropDownList>
								    <em>Lựa chón nhóm hoặc người nhận thư</em>								
							    </p>
						
							
						    <p>
							    <label for="simple-input">Thời gian bắt đầu gửi</label>								
                                <asp:TextBox ID="txtStartDate"  CssClass="round default-width-input" 
                                    runat="server"></asp:TextBox>
                                <em>Thiết lập thời gian muốn bắt đàu gửi thư.</em>
						    </p>	
							
						    <p>
							    <label for="simple-input">Thời gian kết thúc gửi</label>								
                                <asp:TextBox ID="txtEndDate" CssClass="round default-width-input" 
                                    runat="server"></asp:TextBox>
                                <em>Thời gian kết thúc gửi thư.</em>
						    </p>	
						
				        </fieldset>				             
				    </div>
				   
				    <div class="full-width-editor" style="margin-top: 350px;">		
				          <fieldset>		        
				            <p>
					            <label for="Content">Nôi dung</label>
					            <%--<textarea id="textarea1" class="ckeditor"></textarea><br />--%>
                                <asp:TextBox ID="txtContent" class="ckeditor" runat="server" TextMode="MultiLine"></asp:TextBox>
				            </p>
				            <div class="stripe-separator"><!--  --></div>    	
        							
                            <asp:Button ID="btnSaveEvent" runat="server" Text="Gửi" 
                                CssClass="round blue ic-right-arrow"  />	
                            <asp:Button ID="btnCreateNew" runat="server" Text="Thiết lập lại" 
                                CssClass="round blue ic-right-arrow" />
                            <asp:Button ID="btnGenerate" runat="server" Text="Đóng" 
                                CssClass="round blue ic-right-arrow" /> 
                                 
				        </fieldset>	
				    </div> 
				    
				  <div class="stripe-separator"><!--  --></div>  
				   
				  <div class="full-width-editor">
				   
				  </div>
				
			</div> <!-- end content-module-main -->
			</div>			
		</div>
		<!--end content 01-->
		
		<!--start content 02-->
		<div class="content-module">			
				
			
			</div> <!-- end content-module -->
		<!--end content 02-->
		
	  </div>
	</div> <!-- end content -->	
	
    <%--</ContentTemplate>
</asp:UpdatePanel>--%>                    
   
    
<!-- ============= datetime picker -->
<script type="text/javascript" src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
<script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.min.js"></script>
<script type="text/javascript" src="../../resource/other/datetimepicker/jquery/jquery-ui-timepicker-addon.js"></script>
<script type="text/javascript" src="../../resource/other/datetimepicker/jquery/jquery-ui-sliderAccess.js"></script>

<script type="text/javascript">
    $(function() {
        $('#ctl00_ContentPlaceHolder1_txtStartDate').datetimepicker();
        $('#ctl00_ContentPlaceHolder1_txtEndDate').datetimepicker();
    });	
</script>   
</asp:Content>

