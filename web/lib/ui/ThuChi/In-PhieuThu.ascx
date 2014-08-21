<%@ Control Language="C#" AutoEventWireup="true" CodeFile="In-PhieuThu.ascx.cs" Inherits="lib_ui_ThuChi_In_PhieuThu" %>
<%@ Import Namespace="linh.common" %>
<div class="print-frame">
   <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td valign="top">
                <%=LogoStr %>
            </td>
            <td>
                <h1 style="text-align: center;">
                    PHIẾU THU
                </h1> 
            </td>
            <td valign="top" style="width: 200px;">
                <table>
                    <tr>
                        <td style="width: 100px; text-align: right;">
                            Số:                
                        </td>
                        <td style="width: 100px; font-weight: bold;">
                            <%=Item.Ma %>                
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            Ngày:                
                        </td>
                        <td style="font-weight: bold;">
                            <%=Item.NgayTrenPhieu.ToString("dd/MM/yyyy") %>                
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            Nhân viên:                
                        </td>
                        <td style="font-weight: bold;">
                            <%=Item.NguoiTao_Ten %>                
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <p>
        Người nộp tiền: <strong><%=Item.P_Ten %></strong>
    </p>
    <p>
        Địa chỉ:
    </p>
    <p>
        Lý do: <strong><%=Item.Mota %></strong>
    </p>
    <p>
        Số tiền: <strong><%=Lib.TienVietNam(Item.SoTien) %></strong> <i>(Viết bằng chữ: <%=Lib.So_chu(Item.SoTien) %> )</i>
    </p>
    <p>
        Kèm theo: .......................................................... Chứng từ kế toán: ....................................
    </p>
    <p style="text-align: right; font-style: italic;">
        Ngày <%=Item.NgayTrenPhieu.ToString("dd") %> tháng <%=Item.NgayTrenPhieu.ToString("MM") %> năm <%=Item.NgayTrenPhieu.Year %>
    </p>
    <br/>
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td style="width: 20%; text-align: center;">
                <strong>Giám đốc</strong>
                <br/><i>(ký, họ tên, đóng dấu)</i>
                <br/><br/><br/><br/><br/>
            </td>
            <td style="width: 20%; text-align: center;">
                <strong>Kế toán trưởng</strong>
                <br/><i>(ký, họ tên)</i>
            </td>
            <td style="width: 20%; text-align: center;">
                <strong>Người lập</strong>
                <br/><i>(ký, họ tên)</i>
            </td>
            <td style="width: 20%; text-align: center;">
                <strong>Thủ quỹ</strong>
                <br/><i>(ký, họ tên)</i>
            </td>
            <td style="width: 20%; text-align: center;">
                <strong>Người nộp tiền</strong>
                <br/><i>(ký, họ tên)</i>
            </td>
        </tr>
    </table>
</div>