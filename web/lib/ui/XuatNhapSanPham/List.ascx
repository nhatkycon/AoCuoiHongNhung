<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="lib_ui_XuatNhapSanPham_List" %>
<%@ Register Src="~/lib/ui/XuatNhapSanPham/templates/Item.ascx" TagPrefix="uc1" TagName="Item" %>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th class="">
                Mã
            </th>
            <th>
                Mã Phiếu DV
            </th>
            <th>
                Ngày xuất
            </th>      
            <th>
                Người xuất
            </th>        
            <th>
                Ngày nhập
            </th>
            <th>
                Người nhập
            </th>
            <th>
                Trạng thái
            </th>    
        </tr>
    </thead>
    <tbody>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:Item runat="server" ID="Item" Item='<%# Container.DataItem %>' /> 
            </ItemTemplate>
        </asp:Repeater>    
    </tbody>
   
</table>