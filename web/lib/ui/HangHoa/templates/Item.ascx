<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_HangHoa_templates_Item" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td class="">        
        <a href="/lib/pages/HangHoa/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.Ten %>
        </a>
    </td>
    <td>
        <a href="/lib/pages/HangHoa/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.Ma %>
        </a>
    </td>
    <td>
        <a href="/lib/pages/HangHoa/Default.aspx?DM_ID=<%=Item.DM_ID %>">
            <%=Item.DM_Ten %>            
        </a>
    </td>
    <td>
        <%=Lib.TienVietNam(Item.GNY) %>
    </td>
    <td>
        <%=Item.SoLuong %>
    </td>
    <td>
        <%if (Item.HetHang)
        {%>
            <input disabled class="Hetdang input-sm" id="Hetdang" checked="checked" name="Hetdang" type="checkbox"/>
        <%}
        else
        {%>
            <input disabled class="Hetdang input-sm" id="Checkbox1" name="Hetdang" type="checkbox"/>
        <% } %>
    </td>
</tr>