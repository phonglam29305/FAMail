<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="chinh-sach-chong-thu-rac.aspx.cs" Inherits="chinh_sach_chong_thu_rac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container">
        <!-- Docs nav ================================================== -->
        <div class="row">
        <div class="span3 bs-docs-sidebar">
            <ul class="nav nav-list bs-docs-sidenav">
                <li><a href="#loi-mo-dau"><i class="icon-chevron-right"></i>Lời mở đầu</a></li>
                <li><a href="#thu-rac-la-gi"><i class="icon-chevron-right"></i>Thư rác là gì ?</a></li>
                <li><a href="#xac-nhan"><i class="icon-chevron-right"></i>Xác nhận</a></li>
                <li><a href="#noi-dung-email"><i class="icon-chevron-right"></i>Nội dung email</a></li>
                <li><a href="#ngung-nhan-tin"><i class="icon-chevron-right"></i>Ngừng nhận tin</a></li>
                <li><a href="#danh-tieng-tai-khoan"><i class="icon-chevron-right"></i>Danh tiếng tài khoản</a></li>
                <li><a href="#chuyen-nguoi-nhan-tin-sang-danh-sach-khac"><i class="icon-chevron-right"></i>Chuyển Người nhận tin sang danh sách khác</a></li>
                <li><a href="#thuc-thi-chinh-sach"><i class="icon-chevron-right"></i>Thực thi chính sách</a></li>
                <li><a href="#vi-pham-thoa-thuan"><i class="icon-chevron-right"></i>Vi phạm thỏa thuận</a></li>
                <li><a href="#blacklist"><i class="icon-chevron-right"></i>Chính sách đối với Người Nhận Tin, các ISP, Quản trị viên của các Blacklist</a></li>
            </ul>
        </div>
        <div class="span9" style="overflow:hidden;">
            <div style="height:531px;overflow-y:scroll;width:716px; ">
            <section id="loi-mo-dau">
                <div class="page-header">
                    <h3>Lời mở đầu</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     Bằng việc đăng ký sử dụng Dịch Vụ của FA Mail, Khách Hàng đồng ý sử dụng Dịch Vụ theo Chính Sách Chống Thư Rác
                     của chúng tôi dưới đây.</br></br>
                     FA Mail theo đuổi chính sách nói không với thư rác và không cho phép bạn gửi email thương mại tới các địa chỉ
                     email chưa đồng ý nhận tin bằng bất cứ cách thức nào. FA Mail yêu cầu và khuyến khích bạn thực hiện các hoạt 
                     động email marketing dựa trên sự cho phép của Người Nhận Tin.</br></br>
                     </p>
                </div>
            </section>
            <section id="thu-rac-la-gi">
                <div class="page-header">
                    <h3>Thư rác là gì ?</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     Thư rác, còn gọi la spam, junk mail, là các thông điệp email thương mại gửi đi khi chưa có sự đồng ý của người nhận,
                     đặc biệt là các email gửi đi với số lượng lớn. Chưa được sự đồng ý của người nhận có nghĩa là người nhận chưa xác 
                     nhận việc đồng ý nhận thông điệp email từ bạn. Email gửi đi với số lượng lớn nghĩa là các thông điệp email được gửi 
                     đi tới nhiều đi chỉ email có nội dung chính tương tự nhau. Khái niệm “gửi thư rác” mang ý nghĩa việc truyền, phát 
                     tán hoặc gửi đi bất kỳ thư từ email thương mại nào chưa có sự đồng ý của người nhận, đặc biệt là gửi với số lượng 
                     lớn. Bằng cách chỉ gửi email đến những người đã yêu cầu để được nhận nó, bạn đang tuân theo những hướng dẫn gửi email
                     hợp pháp, và Chính Sách Chống Thư Rác của FA Mail.</br></br>
                     <strong>Tôi có thể tự kiểm tra để chắc rằng mình không gửi thư rác bằng cách nào?</strong></br></br>
                     - Bạn có nhập danh sách có được từ việc đi mua hay thuê nào không?</br>
                     - Bạn có đang gửi đến các địa chỉ không rõ ràng như sales@domain.com , business@domain.com,
                     webmaster@domain.com , info@domain.com , hoặc các địa chỉ chung chung khác mà không rõ người nhận là ai không?</br>
                     - Bạn có địa chỉ email abuse@, postmaster@, hay hostmaster@ nào trong danh sách không?</br>
                     - Bạn có đang gửi tới các địa chỉ email mà nó sẽ tự chuyển tiếp email của bạn tới một nhóm các địa chỉ email khác?</br>
                     - Bạn có đang gửi email tới những người chưa đồng ý nhận tin từ bạn?</br>
                     - Tiêu đề (subject) email của bạn có chứa thông tin sai lệch hoặc không chính xác không?</br></br>
                     Nếu có bất kỳ câu trả lời nào là Có, bạn đang là một người gửi thư rác.</br></br>
                     <strong>Tại sao chúng ta phải chống thư rác?</strong></br></br>
                     Không một ai thích nhận thư rác. Nó là một gánh nặng cho các server mail và gây phiền toái cho tất cả những người 
                     nhận được nó. Nếu chúng tôi cho phép một khách hàng gửi đi thư rác thông qua máy chủ của chúng tôi hoặc không thực 
                     thi nghiêm chỉnh chính sách chống thư rác, địa chỉ IP và tên miền của chúng tôi sẽ bị rơi vào blacklist (danh sách đen).
                     Nhiều nhà cung cấp dịch vụ Internet (ISP) và dịch vụ lọc email sử dụng các blacklist này. Nếu một trong các máy chủ của 
                     chúng tôi bị đưa vào vào blacklist, tất cả các email gửi đi thông qua máy chủ này tới những người nhận tin dùng ISP 
                     hoặc hoặc dịch vụ lọc email sử dụng blacklist, email sẽ không nhận được.</br></br>
                     Điều này được áp dụng cho tất cả các khách hàng của chúng tôi. Một khi đã rơi vào blacklist, sẽ rất khó khăn và
                     thường không thể gỡ bỏ khỏi danh sách được. Vì thế, chúng tôi phải thực thi Chính Sách Chống Thư Rác rất nghiêm ngặt.</br></br>
                     <strong>Có luật nào hạn chế thư rác không</strong></br></br>
                     Có một số đạo luật hạn chế thư rác, như Nghị định 90 của Việt Nam, Đạo luật CAN-SPAM (CAN-SPAM Act) của Mỹ,
                     và nhiều đạo luật khác có thể được áp dụng tùy theo việc bạn gửi email tới Người Nhận Tin ở khu vực nào.
                     </p>
                </div>
            </section>
            <section id="xac-nhan">
                <div class="page-header">
                    <h3>Xác nhận</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     Người Nhận Tin có thể được thêm vào Tài Khoản của bạn trong Dịch Vụ bằng nhiều cách. Bạn phải có sự đồng ý của người
                     đăng ký nhận tin cho phép bạn xử lý dữ liệu của họ. Bạn không được phép gửi email tới bất kỳ người nào không bày 
                     tỏ mong muốn nhận được thông tin từ bạn. Chúng tôi cũng lưu ý rằng mong muốn của người nhận có thể không được 
                     suy đoán từ các văn bản của bạn. Ngoài ra, người nhận có thể rút lại sự đồng ý của họ bất cứ lúc nào. Chúng tôi
                     khuyến nghị sử dụng xác nhận kép “double opt-in” cho tất cả các Khách hàng. Đây là cách hiệu quả để ngăn các phàn
                     nàn thư rác và tăng chất lượng chiến dịch email của bạn.</br></br>
                     FA Mail không cho phép bạn thuê, mượn và/hoặc mua danh sách địa chỉ email từ một bên thứ ba, cũng như thu thập 
                     chúng qua các phương thức gian lận, như quét địa chỉ email trên mạng hoặc thu thập từ các nguồn trái phép. Việc 
                     sử dụng các giải pháp thu thập email tự động, phần mềm hoặc đoạn mã lệnh là tuyệt đối không được phép. Bạn có thể
                     lưu trữ, quản lý dữ liệu và gửi đi các thông điệp điện tử chỉ tới những người đã thể hiện sự đồng ý nhận các thông 
                     điệp như vậy từ bạn.
                     </p>
                </div>
            </section>
            <section id="noi-dung-email">
                <div class="page-header">
                    <h3>Nội dung email</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     Bạn phải cung cấp thông tin chính xác và hợp lệ trong phần header của email, tức là phần “From” phải chỉ rõ về 
                     người gửi. Dòng tiêu đề (subject) phải phù hợp với nội dung email, không gây hiểu lầm cho Người Nhận Tin về mục
                     đích và nội dung của email.</br></br>
                     Email không được chứa bất kỳ nội dung thô tục hoặc trái phép nào.
                     </p>
                </div>
            </section>
            <section id="ngung-nhan-tin">
                <div class="page-header">
                    <h3>Ngừng nhận tin</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     Mỗi email gửi đi từ Tài Khoản FA Mail có chứa một đường link ngừng nhận tin không thể xóa bỏ. Đường link này sẽ
                     tự động cập nhật vào danh sách địa chỉ email để đảm bảo rằng người đăng ký nhận tin sẽ không phải nhận các email 
                     tiếp theo. Bạn không được phép gửi email tới bất kỳ cá nhân nào đã được thêm vào danh sách email của bạn, nhưng 
                     sau đó yêu cầu ngừng nhận tin từ bạn. FA Mail tự động xử lý tất cả các yêu cầu ngừng nhận tin từ bạn. Danh sách 
                     các cá nhân muốn ngừng nhận tin được cung cấp ngay trong Tài Khoản của bạn.
                     </p>
                </div>
            </section>
            <section id="danh-tieng-tai-khoan">
                <div class="page-header">
                    <h3>Danh tiếng tài khoản</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    FA Mail có nghĩa vụ thực hiện các hành động cần thiết theo Chính Sách Danh Tiếng để nhận biết và cảnh báo các 
                    vi phạm, ngăn chặn những Tài Khoản vi phạm quy định hoặc có chất lượng gửi email kém không gây ảnh hưởng tới 
                    những Tài Khoản tốt và cả hệ thống của FA Mail. Chỉ số danh tiếng của bạn được công khai trong tài khoản của bạn.
                    Khi đồng ý sử dụng dịch vụ, bạn bảo đảm rằng đã hiểu và chấp nhận Chính Sách Danh Tiếng của FA Mail. Bạn có quyền 
                    được yêu cầu FA mail tư vấn để nâng cao chỉ số danh tiếng tài khoản của bạn.
                    </p>
                </div>
            </section>
            <section id="chuyen-nguoi-nhan-tin-sang-danh-sach-khac">
                <div class="page-header">
                    <h3>Chuyển Người nhận tin sang danh sách khác</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     Xin lưu ý rằng nếu một cá nhân đăng ký nhận tin từ một danh sách của bạn, điều đó KHÔNG cho phép bạn có quyền
                     chuyển người đó sang danh sách khác; hoặc gửi cho người đó nội dung khác với các nội dung đăng ký, ngay 
                     cả là gửi qua chính danh sách đó. Điều này là phù hợp với chính sách chống thư rác của chúng tôi.
                     </p>
                </div>
            </section>
            <section id="thuc-thi-chinh-sach">
                <div class="page-header">
                    <h3>Thực thi chính sách</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                     FA Mail thực hiện Chính Sách Chống Thư Rác nghiêm ngặt. Các biện pháp nghiêm ngặt mà chúng tôi đặt ra để thực hiện
                     Chính Sách Chống Thư Rác bao gồm:</br></br>
                      - Chúng tôi xem xét và theo dõi việc nhập các danh sách email lớn. Bao gồm xem xét nguồn gốc danh sách,
                      thời gian đã sử dụng danh sách, phương pháp thu thập và cách xác nhận.</br>
                      - Chúng tôi sử dụng các bản ghi MD5 nhận biết các danh sách email không hợp pháp thường được phát tán trên mạng.</br>
                       - Chúng tôi sử dụng một công cụ kiểm tra nội dung để theo dõi và đánh dấu bất cứ mẫu email nào chứa 
                      những từ thường được gửi tới các danh sách không hợp pháp.</br>
                      - Một bản ghi của mỗi email đã gửi đi qua hệ thống được lưu lại.</br>
                      Bất kỳ khách hàng nào bị phát hiện đang sử dụng FA Mail để gửi thư rác sẽ ngay lập tức bị cắt sử dụng dịch vụ.</br></br>
                      Mỗi email, dù là Text hay HTML, đều chứa một đường link ngừng nhận tin bắt buộc ở phía cuối email. 
                      Đường link này không thể gỡ bỏ.</br></br>
                      <strong>Thủ tục Xử lý Phàn nàn</strong></br></br>
                      Chúng tôi có một Chính Sách Chống Thư Rác nghiêm ngặt. Tài khoản của bạn sẽ bị chấm dứt ngay lập 
                      tức nếu bạn gửi thư rác. Thư rác được định nghĩa là email gửi tới những người bạn không có mối quan hệ làm việc hoặc chưa từng đăng ký nhận tin (opt-in) từ bạn. Vang Xa dành cho các doanh nghiệp và các tổ chức những người có một danh sách được thiết lập từ các địa chỉ email đã được phép, đã xác nhận opt-in. Chúng tôi chỉ cung cấp dịch vụ cho những người tuân thủ Chính Sách Chống Thư Rác.</br></br>
                      Khi nhận được phàn nàn từ người nhận email của bạn. Để xác định xem bạn đã vi phạm chính sách chống thư 
                      rác hay chưa, chúng tôi sẽ:</br></br>
                      - Xem lại nội dung các email</br>
                      - So sánh danh sách email của bạn với các danh sách thường được thu thập không hợp pháp</br>
                      - Xem lại các khiếu nại thư rác</br>
                      - Xem các bản ghi về thời điểm đăng ký nhận tin và IP của người nhận</br></br>
                      <strong>Thủ tục Xử lý Phàn nàn Không chính xác</strong></br></br>
                      Chúng tôi nhận thấy có khả năng những người đã đăng ký nhận tin từ bạn có thể đã quên rằng họ đã đăng ký.
                      Vì lý do này, chúng tôi lưu lại địa chỉ IP và ngày đăng ký cho tất cả những người đăng ký nhận tin mới. 
                      Nếu chúng tôi nhận được phàn nàn từ một người đăng ký nhận tin đã có bản ghi này và email được gửi tới họ 
                      chứa những nội dung họ đã đăng ký, thì chúng tôi sẽ thông báo cho người nhận ngày và máy tính mà họ đã đăng ký, 
                      và cung cấp một đường link để họ ngừng nhận tin từ bạn. Với loại phàn nàn này, chúng tôi sẽ thông báo cho bạn, 
                      giải thích những gì chúng tôi đã làm, và xem xét trang web của bạn và có thể đề nghị bạn thay đổi các thông báo 
                      hoặc các mô tả mà bạn cung cấp khi có người nhận tin đăng ký vào danh sách của bạn.</br></br>
                      Nếu người phàn nàn không đăng ký qua website của bạn (vd: được bạn nhập từ file vào hệ thống) sẽ không có bản
                      ghi IP hoặc ngày đăng ký. Trong trường hợp này, chúng tôi sẽ điều tra tình hình, xem email phàn nàn, và nếu
                      nó được xác định rằng có thể bạn đã gửi đi thư rác, chúng tôi sẽ ngay lập tức vô hiệu hóa chức năng gửi email
                      trong tài khoản của bạn và sẽ liên lạc với bạn bằng email và/hoặc điện thoại. Ngay khi chúng tôi trao đổi với bạn 
                      và có thể xác minh lại rằng người nhận tin đúng là đã đăng ký opt-in, chúng tôi sẽ bỏ việc chặn chức năng gửi.
                     </p>
                </div>
            </section>
            <section id="vi-pham-thoa-thuan">
                <div class="page-header">
                    <h3>Vi phạm thỏa thuận</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Bạn không được sử dụng Dịch Vụ để gửi đi email không được phép của người nhận. Chúng tôi bảo lưu quyền đưa ra cảnh báo
                    nếu phát hiện thấy bạn đang gửi thư rác hoặc sử dụng Dịch Vụ cho các hoạt động sai trái hoặc phạm pháp. Các biện pháp 
                    thích hợp, như tạm ngưng sử dụng Dịch Vụ, chấm dứt Tài Khoản mà không hoàn lại phí sẽ được thực hiện nếu bạn đã hoặc
                    đang thực hiện các hoạt động như vậy, bất kể cảnh báo rõ ràng của FA Mail.
                     </p>
                </div>
            </section>
            <section id="blacklist">
                <div class="page-header">
                    <h3>Chính sách đối với Người Nhận Tin, các ISP, Quản trị viên của các Blacklist</h3>
                </div>
                <div class="row-fluid">
                    <p style="text-align: justify; margin: 0px; -moz-user-select: text ! important; font-size:14; padding-top:20px">
                    Fa Mail có một Chính Sách Chống Thư Rác nghiêm ngặt. Tài khoản của người dùng sẽ bị chấm dứt nếu người dùng gửi 
                    đi các email không được phép của người nhận. Xin hãy thông báo bất kỳ nghi ngờ vi phạm nào về hòm
                    thư hotro@fastautomaticmail.com.</br></br>
                    Các ISP và Quản trị viên của các Blacklist cũng có thể liên hệ với chúng tôi qua hotro@fastautomaticmail.com.
                    Xin hãy chuyển tiếp cho chúng tôi toàn bộ email vi phạm, bao gồm cả phần header. Bạn cũng có thể gọi tới 
                    số 0917 890 550 để thông báo vi phạm.</br></br>
                    Nếu được, bạn hãy ngừng nhận tin bằng cách dùng đường link ở cuối email khi bạn không muốn nhận thêm email từ 
                    người gửi. Chúng tôi sẽ có hành động thích hợp đối với người gửi email vi phạm theo đúng Chính Sách Chống Thư Rác.
                    </p>
                </div>
            </section>
            </div>
        </div>
        </div>
</div>
</asp:Content>

