<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="SapToi.aspx.cs" Inherits="lib_pages_LichHen_SapToi" %>
<%@ Register TagPrefix="uc1" TagName="DanhSach" Src="~/lib/ui/LichHen/DanhSach.ascx" %>
<%@ Register TagPrefix="uc2" TagName="DanhMucListByLdmMa" Src="~/lib/ui/HeThong/DanhMucListByLdmMa.ascx" %>
<%@ Register Src="~/lib/ui/LichHen/Upcoming.ascx" TagPrefix="uc1" TagName="Upcoming" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Upcoming runat="server" ID="Upcoming" />

</asp:Content>

