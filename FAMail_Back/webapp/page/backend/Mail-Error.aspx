<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/report.master" AutoEventWireup="true" CodeFile="mail-error.aspx.cs" 
Inherits="webapp_page_backend_Mail_Error" Title="FASTAUTOMATICMAIL" %>
<%@ Register assembly="CollectionPager" namespace="SiteUtils" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script>
                    function checkAll() {
                        var checked = !$(this).data('checked');
                        $('input:checkbox').prop('checked', checked);
                        $(this).data('checked', checked);
                    }
    </script>

    <script>
    $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_dtlCustomer_ctl00_chkAll:checkbox').change(function() {
        if ($(this).attr("checked")) $('input:checkbox').attr('checked', 'checked');
        else $('input:checkbox').removeAttr('checked');
    });
    </script>
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
				    <h3 class="fl">Danh sách thư gửi lỗi</h3>
				    <span class="fr expand-collapse-text">Thu vào</span>
				    <span class="fr expand-collapse-text initial-expand">Mở ra</span>			
			    </div> <!-- end content-module-heading -->			
    	           
    	  
                
         <div class="content-module-main">
        
               <table>
              <asp:DataList ID="dlReport" runat="server">
                 <HeaderTemplate>

                     <tbody>
                         <tr>
                             <th style="width:50px;">                                 
                                  <input type="checkbox" onclick="checkAll()" value = "All"  />
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
                         <asp:CheckBox ID="chkCheck" runat="server" />
                         <asp:HiddenField ID="hdfId" runat="server" />
                         <asp:Label ID="lblNo" runat="server" Text=""></asp:Label>
			         </td>
			         <td><asp:Label ID="lblEmail" runat="server"  Text='<%# Eval("Email") %>' ></asp:Label></td>
			         <td><asp:Label ID="lblStartDate" runat="server"  Text='<%# Eval("StartDate") %>' ></asp:Label></td>
			         <td><asp:Label ID="lblEndDate" runat="server"  Text='<%# Eval("EndDate") %>' ></asp:Label></td>
			         <td> 
                        <asp:ImageButton ID="ibtStatus" runat="server" 
                              ImageUrl="~/webapp/resource/images/warning.png"  /> 
			         </td>
		           </tr>
	             </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td colspan="5" class="table-footer">
                                <label for="table-select-actions" style="font-weight: bolder; ">
                                Lựa chọn:</label>
                                <asp:DropDownList ID="drlType" runat="server">
                                    <asp:ListItem Value="1">Xóa</asp:ListItem>
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
                <cc1:CollectionPager ID="dlPager" runat="server" 
                                                 ControlCssClass="hung" BackNextDisplay="HyperLinks" BackText="« Trước" 
                                    LabelText="Trang:" NextText="Sau »" 
                                    ResultsFormat="Hiện thị kết quả {0}-{1} ({2})" ResultsLocation="None">
                            </cc1:CollectionPager>
            </table>
            
         </div> <!-- end content-module-main -->					
		   </div>
		</div>	
</asp:Content>

