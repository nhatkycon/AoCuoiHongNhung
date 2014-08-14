<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="lib_ui_GoiDichVu_List" %>
<%@ Register Src="~/lib/ui/GoiDichVu/templates/Item.ascx" TagPrefix="uc1" TagName="Item" %>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th class="">
                Tên
            </th>
            <th>
                Mã
            </th>
            <th>
                Gía
            </th>            
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:Item runat="server" id="Item1" Item='<%# Container.DataItem %>' /> 
        </ItemTemplate>
    </asp:Repeater>    
</table>