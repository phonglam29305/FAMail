<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" CodeFile="PackageFunction.aspx.cs" Inherits="webapp_page_backend_Default" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="side-content fr">

        <!--start content 01-->
        <div class="content-module">
            <div class="content-module-heading cf">
                <h3 class="fl">Cài đặt chức năng cho gói dịch vụ</h3>
                <span class="fr expand-collapse-text">Thu vào</span>
                <span class="fr expand-collapse-text initial-expand">Mở ra</span>
            </div>
            <!-- end content-module-heading -->

            <div runat="server">
                <asp:CheckBoxList
                    ID="functionList"
                    runat="server"
                    ForeColor="AntiqueWhite"
                    BorderWidth="1"
                    BorderStyle="Double"
                    RepeatColumns="1">
                </asp:CheckBoxList>
               <asp:Button ID="btnFilter" runat="server" CssClass="button round blue image-right ic-save text-upper"
                                            OnClick="btnSave_Click" Text="Lưu" />

            </div>
        </div>
    </div>
</asp:Content>

