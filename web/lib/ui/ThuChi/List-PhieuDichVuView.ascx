<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-PhieuDichVuView.ascx.cs" Inherits="lib_ui_ThuChi_List_PhieuDichVuView" %>
<%@ Register Src="~/lib/ui/ThuChi/templates/Item-PhieuDichVuView.ascx" TagPrefix="uc1" TagName="ItemPhieuDichVuView" %>
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
            <uc1:ItemPhieuDichVuView runat="server" ID="ItemPhieuDichVuView" Item='<%# Container.DataItem %>' />   
        </ItemTemplate>
    </asp:Repeater>    
</table>