﻿<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="lib_pages_ChoThueVay_Add" %>

<%@ Register Src="~/lib/ui/ChoThueVay/Add.ascx" TagPrefix="uc1" TagName="Add" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Add runat="server" Id="Add" />
</asp:Content>

