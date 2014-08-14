<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListByNhanVien.ascx.cs" Inherits="lib_ui_LichHen_ListByNhanVien" %>
<%@ Register Src="~/lib/ui/LichHen/templates/ListByNhanVien-Item.ascx" TagPrefix="uc1" TagName="ListByNhanVienItem" %>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th class="">
                Tên
            </th>
            <th>
                Khách
            </th>
            <th>
                Loại
            </th>
            <th class="hidden-xs">
                Nhân viên
            </th>
            <th>
                Ngày
            </th>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:ListByNhanVienItem runat="server" ID="ListByNhanVienItem" Item='<%# Container.DataItem %>' />            
        </ItemTemplate>
    </asp:Repeater>    
</table>