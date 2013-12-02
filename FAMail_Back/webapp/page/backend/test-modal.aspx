<html lang="en">
<head>
  <meta charset="utf-8" />
  <title>jQuery UI Dialog - Modal form</title>
  <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
 <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

    

  <style>
    body { font-size: 62.5%; }
    label, input { display:block; }
    input.text { margin-bottom:12px; width:95%; padding: .4em; }
    fieldset { padding:0; border:0; margin-top:25px; }
    h1 { font-size: 1.2em; margin: .6em 0; }
    div#users-contain { width: 350px; margin: 20px 0; }
    div#users-contain table { margin: 1em 0; border-collapse: collapse; width: 100%; }
    div#users-contain table td, div#users-contain table th { border: 1px solid #eee; padding: .6em 10px; text-align: left; }
    .ui-dialog .ui-state-error { padding: .3em; }
    .validateTips { border: 1px solid transparent; padding: 0.3em; }
  </style>
  <script>
      $(function () {
          var name = $("#name"),
      email = $("#email"),
      password = $("#password"),
      allFields = $([]).add(name).add(email).add(password),
      tips = $(".validateTips");

          function updateTips(t) {
              tips
        .text(t)
        .addClass("ui-state-highlight");
              setTimeout(function () {
                  tips.removeClass("ui-state-highlight", 1500);
              }, 500);
          }


     
          $("#dialog-form").dialog({
              autoOpen: false,
              height: 400,
              width: 500,
              modal: true,
              buttons: {
               
                  Cancel: function () {
                      $(this).dialog("close");
                  }
              },
              close: function () {
                  allFields.val("").removeClass("ui-state-error");
              }
          });

          $("#create-user")
      .button()
      .click(function () {
          $("#dialog-form").dialog("open");
      });
      });
  </script>
