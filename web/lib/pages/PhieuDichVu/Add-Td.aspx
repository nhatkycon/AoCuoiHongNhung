<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Add-Td.aspx.cs" Inherits="lib_pages_PhieuDichVu_Add_Td" %>

<%@ Register Src="~/lib/ui/PhieuDichVu/Add-Td.ascx" TagPrefix="uc1" TagName="AddTd" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AddTd runat="server" Id="AddTd" />
</asp:Content>

