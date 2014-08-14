<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_XuatNhapSanPham_templates_Item" %>
<tr>
    <td class="">
        <a href="/lib/pages/XuatNhapSanPham/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.MaStr %>
        </a>
    </td>
    <td>
        <a href="/lib/pages/PhieuDichVu/Add.aspx?ID=<%=Item.PDV_ID %>">
            <%=Item.PDV_MaStr %>
        </a>
    </td>
    <td>
        <%if(Item.NgayXuat != DateTime.MinValue){ %>
            <%=Item.NgayXuat.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%=Item.NguoiXuat_Ten %>
    </td>

    <td>
        <%if(Item.NgayNhapDuKien != DateTime.MinValue){ %>
            <%=Item.NgayNhapDuKien.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%=Item.NguoiNhap_Ten %>
    </td>
    <td>
        <a href="/lib/pages/XuatNhapSanPham/Default.aspx?TrangThai=<%=Item.TrangThai %>">
            <%=Item.TrangThai_Ten %>
        </a>
    </td>    
</tr>