<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" CodeFile="Function.aspx.cs" Inherits="webapp_page_backend_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="side-content fr">
				         
	  <!--start content 01-->
		<div class="content-module">
		    <div class="content-module-heading cf">				
				<h3 class="fl">Quản lý chức năng</h3>
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
				    <div class="half-size-column fl" style="height:auto">	
                        <asp:HiddenField ID="hdfId" runat="server" /> 				
					    <fieldset>  
						        <p>
								    <label for="full-width-input">Tên chức năng </label>
						         	<asp:TextBox ID="txtfunctionName" CssClass="round default-width-input" 
                                        runat="server" OnTextChanged="txtfunctionName_TextChanged"></asp:TextBox>							
							    </p>	
                          <p>
							    <label for="simple-input">Diễn giải</label>								
                                <asp:TextBox ID="txtdiengiai" CssClass="round default-width-input"  Width="92%"  TextMode="MultiLine" 
                                    runat="server" OnTextChanged="txtdiengiai_TextChanged"></asp:TextBox>
                                <em>Giải thích về chức năng gói dịch vụ </em>
						    </p>	
                             <p>
								    <label for="full-width-input">Giá </label>
						         	<asp:TextBox ID="txtcode" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>							
							    </p>	
                             
                                 <label for="full-width-input">Mặc định</label>
				            
                                 <asp:CheckBox ID="checkisDefault" runat="server" />
				        				    					
						 </fieldset>	
    				
				    </div> <!-- end half-size-column -->

				   
				    <div class="full-width-editor" style="float: left; margin-top: 30px;">     		       
                       <fieldset>
        							
                            <asp:Button ID="btnSave" runat="server" Text="Lưu chức năng" 
                                CssClass="button round blue image-right ic-add text-upper" OnClick="btnSave_Click" 
                                />	
                                                        
				        </fieldset>	
				    </div> 
				    
			
		 <!-- end content-module-main -->
			</div>			
		</div>
		
		<!--end content 01-->
	  </div>
	    <div class="content-module">
	    	   
				  <div class="full-width-editor">
				        <div class="content-module-heading cf">				
				    <h3 class="fl">Danh sách chức năng </h3>
				    <span class="fr expand-collapse-text">Thu vào</span>
				    <span class="fr expand-collapse-text initial-expand">Mở ra</span>			
			    </div> <!-- end content-module-heading -->	
				   <%--<table>	                --%>
				  <%--  <table>--%>
                                    <asp:DataList ID="dtfunction" runat="server" RepeatColumns="1" Width="100%" OnSelectedIndexChanged="dtfunction_SelectedIndexChanged">
                                        <HeaderTemplate>
                                            <thead>
                                                <tr>
                                                    
                                                    <th>  Tên chức năng </th>
                                                    <th>  Đơn Giá  </th>
                                                    <th>  Mặc định </th>
                                                     <th> Điều chỉnh </th>
                                                </tr>
                                            </thead>
                                        </HeaderTemplate>
                                        <FooterTemplate>
                                            <tfoot>
                                                <tr>
                                                    <td colspan="5" class="table-footer">
                                                    </td>
                                                </tr>
                                            </tfoot>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                          <tbody>
                                    <tr>
                                      
                                        <td style="text-align: left; padding-left: 10px;">
                                            <asp:Label ID="lblAttr" runat="server" Text='<%# Eval("functionName") %>' ></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGmail" runat="server" Text='<%# Eval("cost") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblYahooMail" runat="server" Text='<%# Eval("isDefault") %>'></asp:Label>
                                        </td>
                                       
                                      
                                      
                                          <td>
                                             
                                              <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/webapp/resource/images/edit-validated-icon.png"
                                              CommandArgument='<%# Eval("functionId") %>' OnClick="btnEdit_Click"  />
                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                                    CommandArgument='<%# Eval("functionId") %>'
                                                     OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa thuộc tính này không ?')" 
                                                     OnClick="btnDelete_Click2" /> 
                                                 
                                                 
                                        </td>
                                    </tr>
                                </tbody>        
                                        </ItemTemplate>
                                    </asp:DataList>
                              <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.\sqlexpress;Initial Catalog=SendMailVersion3;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT [functionId], [functionName], [cost], [diengiai], [isDefault] FROM [tblFunction] ORDER BY [functionId], [functionId], [functionId]"></asp:SqlDataSource>--%>
                                </table>
                  
				  </div>
				
			</div>
	    </div>
</asp:Content>

