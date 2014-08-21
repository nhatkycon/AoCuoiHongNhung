<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="List-DeNghiDaDuyet.aspx.cs" Inherits="lib_pages_PhieuDichVu_List_DeNghiDaDuyet" %>

<%@ Register Src="~/lib/ui/PhieuDichVu/List-DeNghiDaDuyet.ascx" TagPrefix="uc1" TagName="ListDeNghiDaDuyet" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ListDeNghiDaDuyet runat="server" ID="ListDeNghiDaDuyet" />
</asp:Content>

