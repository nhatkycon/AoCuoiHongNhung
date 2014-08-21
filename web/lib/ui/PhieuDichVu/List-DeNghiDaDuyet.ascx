<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-DeNghiDaDuyet.ascx.cs" Inherits="lib_ui_PhieuDichVu_List_DeNghiDaDuyet" %>
<%@ Register Src="~/lib/ui/PhieuDichVu/templates/Item-DeNghiChuaDuyet.ascx" TagPrefix="uc1" TagName="ItemDeNghiChuaDuyet" %>

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
                Chụp
            </th>
            <th>
                Tóc
            </th>
            <th>
                Trang điểm
            </th>
            <th>
                PTS
            </th>
            <th>
                Tư vấn
            </th>
            <th>
                Trạng thái
            </th>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:ItemDeNghiChuaDuyet runat="server" ID="ItemDeNghiChuaDuyet" Item='<%# Container.DataItem %>' /> 
        </ItemTemplate>
    </asp:Repeater>    
</table>