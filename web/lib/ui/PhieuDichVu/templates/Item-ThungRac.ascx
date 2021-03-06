﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-ThungRac.ascx.cs" Inherits="lib_ui_PhieuDichVu_templates_Item_ThungRac" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td class="">
        <a href="/lib/pages/ThungRac/PhieuDichVu_View.aspx?ID=<%=Item.ID %>">
            <%=Item.MaStr %>
        </a>
    </td>
    <td>
            <%=Item.KH_Ten %>
    </td>
    <td>
        <%=Lib.TienVietNam(Item.TongTien) %>
    </td>
    <td>
        <%=Lib.TienVietNam(Item.DatCoc) %>
    </td>
    <td>
        <%=Lib.TienVietNam(Item.ConNo) %>
    </td>
    <td>
        <%if (Item.CHUP_NgayBatDau != DateTime.MinValue){ %>
            <%=Item.CHUP_NgayBatDau.ToString("HH:mm") %>-<%=Item.CHUP_NgayKetThuc.ToString("HH:mm") %> 
            <%=Item.CHUP_NgayBatDau.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    
    <td>
        <%if (Item.PTS_NgayBatDau != DateTime.MinValue){ %>
            <%=Item.PTS_NgayBatDau.ToString("dd/MM") %>
        <%} %>
        <%if (Item.PTS_NgayBatDau != DateTime.MinValue){ %>
            - <%=Item.PTS_NgayKetThuc.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%if (Item.PTS_NgayXemMaket != DateTime.MinValue){ %>
            <%=Item.PTS_NgayXemMaket.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%if (Item.PTS_NgayCoSanPham != DateTime.MinValue){ %>
            <%=Item.PTS_NgayCoSanPham.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>
    <td>
        <%if (Item.PTS_HenSanPham != DateTime.MinValue){ %>
            <%=Item.PTS_HenSanPham.ToString("dd/MM/yyyy") %>
        <%} %>
    </td>

    <td>
        <%=Item.NgayTuVan.ToString("dd/MM/yyyy") %>
    </td>
    <td>
            <%=Item.TrangThaistr %>
    </td>
</tr>