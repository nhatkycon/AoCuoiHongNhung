<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-DichVuThem.ascx.cs" Inherits="lib_ui_BaoCao_templates_Item_DichVuThem" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td>
       <%=Item.HH_Ten %>
    </td>
    <td>
        <%=Item.NhanVien_Ten %>
    </td>            
    <td>
        <%=Item.TuVanVien_Ten %>
    </td>
    <td>
        <%=Item.PDV_Ma %>
    </td>
    <td>
        <%=Lib.TienVietNam(Item.Tien) %>
    </td>
    <td>
        <%=Item.NgayTao.ToString("dd/MM/yyyy") %>
    </td>
</tr>