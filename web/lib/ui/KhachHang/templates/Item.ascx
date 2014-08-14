<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_Bally_KhachHang_templates_Item" %>
<tr>
    <td class="">
        <a href="/lib/pages/<%=Item.TiemNang ? "TiemNang" : "KhachHang" %>/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.Ma %>
        </a>
    </td>
    <td class="">
        <a href="/lib/pages/<%=Item.TiemNang ? "TiemNang" : "KhachHang" %>/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.Ten %>
        </a>
    </td>
    <%--<td class="hidden-xs hidden-sm">
        <%=string.IsNullOrEmpty(Item.FacebookUid) ? "" : string.Format(@"<a target=""_blank"" href=""{0}"">{0}</a>", Item.FacebookUid)%>
    </td>--%>
    <td class="hidden-xs">
        <%=Item.DiaChi %>
    </td>
    <td class="hidden-xs">
        <%=Item.KhuVuc_Ten %>
    </td>
    <td class="">
        <%=Item.NguonGoc_Ten %>
    </td>
    <td class="hidden-xs">
        <%=Item.NgayTao.ToString("HH:mm dd/MM/yyyy") %>
    </td>
</tr>