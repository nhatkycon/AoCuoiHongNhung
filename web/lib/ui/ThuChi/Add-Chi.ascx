<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add-Chi.ascx.cs" Inherits="lib_ui_ThuChi_Add_Chi" %>
<%@ Register Src="~/lib/ui/KhachHang/AddQuickModal.ascx" TagPrefix="uc1" TagName="AddQuickModal" %>
<%@ Register TagPrefix="uc1" TagName="AddTask_1_1" Src="~/lib/ui/HeThong/templates/AddTask.ascx" %>
<%@ Register Src="~/lib/ui/ThuChi/Add-Core.ascx" TagPrefix="uc1" TagName="AddCore" %>
<link href="/lib/css/web/bootstrap-timepicker.min.css" rel="stylesheet" />
<div class="panel panel-default Normal-Pnl-Add ThuChiChi-Pnl-Add"
    data-url="/lib/ajax/ThuChi/default.aspx"
    data-success="/lib/pages/ThuChi/Add-Chi.aspx?ID="
    data-list="/lib/pages/ThuChi/List-Chi.aspx"
    >
    <div class="panel-heading">
        <uc1:AddTask_1_1 
            AddUrl="/lib/pages/ThuChi/Add-Chi.aspx" 
            ListUrl="/lib/pages/ThuChi/List-Chi.aspx" 
            runat="server" id="AddTask" />                  
    </div>
    <div class="panel-body">
        <uc1:AddCore runat="server" Thu="False" Id="AddCore" />
    </div>
    <div class="panel-footer">
        <uc1:AddTask_1_1 
            AddUrl="/lib/pages/ThuChi/Add-Thu.aspx" 
            ListUrl="/lib/pages/ThuChi/List-Thu.aspx" 
            runat="server" id="AddTask_1_1" />
    </div>
</div>
<uc1:AddQuickModal runat="server" ID="AddQuickModal" />
<script src="/lib/js/jQueryLib/bootstrap-timepicker.min.js"></script>
<%if (!string.IsNullOrEmpty(Id))
{%>
<script>
    $(function () {
        $('.NDTC_ID').val('<%=Item.NDTC_ID %>');
        $('.LoaiQuy').val('<%=Item.LoaiQuy %>');
    })
</script>
<%} %>