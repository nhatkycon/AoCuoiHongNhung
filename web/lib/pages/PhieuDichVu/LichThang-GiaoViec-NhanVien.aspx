<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="LichThang-GiaoViec-NhanVien.aspx.cs" Inherits="lib_pages_PhieuDichVu_LichThang_GiaoViec_NhanVien" %>
<%@ Register Src="~/lib/ui/PhieuDichVu/LichThang.ascx" TagPrefix="uc2" TagName="LichThang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default">
    <div class="panel-heading">
        Lịch làm việc                   
    </div>
    <div class="panel-body">
        <uc2:LichThang runat="server" ShowHeader="True" Target="/lib/pages/PhieuDichVu/Default.aspx" ID="LichThang" />
    </div>
</div>
</asp:Content>

