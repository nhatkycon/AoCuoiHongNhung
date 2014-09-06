<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="lib_ui_PhieuDichVuDichVu_List" %>
<%@ Register Src="~/lib/ui/PhieuDichVuDichVu/templates/Item-Edit.ascx" TagPrefix="uc1" TagName="ItemEdit" %>
<table class="table table-striped table-bordered table-hover PhieuDichVuDichVu-Pnl">
    <thead class="PhieuDichVuDichVu-AddPnl">
        <tr>
            <th  style="width: 200px;">
                <div class="input-group">
                    <span class="input-group-addon btn autocomplete-btn">
                        <i class="glyphicon glyphicon-chevron-down"></i>
                    </span>
                    <input data-pdvid="<%=Item.ID %>" type="text" 
                        data-cached="0" 
                        data-src="/lib/ajax/HangHoa/Default.aspx" 
                        data-savedUrl="/lib/ajax/PhieuDichVuDichVu/Default.aspx" 
                        class="form-control HH_Ten form-autocomplete-input-pdvDv" value=""/>
                </div>
            </th>
            <th>
                Thứ tự
            </th>            
            <th>
                Mô tả
            </th>
            <th>
                Giá
            </th>              
            <th>
                Số lượng
            </th>
            <th style="width: 300px;">
                Tư vấn
            </th>
            <th>
                Tiền
            </th>    
            <th>
                
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