<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Thu.ascx.cs" Inherits="lib_ui_ThuChi_templates_Item_Thu" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td>
        <a href="/lib/pages/ThuChi/Add-Thu.aspx?ID=<%=Item.ID %>&ret=<%=Server.UrlEncode(Request.Url.PathAndQuery) %>">
            <%=Item.Ma %>            
        </a>
    </td>
    <td>
        <a href="/lib/pages/PhieuDichVu/Add.aspx?ID=<%=Item.PDV_ID %>&ret=<%=Server.UrlEncode(Request.Url.PathAndQuery) %>">
            <%=Item.PDV_MaStr %>
        </a>
    </td>
    <td>
        <a href="/lib/pages/KhachHang/Add.aspx?ID=<%=Item.P_ID %>&ret=<%=Server.UrlEncode(Request.Url.PathAndQuery) %>">
            <%=Item.P_Ten %>
        </a>
    </td>
    <td>
        <a href="/lib/pages/ThuChi/List-Thu.aspx?NDTC_ID=<%=Item.NDTC_ID %>">
            <%=Item.NDTC_Ten %>
        </a>
    </td>
    <td>
        <%=Lib.TienVietNam(Item.SoTien) %>        
    </td>
     <td>
        <%=Item.Mota %>
    </td>
    <td>
        <a href="/lib/pages/ThuChi/List-Thu.aspx=<%=Item.NgayTrenPhieu.ToString("dd/MM/yyyy") %>">
            <%=Item.NgayTrenPhieu.ToString("dd/MM/yyyy") %>
        </a>
    </td>
</tr>