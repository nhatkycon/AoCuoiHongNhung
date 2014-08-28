<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-PhieuDichVuView.ascx.cs" Inherits="lib_ui_ThuChi_templates_Item_PhieuDichVuView" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td>
        <%=Item.Ma %>
    </td>
    <td>
        <%=Item.NDTC_Ten %>
    </td>
    <td>
        <%=Lib.TienVietNam(Item.SoTien) %>        
    </td>
     <td>
        <%=Item.Mota %>
    </td>
    <td>
        <%=Item.NgayTrenPhieu.ToString("dd/MM/yyyy") %>
    </td>
</tr>