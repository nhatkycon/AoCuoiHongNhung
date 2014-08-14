<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_Empty.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="lib_pages_Login" %>
<%@ Register Src="~/lib/ui/HeThong/LoginForm.ascx" TagPrefix="uc1" TagName="LoginForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:LoginForm runat="server" id="LoginForm" />
</asp:Content>

