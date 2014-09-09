<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Print.master" AutoEventWireup="true" CodeFile="ThanhLy-Print.aspx.cs" Inherits="lib_pages_XuatNhapSanPham_ThanhLy_Print" %>

<%@ Register Src="~/lib/ui/XuatNhapSanPham/templates/ThanhLy-Print.ascx" TagPrefix="uc1" TagName="ThanhLyPrint" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ThanhLyPrint runat="server" ID="Print" />
</asp:Content>

