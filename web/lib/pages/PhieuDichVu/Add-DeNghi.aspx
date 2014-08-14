<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Add-DeNghi.aspx.cs" Inherits="lib_pages_PhieuDichVu_Add_DeNghi" %>

<%@ Register Src="~/lib/ui/PhieuDichVu/Add-DeNghi.ascx" TagPrefix="uc1" TagName="AddDeNghi" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AddDeNghi runat="server" Id="Add" />
</asp:Content>

