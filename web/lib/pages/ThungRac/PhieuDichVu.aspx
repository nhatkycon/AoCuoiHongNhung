<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="PhieuDichVu.aspx.cs" Inherits="lib_pages_ThungRac_PhieuDichVu" %>
<%@ Register Src="~/lib/ui/PhieuDichVu/List-ThungRac.ascx" TagPrefix="uc1" TagName="ListThungRac" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ListThungRac runat="server" ID="List" />
    <ul class="pagination">
        <%=paging %>
    </ul>
</asp:Content>

