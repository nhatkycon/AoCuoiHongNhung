<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-Duyet-All.ascx.cs" Inherits="lib_ui_DuyetAnh_List_Duyet_All" %>
<%@ Register Src="~/lib/ui/DuyetAnh/templates/Item-Duyet.ascx" TagPrefix="uc1" TagName="ItemDuyet" %>
<asp:Repeater runat="server" ID="rpt">
    <ItemTemplate>
        <uc1:ItemDuyet runat="server" ID="ItemDuyet" Item='<%# Container.DataItem %>' /> 
    </ItemTemplate>
</asp:Repeater>