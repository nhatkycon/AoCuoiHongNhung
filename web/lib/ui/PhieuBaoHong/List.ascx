<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="lib_ui_PhieuBaoHong_List" %>
<%@ Register Src="~/lib/ui/PhieuBaoHong/templates/Item.ascx" TagPrefix="uc1" TagName="Item" %>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th class="">
                Mã
            </th>
            <th>
                Lý do
            </th>
            <th>
                Ngày
            </th>      
            <th>
                Váy
            </th>        
            <th>
                Duyệt
            </th>
            <th>
                Tiền bồi thường
            </th>
            <th>
                Người lập
            </th>    
        </tr>
    </thead>
    <tbody>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:Item runat="server" ID="Item1" Item='<%# Container.DataItem %>' /> 
            </ItemTemplate>
        </asp:Repeater>    
    </tbody>
   
</table>