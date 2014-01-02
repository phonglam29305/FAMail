<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="cssmenu">
          <div class="top"></div>
          <ul>
              <asp:Repeater ID="rtmenu" runat="server">
                   <ItemTemplate>
                      <li class='active'><a href='<%#Eval("link") %>' class=""><%#Eval("keyName") %></a></li>
                   </ItemTemplate>
              </asp:Repeater>           
          </ul>    
     </div>
    <div id="baiviet" style=" width:auto; height:auto; margin-left:200px;">
        <div id="content">
            <asp:Literal ID="ltrPost" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>

