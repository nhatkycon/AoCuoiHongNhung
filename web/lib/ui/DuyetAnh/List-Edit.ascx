<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-Edit.ascx.cs" Inherits="lib_ui_DuyetAnh_List_Edit" %>
<%@ Register Src="~/lib/ui/DuyetAnh/templates/Item-Edit.ascx" TagPrefix="uc1" TagName="ItemEdit" %>

<table class="table table-striped table-bordered table-hover PhieuDichVuDuyetAnh-Pnl">
    <thead data-id="<%=Item.ID %>" class="PhieuDichVuDuyetAnh-AddPnl" data-savedUrl="/lib/ajax/DuyetAnh/Default.aspx">
        <tr>
            <th style="width: 60px;">
                Thứ tự
            </th>
            <th>
                Ảnh
            </th>            
            <th>
                Ghi chú
            </th>
            <th style="width: 60px;">
            </th>  
        </tr>
        <tr>
            <th>
                <input data-pdvId="<%=Item.ID %>" type="text" class="form-control ThuTu" name="ThuTu"/>
            </th>
            <th>
                <input data-pdvId="<%=Item.ID %>" type="text" class="form-control Ten" name="Ten"/>
            </th>            
            <th>
                <input data-pdvId="<%=Item.ID %>" type="text" class="form-control" name="GhiChu"/>
            </th>
            <th>
                <button data-id="<%=Item.ID %>" data-savedUrl="/lib/ajax/DuyetAnh/Default.aspx" class="btn btn-default addBtn">
                    <i class="glyphicon glyphicon-plus-sign"></i>
                </button>
            </th>
        </tr>    
    </thead>
    <tbody>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:ItemEdit runat="server" ID="ItemEdit1" Item='<%# Container.DataItem %>' /> 
            </ItemTemplate>
        </asp:Repeater>    
    </tbody>
</table>