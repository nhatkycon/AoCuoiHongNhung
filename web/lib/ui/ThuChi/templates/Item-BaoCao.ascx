<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-BaoCao.ascx.cs" Inherits="lib_ui_ThuChi_templates_Item_BaoCao" %>
<%@ Import Namespace="linh.common" %>
<tr class="<%=Item.isthu ? "success" : "warning" %>">
    <td class="hidden-xs hidden-sm">
        <input type="checkbox" class="ship-item-ckb" name="id" value="<%=Item.ma %>"/>
    </td>
    <td style="text-align: right;" class="hidden-xs hidden-sm">
        <%if(Item.sophieu != "0"){ %>
            <%=Item.isthu ? "THU" : "CHI" %>-<%=Lib.FormatMa(Item.sophieu) %>
        <%} %>
    </td>
    <td class="hidden-xs hidden-sm">
        <%=Item.NDTC_Ten %>
    </td>
    <td class="hidden-xs hidden-sm">
        <i>
            <%=Item.diengiai %>
        </i>
    </td>
    <td style="text-align: right;" class="hidden-xs hidden-sm">
        <%=Lib.TienVietNam(Item.thu_tk) %>
    </td>
    <td style="text-align: right;" class="hidden-xs hidden-sm">
        <%=Lib.TienVietNam(Item.thu_tm) %>
    </td>
    <td style="text-align: right;">
        <strong>
            <%=Lib.TienVietNam(Item.thu_t) %>
        </strong>
    </td>
    <td style="text-align: right;" class="hidden-xs hidden-sm">
        <%=Lib.TienVietNam(Item.chi_tk) %>
    </td>
    <td style="text-align: right;" class="hidden-xs hidden-sm">
        <%=Lib.TienVietNam(Item.chi_tm) %>
    </td>
    <td style="text-align: right;">
        <strong>
            <%=Lib.TienVietNam(Item.chi_t) %>
        </strong>
    </td>
    <td style="text-align: right;" class="hidden-xs hidden-sm">
        <%=Lib.TienVietNam(Item.tt_tk) %>
    </td>
    <td style="text-align: right;" class="hidden-xs hidden-sm">
        <%=Lib.TienVietNam(Item.tt_tm) %>
    </td>
    <td style="text-align: right;">
        <strong>
            <%=Lib.TienVietNam(Item.tt_t) %>
        </strong>
    </td>
    <td style="text-align: right;" class="hidden-xs hidden-sm">
        <%=Lib.TienVietNam(Item.sodu_tk) %>
    </td>
    <td style="text-align: right;" class="hidden-xs hidden-sm">
        <%=Lib.TienVietNam(Item.sodu_tm) %>
    </td>
    <td style="text-align: right;">
        <strong>
            <%=Lib.TienVietNam(Item.sodu_t) %>
        </strong>
    </td>
    <td class="hidden-xs hidden-sm">
        <%=Item.loaiquy == 0 ? "TM" : "TK" %>
    </td>
    <td>
        <%=Item.ngay %>
    </td>
</tr>