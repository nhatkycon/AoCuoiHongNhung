<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Edit.ascx.cs" Inherits="lib_ui_PhieuXuatNhapSanPhamChiTiet_templates_Item_Edit" %>
<tr data-savedUrl="/lib/ajax/XuatNhapSanPham/Default.aspx">
    <td>
        <input type="text" class="form-control PhieuXuatNhapSanPhamChiTiet-ThemChiTiet-Input" 
            value="<%=Item.HH_Ten %>"/>
        <input type="text" 
            class="form-control" style="display: none;" name="PXNSPCT_ID" value="<%=Item.ID %>"/>
    </td>
    <td>
        <input type="text" class="form-control PhieuXuatNhapSanPhamChiTiet-ThemChiTiet-Input" name="SoLuong" value="<%=Item.SoLuong %>"/>
    </td>            
    <td>
        <%if (Item.DaXuat)
        {%>
            <input class="DaXuat input-sm PhieuXuatNhapSanPhamChiTiet-ThemChiTiet-Input" checked="checked" name="DaXuat" type="checkbox"/>
        <%}
        else
        {%>
            <input class="DaXuat input-sm PhieuXuatNhapSanPhamChiTiet-ThemChiTiet-Input" name="DaXuat" type="checkbox"/>
        <% } %>
    </td>
    <td>
        <%if (Item.DaNhap)
        {%>
            <input class="DaNhap input-sm PhieuXuatNhapSanPhamChiTiet-ThemChiTiet-Input" checked="checked" name="DaNhap" type="checkbox"/>
        <%}
        else
        {%>
            <input class="DaNhap input-sm PhieuXuatNhapSanPhamChiTiet-ThemChiTiet-Input" name="DaNhap" type="checkbox"/>
        <% } %>
    </td>
    <td>
        <button data-id="<%=Item.ID %>" class="btn btn-default removeBtn">
            <i class="glyphicon glyphicon-remove-sign"></i>
        </button>
    </td>
</tr>    