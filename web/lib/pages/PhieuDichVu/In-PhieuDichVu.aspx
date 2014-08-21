<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Print.master" AutoEventWireup="true" CodeFile="In-PhieuDichVu.aspx.cs" Inherits="lib_pages_PhieuDichVu_In_PhieuDichVu" %>
<%@ Import Namespace="linh.common" %>

<%@ Register Src="~/lib/ui/PhieuDichVu/In-PhieuDichVu.ascx" TagPrefix="uc1" TagName="InPhieuDichVu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>
        <%=Lib.FormatMa(Item.Ma) %>
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:InPhieuDichVu runat="server" ID="Add" />
</asp:Content>

