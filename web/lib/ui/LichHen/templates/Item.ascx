<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_Bally_LichHen_templates_Item" %>
<%@ Import Namespace="linh.common" %>
<tr class="<%=Item.ThanhCong ? "success " : "" %><%=Item.BoQua ? "danger " : "" %>">
    <td>
        <a href="/lib/pages/LichHen/Add.aspx?ID=<%=Item.ID %>&ret=<%=Server.UrlEncode(Request.Url.PathAndQuery) %>">
            <%=Item.Ten %>            
        </a>
    </td>
    <td>
        <a href="/lib/pages/LichHen/?KH_ID=<%=Item.KH_ID %>">
            <%=maHoa.DecryptString(Item.KH_Ten,Item.KH_ID.ToString()) %>
        </a>
    </td>
    <td>
        <a href="/lib/pages/LichHen/?DM_ID=<%=Item.DM_ID %>">
            <%=Item.DM_Ten %>
        </a>
    </td>
    <td class="hidden-xs">
        <a href="/lib/pages/LichHen/?NHANVIEN_ID=<%=Item.NhanVien %>">
            <%=Item.NhanVien_Ten %>
        </a>
    </td>
    <td>
        <%=Item.NgayBatDau.ToString("HH:mm") %>-<%=Item.NgayKetThuc.ToString("HH:mm") %> 
        <a href="/lib/pages/LichHen/?Ngay=<%=Item.NgayBatDau.ToString("dd/MM/yyyy") %>">
            <%=Item.NgayBatDau.ToString("dd/MM/yyyy") %>
        </a>
    </td>
</tr>