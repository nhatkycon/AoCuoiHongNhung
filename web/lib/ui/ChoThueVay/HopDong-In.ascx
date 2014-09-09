<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HopDong-In.ascx.cs" Inherits="lib_ui_ChoThueVay_HopDong_In" %>
<%@ Import Namespace="linh.common" %>
<div class="print-frame">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td valign="top" style="width: 180px;">
                <%=LogoStr %>
            </td>
            <td valign="top">
                <p align="center">
                    <strong>
                    CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM
                    </strong>
                </p>
                <p align="center">
                    Độc lập – Tự do – Hạnh phúc
                </p>
                <h1 align="center">
                    HỢP ĐỒNG CHO THUÊ TRANG PHỤC VÀ PHỤ KIỆN
                </h1>
                <p align="center">
                    Hợp đồng số: <strong><%=Item.MaStr %></strong>/HĐPK-HN
                </p>
            </td>
        </tr>
    </table>
    <p style="text-align: right; font-style: italic;">
        Hà Nội, ngày <%=Item.NgayTao.ToString("dd") %> tháng <%=Item.NgayTao.Month %> năm <%=Item.NgayTao.Year %>        
    </p>
    <p align="left">
        <br/>
        <br/>
        <strong>Chúng tôi gồm có:</strong>
    </p>
    <p>
        <strong>Bên A:</strong>
    </p>
    <div style="padding-left: 20px;">
        <p>
            <strong><i><%=Khach.XungHo %></i> <%=Khach.Ten %></strong>        
        </p>
        <p>
            CMTND <strong><%=Khach.CMND %></strong> Công an <strong><%=Khach.CMND_NoiCap %></strong> cấp ngày <strong><%=Khach.CMND_NgayCap== DateTime.MinValue ? "" : Khach.CMND_NgayCap.ToString("dd/MM/yyyy") %></strong>
        </p>
        <p>
            Điện thoại <strong><%=Khach.Mobile %></strong> Địa chỉ <strong><%=Khach.DiaChi %></strong>
        </p>
    </div>
    <p>
        <strong>Bên B </strong>
        :<strong> CÔNG TY TNHH ẢNH VIỆN ÁO CƯỚI HỒNG NHUNG</strong>
    </p>
    <div style="padding-left: 20px;">
        <p>
            Địa chỉ : <strong>16 K1 - Yên Lãng - Đống Đa - Hà Nội</strong>
        </p>
        <p>
            Điện thoại : <strong>(04) 85 89 83 18 Hotline: 0962 31 81 31</strong>
        </p>
        <p>
            Người đại diện : <strong>Nguyễn Thị Nhung</strong>
        </p>
    </div>
    <p>
        Sau khi thỏa thuận hai bên đồng ý kí kết hợp đồng hợp tác này với các điều khoản sau:
    </p>
    <p>
        <strong>
            <u>
                Điều 1: Nội dung của hợp đồng
            </u>
        </strong>
    </p>
    <div style="padding-left: 10px;">
        <p>
            Bên B cho bên A thuê, thuê ( mượn) trang phục theo bảng phụ lục hợp đồng này.
        </p>
        <p>
            Với số tiền cho thuê (mượn) là: <strong><%=Lib.TienVietNam(Item.Tong) %></strong>
        </p>
        <p>
            <strong>
                <i>(Bằng chữ: <%=Lib.So_chu(Item.Tong) %>)</i>
            </strong>
        </p>
        <p>
            Số tiền đặt cọc: <strong><%=Lib.TienVietNam(Item.DatCong) %></strong>
        </p>
        <p>
            <strong>
                <i>(Bằng chữ: <%=Lib.So_chu(Item.DatCong) %>)</i>
            </strong>
        </p>
        <p>
            Kèm theo giấy tờ: <%=Item.GiayTo %>
        </p>
    </div>
   <p>
        <strong>
            <u>
                Điều 2: Quyền lợi và nghĩa vụ của bên A
            </u>
        </strong>
    </p>
    <div style="padding-left: 10px;">
        <p>
            _ Thanh toán tiền thuê trang phục cho bên B đúng hạn
        </p>
        <p>
            _ Chịu toàn bộ chi phí theo quy định như bản phụ lục hợp đồng nếu phát sinh. Theo Phụ lục hợp đồng
        </p>
        <p>
            _ Bảo quản trang phục, tránh mất, hư hỏng. 
        </p>
    </div>
    
    <p>
        <strong>
            <u>
                Điều 3: Quyền lợi và nghĩa vụ của bên B
            </u>
        </strong>
    </p>
    <div style="padding-left: 10px;">
        <p>
            _ Thu phí của bên A theo quy định chung ( nếu có)
        </p>
        <p>
            _ Giữ gìn bảo quản giấy tờ của khách
        </p>
        <p>
            _ Giao trang phục áo cưới cùng toàn bộ phụ kiện liên quan đúng kiểu dáng và mã số
        </p>
        <p>
            _ Chịu trách nhiệm pháp lý về nguồn gốc và quyền cho thuê trang phục.
        </p>
        <p>
            Người liên hệ bên B: <strong>Nguyễn Công Hòa</strong>
        </p>
        <p>
            Chức vụ: <strong>phó Giám Đốc</strong>
        </p>
        <p>
            Email:<strong>anhvienhongnhung@gmail.com</strong>
        </p>
        <p>
            Điện thoại: <strong>0945.391.886  </strong>
        </p>
    </div>

    <p>
        Hợp đồng này có hiệu lực đến hết ngày .../.../<%=DateTime.Now.Year %>   và có thể được gia hạn khi hết hạn.
    </p>
    <table border="0" cellspacing="0" cellpadding="0" align="left" width="100%">
        <tbody>
            <tr>
                <td width="50%" valign="top">
                    <h2 align="center">
                        ĐẠI DIỆN BÊN A  
                    </h2>
                </td>
                <td  valign="top">
                    <h2 align="center">
                        ĐẠI DIỆN B
                    </h2>
                </td>
            </tr>
        </tbody>
    </table>
</div>
