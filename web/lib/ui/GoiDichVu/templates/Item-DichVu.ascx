<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-DichVu.ascx.cs" Inherits="lib_ui_GoiDichVu_templates_Item_DichVu" %>
<%@ Import Namespace="linh.common" %>
<tr data-id="<%=Item.ID %>" data-savedUrl="/lib/ajax/GoiDichVu/Default.aspx">
    <td class="">
        <p class="form-control-static"><%=Item.HH_Ten %></p>
        <input data-id="<%=Item.ID %>" style="display: none;" type="text" class="form-control GoiDichVu-ThemChiTiet-Input ID" name="Id" value="<%=Item.ID %>"/>
    </td>
    <td>
        <input data-id="<%=Item.ID %>" type="text" class="form-control GoiDichVu-ThemChiTiet-Input ThuTu" name="ThuTu" value="<%=Item.ThuTu %>"/>
    </td>
    <td style="width: 120px;">
        <input data-id="<%=Item.ID %>" type="text" class="form-control GoiDichVu-ThemChiTiet-Input Gia" name="Gia" value="<%=Lib.TienVietNam(Item.Gia) %>"/>
    </td>
    <td>
        <input data-id="<%=Item.ID %>" type="text" class="form-control GoiDichVu-ThemChiTiet-Input SoLuong" name="SoLuong" value="<%=Item.SoLuong %>"/>
    </td>
    <td>
        <button data-id="<%=Item.ID %>" class="btn btn-default removeBtn">
            <i class="glyphicon glyphicon-remove-sign"></i>
        </button>
    </td>  
</tr>  