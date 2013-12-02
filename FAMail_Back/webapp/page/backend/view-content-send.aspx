<%@ Page Title="DANH SÁCH NỘI DUNG" Language="C#" MasterPageFile="~/webapp/template/backend/SendMail.master" AutoEventWireup="true" 
CodeFile="view-content-send.aspx.cs" Inherits="webapp_page_backend_view_content_send" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="side-content fr">
				         
	  <!--start content 01-->
		<div class="content-module">
		    <div class="content-module-heading cf">				
				<h3 class="fl">Danh sách nội dung mail đã gửi cho nhóm: (<asp:Label ID="lblGroupName" 
                        runat="server" Text="Group name" Font-Size="Large"></asp:Label>)</h3>
				<span class="fr expand-collapse-text">Thu vào</span>
				<span class="fr expand-collapse-text initial-expand">Mở ra</span>			
			</div> <!-- end content-module-heading -->			
	           
            
			<div class="content-module-main">
                <div class="content-module-main cf">
                <asp:DataList ID="dlContentList" runat="server">
                 <ItemTemplate>   
                 <p>
                    <div class="stripe-separator"><!--  --></div> 
                 </p>                 
						<p>
                            <asp:Label ID="lblSubject" runat="server" Text="Label" Font-Bold="True" 
                                Font-Size="X-Large"></asp:Label>
                        </p>
                <p>
                    <div class="stripe-separator"><!--  --></div> 
                </p> 
                        <p>
                            <asp:Label ID="lblContent" runat="server" Text="Label" style="text-align:left"></asp:Label>
                        </p>
                    
                 </ItemTemplate>
                </asp:DataList>
                    
                </div>
            </div>
       </div>
</div>
    
</asp:Content>

