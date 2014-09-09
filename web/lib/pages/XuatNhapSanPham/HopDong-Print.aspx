<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Print.master" AutoEventWireup="true" CodeFile="HopDong-Print.aspx.cs" Inherits="lib_pages_XuatNhapSanPham_HopDong_Print" %>

<%@ Register Src="~/lib/ui/XuatNhapSanPham/templates/HopDong-Print.ascx" TagPrefix="uc1" TagName="HopDongPrint" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:HopDongPrint runat="server" ID="Print" />
</asp:Content>

