<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/baiviethtml.master" AutoEventWireup="true" CodeFile="quy-dinh-ve-su-dung-dich-vu.aspx.cs" Inherits="dieu_khoan_kiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            <link href="../css/custom-theme/bootstrap.min.css" rel="stylesheet" />
            <link href="../css/custom-theme/jquery-ui-1.10.0.custom.css" rel="stylesheet" />
            <link href="../css/custom-theme/font-awesome.min.css" rel="stylesheet" />
            
    <link href="../css/style.css" rel="stylesheet" />

            <!--[if IE 7]>
            <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css">
            <![endif]-->
            <!--[if lt IE 9]>
            <link rel="stylesheet" type="text/css" href="css/custom-theme/jquery.ui.1.10.0.ie.css"/>
            <![endif]-->
            <link href="../css/custom-theme/docs.css" rel="stylesheet" />
            <link href="../css/custom-theme/prettify.css" rel="stylesheet" />

            <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
            <!--[if lt IE 9]>
            <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
            <![endif]-->


    <div class="container">
        <!-- Docs nav ================================================== -->
        <div class="row">
        <div class="span3 bs-docs-sidebar">
            <ul class="nav nav-list bs-docs-sidenav">
                <li><a href="#loi-mo-dau"><i class="icon-chevron-right"></i>Lời mở đầu</a></li>
                <li><a href="#khai-niem"><i class="icon-chevron-right"></i>Khái niệm</a></li>
                <li><a href="#dich-vu"><i class="icon-chevron-right"></i>Dịch vụ</a></li>
                <li><a href="#chinh-sach-dung-thu-2-USD"><i class="icon-chevron-right"></i>Chính sách dùng thử 2USD dịch vụ</a></li>
                <li><a href="#dang-ky-va-su-dung-dich-vu"><i class="icon-chevron-right"></i>Đăng ký và sử dụng dịch vụ</a></li>
                <li><a href="#chinh-sach-thanh-toan"><i class="icon-chevron-right"></i>Chính sách thanh toán</a></li>
                <li><a href="#dich-vu-ho-tro-khach-hang"><i class="icon-chevron-right"></i>Dịch vụ hỗ trợ khách hàng</a></li>
                <li><a href="#yeu-cau-ky-thuat"><i class="icon-chevron-right"></i>Yêu cầu kỹ thuật</a></li>
                <li><a href="#cac-hoat-dong-noi-dung-khong-duoc-phep"><i class="icon-chevron-right"></i>Các hoạt động, nội dung không được phép</a></li>
                <li><a href="#huy-bo"><i class="icon-chevron-right"></i>Hủy bỏ</a></li>
                <li><a href="#cham-dut"><i class="icon-chevron-right"></i>Chấm dứt</a></li>
                <li><a href="#bao-mat"><i class="icon-chevron-right"></i>Bảo mật</a></li>
                <li><a href="#ban-quyen-va-nhan-hieu"><i class="icon-chevron-right"></i>Bản quyền và Nhãn hiệu</a></li>
                <li><a href="#kha-nang-tiep-can-dich-vu"><i class="icon-chevron-right"></i>Khả năng tiếp cận dịch vụ</a></li>
                <li><a href="#ben-thu-ba"><i class="icon-chevron-right"></i>Bên thứ ba</a></li>
            </ul>
        </div>
        <div class="span9">
            <!-- Download ================================================== -->
            <section id="loi-mo-dau">
                <div class="page-header">
                    <h3>Lời mở đầu</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Công ty Cổ phần FA Mail (“FA Mail” hoặc “chúng tôi”) là nhà cung cấp Dịch Vụ Email Marketing FA Mail (“Dịch Vụ”). 
                    Quy Định Về Sử Dụng Dịch Vụ này sẽ thiết lập các quy tắc về việc sử dụng Dịch Vụ và đảm bảo chất lượng Dịch Vụ của chúng tôi.
                    Khi đăng ký sử dụng Dịch Vụ, bạn (“bạn” hoặc “Khách Hàng”) đồng ý rằng đã hiểu Quy Định Về Sử Dụng Dịch Vụ này và 
                    cam kết tuân thủ theo đúng các quy định trong tài liệu này.
                     </p>
                </div>
            </section>

            <section id="khai-niem">
                <div class="page-header">
                    <h3>Khái niệm</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    - “Tài Khoản”: quyền truy cập vào công cụ FA Mail do FA Mail cung cấp cho bạn dưới dạng thông tin đăng nhập.</br>
                    - “Địa chỉ email Opt-in”: là địa chỉ email của những người nhận đã đồng ý nhận email và chưa yêu cầu ngừng nhận tin từ bạn.</br>
                    - “Email hỏng”: là các email được gửi trở lại cho người gửi vì địa chỉ của người nhận không tồn tại hoặc hiện tại không hoạt động.
                     </p>
                </div>
            </section>

            <section id="dich-vu">
                <div class="page-header">
                    <h3>Dịch Vụ</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     Dịch Vụ chúng tôi cung cấp cho bạn bao gồm:</br></br>
                     a. quyền truy cập vào công cụ dựa trên nền tảng web để xây dựng, quản lý và lưu trữ 
                     các danh sách địa chỉ email và các mẫu email.</br>
                     b. khả năng gửi email tới các danh sách địa chỉ email mà bạn lưu trữ tại công cụ của FA Mail</br>
                     c. dịch vụ hỗ trợ và tư vấn khách hàng</br>
                     d. các tính năng bổ sung, nếu bạn có yêu cầu và đã thanh toán chi phí phát sinh tương ứng.</br></br>
                     Để sử dụng Dịch Vụ, bạn phải có một tài khoản riêng trên nền tảng FA Mail. Tài Khoản này chỉ truy cập 
                     được bằng các thông tin đăng nhập của bạn.
                     </p>
                </div>
            </section>

            <section id="chinh-sach-dung-thu-2-USD">
                <div class="page-header">
                    <h3>Chính Sách Dùng Thử 2USD Dịch Vụ</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     Nhằm mục đích giúp Khách Hàng trải nghiệm được Dịch Vụ, FA Mail cung cấp một phiên bản Dịch Vụ dùng thử 2USD trong 
                     30 ngày (“Dùng Thử 2USD”). FA Mail khuyến khích Khách Hàng sử dụng phiên bản này trước khi sử dụng phiên bản có thu 
                     phí cao hơn để thử nghiệm Dịch Vụ.</br></br>
                     Dùng Thử 2USD không giới hạn số lượng email bạn được phép gửi đi. FA Mail cũng có thể giới hạn phiên bản này 
                     theo những cách khác.
                     Bạn có thể nâng cấp từ phiên bản Dùng Thử 2USD lên phiên bản có thu phí cao hơn bất cứ lúc nào. 
                     Ngay khi bạn nâng cấp thành công, thời hạn Dùng Thử 2USD sẽ kết thúc và không được cộng dồn vào thời
                     hạn sử dụng của phiên bản có thu phí cao hơn. Các tài khoản chưa nâng cấp lên phiên bản trả phí cao hơn khi 
                     kết thúc thời hạn dùng thử hoặc trong vòng 6 tháng sau khi thời hạn dùng thử kết thúc sẽ bị vô hiệu hóa.
                     </p>
                </div>
            </section>

            <section id="dang-ky-va-su-dung-dich-vu">
                <div class="page-header">
                    <h3>Đăng ký và sử dụng Dịch Vụ</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     Khi đăng ký sử dụng Dịch Vụ thành công phiên bản có thu phí hoặc Dùng Thử 2USD, bạn đã đồng ý:</br></br>
                     a. Tuân thủ Quy Định Về Sử Dụng Dịch Vụ này cũng như Chính Sách Chống Thư Rác và Chính Sách Bảo
                     Mật hoặc các phiên bản sửa đổi được công bố bởi FA Mail.</br>
                     b. Chỉ sử dụng Dịch Vụ để gửi các thông tin mà bạn có toàn quyền sử dụng và xuất bản trên Internet.</br>
                     c. Chỉ sử dụng Dịch Vụ để gửi email tới các địa chỉ email Opt-in</br>
                     d. Tuân thủ theo các quy định pháp luật liên quan đến việc gửi email</br>
                     e. Giữ bí mật thông tin đăng nhập bạn được cung cấp</br>
                     f. Cung cấp cho FA Mail thông tin liên lạc mới nhất của bạn để FA Mail thông báo và hỗ trợ bạn trong
                     quá trình sử dụng Dịch Vụ</br>
                     g. Nhận các email hướng dẫn sử dụng, giới thiệu thông tin về sản phẩm và dịch vụ của FA Mail</br>
                     </p>
                </div>
            </section>

            <section id="chinh-sach-thanh-toan">
                <div class="page-header">
                    <h3>Chính sách Thanh toán</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     Bạn có nghĩa vụ thanh toán đúng hạn tất cả các loại phí dịch vụ theo Gói Tài Khoản bạn sử dụng.
                     Chúng tôi đưa ra các hình thức thanh toán theo tháng, quý, nửa năm và hàng năm.</br></br>
                     FA Mail là dịch vụ trả trước, nghĩa là quyền truy cập vào Dịch Vụ được cung cấp cho bạn sau 
                     khi chúng tôi đã nhận phí dịch vụ được tính trên cơ sở Gói Tài Khoản bạn đã chọn. Chúng tôi sẽ 
                     cung cấp hóa đơn sử dụng dịch vụ trong vòng 10 ngày kể từ ngày nhận được đầy đủ khoản thanh toán.</br></br>
                     Tuy nhiên, với các khách hàng cần được xuất hóa đơn trước khi thanh toán, FA Mail áp dụng chính 
                     sách linh hoạt: cung cấp Tài Khoản cho bạn ngay sau khi kí hợp đồng, bạn cần thanh toán phí dịch vụ 
                     trong vòng 10 ngày kể từ ngày Tài Khoản của bạn được kích hoạt.
                     Hệ thống của chúng tôi tự động theo dõi số lượng email được gửi đi từ Tài Khoản của bạn. Bạn không 
                     thể gửi vượt quá số email tối đa của Gói Tài Khoản bạn đã đăng ký.</br></br>
                     Tài Khoản của bạn có thời hạn sử dụng theo Gói Tài Khoản bạn đã đăng ký. Kết thúc thời hạn này, 
                     số lượng email bạn chưa gửi đi không còn giá trị sử dụng. Chúng tôi đối xử với tất cả khách hàng công bằng, 
                     do đó chúng tôi không thực hiện bất cứ ngoại lệ nào cho chính sách này.</br></br>
                     Chúng tôi có quyền thay đổi phí Dịch Vụ bất cứ lúc nào bằng cách đăng bảng giá mới lên bảng gia Email
                     marketing FA Mail. Bảng giá mới áp dụng cho tất cả các Tài Khoản mới và nâng cấp.
                    </p>
                </div>
            </section>

            <section id="dich-vu-ho-tro-khach-hang">
                <div class="page-header">
                    <h3>Dịch Vụ Hỗ Trợ Khách Hàng</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     Chúng tôi cung cấp Dịch Vụ Hỗ Trợ Khách Hàng qua Email, Live Chat hoặc Điện Thoại. Khi liên hệ với Dịch Vụ Khách Hàng,
                     bạn cần cung cấp thông tin tối thiểu là tên tài khoản của bạn. Chúng tôi không phản hồi hay thực hiện bất cứ hành động
                     nào khi nhận được các yêu cầu hỗ trợ ”khuyết danh”. Thông tin liên hệ của Dịch Vụ Khách Hàng có tại famail.fastautomaticmail.com 
                     và trong phần “Hỗ Trợ” của Tài Khoản của bạn. Hầu hết các câu hỏi dịch vụ khách hàng được phản hồi trong vòng 24 giờ trong các ngày
                     làm việc. Bạn có quyền được thông báo về trạng thái quá trình xử lý yêu cầu hoặc khiếu nại của bạn.
                     </p>
                </div>
            </section>

            <section id="yeu-cau-ky-thuat">
                <div class="page-header">
                    <h3>Yêu cầu kỹ thuật</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Chúng tôi đảm bảo rằng Dịch Vụ sẽ hoạt động với phiên bản chính thức mới nhất của các trình duyệt Internet Explorer,
                    Mozilla Firefox, Google Chrome và Safari. Để dùng Dịch Vụ, bạn cần có một thiết bị cho phép bạn truy cập vào Internet, 
                    có một địa chỉ email để đăng ký Tài Khoản và một trình duyệt được cài đặt ở chế độ cho phép “cookies” và JavaScript.
                     </p>
                </div>
            </section>

            <section id="cac-hoat-dong-noi-dung-khong-duoc-phep">
                <div class="page-header">
                    <h3>Các hoạt động, nội dung không được phép</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Bạn không được phép sử dụng Dịch Vụ theo cách mà, dù cố ý hay vô ý, vi phạm bất cứ quy định quốc gia, quốc tế,
                    Quy Định Về Sử Dụng Dịch Vụ này và Chính Sách Chống Thư Rác của chúng tôi hoặc bản quyền hay quyền khác của một 
                    bên thứ ba. Chúng tôi xem các hành động sau đây là không được phép:</br></br>
                    a. Gửi thư rác hoặc các thông điệp không được yêu cầu khác vi phạm quy định pháp luật</br>
                    b. Gửi thông điệp tới bất cứ danh sách địa chỉ email nào có được từ đi mua hoặc thuê , hoặc do một bên thứ ba cung cấp trái phép</br>
                    c. Đưa vào trong email bất kỳ text, ảnh, đồ họa, logo, phần mềm, bài viết, âm thanh, video hoặc các nội dung khác vi 
                    phạm bản quyền của một bên thứ ba và các quyền liên quan đến bản quyền, nhãn hiệu, sáng chế, bí mật thương mại hoặc
                    các quyền sở hữu khác của bên thứ ba</br>
                    d. Gửi hoặc lưu trữ các tư liệu khiêu dâm, bao lực, lạm dụng, quấy rối, phỉ báng, bôi nhọ, vu khống, lừa đảo, 
                    gian lận, xâm phạm sự riêng tư của người khác hoặc vi phạm luật pháp hay các quy định và chính sách của FA Mail.</br>
                    e. Đặt liên kết tới thông qua Dịch Vụ tới các nội dung khiêu dâm, tư tưởng cực đoan, phân biệt chủng tộc, 
                    chính trị, lừa đảo qua email, hoặc bất kỳ tư liệu nào có thể xúc phạm một người cá nhân hoặc một tổ chức</br>
                    f. Gửi hoặc lưu trữ tư liệu có chứa nội dung độc hại, bao gồm, nhưng không giới hạn, phần mềm virus, 
                    trojan, sâu, bom thời gian, bot, spy-ware, hoặc bất kỳ các tập tin, các chương trình phần mềm khác với mục đích phá hoại hoặc truy cập trái phép vào dữ liệu của bên thứ ba</br>
                    g. Dùng Dịch Vụ theo bất cứ cách nào vi phạm chính sách của FA Mail hoặc pháp luật.</br></br>
                    Bạn không thể sử dụng bất kỳ thiết bị phần cứng hoặc phần mềm với ý định gây thiệt hại hoặc gây trở ngại đến tính 
                    chính xác và kịp thời của Dịch vụ, hoặc để đánh lừa bất kỳ hệ thống, dữ liệu nào từ Dịch Vụ cũng như bất kỳ 
                    trang web nào thuộc sở hữu hoặc điều hành bởi FA Mail.
                     </p>
                </div>
            </section>

            <section id="huy-bo">
                <div class="page-header">
                    <h3>Hủy bỏ</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Bạn có thể hủy bỏ Tài Khoản của bạn bất cứ lúc nào. Để hủy bỏ Tài Khoản, bạn cần liên hệ với Dịch Vụ Hỗ Trợ Khách Hàng
                    của FA Mail và xác nhận vào biên bản hủy bỏ tài khoản. Các yêu cầu hủy bỏ tài khoản qua email hoặc điện thoại mà chưa 
                    có biên bản xác nhận sẽ chưa được thực hiện hủy bỏ. Xin lưu ý rằng nếu bạn hủy bỏ Tài Khoản của bạn, Dịch Vụ bạn đang 
                    sử dụng sẽ bị chấm dứt ngay lập tức và tất cả dữ liệu của bạn (bao gồm Danh Sách Người Nhận Tin, các mẫu email và thống
                    kê) sẽ bị xóa bỏ vĩnh viễn. Hành động này không thể phục hồi lại được. Bạn không thể hủy bỏ Tài Khoản của bạn nếu chưa
                    thanh toán tất cả các hóa đơn.
                    </p>
                </div>
            </section>

            <section id="cham-dut">
                <div class="page-header">
                    <h3>Chấm dứt</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Chúng tôi có quyền chấm dứt hoặc tạm ngưng Dịch Vụ ngay lập tức và từ chối bất kỳ và tất cả việc sử dụng hiện tại 
                    và tương lai của Dịch Vụ trong trường hợp bạn vi phạm bất cứ quy định nào trong Quy Định Về Sử Dụng Dịch Vụ này. 
                    Các hoạt động sau bị chúng tôi xem là vi phạm:</br></br>
                    a. Không thanh toán các khoản phí khi đến hạn</br>
                    b. Sử dụng Dịch vụ cho các hoạt động phạm pháp hoặc bị cấm tại Điều 8 của Quy Định Về Sử Dụng Dịch Vụ này</br>
                    c. Khách Hàng bị thông báo là đang gửi thư rác bởi các tổ chức chống thư rác quốc gia, quốc tế</br>
                    d. Vi phạm các quy định về sử dụng nhãn hiệu của chúng tôi và các sở hữu trí tuệ khác</br>
                    </p>
                </div>
            </section>

            <section id="bao-mat">
                <div class="page-header">
                    <h3>Bảo Mật</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Quy trình bảo mật dữ liệu của chúng tôi được quy định trong Chính Sách Bảo Mật có tại:
                    <a href="chinh-sach-bao-mat.html">Bài viết bảo mật</a> và là một phần không thể tách rời của Quy Định Về Sử Dụng Dịch Vụ này. 
                    </p>
                </div>
             </section>

            <section id="ban-quyen-va-nhan-hieu">
                <div class="page-header">
                    <h3>Bản quyền và nhãn hiệu</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    FA Mail, Email Marketing FA Mail, fastautomaticmail.com là các nhãn hiệu của Công ty Cổ phần FA Mail. Các nhãn hiệu của FA Mail
                    không được phép sử dụng kết hợp với các sản phẩm hoặc dịch vụ của các đơn vị khác bằng bất cứ cách nào mà có thể gây ra nhầm lẫn 
                    cho các khách hàng hiện tại và khách hàng tiềm năng, hoặc bằng bất cứ cách nào có thể làm mất uy tín của FA Mail, các sản phẩm 
                    và/hoặc dịch vụ của FA Mail. Không có phần nào của website FA Mail.com được phép tái sản xuất và truyền lại dưới bất kỳ hình thức
                    nào hoặc bằng bất kỳ phương tiện nào mà không có sự đồng ý bằng văn bản của Công ty Cổ phần FA Mail.
                    </p>
                </div>
            </section>

            <section id="kha-nang-tiep-can-dich-vu">
                <div class="page-header">
                    <h3>Khả năng tiếp cận dịch vụ</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Chúng tôi đảm bảo khả năng tiếp cận Dịch Vụ ở mức 99.5% mỗi tháng trong điều kiện các dịch Internet và Viễn thông 
                    của chúng tôi được thông suốt. Chúng tôi không đảm bảo bất cứ  thời gian đáp ứng tối thiểu hoặc thời gian gửi 
                    email tối thiểu nào trong mối liên hệ với hiệu suất của Dịch Vụ.</br></br>
                    Chúng tôi có thể, theo quyết định riêng của chúng tôi và không chịu trách nhiệm, thay đổi hoặc sửa đổi các tính 
                    năng của Dịch Vụ hoặc sửa đổi hoặc thay thế bất cứ thiết bị nào được cung cấp, hoặc phần mềm được sử dụng để cung 
                    cấp Dịch Vụ, miễn là điều đó không có ảnh hưởng tiêu cực tới Dịch Vụ.</br></br>
                    Chúng tôi có thể thực hiện việc bảo trì theo lịch hoặc khẩn cấp (bao gồm tạm ngưng Dịch Vụ nếu cần thiết) 
                    để duy trì hoặc sửa đổi Dịch Vụ mà không thông báo trước với bạn. Tuy nhiên, trong trường hợp bảo trì theo 
                    lịch kéo dài hơn một ngày, chúng tôi sẽ sử dụng những nỗ lực hợp lý để thông báo cho bạn. Bảo trì theo lịch 
                    sẽ được thực hiện với mục tiêu giảm thiểu tối đa gián đoạn kinh doanh. Thời gian bảo trì Dịch Vụ sẽ được tình
                    bù với thời hạn sử dụng Tài Khoản của bạn, làm tròn tới đơn vị ngày.</br></br>
                    Chúng tôi cũng có quyền sửa đổi, thêm hoặc xóa bất kỳ tài liệu, thông tin, đồ họa hoặc nội dung khác xuất hiện 
                    trên hoặc trong mối liên hệ với trang web http://famail.fastautomaticmail.com, bất cứ lúc nào mà không cần thông báo trước.
                    </p>
                </div>
            </section>

            <section id="ben-thu-ba">
                <div class="page-header">
                    <h3>Bên thứ ba</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Nếu bạn cung cấp quyền truy cập vào Tài khoản của bạn cho bất kỳ bên thứ ba nào (“Bên Thứ Ba”), bạn phải chắc rằng:</br></br>
                    a. bạn được ủy quyền để thực hiện hành động đó</br>
                    b. bạn và Bên Thứ Ba đều bị ràng buộc bởi Quy Định Về Sử Dụng Dịch Vụ này</br>
                    c. Dịch Vụ Hỗ trợ Khách Hàng của FA Mail là dành cho bạn, không dành cho Bên Thứ Ba</br>
                    d. bạn chịu mọi trách nhiệm thay cho Bên Thứ Ba nếu Bên Thứ Ba không thực hiện nghĩa vụ của mình</br>
                    e. bạn không được cung cấp quyền truy cập cho Bên Thứ Ba bằng phương thức mua bán, nhượng lại hay dưới bất kỳ hình thức chuyển giao có tính thương mại nào mà không được sự đồng ý trước của FA Mail.
                    </p>
                </div>
            </section>

            <section id="gioi-han-va-trach-nhiem-phap-ly">
                <div class="row-fluid">
                    <h3>Giới hạn về trách nhiệm pháp lý</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Bạn chịu trách nhiệm cho việc sử dụng Dịch Vụ và trang web của chúng tôi, đặc biệt là đối với các nội dung bạn gửi 
                    thông qua công cụ FA Mail.</br></br>
                    Toàn bộ trách nhiệm của FA Mail, bất kể hình thức và nguyên nhân của hành động, trong mọi trường hợp được giới hạn
                    trong tổng sổ tiền được trả bởi Khách Hàng cho Dịch Vụ trong một tháng ngay trước ngày khách hàng thông báo cho FA Mail,
                    đối với tất cả các khiếu nại liên quan tới các Dịch Vụ được cung cấp bởi FA Mail cho Khách Hàng. Do đó, Khách Hàng loại
                    trừ FA Mail, nhân viên, giám đốc, người đại diện của FA Mail khỏi mọi nghĩa vụ, trách nhiệm và yêu cầu bồi thường vượt
                    quá giới hạn nói trên.</br></br>
                    Không bên nào chịu trách nhiệm cho bất kỳ sự chậm trễ hay thất bại nào trong thực hiện nghĩa vụ của mình theo Quy Định 
                    Về Sử Dụng Dịch Vụ này do Sự Kiện Bất Khả Kháng nằm ngoài tầm kiểm soát hợp lý của mỗi bên để đảm bảo thực hiện các
                    nghĩa vụ.</br></br>
                    Bạn đồng ý trả tiền, không làm phương hại, và miễn cho FA Mail, các nhân viên, giám đốc và người đại diện của FA Mail
                    từ mọi phí tổn và trách nhiệm pháp lý phát sinh từ các khiếu nại, tổn thất (kể cả trực tiếp và gián tiếp), thiệt
                    hại do sai phạm của bạn (hoặc bất kỳ cá nhân nào sử dụng thông tin người dùng của bạn do bạn cung cấp) khi tuân
                    thủ các nghĩa vụ của mình theo Quy Định Về Sử Dụng Dịch Vụ này hoặc vi phạm luật pháp, hoặc vi phạm các quyền 
                    của bất kỳ bên thứ ba nào, hoặc từ việc sử dụng hay truy cập của bạn tới website của FA Mail, hoặc từ các nội
                    dung bạn gửi đi thông qua FA Mail.
                    </p>
                </div>
            </section>

            <section id="quy-dinh-khac">
                <div class="page-header">
                    <h3>Quy định khác</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Chính Sách Chống Thư rác của FA Mail và Chính Sách Bảo Mật là một phần không thể tách rời của Quy Định Về Sử Dụng Dịch
                    Vụ này. Nếu bất kỳ điều khoản nào của Quy Định Về Sử Dụng Dịch Vụ này trái với hoặc không thể thực thi dưới pháp luật 
                    của bất kỳ chính phủ hoặc cấp có thẩm quyền nào, nó sẽ không ảnh hưởng đến tính hợp pháp, giá trị pháp lý, tính thực
                    thi của bất cứ điều khoản nào khác được quy định tại văn bản này và các điều khoản không có hiệu lực thực thi sẽ được
                    sửa đổi trong phạm vi cần thiết để làm cho nó có có hiệu lực thi hành mà không làm thay đổi mục đích ban đầu của điều 
                     khoản.</br></br>
                     FA Mail có quyền thay đổi bất kỳ điều khoản nào của của Quy Định Về Sử Dụng Dịch Vụ này vào bất cứ lúc nào bằng 
                     cách đăng các bản sửa đổi trên trang web của FA Mail và/hoặc bằng cách gửi email thông báo tới bạn đến địa chỉ 
                     email mới nhất bạn đã cung cấp cho FA Mail. Quy Định Về Sử Dụng Dịch Vụ này sẽ có hiệu lực ngay lập tức đối với
                     mọi hoạt động sử dụng mới hoặc tiếp tục sử dụng Dịch Vụ, trừ khi bạn chấm dứt Quy Định Về Sử Dụng Dịch Vụ này 
                     trong thời hạn 10 (mười) ngày. Phiên bản mới nhất của Quy Định Về Sử Dụng Dịch Vụ này có tại: 
                     http://famail.fastautomaticmail.com/docs/quy-dinh-ve-su-dung-dich-vu.html 
                    </p>
                </div>
            </section>



        </div>
    </div>
</div>

<!-- Placed at the end of the document so the pages load faster -->
            <script src="../Scripts/js/jquery-1.9.0.min.js"></script>
            <script src="../Scripts/js/bootstrap.min.js"></script>
            <script src="../Scripts/js/jquery-ui-1.10.0.custom.min.js"></script>
            <script src="../Scripts/js/prettify.js"></script>
            <script src="../Scripts/js/docs.js"></script>
            <script src="../Scripts/js/demo.js"></script>


</asp:Content>

