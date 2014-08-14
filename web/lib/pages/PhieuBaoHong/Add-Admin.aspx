<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Add-Admin.aspx.cs" Inherits="lib_pages_PhieuBaoHong_Add_Admin" %>

<%@ Register Src="~/lib/ui/PhieuBaoHong/Add-Admin.ascx" TagPrefix="uc1" TagName="AddAdmin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AddAdmin runat="server" Id="Add" />
</asp:Content>

