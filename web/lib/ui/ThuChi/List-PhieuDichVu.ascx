<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-PhieuDichVu.ascx.cs" Inherits="lib_ui_ThuChi_List_PhieuDichVu" %>
<%@ Register Src="~/lib/ui/ThuChi/templates/Item-PhieuDichVu.ascx" TagPrefix="uc1" TagName="ItemPhieuDichVu" %>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th class="">
                Mã
            </th>
            <th>
                Nội dung
            </th>
            <th>
                Tiền
            </th>
            <th>
                Mô tả
            </th>
             <th>
                Ngày
            </th>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:ItemPhieuDichVu runat="server" ID="ItemPhieuDichVu" Item='<%# Container.DataItem %>' />   
        </ItemTemplate>
    </asp:Repeater>    
</table>