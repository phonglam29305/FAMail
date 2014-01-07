<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Blog.aspx.cs" Inherits="Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans+Condensed:300&subset=vietnamese,latin' rel='stylesheet' type='text/css'>
    <link href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet"> 
    <link href="css/pagination.css" rel="stylesheet" />
    <div id="cssmenu">
          <div class="top"></div>
          <ul>
              <%--<asp:Repeater ID="rtmenu" runat="server">
                   <ItemTemplate>
                      <li class='active'><a href='<%#Eval("link") %>' class=""><%#Eval("keyName") %></a></li>
                   </ItemTemplate>
              </asp:Repeater> --%>     
              <li><a href="#">HKHK</a></li>
              <li><a href="#">HKHK</a></li>
              <li><a href="#">HKHK</a></li>
              <li><a href="#">HKHK</a></li>     
          </ul>    
     </div>
    <div id="baiviet" style=" width:auto; height:auto; margin-left:200px;">
        <div id="content">
            <div id="blogpage" class="blog-clearfix">
                <div class="blog_items">
                    <h2 class="blog_header">SEIKO – ĐIỀU KHIỂN VÙNG THỜI GIAN CỦA BẠN</h2>
                    <div class="article-tools clearfix">
                        <div class="article-meta">
	                        <span class="createdate">Thứ năm, 12 Tháng 9 2013 09:28</span>
	                        <span class="createby">Quản trị viên</span>
                        </div>
                    </div>
                    <div class="blog_image">
                        <img src="http://chomy.com.vn/images/bai-viet/dong-ho-Seiko-Watch/dong-ho-SEIKO.jpg" />
                    </div>
                    <div class="postcontent">
                        Seiko là Tập đoàn sản xuất công nghiệp lớn trên thế giới, đã có lịch sử trên 109 năm phát triển. Hãng Seiko kinh doanh đa dạng trên nhiều lĩnh vực khác nhau như: thời trang, bất động sản, điện tử, xây dựng... dưới những công ty lớn còn có hàng chục công ty con và các chi nhánh trên khắp thế giới. Hiện doanh thu mỗi năm của Seiko lên đến trên 6 tỷ USD và là một trong những Tập đoàn lớn nhất tại Nhật Bản.<a href="#" class="readmore">Đọc thêm</a>
                    </div>
                    <p class="tags">
                        <a href="#" title="Tag 1">Tag 1</a>
                        <a href="#" title="Tag 2">Tag 2</a>
                        <a href="#" title="Tag 3">Tag 3</a>
                    </p>
                    <div class="stripe-separator"></div>
                </div>

                <div class="blog_items">
                    <h2 class="blog_header">SEIKO – ĐIỀU KHIỂN VÙNG THỜI GIAN CỦA BẠN</h2>
                    <div class="article-tools clearfix">
                        <div class="article-meta">
	                        <span class="createdate">Thứ năm, 12 Tháng 9 2013 09:28</span>
	                        <span class="createby">Quản trị viên</span>
                        </div>
                    </div>
                    <div class="blog_image">
                        <img src="http://chomy.com.vn/images/bai-viet/dong-ho-Seiko-Watch/dong-ho-SEIKO.jpg" />
                    </div>
                    <div class="postcontent">
                        Seiko là Tập đoàn sản xuất công nghiệp lớn trên thế giới, đã có lịch sử trên 109 năm phát triển. Hãng Seiko kinh doanh đa dạng trên nhiều lĩnh vực khác nhau như: thời trang, bất động sản, điện tử, xây dựng... dưới những công ty lớn còn có hàng chục công ty con và các chi nhánh trên khắp thế giới. Hiện doanh thu mỗi năm của Seiko lên đến trên 6 tỷ USD và là một trong những Tập đoàn lớn nhất tại Nhật Bản.<a href="#" class="readmore">Đọc thêm</a>
                    </div>
                    <p class="tags">
                        <a href="#" title="Tag 1">Tag 1</a>
                        <a href="#" title="Tag 2">Tag 2</a>
                        <a href="#" title="Tag 3">Tag 3</a>
                    </p>
                    <div class="stripe-separator"></div>
                </div>
                <div id="divpaging" class="pagingcontainer" runat="server">
                    <div class="pagination">
                        <div class="pagingcontent">
                            <%--<asp:DataList ID="DataListPaging" runat="server" RepeatDirection="Horizontal" onitemcommand="DataListPaging_ItemCommand" onitemdatabound="DataListPaging_ItemDataBound">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Pagingbtn" runat="server" CommandArgument='<%# Eval("PageIndex") %>' CommandName="newpage" Text='<%# Eval("PageText") %> ' CssClass="spacing"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:DataList> --%>
                            <a>1</a>
                            <a>2</a>
                            <a>3</a>
                            <a>4</a>
                            <a>5</a>
                            <a>6</a>
                            <a>7</a>
                            <a>8</a>
                            <a>9</a>
                        </div>
                    </div>
                </div>
            </div>

            <div id="blogitemdetail" runat="server" visible="false">
                <asp:Literal ID="ltrPost" runat="server"></asp:Literal>
                <div class="stripe-separator"></div>
                <p class="tags">
                    <a href="#" title="DADA">DADA</a>
                    <a href="#" title="DADA">DADA</a>
                    <a href="#" title="DADA">DADA</a>
                </p>
                <div class="stripe-separator"></div>
            </div>
        </div>
    </div>
</asp:Content>

