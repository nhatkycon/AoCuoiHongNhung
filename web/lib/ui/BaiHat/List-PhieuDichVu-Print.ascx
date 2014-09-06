<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-PhieuDichVu-Print.ascx.cs" Inherits="lib_ui_BaiHat_List_PhieuDichVu_Print" %>
<%@ Register Src="~/lib/ui/BaiHat/templates/Item-PhieuDichVu-Print.ascx" TagPrefix="uc1" TagName="ItemPhieuDichVuPrint" %>
<table class="table table-striped table-bordered table-hover border">
    <thead >
        <tr>
            <th style="width: 30px;">
                Thứ tự
            </th>
            <th>
                Tên
            </th>            
        </tr>
    </thead>
    <tbody>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:ItemPhieuDichVuPrint runat="server" ID="ItemPhieuDichVuPrint" Item='<%# Container.DataItem %>' /> 
            </ItemTemplate>
        </asp:Repeater>    
    </tbody>
</table>