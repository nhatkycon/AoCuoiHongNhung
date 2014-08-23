<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-ChoThueVay-Print.ascx.cs" Inherits="lib_ui_PhieuXuatNhapSanPhamChiTiet_List_ChoThueVay_Print" %>
<%@ Register Src="~/lib/ui/PhieuXuatNhapSanPhamChiTiet/templates/Item-ChoThueVay-Print.ascx" TagPrefix="uc1" TagName="ItemChoThueVayPrint" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:ItemChoThueVayPrint runat="server" ID="ItemChoThueVayPrint" Item='<%# Container.DataItem %>' /> 
    </ItemTemplate>
</asp:Repeater>