<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/baiviethtml.master" AutoEventWireup="true" CodeFile="Bang-gia.aspx.cs" Inherits="tinh_nang_he_thong_Bang_gia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="bottompagehtml">

   <div class="topPage">
			<h1 class="entry-title pricing">Bảng giá các tài khoản</h1>
   </div>

<div class="individual">
<div id="wp-table-reloaded-id-2-no-1_wrapper" class="dataTables_wrapper">
<table id="wp-table-reloaded-id-2-no-1" class="wp-table-reloaded wp-table-reloaded-id-2">
<thead>
	<tr class="row-1 odd">
    
    <th style="width: 199px;" colspan="1" rowspan="1" class="column-1 sorting_disabled">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/satisfaction-guaranteed.png" />        
    </th>
    <th style="width: 193px;" colspan="1" rowspan="1" class="column-2 sorting_disabled">
    	<div class="majortitle">Basic</div>
        <div class="subtitle">Hệ thống FA Mail</div>
        <div id="month_auto">
          <div class="pricing">
       		 <span><sup>$</sup>9</span>Tháng
          </div>
      
          </div></th>
          
     <th style="width: 193px;" colspan="1" rowspan="1" class="column-3 sorting_disabled">
       <div class="majortitle">Starter</div>
       <div class="subtitle">Hệ thống FA Mail</div>
       <div id="month_start">
          <div class="pricing">
            <span><sup>$</sup>49</span>Tháng
          </div>
         
       </div></th>
       
     <th style="width: 193px;" colspan="1" rowspan="1" class="column-4 sorting_disabled">
       <div class="majortitle">business</div>
       <div class="subtitle">Hệ thống FA Mail</div>
       <div id="month_basic">
         <div class="pricing">
           <span><sup>$</sup>99</span>Tháng
         </div>
       
      </div></th>
       
      <th style="width: 193px;" colspan="1" rowspan="1" class="column-5 sorting_disabled">
      <div class="majortitle">Professional</div>
      <div class="subtitle">Hệ thống FA Mail</div>
      <div id="month_pro">
        <div class="pricing">
          <span><sup>$</sup>129</span>Tháng

        </div>
         
        </div></th>
        
    </tr>
    
</thead>
 <%--   ajax cboxElement--%>
<tfoot>
	<tr class="row-20 even">
    <th colspan="1" rowspan="1" class="column-1"></th>
    <th colspan="1" rowspan="1" class="column-2"><%--<a id="autobtm" href="Dangky.aspx"><asp:Image ID="Image6" runat="server"  ImageUrl="~/images/signupbtn.png" /></a>--%>

        <asp:DataList ID="DataList2" runat="server">

            <ItemTemplate>              
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="all" runat="server" Text='<%#Eval("isUse") %>'></asp:Label>                        
                        </td>
                         <td>
                            <asp:Label ID="bb" runat="server" Text='<%#Eval("functionName") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                       
                    </tr>
                </tbody>
                 <td>
                            
                 </td>
            </ItemTemplate>

        </asp:DataList>
        <asp:HyperLink ID="autobtm" runat="server">
                                <a class="ajax" href="dangky.aspx?type="<%#Eval("functionId") %>">
                                <asp:Image ID="Image2" runat="server"  ImageUrl="~/images/signupbtn.png" />
                                </a>
                           </asp:HyperLink>

    </th>               
    <th>
         <asp:DataList ID="DataList1" runat="server">

            <ItemTemplate>              
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="all" runat="server" Text='<%#Eval("isUse") %>'></asp:Label>                        
                        </td>
                         <td>
                            <asp:Label ID="bb" runat="server" Text='<%#Eval("functionName") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                       
                    </tr>
                </tbody>
                 <td>
                            
                 </td>
            </ItemTemplate>

        </asp:DataList>
        <asp:HyperLink ID="HyperLink1" runat="server">
                                <a class="ajax" href="dangky.aspx?type="<%#Eval("functionId") %>">
                                <asp:Image ID="Image3" runat="server"  ImageUrl="~/images/signupbtn.png" />
                                </a>
                           </asp:HyperLink>
 </th>
    <th colspan="1" rowspan="1" class="column-4">
     
         <asp:DataList ID="DataList3" runat="server">

            <ItemTemplate>              
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="all" runat="server" Text='<%#Eval("isUse") %>'></asp:Label>                        
                        </td>
                         <td>
                            <asp:Label ID="bb" runat="server" Text='<%#Eval("functionName") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                       
                    </tr>
                </tbody>
                 <td>
                            
                 </td>
            </ItemTemplate>

        </asp:DataList>
        <asp:HyperLink ID="HyperLink2" runat="server">
                                <a class="ajax" href="dangky.aspx?type="<%#Eval("functionId") %>">
                                <asp:Image ID="Image4" runat="server"  ImageUrl="~/images/signupbtn.png" />
                                </a>
                           </asp:HyperLink>
 </th>
   <th>
        <asp:DataList ID="DataList4" runat="server">

            <ItemTemplate>              
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="all" runat="server" Text='<%#Eval("isUse") %>'></asp:Label>                        
                        </td>
                         <td>
                            <asp:Label ID="bb" runat="server" Text='<%#Eval("functionName") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                       
                    </tr>
                </tbody>
                 <td>
                            
                 </td>
            </ItemTemplate>

        </asp:DataList>
            <asp:HyperLink ID="HyperLink3" runat="server">
                                <a class="ajax" href="dangky.aspx?type="<%#Eval("functionId") %>">
                                <asp:Image ID="Image5" runat="server"  ImageUrl="~/images/signupbtn.png" />
                                </a>
                           </asp:HyperLink>
   </th>
    
    </tr>
</tfoot>
    
<tbody class="row-hover">

  <tr class="row-2 even">
	<td class="column-1">
      <span>Phí cài đặt và hợp đồng</span></td>
      <asp:DataList ID="dtfunction" runat="server" RepeatColumns="1" Width="100%"   >                   
                    <ItemTemplate>
                        <tbody class="row-hover">
                            <tr class="row-2 even">
                                <td style="text-align: left; padding-left: 10px;" class="column-1" >
                                    <asp:Label ID="lblAttr" runat="server" Text='<%# Eval("functionName") %>'></asp:Label>
                                </td>
                               

                            </tr>
                            
                        </tbody>
                    </ItemTemplate>
                </asp:DataList>
     
      
  </tr>
   </tbody>
</table>
</div>

</div>


</div>
</asp:Content>

