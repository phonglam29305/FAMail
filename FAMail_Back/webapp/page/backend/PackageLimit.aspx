<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" CodeFile="PackageLimit.aspx.cs" Inherits="webapp_page_backend_PackageLimit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="side-content fr">
				         
	  <!--start content 01-->
		<div class="content-module">
		    <div class="content-module-heading cf">				
				<h3 class="fl">Danh giới hạn mail</h3>
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
								    <label for="full-width-input">Tên gói giới hạn </label>
						         	<asp:TextBox ID="txtnamepackagelimit" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>							
							    </p>	
                          <p>
							    <label for="simple-input">Dưới</label>								
                                <asp:TextBox ID="txtunder" CssClass="round default-width-input"  
                                    runat="server" ></asp:TextBox>
                                
						    </p>	
                             <p>
								    <label for="full-width-input">Giá </label>
						         	<asp:TextBox ID="txtcode" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>							
							    </p>	
                            <p>
                                <label for="full-width-input">Kích hoạt</label>
				            
                                 <asp:CheckBox ID="checkisDefault" runat="server" />
                            </p>
                                     				    					
						 </fieldset>	
    				
				    </div> <!-- end half-size-column -->
				    <div class="half-size-column fr" style="height:auto;">
				       		             
				    </div>
				   
				    <div class="full-width-editor" style="float: left; margin-top: 30px;">     		       
                       <fieldset>
        							
                            <asp:Button ID="btnSave" runat="server" Text="Lưu chức năng" 
                                CssClass="button round blue image-right ic-add text-upper" OnClick="btnSave_Click" 
                                />	
                           <asp:Button ID="btnCreateNew" runat="server" Text="Cập nhật chức năng" 
                                 CssClass="button round blue image-right ic-add text-upper" OnClick="btnCreateNew_Click" 
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
				    <h3 class="fl">Danh giới hạn mail </h3>
				    <span class="fr expand-collapse-text">Thu vào</span>
				    <span class="fr expand-collapse-text initial-expand">Mở ra</span>			
			    </div> <!-- end content-module-heading -->	
				   <%--<table>	                --%>
				  <%--  <table>--%>
                                    <asp:DataList ID="dtfunction" runat="server" RepeatColumns="1" Width="100%" >
                                        <HeaderTemplate>
                                            <thead>
                                                <tr>
                                                    
                                                    <th>  Tên giới hạn gởi mail </th>
                                                    <th>  Đến  </th>
                                                    <th>  Giá </th>
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
                                            <asp:Label ID="lblAttr" runat="server" Text='<%# Eval("namepackagelimit") %>' ></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblunder" runat="server" Text='<%# Eval("under") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblcost" runat="server" Text='<%# Eval("cost") %>'></asp:Label>
                                        </td>                                                                                                                                              
                                          <td>
                                             
                                              <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/webapp/resource/images/edit-validated-icon.png"
                                              CommandArgument='<%# Eval("limitId") %>' OnClick="btnEdit_Click"  />
                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                                    CommandArgument='<%# Eval("limitId") %>'
                                                     OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa thuộc tính này không ?')" OnClick="btnDelete_Click" 
                                                    /> 
                                                 
                                                 
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

