<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-Thu.ascx.cs" Inherits="lib_ui_ThuChi_List_Thu" %>
<%@ Register Src="~/lib/ui/ThuChi/templates/Item-Thu.ascx" TagPrefix="uc1" TagName="ItemThu" %>

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
                Người nộp
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
            <uc1:ItemThu runat="server" ID="ItemThu" Item='<%# Container.DataItem %>' />   
        </ItemTemplate>
    </asp:Repeater>    
</table>