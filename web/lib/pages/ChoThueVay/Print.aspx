﻿<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Print.master" AutoEventWireup="true" CodeFile="Print.aspx.cs" Inherits="lib_pages_ChoThueVay_Print" %>

<%@ Register Src="~/lib/ui/ChoThueVay/templates/Item-Print.ascx" TagPrefix="uc1" TagName="ItemPrint" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ItemPrint runat="server" ID="Add" />
</asp:Content>

