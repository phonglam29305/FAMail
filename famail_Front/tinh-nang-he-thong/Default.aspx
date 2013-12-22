<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/baiviethtml.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="tinh_nang_he_thong_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="topPage" style="width: auto; height: auto;">
        <h1 class="entry-title pricing">Bảng giá các tài khoản</h1>
    </div>
    <div id="logo1">
        <asp:Image ID="Image6" runat="server" ImageUrl="~/images/satisfaction-guaranteed.png" />
    </div>
    <div id="goimail">
        <asp:DataList ID="dlGoiDichVu" runat="server" RepeatDirection="Horizontal" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#F7F7DE" />
            <ItemTemplate>
                <th style="width: 197px;" colspan="1" rowspan="1" class="column-5 sorting_disabled">
                    <div class="majortitle1">
                        <asp:Label ID="Lbgoidichvu" runat="server" Text=""><%#Eval("PackageName") %></asp:Label>
                    </div>
                    <div class="subtitle">Hệ thống FA Mail</div>
                    <div id="month_pro">
                        <div class="pricing">
                            <span><sup>$</sup><%#Eval("totalFee") %></span>Tháng
                        </div>
                    </div>
                </th>
            </ItemTemplate>
            <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
    </div>
    <div id="goidichvu" style="height:100%;width:195px;float:left;">
                <asp:Label ID="lbphicaidat" runat="server" Text=""></asp:Label>
        <asp:Repeater ID="rptNameFunction" runat="server" >
            <ItemTemplate>
                <div style="clear:both;width:192px;height:40px;">
                    <asp:Label ID="all" runat="server" Text='<%# Eval("functionName") %>' Font-Size="12pt"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div id="chucnang">
        <asp:Repeater ID="rptMain" runat="server">
            <ItemTemplate>
                <div style="width:191px;float:left;margin-right:2px;border:1px solid #C3D5DF;">
                <asp:Repeater ID="rptSudungChucnang" runat="server" DataSource='<%# display.LoadFunctionPackage(Convert.ToInt32(Eval("packageid"))) %>'>
                    <ItemTemplate>
                         <div style="text-align:center;width:100%;">
                             <img id="Img1" runat="server" src="../images/blue-check.png" Visible='<%#Eval("isUse")+""=="yes"?true:false %>' />
                             <img id="Img2" runat="server" src="~/images/CloseIcon20x20.png" Visible='<%#Eval("isUse")+""=="no"?true:false %> ' />
                         </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div id="dangky">
                    <img src="../images/signupbtn.png" style="margin-left:10px;"/>
                    <div id="bakground"></div>
                </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

