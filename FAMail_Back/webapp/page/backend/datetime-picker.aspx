<%@ Page Language="C#" AutoEventWireup="true" CodeFile="datetime-picker.aspx.cs" Inherits="webapp_page_backend_datetime_picker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test</title>
    
	<link rel="stylesheet" media="all" type="text/css" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
	<link rel="stylesheet" media="all" type="text/css" href="../../resource/other/datetimepicker/css/jquery-ui-timepicker-addon.css" />
</head>
<body>	
				
					<!-- ============= example -->
					<div class="example-container">
						<p>Add a simple datetimepicker to jQuery UI's datepicker</p>
						<div>
					 		<input type="text" name="basic_example_1" id="basic_example_1" value="" />
						</div>					
						
					</div>




		<script type="text/javascript" src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
		<script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.min.js"></script>
		<script type="text/javascript" src="../../resource/other/datetimepicker/jquery/jquery-ui-timepicker-addon.js"></script>
		<script type="text/javascript" src="../../resource/other/datetimepicker/jquery/jquery-ui-sliderAccess.js"></script>

		<script type="text/javascript">
			
			$(function(){
				 $('#basic_example_1').datetimepicker();				
			});
			
		</script>

	
	</body>
</html>
