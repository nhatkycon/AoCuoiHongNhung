<%@ Control Language="C#" AutoEventWireup="true" CodeFile="In-PhieuDichVu.ascx.cs" Inherits="lib_ui_PhieuDichVu_In_PhieuDichVu" %>
<%@ Import Namespace="linh.common" %>
<%@ Register Src="~/lib/ui/PhieuDichVuDichVu/List-PhieuDichVuPrint.ascx" TagPrefix="uc1" TagName="ListPhieuDichVuPrint" %>

<div class="print-frame-a5">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td valign="top" style="width: 180px;">
                <%=LogoStr %>
            </td>            
            <td valign="top" style="width: 200px;">
                <table>
                    <tr>
                        <td style="width: 50px; text-align: right;">
                            Số:                
                        </td>
                        <td style="width: 150px; font-weight: bold;">
                            <%=Lib.FormatMa(Item.Ma) %>                
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            Ngày:                
                        </td>
                        <td style="font-weight: bold;">
                            <%=Item.NgayTuVan.ToString("dd/MM/yyyy") %>                
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            Tư vấn:                
                        </td>
                        <td style="font-weight: bold;">
                            <%=Item.TuVanVien_Ten %>                
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
        <h1 style="text-align: center;">
            PHIẾU DỊCH VỤ
        </h1>
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td style="text-align: right; width: 80px;">
                K/Hàng:
            </td>
            <td>
                <strong>
                    <%=Item.KH_Ten %>
                </strong>
            </td>
            <td style="text-align: right; width: 80px;">
                Gói:
            </td>
            <td>
                <strong>
                    <%=Item.GDV_Ten %>
                </strong>
            </td>
        </tr>
    </table>
    <h3>Dịch vụ:</h3>
    <table width="100%" cellpadding="5" cellspacing="0" class="border">
        <thead>
            <th>
                Tên
            </th>
            <th>
                Giá
            </th>
            <th>
                S.Lượng
            </th>
            <th>
                Tiền
            </th>
        </thead>
        <tbody>
            <uc1:ListPhieuDichVuPrint runat="server" ID="ListPhieuDichVuPrint" />
            <tr>
                <td>
                </td>
                <td style="text-align: right;">
                </td>
                <td style="text-align: right; font-weight: bold;">
                    Tổng:
                </td>
                <td style="text-align: right; font-weight: bold;">
                    <%=Lib.TienVietNam(Item.TongTien) %>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Đặt cọc:
                </td>
                <td style="text-align: right;font-weight: bold;">
                    <%=Lib.TienVietNam(Item.DatCoc) %>
                </td>
                <td style="text-align: right;">
                    Thanh toán:
                </td>
                <td style="text-align: right;font-weight: bold;">
                    <%=Lib.TienVietNam(Item.X_ThanhToan) %>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="text-align: right;">
                </td>
                <td style="text-align: right; font-weight: bold;">
                    Còn nợ:
                </td>
                <td style="text-align: right; font-weight: bold;">
                    <%=Lib.TienVietNam(Item.X_ConNo) %>
                </td>
            </tr>
        </tbody>
    </table>
    <h3>Ekip:</h3>
    <table width="100%" cellpadding="5" cellspacing="0" class="border">
        <%if (!string.IsNullOrEmpty(Item.CHUP_NhanVien_Ten))
          { %>
            <tr>
                <td style="text-align: right; font-weight: bold; width: 60px;">
                    Chụp:
                </td>
                <td>
                    <%=Item.CHUP_NhanVien_Ten %>
                </td>
                <td>
                    <%if (Item.CHUP_NgayBatDau != DateTime.MinValue){ %>
                        <%=Item.CHUP_NgayBatDau.ToString("HH:mm") %>-<%=Item.CHUP_NgayKetThuc.ToString("HH:mm") %> 
                        <%=Item.CHUP_NgayBatDau.ToString("dd/MM/yyyy") %>
                    <%} %>
                </td>
                <td>
                    <strong>Địa điểm:</strong> <%=Item.CHUP_DiaDiem %><br/>
                    <strong>Yêu cầu:</strong> <%=Item.CHUP_YeuCauKhach %>
                </td>
            </tr>
        <%} %>
        <%if (!string.IsNullOrEmpty(Item.TD_NhanVien_Ten)){ %>
            <tr>
                <td style="text-align: right; font-weight: bold">
                    T.Điểm:
                </td>
                <td>
                    <%=Item.TD_NhanVien_Ten %>
                </td>
                <td>
                    <%if (Item.TOC_NgayBatDau != DateTime.MinValue){ %>
                        <%=Item.TOC_NgayBatDau.ToString("HH:mm") %>-<%=Item.TOC_NgayKetThuc.ToString("HH:mm") %> 
                        <%=Item.TOC_NgayBatDau.ToString("dd/MM/yyyy") %>
                    <%} %>
                </td>
                <td valign="top">
                    <%if(Item.TD_NgoaiCanh){ %>                
                        <strong>Địa điểm:</strong> <%=Item.TD_DiaDiem %><br/>
                        <strong>K/C:</strong> <%=Item.TD_KhoangCach %> (<%=Lib.TienVietNam(Item.TD_PhiDiLai) %> )<br/>
                        <strong>Phải thu:</strong> <%=Lib.TienVietNam(Item.TD_KhoanPhaiThu) %><br/>
                    <%} %>
                </td>
            </tr>
        <%} %>
        <%if (!string.IsNullOrEmpty(Item.TOC_NhanVien_Ten))
          { %>
            <tr>
                <td style="text-align: right; font-weight: bold">
                    Tóc:
                </td>
                <td>
                    <%=Item.TOC_NhanVien_Ten %>
                </td>
                <td>
                    <%if (Item.TOC_NgayBatDau != DateTime.MinValue){ %>
                        <%=Item.TOC_NgayBatDau.ToString("HH:mm") %>-<%=Item.TOC_NgayKetThuc.ToString("HH:mm") %> 
                        <%=Item.TOC_NgayBatDau.ToString("dd/MM/yyyy") %>
                    <%} %>
                </td>
                <td>
                
                </td>
            </tr>
        <%} %>
        <%if (!string.IsNullOrEmpty(Item.PTS_NhanVien_Ten))
          { %>
            <tr>
                <td style="text-align: right; font-weight: bold">
                    PTS:
                </td>
                <td>
                    <%=Item.PTS_NhanVien_Ten %>
                </td>
                <td>
                    <%if (Item.PTS_NgayBatDau != DateTime.MinValue){ %>
                        <%=Item.PTS_NgayBatDau.ToString("dd/MM/yyyy") %>
                    <%} %>
                    <%if (Item.PTS_NgayKetThuc != DateTime.MinValue){ %>
                        - <%=Item.PTS_NgayKetThuc.ToString("dd/MM/yyyy") %>
                    <%} %>
                </td>
                <td>
                
                </td>
            </tr>
        <%} %>
    </table>
    <br/>
    
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td style="width: 33%; text-align: center; font-weight: bold;">
                KHÁCH HÀNG
                <br/><br/><br/><br/><br/>
            </td>
            <td style="width: 33%; text-align: center; font-weight: bold;">
                TƯ VẤN VIÊN
            </td>
            <td style="text-align: center; font-weight: bold;">
                QUẢN LÝ
            </td>
        </tr>
        <tr>
            <td style="text-align: center;">
                <i>
                    <%=Item.KH_Ten %>
                </i>
            </td>
            <td style="text-align: center;">
                <i>
                    <%=Item.TuVanVien_Ten %>
                </i>
            </td>
            <td>
                
            </td>
        </tr>
    </table>
</div>