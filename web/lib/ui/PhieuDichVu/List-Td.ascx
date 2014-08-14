<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-Td.ascx.cs" Inherits="lib_ui_PhieuDichVu_List_Td" %>
<%@ Register Src="~/lib/ui/PhieuDichVu/templates/Item-Td.ascx" TagPrefix="uc1" TagName="ItemTd" %>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th class="">
                Mã
            </th>
            <th>
                KH
            </th>
            <th>
                Ngày làm
            </th>
            <th>
                Trạng thái
            </th>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:ItemTd runat="server" ID="ItemTd" Item='<%# Container.DataItem %>' /> 
        </ItemTemplate>
    </asp:Repeater>    
</table>