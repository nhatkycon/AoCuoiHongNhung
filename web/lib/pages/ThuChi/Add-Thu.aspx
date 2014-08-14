<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Add-Thu.aspx.cs" Inherits="lib_pages_ThuChi_Add_Thu" %>

<%@ Register Src="~/lib/ui/ThuChi/Add-Thu.ascx" TagPrefix="uc1" TagName="AddThu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AddThu runat="server" Id="AddThu" />
</asp:Content>

