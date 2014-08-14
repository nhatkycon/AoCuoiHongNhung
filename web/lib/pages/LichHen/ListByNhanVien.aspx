<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="ListByNhanVien.aspx.cs" Inherits="lib_pages_LichHen_ListByNhanVien" %>

<%@ Register Src="~/lib/ui/LichHen/ListByNhanVien.ascx" TagPrefix="uc1" TagName="ListByNhanVien" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ListByNhanVien runat="server" ID="ListByNhanVien" />
</asp:Content>

