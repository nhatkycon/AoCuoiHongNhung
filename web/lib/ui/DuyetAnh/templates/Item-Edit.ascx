<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Edit.ascx.cs" Inherits="lib_ui_DuyetAnh_templates_Item_Edit" %>
<tr data-savedUrl="/lib/ajax/DuyetAnh/Default.aspx">
    <td style="width: 60px;">
        <input data-pdvId="<%=Item.ID %>" type="text" class="form-control PhieuDichVuDuyetAnh-ThemChiTiet-Input" name="ThuTu" value="<%=Item.ThuTu %>"/>
        <input data-pdvId="<%=Item.ID %>" type="text" 
            class="form-control" style="display: none;" name="DUYETANH_ID" value="<%=Item.ID %>"/>
    </td>
    <td>
        <input data-pdvId="<%=Item.ID %>" type="text" class="form-control PhieuDichVuDuyetAnh-ThemChiTiet-Input" name="Ten" value="<%=Item.Ten %>"/>
    </td>            
    <td>
        <input data-pdvId="<%=Item.ID %>" type="text" class="form-control PhieuDichVuDuyetAnh-ThemChiTiet-Input" name="GhiChu" value="<%=Item.GhiChu %>"/>
    </td>
    <td style="width: 60px;">
        <button data-id="<%=Item.ID %>" class="btn btn-default removeBtn">
            <i class="glyphicon glyphicon-remove-sign"></i>
        </button>
    </td>
</tr>    