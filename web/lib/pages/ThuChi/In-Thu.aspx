<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Print.master" AutoEventWireup="true" CodeFile="In-Thu.aspx.cs" Inherits="lib_pages_ThuChi_In_Thu" %>

<%@ Register Src="~/lib/ui/ThuChi/In-PhieuThu.ascx" TagPrefix="uc1" TagName="InPhieuThu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>
        Phiếu thu: <%=Item.Ma %>
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:InPhieuThu runat="server" Id="InPhieuThu" />
</asp:Content>

