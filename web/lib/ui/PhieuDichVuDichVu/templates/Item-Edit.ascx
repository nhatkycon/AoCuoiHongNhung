<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Edit.ascx.cs" Inherits="lib_ui_PhieuDichVuDichVu_templates_Item_Edit" %>
<%@ Import Namespace="linh.common" %>
<tr data-id="<%=Item.ID %>" data-savedUrl="/lib/ajax/PhieuDichVuDichVu/Default.aspx" class="<%=Item.DichVuThem ? "success" : "" %>">
    <td style="width: 200px;">
        <p class="form-control-static"><%=Item.HH_Ten %></p>
        <input data-id="<%=Item.ID %>" style="display: none;" type="text" class="form-control PhieuDichVuDichVu-ThemChiTiet-Input PDVDV_Id" name="PDVDV_Id" value="<%=Item.ID %>"/>
    </td>
    <td style="width: 60px;">
        <input data-id="<%=Item.ID %>" type="text" class="form-control PhieuDichVuDichVu-ThemChiTiet-Input ThuTu" name="ThuTu" value="<%=Item.ThuTu %>"/>
    </td>            
    <td>
        <input data-id="<%=Item.ID %>" type="text" class="form-control PhieuDichVuDichVu-ThemChiTiet-Input MoTa" name="MoTa" value="<%=Item.MoTa %>"/>
    </td>
    <td>
        <input data-id="<%=Item.ID %>" type="text" class="form-control PhieuDichVuDichVu-ThemChiTiet-Input Gia PhieuDichVuDichVu-ThemChiTiet-Input-El" name="Gia" value="<%=Lib.TienVietNam(Item.Gia) %>"/>
    </td>  
    <td>
        <input data-id="<%=Item.ID %>" type="text" class="form-control PhieuDichVuDichVu-ThemChiTiet-Input SoLuong PhieuDichVuDichVu-ThemChiTiet-Input-El" name="SoLuong" value="<%=Item.SoLuong %>"/>
    </td>
    <td class="input-group" style="width: 300px;">
            <span class="input-group-addon btn autocomplete-btn">
                <i class="glyphicon glyphicon-chevron-down"></i>
            </span>
            <input type="text" data-cached="1"  placeholder="Nhân viên" data-src="/lib/ajax/NhanVien/Default.aspx" data-refId="PDVDV_NhanVien" name="PDVDV_NhanVien_Ten" id="PDVDV_NhanVien_Ten" value="<%=Item.NhanVien_Ten %>" class="form-control PhieuDichVuDichVu-ThemChiTiet-Input form-autocomplete-input PDVDV_NhanVien_Ten">
            <input type="text" name="PDVDV_NhanVien" id="PDVDV_NhanVien" value="<%=Item.NhanVien %>" class="form-control PDVDV_NhanVien" style="display: none;">
    </td>
    <td>
        <input data-id="<%=Item.ID %>" type="text" class="form-control PhieuDichVuDichVu-ThemChiTiet-Input Tien" name="Tien" value="<%=Lib.TienVietNam(Item.Tien) %>"/>
    </td>    
    <td>
        <button data-id="<%=Item.ID %>" class="btn btn-default removeBtn">
            <i class="glyphicon glyphicon-remove-sign"></i>
        </button>
    </td>
</tr>    