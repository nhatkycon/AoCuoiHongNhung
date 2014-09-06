<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_Blank.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_DuyetAnh_Default" %>

<%@ Register Src="~/lib/ui/DuyetAnh/PickPhieuDichVu.ascx" TagPrefix="uc1" TagName="PickPhieuDichVu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:PickPhieuDichVu runat="server" ID="PickPhieuDichVu" />
</asp:Content>

