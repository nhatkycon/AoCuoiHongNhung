<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-PhieuDichVu.ascx.cs" Inherits="lib_ui_ThuChi_templates_Item_PhieuDichVu" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td>
        <a href="/lib/pages/ThuChi/Add-Thu.aspx?ID=<%=Item.ID %>&ret=<%=Server.UrlEncode(Request.Url.PathAndQuery) %>">
            <%=Item.Ma %>            
        </a>
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
        <a href="/lib/pages/ThuChi/List-Thu.aspx=<%=Item.NgayTrenPhieu.ToString("dd/MM/yyyy") %>">
            <%=Item.NgayTrenPhieu.ToString("dd/MM/yyyy") %>
        </a>
    </td>
</tr>