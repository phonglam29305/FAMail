<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintOrder.aspx.cs" Inherits="webapp_page_backend_PrintOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EMAILMARKETING.1ONLINEBUSINESSSYSTEM.COM</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
 
            padding:10px;
        }
        .style2
        {
            width: 100%;
            border-style: solid;
            border-width: 1px;
            border-color:#CCCCCC;
            border-bottom-style: none;
            border-bottom-width: 0px;
        }
       .style2  td
        {
        	padding: 10px;
        	border-bottom-style: solid;
            border-bottom-width: 1px;
            border-bottom-color:#CCCCCC;
            
        }
       
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" width:1200px;">
    
        <table cellpadding="0" cellspacing="0" class="style1" >
        <tr>
            <td style="padding:0px; text-align:left;">
                <div style="font-weight:bold;">
                   <p>AMERICAN MARKET</p>
                   <p>Địa chỉ : Phương - Q.Phú Nhuận - Hồ Chí Minh</p>
                   <p>Điện thoai: 061233232  -  Fax: 0874434343 - Website: chomy.com.vn</p>
                </div>
            </td>
           <td colspan="2">
                
            </td>
              <td>
                Mã đơn đặt hàng: <asp:Label ID="lblOrderID" runat="server" Text="HD145328-01"></asp:Label>
            </td>
        </tr>
            <tr>
               
                <td colspan="4" align="center">
                   <h2 style="font-size:30px; font-weight: bolder">ĐƠN ĐẶT HÀNG</h2>
                   </td>
            </tr>
            <tr  style="font-weight:bold; width:350px;">
                <td>
                    Tên khách hàng : <asp:Label ID="lblNameCustomer" runat="server" 
                        Text="Không hiển thị "></asp:Label></td>
                <td>
                    Giới tính : <asp:Label ID="lblGender" runat="server" Text="Không hiển thị "></asp:Label></td>
                <td>
                    Số điện thoại : <asp:Label ID="lblPhoneNumber" runat="server" Text="Không hiển thị "></asp:Label></td>
                <td>
                    Email: <asp:Label ID="lblEmail" runat="server" Text="Không hiển thị "></asp:Label></td>
            </tr>
             <tr  style="font-weight:bold;">
                <td colspan="4">
                    Địa chỉ :  <asp:Label ID="lblAddress" runat="server" Text="Không hiển thị "></asp:Label></td>
                
            </tr>
          
            <tr style="font-weight:bold;">
                <td>
                 Hình thức thanh toán :  <asp:Label ID="lblPaymentForm" runat="server" Text="Không hiển thị "></asp:Label>
                    </td>
                <td>
                    Ngày đặt :  <asp:Label ID="lblDateCreate" runat="server" Text="Không hiển thị "></asp:Label></td>
                <td>
                    Ngày giao : <asp:Label ID="lblDeliveryDate" runat="server" Text="Không hiển thị "></asp:Label></td>
                <td>
                    Phương thức giao hàng:  <asp:Label ID="lblDeliveryMethod" runat="server" Text="Không hiển thị "></asp:Label></td>
            </tr>
             <tr>
            <td><br /></td>
            </tr>
            
               <tr>
                <td colspan="4">
                 
                    <table class="style2" cellpadding=0px cellspacing=0px>
                      <tr style="background-color:#6699CC; font-weight:bolder">
                            <td>
                                STT</td>
                            <td>
                                Mã sản phẩm</td>
                            <td>
                                Tên sản phẩm</td>
                            <td>
                                Mã giao hàng</td>
                            <td>
                                Đơn giá</td>
                            <td>
                                Số lượng</td>
                            <td>
                                Tổng tiền</td>
                            <td>
                                Ghi chú</td>
                        </tr>
                         <asp:Label ID="lblChitiet" runat="server" >
                              
                        
                         </asp:Label>
                        <tr style="font-size: 16px; text-transform:uppercase; font-weight:bolder; color: #000066">
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="3">
                                &nbsp;
                                Tổng cộng :
                            </td>
                            <td colspan="2">
                               <asp:Label ID="lblTotal" runat="server" Text="Không hiển thị  "></asp:Label> 
                                &nbsp;
                            </td>
                        </tr>
                                 <tr style="font-size: 16px; text-transform:uppercase; font-weight:bolder; color: #000066">
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="3">
                                &nbsp;
                                Đã thanh toán :
                            </td>
                            <td colspan="2">
                               <asp:Label ID="lblHandSel" runat="server" Text="Không hiển thị  "></asp:Label> 
                                &nbsp;
                            </td>
                        </tr>
                                   </tr>
                                 <tr style="font-size: 16px; text-transform:uppercase; font-weight:bolder; color: #000066">
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="3">
                                &nbsp;
                                Số còn lại :
                            </td>
                            <td colspan="2">
                               <asp:Label ID="lblSubTotal" runat="server" Text="Không hiển thị "></asp:Label> 
                                &nbsp;
                            </td>
                        </tr>
                         <tr style="font-size: 16px; text-transform:uppercase; font-weight:bolder; color: #000066">
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                         
                            <td colspan="3" style="text-align:right; padding-right:10px;">
                                &nbsp;
                                Số tiền bằng chữ:
                            </td>
                               <td colspan="3" >
                                &nbsp;
                               <asp:Label ID="lblWordMoney" runat="server" Text="Không hiển thị  "></asp:Label> 
                                &nbsp;
                            </td>
                        </tr>
                        
                    </table>
                    <table style="width:100%;" >
                        <tr style="font-weight:bolder;">
                            <td style="padding-left:100px;">
                                KHÁCH HÀNG
                            </td>
                            <td colspan="2">
                                <div style="text-align: center;">
                                    Ngày <asp:Label ID="lblDay" runat="server" Text="22 "></asp:Label>  tháng  <asp:Label ID="lblMonth" runat="server" Text="12 "></asp:Label>  năm <asp:Label ID="lblYear" runat="server" Text="2013 "></asp:Label> <br />
                                    Người lập<br />
                                    <br /><br />
                                   <asp:Label ID="lblPersonCreate" runat="server" Text="Nguyễn Viết Hùng "></asp:Label> 
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
               </tr>
        </table>
    </div>
    </form>
</body>
</html>
