<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_Empty.master" AutoEventWireup="true" CodeFile="ChangePass.aspx.cs" Inherits="lib_pages_ChangePass" %>

<%@ Register Src="~/lib/ui/HeThong/ChangePass.ascx" TagPrefix="uc1" TagName="ChangePass" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ChangePass runat="server" ID="ChangePass" />
</asp:Content>

