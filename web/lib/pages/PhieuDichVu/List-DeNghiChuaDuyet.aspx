<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="List-DeNghiChuaDuyet.aspx.cs" Inherits="lib_pages_PhieuDichVu_List_DeNghiChuaDuyet" %>

<%@ Register Src="~/lib/ui/PhieuDichVu/List-DeNghiChuaDuyet.ascx" TagPrefix="uc1" TagName="ListDeNghiChuaDuyet" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ListDeNghiChuaDuyet runat="server" ID="ListDeNghiChuaDuyet" />
</asp:Content>

