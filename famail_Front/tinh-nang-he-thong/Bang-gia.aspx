<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/baiviethtml.master" AutoEventWireup="true" CodeFile="Bang-gia.aspx.cs" Inherits="tinh_nang_he_thong_Bang_gia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <style>
        @-moz-document url-prefix() {
            #chucnang div:nth-child(1){
                    border-left:none !important;
                    margin-right:4px !important;
            }
            #chucnang div:last-child{
                width:190px !important;
                margin-right:0px !important;
                border-right:none !important;
                margin-left:-1px;
            }
        }
    </style>
    <div class="topPage" style="width: auto; height: auto;">
        <h1 class="entry-title pricing">Bảng giá các gói dịch vụ</h1>
    </div>
    <div id="logo1">
        <asp:Image ID="Image6" runat="server" ImageUrl="~/images/satisfaction-guaranteed.png" />
    </div>
    <div id="goimail">
       
        <asp:Repeater ID="rptGoiDichVu" runat="server">
            <ItemTemplate>
                <div class="column-5 sorting_disabled">
                    <div class="majortitle1">
                        <asp:Label ID="Lbgoidichvu" runat="server" Text=""><%#Eval("PackageName") %></asp:Label>
                    </div>
                    <div class="subtitle">Hệ thống FA Mail</div>
                    <div id="month_pro">
                        <div class="pricing">
                            <span><%#"<p style='margin-top: -52px;margin-bottom: -56px;margin-left: 6px;width: 10px;font-size: 20px;'>$</p>"+Eval("totalFee") %></span>/Tháng
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div id="goidichvu" style="height:100%;width:195px;float:left;">
                <asp:Label ID="lbphicaidat" runat="server" Text=""></asp:Label>
        <asp:Repeater ID="rptNameFunction" runat="server" >
            <ItemTemplate>
                <div style="clear:both;width:192px;height:39px;vertical-align:middle;">
                    <div style="border:none !important;height:10px;margin-top:10px;"><asp:Label ID="all" runat="server" Text='<%# Eval("functionName") %>'></asp:Label></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div id="chucnang">
        <asp:Repeater ID="rptMain" runat="server">
            <ItemTemplate>
                <div style="width:152px;float:left;margin-right:2px;border:1px solid #C3D5DF;">
                <div style="text-align:center;width:100%;height:39px;">
                    <a class="ajax register" href="Register.aspx?packageId=14"><img src="../images/signupbtn.png" /></a>
                </div>
                <asp:Repeater ID="rptSudungChucnang" runat="server" DataSource='<%# display.LoadFunctionPackage(Convert.ToInt32(Eval("packageid"))) %>'>
                    <ItemTemplate>
                         <div style="text-align:center;width:100%;">
                             <img id="Img1" runat="server" src="../images/blue-check.png" Visible='<%#Eval("isUse")+""=="yes"?true:false %>' />
                             <img id="Img2" runat="server"  Visible='<%#Eval("isUse")+""=="no"?true:false %> ' />
                             <asp:Label ID="Label1" runat="server" style="text-align: center" Visible='<%#(Eval("isuse")+""!="yes"&&Eval("isuse")+""!="no")?true:false %>'><%#Eval("isuse") %></asp:Label>
                         </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div id="dangky">
                    <%--<img src="../images/signupbtn.png" style="margin-left:10px;"/>--%>
                    <div id="bakground">
                         <a class="ajax register"  href='register.aspx?packageId=<%#Eval("packageId") %>'>
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/signupbtn.png" />
                        </a>
                    </div>
                </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div style="clear:both;margin-bottom:20px;"></div>

</asp:Content>

