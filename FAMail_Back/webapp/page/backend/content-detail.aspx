<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/SendMail.master"
 AutoEventWireup="true" CodeFile="content-detail.aspx.cs" 
 Inherits="webapp_page_backend_content_detail" Title="XEM NỘI DUNG CHI TIẾT"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <div class="side-content fr">
                <!--start content 01-->
                <div class="content-module">
                    <div class="content-module-heading cf">
                        <h3 class="fl">
                            Xem nội nội dung chi tiết </h3>
                            
                        <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">
                            Mở ra</span>
                    </div>
                    <!-- end content-module-heading -->
                    <div class="content-module-main">
                        <div class="content-module-main cf">
                            <asp:Label ID="lblContentDetail" runat="server" Text="Label"></asp:Label>
                        </div>                        
                    </div>
                </div>
      </div>
</asp:Content>

