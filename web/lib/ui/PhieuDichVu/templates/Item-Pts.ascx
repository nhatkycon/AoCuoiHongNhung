<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Pts.ascx.cs" Inherits="lib_ui_PhieuDichVu_templates_Item_Pts" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td class="">
        <a href="/lib/pages/PhieuDichVu/Add-Pts.aspx?ID=<%=Item.ID %>">
            <%=Item.MaStr %>
        </a>
    </td>
    <td>
        <%=Item.KH_Ten %>
    </td>
    <td>
        <%if (Item.CHUP_NgayBatDau != DateTime.MinValue){ %>
            <%=Item.CHUP_NgayBatDau.ToString("HH:mm") %>-<%=Item.CHUP_NgayKetThuc.ToString("HH:mm") %> 
            <%=Item.CHUP_NgayBatDau.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%if (Item.PTS_NgayBatDau != DateTime.MinValue){ %>
            <%=Item.PTS_NgayBatDau.ToString("dd/MM") %>
        <%} %>
        <%if (Item.PTS_NgayBatDau != DateTime.MinValue){ %>
            - <%=Item.PTS_NgayKetThuc.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%if (Item.PTS_NgayXemMaket != DateTime.MinValue){ %>
            <%=Item.PTS_NgayXemMaket.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%if (Item.PTS_NgayCoSanPham != DateTime.MinValue){ %>
            <%=Item.PTS_NgayCoSanPham.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%if (Item.PTS_HenSanPham != DateTime.MinValue){ %>
            <%=Item.PTS_HenSanPham.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <a href="/lib/pages/PhieuDichVu/List-Pts.aspx?TrangThai=<%=Item.TrangThai %>">
            <%=Item.TrangThaistr %>
        </a>
    </td>
</tr>