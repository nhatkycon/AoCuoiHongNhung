<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Add-Kt.aspx.cs" Inherits="lib_pages_PhieuDichVu_Add_Kt" %>

<%@ Register Src="~/lib/ui/PhieuDichVu/Add-Kt.ascx" TagPrefix="uc1" TagName="AddKt" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AddKt runat="server" Id="Add" />
</asp:Content>

