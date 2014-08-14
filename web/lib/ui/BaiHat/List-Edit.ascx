<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-Edit.ascx.cs" Inherits="lib_ui_BaiHat_List_Edit" %>
<%@ Register Src="~/lib/ui/BaiHat/templates/Item-Edit.ascx" TagPrefix="uc1" TagName="ItemEdit" %>

<table class="table table-striped table-bordered table-hover PhieuDichVuBaiHat-Pnl">
    <thead data-id="<%=Item.ID %>" data-savedUrl="/lib/ajax/BaiHat/Default.aspx" class="PhieuDichVuBaiHat-AddPnl">
        <tr>
            <th style="width: 60px;">
                Thứ tự
            </th>
            <th>
                Tên
            </th>            
            <th style="width: 60px;">
            </th>  
        </tr>
        <tr>
            <th>
                <input data-pdvId="<%=Item.ID %>" type="text" class="form-control STT" name="STT"/>
            </th>
            <th>
                <input data-pdvId="<%=Item.ID %>" type="text" class="form-control Ten" name="Ten"/>
            </th>            
            <th>
                <button class="btn btn-default addBtn">
                    <i class="glyphicon glyphicon-plus-sign"></i>
                </button>
            </th>
        </tr>    
    </thead>
    <tbody>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:ItemEdit runat="server" ID="ItemEdit" Item='<%# Container.DataItem %>' /> 
            </ItemTemplate>
        </asp:Repeater>    
    </tbody>
</table>