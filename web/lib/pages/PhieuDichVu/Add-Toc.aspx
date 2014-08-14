<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Add-Toc.aspx.cs" Inherits="lib_pages_PhieuDichVu_Add_Toc" %>

<%@ Register Src="~/lib/ui/PhieuDichVu/Add-Toc.ascx" TagPrefix="uc1" TagName="AddToc" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AddToc runat="server" Id="AddToc" />
</asp:Content>

