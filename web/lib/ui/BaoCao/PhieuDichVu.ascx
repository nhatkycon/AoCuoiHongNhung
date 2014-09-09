<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PhieuDichVu.ascx.cs" Inherits="lib_ui_BaoCao_PhieuDichVu" %>
<%@ Import Namespace="linh.common" %>
<%@ Register Src="~/lib/ui/PhieuDichVu/templates/Item-BaoCao.ascx" TagPrefix="uc1" TagName="ItemBaoCao" %>

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
                Chụp
            </th>
            <th>
                Tóc
            </th>
            <th>
                Trang điểm
            </th>
            <th>
                PTS
            </th>
            <th>
                Tư vấn
            </th>
            <th>
                Trạng thái
            </th>
        </tr>    
    </thead>
    <tbody>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:ItemBaoCao runat="server" ID="ItemBaoCao"  Item='<%# Container.DataItem %>' /> 
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td class="">
                <%=List.Count %>
            </td>
            <td>
            </td>
            <td style="text-align: right;">
                <strong>
                    <%=Lib.TienVietNam(List.Sum( x => x.TongTien)) %>
                </strong>
            </td>
            <td style="text-align: right;">
                <strong>
                    <%=Lib.TienVietNam(List.Sum( x => x.DatCoc)) %>
                </strong>
            </td>
            <td style="text-align: right;">
                <strong>
                    <%=Lib.TienVietNam(List.Sum( x => x.X_ThanhToan)) %>
                </strong>
            </td>
            <td style="text-align: right;">
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
            <td>
            </td>
        </tr>
    </tbody>
</table>