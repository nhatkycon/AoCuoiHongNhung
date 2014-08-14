<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-DeNghiChuaDuyet.ascx.cs" Inherits="lib_ui_PhieuDichVu_templates_Item_DeNghiChuaDuyet" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td class="">
        <a href="/lib/pages/PhieuDichVu/Add-DeNghi.aspx?ID=<%=Item.ID %>">
            <%=Item.MaStr %>
        </a>
    </td>
    <td>
        <a href="/lib/pages/KhachHang/Add.aspx?ID=<%=Item.KH_ID %>">
            <%=Item.KH_Ten %>
        </a>
    </td>
    <td>
        <%=Item.CHUP_NhanVien_Ten %>
        <%if (Item.CHUP_NgayBatDau != DateTime.MinValue){ %>
            <%=Item.CHUP_NgayBatDau.ToString("HH:mm") %>-<%=Item.CHUP_NgayKetThuc.ToString("HH:mm") %> 
            <%=Item.CHUP_NgayBatDau.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%=Item.TOC_NhanVien_Ten %>
        <%if (Item.TOC_NgayBatDau != DateTime.MinValue){ %>
            <%=Item.TOC_NgayBatDau.ToString("HH:mm") %>-<%=Item.TOC_NgayKetThuc.ToString("HH:mm") %> 
            <%=Item.TOC_NgayBatDau.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%=Item.TD_NhanVien_Ten %>
        <%if (Item.TD_NgayBatDau != DateTime.MinValue){ %>
            <%=Item.TD_NgayBatDau.ToString("HH:mm") %>-<%=Item.TD_NgayKetThuc.ToString("HH:mm") %> 
            <%=Item.TD_NgayBatDau.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%=Item.PTS_NhanVien_Ten %>
        <%if (Item.PTS_NgayBatDau != DateTime.MinValue){ %>
            <%=Item.PTS_NgayBatDau.ToString("dd/MM") %>
        <%} %>
        <%if (Item.PTS_NgayBatDau != DateTime.MinValue){ %>
            - <%=Item.PTS_NgayKetThuc.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%=Item.TuVanVien_Ten %>
        <%=Item.NgayTuVan.ToString("dd/MM/yyyy") %>
    </td>
    <td>
        <%=Item.TrangThaistr %>
    </td>
</tr>