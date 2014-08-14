<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-View.ascx.cs" Inherits="lib_ui_PhieuDichVuDichVu_templates_Item_View" %>
<%@ Import Namespace="linh.common" %>
<tr data-id="<%=Item.ID %>" data-savedUrl="/lib/ajax/PhieuDichVuDichVu/Default.aspx" class="<%=Item.DichVuThem ? "success" : "" %>">
    <td class="">
        <p class="form-control-static"><%=Item.HH_Ten %></p>
    </td>
    <td>
        <p class="form-control-static">
        <%=Item.ThuTu %>
            </p>
    </td>            
    <td>
        <p class="form-control-static">
        <%=Item.MoTa %>
            </p>
    </td>
    <td style="text-align: right;">
        <p class="form-control-static">
        <%=Lib.TienVietNam(Item.Gia) %>
            </p>
    </td>  
    <td style="text-align: right;">
        <p class="form-control-static">
        <%=Item.SoLuong %>
            </p>
    </td>
    <td style="text-align: right;">
        <p class="form-control-static">
        <%=Item.NhanVien_Ten %>
            </p>
    </td>
    <td style="text-align: right;">
        <p class="form-control-static">
        <%=Lib.TienVietNam(Item.Tien) %>
            </p>
    </td>    
</tr>    