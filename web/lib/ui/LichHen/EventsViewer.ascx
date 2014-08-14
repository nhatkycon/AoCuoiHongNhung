<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EventsViewer.ascx.cs" Inherits="lib_ui_LichHen_EventsViewer" %>
<%@ Register Src="~/lib/ui/LichHen/templates/Item-EventsViewer.ascx" TagPrefix="uc1" TagName="ItemEventsViewer" %>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th class="">
                Việc
            </th>
            <th>
                Khách
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
            <uc1:ItemEventsViewer Target="<%# Target %>" runat="server" ID="ItemEventsViewer" Item='<%# Container.DataItem %>' />
        </ItemTemplate>
    </asp:Repeater>    
</table> 