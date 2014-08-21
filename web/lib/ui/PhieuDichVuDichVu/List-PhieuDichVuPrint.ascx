<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-PhieuDichVuPrint.ascx.cs" Inherits="lib_ui_PhieuDichVuDichVu_List_PhieuDichVuPrint" %>
<%@ Register Src="~/lib/ui/PhieuDichVuDichVu/templates/Item-PhieuDichVuPrint.ascx" TagPrefix="uc1" TagName="ItemPhieuDichVuPrint" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:ItemPhieuDichVuPrint runat="server" ID="ItemPhieuDichVuPrint" Item='<%# Container.DataItem %>' /> 
    </ItemTemplate>
</asp:Repeater>