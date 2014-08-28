<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Print.master" AutoEventWireup="true" CodeFile="In-Chi.aspx.cs" Inherits="lib_pages_ThuChi_In_Chi" %>

<%@ Register Src="~/lib/ui/ThuChi/In-PhieuChi.ascx" TagPrefix="uc1" TagName="InPhieuChi" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>
        Phiếu chi: <%=Item.Ma %>
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:InPhieuChi runat="server" Id="InPhieuChi" />
</asp:Content>

