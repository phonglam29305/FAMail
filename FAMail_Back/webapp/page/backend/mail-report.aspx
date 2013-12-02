<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/report.master" 
AutoEventWireup="true" CodeFile="mail-report.aspx.cs" Inherits="webapp_page_backend_mail_report" Title="FASTAUTOMATICMAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">.
 <div class="side-content fr">
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
        <div class="content-module">
		        <div class="content-module-heading cf">				
				    <h3 class="fl">Danh sách đã gửi</h3>
				    <span class="fr expand-collapse-text">Thu vào</span>
				    <span class="fr expand-collapse-text initial-expand">Mở ra</span>			
			    </div> <!-- end content-module-heading -->			
    	           
                <div class="content-module-main cf">				
				    <div class="half-size-column fl" style="height:auto">					
					    <fieldset>                            
						    <p>
								<label for="full-width-input">Chọn chiến dịch cần xem</label>
								<asp:DropDownList ID="drlCampaign" CssClass="round default-width-dropdown" 
                                    runat="server" onselectedindexchanged="drlCampaign_SelectedIndexChanged" 
                                    AutoPostBack="True">
                                    
                                </asp:DropDownList>								    
							</p>
					
						</fieldset>	
    				
				    </div> <!-- end half-size-column -->
                </div>
         <div class="content-module-main" style="margin-top: -32px;">
            
            
            <!-- start update panel-->
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>  
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
              
                
              <table>
              <asp:DataList ID="dlReport" runat="server">
                 <HeaderTemplate>

                     <tbody>
                         <tr>
                             <th style="width:50px;">                             
                                 <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" oncheckedchanged="chkAll_CheckedChanged" />
                              </th>
                             <th>
                                 Email
                             </th>
                                 
                             <th>Thời gian bắt đầu</th>
                             <th>
                                Thời gian kết thúc
                             </th>
                             <th>
                                Trạng thái
                             </th>
                            
                         </tr>
                     </tbody>
                	
                    </HeaderTemplate>
                <ItemTemplate>

                 <tbody>
    	           <tr>
        			 <td style="width:50px;">
        			 <asp:CheckBox ID="chkXoa" runat="server" />
                         <asp:Label ID="lblNo" runat="server" Text=""></asp:Label>
			         </td>
			         <td><asp:Label ID="lblEmail" runat="server"  Text="" ></asp:Label></td>
			         <td><asp:Label ID="lblStartDate" runat="server"  Text="" ></asp:Label></td>
			         <td><asp:Label ID="lblEndDate" runat="server"  Text="" ></asp:Label></td>
			         <td> 
                        <asp:ImageButton ID="ibtStatus" runat="server" 
                              ImageUrl="~/webapp/resource/images/ok.png"  /> 
			         </td>
		           </tr>
	             </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
  
                           
                        </tr>
                    </tfoot>
        	   
                </FooterTemplate>
                </asp:DataList>
            </table>
              
             </ContentTemplate>
            </asp:UpdatePanel>
            <!-- end update panel-->
  
               </div> <!-- end content-module-main -->					
		   </div>
		</div>	
</asp:Content>

