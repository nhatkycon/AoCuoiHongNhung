<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Td.ascx.cs" Inherits="lib_ui_PhieuDichVu_templates_Item_Td" %>
<tr>
    <td class="">
        <a href="/lib/pages/PhieuDichVu/Add-Td.aspx?ID=<%=Item.ID %>">
            <%=Item.MaStr %>
        </a>
    </td>
    <td>
        <%=Item.KH_Ten %>
    </td>
    <td>
        <%if (Item.TD_NgayBatDau != DateTime.MinValue){ %>
            <%=Item.TD_NgayBatDau.ToString("HH:mm") %>-<%=Item.TD_NgayKetThuc.ToString("HH:mm") %> 
            <%=Item.TD_NgayBatDau.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <a href="/lib/pages/PhieuDichVu/List-Td.aspx?TrangThai=<%=Item.TrangThai %>">
            <%=Item.TrangThaistr %>
        </a>
    </td>
</tr>