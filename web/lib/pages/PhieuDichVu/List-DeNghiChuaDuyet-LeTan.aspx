<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="List-DeNghiChuaDuyet-LeTan.aspx.cs" Inherits="lib_pages_PhieuDichVu_List_DeNghiChuaDuyet_LeTan" %>
<%@ Register Src="~/lib/ui/PhieuDichVu/List.ascx" TagPrefix="uc1" TagName="List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:List runat="server" id="List" />
    <ul class="pagination">
        <%=paging %>
    </ul>
</asp:Content>

