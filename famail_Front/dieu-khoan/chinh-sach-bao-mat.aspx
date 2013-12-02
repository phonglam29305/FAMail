<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/baiviethtml.master" AutoEventWireup="true" CodeFile="chinh-sach-bao-mat.aspx.cs" Inherits="dieu_khoan_kiet" %>

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
                <li><a href="#tre-em"><i class="icon-chevron-right"></i>Trẻ em</a></li>
                <li><a href="#thong-tin-chung-toi-thu-thap"><i class="icon-chevron-right"></i>Thông tin Chúng tôi Thu thập</a></li>
                <li><a href="#chia-se-thong-tin-cua-ban"><i class="icon-chevron-right"></i>Chia sẻ Thông tin của bạn</a></li>
                <li><a href="#mat-khau"><i class="icon-chevron-right"></i>Mật khẩu</a></li>
                <li><a href="#thong-tin-ve-viec-su-dung-website"><i class="icon-chevron-right"></i>Thông tin về việc sử dụng website</a></li>
                <li><a href="#chinh-sach-gui-mail"><i class="icon-chevron-right"></i>Chính sách Gửi email</a></li>
                <li><a href="#chinh-sach-thong-tin-rieng-tu-cua-khach-hang"><i class="icon-chevron-right"></i>Chính sách Thông tin Riêng tư của Khách hàng</a></li>
                <li><a href="#bi-mat-thong-tin"><i class="icon-chevron-right"></i>Bí mật Thông tin</a></li>
                <li><a href="#bao-mat"><i class="icon-chevron-right"></i>Bảo mật</a></li>
                <li><a href="#binh-luan-y-kien-cua-khach-hang"><i class="icon-chevron-right"></i>Bình luận/Ý kiến của Khách hàng</a></li>
                <li><a href="#xem-thay-doi-hoac-xoa-thong-tin"><i class="icon-chevron-right"></i>Xem, Thay đổi hoặc Xóa Thông tin</a></li>
                <li><a href="#quy-dinh-khac"><i class="icon-chevron-right"></i>Quy định khác</a></li>
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
                     Là một nhà cung cấp dịch vụ trực tuyến chuyên nghiệp, FA Mail hiểu rằng người dùng luôn quan tâm đến việc thông tin
                     của họ được xử lý và chia sẻ như thế nào. Chúng tôi trân trọng sự tin tưởng của người dùng và thực hiện các hoạt
                     động này hợp pháp và cẩn thận. Bằng việc truy cập vào website của chúng tôi, bạn đang đồng ý và cho phép các hoạt 
                     động được mô tả trong Chính Sách Bảo Mật này. </br></br>
                     Chúng tôi tin rằng Chính Sách Bảo Mật này là quan trọng đối với các Khách Hàng của chúng tôi, để bạn biết được cách thức mà
                     chúng tôi thực hiện với các thông tin về bạn mà chúng tôi nhận được trong quá trình bạn truy cập vào website của chúng tôi. 
                     Chính Sách Bảo Mật này được lập ra để giúp bạn hiểu được cách chúng tôi thu thập, công bố và giữ an toàn các thông tin tổng
                     hợp chúng tôi nhận được khi bạn truy cập và duyệt trang web của chúng tôi. Chúng tôi khuyến khích bạn dành thời gian để đọc
                     Chính Sách Bảo Mật này của chúng tôi cũng như của các website khác bạn truy cập.</br></br>
                     FA Mail thực hiện tất cả những nỗ lực hợp lý để giữ cho các thông tin cá nhân người dùng công bố được bảo mật. 
                     Thông tin được thu thập thông qua theo dõi truy cập và form đăng ký sẽ không được chia sẻ hoặc bán cho một bên thứ ba nào khác
                     với bất kỳ mục đích nào mà không có sự cho phép của bạn, ngoài trừ các hoạt động được đề cập trong Chính Sách Bảo Mật này, 
                     hoặc trong trường hợp có hợp đồng riêng giữa bạn và FA Mail.</br></br>
                     Khi bạn truy cập vào website của chúng tôi, chúng tôi nhận được và có thể sẽ thu thập hai loại thông tin: 
                     (1) Thông tin về quá trình sử dụng website và Cookies, và (2) thông tin cá nhân của bạn.</br></br>
                     Khi bạn nhấn vào các đường link trên FA Mail.com, bạn có thể sẽ rời khỏi website của chúng tôi và chuyển tới một website 
                     bên ngoài. Chúng tôi không chịu trách nhiệm bảo mật cho các website bên ngoài này và chúng tôi khuyến khích bạn đọc chính
                     sách bảo mật của họ.</br></br>
                     Nếu bạn có bất kỳ câu hỏi nào về chính sách bảo mật của chúng tôi, hãy liên hệ với chúng tôi qua </br>
                     <a href="http://famail.fastautomaticmail.com">http://famail.fastautomaticmail.com</a>
                     </p>
                </div>
            </section>

            <section id="tre-em">
                <div class="page-header">
                    <h3>Trẻ em</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     Website này không dành cho trẻ em, đặc biệt là trẻ em dưới 13 tuổi. 
                     Trẻ em nếu truy cập vào website này phải có sự giám sát trực tiếp của cha mẹ.
                     </p>
                </div>
            </section>

            <section id="thong-tin-chung-toi-thu-thap">
                <div class="page-header">
                    <h3>Thông tin Chúng tôi Thu thập</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     FA Mail thu thập thông tin cá nhân từ Khách Hàng, những người truy cập vào website và đăng ký sử dụng Dịch Vụ của chúng tôi.
                     Khi Khách Hàng đăng ký sử dụng Dịch Vụ, chúng tôi yêu cầu cung cấp: (i) tên đăng nhập, (ii) mật khẩu, (iii) địa chỉ email, 
                     (iv) họ và tên, (v) số điện thoại liên hệ. Chúng tôi cũng có thể yêu cầu Khách Hàng cung cấp các thông tin bổ sung như
                     (i) tên công ty, (ii) chức danh, (iii) ngành nghề  hoặc các thông tin cá nhân khác. Chúng tôi sử dụng các thông tin đăng ký
                     của Khách Hàng để xác thực người dùng và cung cấp quyền truy cập vào Dịch Vụ của FA Mail. Chúng tôi cũng sử dụng địa chỉ email
                     trong thông tin đăng ký để liên hệ với Khách Hàng của chúng tôi. FA Mail có thể liên hệ với bạn qua email để thông báo với bạn 
                     những thay đổi về Dịch Vụ của chúng tôi, lịch bảo trì định kỳ, thông tin về FA Mail và các hoạt động xúc tiến từ FA Mail. 
                     Chúng tôi sẽ giữ thông tin của bạn chừng nào tài khoản của bạn còn hoạt động hoặc nhằm mục đích cung cấp dịch vụ cho bạn. 
                     Việc lưu giữ và sử dụng thông tin bạn là cần thiết để tuân thủ các nghĩa vụ pháp lý của chúng tôi và thực hiện thỏa thuận giữa 
                     chúng tôi.</br></br>
                     FA Mail sẽ sử dụng tất cả các nỗ lực hợp lý để cho bạn truy cập tự do vào các thông tin cá nhân của bạn trong phạm vi 
                     thích hợp. Bạn có thể thay đổi hoặc xóa các thông tin cá nhân bất cứ lúc nào bằng cách liên hệ với Dịch Vụ Hỗ Trợ Khách
                     Hàng của chúng tôi và chỉ rõ bạn muốn thay đổi, hủy bỏ hoặc xóa các thông tin như vậy. Bạn có thể đăng nhập vào tài khoản 
                     của bạn bất cứ lúc nào và thay đổi hoặc xóa các thông tin cá nhân chưa chính xác.</br></br>
                     Bạn đồng ý và hiểu rằng các thông tin của bạn được thu thập qua Website này và Dịch Vụ của FA Mail có thể được 
                     chuyển cho các cơ quan chức năng trong trường hợp theo yêu cầu của pháp luật.
                     </p>
                </div>
            </section>

            <section id="chia-se-thong-tin-cua-ban">
                <div class="page-header">
                    <h3>Chia sẻ Thông tin của bạn</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     FA Mail sẽ không chia sẻ, bán, cho thuê hoặc trao đổi thông tin cá nhân của bạn theo bất cứ cách thức nào khác với 
                     các hoạt động được công bố trong Chính Sách Bảo Mật này.</br></br>
                     Chúng tôi giữ quyền công bố các thông tin của bạn theo yêu cầu của pháp luật và khi chúng tôi tin rằng việc công bố 
                     là cần thiết để bảo vệ các quyền của chúng tôi và tuân thủ với các phán quyết toàn án, thủ tục pháp lý liên quan đến
                     Website của chúng tôi.
                     Chúng tôi sử dụng dịch vụ của một bên thứ ba như nhà cung cấp dịch vụ thanh toán, chuyển phát để cung cấp dịch vụ
                     cho bạn. Khi bạn đăng ký sử dụng dịch vụ của chúng tôi, chúng tôi sẽ chia sẻ các thông tin cần thiết tối thiểu cho 
                     bên thứ ba để họ cung cấp được dịch vụ của mình. Bên thứ ba bị nghiêm cấm sử dụng thông tin cá nhân của bạn cho các
                     mục đích xúc tiến thương mại.</br></br>
                     Nếu FA Mail tham gia vào việc mua bán, sát nhập, bán tất cả hoặc một phần tài sản của FA Mail, 
                     bạn sẽ được thông báo qua email và/hoặc thông báo trên Website của chúng tôi về bất kỳ sự thay đổi 
                     nào về quyền sở hữu hoặc sử dụng thông tin của bạn.
                     </p>
                </div>
            </section>

            <section id="mat-khau">
                <div class="page-header">
                    <h3>Mật khẩu</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     Thông tin tài khoản FA Mail, tên đăng nhập, mật khẩu và hồ sơ khách hàng được bảo vệ bằng mật khẩu, 
                     do đó bạn được bảo mật quyền truy cập sửa đổi các thông tin cá nhân. Người dùng có trách nhiệm bảo vệ 
                     mật khẩu của mình. Quyền truy cập vào Dịch Vụ của FA Mail được bảo vệ bằng một tên đăng nhập và mật khẩu
                     duy nhất mà chỉ mình bạn biết. FA Mail đã thiết lập quy trình bảo mật nội bộ mã hóa các mật khẩu của Khách
                     Hàng để bảo vệ nó khỏi bị lộ hoặc truy cập bởi bất kỳ ai khác ngoài bạn. Các nhân viên của FA Mail cũng không
                     thể biết hoặc truy cập vào mật khẩu của bạn. Không một nhân viên nào của FA Mail hỏi bạn về mật khẩu của bạn qua 
                     email, thư tín, điện thoại hay bất kỳ cách thức nào khác.
                     </p>
                </div>
            </section>

            <section id="thong-tin-ve-viec-su-dung-website">
                <div class="page-header">
                    <h3>Thông tin về việc sử dụng website</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     Máy chủ của chúng tôi tự động thu thập các thông tin về việc sử dụng website mỗi khi bạn truy cập vào website.</br></br>
                    Thông tin về việc sử dụng website, bao gồm nhưng không giới hạn các thông tin sau đây: tên miền, hệ điều hành bạn
                    dùng, trình duyệt và phiên bản, website dẫn bạn tới website của chúng tôi, và các thông tin tương tự khác. 
                    Các thông tin này được tổng hợp để đo lường số lượt truy cập, thời gian truy cập trung bình vào website, 
                    thời điểm truy cập, và các thông tin tương tự khác. Chúng tôi có thể sử dụng và công bố các thông tin về việc sử 
                    dụng website, ví dụ, để đo lường các dùng website, cải tiến nội dụng, giải thích các tiện ích của website và dịch vụ 
                    chúng tôi cung cấp, mở rộng các chức năng.</br></br>
                    Tương tự như các website thương mại khác, một kỹ thuật gọi là “cookies” sẽ được sử dụng  để cung cấp cho bạn 
                    thông tin nhằm đáp ứng nhu cầu cá nhân riêng.  Cookie là một phần dữ liệu mà một website gửi tới trình duyệt của bạn, 
                    có thể sẽ được lưu lại trên ổ cứng máy tính của bạn, nhờ đó chúng tôi có thể ghi nhận bạn khi bạn truy cập trở lại.
                    Bạn có thể thiết đặt trình duyệt để thông báo cho bạn khi bạn nhận được một cookie.  Cookie của chúng tôi thu thập các
                    thông tin chung để nâng cao khả năng phục vụ bạn và đo lường tính tiện ích của website chúng tôi. Chúng tôi không liên
                    kết thông tin chúng tôi lưu giữ trong cookie tới bất kỳ thông tin cá nhân nào bạn đã nhập trên website của chúng tôi. </br></br>
                    Việc sử dụng cookie bởi một đối tác phân tích website thứ ba không được đề cập bởi chính sách bảo mật của chúng tôi. 
                    Chúng tôi không truy cập hoặc kiểm soát vượt quá các cookie này. Các bên thứ ba này sử dụng phiên ID cookie để giúp
                    bạn điều hướng website của chúng tôi dễ hơn.</br></br>
                    Thông tin chúng tôi thu thập có thể được dùng để nâng cao việc sử dụng website của bạn, và để cung cấp dịch vụ mà 
                    bạn đã yêu cầu, sắp xếp website theo cách thân thiện với nhiều khách hàng nhất, đưa ra các ưu đãi đặc biệt, và/hoặc
                    phản hồi lại các câu hỏi và yêu cầu của bạn.</br></br>
                    Trong trường hợp bạn đăng ký sử dụng Dịch Vụ, thông tin cá nhân bao gồm các dữ liệu dùng để xác định bạn là một 
                    cá nhân nhất định, tức là tên bạn, địa chỉ email, số điện thoại, địa chỉ và/hoặc tên công ty và địa chỉ công ty.
                    Thông tin này sẽ được sử dụng để hoàn thành quá trình mở tài khoản, phản hồi câu hỏi của khách hàng, và/hoặc xác 
                    minh tính hợp lệ của câu hỏi, và để thực hiện nghiệp vụ thanh toán. FA Mail chỉ thu thập các thông tin cá nhân bạn 
                    tự nguyện cung cấp để đăng ký Dịch Vụ của FA Mail. FA Mail sẽ hướng dẫn rõ thông tin nào là bắt buộc phải cung cấp 
                    và thông tin nào bạn không cần công bố
                    </p>
                </div>
            </section>

            <section id="chinh-sach-gui-mail">
                <div class="page-header">
                    <h3>Chính sách Gửi email</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     Khi bạn gửi cho chúng tôi một email, chúng tôi sử dụng địa chỉ email của bạn để cảm ơn bạn đã góp ý và/hoặc phản
                     hồi lại câu hỏi của bạn, và chúng tôi sẽ lưu giữ các thông điệp liên hệ giữa bạn và chúng tôi và các thông điệp 
                     tương ứng tiếp theo.</br></br>
                     Khi bạn đồng ý nhận các thông tin về sản phẩm dịch vụ, chương trình khuyến mại, bản tin, thông cáo báo chí, chào
                     hàng của chúng tôi, chúng tôi sử dụng địa chỉ email của bạn và bất kỳ thông tin nào bạn cung cấp cho chúng tôi để 
                     cung cấp thông tin tới bạn, tới khi bạn yêu cầu chúng tôi dừng gửi đi các thông điệp này (bằng cách nhấn vào đường
                     link dừng nhận tin trong mỗi email chúng tôi gửi đi).</br></br>
                     Khi bạn yêu cầu thông tin hoặc các dịch vụ khác từ chúng tôi, chúng tôi sử dụng địa chỉ email của bạn và bất kỳ
                     thông tin nào bạn cung cấp cho chúng tôi để cung cấp thông tin hoặc dịch vụ khác mà bạn đã yêu cầu, tới khi bạn yêu
                     cầu dừng nhận tin hoặc tới khi thông tin hoặc dịch vụ không còn tồn tại.</br></br>
                     Chúng tôi sẽ không bao giờ sử dụng địa chỉ email hoặc các thông tin khác để gửi tới bạn bất kỳ thông điệp nào mà bạn
                     không yêu cầu nhận (trừ khi đó là một phần của dịch vụ mà bạn đang yêu cầu), cũng như không chia sẻ hoặc bán, cho thuê,
                     cho mượn tới bất kỳ một bên thứ ba nào.
                     </p>
                </div>
            </section>

            <section id="chinh-sach-thong-tin-rieng-tu-cua-khach-hang">
                <div class="page-header">
                    <h3>Chính sách thông tin Riêng tư của Khách hàng</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     FA Mail đề cao tầm quan trọng của việc tôn trọng tính riêng tư của những người đã tin tưởng giao thông tin nhạy
                     cảm của họ cho bạn. Chúng tôi luôn nỗ lực để giữ an toàn thông tin của họ. FA Mail sẽ không bao giờ sử dụng thông 
                     tin về các khách hàng bạn thu thập được và lưu trữ trong Dịch Vụ của chúng tôi để gửi đi bất cứ thông tin nào khác các
                     thông tin cung cấp bởi bạn, cũng như không chia sẻ hoặc bán cho bất cứ ai vì bất cứ mục đích gì.
                     </p>
                </div>
            </section>

            <section id="bi-mat-thong-tin">
                <div class="page-header">
                    <h3>Bí mật thông tin</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Chúng tôi giới hạn quyền truy cập vào các thông tin cá nhân của bạn trong các nhân viên của FA Mail và những người
                    cần được biết thông tin để hỗ trợ chúng tôi trong hoạt động kinh doanh, hoặc cung cấp dịch vụ tới bạn. Chúng tôi 
                    giữ an toàn các thông tin cá nhân theo các tiêu chuẩn và quy trình bảo mật, từ các thông tin điện tử đến thông tin 
                    vật lý. Chỉ các nhân viên cần thông tin để thực hiện nghiệp vụ riêng liên quan tới bạn mới có quyền truy cập vào thông 
                    tin cá nhân của bạn.
                     </p>
                </div>
            </section>

            <section id="bao-mat">
                <div class="page-header">
                    <h3>Bảo mật</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    FA Mail lưu trữ các máy chủ trong một môi trường máy chủ bảo mật cao, dưới sự giám sát chặt chẽ để ngăn cản 
                    các truy cập trái phép và bảo mật dữ liệu.</br></br>
                    Chúng tôi không thể đảm bảo tính bảo mật của các dữ liệu của bạn trong quá trình chúng đang được truyền tải qua 
                    Internet và qua các máy chủ nằm ngoài tầm kiểm soát của chúng tôi. Chúng tôi nỗ lực hết sức để bảo vệ thông tin
                    cá nhân của bạn nhưng FA Mail không thể đảm bảo hay cam kết sự bảo mật cho bất kỳ thông tin nào bạn đang truyền tới 
                    website của chúng tôi hoặc Dịch Vụ. Bất kỳ việc truyền tải dữ liệu nào bạn thực hiện qua Internet gây ra rủi ro của 
                    riêng bạn. Một khi chúng tôi đã nhận được giữ liệu được chuyển đến, chúng tôi sẽ thực hiện những nỗ lực cao nhất để
                    đảm bảo tính bảo mật trên hệ thống của chúng tôi.</br></br>
                    Nếu bạn sử dụng blog hoặc diễn đàn trên Website này, bạn nên nhận biết được rằng bất kỳ thông tin định cá nhân nào bạn
                    đăng lên đều có thể được đọc, thu thập, hoặc sử dụng bởi những người dùng khác trong blog và forum, và cũng có thể được
                    dùng để gửi cho bạn các email không được phép. Chúng tôi không chịu trách nhiệm cho những thông tin định danh cá nhận 
                    bạn đã chọn đăng lên blog và diễn đàn. Để yêu cầu xóa bỏ thông tin cá nhân của bạn từ blog hoặc diễn đàn của chúng tôi,
                    hãy liên hệ với chúng tôi tại http://famail.fastautomaticmail.com. Trong một số trường hợp, bạn sẽ không thể xóa bỏ 
                    thông tin cá nhân của bạn, trong trường hợp đó chúng tôi sẽ báo cho bạn chúng tôi không thể thực hiện và lý do tại sao. 
                    Chúng tôi có thể sẽ không hiển thị các thông tin được đăng bởi người dùng trên các blog, bài viết, diễn đàn thuộc quyền 
                    quản lý của FA Mail.
                    </p>
                </div>
            </section>

            <section id="binh-luan-y-kien-cua-khach-hang">
                <div class="page-header">
                    <h3>Bình luận/Ý kiến của Khách hàng</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Chúng tôi đăng các bình luận/ý kiến của khách hàng trên website của chúng tôi, có thể kèm theo các thông tin
                    mang tính định danh cá nhân. Chúng tôi sẽ hỏi sự chấp thuận của khách hàng qua email trước khi đăng tải bất cứ 
                    bình luận/ý kiến nào có kèm theo tên của khách hàng.
                    </p>
                </div>
            </section>

            <section id="xem-thay-doi-hoac-xoa-thong-tin">
                <div class="page-header">
                    <h3>Xem, Thay đổi hoặc Xóa Thông tin</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Bạn có thể thay đổi hoặc xóa thông tin hồ sơ của bạn vào bất cứ lúc nào bằng cách truy cập vào Tài Khoản và nhấn vào 
                    mục ‘Tài khoản của tôi’, sau đó thông tin sẽ được cập nhật. Vui lòng liên hệ với Dịch Vụ Hỗ Trợ Khách Hàng của chúng 
                    tôi nếu bạn cần hỗ trợ về cập nhật hoặc xem xét lại thông tin của bạn. FA Mail sẽ phản hồi lại bạn để xem xét thông 
                    tin trong vòng 10 ngày
                    </p>
                </div>
            </section>

            <section id="quy-dinh-khac">
                <div class="page-header">
                    <h3>Quy định khác</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Chúng tôi có thể thay đổi Chính Sách Bảo Mật này vào bất cứ lúc nào. Trừ khi có quy định khác, chính sách bảo mật
                    hiện hành của chúng tôi áp dụng cho tất cả các thông tin chúng tôi có về bạn và tài khoản của bạn. Nếu chúng tôi thực
                    hiện thay đổi Chính Sách Bảo Mật này, chúng tôi sẽ thông báo cho bạn tại Blog Email marketing FA Mail 
                   (http://famail.fastautomaticmail.com/blog) ngay khi sự thay đổi có hiệu lực.</br></br>
                    Nếu, tuy nhiên, FA Mail có ý định sử dụng thông tin cá nhân của người dùng theo một cách khác với cách thức tại thời
                    điểm chúng tôi thu thập giữ liệu, chúng tôi có trách nhiệm thông báo với bạn qua email. Người dùng có quyền lựa chọn
                    liệu chúng tôi có thể sử dụng thông tin của họ theo cách khác này hay không. Tuy nhiên, nếu người dùng đã ngừng tất cả 
                    các mối liên hệ với website của chúng tôi, hoặc tài khoản của họ đã xóa, thì họ sẽ không được thông báo, bất kể thông 
                    tin cá nhân của họ được sử dụng theo cách thức mới nào.
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

