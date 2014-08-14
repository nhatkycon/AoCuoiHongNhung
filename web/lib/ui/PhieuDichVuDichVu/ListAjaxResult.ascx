<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListAjaxResult.ascx.cs" Inherits="lib_ui_PhieuDichVuDichVu_ListAjaxResult" %>
<%@ Register Src="~/lib/ui/PhieuDichVuDichVu/templates/Item-Edit.ascx" TagPrefix="uc1" TagName="ItemEdit" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:ItemEdit runat="server" ID="ItemEdit" Item='<%# Container.DataItem %>' /> 
    </ItemTemplate>
</asp:Repeater>