<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_Empty.master" AutoEventWireup="true" CodeFile="MemberList.aspx.cs" Inherits="lib_pages_MemberList" %>

<%@ Register Src="~/lib/ui/HeThong/UserList.ascx" TagPrefix="uc1" TagName="UserList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:UserList runat="server" ID="UserList" />
</asp:Content>

