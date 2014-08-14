<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="lib_ui_HangHoa_List" %>
<%@ Register Src="~/lib/ui/HangHoa/templates/Item.ascx" TagPrefix="uc1" TagName="Item" %>

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
                Nhóm
            </th>
            <th>
                Gía
            </th>
            <th>
                SL
            </th>
            <th>
                Hết
            </th>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:Item runat="server" ID="Item" Item='<%# Container.DataItem %>' />            
        </ItemTemplate>
    </asp:Repeater>    
</table>