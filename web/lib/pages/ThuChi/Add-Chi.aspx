<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Add-Chi.aspx.cs" Inherits="lib_pages_ThuChi_Add_Chi" %>

<%@ Register Src="~/lib/ui/ThuChi/Add-Chi.ascx" TagPrefix="uc1" TagName="AddChi" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AddChi runat="server" Id="AddChi" />
</asp:Content>

