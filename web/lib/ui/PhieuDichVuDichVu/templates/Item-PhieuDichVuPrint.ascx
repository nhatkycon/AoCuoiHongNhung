<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-PhieuDichVuPrint.ascx.cs" Inherits="lib_ui_PhieuDichVuDichVu_templates_Item_PhieuDichVuPrint" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td>
        <%=Item.HH_Ten %>
    </td>
    <td style="text-align: right;">
        <%=Lib.TienVietNam(Item.Gia) %>
    </td>
    <td style="text-align: right;">
        <%=Item.SoLuong %>
    </td>
    <td style="text-align: right;">
        <%=Lib.TienVietNam(Item.Tien) %>
    </td>
</tr>