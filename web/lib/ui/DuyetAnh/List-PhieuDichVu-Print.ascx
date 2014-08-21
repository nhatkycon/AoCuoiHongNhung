<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-PhieuDichVu-Print.ascx.cs" Inherits="lib_ui_DuyetAnh_List_PhieuDichVu_Print" %>
<%@ Register Src="~/lib/ui/DuyetAnh/templates/Item-PhieuDichVu-Print.ascx" TagPrefix="uc1" TagName="ItemPhieuDichVuPrint" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:ItemPhieuDichVuPrint runat="server" ID="ItemPhieuDichVuPrint" Item='<%# Container.DataItem %>' /> 
    </ItemTemplate>
</asp:Repeater>