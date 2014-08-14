<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Edit.ascx.cs" Inherits="lib_ui_BaiHat_templates_Item_Edit" %>
<tr data-savedUrl="/lib/ajax/BaiHat/Default.aspx">
    <td style="width: 60px;">
        <input data-pdvId="<%=Item.ID %>" type="text" class="form-control PhieuDichVuBaiHat-ThemChiTiet-Input" name="STT" value="<%=Item.STT %>"/>
        <input data-pdvId="<%=Item.ID %>" type="text" 
            class="form-control" style="display: none;" name="BH_ID" value="<%=Item.ID %>"/>
    </td>
    <td>
        <input data-pdvId="<%=Item.ID %>" type="text" class="form-control PhieuDichVuBaiHat-ThemChiTiet-Input" name="Ten" value="<%=Item.Ten %>"/>
    </td>            
    <td style="width: 60px;">
        <button data-id="<%=Item.ID %>" class="btn btn-default removeBtn">
            <i class="glyphicon glyphicon-remove-sign"></i>
        </button>
    </td>
</tr>  