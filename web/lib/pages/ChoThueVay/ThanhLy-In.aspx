<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Print.master" AutoEventWireup="true" CodeFile="ThanhLy-In.aspx.cs" Inherits="lib_pages_ChoThueVay_ThanhLy_In" %>

<%@ Register Src="~/lib/ui/ChoThueVay/ThanhLy-In.ascx" TagPrefix="uc1" TagName="ThanhLyIn" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ThanhLyIn runat="server" ID="ThanhLyIn" />
</asp:Content>

