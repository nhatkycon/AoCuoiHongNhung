<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-ChoThueVay-Print.ascx.cs" Inherits="lib_ui_PhieuXuatNhapSanPhamChiTiet_templates_Item_ChoThueVay_Print" %>
<tr data-savedUrl="/lib/ajax/XuatNhapSanPham/Default.aspx">
    <td>
        <%=Item.HH_Ten %>
    </td>
    <td>
        <%=Item.SoLuong %>
    </td>            
    <td>
        <%if (Item.DaXuat)
        {%>
            <input class="DaXuat input-sm PhieuXuatNhapSanPhamChiTiet-ThemChiTiet-Input" checked="checked" disabled name="DaXuat" type="checkbox"/>
        <%}
        else
        {%>
            <input class="DaXuat input-sm PhieuXuatNhapSanPhamChiTiet-ThemChiTiet-Input" name="DaXuat" disabled type="checkbox"/>
        <% } %>
    </td>
    <td>
        <%if (Item.DaNhap)
        {%>
            <input class="DaNhap input-sm PhieuXuatNhapSanPhamChiTiet-ThemChiTiet-Input" disabled checked="checked" name="DaNhap" type="checkbox"/>
        <%}
        else
        {%>
            <input class="DaNhap input-sm PhieuXuatNhapSanPhamChiTiet-ThemChiTiet-Input" disabled name="DaNhap" type="checkbox"/>
        <% } %>
    </td>
    <td>
        . . . . . . . .
    </td>
</tr>    