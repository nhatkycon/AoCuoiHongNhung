<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-Toc.ascx.cs" Inherits="lib_ui_PhieuDichVu_List_Toc" %>
<%@ Register Src="~/lib/ui/PhieuDichVu/templates/Item-Toc.ascx" TagPrefix="uc1" TagName="ItemToc" %>

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
                Ngày làm
            </th>
            <th>
                Trạng thái
            </th>
        </tr>    
    </thead>
    <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <uc1:ItemToc runat="server" ID="ItemToc" Item='<%# Container.DataItem %>' /> 
        </ItemTemplate>
    </asp:Repeater>    
</table>