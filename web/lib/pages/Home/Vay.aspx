<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Vay.aspx.cs" Inherits="lib_pages_Home_Vay" %>

<%@ Register Src="~/lib/ui/ChoThueVay/List.ascx" TagPrefix="uc1" TagName="List" %>
<%@ Register Src="~/lib/ui/GiatLa/List.ascx" TagPrefix="uc2" TagName="List" %>
<%@ Register Src="~/lib/ui/XuatNhapSanPham/List.ascx" TagPrefix="uc3" TagName="List" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-7">
            <h3>
                Xuất Sản phẩm phụ kiện
            </h3>   
            <uc3:List runat="server" ID="ListXuatNhap" />
            <h3>
                Cho thuê váy
            </h3>
            <uc1:List runat="server" ID="ListChoThueVay" />
        </div>
        <div class="col-md-5">
            <h3>
                Giặt là
            </h3>     
            <uc2:List runat="server" ID="ListGiatLa" />
        </div>    
    </div>
</asp:Content>

