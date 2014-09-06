<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_Blank.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="lib_pages_DuyetAnh_View" %>

<%@ Register Src="~/lib/ui/DuyetAnh/View.ascx" TagPrefix="uc1" TagName="View" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title><%=Item.MaStr %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:View runat="server" ID="View" />
</asp:Content>

