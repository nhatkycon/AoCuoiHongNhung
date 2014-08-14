<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_ajax_PhieuDichVuDichVu_Default" %>
<%@ Register Src="~/lib/ui/PhieuDichVuDichVu/templates/Item-Edit.ascx" TagPrefix="uc1" TagName="ItemEdit" %>
<%@ Register Src="~/lib/ui/PhieuDichVuDichVu/ListAjaxResult.ascx" TagPrefix="uc1" TagName="ListAjaxResult" %>
<uc1:ItemEdit runat="server" ID="ItemEdit" Visible="False"/><uc1:ListAjaxResult Visible="False" runat="server" ID="ListAjaxResult" />
