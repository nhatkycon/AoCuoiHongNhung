<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="lib_ui_ChoThueVay_List" %>
<%@ Register Src="~/lib/ui/ChoThueVay/templates/Item.ascx" TagPrefix="uc1" TagName="Item" %>

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
                Tổng
            </th>
            <th>
                Đặt cọc
            </th>
            <th>
                Thanh toán
            </th>
            <th>
                Còn nợ
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
                <uc1:Item runat="server" ID="Item1" Item='<%# Container.DataItem %>' /> 
            </ItemTemplate>
        </asp:Repeater>    
    </tbody>
   
</table>