<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControl.ascx.vb" Inherits="tinh_nang_he_thong_images_WebUserControl" %>
<asp:DataList ID="dtfunction" runat="server" RepeatColumns="1" Width="100%" >                   
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td style="text-align: left; padding-left: 10px;">
                                    <asp:Label ID="lblAttr" runat="server" Text='<%# Eval("functionName") %>'></asp:Label>
                                </td>
                               <td>
                                    <a href="packagefunction.aspx?id=<%# Eval("packageId") %>">
                                    <img src="../../resource/images/list-function.png" /></a>
                               </td>

                            </tr>
                            
                        </tbody>
                    </ItemTemplate>
                </asp:DataList>