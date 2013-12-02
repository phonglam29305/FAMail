<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PreviewContent.aspx.cs" Inherits="webapp_page_backend_PreviewContent"  EnableViewState="False"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>FASTAUTOMATICMAIL </title>
    <link href="../../resource/css/preview.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
            float: left;
           
        }
        .style2
        {
           background: #2a2e36; /* Old browsers */

           padding:5px;  
        }
       
    </style>
</head>
<body style="margin:0px auto; ">
    <form id="form1" runat="server">
    <div>
    
    
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td class="style2" colspan="2">
                <asp:LinkButton ID="btnDefault" runat="server" CssClass="round default" 
                        onclick="btnDefault_Click">Ban đầu</asp:LinkButton>
                    <asp:LinkButton ID="btnGmal" runat="server" CssClass="round gmail" 
                        onclick="btnGmal_Click">Gmail</asp:LinkButton>
		            <asp:LinkButton ID="btnYahoo" runat="server" CssClass="round yahoo" 
                        onclick="btnYahoo_Click">Yahoo</asp:LinkButton>
                    <asp:LinkButton ID="btnHotmail" runat="server" CssClass="round hotmail" 
                        onclick="btnHotmail_Click">Hotmail</asp:LinkButton>
                    <asp:LinkButton ID="btnOutlook" runat="server" CssClass="round outlook" 
                        onclick="btnOutlook_Click">Outlook</asp:LinkButton>
                    <asp:LinkButton ID="btnAOL" runat="server" CssClass="round aol" 
                        onclick="btnAOL_Click">AOL</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; min-width: 20%; vertical-align:top; background:#F1F1F1; ">
                   <h2 style="font-size: 0.85em; text-transform:uppercase; /* margin-top: 5px; */vertical-align: top;background:#2a2e36; margin:10px; padding:5px; color:White;">
                   Nội dung đánh giá</h2>
                   <div style="text-align:justify; padding:10px;">
                       <div class="information-box round">
                           <asp:Label ID="lblContent1" runat="server" Text="">Những nội dung đánh giá chỉ mang tính tương đối.</asp:Label>
                       </div>
                      
                       <div>
                        <asp:Label ID="lblContentLeft" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblGmail" runat="server" Text=""></asp:Label>
                 
                       </div>
                    </div>
                 </td>
                <td style=" border-left: 1px solid rgb(224, 231, 227);  width: 80%; vertical-align: top;">
                        <h2 style="font-size: 0.85em; text-transform:uppercase; /* margin-top: 5px; */vertical-align: top;background:#2a2e36; margin:10px; padding:5px; color:White;">
                          Nội dung mail
                          </h2>
                        <div style="padding:50px;">
                          
                            <asp:Label ID="lblContent" runat="server" Text="">
                             
                            </asp:Label>
                        </div>
    </form>
</body>
</html>



