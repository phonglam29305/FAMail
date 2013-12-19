<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="webapp/resource/js/jquery-1.9.1.js"></script>
    <%--<script type="text/javascript">
        $(document).ready(function(){  
            $("#<%=DropDownList1.ClientID%>").change(function(){ 
                  var myparam= $("#<%=DropDownList1.ClientID%>").val();      
                        $.ajax({ 
                            type:"POST",
                            url:"Default2.aspx/CalculateCost",
                            data:'{param:"'+myparam+'"}',
                            contentType:"application/json; charset=utf-8",
                                success: function(data)
                                {       
                                    alert(data.d)
                                } 
                            }); 
                    });
        });  
    </script>--%>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $("#<%=DropDownList1.ClientID%>").change(function () { 
                var uname = $("#<%=DropDownList1.UniqueID%>");
                var msgbox = $("#status");
                $.ajax({
                   type: "POST",
                   url: "Default2.aspx/CalculateCost",
                   data: "{'args': '" + uname.val() + "'}",
                   contentType: "application/json; charset=utf-8",
                   dataType: "json",
                   success: function (msg) {
                        alert(msg.d);
                        }
                   });
                });
            });
    </script>--%>
    <script language="jscript" type="text/jscript">
        $(document).ready(function () {
            $("#<%=DropDownList1.ClientID%>").change(function () {
                var uname = $("#<%=DropDownList1.UniqueID%>");
                var value = uname.val();
                $.ajax({
                    type: "POST",
                    url: "Default2.aspx/sbGetData",
                    data: "{'sdPreNo':'" + value + "'}",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "JSON",
                    timeout: 10000,
                    success: function (msg) {
                        alert(msg.d);
                    },
                    error: function (xhr, status) {
                        alert(status + " - " + xhr.responseText);
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
        <asp:CheckBox ID="chk1" runat="server" />
    </div>
    </form>
</body>
</html>
