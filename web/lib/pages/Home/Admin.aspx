<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="lib_pages_Home_Admin" %>
<%@ Register Src="~/lib/ui/PhieuDichVu/LichThang.ascx" TagPrefix="uc2" TagName="LichThang" %>
<%@ Register Src="~/lib/ui/LichHen/EventsViewer.ascx" TagPrefix="uc1" TagName="EventsViewer" %>
<%@ Register Src="~/lib/ui/KhachHang/SinhNhat.ascx" TagPrefix="uc1" TagName="SinhNhat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-7">
            <h3>
                Lịch sắp tới
            </h3>   
            <uc1:EventsViewer Target="/lib/pages/PhieuDichVu/Add.aspx?ID=" runat="server" ID="EventsViewer" />
            <h3>Sinh nhật khách hàng</h3>
            <uc1:SinhNhat runat="server" ID="SinhNhat" />
        </div>
        <div class="col-md-5">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Lịch tháng                   
                </div>
                <div class="panel-body">
                    <uc2:LichThang runat="server" ShowHeader="True" Target="/lib/pages/PhieuDichVu/Default.aspx" ID="LichThang" />
                </div>
            </div>        
        </div>    
    </div>
</asp:Content>

