<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/event.master" AutoEventWireup="true" 
CodeFile="event-report.aspx.cs" Inherits="webapp_page_backend_Mail_Sended" Title="FASTAUTOMATICMAIL " ValidateRequest="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    <asp:Repeater ID="rptGroup" runat="server">
        <ItemTemplate>      
	     
        <div class="side-content fr"> 
            
        <div class="content-module">
		        <div class="content-module-heading cf">				
				    <h3 class="fl"> 
                        <asp:Label ID="lblGroupName" runat="server" Text="" Font-Size="11"></asp:Label></h3>
				    <span class="fr expand-collapse-text">Thu vào</span>
				    <span class="fr expand-collapse-text initial-expand">Mở ra</span>			
			    </div> <!-- end content-module-heading -->			
    	           
                
             <div class="content-module-main">        
           
              <table>
              <asp:DataList ID="dlEventRegister" runat="server">
                 <HeaderTemplate>

                     <tbody>
                         <tr>
                             <th style="width:50px;">
                                 <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="false" 
                                     />
                              </th>
                             <th>
                                 Email
                             </th>
                                 
                             <th>Họ tên</th>
                             <th>
                                Địa chỉ
                             </th>
                             <th>
                                Ngày đăng ký
                             </th>
                            <th>
                                Nhóm
                             </th>
                             <th>
                                Sự kiện
                             </th>
                         </tr>
                     </tbody>
                	
                    </HeaderTemplate>
                <ItemTemplate>

                 <tbody>
    	           <tr>
        			 <td style="width:50px;">
			           <asp:CheckBox ID="chkXoa" runat="server" />
                         <asp:HiddenField ID="hdfId" Value="" runat="server" />
			         </td>
			         <td>
			            <asp:Label ID="lblEmail" runat="server"  Text="" ></asp:Label>
			         </td>
			         <td>
			            <asp:Label ID="lblName" runat="server"  Text="" ></asp:Label>
			         </td>
			         <td>
			            <asp:Label ID="lblAddress" runat="server"  Text="" ></asp:Label>
			         </td>
			         <td> 
                        <asp:Label ID="lblCreateDate" runat="server"  Text="" ></asp:Label>
			         </td>
			         <td> 
                        <asp:Label ID="lblGroupName" runat="server"  Text="" ></asp:Label>
			         </td>
			         <td> 
                        <asp:Label ID="lblEvent" runat="server"  Text="" ></asp:Label>
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
           
             </div> <!-- end content-module-main -->					
		 </div>
		</div>
		
	  </ItemTemplate>
    </asp:Repeater>

</asp:Content>

