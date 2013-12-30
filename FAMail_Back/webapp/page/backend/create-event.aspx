<%@ Page Language="C#" Debug="true" MasterPageFile="~/webapp/template/backend/event.master" AutoEventWireup="true" 
CodeFile="create-event.aspx.cs" Inherits="webapp_page_backend_create_event" Title="FASTAUTOMATICMAIL" 
ValidateRequest="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function templateChange() {

        var contentId = $('select#<%=drlContent.ClientID%> option:selected').val();
        
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
 
        CKEDITOR.instances.ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtContent.setData(response.d);
    }
    function openNewWindow() {
        window.open("CreateContentMail.aspx?Id=0", "_blank",
        "toolbar=yes, scrollbars=yes, resizable=yes,top=100, left=100, width=1000, height=600");
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
								    <label for="simple-input">Tiêu đề mail</label>    								
                                    <asp:TextBox ID="txtSubject" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
                                    <em>Tiêu đề mail gửi đến khách hàng</em>
							    </p>
    							
						        <p>
								    <label for="full-width-input">Phân loại khách hàng</label>
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
						    </fieldset>	
    				
				    </div> <!-- end half-size-column -->
				    <div class="half-size-column fr">
				        <fieldset>
				            <p>
							    <label for="simple-input">Voucher</label>								
                                <asp:TextBox ID="txtVoucher" CssClass="round default-width-input" 
                                    runat="server"></asp:TextBox>
                                <em>Mã voucher khi khách hàng đăng ký sự kiện này !</em>
						    </p>						
							
						    <p>
							    <label for="simple-input">Thời gian bắt đầu</label>								
                                <asp:TextBox ID="txtStartDate"  CssClass="round default-width-input" 
                                    runat="server"></asp:TextBox>
                                <em>Thời gian bắt đầu sự kiện này. Định dạng ( MM/dd/yyyy hh:mm )</em>
						    </p>	
							
						    <p>
							    <label for="simple-input">Thời gian kết thúc</label>								
                                <asp:TextBox ID="txtEndDate" CssClass="round default-width-input" 
                                    runat="server"></asp:TextBox>
                                <em>Thời gian kết thúc sự kiện này. Định dạng ( MM/dd/yyyy hh:mm )</em>
						    </p>	
                            <p>							    							
                                <asp:CheckBox ID="chkRequireTime" runat="server" />Áp dụng thời gian trên cho sự kiện này !                             
						    </p>	
						
				        </fieldset>				             
				    </div>
				   
				    <div class="full-width-editor" style="margin-top: 350px;">		
				         	        
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
                                <em><br />
                                <asp:CheckBox ID="chkDefaultPage" runat="server" Checked="true" 
                                    oncheckedchanged="chkDefaultPage_CheckedChanged" AutoPostBack="True" />
                                     Sử dụng trang mặc định (<a href="event-register-success.aspx" target="_blank">Xem trang mặc định</a>)</em>
                                     
                             
				            </p>				            
				            </ContentTemplate>
                            </asp:UpdatePanel>
                            <!-- end update panel-->
                            
                            <!-- start update panel -->
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                              <ContentTemplate> 
                              
                             <p>			
                                <asp:Label ID="lbl"  runat="server" Text=""></asp:Label>	            
                                <label for="simple-input">Cấu hình danh sách gửi từng phần ! </label>
                                <table>	                
				                    <asp:DataList ID="dlContentSendEvent" runat="server" 
                                         RepeatColumns="1"  Width="48%">  
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
                                                                    onclick="lbtContentDelete_Click"></asp:LinkButton>
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
                             </p>
                             
                            <p>
                                 &nbsp;<asp:Panel Visible="false" ID="PanelHourError" runat="server" style="width:39%">
                                    <div class="error-box round">
                                        <asp:Label ID="lblHourError"  runat="server" Text=""></asp:Label> 
                                    </div>
                                 </asp:Panel>
                                 <p>
                                 </p>
                                 <table width="1000px">
                                     <tr>
                                         <td>
                                             <label for="simple-input" 
                                                 style="width: auto; font-weight: bolder; text-transform: none">
                                             Chọn mẫu</label>
                                         </td>
                                         <td style="width: 197px">
                                             <asp:DropDownList ID="drlContent" runat="server" 
                                                 CssClass="round default-width-dropdown" onchange="templateChange()"  Height="27px" Width="200px">
                                             </asp:DropDownList>
                                         </td>
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
                                                 onclick="btnSaveContent_Click" Text="Thêm"  />
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                         </td>
                                         <td style="width: 197px">

                                             <asp:LinkButton ID="lbtContentRefresh" runat="server" 
                                                 onclick="lbtContentRefresh_Click">Làm mới danh sách</asp:LinkButton>
                                         </td>
                                         <td style="width: 330px">
                                         </td>
                                         <td>
                                             <asp:LinkButton ID="lbtAddNewContent" runat="server" OnClientClick="openNewWindow()">
                                             Thêm mới nội dung</asp:LinkButton>
                                         </td>
                                     </tr>
                                 </table>
                                 <p>
                                 </p>
                            </p>
                            
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            <!-- end update panel-->
                            
                       <%--<asp:TextBox ID="txtContent" class="ckeditor" Rows="20" Columns="20" style="width:100%" runat="server" TextMode="MultiLine"></asp:TextBox>--%>  
                            
                        <p>					            
                            <asp:TextBox ID="txtContent" class="ckeditor" runat="server" TextMode="MultiLine" Width="900px"></asp:TextBox>
                            <%--<asp:TextBox ID="txtContent" class="ckeditor" Rows="20" Columns="20" style="width:100%" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
			            </p>
			            
			            <p>			                                                
                                                  
                                 
			                </p>
				            
				            <div class="stripe-separator"><!--  --></div>    	
        							
                            <asp:Button ID="btnSaveEvent" runat="server" Text="Lưu sự kiện" 
                                CssClass="button round blue image-right ic-add text-upper" onclick="btnSaveEvent_Click" />	
                            <asp:Button ID="btnCreateNew" runat="server" Text="Tạo mới" 
                                CssClass="button round blue image-right ic-refresh text-upper" onclick="btnCreateNew_Click"/>
                            <asp:Button ID="btnGenerate" runat="server" Text="Phát sinh Code HTML" 
                                CssClass="round blue ic-right-arrow" onclick="btnGenerate_Click"/>       
				        
				    </div> 
				    
				  <div class="stripe-separator"><!--  --></div>  
				   
				  <div class="full-width-editor">
				   <table>	                
				    <asp:DataList ID="dlEvent" runat="server" 
                         RepeatColumns="1"  Width="100%">  
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
                                                    onclick="lbtEdit_Click" Width="15px"></asp:LinkButton>
								                <asp:LinkButton ID="lbtDelete" runat="server" Height="15px" 
								                OnClientClick="return confirmDelete('Nếu tiếp tục dữ liệu sẽ bị xóa khỏi hệ thống ?')"
                                                   onclick="lbtDelete_Click" Width="15px"></asp:LinkButton>
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
				
			</div> <!-- end content-module-main -->
			</div>			
		</div>
		<!--end content 01-->
 </div>
 
<!-- ============= datetime picker -->

<script type="text/javascript">	
	$(function(){
		 $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtStartDate').datetimepicker();	
		 $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtEndDate').datetimepicker();			 		
	});	
</script> 

	
</asp:Content>

