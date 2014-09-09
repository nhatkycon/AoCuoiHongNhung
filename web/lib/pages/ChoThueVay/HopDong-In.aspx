<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Print.master" AutoEventWireup="true" CodeFile="HopDong-In.aspx.cs" Inherits="lib_pages_ChoThueVay_HopDong_In" %>

<%@ Register Src="~/lib/ui/ChoThueVay/HopDong-In.ascx" TagPrefix="uc1" TagName="HopDongIn" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>
        <%=Item.MaStr %>
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:HopDongIn runat="server" ID="HopDongIn" />
</asp:Content>

