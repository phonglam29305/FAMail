<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/backend.master" AutoEventWireup="true" CodeFile="generate.aspx.cs"
 Inherits="webapp_page_backend_mail_report" Title="FASTAUTOMATICMAIL" ValidateRequest="false" 
 %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<form id="form1" runat="server"> --%>

<!-- MAIN CONTENT -->
	<div id="content">		
		<div class="page-full-width cf">

			<div class="content-module">
			
				<div class="content-module-heading cf">
				
					<h3 class="fl">Tạo HTML</h3>
					<span class="fr expand-collapse-text">Click to collapse</span>
					<span class="fr expand-collapse-text initial-expand">Click to expand</span>
				
				</div> <!-- end content-module-heading -->				
				
				<div class="content-module-main">	
				    <em>Vui lòng chọn thông tin cần hiển thị</em>			    					
					<div class="stripe-separator"><!--  --></div>
					  <table>
					    <tr>
					        <td style="text-align:left">					           
                              <asp:Label ID="lblName" runat="server" Text="Họ và Tên"></asp:Label> 
					        </td>
					        <td>					          
                                 Không hiển thị&nbsp<asp:RadioButton Checked="true" ID="rdoName1" GroupName="Name" runat="server" />                                 
                                 Hiển thị&nbsp<asp:RadioButton ID="rdoName2" GroupName="Name" runat="server" />
					        </td>
					    </tr>
					    <tr>
					        <td style="text-align:left">					           
                              <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label> 
					        </td>
					        <td>					          
                                 Luôn hiển thị
					        </td>
					    </tr><tr>
					        <td style="text-align:left">					           
                              <asp:Label ID="lblJob" runat="server" Text="Nghề nghiệp"></asp:Label> 
					        </td>
					        <td>					          
                                 Không hiển thị&nbsp<asp:RadioButton Checked="true" ID="rdoJob1" GroupName="Job" runat="server" />                                 
                                 Hiển thị&nbsp<asp:RadioButton ID="rdoJob2" GroupName="Job" runat="server" />
					        </td>
					    </tr>
					    <tr>
					        <td style="text-align:left">					           
                              <asp:Label ID="lblCompany" runat="server" Text="Công ty"></asp:Label> 
					        </td>
					        <td>					          
                                 Không hiển thị&nbsp<asp:RadioButton Checked="true" ID="rdoCampany1" GroupName="Company" runat="server" />                                 
                                 Hiển thị&nbsp<asp:RadioButton ID="rdoCampany2" GroupName="Company" runat="server" />
					        </td>
					    </tr>
                        <tr>
					        <td style="text-align:left">					           
                              <asp:Label ID="lblGender" runat="server" Text="Giới tính"></asp:Label> 
					        </td>
					        <td>					          
                                 Không hiển thị&nbsp<asp:RadioButton Checked="true" ID="rdoGender1" GroupName="Gender" runat="server" />                                 
                                 Hiển thị&nbsp<asp:RadioButton ID="rdoGender2" GroupName="Gender" runat="server" />
					        </td>
					    </tr>
					    <tr>
					        <td style="text-align:left">					           
                              <asp:Label ID="lblPhone" runat="server" Text="Số điện thoại"></asp:Label> 
					        </td>
					        <td>					          
                                 Không hiển thị&nbsp<asp:RadioButton Checked="true" ID="rdoPhone1" GroupName="Phone" runat="server" />                                 
                                 Hiển thị&nbsp<asp:RadioButton ID="rdoPhone2" GroupName="Phone" runat="server" />
					        </td>
					    </tr>
					    <tr>
					        <td style="text-align:left">					           
                              <asp:Label ID="lblSecondPhone" runat="server" Text="Số điện thoại 2"></asp:Label> 
					        </td>
					        <td>					          
                                 Không hiển thị&nbsp<asp:RadioButton Checked="true"  ID="rdoSecondPhone1" GroupName="SecondPhone" runat="server" />                                 
                                 Hiển thị&nbsp<asp:RadioButton ID="rdoSecondPhone2" GroupName="SecondPhone" runat="server" />
					        </td>
					    </tr>
					    <tr>
					        <td style="text-align:left">					           
                              <asp:Label ID="lblAddress" Checked="true" runat="server" Text="Địa chỉ"></asp:Label> 
					        </td>
					        <td >					          
                                 Không hiển thị&nbsp<asp:RadioButton Checked="true" ID="rdoAddress1" GroupName="Address" runat="server" />                                 
                                 Hiển thị&nbsp<asp:RadioButton ID="rdoAddress2" GroupName="Address" runat="server" />
					        </td>
					    </tr>
					    <tr>
					        <td style="text-align:left"> 					           
                              <asp:Label ID="lblAddress2" runat="server" Text="Địa chỉ 2"></asp:Label> 
					        </td>
					        <td>					          
                                 Không hiển thị&nbsp<asp:RadioButton Checked="true" ID="rdoAddressTwo1" GroupName="Address2" runat="server" />                                 
                                 Hiển thị&nbsp<asp:RadioButton ID="rdoAddressTwo2" GroupName="Address2" runat="server" />
					        </td>
					    </tr>
					    <tr>
					        <td style="text-align:left">					           
                              <asp:Label ID="lblCity" runat="server" Text="Thành phố"></asp:Label> 
					        </td>
					        <td>					          
                                 Không hiển thị&nbsp<asp:RadioButton Checked="true" ID="rdoCity1" GroupName="City" runat="server" />                                 
                                 Hiển thị&nbsp<asp:RadioButton ID="rdoCity2" GroupName="City" runat="server" />
					        </td>
					    </tr>
					    <tr>
					        <td style="text-align:left">					           
                              <asp:Label ID="lblProvince" runat="server" Text="Tỉnh"></asp:Label> 
					        </td>
					        <td>					          
                                 Không hiển thị&nbsp<asp:RadioButton Checked="true" ID="rdoProvince1" GroupName="Province" runat="server" />                                 
                                 Hiển thị&nbsp<asp:RadioButton ID="rdoProvince2" GroupName="Province" runat="server" />
					        </td>
					    </tr>
					    <tr>
					        <td style="text-align:left">					           
                              <asp:Label ID="lblZipCode" runat="server" Text="Mã thành phố"></asp:Label> 
					        </td>
					        <td>					          
                                 Không hiển thị&nbsp<asp:RadioButton Checked="true" ID="rdoZipCode1" GroupName="ZipCode" runat="server" />                                 
                                 Hiển thị&nbsp<asp:RadioButton ID="rdoZipCode2" GroupName="ZipCode" runat="server" />
					        </td>
					    </tr>
					    <tr>
					        <td style="text-align:left">					           
                              <asp:Label ID="lblCountry" runat="server" Text="Quốc gia"></asp:Label> 
					        </td>
					        <td>					          
                                 Không hiển thị&nbsp<asp:RadioButton Checked="true" ID="rdoCountry1" GroupName="Country" runat="server" />                                 
                                 Hiển thị&nbsp<asp:RadioButton ID="rdoCountry2" GroupName="Country" runat="server" />
					        </td>
					    </tr>
					    <tr>
					        <td style="text-align:left">					           
                              <asp:Label ID="lblFax" runat="server" Text="Fax"></asp:Label> 
					        </td>
					        <td>					          
                                 Không hiển thị&nbsp<asp:RadioButton Checked="true" ID="rdoFax1" GroupName="Fax" runat="server" />                                 
                                 Hiển thị&nbsp<asp:RadioButton ID="rdoFax2" GroupName="Fax" runat="server" />
					        </td>
					    </tr>
					    <tr>
					      <td></td>
					      <td></td>
					    </tr>
					    <tr>
					      <td></td>
					      <td> </td>
					    </tr>
					  </table>
					  
					  <p>					    
                        <asp:Label for="textarea" Visible="false" ID="lblHTML" runat="server" Text="Phát sinh HTML Form"></asp:Label>			    
                        <asp:TextBox ID="txtHTML" Visible="false" CssClass="round full-width-textarea" 
                              runat="server" TextMode="MultiLine"></asp:TextBox>
						
					  </p>
					<div class="stripe-separator"><!--  --></div>
					 <asp:Button ID="btnContinute" runat="server" Text="Tiếp tục" 
                                CssClass="round blue ic-right-arrow" 
                        onclick="btnContinute_Click" />		
                         <asp:Button ID="btnBack" runat="server" Text="Quay lại" 
                                CssClass="button round blue image-right ic-refresh text-upper" 
                        onclick="btnBack_Click"   />
                        <asp:Button ID="btnBackEvent" runat="server" Text="Quay lại tạo sự kiện" 
                                CssClass="button round blue image-right ic-refresh text-upper" onclick="btnBackEvent_Click" 
                           />
				</div> <!-- end content-module -->
		
		</div> <!-- end full-width -->
			
	    </div> <!-- end content -->
	</div>
<%--</form>--%>
</asp:Content>

