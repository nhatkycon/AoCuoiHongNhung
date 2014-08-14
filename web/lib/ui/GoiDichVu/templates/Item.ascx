<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_GoiDichVu_templates_Item" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td class="">
        <a href="/lib/pages/GoiDichVu/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.Ten %>
        </a>
    </td>
    <td>
        <a href="/lib/pages/GoiDichVu/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.Ma %>
        </a>        
    </td>
    <td>
        <%=Lib.TienVietNam(Item.GNY) %>
    </td>            
</tr>  