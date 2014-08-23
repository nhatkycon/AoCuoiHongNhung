<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Print.master" AutoEventWireup="true" CodeFile="In-PhieuChonAnh.aspx.cs" Inherits="lib_pages_PhieuDichVu_In_PhieuChonAnh" %>

<%@ Register Src="~/lib/ui/PhieuDichVu/In-PhieuChonAnh.ascx" TagPrefix="uc1" TagName="InPhieuChonAnh" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Phiếu chọn ảnh <%=Item.MaStr %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:InPhieuChonAnh runat="server" ID="Add" />
</asp:Content>

