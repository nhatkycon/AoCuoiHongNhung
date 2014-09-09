<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item.ascx.cs" Inherits="lib_ui_ChoThueVay_templates_Item" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td class="">
        <a href="/lib/pages/ChoThueVay/Add.aspx?ID=<%=Item.ID %>">
            <%=Item.MaStr %>
        </a>
    </td>
    <td>
        <%=Item.KH_Ten %>
    </td>
    <td style="text-align:right;">
        <%=Lib.TienVietNam(Item.Tong) %>
    </td>
    <td style="text-align:right;">
        <%=Lib.TienVietNam(Item.DatCong) %>
    </td>
    <td style="text-align:right;">
        <%=Lib.TienVietNam(Item.X_ThanhToan) %>
    </td>
    <td style="text-align:right;">
        <%=Lib.TienVietNam(Item.X_ConNo) %>
    </td>
    <td>
        <%if(Item.NgayBatDau != DateTime.MinValue){ %>
            <%=Item.NgayBatDau.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%=Item.NguoiXuat_Ten %>
    </td>

    <td>
        <%if(Item.NgayKetThuc != DateTime.MinValue){ %>
            <%=Item.NgayKetThuc.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%=Item.NguoiNhap_Ten %>
    </td>
    <td>
        <a href="/lib/pages/ChoThueVay/Default.aspx?TrangThai=<%=Item.TrangThai %>">
            <%=Item.TrangThai_Ten %>
        </a>
    </td>    
</tr>