</head>
<body>


 
<div id="dialog-form" title="Kiểm tra email mail của bạn với các từ khóa spam">
  <p class="validateTips">Thống kê nội dung các quy tắc vi phạm của mẫu email dạng HTML chi tiết như bên dưới:</p>
 
  <form>
  <fieldset>
    &nbsp;
      <div class="Heading2" 
          style="font-weight: bold; color: rgb(0, 0, 0); height: 16pt; background-color: rgb(237, 236, 236); padding: 4px 4px 4px 10px; background-image: url(http://www.sendlang.com/sendlang/interface/images/table_bg.gif); font-family: Tahoma, Arial; font-size: 11px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
          <div class="spamRuleBroken_row_rulename" 
              style="float: left; padding: 3px 0px 3px 5px;">
              Quy tắc vi phạm</div>
          <div class="spamRuleBroken_row_rulescore" 
              style="float: right; width: 80px; text-align: right; padding: 3px 15px 3px 5px;">
              Điểm</div>
          &nbsp;</div>
      <div class="spam_info spamRuleBroken_row" 
          style="padding: 4px 8px; background-color: rgb(249, 249, 249); display: block; clear: both; color: rgb(103, 103, 103); font-family: Tahoma, Arial; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
          <div class="spamRuleBroken_row_rulename" 
              style="float: left; padding: 3px 0px 3px 5px;">
              Những phần HTML và text khác</div>
          <div class="spamRuleBroken_row_rulescore" 
              style="float: right; width: 80px; text-align: right; padding: 3px 15px 3px 5px;">
              1.5</div>
          &nbsp;</div>
      <div class="spam_info spamRuleBroken_row" 
          style="padding: 4px 8px; background-color: rgb(249, 249, 249); display: block; clear: both; color: rgb(103, 103, 103); font-family: Tahoma, Arial; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
          <div class="spamRuleBroken_graph" 
              style="border: 1px solid gray; height: 5px; background-color: rgb(238, 238, 238);">
              <div class="spam_notspam" 
                  style="background-color: rgb(0, 255, 0); height: 5px; width: 165.296875px;">
                  <img height="5" 
                      src="http://www.sendlang.com/sendlang/feature_email_view/images/1x1.gif" 
                      width="1" /></div>
          </div>
          <div style="line-height: 1; margin-bottom: 5px;">
              <br />
              Nội dung được đánh giá cao nhất<span class="Apple-converted-space">&nbsp;</span><span 
                  style="font-size: 15px; font-weight: bold;">1.5</span><span 
                  class="Apple-converted-space">&nbsp;</span>trong ngưỡng cho phép là 5. Điều này 
              có nghĩa email của bạn sẽ được gửi đến đích, nhưng điều này không được bảo đảm 
              tuyệt đối nó chỉ có giá trị tham khảo.</div>
      </div>
      <div class="toolTipBox" 
          style="padding: 5px; margin-top: 10px; background-color: rgb(224, 236, 255); color: rgb(51, 51, 51); text-decoration: none; margin-bottom: 15px; font-family: Tahoma, Arial; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
          <img align="left" height="16" 
              src="http://www.sendlang.com/sendlang/interface/images/infoballon.gif" 
              width="20" />Thống kê nội dung các quy tắc vi phạm của &#39;<b>Tiêu đề gửi</b>&#39; 
          chi tiết như bên dưới:</div>
      <div class="Heading2" 
          style="font-weight: bold; color: rgb(0, 0, 0); height: 16pt; background-color: rgb(237, 236, 236); padding: 4px 4px 4px 10px; background-image: url(http://www.sendlang.com/sendlang/interface/images/table_bg.gif); font-family: Tahoma, Arial; font-size: 11px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
          <div class="spamRuleBroken_row_rulename" 
              style="float: left; padding: 3px 0px 3px 5px;">
              Quy tắc vi phạm</div>
          <div class="spamRuleBroken_row_rulescore" 
              style="float: right; width: 80px; text-align: right; padding: 3px 15px 3px 5px;">
              Điểm</div>
          &nbsp;</div>
      <div class="spam_info spamRuleBroken_row" 
          style="padding: 4px 8px; background-color: rgb(249, 249, 249); display: block; clear: both; color: rgb(103, 103, 103); font-family: Tahoma, Arial; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
          <div class="spamRuleBroken_row_rulename" 
              style="float: left; padding: 3px 0px 3px 5px;">
              Những phần HTML và text khác</div>
          <div class="spamRuleBroken_row_rulescore" 
              style="float: right; width: 80px; text-align: right; padding: 3px 15px 3px 5px;">
              1.5</div>
          &nbsp;</div>
      <div class="spam_info spamRuleBroken_row" 
          style="padding: 4px 8px; background-color: rgb(249, 249, 249); display: block; clear: both; color: rgb(103, 103, 103); font-family: Tahoma, Arial; font-size: 11px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px;">
          <div class="spamRuleBroken_graph" 
              style="border: 1px solid gray; height: 5px; background-color: rgb(238, 238, 238);">
              <div class="spam_notspam" 
                  style="background-color: rgb(0, 255, 0); height: 5px; width: 165.296875px;">
                  <img height="5" 
                      src="http://www.sendlang.com/sendlang/feature_email_view/images/1x1.gif" 
                      width="1" /></div>
          </div>
          <div style="line-height: 1; margin-bottom: 5px;">
              <br />
              Nội dung được đánh giá cao nhất<span class="Apple-converted-space">&nbsp;</span><span 
                  style="font-size: 15px; font-weight: bold;">1.5</span><span 
                  class="Apple-converted-space">&nbsp;</span>trong ngưỡng cho phép là 5. Điều này 
              có nghĩa email của bạn sẽ được gửi đến đích, nhưng điều này không được bảo đảm 
              tuyệt đối nó chỉ có giá trị tham khảo.</div>
      </div>
  </fieldset>
  </form>
</div>
 
 
<div id="users-contain" class="ui-widget">
  <h1>Existing Users:</h1>
  <table id="users" class="ui-widget ui-widget-content">
    <thead>
      <tr class="ui-widget-header ">
        <th>Name</th>
        <th>Email</th>
        <th>Password</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td>John Doe</td>
        <td>john.doe@example.com</td>
        <td>johndoe1</td>
      </tr>
    </tbody>
  </table>
</div>
<button id="create-user">Create new user</button>
  
    <button id="Button2" onclick="ShowCurrentTime()">Test</button>
</body>
</html>