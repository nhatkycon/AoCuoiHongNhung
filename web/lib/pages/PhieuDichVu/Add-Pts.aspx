<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Add-Pts.aspx.cs" Inherits="lib_pages_PhieuDichVu_Add_Pts" %>
<%@ Register Src="~/lib/ui/PhieuDichVu/Add-Pts.ascx" TagPrefix="uc1" TagName="AddPts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AddPts runat="server" Id="AddPts" />
</asp:Content>

