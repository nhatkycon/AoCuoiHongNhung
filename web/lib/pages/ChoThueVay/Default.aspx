<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_ChoThueVay_Default" %>

<%@ Register Src="~/lib/ui/ChoThueVay/List.ascx" TagPrefix="uc1" TagName="List" %>
<%@ Register TagPrefix="uc1" TagName="ListXuatNhapSanPhamTrangThai" Src="~/lib/ui/HeThong/ListXuatNhapSanPhamTrangThai.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="ModuleHeader">
        <div class="panel panel-default">
            <div class="panel-body" role="form">
                <div class="form-inline">
                    <div class="form-group pull-left">
                        <a href="/lib/pages/ChoThueVay/Add.aspx" class="btn btn-primary">Thêm</a>      
                        <a href="/lib/pages/ChoThueVay/Default.aspx" class="btn btn-success">
                            <i class="glyphicon glyphicon-refresh"></i>
                        </a>
                    </div>
                    <div class="form-group pull-right">
                        <a href="javascript:;" class="btn btn-default" data-toggle="collapse" data-target="#filtering">
                            <i class="glyphicon glyphicon-search"></i>
                        </a>
                    </div>
                </div>
            </div>               
        </div>
        <div id="filtering" class="panel panel-default collapse">
            <div class="panel-body">
                <div class="form-inline">
                    <div class="row">
                        <div class="col-sm-2">
                            <uc1:ListXuatNhapSanPhamTrangThai runat="server" ID="ListXuatNhapSanPhamTrangThai" />
                        </div>
                        
                        <div class="col-sm-2">
                            <div class="pull-right">
                                <div class="input-group">
                                  <input name="q" type="text" value="<%=Request["q"] %>" class="form-control">
                                  <div class="input-group-btn">
                                    <a class="btn btn-default searchBtn">
                                        <i class="glyphicon glyphicon-search"></i>
                                    </a>                                
                                  </div>
                                </div>            
                            </div>                    
                        </div>
                    </div>   
                </div>            
            </div>
        </div>
    </div>    <uc1:List runat="server" id="List" />
    <ul class="pagination">
        <%=paging %>
    </ul>
</asp:Content>

