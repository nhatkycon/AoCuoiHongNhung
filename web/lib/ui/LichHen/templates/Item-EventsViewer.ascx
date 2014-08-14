<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-EventsViewer.ascx.cs" Inherits="lib_ui_LichHen_templates_Item_EventsViewer" %>
<tr>
    <td>
        <a href="<%=Target %><%=Item.ID %>&ret=<%=Server.UrlEncode(Request.Url.PathAndQuery) %>">
            <%=string.Format(Item.Ten, Item.PDV_MaStr, Item.NhanVien_Ten, Item.KH_Ten) %>            
        </a>
    </td>
    <td>
        <%=Item.KH_Ten %>
    </td>
    <td >
        <%=Item.NhanVien_Ten %>
    </td>
    <td>
        <%if(Item.NgayBatDau.Hour > 0){ %>
            <%=Item.NgayBatDau.ToString("HH:mm") %>-<%=Item.NgayKetThuc.ToString("HH:mm") %> 
        <%} %>
        <%=Item.NgayBatDau.ToString("dd/MM/yyyy") %>
    </td>
</tr>