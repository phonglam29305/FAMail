<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" CodeFile="ManageHTMLRule.aspx.cs" Inherits="webapp_page_backend_ManageHTMLRule" Title="Manage HTML Rule" %>
<%@ Register assembly="CollectionPager" namespace="SiteUtils" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="side-content fr">
         <asp:Panel Visible="false" ID="pnError" runat="server">
            <div class="error-box round">
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>
        </asp:Panel>
        <asp:Panel Visible="false" ID="pnSuccess" runat="server">
            <div class="confirmation-box round">
                <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
            </div>
        </asp:Panel>
            <div class="content-module">
                <div class="content-module-heading cf">
                    <h3 class="fl">
                        THÊM TIÊU CHUẨN</h3>
                    <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">
                        Mở ra</span>
                </div>
                <!-- end content-module-heading -->
                <div class="content-module-main" style="height: auto; padding-left: 10px;">
                      <table>
                          <tr>
                            <td>Thuộc tính</td>
                            <td>Gmail</td>
                            <td>YahooMail</td>
                            <td>HotMail</td>
                            <td>AOL Mail</td>
                            <td>Outlook</td>
                            <td></td>
                          </tr>
                          <tr>
                            <td>
                                <asp:TextBox ID="txtAttr" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:CheckBox ID="chkGmail" runat="server" />
                            </td>
                            <td><asp:CheckBox ID="chkYahoo" runat="server" /></td>
                            <td><asp:CheckBox ID="chkHotMail" runat="server" /></td>
                            <td><asp:CheckBox ID="chkAOL" runat="server" /></td>
                            <td><asp:CheckBox ID="chkOutLook" runat="server" /></td>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Cập nhật" 
                                    CssClass="button round blue image-right ic-add text-upper" 
                                    onclick="btnSave_Click" /></td>
                          </tr>
                      </table>
                   
                    </div>
                       <div class="content-module-heading cf">
                    <h3 class="fl">
                        Bảng tiêu chuẩn HTML Mail</h3>
                    <span class="fr expand-collapse-text">Thu vào</span> <span class="fr expand-collapse-text initial-expand">
                        Mở ra</span>
                </div>
                <!-- end content-module-heading -->
                <div class="content-module-main" >
                    <%--<form  runat="server">--%>
                   
                    <table>
                        <asp:DataList ID="dtlHTML" runat="server">
                            <HeaderTemplate>
                                <thead>
                                    <tr>
                                    
                                        <th style="text-align: left; padding-left: 10px;">
                                            Thuộc tính
                                        </th>
                                        <th>
                                            Gmail 
                                        </th>
                                        <th>
                                            YahooMail
                                        </th>
                                        <th>
                                            HotMail
                                        </th>
                                        <th>
                                            AolMail
                                        </th>
                                        <th>
                                            Outlook
                                        </th>
                                        <th> 
                                            Chức năng
                                        </th>
                                    </tr>
                                </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                      
                                        <td style="text-align: left; padding-left: 10px;">
                                            <asp:Label ID="lblAttr" runat="server" Text='<%# Eval("Attribute") %>' ></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGmail" runat="server" Text='<%# Eval("Gmail") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblYahooMail" runat="server" Text='<%# Eval("YahooMail") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblHotMail" runat="server" Text='<%# Eval("WindowsLiveMail2011") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAOLMail" runat="server" Text='<%# Eval("AOLMail") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblOutlook" runat="server" Text='<%# Eval("Outlook071013") %>'></asp:Label>
                                        </td>
                                          <td>
                                              <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/webapp/resource/images/edit-validated-icon.png"
                                              CommandArgument='<%# Eval("Attribute") %>' onclick="btnEdit_Click" />
                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                                    CommandArgument='<%# Eval("Attribute") %>'  
                                                  OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa thuộc tính này không ?')" 
                                                  onclick="btnDelete_Click" />
                                        </td>
                                    </tr>
                                </tbody>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:DataList>
                      <cc1:CollectionPager ID="dlPager" runat="server" 
                                                 ControlCssClass="hung" BackNextDisplay="HyperLinks" BackText="« Trước" 
                                    LabelText="Trang:" NextText="Sau »" 
                                    ResultsFormat="Hiện thị kết quả {0}-{1} ({2})" ResultsLocation="None">
                            </cc1:CollectionPager>
                    </table>
                    <%-- </form>--%>
                </div>
                    <%-- </form>--%>
                </div>
                
             
                <!-- end content-module-main -->
            </div>
</asp:Content>

