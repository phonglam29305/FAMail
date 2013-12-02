<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnReciveMail.aspx.cs" Inherits="UnReciveMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ngưng nhận tin khuyến mãi</title>
</head>
<body style="margin: 0px auto; text-align: center; width:auto;">
    <form id="form1" runat="server">
    <div style="text-align: center; margin: 100px auto; width:1024px;">
    
        <table style="background-color: #66CCFF; padding: 20px;">
            <tr>
                <td colspan="2" style="padding: 20px;"><asp:Label ID="Label1" runat="server" 
            Text="Bạn thực sử không muốn nhận thông tin khuyến mãi từ chúng tôi ?"></asp:Label></td>
            </tr>
            <tr>
                <td style="padding: 20px;">
                    <asp:Button ID="btnOk" runat="server" Text="Đúng vậy, Tôi không muốn" 
                        onclick="btnOk_Click"  />
                </td>
                 <td style="padding: 20px;">
                     <asp:Button ID="btnCancel" runat="server" Text="Tôi sẽ tiếp tục nhận thông tin" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
