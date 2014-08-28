<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List-BaoCao.ascx.cs" Inherits="lib_ui_ThuChi_List_BaoCao" %>
<%@ Register Src="~/lib/ui/ThuChi/templates/Item-BaoCao.ascx" TagPrefix="uc1" TagName="ItemBaoCao" %>

<table class="table table-striped table-hover table-bordered DatHangList">
    <thead>
        <tr>
            <th class="hidden-xs hidden-sm">
                <input type="checkbox" class="ship-all-ckb" name="id"/>
            </th>
            <th class="hidden-xs hidden-sm">
                Phiếu
            </th>
            <th class="hidden-xs hidden-sm">
                Nội dung
            </th>
            <th class="hidden-xs hidden-sm">
                Diễn giải
            </th>
            <th class="hidden-xs hidden-sm">
                T-TK
            </th>
            <th class="hidden-xs hidden-sm">
                T-TM
            </th>
            <th>
                Thu
            </th>
            <th class="hidden-xs hidden-sm">
                C-TK
            </th>
            <th class="hidden-xs hidden-sm">
                C-TM
            </th>
            <th>
                Chi
            </th>
            <th class="hidden-xs hidden-sm">
                TT-TK
            </th>
            <th class="hidden-xs hidden-sm">
                TT-TM
            </th>
            <th>
                TT
            </th>
            <th class="hidden-xs hidden-sm">
                SD-TK
            </th>
            <th class="hidden-xs hidden-sm">
                SD-TM
            </th>
            <th>
                SD
            </th>
            <th class="hidden-xs hidden-sm">
                Quỹ
            </th>
            <th>
                Ngày
            </th>
        </tr>    
    </thead>
    <tbody>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:ItemBaoCao runat="server" ID="ItemBaoCao" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>        
    </tbody>
</table>