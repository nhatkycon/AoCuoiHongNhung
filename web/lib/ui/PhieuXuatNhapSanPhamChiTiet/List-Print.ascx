<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-Print.ascx.cs" Inherits="lib_ui_PhieuXuatNhapSanPhamChiTiet_List_Print" %>
<%@ Register Src="~/lib/ui/PhieuXuatNhapSanPhamChiTiet/templates/Item-Print.ascx" TagPrefix="uc1" TagName="ItemPrint" %>

<table width="100%" border="1" cellpadding="4" cellspacing="0">
<thead>
    <th>
        Sản phẩm
    </th>
    <th style="width: 80px;">
        Số lượng
    </th>            
    <th style="width: 30px;">
        Xuất
    </th>
    <th style="width: 30px;">
        Nhập
    </th>  
    <th style="width: 200px;">
        Ghi chú
    </th>
</thead> 
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:ItemPrint runat="server" ID="ItemPrint" Item='<%# Container.DataItem %>' /> 
        </ItemTemplate>
    </asp:Repeater>    
</table>