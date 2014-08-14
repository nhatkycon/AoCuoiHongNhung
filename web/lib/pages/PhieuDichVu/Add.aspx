<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="lib_pages_PhieuDichVu_Add" %>

<%@ Register Src="~/lib/ui/PhieuDichVu/Add.ascx" TagPrefix="uc1" TagName="Add" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Phiếu dịch vụ: <%=Item.MaStr %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Add runat="server" id="Add" />
</asp:Content>

