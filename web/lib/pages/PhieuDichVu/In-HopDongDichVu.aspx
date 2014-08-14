<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Print.master" AutoEventWireup="true" CodeFile="In-HopDongDichVu.aspx.cs" Inherits="lib_pages_PhieuDichVu_In_HopDongDichVu" %>

<%@ Register Src="~/lib/ui/PhieuDichVu/templates/Item-In-HopDongDichVu.ascx" TagPrefix="uc1" TagName="ItemInHopDongDichVu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ItemInHopDongDichVu runat="server" ID="Add" />
</asp:Content>

