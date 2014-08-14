<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="PhieuDichVu_View.aspx.cs" Inherits="lib_pages_ThungRac_PhieuDichVu_View" %>

<%@ Register Src="~/lib/ui/PhieuDichVu/Add.ascx" TagPrefix="uc1" TagName="Add" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Add runat="server" Id="Add" />
</asp:Content>

