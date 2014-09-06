<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Duyet.ascx.cs" Inherits="lib_ui_DuyetAnh_templates_Item_Duyet" %>
<div data-id="<%=Item.ID %>" class="DuyetAnh-Item<%=Item.Selected ? " DuyetAnh-Item-Active" : "" %>">
    <img data-original="<%=Item.FullName %>?w=200" 
        data-full="<%=Item.FullName %>"
        alt="<%=Item.Ten %>" data-ten="<%=Item.Ten %>" class="DuyetAnh-Item-Img"/>
    <!-- Split button -->
    <div class="DuyetAnh-Item-Ten">
        <button data-id="<%=Item.ID %>" class="btn btn-sm DuyetAnh-Item-AddBtn">
            <i class="glyphicon glyphicon-plus"></i>
            <i class="glyphicon glyphicon-remove"></i>
        </button>
        <span class="DuyetAnh-Item-Ten-Lbl"><%=Item.Ten %></span>
    </div>
    <div class="DuyetAnh-Item-Footer" data-id="<%=Item.ID %>" >
        <input class="form-control DuyetAnh-Item-InputControl ThuTu" name="ThuTu"  value="<%=Item.ThuTu %>" placeholder="Thứ tự" type="number"/>
        <textarea placeholder="Ghi chú, chỉnh sửa, yêu cầu" 
            class="form-control DuyetAnh-Item-InputControl DuyetAnh-Item-GhiChu" name="GhiChu" rows="3"><%=Item.GhiChu %></textarea>    
        
    </div>
</div>