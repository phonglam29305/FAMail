<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/baiviethtml.master" AutoEventWireup="true" CodeFile="Bang-gia.aspx.cs" Inherits="tinh_nang_he_thong_Bang_gia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <div id="goidichvu">
        <asp:Label ID="lbphicaidat" runat="server" Text=""></asp:Label>
        <asp:DataList ID="dlTenChucNang" runat="server" CellPadding="4" ForeColor="#333333" Width="973px">

            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#EFF3FB" />

            <ItemTemplate>
                <asp:Label ID="all" runat="server" Text='<%# Eval("functionName") %>' Font-Size="12pt"></asp:Label>

            </ItemTemplate>

            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />

        </asp:DataList>
    </div>
    <div id="chucnang">
        <asp:DataList ID="dlSDCN" runat="server" RepeatDirection="Horizontal" Width="113%">

            <ItemTemplate>

                <asp:DataList ID="dlSudungChucNang" runat="server" DataSource='<%# display.LoadFunctionPackage(Convert.ToInt32(Eval("packageid"))) %>'>

                    <ItemTemplate>
                        <%-- thay thanh image  --%>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/blue-check.png" Visible='<%#Eval("isuse")+""=="yes"?true:false %>' />
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/CloseIcon20x20.png" Visible='<%#Eval("isuse")+""=="no"?true:false %> ' />
                        <asp:Label ID="Label6" runat="server" Visible='<%#(Eval("isuse")+""!="yes"&&Eval("isuse")+""!="NO")?true:false %>'></asp:Label>
                        <%-- thay thanh image   --%>    <%--<asp:Label ID="Label5" runat="server"  Visible='<%#Eval("isuse")+""=="yes"?true:false %>'><%#Eval("isuse") %></asp:Label> --%>

                        <div id="dangky">
                    </ItemTemplate>

                </asp:DataList>

                <div id="dangky">
                    <asp:HyperLink ID="Hpldangky" runat="server">
                        <a class="ajax" href='dangky.aspx?packageId=<%#Eval("packageId") %>'>
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/signupbtn.png" />
                        </a>
                    </asp:HyperLink>
                    <div id="bakground"></div>
                </div>

            </ItemTemplate>


        </asp:DataList>

    </div>

</asp:Content>

