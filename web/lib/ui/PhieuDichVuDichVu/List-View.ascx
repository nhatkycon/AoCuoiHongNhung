<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-View.ascx.cs" Inherits="lib_ui_PhieuDichVuDichVu_List_View" %>
<%@ Register Src="~/lib/ui/PhieuDichVuDichVu/templates/Item-View.ascx" TagPrefix="uc1" TagName="ItemView" %>

<table class="table table-striped table-bordered table-hover PhieuDichVuDichVu-Pnl">
    <thead class="PhieuDichVuDichVu-AddPnl">
        <tr>
            <th class="">
                Tên
            </th>
            <th>
                Thứ tự
            </th>            
            <th>
                Mô tả
            </th>
            <th>
                Giá
            </th>  
            <th>
                Số lượng
            </th>
            <th>
                Tư vấn
            </th>
            <th>
                Tiền
            </th>    
        </tr>    
    </thead>
    <tbody>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:ItemView runat="server" ID="ItemView" Item='<%# Container.DataItem %>' /> 
            </ItemTemplate>
        </asp:Repeater>    
    </tbody>
</table>