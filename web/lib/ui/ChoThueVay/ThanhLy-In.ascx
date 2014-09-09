<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThanhLy-In.ascx.cs" Inherits="lib_ui_ChoThueVay_ThanhLy_In" %>
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
                    BIÊN BẢN THANH LÝ HỢP ĐỒNG 
                </h1>
                <p align="center">                    
                    
                </p>
                
            </td>
        </tr>
    </table>
    <p>
        <i>
            Căn cứ vào Hợp đồng cho thuê trang phục và phụ kiện số <strong><%=Item.MaStr %></strong>/HĐPK-HN
                    ,  ngày <%=Item.NgayTao.ToString("dd/MM/yyyy") %>  giữa Công ty TNHH Ảnh Viện Áo Cưới Hồng Nhung và khách hàng:
        </i>
    </p>
    <p>
        <i>
            Hôm nay, ngày <%=DateTime.Now.Day %> tháng <%=DateTime.Now.Month %>  . năm .<%=DateTime.Now.Year %>, chúng tôi gồm:
        </i>
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
        Hai bên thống nhất ký biên bản thanh lý Hợp đồng cho thuê trang phục và phụ kiện số <strong><%=Item.MaStr %></strong>/HĐPK-HN
                    ,  ngày <%=Item.NgayTao.ToString("dd/MM/yyyy") %>
    </p>
    <p>
        <strong>
            <u>
                ĐIỀU 1: 
            </u>
        </strong>
    </p>
    <div style="padding-left: 10px;">
        <p>
            Bên B đã tiến hành lập biên bản thanh lý hợp đồng cho bên A theo đúng thỏa thuận trong hợp đồng 
            cho thuê trang phục và phụ kiện số <strong><%=Item.MaStr %></strong>/HĐPK-HN khi kết thúc hợp đồng
        </p>
        
    </div>
   <p>
        <strong>
            <u>
                ĐIỀU 2: Giá trị hợp đồng và phương thức thanh toán: 
            </u>
        </strong>
    </p>
    <div style="padding-left: 10px;">
        <p>
           Bên A đồng ý thanh toán cho Bên B mức phí dịch vụ :   <strong><%=Lib.TienVietNam(Item.Tong) %></strong>VNĐ<br />
Phương thức thanh toán:                Tiền mặt           Chuyển khoản 
Ngoài ra không phát sinh thêm chi phí khác
        </p>
    </div>
    
    <p>
        <strong>
            <u>
                ĐIỀU 3: 
            </u>
        </strong>
    </p>
    <div style="padding-left: 10px;">
        <p>
            Bên A đồng ý thanh toán toàn bộ số tiền trên cho Bên B theo như quy định 
Hai bên thống nhất thanh lý Hợp đồng cho thuê trang phục và phụ kiện số <strong><%=Item.MaStr %></strong>/HĐPK-HN ký ngày <%=Item.NgayTao.ToString("dd/MM/yyyy") %> giữa bên B và bên A. 
        </p>
    </div>

    <p>
        Biên bản thanh lý này được lập thành 02 bản mỗi bên giữ một bản và có giá trị pháp lý như nhau.
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
