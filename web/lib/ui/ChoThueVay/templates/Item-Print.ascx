<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Print.ascx.cs" Inherits="lib_ui_ChoThueVay_templates_Item_Print" %>
<%@ Register TagPrefix="uc1" TagName="ListPhieuDichVuPrint" Src="~/lib/ui/PhieuDichVuDichVu/List-PhieuDichVuPrint.ascx" %>
<%@ Register Src="~/lib/ui/PhieuXuatNhapSanPhamChiTiet/List-Print.ascx" TagPrefix="uc1" TagName="ListPrint" %>
<%@ Register Src="~/lib/ui/PhieuXuatNhapSanPhamChiTiet/List-ChoThueVay-Print.ascx" TagPrefix="uc1" TagName="ListChoThueVayPrint" %>


<%@ Import Namespace="linh.common" %>
<div class="print-frame">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td valign="top">
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
                            <%=Item.NgayTao.ToString("dd/MM/yyyy") %>         
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <h1 style="text-align: center;">
        CHO THUÊ VÁY
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
                Từ:
            </td>
            <td>
                <strong>
                    <%=Item.NgayBatDau.ToString("dd/MM/yyyy") %>
                </strong>
            </td>
            <td style="text-align: right; width: 80px;">
                Đến:
            </td>
            <td>
                <strong>
                    <%=Item.NgayKetThuc.ToString("dd/MM/yyyy") %>
                </strong>
            </td>
        </tr>
    </table>
    <h3>
        Chi tiết
    </h3>
    <table width="100%" cellpadding="5" cellspacing="0" class="border">
        <thead>
            <th>
                Sản phẩm
            </th>
            <th style="width: 80px;">
                Số lượng
            </th>            
            <th style="width: 30px;">
                Xuất
            </th>
            <th style="width: 30px;">
                Nhập
            </th>  
            <th style="width: 200px;">
                Ghi chú
            </th>
        </thead> 
        <tbody>
            <uc1:ListChoThueVayPrint runat="server" ID="ListPrint" /> <tr>
            <td>
                </td>
                <td>
                </td>
                <td style="text-align: right;">
                </td>
                <td style="text-align: right; font-weight: bold;">
                    Tổng:
                </td>
                <td style="text-align: right; font-weight: bold;">
                    <%=Lib.TienVietNam(Item.Tong) %>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="text-align: right;">
                    Đặt cọc:
                </td>
                <td style="text-align: right;font-weight: bold;">
                    <%=Lib.TienVietNam(Item.DatCong) %>
                </td>
                <td style="text-align: right;">
                    T.Toán:
                </td>
                <td style="text-align: right;font-weight: bold;">
                    <%=Lib.TienVietNam(Item.X_ThanhToan) %>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td style="text-align: right;">
                </td>
                <td style="text-align: right; font-weight: bold;">
                    Nợ:
                </td>
                <td style="text-align: right; font-weight: bold;">
                    <%=Lib.TienVietNam(Item.X_ConNo) %>
                </td>
            </tr>
        </tbody>
    </table>
    <p>
        <strong>Giấy tờ đặt cọc:</strong> <%=Item.GiayTo %>
    </p>
    <p style="text-align: right; font-style: italic;">
        Ngày <%=Item.NgayTao.ToString("dd") %> tháng <%=Item.NgayTao.ToString("MM") %> năm <%=Item.NgayTao.Year %>
    </p>
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td style="width: 33%; text-align: center; font-weight: bold;">
                KHÁCH HÀNG
                <br/><br/><br/><br/><br/>
            </td>
            <td style="width: 33%; text-align: center; font-weight: bold;">
                NGƯỜI XUẤT
            </td>
            <td style="text-align: center; font-weight: bold;">
                NGƯỜI NHẬP
            </td>
        </tr>
        <tr>
            <td style="text-align: center;">
                <i>
                </i>
            </td>
            <td style="text-align: center;">
                <i>
                </i>
            </td>
            <td>
                
            </td>
        </tr>
    </table>
</div>