﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-In-HopDongDichVu.ascx.cs" Inherits="lib_ui_PhieuDichVu_templates_Item_In_HopDongDichVu" %>
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
                    HỢP ĐỒNG DỊCH VỤ ÁO CƯỚI
                </h1>
                <p align="center">
                    Hợp đồng số: <strong><%=Item.MaStr %></strong>/HĐDV-HN
                </p>
            </td>
        </tr>
    </table>
    <p style="text-align: right; font-style: italic;">
        Hà Nội, ngày <%=Item.NgayTuVan.ToString("dd") %> tháng <%=Item.NgayTuVan.Month %> năm <%=Item.NgayTuVan.Year %>        
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
            <strong><i><%=Item._KhachHang.XungHo %></i> <%=Item._KhachHang.Ten %></strong>        
        </p>
        <p>
            CMTND <strong><%=Item._KhachHang.CMND %></strong> Công an <strong><%=Item._KhachHang.CMND_NoiCap %></strong> cấp ngày <strong><%=Item._KhachHang.CMND_NgayCap== DateTime.MinValue ? "" : Item._KhachHang.CMND_NgayCap.ToString("dd/MM/yyyy") %></strong>
        </p>
        <p>
            Điện thoại <strong><%=Item._KhachHang.Mobile %></strong> Địa chỉ <strong><%=Item._KhachHang.DiaChi %></strong>
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
        Bên A và bên B đồng ý hợp tác lên kế hoạch chụp ảnh cho bên A. Nội dung bao gồm:
    </p>
    <p>
        <strong>Tổng gói dịch vụ</strong>
        : <strong><%=Lib.TienVietNam(Item.TongTien) %> vnđ</strong>
    </p>
    <p>
        <strong>
            <i>(Bằng chữ: <%=Lib.So_chu(Item.TongTien) %>)</i>
        </strong>
    </p>
    
    <p>
        1/ Bên A đặt cọc trước <strong><%=Lib.TienVietNam(Item.DatCoc) %></strong> vnđ <strong><i>(Bằng chữ: <%=Lib.So_chu(Item.DatCoc) %>)</i></strong> để bên B lên kế hoach chụp ( Nếu bên A hủy hợp đồng thì số tiền này sẽ không hoàn lại)
    </p>
    <p>
        2/ Trước khi chụp ảnh, bên A phải thanh toán trước 80% tổng giá trị hợp đồng, 20% còn lại sẽ thanh toán sau khi lấy album.
    </p>
    <p>
        3/ Bên A sẽ được mượn váy cưới theo, áo dài ăn hỏi trong 3 ngày liên tiếp. Đặt cọc 5 triệu đồng đối với váy cưới và 1 triệu đồng đối với áo dài, số tiền
        này bên B sẽ trả lại bên A khi trả váy
    </p>
    <p>
        4/ Bên A và bên B có nghĩa vụ tuân thủ đúng nội dung đã thỏa thuận. Đảm bảo thời gian, địa điểm chụp ảnh, chất lượng ảnh…
    </p>
    <p>
        5/ Mọi chí phí phát sinh ( chụp thêm địa điểm, mặc thêm váy…) mà không có trong hợp đồng ( do nhu cầu bên A) thì bên A đều phải chi trả hoàn toàn.
    </p>
    <p>
        <em> Cảm ơn quý khách đã sử dụng dịch vụ của hồng Nhung Studio.</em>
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
