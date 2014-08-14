<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Toc.ascx.cs" Inherits="lib_ui_PhieuDichVu_templates_Item_Toc" %>
<tr>
    <td class="">
        <a href="/lib/pages/PhieuDichVu/Add-Toc.aspx?ID=<%=Item.ID %>">
            <%=Item.MaStr %>
        </a>
    </td>
    <td>
        <%=Item.KH_Ten %>
    </td>
    <td>
        <%if (Item.TOC_NgayBatDau != DateTime.MinValue){ %>
            <%=Item.TOC_NgayBatDau.ToString("HH:mm") %>-<%=Item.TOC_NgayKetThuc.ToString("HH:mm") %> 
            <%=Item.TOC_NgayBatDau.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <a href="/lib/pages/PhieuDichVu/List-Toc?TrangThai=<%=Item.TrangThai %>">
            <%=Item.TrangThaistr %>
        </a>
    </td>
</tr>