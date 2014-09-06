<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-Edit.ascx.cs" Inherits="lib_ui_PhieuXuatNhapSanPhamChiTiet_List_Edit" %>
<%@ Register Src="~/lib/ui/PhieuXuatNhapSanPhamChiTiet/templates/Item-Edit.ascx" TagPrefix="uc1" TagName="ItemEdit" %>

<table class="table table-striped table-bordered table-hover PhieuXuatNhapSanPhamChiTiet-Pnl">
    <thead class="PhieuXuatNhapSanPhamChiTiet-AddPnl">
        <tr>
            <th class="">
                <div class="input-group">
                    <span class="input-group-addon btn autocomplete-btn">
                        <i class="glyphicon glyphicon-chevron-down"></i>
                    </span>
                    <input data-PxnSpId="<%=PID %>" type="text" 
                        data-cached="0" 
                        data-src="/lib/ajax/HangHoa/Default.aspx" 
                        data-savedUrl="/lib/ajax/XuatNhapSanPham/Default.aspx" 
                        class="form-control HH_Ten form-autocomplete-input-pxnSpCt" value=""/>
                </div>
            </th>
            <th>
                Số lượng
            </th>            
            <th>
                Xuất
            </th>
            <th>
                Nhập
            </th>  
            <th>
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