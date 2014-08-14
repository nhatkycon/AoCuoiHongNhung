<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-Pts.ascx.cs" Inherits="lib_ui_PhieuDichVu_List_Pts" %>
<%@ Register Src="~/lib/ui/PhieuDichVu/templates/Item-Pts.ascx" TagPrefix="uc1" TagName="ItemPts" %>

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
                Ngày chụp
            </th>
            <th>
                Ngày nhận
            </th>
            <th>
                Ngày duyệt maket
            </th>
            <th>
                Ngày có sản phẩm
            </th>
            <th>
                Ngày hẹn trả SP
            </th>
            <th>
                Trạng thái
            </th>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:ItemPts runat="server" ID="ItemPts" Item='<%# Container.DataItem %>' /> 
        </ItemTemplate>
    </asp:Repeater>    
</table>