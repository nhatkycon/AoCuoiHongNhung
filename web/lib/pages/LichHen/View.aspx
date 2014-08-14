<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="lib_pages_LichHen_View" %>

<%@ Register Src="~/lib/ui/LichHen/templates/View-Item.ascx" TagPrefix="uc1" TagName="ViewItem" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ViewItem runat="server" ID="ViewItem" />
</asp:Content>

