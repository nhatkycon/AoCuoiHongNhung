<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_KhoVay_templates_Item" %>
<%@ Import Namespace="linh.common" %>
<tr class="<%=Item.HetHang ? "danger" : "" %>">
    <td>
        <a href="/lib/pages/KhoVay/View.aspx?ID=<%=Item.ID %>">
            <%=Item.Ma %>
        </a>
    </td>
    <td>
        <a href="/lib/pages/KhoVay/View.aspx?ID=<%=Item.ID %>">
            <%=Item.Ten %>
        </a>
    </td>
    <td>
        <a href="/lib/pages/KhoVay/Default.aspx?ID=<%=Item.DM_ID %>">
            <%=Item.DM_Ten %>
        </a>
    </td>
    <td>
        <%=Lib.TienVietNam(Item.GNY) %>
    </td>
    <td>
        <%if(Item.HetHang){ %>
        Hết
        <%}else{ %>
        Còn
        <%} %>
    </td>
</tr>