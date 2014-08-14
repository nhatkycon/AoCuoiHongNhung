<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_Default" %>

<%@ Register Src="~/lib/ui/LichHen/Upcoming.ascx" TagPrefix="uc1" TagName="Upcoming" %>
<%@ Register Src="~/lib/ui/LichHen/LichThang.ascx" TagPrefix="uc1" TagName="LichThang" %>
<%@ Register Src="~/lib/ui/KhachHang/SinhNhat.ascx" TagPrefix="uc1" TagName="SinhNhat" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-7">
            <h3>
                Lịch sắp tới
            </h3>   
            <uc1:Upcoming runat="server" ID="Upcoming" />
            <h3>Sinh nhật khách hàng</h3>
            <uc1:SinhNhat runat="server" ID="SinhNhat" />
        </div>
        <div class="col-md-5">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Lịch tháng                   
                </div>
                <div class="panel-body">
                    <uc1:LichThang runat="server" ID="LichThang" />
                </div>
                <div class="panel-footer">
                    <a href="/lib/pages/LichHen/Add.aspx" class="btn btn-default">
                        <i class="glyphicon glyphicon-plus"></i>
                        Thêm mới
                    </a>        
                </div>
            </div>        
        </div>    
    </div>
</asp:Content>

