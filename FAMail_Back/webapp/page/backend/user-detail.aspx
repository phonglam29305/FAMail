<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/report.master" AutoEventWireup="true"
    CodeFile="user-detail.aspx.cs" Inherits="webapp_page_backend_reportSend" Title="FASTAUTOMATICMAIL" %>

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
                    Thông kê tổng quát</h3>
                <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">
                    Mở ra</span>
            </div>
            <!-- end content-module-heading -->
            <%--<div class="content-module-main cf">
                <div class="half-size-column fl" style="height: auto">
                    <fieldset style="margin-left: 15px;">
                        <p>
                            <label for="full-width-input">
                                Thống kê theo thời gian</label>
                            <div class="stripe-separator"><!--  --></div>
                                Từ ngày
                            <asp:TextBox ID="txtStartDate" Width="20%" CssClass="round default-width-input" runat="server"></asp:TextBox>
                            Đến ngày
                            <asp:TextBox ID="txtEndDate" Width="20%" CssClass="round default-width-input" runat="server"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="Thống kê" 
                                CssClass="button round blue image-right ic-add text-upper" 
                                     />    
                            <div class="stripe-separator"><!--  --></div>
                        </p>
                    </fieldset>
                </div>               
            </div>--%>
            <div class="stripe-separator"><!--  --></div>
            <div class="content-module-main" style="margin-top: -32px;">
                <!-- start update panel-->
                <div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </div>
             
                        <div class="content-module-main cf">
                            <div class="half-size-column fl">
                                <fieldset>
                                    <table>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Tên đăng nhập:</b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblUsername" runat="server" Text="Không hiển thị"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 40%; text-align: left; padding-left: 10px;">
                                                <b>Thuộc phòng ban :</b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblDepartment" runat="server" Text="Không hiển thị "></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 65%; text-align: left; padding-left: 10px;">
                                                <b>Mail đã gửi đi / Tổng cho phép : </b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblHasSend" runat="server" Text="Không hiển thị"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 35px">
                                            <td style="width: 65%; text-align: left; padding-left: 10px;">
                                                <b>Khách hàng đã tạo / Tổng cho phép :</b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblHasCustomerCreate" runat="server" Text="Không hiển thị "></asp:Label>
                                            </td>
                                        </tr>

                                        <tr style="height: 35px">
                                            <td style="width: 65%; text-align: left; padding-left: 10px;">
                                                <b>Hiệu lực đến ngày</b>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblToDate" runat="server" Text="Không hiển thị "></asp:Label>
                                            </td>
                                        </tr>
                                        
                                       
                                    </table>
                                </fieldset>
                            </div>
                            <!-- end half-size-column -->
                            
                        </div>
      
            </div>
         </div>
            
<!-- ============= datetime picker -->

<script type="text/javascript">
    $(function () {
        $('#ContentPlaceHolder1_ContentPlaceHolder1_txtStartDate').datetimepicker({
	            changeMonth:true, changeYear:true, timeFormat: "", dateFormat: "dd/mm/yy"
            });

	        $('#ContentPlaceHolder1_ContentPlaceHolder1_txtEndDate').datetimepicker({
	            changeMonth: true, changeYear: true, timeFormat: "", dateFormat: "dd/mm/yy"
	        });
    });	
</script> 
</asp:Content>
