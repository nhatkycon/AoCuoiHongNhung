<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-DichVu-Add.ascx.cs" Inherits="lib_ui_GoiDichVu_templates_Item_DichVu_Add" %>
<%@ Import Namespace="linh.common" %>
<tr data-id="<%=Item.ID %>" class="GoiDichVu-ThemChiTiet-AddPnl">
    
    <td class="">
        <div class="input-group">
            <span class="input-group-addon btn autocomplete-btn">
                <i class="glyphicon glyphicon-chevron-down"></i>
            </span>
            <input data-id="<%=Item.ID %>" type="text" 
                data-cached="1" data-src="/lib/ajax/HangHoa/Default.aspx" 
                data-savedUrl="/lib/ajax/GoiDichVu/Default.aspx" 
                data-gid="<%=Item.GDV_ID %>"
                class="form-control HH_Ten form-autocomplete-input-gdvCt" value="<%=Item.HH_Ten %>"/>
        </div>
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