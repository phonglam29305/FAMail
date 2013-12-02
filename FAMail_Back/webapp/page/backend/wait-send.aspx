<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/SendMail.master" AutoEventWireup="true" 
CodeFile="wait-send.aspx.cs" Inherits="webapp_page_backend_wait_send" Title="FASTAUTOMATICMAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- start update panel-->
<div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>  
</div>
<div class="side-content fr">
        <div class="content-module">
		        <div class="content-module-heading cf">				
				    <h3 class="fl">Danh sách thư chờ gửi</h3>
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
                 
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
              <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="3000" Enabled="True">
              </asp:Timer>
              <table>
              <asp:DataList ID="dlWaitSend" runat="server">
                 <HeaderTemplate>

                  <thead>
                    <tr style="font-size: 0.8em;">
			            <th>
                            <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" oncheckedchanged="chkAll_CheckedChanged" />                        
                        </th>
			            <th>Tiêu đề</th>
			            <th>Mail gửi đi</th>
                        <th>Gửi cho nhóm</th>
			            <th>Thời gian bắt đầu</th>
                        <th>Thời gian kết thúc</th>
			            <th>Trạng thái</th>
                        <th>Thao tác</th>
		            </tr>	
	                </thead>
                	  <tbody>
                    </HeaderTemplate>
                <ItemTemplate>

               
    	           <tr>
        			 <td style="width:10px;">
                         <asp:CheckBox ID="chkCheck" runat="server" />
                         <asp:HiddenField ID="hdfId" runat="server" />
			         </td>
			         <td><asp:Label ID="lblSubject" runat="server"  Text="" ></asp:Label></td>
			         <td><asp:Label ID="lblMailConfig" runat="server"  Text="" ></asp:Label></td>
                     <td><asp:Label ID="lblGroupTo" runat="server"  Text="" ></asp:Label></td>
			         <td><asp:Label ID="lblStartDate" runat="server"  Text="" ></asp:Label></td>
                     <td><asp:Label ID="lblEndDate" runat="server"  Text="" ></asp:Label></td>
			         <td> 
                         <asp:Panel ID="Panel1" runat="server" style="width:130px;border: 1px solid rgb(221, 213, 213)">
                            <div >
                               <asp:TextBox ID="progressbar" runat="server" Text="" style="max-width:112px;height:15px" ReadOnly="True" ForeColor="#FF0066"></asp:TextBox> 
                            </div>    
                         </asp:Panel>                                            
                                                
                         <asp:LinkButton ID="lbtDetail" runat="server"></asp:LinkButton>
			         </td>
                     <td> 
                         <asp:LinkButton ID="lbtDelete" Height="15px" 
                          CssClass="table-actions-button ic-table-delete" 
                          OnClientClick="return confirmDelete('Bạn có chắc xóa thời gian này không ?')"
                          runat="server" onclick="lbtDelete_Click"></asp:LinkButton></td>
		           </tr>
	           
                </ItemTemplate>
                <FooterTemplate> 
                  </tbody>  
                    <tfoot>
                        <tr>
                            <td colspan="8" class="table-footer" style=" padding: 30px;">
                                <label for="table-select-actions" style="font-weight: bolder; ">
                                Lựa chọn:</label>
                                <asp:DropDownList ID="drlType" runat="server" Height="27px" Width="100px">
                                    <asp:ListItem Value="1">Xóa</asp:ListItem>
                                    <asp:ListItem Value="2">Xuất ra Excel</asp:ListItem>
                                    <asp:ListItem Value="3">In</asp:ListItem>
                                </asp:DropDownList>
                                <asp:LinkButton ID="lbtExecute" runat="server" 
                                    CssClass="round button blue text-upper small-button"
                                    OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ thực hiện chức năng này không ?')"
                                    onclick="lbtExecute_Click">Thực 
                                hiện</asp:LinkButton>
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </td>
                           
                        </tr>
                    </tfoot>	   
                </FooterTemplate>
                </asp:DataList>
            </table>
     </ContentTemplate>
</asp:UpdatePanel>       
           
               </div> <!-- end content-module-main -->					
		   </div>
		</div>	

<!-- end update panel-->
</asp:Content>


