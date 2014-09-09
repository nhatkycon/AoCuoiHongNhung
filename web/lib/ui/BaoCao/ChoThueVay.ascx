<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChoThueVay.ascx.cs" Inherits="lib_ui_BaoCao_ChoThueVay" %>
<%@ Import Namespace="linh.common" %>
<%@ Register Src="~/lib/ui/ChoThueVay/templates/Item.ascx" TagPrefix="uc1" TagName="Item" %>

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
                Tổng
            </th>
            <th>
                Đặt cọc
            </th>
            <th>
                Thanh toán
            </th>
            <th>
                Còn nợ
            </th>
            <th>
                Ngày xuất
            </th>      
            <th>
                Người xuất
            </th>        
            <th>
                Ngày nhập
            </th>
            <th>
                Người nhập
            </th>
            <th>
                Trạng thái
            </th>    
        </tr>
    </thead>
    <tbody>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:Item runat="server" ID="Item" Item='<%# Container.DataItem %>' /> 
            </ItemTemplate>
        </asp:Repeater>  
        <tr>
            <td class="">
                
            </td>
            <td>
            </td>
            <td style="text-align:right;">
                <strong>
                    <%=Lib.TienVietNam(List.Sum( x => x.Tong)) %>
                </strong>
            </td>
            <td style="text-align:right;">
                <%=Lib.TienVietNam(List.Sum( x => x.DatCong)) %>
            </td>
            <td style="text-align:right;">
                <%=Lib.TienVietNam(List.Sum( x => x.X_ThanhToan)) %>
            </td>
            <td style="text-align:right;">
                <strong>
                    <%=Lib.TienVietNam(List.Sum( x => x.X_ConNo)) %>
                </strong>
            </td>
            <td>
               
            </td>
            <td>
            </td>

            <td>
                
            </td>
            <td>
            </td>
            <td>
               
            </td>    
        </tr> 
    </tbody>
</table>