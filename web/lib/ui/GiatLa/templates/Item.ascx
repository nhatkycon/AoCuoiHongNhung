<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_GiatLa_templates_Item" %>
<tr>
    <td class="">
        <a href="/lib/pages/GiatLa/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.MaStr %>
        </a>
    </td>
    <td>
        <a href="/lib/pages/GiatLa/Default.aspx?CH_ID=<%=Item.CH_ID %>">
            <%=Item.CH_Ten %>
        </a>
    </td>
    <td>
        <%if(Item.NgayBatDau != DateTime.MinValue){ %>
            <%=Item.NgayBatDau.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%=Item.NguoiXuat_Ten %>
    </td>

    <td>
        <%if(Item.NgayKetThuc != DateTime.MinValue){ %>
            <%=Item.NgayKetThuc.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%=Item.NguoiNhap_Ten %>
    </td>
    <td>
        <a href="/lib/pages/GiatLa/Default.aspx?TrangThai=<%=Item.TrangThai %>">
            <%=Item.TrangThai_Ten %>
        </a>
    </td>    
</tr>