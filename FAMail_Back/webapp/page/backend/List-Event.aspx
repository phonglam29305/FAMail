<%@ Page Language="C#" Debug="true" MasterPageFile="~/webapp/template/backend/event.master" AutoEventWireup="true" 
CodeFile="List-Event.aspx.cs" Inherits="webapp_page_backend_List_Event" Title="FASTAUTOMATICMAIL" 
ValidateRequest="false"  %>

<%@ Register assembly="CollectionPager" namespace="SiteUtils" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="side-content fr">
                <asp:Panel Visible="false" ID="pnError" runat="server">
                    <div class="error-box round">
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </div>
                </asp:Panel>
                <asp:Panel Visible="false" ID="pnSuccess" runat="server">
                    <div class="confirmation-box round">
                        <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
                    </div>
                </asp:Panel>
                <div class="content-module">
                    <div class="content-module-heading cf">
                        <h3 class="fl">
                            Danh sách sự kiện</h3>
                        <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">
                            Mở ra</span>
                    </div>
                    <!-- end content-module-heading -->
                    <div class="content-module-main">
                        <%--<form  runat="server">--%>
                        <asp:Panel ID="pnSearch" runat="server">
                            <table id="FilterTable">
                                <thead>
                                    <tr>
                                        <th colspan="6" style="height: 27px; padding-left: 10px; text-align: left">
                                            Tìm kiếm sự kiện
                                        </th>
                                    </tr>
                                </thead>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="btnFillter" runat="server" ImageUrl="~/webapp/resource/images/Calendar-icon.png" />
                                    </td>
                                    <td align="left" style="text-align: left;">
                                        <asp:Label ID="Label5" runat="server" Text="&lt;b&gt;Tiêu đề:&lt;/b&gt;"></asp:Label>
                                        <asp:TextBox ID="txtSubject" runat="server" CssClass="Hung" Width="100%"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/webapp/resource/images/EMail-icon.png" />
                                    </td>
                                    <td align="left" style="text-align: left;">
                                    <p>
								    <label for="full-width-input">Phân loại khách hàng</label>
								    <asp:DropDownList ID="drlMailGroup" CssClass="round default-width-dropdown" runat="server">
                                    </asp:DropDownList>
								    <em>Tùy chọn này dùng để phân nhóm mail ! (<a href="group-mail.aspx">Thêm nhóm mới</a>)</em>								
							    </p> 
                                    </td>
                                    <td style="padding-left: 30px;">
                                        <asp:Button ID="btnFilter" runat="server" CssClass="button round blue image-right ic-search text-upper"
                                            Text="Lọc dữ liệu" OnClick="btnFilter_Click" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
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
								                  <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/webapp/resource/images/edit-validated-icon.png"
                                                    PostBackUrl='<%#"~/webapp/page/backend/create-event.aspx?EventId=" + Eval("EventId")%>' />
								                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                                    CommandArgument='<%# Eval("id") %>' OnClick="btnDelete_Click" OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa sự kiện này không ?')" />

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
                                   <cc1:CollectionPager ID="dlPager" runat="server" 
                                                 ControlCssClass="hung" BackNextDisplay="HyperLinks" BackText="« Trước" 
                                    LabelText="Trang:" NextText="Sau »" 
                                    ResultsFormat="Hiện thị kết quả {0}-{1} ({2})" ResultsLocation="None">
                            </cc1:CollectionPager>
                        </table>
                        <%-- </form>--%>
                    </div>
                    <!-- end content-module-main -->
                </div>
            </div>
            

    <!-- ============= datetime picker -->

    <script type="text/javascript">
        $(function () {
            $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtDateFrom').datetimepicker({
                changeMonth: true, changeYear: true, timeFormat: "", dateFormat: "dd/mm/yy"
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtDateTo').datetimepicker({
                changeMonth: true, changeYear: true, timeFormat: "", dateFormat: "dd/mm/yy"
            });
        });
    </script>

</asp:Content>