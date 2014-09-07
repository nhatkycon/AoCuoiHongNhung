<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DichVuThem.ascx.cs" Inherits="lib_ui_BaoCao_DichVuThem" %>
<%@ Register Src="~/lib/ui/BaoCao/templates/Item-DichVuThem.ascx" TagPrefix="uc1" TagName="ItemDichVuThem" %>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th>
                Dịch vụ
            </th>
            <th>
                Nhân viên
            </th>           
            <th>
                Tư vấn
            </th> 
            <th>
                PDV
            </th>
            <th>
                Tiền
            </th>
            <th>
                Ngày
            </th>
        </tr>
    </thead>
    <tbody>
         <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:ItemDichVuThem runat="server" ID="ItemDichVuThem" Item='<%# Container.DataItem %>' /> 
            </ItemTemplate>
        </asp:Repeater>       
    </tbody>
</table>

