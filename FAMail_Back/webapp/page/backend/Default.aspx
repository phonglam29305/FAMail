<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="webapp_page_backend_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <title></title>
    <script language="javascript" type="text/javascript" src="http://code.jquery.com/jquery-latest.js"></script>
    <script type="text/javascript">
        function beatHeart(times) {
            var interval = setInterval(function () {
                $(".heartbeat").fadeIn(500, function () {
                    $(".heartbeat").fadeOut(500);
                });
            }, 1000); // beat every second

            // after n times, let's clear the interval (adding 100ms of safe gap)
            setTimeout(function () { clearInterval(interval); }, (1000 * times) + 100);
        }
        $(function () {


            // just keeping beating 2 times, each 3 seconds
            setInterval(function () { beatHeart(2); }, 3000);

        });
    </script>
    <style>
    .heartbeat {
        /*position: absolute;*/
        display: none;
        margin: 5px;
        color: blue;
        /*right: 0;
        top: 0;*/
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="heartbeat">&hearts;</div>
    </form>
</body>
</html>
