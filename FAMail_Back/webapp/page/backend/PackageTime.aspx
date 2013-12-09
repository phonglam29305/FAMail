<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" CodeFile="PackageTime.aspx.cs" Inherits="webapp_page_backend_PackageTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


     <div class="side-content fr">
				         
	  <!--start content 01-->
		<div class="content-module">
		    <div class="content-module-heading cf">		
                 <asp:HiddenField ID="hdfId" runat="server" /> 			
				<h3 class="fl">Thông tin gói thời gian</h3>
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
				    <div class="half-size-column1 fl" >					
					    <fieldset>  
						        <p>
								    <label for="full-width-input">Thời gian</label>
						         	<asp:TextBox ID="txtthoigian" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox> &nbsp; &nbsp;	Tháng		 						  								    							
							    </p>

							    <p>
								    <label for="full-width-input">Discount</label>
								     <asp:TextBox ID="txtdiscount"  CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox> &nbsp; &nbsp;	%
								    							
							    </p>
                            		
						 </fieldset>	
    				
				    </div> <!-- end half-size-column -->
				     
				    <div class="full-width-editor" style="float: left; margin-top: 0px; height: 58px;">  
				          
				         <br />
                       <fieldset>
        							
                            <asp:Button ID="btnSave" runat="server" Text="Lưu thông tin" 
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
				    <h3 class="fl">Danh sách gói thời gian </h3>
				    <span class="fr expand-collapse-text">Thu vào</span>
				    <span class="fr expand-collapse-text initial-expand">Mở ra</span>			
			    </div> <!-- end content-module-heading -->	               
				<%--    <table>--%>
                                    <asp:DataList ID="dtfunction" runat="server" RepeatColumns="1" Width="100%">
                                        <HeaderTemplate>
                                            <thead>
                                                <tr>
                                                   
                                                    <th>  Thời gian  </th>
                                                    <th>  Discount </th>
                                                     <th> Ðiều chỉnh </th>
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
                                            <asp:Label ID="lblAttr" runat="server" Text='<%# Eval("monthCount") %>' ></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGmail" runat="server" Text='<%# Eval("discount") %>'></asp:Label>
                                        </td>
                                     
                                       
                                      
                                      
                                          <td>
                                             
                                              <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/webapp/resource/images/edit-validated-icon.png"
                                              CommandArgument='<%# Eval("packageTimeId") %>' OnClick="btnEdit_Click"  />
                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                                    CommandArgument='<%# Eval("packageTimeId") %>'
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

