<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="lib_pages_KhoVay_View" %>

<%@ Register Src="~/lib/ui/KhoVay/View.ascx" TagPrefix="uc1" TagName="View" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:View runat="server" Id="View" />
</asp:Content>

