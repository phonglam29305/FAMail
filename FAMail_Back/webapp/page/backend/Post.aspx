<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="webapp_Post" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .heartbeat {
            display: none;
            margin: 5px;
            color: blue;
        }
    </style>
    <script language="javascript" type="text/javascript">
        $(function () {
            setInterval(KeepSessionAlive, 10000);
        });

        function KeepSessionAlive() {
            $.post("/FAMail_Back/webapp/page/backend/KeepSessionAlive.ashx", null, function () {
                //$("#result").append("<p>Session is alive and kicking!<p/>");
                setInterval(function () { beatHeart(5); }, 10000);
            });
        }
        function beatHeart(times) {
            var interval = setInterval(function () {
                $(".heartbeat").fadeIn(500, function () {
                    $(".heartbeat").fadeOut(500);
                });
            }, 1000); // beat every second

            // after n times, let's clear the interval (adding 100ms of safe gap)
            setTimeout(function () { clearInterval(interval); }, (2000 * times) + 500);
        }
   </script>
    <div class="side-content fr">
        <div class="content-module">
            <div class="content-module-heading cf">
                <h3 class="fl">Bài viết</h3>
                <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">Mở ra</span> 
            </div>
            <div class="content-module-main">
                    <div id="errorbox" runat="server" class="error-box round">
                        <asp:Label ID="lblError"  runat="server" Text=""></asp:Label> 
                    </div>
                    <div id="successbox" runat="server" class="confirmation-box round">
                        <asp:Label ID="lblSuccess"  runat="server" Text=""></asp:Label> 
                    </div>
                    <div class="full-width-editor">
                        <table>
                            <tr>
                                <td>Tựa bài viết</td>
                                <td><asp:TextBox ID="txtTitle" runat="server" CssClass="round default-width-input" Height="20px" ToolTip="Nhập tựa đề bài viết"></asp:TextBox>
                                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Đường dẫn</td>
                                <td>
                                    <asp:TextBox ID="txtLink" runat="server" CssClass="round default-width-input" placeholder="Để trống nếu bài viết k có link"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Nhóm bài viết</td>
                                <td>
                                    <asp:DropDownList ID="ddlGroup" runat="server" AppendDataBoundItems="True" CssClass="round default-width-input">
                                        <asp:ListItem Value="nullgroup">--------Chọn nhóm--------</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Icon bài viết</td>
                                <td>
                                    <asp:FileUpload ID="fUlIcon" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>Hiển thị</td>
                                <td>
                                    <asp:DropDownList ID="ddlIsShow" runat="server">
                                        <asp:ListItem>--------------Chọn 1 mục--------------</asp:ListItem>
                                        <asp:ListItem Value="True">Hiển thị</asp:ListItem>
                                        <asp:ListItem Value="False">Không hiển thị</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Tóm tắt</td><td></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox ID="txtDescription" runat="server" Width="1096px" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Nội dung:</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox ID="txtContent" CssClass="ckeditor" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Tag:</td>
                                <td>
                                    Được phân cách nhau bởi dấu , ví dụ: Tag số 1,Tag số 2<br />
                                    <asp:TextBox ID="txtTags" runat="server" Width="596px" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Lưu bài viết" CssClass="round blue ic-right-arrow" OnClick="btnSubmit_Click"/>
                                    <asp:Button ID="btncapnhat" runat="server" Text="Cập nhật" CssClass="round blue ic-right-arrow" OnClick="btncapnhat_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    
                                </td>
                             
                            </tr>
                        </table>
                    </div>
                </div>
            <asp:DataList ID="dtbaiviet" runat="server" RepeatColumns="1" Width="100%" >
                                        <HeaderTemplate>
                                            <thead>
                                                <tr>
                                                    
                                                    <th>  Tên bài viết </th>
                                                    <th>  Nhóm  </th>
                                                    <th> Chức năng </th>
                                                  
                                                </tr>
                                            </thead>
                                        </HeaderTemplate>
                                        <FooterTemplate>
                                            <tfoot>
                                                <tr>
                                                    <td colspan="5" class="table-footer">
                                                    </td>
                                                </tr>
                                            </tfoot>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                          <tbody>
                                    <tr>
                                      
                                        <td style="text-align: left; padding-left: 10px;">
                                            <asp:Label ID="lblAttr" runat="server" Text='<%# Eval("keyName") %>' ></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGmail" runat="server" Text='<%# Eval("groupName") %>'></asp:Label>
                                        </td>
                                      
                                      
                                      
                                          <td>
                                             
                                              <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/webapp/resource/images/edit-validated-icon.png"
                                              CommandArgument='<%# Eval("key") %>' OnClick="btnEdit_Click"  />
                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                                    CommandArgument='<%# Eval("key") %>'
                                                     OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa thuộc tính này không ?')" OnClick="btnDelete_Click" 
                                                    /> 
                                                 
                                                 
                                        </td>
                                    </tr>
                                </tbody>        
                                        </ItemTemplate>
                                    </asp:DataList>
        </div>
        <div class="heartbeat">&hearts;</div>
    </div>
    
</asp:Content>

