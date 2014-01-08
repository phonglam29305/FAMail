<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Blog.aspx.cs" Inherits="Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans+Condensed:300&subset=vietnamese,latin' rel='stylesheet' type='text/css'>
    <link href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet"> 
    <link href="css/pagination.css" rel="stylesheet" />
    <div id="fb-root"></div>
    <script type="text/javascript">
        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));
    </script>
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
            <div id="blogpage" class="blog-clearfix" runat="server">
                <asp:Repeater ID="rptBlog" runat="server">
                    <ItemTemplate>
                        <div class="blog_items">
                            <h2 class="blog_header"><%#Eval("keyName") %></h2>
                            <div class="article-tools clearfix">
                                <div class="article-meta">
	                                <span class="createdate"><%#Eval("createDate") %></span>
	                                <span class="createby">Quản trị viên</span>
                                </div>
                            </div>
                            <div class="blog_image">
                                <img src='<%#Eval("keyImage") %>' />
                            </div>
                            <div class="postcontent">
                                <%#Eval("keyDescription") %><a href='<%#Eval("link") %>' class="readmore">Đọc thêm</a>
                            </div>
                            <p class="tags">
                                <asp:Literal ID="ltrTags" runat="server" Text='<%#Eval("PostTag") %>'></asp:Literal>
                            </p>
                            <div class="stripe-separator"></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div id="divpaging" class="pagingcontainer" runat="server">
                    <div class="pagination">
                        <div class="pagingcontent">
                            <asp:DataList ID="DataListPaging" runat="server" RepeatDirection="Horizontal" onitemcommand="DataListPaging_ItemCommand" onitemdatabound="DataListPaging_ItemDataBound">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Pagingbtn" runat="server" CommandArgument='<%# Eval("PageIndex") %>' CommandName="newpage" Text='<%# Eval("PageText") %> ' CssClass="spacing"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </div>
                </div>
            </div>

            <div id="blogitemdetail" runat="server" visible="false">
                <asp:Literal ID="ltrPost" runat="server"></asp:Literal>
                <div class="stripe-separator"></div>
                <p class="tags">
                    <asp:Literal ID="ltrBlogTag" runat="server"></asp:Literal>  
                </p>
                <div class="stripe-separator"></div>
                <div id="fbcomment" class="fb-comments" runat="server" data-href="http://example.com" data-num-posts="15" data-width="765"></div>
            </div>
        </div>
    </div>
</asp:Content>

