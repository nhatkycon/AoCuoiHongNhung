<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_PhieuBaoHong_templates_Item" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td class="">
        <a href="/lib/pages/PhieuBaoHong/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.MaStr %>
        </a>
    </td>
    <td>
        <a href="/lib/pages/PhieuBaoHong/Default.aspx?LYDO_ID=<%=Item.LYDO_ID %>">
            <%=Item.LYDO_Ten %>
        </a>
    </td>
    <td>
        <%if(Item.NgayBaoHong != DateTime.MinValue){ %>
            <%=Item.NgayBaoHong.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%=Item.HH_Ten %>
    </td>

    <td>
        <%if(Item.Duyet){ %>
            <strong><%=Item.NguoiDuyet_Ten %></strong>
            <%if(Item.NgayDuyet != DateTime.MinValue){ %>
                - <%=Item.NgayDuyet.ToString("dd/MM/yyyy") %>
            <%} %>
        <%} else
          {%>
          Chưa duyệt    
        <%  }%>
    </td>
    <td>
        <%=Lib.TienVietNam(Item.Tien) %>
    </td>
    <td>
        <%=Item.NhanVien_Ten %>
    </td>
</tr>