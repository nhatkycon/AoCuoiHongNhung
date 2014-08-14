<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-Chi.ascx.cs" Inherits="lib_ui_ThuChi_List_Chi" %>
<%@ Register Src="~/lib/ui/ThuChi/templates/Item-Chi.ascx" TagPrefix="uc1" TagName="ItemChi" %>


<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th class="">
                Mã
            </th>
            <th>
                PDV
            </th>
            <th>
                Người nhận
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
            <uc1:ItemChi runat="server" ID="ItemChi" Item='<%# Container.DataItem %>' /> 
        </ItemTemplate>
    </asp:Repeater>    
</table>