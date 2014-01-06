<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Bang-gia.aspx.cs" Inherits="Bang_gia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("div#goidichvu :first-child").addClass('first-div');
            $("div#goidichvu div div").removeClass('first-div');
            $("#goidichvu div:last-child").addClass('last-child');
            $("#goidichvu div div").removeClass('last-child');
            if (/*@cc_on!@*/false) {/*IE 10 detect*/
                $("div#goimail .pricing").addClass('ie10');
            };
            if ($.browser.msie && parseFloat($.browser.version) == 9) {
                $("div#chucnang div:first-child").addClass("ie9");
            }
        });
    </script>
    <style>
        #goidichvu div:first-child {
            border-left:none !important;
            border-top:1px solid white;
        }
        .ie10 {
            padding: 60px 0 23px !important;
        }
        @-moz-document url-prefix() {
            .pricing span p
            {
                margin-top:0px !important;
            }
            #goidichvu div:nth-child(2n+1) {
                height:39px !important;
            }
            #goidichvu div:nth-child(2n+2) {
                /*border-top:1px solid #C3D5DF;
                border-left:1px solid #C3D5DF;*/
                /*border:none !important;*/
                height:39px !important;
            }
        }
    </style>
    <!--[if ie]>
       <style>
            #chucnang div:first-child{
                margin-left:-1px;
            }
            .ie9{
                margin-left:0px !important;
            }
			#goimail .pricing {
                font-size: 15px;
                font-weight: bold;
                color: #fff;
                line-height: 55px;
                padding: 60px 0 23px;
            }
            #goidichvu div:first-child{
                margin-top:9px !important;
            }
            .nth-child-2n1 {
                height:39px !important;
            }
            .nth-child-2n2 {
                height:40px !important;
            }
            .last-child {
                border-bottom:1px solid #C3D5DF;
            }
            .first-div{
                border-top:1px solid white;
                border-left:none !important;
            }
            .menu-content-1{
                width:667px !important;
            }
       </style> 
    <![endif]-->
    
      <!--[if (lt IE 9)] >
        <style>
           .pricing{
                font-size: 15px; 
                font-weight: bold;
                color: #fff; 
                line-height: 55px; 
                padding: 60px 0 23px;
            }
            .last-child {
                border-bottom:1px solid #C3D5DF;
            }
            .first-div{
                margin-top:5px !important;
                border-top:1px solid white;
                border-left:none !important;
            }
            #goidichvu div:first-child{
                margin-top:10px !important;
            }
            #goimail .column-5:first-child{
                width:151px;
            }
        </style>
    <!--[end if]--> 

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
                <%--<asp:Label ID="lbphicaidat" runat="server" Text=""></asp:Label>--%>
        <asp:Repeater ID="rptNameFunction" runat="server" >
            <ItemTemplate>
                <div class="parentdiv" style="clear:both;width:192px;height:39px;vertical-align:middle;">
                    <div class="innerdiv" style="border:none !important;height:10px;margin-top:10px;">
                        <asp:Label ID="all" runat="server" Text='<%# Eval("functionName") %>'></asp:Label>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div id="chucnang">
        <asp:Repeater ID="rptMain" runat="server">
            <ItemTemplate>
                <div style="width:152px;float:left;margin-right:2px;border:1px solid #C3D5DF;">
                <div style="text-align:center;width:100%;height:39px;">
                    <a class="ajax register" href="Register.aspx?packageId=<%#Eval("packageId") %>" style="outline:none;"><img src="images/signupbtn.png" /></a>
                </div>
                <asp:Repeater ID="rptSudungChucnang" runat="server" DataSource='<%# display.LoadFunctionPackage(Convert.ToInt32(Eval("packageid"))) %>'>
                    <ItemTemplate>
                         <div style="text-align:center;width:100%;height:39px;">
                             <img id="Img1" runat="server" src="images/blue-check.png" Visible='<%#Eval("isUse")+""=="yes"?true:false %>' />
                             <%--<img id="Img2" runat="server" src="~/images/CloseIcon20x20.png" Visible='<%#Eval("isUse")+""=="no"?true:false %> ' />--%>
                             <asp:Label ID="Label1" runat="server" style="text-align: center" Visible='<%#(Eval("isuse")+""!="yes"&&Eval("isuse")+""!="no")?true:false %>'><%#Eval("isuse") %></asp:Label>
                         </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div id="dangky">
                    <%--<img src="../images/signupbtn.png" style="margin-left:10px;"/>--%>
                    <div id="bakground">
                        <a class="ajax register" href="Register.aspx?packageId=<%#Eval("packageId") %>" style="outline:none;"><img src="images/signupbtn.png" /></a>
                    </div>
                </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div style="clear:both;margin-bottom:20px;"></div>
</asp:Content>

