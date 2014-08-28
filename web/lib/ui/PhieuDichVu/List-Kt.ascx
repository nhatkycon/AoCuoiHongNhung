<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-Kt.ascx.cs" Inherits="lib_ui_PhieuDichVu_List_Kt" %>
<%@ Register Src="~/lib/ui/PhieuDichVu/templates/Item.ascx" TagPrefix="uc1" TagName="Item" %>
<%@ Register Src="~/lib/ui/PhieuDichVu/templates/Item-Kt.ascx" TagPrefix="uc1" TagName="ItemKt" %>


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
                Còn nợ
            </th>
            <th>
                Ngày chụp
            </th>
            <th>
                Ngày PTS
            </th>
            <th>
                Duyệt maket
            </th>
            <th>
                Có sản phẩm
            </th>
            <th>
                Hẹn trả SP
            </th>
            <th>
                Ngày tạo
            </th>
            <th>
                Trạng thái
            </th>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:ItemKt runat="server" ID="ItemKt" Item='<%# Container.DataItem %>' /> 
        </ItemTemplate>
    </asp:Repeater>    
</table>