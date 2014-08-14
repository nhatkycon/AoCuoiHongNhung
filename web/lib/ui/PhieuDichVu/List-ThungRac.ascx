<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-ThungRac.ascx.cs" Inherits="lib_ui_PhieuDichVu_List_ThungRac" %>
<%@ Register Src="~/lib/ui/PhieuDichVu/templates/Item-ThungRac.ascx" TagPrefix="uc1" TagName="ItemThungRac" %>

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
            <uc1:ItemThungRac runat="server" ID="ItemThungRac" Item='<%# Container.DataItem %>' /> 
        </ItemTemplate>
    </asp:Repeater>    
</table>