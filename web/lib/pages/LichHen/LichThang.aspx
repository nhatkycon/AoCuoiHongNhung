<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="LichThang.aspx.cs" Inherits="lib_pages_LichHen_LichThang" %>

<%@ Register Src="~/lib/ui/LichHen/LichThang.ascx" TagPrefix="uc1" TagName="LichThang" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:LichThang runat="server" ID="LichThang" />
</asp:Content>

