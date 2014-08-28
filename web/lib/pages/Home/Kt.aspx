<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Kt.aspx.cs" Inherits="lib_pages_Home_Kt" %>
<%@ Register TagPrefix="uc1" TagName="ListKt" Src="~/lib/ui/PhieuDichVu/List-Kt.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-7">
            <div class="col-md-6">
                <a class="btn btn-primary btn-block" href="/lib/pages/ThuChi/Add-Thu.aspx">
                    Viết phiếu thu
                </a>    
            </div>
            <div class="col-md-6">
                <a class="btn btn-primary btn-block"  href="/lib/pages/ThuChi/Add-Chi.aspx">
                    Viết phiếu chi
                </a>    
            </div>
        </div>
        <div class="col-md-5">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Phiếu dịch vụ
                </div>
                <div class="panel-body">
                    <uc1:ListKt runat="server" ID="List" />
                </div>
            </div>
        </div>    
    </div>
</asp:Content>

