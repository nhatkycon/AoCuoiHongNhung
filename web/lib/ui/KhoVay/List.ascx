<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="lib_ui_KhoVay_List" %>
<%@ Register Src="~/lib/ui/KhoVay/templates/Item.ascx" TagPrefix="uc1" TagName="Item" %>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th class="">
                Mã
            </th>
            <th>
                Tên
            </th>
            <th>
                Nhóm
            </th>
            <th>
                Giá
            </th>
            <th>
                Tình trạng
            </th>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:Item runat="server" ID="Item" Item='<%# Container.DataItem %>' /> 
        </ItemTemplate>
    </asp:Repeater>    
</table>