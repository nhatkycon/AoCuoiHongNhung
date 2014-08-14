<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListByNhanVien-Item.ascx.cs" Inherits="lib_ui_LichHen_templates_ListByNhanVien_Item" %>
<%@ Import Namespace="linh.common" %>
<tr class="<%=Item.ThanhCong ? "success " : "" %><%=Item.BoQua ? "danger " : "" %>">
    <td>
        <a href="/lib/pages/LichHen/View.aspx?ID=<%=Item.ID %>&ret=<%=Server.UrlEncode(Request.Url.PathAndQuery) %>">
            <%=Item.Ten %>            
        </a>
    </td>
    <td>
        <%=maHoa.DecryptString(Item.KH_Ten,Item.KH_ID.ToString()) %>
    </td>
    <td>
        <a href="?DM_ID=<%=Item.DM_ID %>">
            <%=Item.DM_Ten %>
        </a>
    </td>
    <td class="hidden-xs">
        <%=Item.NhanVien_Ten %>
    </td>
    <td>
        <%=Item.NgayBatDau.ToString("HH:mm") %>-<%=Item.NgayKetThuc.ToString("HH:mm") %> 
        <a href="?Ngay=<%=Item.NgayBatDau.ToString("dd/MM/yyyy") %>">
            <%=Item.NgayBatDau.ToString("dd/MM/yyyy") %>
        </a>
    </td>
</tr>